namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCStoreWorldPlanningInfo
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
            this.gridControlInfo = new DevExpress.XtraGrid.GridControl();
            this.gridViewInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcInfoRowHeader = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditStatistic = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcInfo_Monday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfo_Tuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfo_Wednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfo_Thursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfo_Friday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfo_Saturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fcInfo_Sunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfoSummAndDifferences = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblDifferenceToBenchmark = new DevExpress.XtraEditors.LabelControl();
            this.lblBenchmark = new DevExpress.XtraEditors.LabelControl();
            this.lblTargetedNetPerformancePerHour = new DevExpress.XtraEditors.LabelControl();
            this.lblAvailableWorldBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumPresence = new DevExpress.XtraEditors.LabelControl();
            this.lblMinimumPresence = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlInfo
            // 
            this.gridControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInfo.EmbeddedNavigator.Name = "";
            this.gridControlInfo.Location = new System.Drawing.Point(0, 0);
            this.gridControlInfo.MainView = this.gridViewInfo;
            this.gridControlInfo.Name = "gridControlInfo";
            this.gridControlInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEditStatistic});
            this.gridControlInfo.Size = new System.Drawing.Size(638, 179);
            this.gridControlInfo.TabIndex = 1;
            this.gridControlInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInfo});
            // 
            // gridViewInfo
            // 
            this.gridViewInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcInfoRowHeader,
            this.gcInfo_Monday,
            this.gcInfo_Tuesday,
            this.gcInfo_Wednesday,
            this.gcInfo_Thursday,
            this.gcInfo_Friday,
            this.gcInfo_Saturday,
            this.fcInfo_Sunday,
            this.gcInfoSummAndDifferences});
            this.gridViewInfo.GridControl = this.gridControlInfo;
            this.gridViewInfo.Name = "gridViewInfo";
            this.gridViewInfo.OptionsMenu.EnableColumnMenu = false;
            this.gridViewInfo.OptionsMenu.EnableFooterMenu = false;
            this.gridViewInfo.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewInfo.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewInfo.OptionsSelection.InvertSelection = true;
            this.gridViewInfo.OptionsView.RowAutoHeight = true;
            this.gridViewInfo.OptionsView.ShowGroupPanel = false;
            this.gridViewInfo.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridViewInfo_CalcRowHeight);
            this.gridViewInfo.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewInfo_RowCellStyle);
            // 
            // gcInfoRowHeader
            // 
            this.gcInfoRowHeader.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfoRowHeader.AppearanceCell.Options.UseFont = true;
            this.gcInfoRowHeader.ColumnEdit = this.repositoryItemMemoEditStatistic;
            this.gcInfoRowHeader.FieldName = "ItemName";
            this.gcInfoRowHeader.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcInfoRowHeader.MinWidth = 50;
            this.gcInfoRowHeader.Name = "gcInfoRowHeader";
            this.gcInfoRowHeader.OptionsColumn.AllowEdit = false;
            this.gcInfoRowHeader.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfoRowHeader.OptionsColumn.AllowMove = false;
            this.gcInfoRowHeader.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfoRowHeader.OptionsColumn.ReadOnly = true;
            this.gcInfoRowHeader.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfoRowHeader.OptionsFilter.AllowAutoFilter = false;
            this.gcInfoRowHeader.OptionsFilter.AllowFilter = false;
            this.gcInfoRowHeader.Visible = true;
            this.gcInfoRowHeader.VisibleIndex = 0;
            this.gcInfoRowHeader.Width = 150;
            // 
            // repositoryItemMemoEditStatistic
            // 
            this.repositoryItemMemoEditStatistic.Appearance.Font = new System.Drawing.Font("Verdana", 6F);
            this.repositoryItemMemoEditStatistic.Appearance.Options.UseFont = true;
            this.repositoryItemMemoEditStatistic.Name = "repositoryItemMemoEditStatistic";
            // 
            // gcInfo_Monday
            // 
            this.gcInfo_Monday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Monday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Monday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Monday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Monday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Monday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Monday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Monday.Caption = "Monday";
            this.gcInfo_Monday.FieldName = "gcInfo_Monday";
            this.gcInfo_Monday.Name = "gcInfo_Monday";
            this.gcInfo_Monday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Monday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Monday.OptionsColumn.AllowMove = false;
            this.gcInfo_Monday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Monday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Monday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Monday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Monday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Monday.Tag = 1;
            this.gcInfo_Monday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Monday.Visible = true;
            this.gcInfo_Monday.VisibleIndex = 1;
            // 
            // gcInfo_Tuesday
            // 
            this.gcInfo_Tuesday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Tuesday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Tuesday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Tuesday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Tuesday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Tuesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Tuesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Tuesday.Caption = "Tuesday";
            this.gcInfo_Tuesday.FieldName = "gcInfo_Tuesday";
            this.gcInfo_Tuesday.Name = "gcInfo_Tuesday";
            this.gcInfo_Tuesday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Tuesday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Tuesday.OptionsColumn.AllowMove = false;
            this.gcInfo_Tuesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Tuesday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Tuesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Tuesday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Tuesday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Tuesday.Tag = 2;
            this.gcInfo_Tuesday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Tuesday.Visible = true;
            this.gcInfo_Tuesday.VisibleIndex = 2;
            // 
            // gcInfo_Wednesday
            // 
            this.gcInfo_Wednesday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Wednesday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Wednesday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Wednesday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Wednesday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Wednesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Wednesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Wednesday.Caption = "Wednesday";
            this.gcInfo_Wednesday.FieldName = "gcInfo_Wednesday";
            this.gcInfo_Wednesday.Name = "gcInfo_Wednesday";
            this.gcInfo_Wednesday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Wednesday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Wednesday.OptionsColumn.AllowMove = false;
            this.gcInfo_Wednesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Wednesday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Wednesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Wednesday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Wednesday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Wednesday.Tag = 3;
            this.gcInfo_Wednesday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Wednesday.Visible = true;
            this.gcInfo_Wednesday.VisibleIndex = 3;
            // 
            // gcInfo_Thursday
            // 
            this.gcInfo_Thursday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Thursday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Thursday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Thursday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Thursday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Thursday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Thursday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Thursday.Caption = "Thursday";
            this.gcInfo_Thursday.FieldName = "gcInfo_Thursday";
            this.gcInfo_Thursday.Name = "gcInfo_Thursday";
            this.gcInfo_Thursday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Thursday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Thursday.OptionsColumn.AllowMove = false;
            this.gcInfo_Thursday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Thursday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Thursday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Thursday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Thursday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Thursday.Tag = 4;
            this.gcInfo_Thursday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Thursday.Visible = true;
            this.gcInfo_Thursday.VisibleIndex = 4;
            // 
            // gcInfo_Friday
            // 
            this.gcInfo_Friday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Friday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Friday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Friday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Friday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Friday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Friday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Friday.Caption = "Friday";
            this.gcInfo_Friday.FieldName = "gcInfo_Friday";
            this.gcInfo_Friday.Name = "gcInfo_Friday";
            this.gcInfo_Friday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Friday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Friday.OptionsColumn.AllowMove = false;
            this.gcInfo_Friday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Friday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Friday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Friday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Friday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Friday.Tag = 5;
            this.gcInfo_Friday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Friday.Visible = true;
            this.gcInfo_Friday.VisibleIndex = 5;
            // 
            // gcInfo_Saturday
            // 
            this.gcInfo_Saturday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfo_Saturday.AppearanceCell.Options.UseFont = true;
            this.gcInfo_Saturday.AppearanceCell.Options.UseTextOptions = true;
            this.gcInfo_Saturday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Saturday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcInfo_Saturday.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInfo_Saturday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInfo_Saturday.Caption = "Saturday";
            this.gcInfo_Saturday.FieldName = "gcInfo_Saturday";
            this.gcInfo_Saturday.Name = "gcInfo_Saturday";
            this.gcInfo_Saturday.OptionsColumn.AllowEdit = false;
            this.gcInfo_Saturday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Saturday.OptionsColumn.AllowMove = false;
            this.gcInfo_Saturday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfo_Saturday.OptionsColumn.ReadOnly = true;
            this.gcInfo_Saturday.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfo_Saturday.OptionsFilter.AllowAutoFilter = false;
            this.gcInfo_Saturday.OptionsFilter.AllowFilter = false;
            this.gcInfo_Saturday.Tag = 6;
            this.gcInfo_Saturday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfo_Saturday.Visible = true;
            this.gcInfo_Saturday.VisibleIndex = 6;
            // 
            // fcInfo_Sunday
            // 
            this.fcInfo_Sunday.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fcInfo_Sunday.AppearanceCell.Options.UseFont = true;
            this.fcInfo_Sunday.AppearanceCell.Options.UseTextOptions = true;
            this.fcInfo_Sunday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fcInfo_Sunday.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fcInfo_Sunday.AppearanceHeader.Options.UseTextOptions = true;
            this.fcInfo_Sunday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fcInfo_Sunday.Caption = "Sunday";
            this.fcInfo_Sunday.FieldName = "fcInfo_Sunday";
            this.fcInfo_Sunday.Name = "fcInfo_Sunday";
            this.fcInfo_Sunday.OptionsColumn.AllowEdit = false;
            this.fcInfo_Sunday.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.fcInfo_Sunday.OptionsColumn.AllowMove = false;
            this.fcInfo_Sunday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.fcInfo_Sunday.OptionsColumn.ReadOnly = true;
            this.fcInfo_Sunday.OptionsColumn.ShowInCustomizationForm = false;
            this.fcInfo_Sunday.OptionsFilter.AllowAutoFilter = false;
            this.fcInfo_Sunday.OptionsFilter.AllowFilter = false;
            this.fcInfo_Sunday.Tag = 0;
            this.fcInfo_Sunday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.fcInfo_Sunday.Visible = true;
            this.fcInfo_Sunday.VisibleIndex = 7;
            // 
            // gcInfoSummAndDifferences
            // 
            this.gcInfoSummAndDifferences.AppearanceCell.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gcInfoSummAndDifferences.AppearanceCell.Options.UseFont = true;
            this.gcInfoSummAndDifferences.ColumnEdit = this.repositoryItemMemoEditStatistic;
            this.gcInfoSummAndDifferences.FieldName = "gcInfoSummAndDifferences";
            this.gcInfoSummAndDifferences.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gcInfoSummAndDifferences.MinWidth = 100;
            this.gcInfoSummAndDifferences.Name = "gcInfoSummAndDifferences";
            this.gcInfoSummAndDifferences.OptionsColumn.AllowEdit = false;
            this.gcInfoSummAndDifferences.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfoSummAndDifferences.OptionsColumn.AllowMove = false;
            this.gcInfoSummAndDifferences.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcInfoSummAndDifferences.OptionsColumn.ReadOnly = true;
            this.gcInfoSummAndDifferences.OptionsColumn.ShowInCustomizationForm = false;
            this.gcInfoSummAndDifferences.OptionsFilter.AllowAutoFilter = false;
            this.gcInfoSummAndDifferences.OptionsFilter.AllowFilter = false;
            this.gcInfoSummAndDifferences.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcInfoSummAndDifferences.Visible = true;
            this.gcInfoSummAndDifferences.VisibleIndex = 8;
            this.gcInfoSummAndDifferences.Width = 250;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lblDifferenceToBenchmark);
            this.panelControl4.Controls.Add(this.lblBenchmark);
            this.panelControl4.Controls.Add(this.lblTargetedNetPerformancePerHour);
            this.panelControl4.Controls.Add(this.lblAvailableWorldBufferHours);
            this.panelControl4.Controls.Add(this.lblMaximumPresence);
            this.panelControl4.Controls.Add(this.lblMinimumPresence);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 179);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(638, 32);
            this.panelControl4.TabIndex = 5;
            // 
            // lblDifferenceToBenchmark
            // 
            this.lblDifferenceToBenchmark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDifferenceToBenchmark.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblDifferenceToBenchmark.Location = new System.Drawing.Point(397, 16);
            this.lblDifferenceToBenchmark.Name = "lblDifferenceToBenchmark";
            this.lblDifferenceToBenchmark.Size = new System.Drawing.Size(241, 11);
            this.lblDifferenceToBenchmark.TabIndex = 16;
            this.lblDifferenceToBenchmark.Text = "Difference to benchmark:";
            // 
            // lblBenchmark
            // 
            this.lblBenchmark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBenchmark.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBenchmark.Location = new System.Drawing.Point(397, 2);
            this.lblBenchmark.Name = "lblBenchmark";
            this.lblBenchmark.Size = new System.Drawing.Size(241, 14);
            this.lblBenchmark.TabIndex = 15;
            this.lblBenchmark.Text = "Benchmark:";
            // 
            // lblTargetedNetPerformancePerHour
            // 
            this.lblTargetedNetPerformancePerHour.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTargetedNetPerformancePerHour.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblTargetedNetPerformancePerHour.Location = new System.Drawing.Point(147, 1);
            this.lblTargetedNetPerformancePerHour.Name = "lblTargetedNetPerformancePerHour";
            this.lblTargetedNetPerformancePerHour.Size = new System.Drawing.Size(241, 16);
            this.lblTargetedNetPerformancePerHour.TabIndex = 14;
            this.lblTargetedNetPerformancePerHour.Text = "Targeted net-performance per hour:";
            // 
            // lblAvailableWorldBufferHours
            // 
            this.lblAvailableWorldBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailableWorldBufferHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAvailableWorldBufferHours.Location = new System.Drawing.Point(147, 16);
            this.lblAvailableWorldBufferHours.Name = "lblAvailableWorldBufferHours";
            this.lblAvailableWorldBufferHours.Size = new System.Drawing.Size(241, 11);
            this.lblAvailableWorldBufferHours.TabIndex = 13;
            this.lblAvailableWorldBufferHours.Text = "Available world buffer hours :";
            // 
            // lblMaximumPresence
            // 
            this.lblMaximumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaximumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMaximumPresence.Location = new System.Drawing.Point(5, 14);
            this.lblMaximumPresence.Name = "lblMaximumPresence";
            this.lblMaximumPresence.Size = new System.Drawing.Size(136, 13);
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
            // UCStoreWorldPlanningInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlInfo);
            this.Controls.Add(this.panelControl4);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCStoreWorldPlanningInfo";
            this.Size = new System.Drawing.Size(638, 211);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfoRowHeader;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditStatistic;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Monday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Tuesday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Wednesday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Thursday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Friday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfo_Saturday;
        private DevExpress.XtraGrid.Columns.GridColumn fcInfo_Sunday;
        private DevExpress.XtraGrid.Columns.GridColumn gcInfoSummAndDifferences;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl lblDifferenceToBenchmark;
        private DevExpress.XtraEditors.LabelControl lblBenchmark;
        private DevExpress.XtraEditors.LabelControl lblTargetedNetPerformancePerHour;
        private DevExpress.XtraEditors.LabelControl lblAvailableWorldBufferHours;
        private DevExpress.XtraEditors.LabelControl lblMaximumPresence;
        private DevExpress.XtraEditors.LabelControl lblMinimumPresence;
    }
}
