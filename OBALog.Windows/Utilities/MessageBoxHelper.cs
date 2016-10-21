using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public class MessageBoxHelper : XtraMessageBoxForm
    {

        private Timer CountdownTimer;
        private bool countDownCaption;
        private bool autoClose;
        private int timeout;
        private DialogResult timeoutResult;
        private string baseCaption;
        private bool captionWasCoped;
        private bool selectNext;
        private bool disablebttns;
        private bool disableCancel;
        private bool center;
        public bool ShowMessageNextTime;

        private CheckEdit cbShowNextTime;
        public MessageBoxHelper()
            : base()
        {
            baseCaption = "";
            CountdownTimer = new Timer();
            CountdownTimer.Tag = this;
            CountdownTimer.Interval = 1000;
            CountdownTimer.Tick += MyTimer_Tick;
            captionWasCoped = false;
        }

        protected override void OnShown(EventArgs e)
        {

            if (countDownCaption)
            {
                this.Text = string.Format("OBALog will logoff in {0} seconds...", timeout);

            }
            if (selectNext)
            {
                ShowNextTime();
            }
            IButtonControl btnCancel = null;
            if ((this.CancelButton != null) && (this.CancelButton.DialogResult == DialogResult.Cancel))
                btnCancel = this.CancelButton;
            if (disablebttns)
                DisableAllExceptCancel(btnCancel as SimpleButton);
            if ((disableCancel) && (btnCancel != null))
                (btnCancel as SimpleButton).Enabled = false;
            if (center)
                CenterOnParent();
            if (this.timeout > 0)
            {
                this.CountdownTimer.Enabled = true;
                this.CountdownTimer.Start();
            }
            base.OnShown(e);
        }

        void DisableAllExceptCancel(SimpleButton btnCancel)
        {
            foreach (Control cont in this.Controls)
                if ((cont is BaseButton) && (cont != (btnCancel as SimpleButton)))
                    cont.Enabled = false;
        }

        void MyTimer_Tick(object sender, EventArgs e)
        {

            if (!captionWasCoped)
            {
                baseCaption = this.Message.Caption;
                captionWasCoped = true;
            }
            Timer messageTimer = (sender as Timer);
            timeout--;
            if ((countDownCaption) && (timeout > 0))
            {
                this.Text = string.Format("OBALog will logoff in {0} seconds...", timeout);
            }
            else if (countDownCaption)
            {
                this.Text = baseCaption;
            }
            if (timeout <= 0)
            {
                this.Message.Caption = baseCaption;
                messageTimer.Stop();
                messageTimer.Enabled = false;
                if (autoClose)
                {
                    this.DialogResult = timeoutResult;
                    base.Close();
                }
            }
        }

        public DialogResult ShowForm(MyXtraMessageArgs messageArgs)
        {
            selectNext = messageArgs.ShowNextTime;
            disablebttns = messageArgs.DisableButtons;
            disableCancel = messageArgs.DisableCancel;
            autoClose = messageArgs.AutoClose;
            countDownCaption = messageArgs.ShowCountdown;
            timeout = messageArgs.Timeout;
            center = messageArgs.Center;
            timeoutResult = messageArgs.AutoCloseResult;

            return base.ShowMessageBoxDialog(messageArgs);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (cbShowNextTime != null)
                this.ShowMessageNextTime = cbShowNextTime.Checked;
            this.CountdownTimer.Stop();
            this.CountdownTimer.Dispose();
            base.OnClosing(e);
        }

        void ShowNextTime()
        {
            cbShowNextTime = new CheckEdit();
            cbShowNextTime.Checked = true;
            cbShowNextTime.Text = "Show this dialog again?";
            cbShowNextTime.Properties.AutoWidth = true;
            cbShowNextTime.Properties.AutoHeight = true;
            this.Height += cbShowNextTime.Height;
            cbShowNextTime.Location = new Point(1, this.ClientSize.Height - cbShowNextTime.Height - 1);
            this.Controls.Add(cbShowNextTime);
        }

        void CenterOnParent()
        {
            int y = this.Owner.Height - this.Height;
            int x = this.Owner.Width - this.Width;
            this.Location = new Point(x / 2 + this.Owner.Location.X, y / 2 + this.Owner.Location.Y);
        }
    }

    public class MyXtraMessageArgs : XtraMessageBoxArgs
    {
        public bool ShowCountdown { get; set; }
        public bool ShowNextTime { get; set; }
        public bool DisableCancel { get; set; }
        public bool DisableButtons { get; set; }
        public bool AutoClose { get; set; }
        public DialogResult AutoCloseResult { get; set; }
        public bool Center { get; set; }
        public int Timeout { get; set; }
        public bool ShowMessageNextTime { get; set; }
        private MessageBoxButtons fButtons;
        public new MessageBoxButtons Buttons
        {
            get
            {
                return this.fButtons;
            }
            set
            {
                base.Buttons = MyXtraMessageBox.GetDialogResultsFromButtons(value);
                this.fButtons = value;
            }
        }

        private string fIcon;
        public new string Icon
        {
            get
            {
                return fIcon;
            }
            set
            {
                fIcon = value;
                base.Icon = MyXtraMessageBox.GetIcon(value);
            }
        }

        public MyXtraMessageArgs()
            : base()
        {
            this.Buttons = MessageBoxButtons.OK;
            this.ShowCountdown = false;
            this.ShowNextTime = false;
            this.DisableButtons = false;
            this.DisableCancel = false;
            this.AutoClose = false;
            this.Center = false;
            this.Timeout = 0;
            this.ShowMessageNextTime = false;
        }
    }

    public static class MyXtraMessageBox
    {
        public static DialogResult Show(MyXtraMessageArgs options)
        {
            MyXtraMessageBoxForm messageForm = new MyXtraMessageBoxForm();
            DialogResult result = messageForm.ShowForm(options);

            options.ShowMessageNextTime = messageForm.ShowMessageNextTime;

            return result;
        }

        public static DialogResult[] GetDialogResultsFromButtons(MessageBoxButtons buttons)
        {
            MethodInfo xtraMessageBoxInfo = typeof(XtraMessageBox).GetMethod("MessageBoxButtonsToDialogResults", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            return (DialogResult[])xtraMessageBoxInfo.Invoke(null, new object[] { buttons });
        }

        public static Icon GetIcon(string iconInfo)
        {
            object icon = Enum.Parse(typeof(MessageBoxIcon), iconInfo);
            MethodInfo xtraMessageBoxInfo = typeof(XtraMessageBox).GetMethod("MessageBoxIconToIcon", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            icon = xtraMessageBoxInfo.Invoke(null, new object[] { icon });
            return (Icon)icon;
        }
    }

    public class MyXtraMessageBoxForm : XtraMessageBoxForm
    {
        private Timer CountdownTimer;
        private bool countDownCaption { get; set; }
        private bool autoClose { get; set; }
        private int timeout { get; set; }

        private DialogResult timeoutResult;
        private string baseCaption { get; set; }
        private bool captionWasCoped { get; set; }
        private bool selectNext { get; set; }
        private bool disablebttns { get; set; }
        private bool disableCancel { get; set; }
        private bool center { get; set; }
        public bool ShowMessageNextTime { get; set; }
        public string text { get; set; }

        private CheckEdit cbShowNextTime;
        public MyXtraMessageBoxForm()
            : base()
        {
            baseCaption = "";
            CountdownTimer = new Timer();
            CountdownTimer.Tag = this;
            CountdownTimer.Interval = 1000;
            CountdownTimer.Tick += MyTimer_Tick;
            captionWasCoped = false;
        }

        protected override void OnShown(EventArgs e)
        {
            if (countDownCaption)
                this.Text = string.Format("OBALog will logoff in {0} seconds...", timeout);
            base.Message.Text = text.Replace("XXXXX", timeout.ToString());

            if (selectNext)
            {
                ShowNextTime();
            }

            IButtonControl btnCancel = null;

            if ((this.CancelButton != null) && (this.CancelButton.DialogResult == DialogResult.Cancel))
                btnCancel = this.CancelButton;
            if (disablebttns)
                DisableAllExceptCancel(btnCancel as SimpleButton);
            if ((disableCancel) && (btnCancel != null))
                (btnCancel as SimpleButton).Enabled = false;
            if (center)
                CenterOnParent();

            if (this.timeout > 0)
            {
                this.CountdownTimer.Enabled = true;
                this.CountdownTimer.Start();
            }

            base.OnShown(e);
        }

        void DisableAllExceptCancel(SimpleButton btnCancel)
        {
            foreach (Control cont in this.Controls)
                if ((cont is BaseButton) && (cont != (btnCancel as SimpleButton)))
                    cont.Enabled = false;
        }

        void MyTimer_Tick(object sender, EventArgs e)
        {
            if (!captionWasCoped)
            {
                baseCaption = this.Message.Caption;
                captionWasCoped = true;
            }
            Timer messageTimer = (sender as Timer);
            timeout--;
            if ((countDownCaption) && (timeout > 0))
            {
                this.Text = string.Format("OBALog will logoff in {0} seconds...", timeout);
                base.Message.Text = text.Replace("XXXXX", timeout.ToString());
                this.Refresh();
            }
            else if (countDownCaption)
            {
                this.Text = baseCaption;
            }
            if (timeout <= 0)
            {
                this.Message.Caption = baseCaption;
                messageTimer.Stop();
                messageTimer.Enabled = false;
                if (autoClose)
                {
                    this.DialogResult = timeoutResult;
                    base.Close();
                }
            }
        }

        public DialogResult ShowForm(MyXtraMessageArgs messageArgs)
        {
            selectNext = messageArgs.ShowNextTime;
            disablebttns = messageArgs.DisableButtons;
            disableCancel = messageArgs.DisableCancel;
            autoClose = messageArgs.AutoClose;
            countDownCaption = messageArgs.ShowCountdown;
            timeout = messageArgs.Timeout;
            center = messageArgs.Center;
            timeoutResult = messageArgs.AutoCloseResult;

            text = messageArgs.Text;

            return base.ShowMessageBoxDialog(messageArgs);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            if (cbShowNextTime != null)
                this.ShowMessageNextTime = cbShowNextTime.Checked;


            if (timeout == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }

            this.CountdownTimer.Stop();
            this.CountdownTimer.Dispose();
            base.OnClosing(e);
        }

        void ShowNextTime()
        {
            cbShowNextTime = new CheckEdit();
            cbShowNextTime.Checked = true;
            cbShowNextTime.Text = "Show this dialog again?";
            cbShowNextTime.Properties.AutoWidth = true;
            cbShowNextTime.Properties.AutoHeight = true;
            this.Height += cbShowNextTime.Height;
            cbShowNextTime.Location = new Point(1, this.ClientSize.Height - cbShowNextTime.Height - 1);
            this.Controls.Add(cbShowNextTime);
        }

        void CenterOnParent()
        {
            int y = this.Owner.Height - this.Height;
            int x = this.Owner.Width - this.Width;
            this.Location = new Point(x / 2 + this.Owner.Location.X, y / 2 + this.Owner.Location.Y);
        }
    }
}