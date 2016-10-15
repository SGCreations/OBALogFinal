using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class ManageUsers : XtraForm
    {
        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.Users_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.Users_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.Users_Delete);
        public bool FormDirty { get; set; }
        public string LastUser { get; set; }

        public int SelectedID { get; set; }
        public bool IsNewRecord { get; set; }

        public ManageUsers()
        {
            try
            {
                InitializeComponent();

                if (BindUser() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No users are available to show. Please add a new user!", "Message");
                }

                BindUserAccessTypes();

                btn_create.Enabled = hasAccessInsert;
                btn_delete.Enabled = hasAccessDelete;
                btn_save.Enabled = (hasAccessInsert || hasAccessUpdate);
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
                cbo_user_access_type.Properties.DataSource = dt;
                cbo_user_access_type.Properties.DisplayMember = "AccessTypeName";
                cbo_user_access_type.Properties.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private int BindUser()
        {
            using (DataTable dt = new BL_User().selectAll(new ML_User { Key = null }))
            {
                lst_users.UnSelectAll();
                lst_users.DataSource = dt;
                lst_users.DisplayMember = "Name";
                lst_users.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            UserWithPasswordValidation.SetValidationRule(txt_password, new CustomPasswordValidationRule());
            FormDirty = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewRecord && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }
                using (DataTable Table = new BL_User().selectUsage(new ML_User { Key = (SelectedID == 0 ? null : (int?)SelectedID), LoginId = txt_login_name.Text }))
                {
                    if (IsNewRecord)
                    {
                        //New record - insert
                        if (UserWithPasswordValidation.Validate() && UserValidation.Validate())
                        {
                            if (Table.Rows.Count < 1)
                            {
                                new BL_User().insert(new ML_User() { LoginId = txt_login_name.Text.Trim(), Name = txt_name.Text.Trim(), NIC = txt_nic.Text.Trim(), Password = (txt_password.IsEmpty() ? null : txt_password.Text), UserAccessTypeKey = (int)cbo_user_access_type.EditValue, UserKey = UniversalVariables.UserKey });

                                LastUser = txt_name.Text;

                                BindUser();
                                ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                                SetPrevious();
                            }
                            else
                            {
                                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered user login name is already in the database. Please re-check!", "Error");
                            }
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "None of the values can be null / invalid. Please re-check!", "Error!");
                        }
                    }
                    else
                    {
                        //Update
                        if (UserValidation.Validate() && SelectedID > 0)
                        {
                            if (Table.Rows.Count <= 1)
                            {
                                bool IsPasswordReset;

                                if (txt_password.IsNotEmpty())
                                {
                                    IsPasswordReset = UserWithPasswordValidation.Validate();
                                    if (!IsPasswordReset)
                                        return;
                                }
                                else
                                {
                                    IsPasswordReset = false;
                                }

                                new BL_User().update(new ML_User { LoginId = txt_login_name.Text.Trim(), Name = txt_name.Text.Trim(), NIC = txt_nic.Text.Trim(), UserAccessTypeKey = Convert.ToInt32(cbo_user_access_type.EditValue), UserKey = UniversalVariables.UserKey, Key = SelectedID, Password = IsPasswordReset ? (txt_password.IsEmpty() ? null : txt_password.Text) : null });

                                LastUser = txt_name.Text.Trim();
                                BindUser();
                                ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                                SetPrevious();
                            }
                            else
                            {
                                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered user login name is already in the database. Please re-check!", "Error");
                            }
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "None of the values can be null / invalid. Please re-check!", "Error");
                        }
                    }
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
            if (LastUser.IsNotEmpty())
            {
                lst_users.SelectedIndex = lst_users.FindStringExact(LastUser);
            }
            FormDirty = false;
        }

        private void ResetForm(bool IsNew, bool lstEnabled, bool txtClear, bool btnNewUserEnabled, bool btnDeleteEnabled, bool focusList)
        {
            lst_users.Enabled = lstEnabled;
            if (txtClear)
            {
                txt_name.ClearAndFocus();
                txt_login_name.Clear();
                txt_name.Clear();
                txt_nic.Clear();
                txt_password.Clear();
                txt_retype_pwd.Clear();

            }
            SelectedID = 0;
            btn_create.Enabled = btnNewUserEnabled;
            btn_delete.Enabled = btnDeleteEnabled;
            IsNewRecord = IsNew;
            if (focusList) lst_users_SelectedIndexChanged(this, new EventArgs());

            UserWithPasswordValidation.Reset(this);
            UserValidation.Reset(this);
        }

        private void lst_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_users.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_users.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        SelectedID = (int)currentRow.Row["Key"];
                        txt_name.Text = currentRow.Row["Name"].ToString();
                        txt_login_name.Text = currentRow.Row["LoginId"].ToString();
                        txt_nic.Text = currentRow.Row["NIC"].ToString();
                        cbo_user_access_type.EditValue = currentRow.Row["UserAccessTypeKey"].ToString().IsEmpty() ? null : currentRow.Row["UserAccessTypeKey"];
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the user {0} from the database?", lst_users.Text)) == System.Windows.Forms.DialogResult.OK)
                {
                    new BL_User().delete(new ML_User { Key = SelectedID, UserKey = UniversalVariables.UserKey });
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("User {0} has been successfully deleted.", lst_users.Text), "Deletion Successful!");
                    BindUser();
                    ResetForm(false, true, true, hasAccessInsert, hasAccessDelete, true);
                    FormDirty = false;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm(true, false, true, false, false, false);
                FormDirty = false;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ManageUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
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
    }
}
