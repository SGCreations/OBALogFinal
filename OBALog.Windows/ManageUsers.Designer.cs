namespace OBALog.Windows
{
    partial class ManageUsers
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
            DevExpress.XtraEditors.LabelControl UserAccessKeyLabel;
            DevExpress.XtraEditors.LabelControl NameLabel;
            DevExpress.XtraEditors.LabelControl PasswordLabel;
            DevExpress.XtraEditors.LabelControl LoginIdLabel;
            DevExpress.XtraEditors.LabelControl label2;
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUsers));
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.lst_users = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_create = new DevExpress.XtraEditors.SimpleButton();
            this.txt_retype_pwd = new DevExpress.XtraEditors.TextEdit();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.txt_nic = new DevExpress.XtraEditors.TextEdit();
            this.txt_login_name = new DevExpress.XtraEditors.TextEdit();
            this.cbo_user_access_type = new DevExpress.XtraEditors.LookUpEdit();
            this.UserValidation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.UserWithPasswordValidation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.mem_desc = new OBALog.Windows.CustomMemoEdit();
            Label1 = new DevExpress.XtraEditors.LabelControl();
            UserAccessKeyLabel = new DevExpress.XtraEditors.LabelControl();
            NameLabel = new DevExpress.XtraEditors.LabelControl();
            PasswordLabel = new DevExpress.XtraEditors.LabelControl();
            LoginIdLabel = new DevExpress.XtraEditors.LabelControl();
            label2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_retype_pwd.Properties)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_login_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_user_access_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserWithPasswordValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_desc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            Label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label1.Location = new System.Drawing.Point(4, 124);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(83, 13);
            Label1.TabIndex = 41;
            Label1.Text = "Retype Password";
            // 
            // UserAccessKeyLabel
            // 
            UserAccessKeyLabel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UserAccessKeyLabel.Location = new System.Drawing.Point(4, 150);
            UserAccessKeyLabel.Name = "UserAccessKeyLabel";
            UserAccessKeyLabel.Size = new System.Drawing.Size(87, 13);
            UserAccessKeyLabel.TabIndex = 41;
            UserAccessKeyLabel.Text = "User Access Type";
            // 
            // NameLabel
            // 
            NameLabel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NameLabel.Location = new System.Drawing.Point(4, 17);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new System.Drawing.Size(28, 13);
            NameLabel.TabIndex = 39;
            NameLabel.Text = "Name";
            // 
            // PasswordLabel
            // 
            PasswordLabel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PasswordLabel.Location = new System.Drawing.Point(4, 98);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new System.Drawing.Size(46, 13);
            PasswordLabel.TabIndex = 37;
            PasswordLabel.Text = "Password";
            // 
            // LoginIdLabel
            // 
            LoginIdLabel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LoginIdLabel.Location = new System.Drawing.Point(4, 43);
            LoginIdLabel.Name = "LoginIdLabel";
            LoginIdLabel.Size = new System.Drawing.Size(57, 13);
            LoginIdLabel.TabIndex = 35;
            LoginIdLabel.Text = "Login Name";
            // 
            // label2
            // 
            label2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(4, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 13);
            label2.TabIndex = 35;
            label2.Text = "NIC";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(115, 95);
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.MaxLength = 20;
            this.txt_password.Properties.UseSystemPasswordChar = true;
            this.txt_password.Size = new System.Drawing.Size(195, 20);
            this.txt_password.TabIndex = 42;
            this.txt_password.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_users
            // 
            this.lst_users.Location = new System.Drawing.Point(12, 12);
            this.lst_users.Name = "lst_users";
            this.lst_users.Size = new System.Drawing.Size(143, 284);
            this.lst_users.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lst_users.TabIndex = 54;
            this.lst_users.SelectedIndexChanged += new System.EventHandler(this.lst_users_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Location = new System.Drawing.Point(223, 302);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(81, 23);
            this.btn_save.TabIndex = 53;
            this.btn_save.Text = "&Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Appearance.Options.UseFont = true;
            this.btn_cancel.Location = new System.Drawing.Point(397, 302);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(81, 23);
            this.btn_cancel.TabIndex = 50;
            this.btn_cancel.Text = "Cl&ose";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.Location = new System.Drawing.Point(310, 302);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(81, 23);
            this.btn_delete.TabIndex = 49;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_create
            // 
            this.btn_create.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_create.Appearance.Options.UseFont = true;
            this.btn_create.Location = new System.Drawing.Point(12, 302);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(143, 23);
            this.btn_create.TabIndex = 48;
            this.btn_create.Text = "&Create User";
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // txt_retype_pwd
            // 
            this.txt_retype_pwd.Location = new System.Drawing.Point(115, 121);
            this.txt_retype_pwd.Name = "txt_retype_pwd";
            this.txt_retype_pwd.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_retype_pwd.Properties.Appearance.Options.UseFont = true;
            this.txt_retype_pwd.Properties.MaxLength = 20;
            this.txt_retype_pwd.Properties.UseSystemPasswordChar = true;
            this.txt_retype_pwd.Size = new System.Drawing.Size(195, 20);
            this.txt_retype_pwd.TabIndex = 43;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule1.Control = this.txt_password;
            compareAgainstControlValidationRule1.ErrorText = "This value is not valid";
            this.UserWithPasswordValidation.SetValidationRule(this.txt_retype_pwd, compareAgainstControlValidationRule1);
            this.txt_retype_pwd.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox1.Controls.Add(this.mem_desc);
            this.GroupBox1.Controls.Add(this.txt_retype_pwd);
            this.GroupBox1.Controls.Add(Label1);
            this.GroupBox1.Controls.Add(UserAccessKeyLabel);
            this.GroupBox1.Controls.Add(this.txt_name);
            this.GroupBox1.Controls.Add(NameLabel);
            this.GroupBox1.Controls.Add(PasswordLabel);
            this.GroupBox1.Controls.Add(label2);
            this.GroupBox1.Controls.Add(LoginIdLabel);
            this.GroupBox1.Controls.Add(this.txt_nic);
            this.GroupBox1.Controls.Add(this.txt_password);
            this.GroupBox1.Controls.Add(this.txt_login_name);
            this.GroupBox1.Controls.Add(this.cbo_user_access_type);
            this.GroupBox1.Location = new System.Drawing.Point(159, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(319, 290);
            this.GroupBox1.TabIndex = 52;
            this.GroupBox1.TabStop = false;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(115, 14);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Properties.MaxLength = 100;
            this.txt_name.Size = new System.Drawing.Size(195, 20);
            this.txt_name.TabIndex = 40;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This field cannot be blank";
            this.UserWithPasswordValidation.SetValidationRule(this.txt_name, conditionValidationRule1);
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.AnyOf;
            conditionValidationRule2.ErrorText = "Required";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.UserValidation.SetValidationRule(this.txt_name, conditionValidationRule2);
            this.txt_name.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // txt_nic
            // 
            this.txt_nic.Location = new System.Drawing.Point(115, 68);
            this.txt_nic.Name = "txt_nic";
            this.txt_nic.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nic.Properties.Appearance.Options.UseFont = true;
            this.txt_nic.Properties.Mask.BeepOnError = true;
            this.txt_nic.Properties.Mask.EditMask = "\\d{9}(V|X)";
            this.txt_nic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_nic.Size = new System.Drawing.Size(195, 20);
            this.txt_nic.TabIndex = 41;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This field cannot be blank";
            this.UserWithPasswordValidation.SetValidationRule(this.txt_nic, conditionValidationRule3);
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Required";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.UserValidation.SetValidationRule(this.txt_nic, conditionValidationRule4);
            this.txt_nic.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // txt_login_name
            // 
            this.txt_login_name.Location = new System.Drawing.Point(115, 40);
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_login_name.Properties.Appearance.Options.UseFont = true;
            this.txt_login_name.Properties.MaxLength = 15;
            this.txt_login_name.Size = new System.Drawing.Size(195, 20);
            this.txt_login_name.TabIndex = 41;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "This field cannot be blank";
            this.UserWithPasswordValidation.SetValidationRule(this.txt_login_name, conditionValidationRule5);
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "Required";
            conditionValidationRule6.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.UserValidation.SetValidationRule(this.txt_login_name, conditionValidationRule6);
            this.txt_login_name.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // cbo_user_access_type
            // 
            this.cbo_user_access_type.Location = new System.Drawing.Point(115, 148);
            this.cbo_user_access_type.Name = "cbo_user_access_type";
            this.cbo_user_access_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_user_access_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccessTypeName", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_user_access_type.Properties.NullText = "";
            this.cbo_user_access_type.Properties.PopupSizeable = false;
            this.cbo_user_access_type.Properties.ShowFooter = false;
            this.cbo_user_access_type.Properties.ShowHeader = false;
            this.cbo_user_access_type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_user_access_type.Size = new System.Drawing.Size(195, 20);
            this.cbo_user_access_type.TabIndex = 49;
            this.cbo_user_access_type.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // UserValidation
            // 
            this.UserValidation.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // UserWithPasswordValidation
            // 
            this.UserWithPasswordValidation.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // mem_desc
            // 
            this.mem_desc.EditValue = resources.GetString("mem_desc.EditValue");
            this.mem_desc.Location = new System.Drawing.Point(6, 184);
            this.mem_desc.Name = "mem_desc";
            this.mem_desc.Properties.AllowFocused = false;
            this.mem_desc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.mem_desc.Properties.ReadOnly = true;
            this.mem_desc.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mem_desc.ShowToolTips = false;
            this.mem_desc.Size = new System.Drawing.Size(304, 99);
            this.mem_desc.TabIndex = 50;
            this.mem_desc.TabStop = false;
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 335);
            this.Controls.Add(this.lst_users);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageUsers";
            this.Text = "Users";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageUsers_FormClosing);
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_retype_pwd.Properties)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_login_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_user_access_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserWithPasswordValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_desc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        
        #endregion

        internal DevExpress.XtraEditors.ListBoxControl lst_users;
        internal DevExpress.XtraEditors.SimpleButton btn_save;
        internal DevExpress.XtraEditors.SimpleButton btn_cancel;
        internal DevExpress.XtraEditors.SimpleButton btn_delete;
        internal DevExpress.XtraEditors.SimpleButton btn_create;
        internal DevExpress.XtraEditors.TextEdit txt_retype_pwd;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevExpress.XtraEditors.TextEdit txt_name;
        internal DevExpress.XtraEditors.TextEdit txt_password;
        internal DevExpress.XtraEditors.TextEdit txt_login_name;
        internal DevExpress.XtraEditors.TextEdit txt_nic;
        private DevExpress.XtraEditors.LookUpEdit cbo_user_access_type;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider UserValidation;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider UserWithPasswordValidation;
        private CustomMemoEdit mem_desc;
    }
}