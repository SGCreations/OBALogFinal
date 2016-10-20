namespace OBALog.Windows
{
    partial class ManagePrivileges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePrivileges));
            this.lst_uat = new DevExpress.XtraEditors.ListBoxControl();
            this.gc_assigned_privileges = new DevExpress.XtraGrid.GridControl();
            this.gv_assigned_privileges = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrivilege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkAllowed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btn_select_uat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_deselect_uat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_clear_filter = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbo_filter = new OBALog.Windows.CustomLookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_assigned_privileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_assigned_privileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_filter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lst_uat
            // 
            this.lst_uat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lst_uat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_uat.Location = new System.Drawing.Point(2, 20);
            this.lst_uat.Name = "lst_uat";
            this.lst_uat.Size = new System.Drawing.Size(178, 378);
            this.lst_uat.TabIndex = 29;
            this.lst_uat.SelectedIndexChanged += new System.EventHandler(this.lst_uat_SelectedIndexChanged);
            // 
            // gc_assigned_privileges
            // 
            this.gc_assigned_privileges.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc_assigned_privileges.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc_assigned_privileges.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc_assigned_privileges.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc_assigned_privileges.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc_assigned_privileges.Location = new System.Drawing.Point(2, 51);
            this.gc_assigned_privileges.MainView = this.gv_assigned_privileges;
            this.gc_assigned_privileges.Name = "gc_assigned_privileges";
            this.gc_assigned_privileges.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkAllowed});
            this.gc_assigned_privileges.Size = new System.Drawing.Size(719, 347);
            this.gc_assigned_privileges.TabIndex = 35;
            this.gc_assigned_privileges.UseEmbeddedNavigator = true;
            this.gc_assigned_privileges.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_assigned_privileges});
            // 
            // gv_assigned_privileges
            // 
            this.gv_assigned_privileges.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_assigned_privileges.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriority,
            this.colKey,
            this.colPrivilege,
            this.colAllowed,
            this.colCategory});
            this.gv_assigned_privileges.GridControl = this.gc_assigned_privileges;
            this.gv_assigned_privileges.GroupCount = 1;
            this.gv_assigned_privileges.Name = "gv_assigned_privileges";
            this.gv_assigned_privileges.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv_assigned_privileges.OptionsFilter.AllowFilterEditor = false;
            this.gv_assigned_privileges.OptionsFind.AlwaysVisible = true;
            this.gv_assigned_privileges.OptionsView.EnableAppearanceOddRow = true;
            this.gv_assigned_privileges.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gv_assigned_privileges.OptionsView.ShowGroupPanel = false;
            this.gv_assigned_privileges.OptionsView.ShowIndicator = false;
            this.gv_assigned_privileges.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategory, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gv_assigned_privileges.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_assigned_privileges_CellValueChanging);
            this.gv_assigned_privileges.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gv_assigned_privileges_CustomColumnSort);
            // 
            // colPriority
            // 
            this.colPriority.FieldName = "Priority";
            this.colPriority.Name = "colPriority";
            // 
            // colKey
            // 
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            // 
            // colPrivilege
            // 
            this.colPrivilege.Caption = "Privilege";
            this.colPrivilege.FieldName = "Privilege";
            this.colPrivilege.Name = "colPrivilege";
            this.colPrivilege.OptionsColumn.AllowEdit = false;
            this.colPrivilege.Visible = true;
            this.colPrivilege.VisibleIndex = 0;
            this.colPrivilege.Width = 629;
            // 
            // colAllowed
            // 
            this.colAllowed.Caption = "Allowed";
            this.colAllowed.FieldName = "Allowed";
            this.colAllowed.Name = "colAllowed";
            this.colAllowed.Visible = true;
            this.colAllowed.VisibleIndex = 1;
            this.colAllowed.Width = 90;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            // 
            // chkAllowed
            // 
            this.chkAllowed.AutoHeight = false;
            this.chkAllowed.Name = "chkAllowed";
            // 
            // btn_select_uat
            // 
            this.btn_select_uat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_uat.Location = new System.Drawing.Point(552, 63);
            this.btn_select_uat.Name = "btn_select_uat";
            this.btn_select_uat.Size = new System.Drawing.Size(78, 23);
            this.btn_select_uat.TabIndex = 39;
            this.btn_select_uat.Text = "Select All";
            this.btn_select_uat.Visible = false;
            this.btn_select_uat.Click += new System.EventHandler(this.btn_select_all_privileges_Click);
            // 
            // btn_deselect_uat
            // 
            this.btn_deselect_uat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deselect_uat.Location = new System.Drawing.Point(636, 63);
            this.btn_deselect_uat.Name = "btn_deselect_uat";
            this.btn_deselect_uat.Size = new System.Drawing.Size(78, 23);
            this.btn_deselect_uat.TabIndex = 38;
            this.btn_deselect_uat.Text = "Deselect All";
            this.btn_deselect_uat.Visible = false;
            this.btn_deselect_uat.Click += new System.EventHandler(this.btn_deselect_all_privileges_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(874, 418);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(49, 23);
            this.btn_close.TabIndex = 36;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lst_uat);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(182, 400);
            this.groupControl1.TabIndex = 40;
            this.groupControl1.Text = "User Access Types";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btn_clear_filter);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.cbo_filter);
            this.groupControl2.Controls.Add(this.btn_deselect_uat);
            this.groupControl2.Controls.Add(this.btn_select_uat);
            this.groupControl2.Controls.Add(this.gc_assigned_privileges);
            this.groupControl2.Location = new System.Drawing.Point(200, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(723, 400);
            this.groupControl2.TabIndex = 40;
            this.groupControl2.Text = "Privileges";
            // 
            // btn_clear_filter
            // 
            this.btn_clear_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear_filter.Location = new System.Drawing.Point(238, 23);
            this.btn_clear_filter.Name = "btn_clear_filter";
            this.btn_clear_filter.Size = new System.Drawing.Size(78, 23);
            this.btn_clear_filter.TabIndex = 120;
            this.btn_clear_filter.Text = "Clear Filter";
            this.btn_clear_filter.Click += new System.EventHandler(this.btn_clear_filter_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Filter:";
            // 
            // cbo_filter
            // 
            this.cbo_filter.EditValue = "";
            this.cbo_filter.Location = new System.Drawing.Point(72, 25);
            this.cbo_filter.Name = "cbo_filter";
            this.cbo_filter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_filter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Privilege", "Privilege", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.cbo_filter.Properties.NullText = "";
            this.cbo_filter.Properties.PopupSizeable = false;
            this.cbo_filter.Properties.ShowFooter = false;
            this.cbo_filter.Properties.ShowHeader = false;
            this.cbo_filter.Size = new System.Drawing.Size(160, 20);
            this.cbo_filter.TabIndex = 118;
            this.cbo_filter.EditValueChanged += new System.EventHandler(this.cbo_filter_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(200, 423);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(338, 13);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "PLEASE NOTE: The changes you make are saved in real-time.";
            // 
            // ManagePrivileges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 453);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagePrivileges";
            this.Text = "Privileges";
            ((System.ComponentModel.ISupportInitialize)(this.lst_uat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_assigned_privileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_assigned_privileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_filter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.ListBoxControl lst_uat;
        private DevExpress.XtraGrid.GridControl gc_assigned_privileges;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_assigned_privileges;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivilege;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowed;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowed;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        internal DevExpress.XtraEditors.SimpleButton btn_select_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_deselect_uat;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private CustomLookUpEdit cbo_filter;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        internal DevExpress.XtraEditors.SimpleButton btn_clear_filter;

    }
}