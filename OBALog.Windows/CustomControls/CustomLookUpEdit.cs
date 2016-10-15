using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public class CustomLookUpEdit : LookUpEdit
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                EditValue = null;
            }
            base.OnKeyPress(e);
        }
    }
}
