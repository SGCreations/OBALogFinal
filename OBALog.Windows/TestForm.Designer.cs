namespace OBALog.Windows
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.grp_privileges = new DevExpress.XtraEditors.GroupControl();
            this.btn_select_privileges = new DevExpress.XtraEditors.SimpleButton();
            this.lst_privileges = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_deselect_privileges = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_privilege_count = new DevExpress.XtraEditors.LabelControl();
            this.grp_access_types = new DevExpress.XtraEditors.GroupControl();
            this.dgv_user_levels = new DevExpress.XtraGrid.GridControl();
            this.gv_assigned_privileges = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrivilege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_select_uat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_deselect_uat = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_uat = new DevExpress.XtraEditors.LabelControl();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.lst_uat = new DevExpress.XtraEditors.ListBoxControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grp_privileges)).BeginInit();
            this.grp_privileges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lst_privileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_access_types)).BeginInit();
            this.grp_access_types.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user_levels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_assigned_privileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_privileges
            // 
            this.grp_privileges.Controls.Add(this.btn_select_privileges);
            this.grp_privileges.Controls.Add(this.lst_privileges);
            this.grp_privileges.Controls.Add(this.btn_deselect_privileges);
            this.grp_privileges.Controls.Add(this.btn_add);
            this.grp_privileges.Controls.Add(this.lbl_privilege_count);
            this.grp_privileges.Location = new System.Drawing.Point(12, 12);
            this.grp_privileges.Name = "grp_privileges";
            this.grp_privileges.Size = new System.Drawing.Size(420, 366);
            this.grp_privileges.TabIndex = 28;
            this.grp_privileges.Text = "Available Privileges:";
            this.grp_privileges.Paint += new System.Windows.Forms.PaintEventHandler(this.grp_privileges_Paint);
            // 
            // btn_select_privileges
            // 
            this.btn_select_privileges.Location = new System.Drawing.Point(5, 304);
            this.btn_select_privileges.Name = "btn_select_privileges";
            this.btn_select_privileges.Size = new System.Drawing.Size(78, 23);
            this.btn_select_privileges.TabIndex = 28;
            this.btn_select_privileges.Text = "Select All";
            this.btn_select_privileges.Click += new System.EventHandler(this.btn_select_privileges_Click);
            // 
            // lst_privileges
            // 
            this.lst_privileges.HorizontalScrollbar = true;
            this.lst_privileges.Location = new System.Drawing.Point(5, 23);
            this.lst_privileges.Name = "lst_privileges";
            this.lst_privileges.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_privileges.Size = new System.Drawing.Size(402, 277);
            this.lst_privileges.TabIndex = 8;
            // 
            // btn_deselect_privileges
            // 
            this.btn_deselect_privileges.Location = new System.Drawing.Point(89, 304);
            this.btn_deselect_privileges.Name = "btn_deselect_privileges";
            this.btn_deselect_privileges.Size = new System.Drawing.Size(78, 23);
            this.btn_deselect_privileges.TabIndex = 27;
            this.btn_deselect_privileges.Text = "Deselect All";
            this.btn_deselect_privileges.Click += new System.EventHandler(this.btn_deselect_privileges_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(173, 304);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(78, 23);
            this.btn_add.TabIndex = 25;
            this.btn_add.Text = "Add";
            // 
            // lbl_privilege_count
            // 
            this.lbl_privilege_count.Location = new System.Drawing.Point(5, 333);
            this.lbl_privilege_count.Name = "lbl_privilege_count";
            this.lbl_privilege_count.Size = new System.Drawing.Size(31, 13);
            this.lbl_privilege_count.TabIndex = 25;
            this.lbl_privilege_count.Text = "Label1";
            // 
            // grp_access_types
            // 
            this.grp_access_types.Controls.Add(this.dgv_user_levels);
            this.grp_access_types.Controls.Add(this.btn_select_uat);
            this.grp_access_types.Controls.Add(this.btn_deselect_uat);
            this.grp_access_types.Controls.Add(this.lbl_uat);
            this.grp_access_types.Controls.Add(this.btn_delete);
            this.grp_access_types.Controls.Add(this.btn_save);
            this.grp_access_types.Controls.Add(this.lst_uat);
            this.grp_access_types.Location = new System.Drawing.Point(438, 12);
            this.grp_access_types.Name = "grp_access_types";
            this.grp_access_types.Size = new System.Drawing.Size(731, 366);
            this.grp_access_types.TabIndex = 29;
            this.grp_access_types.Text = "User Access Type:";
            // 
            // dgv_user_levels
            // 
            this.dgv_user_levels.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgv_user_levels.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgv_user_levels.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgv_user_levels.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgv_user_levels.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgv_user_levels.Location = new System.Drawing.Point(153, 23);
            this.dgv_user_levels.MainView = this.gv_assigned_privileges;
            this.dgv_user_levels.Name = "dgv_user_levels";
            this.dgv_user_levels.Size = new System.Drawing.Size(568, 303);
            this.dgv_user_levels.TabIndex = 34;
            this.dgv_user_levels.UseEmbeddedNavigator = true;
            this.dgv_user_levels.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_assigned_privileges});
            // 
            // gv_assigned_privileges
            // 
            this.gv_assigned_privileges.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrivilege,
            this.colAllowed});
            this.gv_assigned_privileges.GridControl = this.dgv_user_levels;
            this.gv_assigned_privileges.Name = "gv_assigned_privileges";
            this.gv_assigned_privileges.OptionsBehavior.Editable = false;
            this.gv_assigned_privileges.OptionsBehavior.ReadOnly = true;
            this.gv_assigned_privileges.OptionsFilter.AllowFilterEditor = false;
            this.gv_assigned_privileges.OptionsFind.AlwaysVisible = true;
            this.gv_assigned_privileges.OptionsView.EnableAppearanceOddRow = true;
            this.gv_assigned_privileges.OptionsView.ShowGroupPanel = false;
            this.gv_assigned_privileges.OptionsView.ShowIndicator = false;
            // 
            // colPrivilege
            // 
            this.colPrivilege.Caption = "Privilege";
            this.colPrivilege.FieldName = "Privilege";
            this.colPrivilege.Name = "colPrivilege";
            this.colPrivilege.Visible = true;
            this.colPrivilege.VisibleIndex = 0;
            // 
            // colAllowed
            // 
            this.colAllowed.Caption = "Allowed";
            this.colAllowed.FieldName = "Allowed";
            this.colAllowed.Name = "colAllowed";
            this.colAllowed.Visible = true;
            this.colAllowed.VisibleIndex = 1;
            // 
            // btn_select_uat
            // 
            this.btn_select_uat.Location = new System.Drawing.Point(391, 333);
            this.btn_select_uat.Name = "btn_select_uat";
            this.btn_select_uat.Size = new System.Drawing.Size(78, 23);
            this.btn_select_uat.TabIndex = 33;
            this.btn_select_uat.Text = "Select All";
            this.btn_select_uat.Click += new System.EventHandler(this.btn_select_uat_Click);
            // 
            // btn_deselect_uat
            // 
            this.btn_deselect_uat.Location = new System.Drawing.Point(475, 333);
            this.btn_deselect_uat.Name = "btn_deselect_uat";
            this.btn_deselect_uat.Size = new System.Drawing.Size(78, 23);
            this.btn_deselect_uat.TabIndex = 32;
            this.btn_deselect_uat.Text = "Deselect All";
            // 
            // lbl_uat
            // 
            this.lbl_uat.Location = new System.Drawing.Point(5, 333);
            this.lbl_uat.Name = "lbl_uat";
            this.lbl_uat.Size = new System.Drawing.Size(31, 13);
            this.lbl_uat.TabIndex = 31;
            this.lbl_uat.Text = "Label1";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(643, 333);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(78, 23);
            this.btn_delete.TabIndex = 30;
            this.btn_delete.Text = "Delete";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(559, 333);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(78, 23);
            this.btn_save.TabIndex = 29;
            this.btn_save.Text = "Save";
            // 
            // lst_uat
            // 
            this.lst_uat.Location = new System.Drawing.Point(5, 23);
            this.lst_uat.Name = "lst_uat";
            this.lst_uat.Size = new System.Drawing.Size(142, 304);
            this.lst_uat.TabIndex = 28;
            this.lst_uat.SelectedIndexChanged += new System.EventHandler(this.lst_uat_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1120, 384);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(49, 23);
            this.btn_close.TabIndex = 27;
            this.btn_close.Text = "&Close";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grp_access_types);
            this.Controls.Add(this.grp_privileges);
            this.Controls.Add(this.btn_close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.Text = "Privileges";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestForm_FormClosed);
            this.Load += new System.EventHandler(this.ManagePrivileges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grp_privileges)).EndInit();
            this.grp_privileges.ResumeLayout(false);
            this.grp_privileges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lst_privileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_access_types)).EndInit();
            this.grp_access_types.ResumeLayout(false);
            this.grp_access_types.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user_levels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_assigned_privileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp_privileges;
        internal DevExpress.XtraEditors.SimpleButton btn_select_privileges;
        internal DevExpress.XtraEditors.ListBoxControl lst_privileges;
        internal DevExpress.XtraEditors.SimpleButton btn_deselect_privileges;
        internal DevExpress.XtraEditors.SimpleButton btn_add;
        internal DevExpress.XtraEditors.LabelControl lbl_privilege_count;
        private DevExpress.XtraEditors.GroupControl grp_access_types;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.SimpleButton btn_select_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_deselect_uat;
        internal DevExpress.XtraEditors.LabelControl lbl_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_delete;
        internal DevExpress.XtraEditors.SimpleButton btn_save;
        internal DevExpress.XtraEditors.ListBoxControl lst_uat;
        private DevExpress.XtraGrid.GridControl dgv_user_levels;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_assigned_privileges;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivilege;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowed;
        private System.Windows.Forms.Button button1;
    }
}