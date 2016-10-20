using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;
using System.Linq;

namespace OBALog.Windows
{
    public partial class ManagePrivileges : XtraForm
    {
        public ManagePrivileges()
        {
            InitializeComponent();
            BindUserAccessTypes();
            BindFilters();
        }

        private void BindFilters()
        {
            try
            {
                using (DataTable dt = new BL_Privilege().selectFilters())
                {
                    cbo_filter.Properties.DataSource = dt;
                    cbo_filter.Properties.ValueMember = "Privilege";
                    cbo_filter.Properties.DisplayMember = "Privilege";
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void BindPrivileges(int Key)
        {
            try
            {
                using (DataTable dt = new BL_UserAccessType().selectUserPrivilege(new ML_UserAccessType { Key = Key }))
                {
                    gc_assigned_privileges.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindUserAccessTypes()
        {
            using (DataTable dt = new BL_UserAccessType().select(new ML_UserAccessType { AccessTypeName = null }))
            {
                lst_uat.DataSource = dt;
                lst_uat.DisplayMember = "AccessTypeName";
                lst_uat.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void lst_uat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView currentRow = (lst_uat.SelectedItem as DataRowView);

            BindPrivileges(currentRow.Row["Key"].ToString().ToInt());
        }

        private void gv_assigned_privileges_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Allowed")
                {
                    int privilegeKey = Convert.ToInt32(gv_assigned_privileges.GetRowCellValue(e.RowHandle, "Key"));
                    int userAccessTypeKey = (lst_uat.SelectedItem as DataRowView).Row["Key"].ToString().ToInt();

                    SaveToDatabase((bool)e.Value, privilegeKey, userAccessTypeKey);
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_select_all_privileges_Click(object sender, EventArgs e)
        {
            try
            {
                SelectDeselect(true);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void SelectDeselect(bool Allowed)
        {
            if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, string.Format("This will {0} all privileges for the current access type. Proceed?", Allowed ? "select" : "deselect")) == System.Windows.Forms.DialogResult.Yes)
            {
                int userAccessTypeKey = (lst_uat.SelectedItem as DataRowView).Row["Key"].ToString().ToInt();

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);

                for (int i = 0; i < gv_assigned_privileges.RowCount; i++)
                {
                    var rowHandle = gv_assigned_privileges.GetRowHandle(i);

                    if (!gv_assigned_privileges.IsGroupRow(rowHandle))
                    {
                        gv_assigned_privileges.SetRowCellValue(i, "Allowed", Allowed);
                        int privilegeKey = Convert.ToInt32(gv_assigned_privileges.GetRowCellValue(rowHandle, "Key"));

                        if (privilegeKey > 0)
                        {
                            SaveToDatabase(Allowed, privilegeKey, userAccessTypeKey);
                        }
                    }
                }

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                ApplicationUtilities.ShowMessageSplash(UniversalEnum.MessageTypes.Information, "All settings updated!", this);
            }
        }
        private void btn_deselect_all_privileges_Click(object sender, EventArgs e)
        {
            try
            {
                SelectDeselect(false);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private static void SaveToDatabase(bool allowed, int privilegeKey, int userAccessTypeKey)
        {
            new BL_Privilege().setPrivilege(new ML_Privilege { Allowed = allowed, UserAccessTypeKey = userAccessTypeKey, PrivilegeKey = privilegeKey });
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_filter_EditValueChanged(object sender, EventArgs e)
        {
            //if (cbo_filter.IsNotEmpty())
            {
                gv_assigned_privileges.Columns["Privilege"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("[Privilege] LIKE '{0}%'", cbo_filter.EditValue));
            }
        }

        private void gv_assigned_privileges_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            e.Result = GetSortOrder(e.Value1.ToString()).CompareTo(GetSortOrder(e.Value2.ToString()));
            e.Handled = true;
        }

        private int GetSortOrder(string v)
        {
            try
            {
                DataTable datatable = (gc_assigned_privileges.DataSource as DataTable);

                //EnumerableRowCollection<object> aa = (from myRow in datatable.AsEnumerable()
                //                                      where myRow.Field<string>("Category") == "Global"
                //                                      select myRow["Priority"]);

                switch (v)
                {
                    case "Global":
                        return datatable.AsEnumerable()
                        .Select(s => new { Category = s.Field<string>("Category"), Priority = s.Field<int>("Priority") })
                        .Distinct()
                        .Where(f => f.Category == "Global")
                        .Distinct()
                        .Select(f => f.Priority).ToList()[0];

                    case "Custom":
                        return datatable.AsEnumerable()
                        .Select(s => new { Category = s.Field<string>("Category"), Priority = s.Field<int>("Priority") })
                        .Distinct()
                        .Where(f => f.Category == "Custom")
                        .Distinct()
                        .Select(f => f.Priority).ToList()[0];

                    case "Local":
                        return datatable.AsEnumerable()
                        .Select(s => new { Category = s.Field<string>("Category"), Priority = s.Field<int>("Priority") })
                        .Distinct()
                        .Where(f => f.Category == "Local")
                        .Distinct()
                        .Select(f => f.Priority).ToList()[0];
                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);

                return 0;
            }
        }

        private void btn_clear_filter_Click(object sender, EventArgs e)
        {
            cbo_filter.EditValue = string.Empty;
        }
    }
}
