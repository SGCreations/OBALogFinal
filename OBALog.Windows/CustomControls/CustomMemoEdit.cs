using DevExpress.XtraEditors;

namespace OBALog.Windows
{
    public class CustomMemoEdit : MemoEdit
    {
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                SelectionLength = 0;
                base.OnMouseMove(e);
            }
            catch
            {
                throw;
            }
        }
    }
}
