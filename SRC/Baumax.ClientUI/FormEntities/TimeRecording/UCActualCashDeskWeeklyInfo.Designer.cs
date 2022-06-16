namespace Baumax.ClientUI.FormEntities.TimeRecording
{
    partial class UCActualCashDeskWeeklyInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditResult = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gc_Monday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditDays = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gc_Tuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Wednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Thursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Friday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Saturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Sunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblAvailableWorldBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumPresence = new DevExpress.XtraEditors.LabelControl();
            this.lblMinimumPresence = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEditDays,
            this.repositoryItemMemoEditResult});
            this.gridControl.Size = new System.Drawing.Size(638, 148);
            this.gridControl.TabIndex = 6;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_ItemName,
            this.gcResult,
            this.gc_Monday,
            this.gc_Tuesday,
            this.gc_Wednesday,
            this.gc_Thursday,
            this.gc_Friday,
            this.gc_Saturday,
            this.gc_Sunday});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsFilter.AllowMRUFilterList = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
            // 
            // gc_ItemName
            // 
            this.gc_ItemName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gc_ItemName.FieldName = "ItemName";
            this.gc_ItemName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gc_ItemName.MinWidth = 100;
            this.gc_ItemName.Name = "gc_ItemName";
            this.gc_ItemName.OptionsColumn.AllowEdit = false;
            this.gc_ItemName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_ItemName.OptionsColumn.AllowIncrementalSearch = false;
            this.gc_ItemName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gc_ItemName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_ItemName.OptionsColumn.ReadOnly = true;
            this.gc_ItemName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_ItemName.Visible = true;
            this.gc_ItemName.VisibleIndex = 0;
            this.gc_ItemName.Width = 200;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gcResult
            // 
            this.gcResult.AppearanceCell.Options.UseTextOptions = true;
            this.gcResult.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gcResult.ColumnEdit = this.repositoryItemMemoEditResult;
            this.gcResult.FieldName = "Result";
            this.gcResult.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gcResult.MinWidth = 150;
            this.gcResult.Name = "gcResult";
            this.gcResult.OptionsColumn.AllowEdit = false;
            this.gcResult.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcResult.OptionsColumn.AllowIncrementalSearch = false;
            this.gcResult.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcResult.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcResult.OptionsColumn.ReadOnly = true;
            this.gcResult.OptionsColumn.ShowInCustomizationForm = false;
            this.gcResult.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcResult.Visible = true;
            this.gcResult.VisibleIndex = 8;
            this.gcResult.Width = 250;
            // 
            // repositoryItemMemoEditResult
            // 
            this.repositoryItemMemoEditResult.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEditResult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.repositoryItemMemoEditResult.Name = "repositoryItemMemoEditResult";
            // 
            // gc_Monday
            // 
            this.gc_Monday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Monday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Monday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Monday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Monday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Monday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Monday.Caption = "Monday";
            this.gc_Monday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Monday.FieldName = "Monday";
            this.gc_Monday.Name = "gc_Monday";
            this.gc_Monday.OptionsColumn.AllowEdit = false;
            this.gc_Monday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Monday.OptionsColumn.AllowMove = false;
            this.gc_Monday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Monday.OptionsColumn.ReadOnly = true;
            this.gc_Monday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Monday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Monday.OptionsFilter.AllowFilter = false;
            this.gc_Monday.Tag = "1";
            this.gc_Monday.Visible = true;
            this.gc_Monday.VisibleIndex = 1;
            this.gc_Monday.Width = 21;
            // 
            // repositoryItemMemoEditDays
            // 
            this.repositoryItemMemoEditDays.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEditDays.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemMemoEditDays.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemMemoEditDays.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEditDays.Name = "repositoryItemMemoEditDays";
            // 
            // gc_Tuesday
            // 
            this.gc_Tuesday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Tuesday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Tuesday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Tuesday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Tuesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Tuesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Tuesday.Caption = "Tuesday";
            this.gc_Tuesday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Tuesday.FieldName = "Tuesday";
            this.gc_Tuesday.Name = "gc_Tuesday";
            this.gc_Tuesday.OptionsColumn.AllowEdit = false;
            this.gc_Tuesday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Tuesday.OptionsColumn.AllowMove = false;
            this.gc_Tuesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Tuesday.OptionsColumn.ReadOnly = true;
            this.gc_Tuesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Tuesday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Tuesday.OptionsFilter.AllowFilter = false;
            this.gc_Tuesday.Tag = "2";
            this.gc_Tuesday.Visible = true;
            this.gc_Tuesday.VisibleIndex = 2;
            this.gc_Tuesday.Width = 21;
            // 
            // gc_Wednesday
            // 
            this.gc_Wednesday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Wednesday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Wednesday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Wednesday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Wednesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Wednesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Wednesday.Caption = "Wednesday";
            this.gc_Wednesday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Wednesday.FieldName = "Wednesday";
            this.gc_Wednesday.Name = "gc_Wednesday";
            this.gc_Wednesday.OptionsColumn.AllowEdit = false;
            this.gc_Wednesday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Wednesday.OptionsColumn.AllowMove = false;
            this.gc_Wednesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Wednesday.OptionsColumn.ReadOnly = true;
            this.gc_Wednesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Wednesday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Wednesday.OptionsFilter.AllowFilter = false;
            this.gc_Wednesday.Tag = "3";
            this.gc_Wednesday.Visible = true;
            this.gc_Wednesday.VisibleIndex = 3;
            this.gc_Wednesday.Width = 21;
            // 
            // gc_Thursday
            // 
            this.gc_Thursday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Thursday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Thursday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Thursday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Thursday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Thursday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Thursday.Caption = "Thursday";
            this.gc_Thursday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Thursday.FieldName = "Thursday";
            this.gc_Thursday.Name = "gc_Thursday";
            this.gc_Thursday.OptionsColumn.AllowEdit = false;
            this.gc_Thursday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Thursday.OptionsColumn.AllowMove = false;
            this.gc_Thursday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Thursday.OptionsColumn.ReadOnly = true;
            this.gc_Thursday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Thursday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Thursday.OptionsFilter.AllowFilter = false;
            this.gc_Thursday.Tag = "4";
            this.gc_Thursday.Visible = true;
            this.gc_Thursday.VisibleIndex = 4;
            this.gc_Thursday.Width = 21;
            // 
            // gc_Friday
            // 
            this.gc_Friday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Friday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Friday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Friday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Friday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Friday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Friday.Caption = "Friday";
            this.gc_Friday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Friday.FieldName = "Friday";
            this.gc_Friday.Name = "gc_Friday";
            this.gc_Friday.OptionsColumn.AllowEdit = false;
            this.gc_Friday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Friday.OptionsColumn.AllowMove = false;
            this.gc_Friday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Friday.OptionsColumn.ReadOnly = true;
            this.gc_Friday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Friday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Friday.OptionsFilter.AllowFilter = false;
            this.gc_Friday.Tag = "5";
            this.gc_Friday.Visible = true;
            this.gc_Friday.VisibleIndex = 5;
            this.gc_Friday.Width = 21;
            // 
            // gc_Saturday
            // 
            this.gc_Saturday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Saturday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Saturday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Saturday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Saturday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Saturday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Saturday.Caption = "Saturday";
            this.gc_Saturday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Saturday.FieldName = "Saturday";
            this.gc_Saturday.Name = "gc_Saturday";
            this.gc_Saturday.OptionsColumn.AllowEdit = false;
            this.gc_Saturday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Saturday.OptionsColumn.AllowMove = false;
            this.gc_Saturday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Saturday.OptionsColumn.ReadOnly = true;
            this.gc_Saturday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Saturday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Saturday.OptionsFilter.AllowFilter = false;
            this.gc_Saturday.Tag = "6";
            this.gc_Saturday.Visible = true;
            this.gc_Saturday.VisibleIndex = 6;
            this.gc_Saturday.Width = 21;
            // 
            // gc_Sunday
            // 
            this.gc_Sunday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Sunday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Sunday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_Sunday.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Sunday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Sunday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Sunday.Caption = "Sunday";
            this.gc_Sunday.ColumnEdit = this.repositoryItemMemoEditDays;
            this.gc_Sunday.FieldName = "Sunday";
            this.gc_Sunday.Name = "gc_Sunday";
            this.gc_Sunday.OptionsColumn.AllowEdit = false;
            this.gc_Sunday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Sunday.OptionsColumn.AllowMove = false;
            this.gc_Sunday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Sunday.OptionsColumn.ReadOnly = true;
            this.gc_Sunday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Sunday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Sunday.OptionsFilter.AllowFilter = false;
            this.gc_Sunday.Tag = "0";
            this.gc_Sunday.Visible = true;
            this.gc_Sunday.VisibleIndex = 7;
            this.gc_Sunday.Width = 32;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lblAvailableWorldBufferHours);
            this.panelControl4.Controls.Add(this.lblMaximumPresence);
            this.panelControl4.Controls.Add(this.lblMinimumPresence);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 148);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(638, 20);
            this.panelControl4.TabIndex = 7;
            // 
            // lblAvailableWorldBufferHours
            // 
            this.lblAvailableWorldBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailableWorldBufferHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAvailableWorldBufferHours.Location = new System.Drawing.Point(310, 1);
            this.lblAvailableWorldBufferHours.Name = "lblAvailableWorldBufferHours";
            this.lblAvailableWorldBufferHours.Size = new System.Drawing.Size(208, 15);
            this.lblAvailableWorldBufferHours.TabIndex = 13;
            this.lblAvailableWorldBufferHours.Text = "Available world buffer hours :";
            // 
            // lblMaximumPresence
            // 
            this.lblMaximumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaximumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMaximumPresence.Location = new System.Drawing.Point(149, 1);
            this.lblMaximumPresence.Name = "lblMaximumPresence";
            this.lblMaximumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMaximumPresence.TabIndex = 12;
            this.lblMaximumPresence.Text = "Maximum presence:";
            // 
            // lblMinimumPresence
            // 
            this.lblMinimumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMinimumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMinimumPresence.Location = new System.Drawing.Point(5, 1);
            this.lblMinimumPresence.Name = "lblMinimumPresence";
            this.lblMinimumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMinimumPresence.TabIndex = 11;
            this.lblMinimumPresence.Text = "Minimum presence:";
            // 
            // UCActualCashDeskWeeklyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl4);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCActualCashDeskWeeklyInfo";
            this.Size = new System.Drawing.Size(638, 168);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_ItemName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditResult;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Monday;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditDays;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Tuesday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Wednesday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Thursday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Friday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Saturday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Sunday;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl lblAvailableWorldBufferHours;
        private DevExpress.XtraEditors.LabelControl lblMaximumPresence;
        private DevExpress.XtraEditors.LabelControl lblMinimumPresence;
    }
}
