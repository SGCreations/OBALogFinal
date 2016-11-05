using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public class CustomSpinEdit : SpinEdit
    {
        protected override void OnHandleCreated(System.EventArgs e)
        {
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.EditValue = (this.Value.ToString() == null || this.Value == 0) ? null : this.EditValue;
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

        protected override void OnTextChanged(System.EventArgs e)
        {
            if (this.Value.ToString() == null || this.Value == Convert.ToDecimal("0"))
            {
                this.EditValue = null;
            }

            base.OnTextChanged(e);
        }
    }
}
