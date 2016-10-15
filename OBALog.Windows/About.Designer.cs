namespace OBALog.Windows
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.me_copyright_notice = new DevExpress.XtraEditors.MemoEdit();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.me_details = new DevExpress.XtraEditors.MemoEdit();
            this.me_stc_address = new DevExpress.XtraEditors.MemoEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.me_copyright_notice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_details.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_stc_address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // me_copyright_notice
            // 
            this.me_copyright_notice.EditValue = resources.GetString("me_copyright_notice.EditValue");
            this.me_copyright_notice.Location = new System.Drawing.Point(12, 465);
            this.me_copyright_notice.Name = "me_copyright_notice";
            this.me_copyright_notice.Properties.AcceptsReturn = false;
            this.me_copyright_notice.Properties.AllowFocused = false;
            this.me_copyright_notice.Properties.AllowMouseWheel = false;
            this.me_copyright_notice.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.me_copyright_notice.Properties.Appearance.Options.UseTextOptions = true;
            this.me_copyright_notice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.me_copyright_notice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.me_copyright_notice.Properties.ReadOnly = true;
            this.me_copyright_notice.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.me_copyright_notice.Size = new System.Drawing.Size(851, 60);
            this.me_copyright_notice.TabIndex = 30;
            this.me_copyright_notice.Paint += new System.Windows.Forms.PaintEventHandler(this.txt_Paint);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(788, 558);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 31;
            this.btClose.Text = "&Close";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // me_details
            // 
            this.me_details.EditValue = resources.GetString("me_details.EditValue");
            this.me_details.Location = new System.Drawing.Point(12, 388);
            this.me_details.Name = "me_details";
            this.me_details.Properties.AcceptsReturn = false;
            this.me_details.Properties.AllowFocused = false;
            this.me_details.Properties.AllowMouseWheel = false;
            this.me_details.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.me_details.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.me_details.Properties.Appearance.Options.UseFont = true;
            this.me_details.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.me_details.Properties.ReadOnly = true;
            this.me_details.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.me_details.Size = new System.Drawing.Size(851, 71);
            this.me_details.TabIndex = 32;
            this.me_details.Paint += new System.Windows.Forms.PaintEventHandler(this.txt_Paint);
            // 
            // me_stc_address
            // 
            this.me_stc_address.EditValue = "S. Thomas\' College,\r\nMount Lavinia,\r\nSri Lanka.";
            this.me_stc_address.Location = new System.Drawing.Point(12, 335);
            this.me_stc_address.Name = "me_stc_address";
            this.me_stc_address.Properties.AcceptsReturn = false;
            this.me_stc_address.Properties.AllowFocused = false;
            this.me_stc_address.Properties.AllowMouseWheel = false;
            this.me_stc_address.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.me_stc_address.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.me_stc_address.Properties.Appearance.Options.UseFont = true;
            this.me_stc_address.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.me_stc_address.Properties.ReadOnly = true;
            this.me_stc_address.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.me_stc_address.Size = new System.Drawing.Size(851, 47);
            this.me_stc_address.TabIndex = 33;
            this.me_stc_address.Paint += new System.Windows.Forms.PaintEventHandler(this.txt_Paint);
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "-THIS PRODUCT IS A CONTRIBUTION MADE TO COLLEGE BY ALL INVOLVED TO ASSIST THE OBA" +
    " IN THEIR DAILY MANAGEMENT AND TO FACILITATE THE PROVISION OF MORE EFFECTIVE AND" +
    " BETTER SERVICES BY THE OBA-";
            this.memoEdit1.Location = new System.Drawing.Point(12, 529);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.AcceptsReturn = false;
            this.memoEdit1.Properties.AllowFocused = false;
            this.memoEdit1.Properties.AllowMouseWheel = false;
            this.memoEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.memoEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.memoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(851, 32);
            this.memoEdit1.TabIndex = 34;
            this.memoEdit1.Paint += new System.Windows.Forms.PaintEventHandler(this.txt_Paint);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::OBALog.Windows.Properties.Resources.App_About_Aug_2016;
            this.PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(851, 317);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 23;
            this.PictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AcceptButton = this.btClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 592);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.me_stc_address);
            this.Controls.Add(this.me_details);
            this.Controls.Add(this.me_copyright_notice);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.me_copyright_notice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_details.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_stc_address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        private DevExpress.XtraEditors.MemoEdit me_copyright_notice;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.MemoEdit me_details;
        private DevExpress.XtraEditors.MemoEdit me_stc_address;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}