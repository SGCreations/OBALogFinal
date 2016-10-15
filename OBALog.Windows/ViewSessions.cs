using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class ViewSessions : XtraForm
    {
        public ViewSessions()
        {
            try
            {
                InitializeComponent();
                BindUsers();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void BindUsers()
        {
            cbo_user.Properties.DataSource = new BL_User().selectAll(new ML_User { Key = null });
            cbo_user.Properties.ValueMember = "Key";
            cbo_user.Properties.DisplayMember = "Name";
        }

        private void btn_populate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_user.SelectedText != null)
                {
                    nud_no_of_records_EditValueChanged(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void nud_no_of_records_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbo_user.IsNotEmpty())
                {
                    gcUserLog.DataSource = new BL_UsageLog().selectByUser(new ML_UsageLog { UserKey = Convert.ToInt32(cbo_user.EditValue) }, Convert.ToInt32(nud_no_of_records.EditValue));
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void cbo_user_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                nud_no_of_records_EditValueChanged(this, new EventArgs());
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
    }
}
