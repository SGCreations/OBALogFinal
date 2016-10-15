using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Windows
{
    public partial class ManageSalutations : XtraForm
    {
        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.Salutations_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.Salutations_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.Salutations_Delete);
        public bool FormDirty { get; set; }
        public string LastSalutation { get; set; }

        public int SelectedID { get; set; }
        public bool IsNewRecord { get; set; }

        public ManageSalutations()
        {
            try
            {
                InitializeComponent();
                if (BindSalutation() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No salutations are available to show. Please add a new salutation!", "Message");
                    btn_new_salutation.PerformClick();
                }

                btn_new_salutation.Enabled = hasAccessInsert;
                btn_delete_salutation.Enabled = hasAccessDelete;
                btn_save_salutation.Enabled = (hasAccessInsert || hasAccessUpdate);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindSalutation()
        {
            using (DataTable dt = new BL_Salutation().select(new ML_Salutation { Salutation = null }))
            {
                lst_salutations.UnSelectAll();
                lst_salutations.DataSource = dt;
                lst_salutations.DisplayMember = "Salutation";
                lst_salutations.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void lst_salutations_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_salutations.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_salutations.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_salutation.Text = currentRow.Row["Salutation"].ToString();
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

        private void btn_new_salutation_Click(object sender, EventArgs e)
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

        private void ResetForm(bool IsNew, bool lstEnabled, bool txtClear, bool btnNewSalutationEnabled, bool btnDeleteEnabled, bool focusList)
        {
            lst_salutations.Enabled = lstEnabled;
            if (txtClear) txt_new_salutation.ClearAndFocus();
            SelectedID = 0;

            btn_new_salutation.Enabled = btnNewSalutationEnabled;
            btn_delete_salutation.Enabled = btnDeleteEnabled;
            IsNewRecord = IsNew;
            if (focusList) lst_salutations_SelectedIndexChanged(this, new EventArgs());
            FormDirty = false;
        }

        private void SetPrevious()
        {
            if (LastSalutation.IsNotEmpty())
            {
                lst_salutations.SelectedIndex = lst_salutations.FindStringExact(LastSalutation);
                FormDirty = false;
            }
        }

        private void btn_save_salutation_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewRecord && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_salutation.IsNotEmpty())
                {
                    using (DataTable Table = new BL_Salutation().select(new ML_Salutation { Salutation = txt_new_salutation.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewRecord)
                            {
                                new BL_Salutation().insert(new ML_Salutation { Salutation = txt_new_salutation.Text.Trim(), UserKey = UniversalVariables.UserKey });
                            }
                            else if (SelectedID > 0)
                            {
                                new BL_Salutation().update(new ML_Salutation { Key = SelectedID, Salutation = txt_new_salutation.Text.Trim(), UserKey = UniversalVariables.UserKey });
                            }

                            BindSalutation();
                            ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered salutation is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for salutation. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {

                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_delete_salutation_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BL_Salutation().selectUsage(new ML_Salutation { Key = SelectedID }) == 0)
                {
                    if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the salutation {0} from the database?", lst_salutations.Text)) == System.Windows.Forms.DialogResult.OK)
                    {
                        new BL_Salutation().delete(new ML_Salutation { Key = SelectedID, UserKey = UniversalVariables.UserKey });
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Salutation {0} has been successfully deleted.", lst_salutations.Text), "Deletion Successful!");
                        BindSalutation();
                        ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The salutation you are trying to delete has been referenced in one or more member records. This salutation cannot be deleted.", "Error");
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
        private void ManageSalutations_Load(object sender, EventArgs e)
        {

        }

        private void txt_new_salutation_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ManageSalutations_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }
    }
}
