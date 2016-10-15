namespace OBALog.Windows
{
    partial class ManageUserAccessTypes

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserAccessTypes));
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_uat = new DevExpress.XtraEditors.TextEdit();
            this.lst_uat = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_uat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_uat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_uat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_uat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(251, 191);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(49, 23);
            this.btn_close.TabIndex = 44;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_new_uat
            // 
            this.txt_new_uat.Location = new System.Drawing.Point(138, 12);
            this.txt_new_uat.Name = "txt_new_uat";
            this.txt_new_uat.Size = new System.Drawing.Size(161, 20);
            this.txt_new_uat.TabIndex = 43;
            this.txt_new_uat.EditValueChanged += new System.EventHandler(this.txt_new_uat_EditValueChanged);
            // 
            // lst_uat
            // 
            this.lst_uat.Location = new System.Drawing.Point(12, 12);
            this.lst_uat.Name = "lst_uat";
            this.lst_uat.Size = new System.Drawing.Size(120, 173);
            this.lst_uat.TabIndex = 42;
            this.lst_uat.SelectedIndexChanged += new System.EventHandler(this.lst_uat_SelectedIndexChanged);
            // 
            // btn_delete_uat
            // 
            this.btn_delete_uat.Location = new System.Drawing.Point(251, 162);
            this.btn_delete_uat.Name = "btn_delete_uat";
            this.btn_delete_uat.Size = new System.Drawing.Size(49, 23);
            this.btn_delete_uat.TabIndex = 41;
            this.btn_delete_uat.Text = "&Delete";
            this.btn_delete_uat.Click += new System.EventHandler(this.btn_delete_uat_Click);
            // 
            // btn_save_uat
            // 
            this.btn_save_uat.Location = new System.Drawing.Point(196, 162);
            this.btn_save_uat.Name = "btn_save_uat";
            this.btn_save_uat.Size = new System.Drawing.Size(49, 23);
            this.btn_save_uat.TabIndex = 40;
            this.btn_save_uat.Text = "&Save";
            this.btn_save_uat.Click += new System.EventHandler(this.btn_save_uat_Click);
            // 
            // btn_new_uat
            // 
            this.btn_new_uat.Location = new System.Drawing.Point(141, 162);
            this.btn_new_uat.Name = "btn_new_uat";
            this.btn_new_uat.Size = new System.Drawing.Size(49, 23);
            this.btn_new_uat.TabIndex = 39;
            this.btn_new_uat.Text = "&New";
            this.btn_new_uat.Click += new System.EventHandler(this.btn_new_uat_Click);
            // 
            // ManageUserAccessTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 222);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_new_uat);
            this.Controls.Add(this.lst_uat);
            this.Controls.Add(this.btn_delete_uat);
            this.Controls.Add(this.btn_save_uat);
            this.Controls.Add(this.btn_new_uat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageUserAccessTypes";
            this.Text = "User Access Types";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageUserAccessTypes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_uat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.TextEdit txt_new_uat;
        internal DevExpress.XtraEditors.ListBoxControl lst_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_save_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_new_uat;
    }
}