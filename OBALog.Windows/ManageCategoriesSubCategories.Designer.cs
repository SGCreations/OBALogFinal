namespace OBALog.Windows
{
    public partial class ManageCategoriesSubCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCategoriesSubCategories));
            this.lbl_message = new DevExpress.XtraEditors.LabelControl();
            this.txt_new_sub_category = new DevExpress.XtraEditors.TextEdit();
            this.lst_sub_categories = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_sub_category = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_sub_category = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_sub_category = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_category = new DevExpress.XtraEditors.TextEdit();
            this.lst_categories = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_category = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_category = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_category = new DevExpress.XtraEditors.SimpleButton();
            this.grp_categories = new DevExpress.XtraEditors.GroupControl();
            this.grp_sub_categories = new DevExpress.XtraEditors.GroupControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_sub_category.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_sub_categories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_category.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_categories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_categories)).BeginInit();
            this.grp_categories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grp_sub_categories)).BeginInit();
            this.grp_sub_categories.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_message
            // 
            this.lbl_message.Location = new System.Drawing.Point(12, 239);
            this.lbl_message.MaximumSize = new System.Drawing.Size(1000, 100);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(31, 13);
            this.lbl_message.TabIndex = 6;
            this.lbl_message.Text = "Label1";
            this.lbl_message.Visible = false;
            // 
            // txt_new_sub_category
            // 
            this.txt_new_sub_category.Location = new System.Drawing.Point(170, 25);
            this.txt_new_sub_category.Name = "txt_new_sub_category";
            this.txt_new_sub_category.Size = new System.Drawing.Size(183, 20);
            this.txt_new_sub_category.TabIndex = 5;
            this.txt_new_sub_category.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_sub_categories
            // 
            this.lst_sub_categories.Location = new System.Drawing.Point(5, 25);
            this.lst_sub_categories.Name = "lst_sub_categories";
            this.lst_sub_categories.Size = new System.Drawing.Size(155, 186);
            this.lst_sub_categories.TabIndex = 4;
            this.lst_sub_categories.SelectedIndexChanged += new System.EventHandler(this.lst_sub_categories_SelectedIndexChanged);
            // 
            // btn_delete_sub_category
            // 
            this.btn_delete_sub_category.Location = new System.Drawing.Point(296, 51);
            this.btn_delete_sub_category.Name = "btn_delete_sub_category";
            this.btn_delete_sub_category.Size = new System.Drawing.Size(57, 23);
            this.btn_delete_sub_category.TabIndex = 3;
            this.btn_delete_sub_category.Text = "Delete";
            this.btn_delete_sub_category.Click += new System.EventHandler(this.btn_delete_sub_category_Click);
            // 
            // btn_save_sub_category
            // 
            this.btn_save_sub_category.Location = new System.Drawing.Point(233, 51);
            this.btn_save_sub_category.Name = "btn_save_sub_category";
            this.btn_save_sub_category.Size = new System.Drawing.Size(57, 23);
            this.btn_save_sub_category.TabIndex = 2;
            this.btn_save_sub_category.Text = "Save";
            this.btn_save_sub_category.Click += new System.EventHandler(this.btn_save_sub_category_Click);
            // 
            // btn_new_sub_category
            // 
            this.btn_new_sub_category.Location = new System.Drawing.Point(170, 51);
            this.btn_new_sub_category.Name = "btn_new_sub_category";
            this.btn_new_sub_category.Size = new System.Drawing.Size(57, 23);
            this.btn_new_sub_category.TabIndex = 1;
            this.btn_new_sub_category.Text = "New";
            this.btn_new_sub_category.Click += new System.EventHandler(this.btn_new_sub_category_Click);
            // 
            // txt_new_category
            // 
            this.txt_new_category.Location = new System.Drawing.Point(170, 25);
            this.txt_new_category.Name = "txt_new_category";
            this.txt_new_category.Size = new System.Drawing.Size(183, 20);
            this.txt_new_category.TabIndex = 5;
            this.txt_new_category.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_categories
            // 
            this.lst_categories.Location = new System.Drawing.Point(5, 25);
            this.lst_categories.Name = "lst_categories";
            this.lst_categories.Size = new System.Drawing.Size(155, 186);
            this.lst_categories.TabIndex = 4;
            this.lst_categories.SelectedIndexChanged += new System.EventHandler(this.lst_categories_SelectedIndexChanged);
            // 
            // btn_delete_category
            // 
            this.btn_delete_category.Location = new System.Drawing.Point(296, 51);
            this.btn_delete_category.Name = "btn_delete_category";
            this.btn_delete_category.Size = new System.Drawing.Size(57, 23);
            this.btn_delete_category.TabIndex = 3;
            this.btn_delete_category.Text = "Delete";
            this.btn_delete_category.Click += new System.EventHandler(this.btn_delete_category_Click);
            // 
            // btn_save_category
            // 
            this.btn_save_category.Location = new System.Drawing.Point(233, 51);
            this.btn_save_category.Name = "btn_save_category";
            this.btn_save_category.Size = new System.Drawing.Size(57, 23);
            this.btn_save_category.TabIndex = 2;
            this.btn_save_category.Text = "Save";
            this.btn_save_category.Click += new System.EventHandler(this.btn_save_category_Click);
            // 
            // btn_new_category
            // 
            this.btn_new_category.Location = new System.Drawing.Point(170, 51);
            this.btn_new_category.Name = "btn_new_category";
            this.btn_new_category.Size = new System.Drawing.Size(57, 23);
            this.btn_new_category.TabIndex = 1;
            this.btn_new_category.Text = "New";
            this.btn_new_category.Click += new System.EventHandler(this.btn_new_category_Click);
            // 
            // grp_categories
            // 
            this.grp_categories.Controls.Add(this.txt_new_category);
            this.grp_categories.Controls.Add(this.lst_categories);
            this.grp_categories.Controls.Add(this.btn_new_category);
            this.grp_categories.Controls.Add(this.btn_delete_category);
            this.grp_categories.Controls.Add(this.btn_save_category);
            this.grp_categories.Location = new System.Drawing.Point(12, 12);
            this.grp_categories.Name = "grp_categories";
            this.grp_categories.Size = new System.Drawing.Size(360, 216);
            this.grp_categories.TabIndex = 10;
            this.grp_categories.Text = "Organization Categories:";
            // 
            // grp_sub_categories
            // 
            this.grp_sub_categories.Controls.Add(this.lst_sub_categories);
            this.grp_sub_categories.Controls.Add(this.txt_new_sub_category);
            this.grp_sub_categories.Controls.Add(this.btn_new_sub_category);
            this.grp_sub_categories.Controls.Add(this.btn_save_sub_category);
            this.grp_sub_categories.Controls.Add(this.btn_delete_sub_category);
            this.grp_sub_categories.Location = new System.Drawing.Point(378, 12);
            this.grp_sub_categories.Name = "grp_sub_categories";
            this.grp_sub_categories.Size = new System.Drawing.Size(360, 216);
            this.grp_sub_categories.TabIndex = 10;
            this.grp_sub_categories.Text = "Organization Sub Categories:";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(681, 234);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(57, 23);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ManageCategoriesSubCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 264);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.grp_sub_categories);
            this.Controls.Add(this.grp_categories);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageCategoriesSubCategories";
            this.Text = "Organization Categories ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCategoriesSubCategories_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_sub_category.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_sub_categories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_category.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_categories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_categories)).EndInit();
            this.grp_categories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grp_sub_categories)).EndInit();
            this.grp_sub_categories.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl lbl_message;
        internal DevExpress.XtraEditors.TextEdit txt_new_sub_category;
        internal DevExpress.XtraEditors.ListBoxControl lst_sub_categories;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_sub_category;
        internal DevExpress.XtraEditors.SimpleButton btn_save_sub_category;
        internal DevExpress.XtraEditors.SimpleButton btn_new_sub_category;
        internal DevExpress.XtraEditors.TextEdit txt_new_category;
        internal DevExpress.XtraEditors.ListBoxControl lst_categories;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_category;
        internal DevExpress.XtraEditors.SimpleButton btn_save_category;
        internal DevExpress.XtraEditors.SimpleButton btn_new_category;
        private DevExpress.XtraEditors.GroupControl grp_categories;
        private DevExpress.XtraEditors.GroupControl grp_sub_categories;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
    }
}