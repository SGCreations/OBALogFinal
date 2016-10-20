using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Windows
{
    public partial class ManageUserAccessTypes : XtraForm
    {
        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.UAT_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.UAT_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.UAT_Delete);
        public bool FormDirty { get; set; }
        public string LastUAT { get; set; }

        public int SelectedID { get; set; }
        public bool IsNewRecord { get; set; }

        public ManageUserAccessTypes()
        {
            try
            {
                InitializeComponent();
                if (BindUserAccessTypes() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No user access types are available to show. Please add a new user access type!", "Message");
                    btn_new_uat.PerformClick();
                }
                btn_new_uat.Enabled = hasAccessInsert;
                btn_delete_uat.Enabled = hasAccessDelete;
                btn_save_uat.Enabled = (hasAccessInsert || hasAccessUpdate);
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
                lst_uat.UnSelectAll();
                lst_uat.DataSource = dt;
                lst_uat.DisplayMember = "AccessTypeName";
                lst_uat.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void btn_new_uat_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm(true, false, true, false, false, false);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetForm(bool IsNew, bool lstEnabled, bool txtClear, bool btnNewUserAccessTypeEnabled, bool btnDeleteEnabled, bool focusList)
        {
            lst_uat.Enabled = lstEnabled;
            if (txtClear) txt_new_uat.ClearAndFocus();
            SelectedID = 0;

            btn_new_uat.Enabled = btnNewUserAccessTypeEnabled;
            btn_delete_uat.Enabled = btnDeleteEnabled;
            IsNewRecord = IsNew;
            if (focusList) lst_uat_SelectedIndexChanged(this, new EventArgs());
            FormDirty = false;
        }

        private void lst_uat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_uat.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_uat.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_uat.Text = currentRow.Row["AccessTypeName"].ToString();
                        SelectedID = (int)currentRow.Row["Key"];
                        FormDirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_uat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewRecord && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }
                if (txt_new_uat.IsNotEmpty())
                {
                    using (DataTable Table = new BL_UserAccessType().selectAll(new ML_UserAccessType { AccessTypeName = txt_new_uat.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewRecord)
                            {
                                new BL_UserAccessType().insert(new ML_UserAccessType { AccessTypeName = txt_new_uat.Text.Trim(), UserKey = UniversalVariables.UserKey, UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat) });
                            }
                            else if (SelectedID > 0)
                            {
                                new BL_UserAccessType().update(new ML_UserAccessType { Key = SelectedID, AccessTypeName = txt_new_uat.Text.Trim(), UserKey = UniversalVariables.UserKey, UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat) });
                            }
                            LastUAT = txt_new_uat.Text;
                            BindUserAccessTypes();
                            ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered user access type is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for access type name. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {

                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void SetPrevious()
        {
            if (LastUAT.IsNotEmpty())
            {
                lst_uat.SelectedIndex = lst_uat.FindStringExact(LastUAT);
                FormDirty = false;
            }
        }

        private void btn_delete_uat_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the access type {0} from the database?", lst_uat.Text)) == System.Windows.Forms.DialogResult.OK)
                {
                    new BL_UserAccessType().delete(new ML_UserAccessType { Key = SelectedID });
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("User access type {0} has been successfully deleted.", lst_uat.Text), "Deletion Successful!");
                    BindUserAccessTypes();
                    ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool CloseFormWithChecks()
        {
            if (IsNewRecord)
            {
                ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ManageUserAccessTypes_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }

        private void txt_new_uat_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

    }
}
