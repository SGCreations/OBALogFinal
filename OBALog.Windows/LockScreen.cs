using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class LockScreen : XtraForm
    {
        public LockScreen()
        {
            InitializeComponent();
            lbl_user_full_name.Text = UniversalVariables.Name;
        }
        private void LockScreen_Paint(object sender, PaintEventArgs e)
        {
            var hb = new HatchBrush(HatchStyle.Percent10, this.TransparencyKey);
            e.Graphics.FillRectangle(hb, this.DisplayRectangle);
        }
        private void txt_password_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            validateUnlock();
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validateUnlock();
            }
        }

        private void validateUnlock()
        {
            try
            {
                DataSet user = new BL_User().checkLogin(new ML_User { LoginId = UniversalVariables.Username, Password = txt_password.Text });

                if (user.Tables[0].Rows.Count == 1 && user.Tables[1].Rows.Count > 0)
                {
                    this.Hide();
                    Home.InactivityTimer.Enabled = true;
                    Home.idleFlag = true;
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The password you entered is wrong. Please retry!", "Wrong Password");
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

        }

    }
}
