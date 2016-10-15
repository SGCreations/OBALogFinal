namespace OBALog.Windows
{
    partial class ResetPassword
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.LabelControl Label1;
            DevExpress.XtraEditors.LabelControl PasswordLabel;
            DevExpress.XtraEditors.LabelControl labelControl3;
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.txt_retype_pwd = new DevExpress.XtraEditors.TextEdit();
            this.txt_current_pwd = new DevExpress.XtraEditors.TextEdit();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_update_password = new DevExpress.XtraEditors.SimpleButton();
            this.vp_password = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.mem_desc = new OBALog.Windows.CustomMemoEdit();
            Label1 = new DevExpress.XtraEditors.LabelControl();
            PasswordLabel = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_retype_pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_current_pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vp_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_desc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            Label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label1.Location = new System.Drawing.Point(11, 88);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(84, 13);
            Label1.TabIndex = 45;
            Label1.Text = "Confirm Password";
            // 
            // PasswordLabel
            // 
            PasswordLabel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PasswordLabel.Location = new System.Drawing.Point(11, 62);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new System.Drawing.Size(71, 13);
            PasswordLabel.TabIndex = 44;
            PasswordLabel.Text = "New Password";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelControl3.Location = new System.Drawing.Point(11, 36);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(83, 13);
            labelControl3.TabIndex = 48;
            labelControl3.Text = "Current Password";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(122, 59);
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.MaxLength = 20;
            this.txt_password.Properties.UseSystemPasswordChar = true;
            this.txt_password.Size = new System.Drawing.Size(199, 20);
            this.txt_password.TabIndex = 1;
            this.txt_password.EditValueChanged += new System.EventHandler(this.txt_password_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Current User Name";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(122, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(94, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "LoggedInUserName";
            // 
            // txt_retype_pwd
            // 
            this.txt_retype_pwd.Location = new System.Drawing.Point(122, 85);
            this.txt_retype_pwd.Name = "txt_retype_pwd";
            this.txt_retype_pwd.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_retype_pwd.Properties.Appearance.Options.UseFont = true;
            this.txt_retype_pwd.Properties.MaxLength = 20;
            this.txt_retype_pwd.Properties.UseSystemPasswordChar = true;
            this.txt_retype_pwd.Size = new System.Drawing.Size(199, 20);
            this.txt_retype_pwd.TabIndex = 2;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule1.Control = this.txt_password;
            compareAgainstControlValidationRule1.ErrorText = "This value is not valid";
            this.vp_password.SetValidationRule(this.txt_retype_pwd, compareAgainstControlValidationRule1);
            this.txt_retype_pwd.EditValueChanged += new System.EventHandler(this.txt_retype_pwd_EditValueChanged);
            // 
            // txt_current_pwd
            // 
            this.txt_current_pwd.Location = new System.Drawing.Point(122, 33);
            this.txt_current_pwd.Name = "txt_current_pwd";
            this.txt_current_pwd.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_current_pwd.Properties.Appearance.Options.UseFont = true;
            this.txt_current_pwd.Properties.MaxLength = 20;
            this.txt_current_pwd.Properties.UseSystemPasswordChar = true;
            this.txt_current_pwd.Size = new System.Drawing.Size(199, 20);
            this.txt_current_pwd.TabIndex = 0;
            this.txt_current_pwd.EditValueChanged += new System.EventHandler(this.txt_current_pwd_EditValueChanged);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(272, 175);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(49, 23);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_update_password
            // 
            this.btn_update_password.Location = new System.Drawing.Point(161, 175);
            this.btn_update_password.Name = "btn_update_password";
            this.btn_update_password.Size = new System.Drawing.Size(105, 23);
            this.btn_update_password.TabIndex = 3;
            this.btn_update_password.Text = "&Update Password";
            this.btn_update_password.Click += new System.EventHandler(this.btn_update_password_Click);
            // 
            // mem_desc
            // 
            this.mem_desc.EditValue = resources.GetString("mem_desc.EditValue");
            this.mem_desc.Location = new System.Drawing.Point(12, 111);
            this.mem_desc.Name = "mem_desc";
            this.mem_desc.Properties.AllowFocused = false;
            this.mem_desc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.mem_desc.Properties.ReadOnly = true;
            this.mem_desc.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mem_desc.ShowToolTips = false;
            this.mem_desc.Size = new System.Drawing.Size(309, 58);
            this.mem_desc.TabIndex = 51;
            this.mem_desc.TabStop = false;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 207);
            this.Controls.Add(this.mem_desc);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_update_password);
            this.Controls.Add(labelControl3);
            this.Controls.Add(this.txt_current_pwd);
            this.Controls.Add(this.txt_retype_pwd);
            this.Controls.Add(Label1);
            this.Controls.Add(PasswordLabel);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetPassword_FormClosing);
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_retype_pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_current_pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vp_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_desc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }                
        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        internal DevExpress.XtraEditors.TextEdit txt_retype_pwd;
        internal DevExpress.XtraEditors.TextEdit txt_password;
        internal DevExpress.XtraEditors.TextEdit txt_current_pwd;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.SimpleButton btn_update_password;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vp_password;
        private CustomMemoEdit mem_desc;

    }
}