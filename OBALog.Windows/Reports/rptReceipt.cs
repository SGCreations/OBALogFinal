
using System;
namespace OBALog.Windows
{
    public partial class rptReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceipt()
        {
            InitializeComponent();
            lblPrintedBy.Text = string.Format("This receipt was generated / printed by {0} on {1}.", UniversalVariables.Username, DateTime.Now.ToShortDateString());
        }
    }
}
