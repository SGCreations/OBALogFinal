using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class About : XtraForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Paint(object sender, PaintEventArgs e)
        {
            MemoEdit editor = sender as MemoEdit;
            if (editor != null)
            {
                editor.SelectionLength = 0;
            }
        }

    }
}
