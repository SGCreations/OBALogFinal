namespace OBALog.Windows
{
    partial class ManageCountryCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCountryCity));
            this.lbl_message = new DevExpress.XtraEditors.LabelControl();
            this.txt_new_city = new DevExpress.XtraEditors.TextEdit();
            this.lst_city = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_city = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_city = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_city = new DevExpress.XtraEditors.SimpleButton();
            this.txt_new_country = new DevExpress.XtraEditors.TextEdit();
            this.lst_country = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_delete_country = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_country = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_country = new DevExpress.XtraEditors.SimpleButton();
            this.grp_countries = new DevExpress.XtraEditors.GroupControl();
            this.grp_cities = new DevExpress.XtraEditors.GroupControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_city.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_city)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_countries)).BeginInit();
            this.grp_countries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grp_cities)).BeginInit();
            this.grp_cities.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_message
            // 
            this.lbl_message.Location = new System.Drawing.Point(12, 239);
            this.lbl_message.MaximumSize = new System.Drawing.Size(1000, 100);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(31, 13);
            this.lbl_message.TabIndex = 6;
            this.lbl_message.Text = "Status";
            this.lbl_message.Visible = false;
            // 
            // txt_new_city
            // 
            this.txt_new_city.Location = new System.Drawing.Point(170, 25);
            this.txt_new_city.Name = "txt_new_city";
            this.txt_new_city.Size = new System.Drawing.Size(183, 20);
            this.txt_new_city.TabIndex = 5;
            this.txt_new_city.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_city
            // 
            this.lst_city.Location = new System.Drawing.Point(5, 25);
            this.lst_city.Name = "lst_city";
            this.lst_city.Size = new System.Drawing.Size(155, 186);
            this.lst_city.TabIndex = 4;
            this.lst_city.SelectedIndexChanged += new System.EventHandler(this.lst_city_SelectedIndexChanged);
            // 
            // btn_delete_city
            // 
            this.btn_delete_city.Location = new System.Drawing.Point(296, 51);
            this.btn_delete_city.Name = "btn_delete_city";
            this.btn_delete_city.Size = new System.Drawing.Size(57, 23);
            this.btn_delete_city.TabIndex = 3;
            this.btn_delete_city.Text = "Delete";
            this.btn_delete_city.Click += new System.EventHandler(this.btn_delete_city_Click);
            // 
            // btn_save_city
            // 
            this.btn_save_city.Location = new System.Drawing.Point(233, 51);
            this.btn_save_city.Name = "btn_save_city";
            this.btn_save_city.Size = new System.Drawing.Size(57, 23);
            this.btn_save_city.TabIndex = 2;
            this.btn_save_city.Text = "Save";
            this.btn_save_city.Click += new System.EventHandler(this.btn_save_city_Click);
            // 
            // btn_new_city
            // 
            this.btn_new_city.Location = new System.Drawing.Point(170, 51);
            this.btn_new_city.Name = "btn_new_city";
            this.btn_new_city.Size = new System.Drawing.Size(57, 23);
            this.btn_new_city.TabIndex = 1;
            this.btn_new_city.Text = "New";
            this.btn_new_city.Click += new System.EventHandler(this.btn_new_city_Click);
            // 
            // txt_new_country
            // 
            this.txt_new_country.Location = new System.Drawing.Point(170, 25);
            this.txt_new_country.Name = "txt_new_country";
            this.txt_new_country.Size = new System.Drawing.Size(183, 20);
            this.txt_new_country.TabIndex = 5;
            this.txt_new_country.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // lst_country
            // 
            this.lst_country.Location = new System.Drawing.Point(5, 25);
            this.lst_country.Name = "lst_country";
            this.lst_country.Size = new System.Drawing.Size(155, 186);
            this.lst_country.TabIndex = 4;
            this.lst_country.SelectedIndexChanged += new System.EventHandler(this.lst_country_SelectedIndexChanged);
            // 
            // btn_delete_country
            // 
            this.btn_delete_country.Location = new System.Drawing.Point(296, 51);
            this.btn_delete_country.Name = "btn_delete_country";
            this.btn_delete_country.Size = new System.Drawing.Size(57, 23);
            this.btn_delete_country.TabIndex = 3;
            this.btn_delete_country.Text = "Delete";
            this.btn_delete_country.Click += new System.EventHandler(this.btn_delete_country_Click);
            // 
            // btn_save_country
            // 
            this.btn_save_country.Location = new System.Drawing.Point(233, 51);
            this.btn_save_country.Name = "btn_save_country";
            this.btn_save_country.Size = new System.Drawing.Size(57, 23);
            this.btn_save_country.TabIndex = 2;
            this.btn_save_country.Text = "Save";
            this.btn_save_country.Click += new System.EventHandler(this.btn_save_country_Click);
            // 
            // btn_new_country
            // 
            this.btn_new_country.Location = new System.Drawing.Point(170, 51);
            this.btn_new_country.Name = "btn_new_country";
            this.btn_new_country.Size = new System.Drawing.Size(57, 23);
            this.btn_new_country.TabIndex = 1;
            this.btn_new_country.Text = "New";
            this.btn_new_country.Click += new System.EventHandler(this.btn_new_country_Click);
            // 
            // grp_countries
            // 
            this.grp_countries.Controls.Add(this.txt_new_country);
            this.grp_countries.Controls.Add(this.lst_country);
            this.grp_countries.Controls.Add(this.btn_new_country);
            this.grp_countries.Controls.Add(this.btn_delete_country);
            this.grp_countries.Controls.Add(this.btn_save_country);
            this.grp_countries.Location = new System.Drawing.Point(12, 12);
            this.grp_countries.Name = "grp_countries";
            this.grp_countries.Size = new System.Drawing.Size(360, 216);
            this.grp_countries.TabIndex = 10;
            this.grp_countries.Text = "Countries:";
            // 
            // grp_cities
            // 
            this.grp_cities.Controls.Add(this.lst_city);
            this.grp_cities.Controls.Add(this.txt_new_city);
            this.grp_cities.Controls.Add(this.btn_new_city);
            this.grp_cities.Controls.Add(this.btn_save_city);
            this.grp_cities.Controls.Add(this.btn_delete_city);
            this.grp_cities.Location = new System.Drawing.Point(378, 12);
            this.grp_cities.Name = "grp_cities";
            this.grp_cities.Size = new System.Drawing.Size(360, 216);
            this.grp_cities.TabIndex = 10;
            this.grp_cities.Text = "Cities:";
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
            // ManageCountryCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 264);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.grp_cities);
            this.Controls.Add(this.grp_countries);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageCountryCity";
            this.Text = "Countries & Cities";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCountryCity_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_city.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_city)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_new_country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_countries)).EndInit();
            this.grp_countries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grp_cities)).EndInit();
            this.grp_cities.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl lbl_message;
        internal DevExpress.XtraEditors.TextEdit txt_new_city;
        internal DevExpress.XtraEditors.ListBoxControl lst_city;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_city;
        internal DevExpress.XtraEditors.SimpleButton btn_save_city;
        internal DevExpress.XtraEditors.SimpleButton btn_new_city;
        internal DevExpress.XtraEditors.TextEdit txt_new_country;
        internal DevExpress.XtraEditors.ListBoxControl lst_country;
        internal DevExpress.XtraEditors.SimpleButton btn_delete_country;
        internal DevExpress.XtraEditors.SimpleButton btn_save_country;
        internal DevExpress.XtraEditors.SimpleButton btn_new_country;
        private DevExpress.XtraEditors.GroupControl grp_countries;
        private DevExpress.XtraEditors.GroupControl grp_cities;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
    }
}