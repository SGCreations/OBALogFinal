using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class TestForm : XtraForm
    {
        public int UATID { get; set; }

        public TestForm()
        {
            try
            {
                InitializeComponent();
                if (BindPrivileges() == 0 & BindUserAccessTypes() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "No privileges and / or user access types are available to show. The system will now exit. Please contact System Administrator!", "Error");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindPrivileges()
        {
            return 0;
            //using (DataTable dt = new BL_Privilege().select(new ML_Privilege { Privilege = null }))
            //{
            //    lst_privileges.DataSource = dt;
            //    lst_privileges.DisplayMember = "Privilege";
            //    lst_privileges.ValueMember = "Key";
            //    return dt.Rows.Count;
            //}
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

        private void ManagePrivileges_Load(object sender, EventArgs e)
        {

        }

        private void grp_privileges_Paint(object sender, PaintEventArgs e)
        {

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
                        UATID = (int)currentRow.Row["Key"];

                        BindPrivilegesByUAT(UATID);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void BindPrivilegesByUAT(int UserAccessTypeKey)
        {
            using (DataTable dt = new BL_Privilege().selectByUAT(UserAccessTypeKey))
            {
                dgv_user_levels.DataSource = dt;
            }
        }

        private void btn_select_privileges_Click(object sender, EventArgs e)
        {
            lst_privileges.SelectAll();
        }

        private void btn_deselect_privileges_Click(object sender, EventArgs e)
        {
            lst_privileges.UnSelectAll();
        }

        private void btn_select_uat_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rptReceipt report = new rptReceipt();
            //report.Parameters["MemberKey"].Value = 2;
            //report.Parameters["MemberKey"].Visible = false;
            //DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
            //tool.ShowPreview();



            using (WebClient client = new WebClient())
            {
                string text = client.DownloadString("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                double milliseconds = Convert.ToInt64(System.Text.RegularExpressions.Regex.Match(text, "(?<=\\btime=\")[^\"]*").Value) / 1000.0;
                var dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
            }
        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
