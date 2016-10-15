namespace OBALog.Windows
{
    partial class ManageSalutations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageSalutations));
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_salutation = new DevExpress.XtraEditors.TextEdit();
            this.lst_salutations = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_salutation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_salutation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_salutation = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_salutation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_salutations)).BeginInit();
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
            // txt_new_salutation
            // 
            this.txt_new_salutation.Location = new System.Drawing.Point(138, 12);
            this.txt_new_salutation.Name = "txt_new_salutation";
            this.txt_new_salutation.Size = new System.Drawing.Size(161, 20);
            this.txt_new_salutation.TabIndex = 43;
            this.txt_new_salutation.EditValueChanged += new System.EventHandler(this.txt_new_salutation_EditValueChanged);
            // 
            // lst_salutations
            // 
            this.lst_salutations.Location = new System.Drawing.Point(12, 12);
            this.lst_salutations.Name = "lst_salutations";
            this.lst_salutations.Size = new System.Drawing.Size(120, 173);
            this.lst_salutations.TabIndex = 42;
            this.lst_salutations.SelectedIndexChanged += new System.EventHandler(this.lst_salutations_SelectedIndexChanged);
            // 
            // btn_delete_salutation
            // 
            this.btn_delete_salutation.Location = new System.Drawing.Point(251, 162);
            this.btn_delete_salutation.Name = "btn_delete_salutation";
            this.btn_delete_salutation.Size = new System.Drawing.Size(49, 23);
            this.btn_delete_salutation.TabIndex = 41;
            this.btn_delete_salutation.Text = "&Delete";
            this.btn_delete_salutation.Click += new System.EventHandler(this.btn_delete_salutation_Click);
            // 
            // btn_save_salutation
            // 
            this.btn_save_salutation.Location = new System.Drawing.Point(196, 162);
            this.btn_save_salutation.Name = "btn_save_salutation";
            this.btn_save_salutation.Size = new System.Drawing.Size(49, 23);
            this.btn_save_salutation.TabIndex = 40;
            this.btn_save_salutation.Text = "&Save";
            this.btn_save_salutation.Click += new System.EventHandler(this.btn_save_salutation_Click);
            // 
            // btn_new_salutation
            // 
            this.btn_new_salutation.Location = new System.Drawing.Point(141, 162);
            this.btn_new_salutation.Name = "btn_new_salutation";
            this.btn_new_salutation.Size = new System.Drawing.Size(49, 23);
            this.btn_new_salutation.TabIndex = 39;
            this.btn_new_salutation.Text = "&New";
            this.btn_new_salutation.Click += new System.EventHandler(this.btn_new_salutation_Click);
            // 
            // ManageSalutations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 222);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_new_salutation);
            this.Controls.Add(this.lst_salutations);
            this.Controls.Add(this.btn_delete_salutation);
            this.Controls.Add(this.btn_save_salutation);
            this.Controls.Add(this.btn_new_salutation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageSalutations";
            this.Text = "Salutations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageSalutations_FormClosing);
            this.Load += new System.EventHandler(this.ManageSalutations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_salutation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_salutations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.TextEdit txt_new_salutation;
        internal DevExpress.XtraEditors.ListBoxControl lst_salutations;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_salutation;
        internal DevExpress.XtraEditors.SimpleButton btn_save_salutation;
        internal DevExpress.XtraEditors.SimpleButton btn_new_salutation;
    }
}