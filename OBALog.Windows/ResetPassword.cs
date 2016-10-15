using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Windows
{
    public partial class ResetPassword : XtraForm
    {

        public bool FormDirty { get; set; }

        public ResetPassword()
        {
            try
            {
                InitializeComponent();

                lblUserName.Text = UniversalVariables.Username;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }


        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            vp_password.SetValidationRule(txt_password, new CustomPasswordValidationRule());
        }


        private void txt_current_pwd_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_password_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet user = new BL_User().checkLogin(new ML_User { LoginId = UniversalVariables.Username, Password = txt_current_pwd.Text });

                if (user.Tables[0].Rows.Count == 1 && user.Tables[1].Rows.Count > 0)
                {
                    if (vp_password.Validate() && txt_retype_pwd.Text == txt_password.Text)
                    {
                        new BL_User().resetPassword(new ML_User() { Key = UniversalVariables.UserKey, Password = txt_password.Text, LoginId = UniversalVariables.Username });
                        FormDirty = false;
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, "Password changed successfully! The new password will be available from next login.", "Success");
                        this.Close();
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The passwords you have entered do not match or there are errors in the password constraints. Please re-check!", "Error");
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The current password you have entered does not match what is stored in the database. Please re-check. If the problem persists contact the System Administrator.", "Error");
                    txt_current_pwd.Focus();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void txt_password_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void txt_retype_pwd_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ResetPassword_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }

        private bool CloseFormWithChecks()
        {
            return true;
        }
    }
}
