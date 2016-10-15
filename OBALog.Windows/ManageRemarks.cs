using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace OBALog.Windows
{
    public partial class ManageRemarks : XtraForm
    {
        public List<OBALog.Model.ML_RemarksHistory>  RemarksHistory { get; set; }

        public ManageRemarks(List<OBALog.Model.ML_RemarksHistory> remarksHistory)
        {
            InitializeComponent();
            RemarksHistory = remarksHistory;
        }

        private void ManageRemarks_Load(object sender, EventArgs e)
        {
            gc_remarks.DataSource = RemarksHistory;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
