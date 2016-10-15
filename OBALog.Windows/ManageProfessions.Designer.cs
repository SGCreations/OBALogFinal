namespace OBALog.Windows
{
    partial class ManageProfessions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageProfessions));
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_profession = new DevExpress.XtraEditors.TextEdit();
            this.lst_professions = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_profession = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_profession = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_profession = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_profession.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_professions)).BeginInit();
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
            // txt_new_profession
            // 
            this.txt_new_profession.Location = new System.Drawing.Point(138, 12);
            this.txt_new_profession.Name = "txt_new_profession";
            this.txt_new_profession.Size = new System.Drawing.Size(161, 20);
            this.txt_new_profession.TabIndex = 43;
            this.txt_new_profession.EditValueChanged += new System.EventHandler(this.txt_new_profession_EditValueChanged);
            // 
            // lst_professions
            // 
            this.lst_professions.Location = new System.Drawing.Point(12, 12);
            this.lst_professions.Name = "lst_professions";
            this.lst_professions.Size = new System.Drawing.Size(120, 173);
            this.lst_professions.TabIndex = 42;
            this.lst_professions.SelectedIndexChanged += new System.EventHandler(this.lst_professions_SelectedIndexChanged);
            // 
            // btn_delete_profession
            // 
            this.btn_delete_profession.Location = new System.Drawing.Point(251, 162);
            this.btn_delete_profession.Name = "btn_delete_profession";
            this.btn_delete_profession.Size = new System.Drawing.Size(49, 23);
            this.btn_delete_profession.TabIndex = 41;
            this.btn_delete_profession.Text = "&Delete";
            this.btn_delete_profession.Click += new System.EventHandler(this.btn_delete_profession_Click);
            // 
            // btn_save_profession
            // 
            this.btn_save_profession.Location = new System.Drawing.Point(196, 162);
            this.btn_save_profession.Name = "btn_save_profession";
            this.btn_save_profession.Size = new System.Drawing.Size(49, 23);
            this.btn_save_profession.TabIndex = 40;
            this.btn_save_profession.Text = "&Save";
            this.btn_save_profession.Click += new System.EventHandler(this.btn_save_profession_Click);
            // 
            // btn_new_profession
            // 
            this.btn_new_profession.Location = new System.Drawing.Point(141, 162);
            this.btn_new_profession.Name = "btn_new_profession";
            this.btn_new_profession.Size = new System.Drawing.Size(49, 23);
            this.btn_new_profession.TabIndex = 39;
            this.btn_new_profession.Text = "&New";
            this.btn_new_profession.Click += new System.EventHandler(this.btn_new_profession_Click);
            // 
            // ManageProfessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 222);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_new_profession);
            this.Controls.Add(this.lst_professions);
            this.Controls.Add(this.btn_delete_profession);
            this.Controls.Add(this.btn_save_profession);
            this.Controls.Add(this.btn_new_profession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageProfessions";
            this.Text = "Professions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageProfessions_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_profession.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_professions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.TextEdit txt_new_profession;
        internal DevExpress.XtraEditors.ListBoxControl lst_professions;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_profession;
        internal DevExpress.XtraEditors.SimpleButton btn_save_profession;
        internal DevExpress.XtraEditors.SimpleButton btn_new_profession;
    }
}