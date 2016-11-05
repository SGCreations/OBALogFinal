namespace OBALog.Windows
{
    partial class ManageRemarks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageRemarks));
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.gc_remarks = new DevExpress.XtraGrid.GridControl();
            this.gv_remarks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rmeRemarks = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gc_remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmeRemarks)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(544, 256);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 10;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // gc_remarks
            // 
            this.gc_remarks.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc_remarks.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc_remarks.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc_remarks.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc_remarks.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc_remarks.Location = new System.Drawing.Point(12, 12);
            this.gc_remarks.MainView = this.gv_remarks;
            this.gc_remarks.Name = "gc_remarks";
            this.gc_remarks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rmeRemarks});
            this.gc_remarks.Size = new System.Drawing.Size(607, 238);
            this.gc_remarks.TabIndex = 11;
            this.gc_remarks.UseEmbeddedNavigator = true;
            this.gc_remarks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_remarks});
            // 
            // gv_remarks
            // 
            this.gv_remarks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_remarks.GridControl = this.gc_remarks;
            this.gv_remarks.Name = "gv_remarks";
            this.gv_remarks.OptionsBehavior.Editable = false;
            this.gv_remarks.OptionsBehavior.ReadOnly = true;
            this.gv_remarks.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_remarks.OptionsView.RowAutoHeight = true;
            this.gv_remarks.OptionsView.ShowGroupPanel = false;
            this.gv_remarks.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "MemberKey";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.ColumnEdit = this.rmeRemarks;
            this.gridColumn2.FieldName = "Remarks";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 345;
            // 
            // rmeRemarks
            // 
            this.rmeRemarks.Appearance.Options.UseTextOptions = true;
            this.rmeRemarks.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.rmeRemarks.Name = "rmeRemarks";
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "UpdatedDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 119;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "User";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 141;
            // 
            // ManageRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 290);
            this.Controls.Add(this.gc_remarks);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageRemarks";
            this.Text = "Remarks History";
            this.Load += new System.EventHandler(this.ManageRemarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmeRemarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btn_close;
        private DevExpress.XtraGrid.GridControl gc_remarks;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_remarks;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rmeRemarks;
    }
}