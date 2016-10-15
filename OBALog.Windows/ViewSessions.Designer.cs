namespace OBALog.Windows
{
    partial class ViewSessions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSessions));
            this.Label2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.Label1 = new DevExpress.XtraEditors.LabelControl();
            this.nud_no_of_records = new DevExpress.XtraEditors.SpinEdit();
            this.gcUserLog = new DevExpress.XtraGrid.GridControl();
            this.gvUserLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.From = new DevExpress.XtraGrid.Columns.GridColumn();
            this.To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbo_user = new DevExpress.XtraEditors.LookUpEdit();
            this.btn_populate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.nud_no_of_records.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_user.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 35);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "No. of records:";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(264, 264);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Select user:";
            // 
            // nud_no_of_records
            // 
            this.nud_no_of_records.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_no_of_records.Location = new System.Drawing.Point(100, 32);
            this.nud_no_of_records.Name = "nud_no_of_records";
            this.nud_no_of_records.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nud_no_of_records.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_no_of_records.Properties.Mask.EditMask = "n0";
            this.nud_no_of_records.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_no_of_records.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_no_of_records.Size = new System.Drawing.Size(145, 20);
            this.nud_no_of_records.TabIndex = 15;
            this.nud_no_of_records.EditValueChanged += new System.EventHandler(this.nud_no_of_records_EditValueChanged);
            // 
            // gcUserLog
            // 
            this.gcUserLog.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcUserLog.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcUserLog.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcUserLog.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcUserLog.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcUserLog.Location = new System.Drawing.Point(12, 58);
            this.gcUserLog.MainView = this.gvUserLog;
            this.gcUserLog.Name = "gcUserLog";
            this.gcUserLog.Size = new System.Drawing.Size(327, 200);
            this.gcUserLog.TabIndex = 16;
            this.gcUserLog.UseEmbeddedNavigator = true;
            this.gcUserLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserLog});
            // 
            // gvUserLog
            // 
            this.gvUserLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.From,
            this.To});
            this.gvUserLog.GridControl = this.gcUserLog;
            this.gvUserLog.Name = "gvUserLog";
            this.gvUserLog.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvUserLog.OptionsBehavior.Editable = false;
            this.gvUserLog.OptionsBehavior.ReadOnly = true;
            this.gvUserLog.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUserLog.OptionsView.ShowGroupPanel = false;
            this.gvUserLog.OptionsView.ShowIndicator = false;
            // 
            // From
            // 
            this.From.DisplayFormat.FormatString = "g";
            this.From.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.From.FieldName = "From";
            this.From.Name = "From";
            this.From.Visible = true;
            this.From.VisibleIndex = 0;
            // 
            // To
            // 
            this.To.DisplayFormat.FormatString = "g";
            this.To.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.To.FieldName = "To";
            this.To.Name = "To";
            this.To.Visible = true;
            this.To.VisibleIndex = 1;
            // 
            // cbo_user
            // 
            this.cbo_user.Location = new System.Drawing.Point(100, 6);
            this.cbo_user.Name = "cbo_user";
            this.cbo_user.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbo_user.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_user.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True)});
            this.cbo_user.Properties.NullText = "";
            this.cbo_user.Properties.NullValuePrompt = "Select a user";
            this.cbo_user.Properties.PopupSizeable = false;
            this.cbo_user.Properties.ShowFooter = false;
            this.cbo_user.Properties.ShowHeader = false;
            this.cbo_user.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_user.Size = new System.Drawing.Size(145, 20);
            this.cbo_user.TabIndex = 17;
            this.cbo_user.EditValueChanged += new System.EventHandler(this.cbo_user_EditValueChanged);
            // 
            // btn_populate
            // 
            this.btn_populate.Location = new System.Drawing.Point(139, 264);
            this.btn_populate.Name = "btn_populate";
            this.btn_populate.Size = new System.Drawing.Size(119, 23);
            this.btn_populate.TabIndex = 12;
            this.btn_populate.Text = "&Populate Usage Log";
            this.btn_populate.Click += new System.EventHandler(this.btn_populate_Click);
            // 
            // ViewSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 298);
            this.Controls.Add(this.gcUserLog);
            this.Controls.Add(this.nud_no_of_records);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_populate);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbo_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewSessions";
            this.Text = "View Sessions";
            ((System.ComponentModel.ISupportInitialize)(this.nud_no_of_records.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_user.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl Label2;
        internal DevExpress.XtraEditors.SimpleButton btn_close;
        internal DevExpress.XtraEditors.LabelControl Label1;
        private DevExpress.XtraEditors.SpinEdit nud_no_of_records;
        private DevExpress.XtraGrid.GridControl gcUserLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserLog;
        private DevExpress.XtraEditors.LookUpEdit cbo_user;
        internal DevExpress.XtraEditors.SimpleButton btn_populate;
        private DevExpress.XtraGrid.Columns.GridColumn From;
        private DevExpress.XtraGrid.Columns.GridColumn To;
        

    }
}