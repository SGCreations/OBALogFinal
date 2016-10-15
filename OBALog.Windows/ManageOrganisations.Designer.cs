namespace OBALog.Windows
{
    partial class ManageOrganisations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageOrganisations));
            this.Label7 = new DevExpress.XtraEditors.LabelControl();
            this.Label6 = new DevExpress.XtraEditors.LabelControl();
            this.Label5 = new DevExpress.XtraEditors.LabelControl();
            this.Label4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_website = new DevExpress.XtraEditors.TextEdit();
            this.Label3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_address = new DevExpress.XtraEditors.TextEdit();
            this.Label2 = new DevExpress.XtraEditors.LabelControl();
            this.Label1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_message = new DevExpress.XtraEditors.LabelControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_organisation = new DevExpress.XtraEditors.TextEdit();
            this.lst_organisation = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_new_organisation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_organisation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete_organisation = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_category = new DevExpress.XtraEditors.LookUpEdit();
            this.cbo_sub_category = new DevExpress.XtraEditors.LookUpEdit();
            this.cbo_country = new DevExpress.XtraEditors.LookUpEdit();
            this.cbo_city = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_website.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_organisation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_organisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_category.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_sub_category.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_city.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(283, 168);
            this.Label7.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 33;
            this.Label7.Text = "Country:";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(472, 168);
            this.Label6.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(23, 13);
            this.Label6.TabIndex = 31;
            this.Label6.Text = "City:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(283, 51);
            this.Label5.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 29;
            this.Label5.Text = "Category:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(283, 12);
            this.Label4.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 13);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Organisation:";
            // 
            // txt_website
            // 
            this.txt_website.Location = new System.Drawing.Point(283, 223);
            this.txt_website.Name = "txt_website";
            this.txt_website.Size = new System.Drawing.Size(371, 20);
            this.txt_website.TabIndex = 26;
            this.txt_website.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(283, 207);
            this.Label3.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(43, 13);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Website:";
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(283, 145);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(371, 20);
            this.txt_address.TabIndex = 24;
            this.txt_address.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(283, 129);
            this.Label2.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "Address:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(283, 90);
            this.Label1.MaximumSize = new System.Drawing.Size(200, 100);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 13);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Sub category:";
            // 
            // lbl_message
            // 
            this.lbl_message.Location = new System.Drawing.Point(283, 246);
            this.lbl_message.MaximumSize = new System.Drawing.Size(200, 100);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(31, 13);
            this.lbl_message.TabIndex = 6;
            this.lbl_message.Text = "Label1";
            this.lbl_message.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(605, 269);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(49, 23);
            this.btn_close.TabIndex = 24;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_new_organisation
            // 
            this.txt_new_organisation.Location = new System.Drawing.Point(283, 28);
            this.txt_new_organisation.Name = "txt_new_organisation";
            this.txt_new_organisation.Size = new System.Drawing.Size(373, 20);
            this.txt_new_organisation.TabIndex = 20;
            this.txt_new_organisation.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_organisation
            // 
            this.lst_organisation.DisplayMember = "Organisation";
            this.lst_organisation.HorizontalScrollbar = true;
            this.lst_organisation.Location = new System.Drawing.Point(12, 12);
            this.lst_organisation.Name = "lst_organisation";
            this.lst_organisation.Size = new System.Drawing.Size(265, 277);
            this.lst_organisation.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lst_organisation.TabIndex = 7;
            this.lst_organisation.ValueMember = "Key";
            this.lst_organisation.SelectedIndexChanged += new System.EventHandler(this.lst_organisation_SelectedIndexChanged);
            // 
            // btn_new_organisation
            // 
            this.btn_new_organisation.Location = new System.Drawing.Point(415, 269);
            this.btn_new_organisation.Name = "btn_new_organisation";
            this.btn_new_organisation.Size = new System.Drawing.Size(57, 23);
            this.btn_new_organisation.TabIndex = 4;
            this.btn_new_organisation.Text = "&New";
            this.btn_new_organisation.Click += new System.EventHandler(this.btn_new_organisation_Click);
            // 
            // btn_save_organisation
            // 
            this.btn_save_organisation.Location = new System.Drawing.Point(478, 269);
            this.btn_save_organisation.Name = "btn_save_organisation";
            this.btn_save_organisation.Size = new System.Drawing.Size(57, 23);
            this.btn_save_organisation.TabIndex = 5;
            this.btn_save_organisation.Text = "&Save";
            this.btn_save_organisation.Click += new System.EventHandler(this.btn_save_organisation_Click);
            // 
            // btn_delete_organisation
            // 
            this.btn_delete_organisation.Location = new System.Drawing.Point(541, 269);
            this.btn_delete_organisation.Name = "btn_delete_organisation";
            this.btn_delete_organisation.Size = new System.Drawing.Size(57, 23);
            this.btn_delete_organisation.TabIndex = 6;
            this.btn_delete_organisation.Text = "&Delete";
            this.btn_delete_organisation.Click += new System.EventHandler(this.btn_delete_organisation_Click);
            // 
            // cbo_category
            // 
            this.cbo_category.Location = new System.Drawing.Point(283, 67);
            this.cbo_category.Name = "cbo_category";
            this.cbo_category.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbo_category.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_category.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_category.Properties.DisplayMember = "Category";
            this.cbo_category.Properties.NullText = "";
            this.cbo_category.Properties.NullValuePrompt = "Select Value";
            this.cbo_category.Properties.NullValuePromptShowForEmptyValue = true;
            this.cbo_category.Properties.PopupSizeable = false;
            this.cbo_category.Properties.ShowFooter = false;
            this.cbo_category.Properties.ShowHeader = false;
            this.cbo_category.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_category.Properties.ValueMember = "Key";
            this.cbo_category.Size = new System.Drawing.Size(183, 20);
            this.cbo_category.TabIndex = 35;
            this.cbo_category.EditValueChanged += new System.EventHandler(this.cbo_category_EditValueChanged);
            this.cbo_category.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_category_KeyPress);
            // 
            // cbo_sub_category
            // 
            this.cbo_sub_category.Location = new System.Drawing.Point(283, 106);
            this.cbo_sub_category.Name = "cbo_sub_category";
            this.cbo_sub_category.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbo_sub_category.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_sub_category.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubCategory", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_sub_category.Properties.NullText = "";
            this.cbo_sub_category.Properties.NullValuePrompt = "Select Value";
            this.cbo_sub_category.Properties.NullValuePromptShowForEmptyValue = true;
            this.cbo_sub_category.Properties.PopupSizeable = false;
            this.cbo_sub_category.Properties.ShowFooter = false;
            this.cbo_sub_category.Properties.ShowHeader = false;
            this.cbo_sub_category.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_sub_category.Size = new System.Drawing.Size(183, 20);
            this.cbo_sub_category.TabIndex = 35;
            this.cbo_sub_category.EditValueChanged += new System.EventHandler(this.cbo_sub_category_EditValueChanged);
            this.cbo_sub_category.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_category_KeyPress);
            // 
            // cbo_country
            // 
            this.cbo_country.Location = new System.Drawing.Point(283, 184);
            this.cbo_country.Name = "cbo_country";
            this.cbo_country.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbo_country.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_country.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Country", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_country.Properties.NullText = "";
            this.cbo_country.Properties.NullValuePrompt = "Select Value";
            this.cbo_country.Properties.NullValuePromptShowForEmptyValue = true;
            this.cbo_country.Properties.PopupSizeable = false;
            this.cbo_country.Properties.ShowFooter = false;
            this.cbo_country.Properties.ShowHeader = false;
            this.cbo_country.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_country.Size = new System.Drawing.Size(183, 20);
            this.cbo_country.TabIndex = 35;
            this.cbo_country.EditValueChanged += new System.EventHandler(this.cbo_country_EditValueChanged);
            this.cbo_country.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_category_KeyPress);
            // 
            // cbo_city
            // 
            this.cbo_city.Location = new System.Drawing.Point(472, 184);
            this.cbo_city.Name = "cbo_city";
            this.cbo_city.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbo_city.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_city.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("City", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_city.Properties.NullText = "";
            this.cbo_city.Properties.NullValuePrompt = "Select Value";
            this.cbo_city.Properties.NullValuePromptShowForEmptyValue = true;
            this.cbo_city.Properties.PopupSizeable = false;
            this.cbo_city.Properties.ShowFooter = false;
            this.cbo_city.Properties.ShowHeader = false;
            this.cbo_city.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_city.Size = new System.Drawing.Size(183, 20);
            this.cbo_city.TabIndex = 35;
            this.cbo_city.EditValueChanged += new System.EventHandler(this.cbo_city_EditValueChanged);
            this.cbo_city.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_category_KeyPress);
            // 
            // ManageOrganisations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 306);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lst_organisation);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.btn_save_organisation);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.btn_new_organisation);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btn_delete_organisation);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txt_new_organisation);
            this.Controls.Add(this.txt_website);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cbo_category);
            this.Controls.Add(this.cbo_sub_category);
            this.Controls.Add(this.cbo_country);
            this.Controls.Add(this.cbo_city);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageOrganisations";
            this.Text = "Organisations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageOrganisations_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_website.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_organisation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_organisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_category.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_sub_category.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_city.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl Label7;
        internal DevExpress.XtraEditors.LabelControl Label6;
        internal DevExpress.XtraEditors.LabelControl Label5;
        internal DevExpress.XtraEditors.LabelControl Label4;
        internal DevExpress.XtraEditors.TextEdit txt_website;
        internal DevExpress.XtraEditors.LabelControl Label3;
        internal DevExpress.XtraEditors.TextEdit txt_address;
        internal DevExpress.XtraEditors.LabelControl Label2;
        internal DevExpress.XtraEditors.LabelControl Label1;
        internal DevExpress.XtraEditors.LabelControl lbl_message;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.TextEdit txt_new_organisation;
        internal DevExpress.XtraEditors.ListBoxControl lst_organisation;
        internal DevExpress.XtraEditors.SimpleButton btn_new_organisation;
        internal DevExpress.XtraEditors.SimpleButton btn_save_organisation;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_organisation;
        private DevExpress.XtraEditors.LookUpEdit cbo_category;
        private DevExpress.XtraEditors.LookUpEdit cbo_sub_category;
        private DevExpress.XtraEditors.LookUpEdit cbo_country;
        private DevExpress.XtraEditors.LookUpEdit cbo_city;
    }
}