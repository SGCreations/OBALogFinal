namespace OBALog.Windows
{
    partial class LockScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockScreen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grp_controls = new DevExpress.XtraEditors.GroupControl();
            this.lbl_lock_text = new DevExpress.XtraEditors.LabelControl();
            this.pic_col_crest = new DevExpress.XtraEditors.PictureEdit();
            this.lbl_user_full_name = new DevExpress.XtraEditors.LabelControl();
            this.txt_password = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_controls)).BeginInit();
            this.grp_controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_col_crest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_controls
            // 
            this.grp_controls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grp_controls.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grp_controls.Appearance.Options.UseBackColor = true;
            this.grp_controls.Controls.Add(this.lbl_lock_text);
            this.grp_controls.Controls.Add(this.pic_col_crest);
            this.grp_controls.Controls.Add(this.lbl_user_full_name);
            this.grp_controls.Controls.Add(this.txt_password);
            this.grp_controls.Location = new System.Drawing.Point(45, 69);
            this.grp_controls.Name = "grp_controls";
            this.grp_controls.ShowCaption = false;
            this.grp_controls.Size = new System.Drawing.Size(500, 400);
            this.grp_controls.TabIndex = 0;
            this.grp_controls.Text = "groupControl1";
            // 
            // lbl_lock_text
            // 
            this.lbl_lock_text.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lock_text.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_lock_text.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbl_lock_text.Location = new System.Drawing.Point(50, 219);
            this.lbl_lock_text.Name = "lbl_lock_text";
            this.lbl_lock_text.Size = new System.Drawing.Size(400, 21);
            this.lbl_lock_text.TabIndex = 17;
            this.lbl_lock_text.Text = "OBALog is locked. Please enter your password to unlock...";
            // 
            // pic_col_crest
            // 
            this.pic_col_crest.CausesValidation = false;
            this.pic_col_crest.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pic_col_crest.EditValue = ((object)(resources.GetObject("pic_col_crest.EditValue")));
            this.pic_col_crest.Location = new System.Drawing.Point(167, 24);
            this.pic_col_crest.Name = "pic_col_crest";
            this.pic_col_crest.Properties.AllowFocused = false;
            this.pic_col_crest.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pic_col_crest.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pic_col_crest.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pic_col_crest.Properties.Appearance.Options.UseBackColor = true;
            this.pic_col_crest.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_col_crest.Properties.ReadOnly = true;
            this.pic_col_crest.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_col_crest.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pic_col_crest.Properties.ZoomAccelerationFactor = 1D;
            this.pic_col_crest.Size = new System.Drawing.Size(167, 176);
            this.pic_col_crest.TabIndex = 16;
            // 
            // lbl_user_full_name
            // 
            this.lbl_user_full_name.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_user_full_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_user_full_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbl_user_full_name.Location = new System.Drawing.Point(114, 251);
            this.lbl_user_full_name.Name = "lbl_user_full_name";
            this.lbl_user_full_name.Size = new System.Drawing.Size(272, 26);
            this.lbl_user_full_name.TabIndex = 1;
            this.lbl_user_full_name.Text = "labelControl1";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(114, 303);
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_password.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Properties.Appearance.Options.UseBackColor = true;
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_password.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_password.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 40, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txt_password.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txt_password.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_password.Properties.NullValuePrompt = "Password";
            this.txt_password.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_password.Properties.UseSystemPasswordChar = true;
            this.txt_password.Size = new System.Drawing.Size(272, 38);
            this.txt_password.TabIndex = 0;
            this.txt_password.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_password_ButtonClick);
            this.txt_password.EditValueChanged += new System.EventHandler(this.txt_password_EditValueChanged);
            this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
            // 
            // LockScreen
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 538);
            this.Controls.Add(this.grp_controls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LockScreen";
            this.ShowInTaskbar = false;
            this.Text = "OBALog ";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LockScreen_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.grp_controls)).EndInit();
            this.grp_controls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_col_crest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp_controls;
        private DevExpress.XtraEditors.ButtonEdit txt_password;
        private DevExpress.XtraEditors.LabelControl lbl_user_full_name;
        private DevExpress.XtraEditors.PictureEdit pic_col_crest;
        private DevExpress.XtraEditors.LabelControl lbl_lock_text;
    }
}