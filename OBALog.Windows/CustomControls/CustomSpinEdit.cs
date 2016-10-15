using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public class CustomSpinEdit : SpinEdit
    {
        protected override void OnHandleCreated(System.EventArgs e)
        {
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.EditValue = null;

            base.OnHandleCreated(e);
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                EditValue = null;
            }

            base.OnKeyPress(e);
        }
    }
}
