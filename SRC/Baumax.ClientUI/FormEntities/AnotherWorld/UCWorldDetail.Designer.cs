namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCWorldDetail
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorldDetail));
            this.cardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.cc_AvailableWTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_CurrentlyAvailableBuffer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_BusinessVolumeHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_TargetedBusinessVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_NetBusinessVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_NetBusinessVolumeWithoutBuffer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_BenchmarkBusinessVolumePerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_MinPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cc_MaxPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_ViewMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_WorldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repWorld = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.m_images = new DevExpress.Utils.ImageCollection(this.components);
            this.gc_AvailableWTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_CurrentlyAvailableBuffer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BusinessVolumeHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_TargetedBusinessVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_NetBusinessVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_NetBusinessVolumeWithoutBuffer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BenchmarkBusinessVolumePerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_MinPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_MaxPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGrid = new DevExpress.XtraVerticalGrid.VGridControl();
            this.vc_WorldName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_AvailableWTH = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_CurrentlyAvailableBuffer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_BusinessVolumeHours = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_TargetedBusinessVolume = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_NetBusinessVolume = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_NetBusinessVolumeWithoutBuffer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_BenchmarkBusinessVolumePerHour = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_MinPer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_MaxPer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cardView
            // 
            this.cardView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cardView.CardInterval = 4;
            this.cardView.CardWidth = 260;
            this.cardView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cc_AvailableWTH,
            this.cc_CurrentlyAvailableBuffer,
            this.cc_BusinessVolumeHours,
            this.cc_TargetedBusinessVolume,
            this.cc_NetBusinessVolume,
            this.cc_NetBusinessVolumeWithoutBuffer,
            this.cc_BenchmarkBusinessVolumePerHour,
            this.cc_MinPer,
            this.cc_MaxPer});
            this.cardView.FocusedCardTopFieldIndex = 0;
            this.cardView.GridControl = this.gridControl;
            this.cardView.Images = this.m_images;
            this.cardView.Name = "cardView";
            this.cardView.OptionsBehavior.Editable = false;
            this.cardView.OptionsView.ShowCardExpandButton = false;
            this.cardView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.cardView.OptionsView.ShowQuickCustomizeButton = false;
            this.cardView.CustomCardCaptionImage += new DevExpress.XtraGrid.Views.Card.CardCaptionImageEventHandler(this.cardView_CustomCardCaptionImage);
            this.cardView.CustomDrawCardCaption += new DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventHandler(this.cardView_CustomDrawCardCaption);
            this.cardView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.View_FocusedRowChanged);
            this.cardView.RowCountChanged += new System.EventHandler(this.View_RowCountChanged);
            // 
            // cc_AvailableWTH
            // 
            this.cc_AvailableWTH.Caption = "Available work-time hours";
            this.cc_AvailableWTH.DisplayFormat.FormatString = "{0:F2}";
            this.cc_AvailableWTH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_AvailableWTH.FieldName = "AvailableWorkTimeHours";
            this.cc_AvailableWTH.Name = "cc_AvailableWTH";
            this.cc_AvailableWTH.Visible = true;
            this.cc_AvailableWTH.VisibleIndex = 0;
            // 
            // cc_CurrentlyAvailableBuffer
            // 
            this.cc_CurrentlyAvailableBuffer.Caption = "Currently available buffer";
            this.cc_CurrentlyAvailableBuffer.DisplayFormat.FormatString = "{0:F2}";
            this.cc_CurrentlyAvailableBuffer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_CurrentlyAvailableBuffer.FieldName = "AvailableBufferHours";
            this.cc_CurrentlyAvailableBuffer.Name = "cc_CurrentlyAvailableBuffer";
            this.cc_CurrentlyAvailableBuffer.Visible = true;
            this.cc_CurrentlyAvailableBuffer.VisibleIndex = 1;
            // 
            // cc_BusinessVolumeHours
            // 
            this.cc_BusinessVolumeHours.Caption = "Business Volume Hours";
            this.cc_BusinessVolumeHours.DisplayFormat.FormatString = "{0:F2}";
            this.cc_BusinessVolumeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_BusinessVolumeHours.FieldName = "BusinessVolumeHours";
            this.cc_BusinessVolumeHours.Name = "cc_BusinessVolumeHours";
            this.cc_BusinessVolumeHours.Visible = true;
            this.cc_BusinessVolumeHours.VisibleIndex = 2;
            // 
            // cc_TargetedBusinessVolume
            // 
            this.cc_TargetedBusinessVolume.Caption = "Targeted Business Volume";
            this.cc_TargetedBusinessVolume.DisplayFormat.FormatString = "{0:F2}";
            this.cc_TargetedBusinessVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_TargetedBusinessVolume.FieldName = "TargetedBusinessVolume";
            this.cc_TargetedBusinessVolume.Name = "cc_TargetedBusinessVolume";
            this.cc_TargetedBusinessVolume.Visible = true;
            this.cc_TargetedBusinessVolume.VisibleIndex = 3;
            // 
            // cc_NetBusinessVolume
            // 
            this.cc_NetBusinessVolume.Caption = "Net Business Volume";
            this.cc_NetBusinessVolume.DisplayFormat.FormatString = "{0:F2}";
            this.cc_NetBusinessVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_NetBusinessVolume.FieldName = "NetBusinessVolume1";
            this.cc_NetBusinessVolume.Name = "cc_NetBusinessVolume";
            this.cc_NetBusinessVolume.Visible = true;
            this.cc_NetBusinessVolume.VisibleIndex = 4;
            // 
            // cc_NetBusinessVolumeWithoutBuffer
            // 
            this.cc_NetBusinessVolumeWithoutBuffer.Caption = "Net Business Volume Without Buffer";
            this.cc_NetBusinessVolumeWithoutBuffer.DisplayFormat.FormatString = "{0:F2}";
            this.cc_NetBusinessVolumeWithoutBuffer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_NetBusinessVolumeWithoutBuffer.FieldName = "NetBusinessVolumeWithoutBuffer";
            this.cc_NetBusinessVolumeWithoutBuffer.Name = "cc_NetBusinessVolumeWithoutBuffer";
            this.cc_NetBusinessVolumeWithoutBuffer.Visible = true;
            this.cc_NetBusinessVolumeWithoutBuffer.VisibleIndex = 5;
            // 
            // cc_BenchmarkBusinessVolumePerHour
            // 
            this.cc_BenchmarkBusinessVolumePerHour.Caption = "Benchmark perfomance";
            this.cc_BenchmarkBusinessVolumePerHour.DisplayFormat.FormatString = "{0:F2}";
            this.cc_BenchmarkBusinessVolumePerHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cc_BenchmarkBusinessVolumePerHour.FieldName = "BenchmarkPerfomance";
            this.cc_BenchmarkBusinessVolumePerHour.Name = "cc_BenchmarkBusinessVolumePerHour";
            this.cc_BenchmarkBusinessVolumePerHour.Visible = true;
            this.cc_BenchmarkBusinessVolumePerHour.VisibleIndex = 6;
            // 
            // cc_MinPer
            // 
            this.cc_MinPer.Caption = "Min person";
            this.cc_MinPer.FieldName = "Min";
            this.cc_MinPer.Name = "cc_MinPer";
            this.cc_MinPer.Visible = true;
            this.cc_MinPer.VisibleIndex = 7;
            // 
            // cc_MaxPer
            // 
            this.cc_MaxPer.Caption = "MaxPerson";
            this.cc_MaxPer.FieldName = "Max";
            this.cc_MaxPer.Name = "cc_MaxPer";
            this.cc_MaxPer.Visible = true;
            this.cc_MaxPer.VisibleIndex = 8;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.cms;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.cardView;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.UseWindowsXPTheme = true;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repWorld});
            this.gridControl.Size = new System.Drawing.Size(561, 297);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.cardView});
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ViewMinMax,
            this.ts_Refresh});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(164, 48);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // ts_ViewMinMax
            // 
            this.ts_ViewMinMax.Image = ((System.Drawing.Image)(resources.GetObject("ts_ViewMinMax.Image")));
            this.ts_ViewMinMax.Name = "ts_ViewMinMax";
            this.ts_ViewMinMax.Size = new System.Drawing.Size(163, 22);
            this.ts_ViewMinMax.Text = "View all min/max";
            this.ts_ViewMinMax.Click += new System.EventHandler(this.ts_ViewAllMinMax_Click);
            // 
            // ts_Refresh
            // 
            this.ts_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("ts_Refresh.Image")));
            this.ts_Refresh.Name = "ts_Refresh";
            this.ts_Refresh.Size = new System.Drawing.Size(163, 22);
            this.ts_Refresh.Text = "Refresh";
            // 
            // gridView
            // 
            this.gridView.Appearance.GroupPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.ColumnPanelRowHeight = 50;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_WorldName,
            this.gc_AvailableWTH,
            this.gc_CurrentlyAvailableBuffer,
            this.gc_BusinessVolumeHours,
            this.gc_TargetedBusinessVolume,
            this.gc_NetBusinessVolume,
            this.gc_NetBusinessVolumeWithoutBuffer,
            this.gc_BenchmarkBusinessVolumePerHour,
            this.gc_MinPer,
            this.gc_MaxPer});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Images = this.m_images;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.PaintStyleName = "Skin";
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_WorldName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.View_FocusedRowChanged);
            this.gridView.RowCountChanged += new System.EventHandler(this.View_RowCountChanged);
            // 
            // gc_WorldName
            // 
            this.gc_WorldName.Caption = "World name";
            this.gc_WorldName.ColumnEdit = this.repWorld;
            this.gc_WorldName.FieldName = "WorldName";
            this.gc_WorldName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gc_WorldName.Name = "gc_WorldName";
            this.gc_WorldName.OptionsFilter.AllowAutoFilter = false;
            this.gc_WorldName.OptionsFilter.AllowFilter = false;
            this.gc_WorldName.Visible = true;
            this.gc_WorldName.VisibleIndex = 0;
            this.gc_WorldName.Width = 106;
            // 
            // repWorld
            // 
            this.repWorld.AutoHeight = false;
            this.repWorld.Name = "repWorld";
            this.repWorld.SmallImages = this.m_images;
            // 
            // m_images
            // 
            this.m_images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("m_images.ImageStream")));
            // 
            // gc_AvailableWTH
            // 
            this.gc_AvailableWTH.Caption = "Available work-time-hours";
            this.gc_AvailableWTH.DisplayFormat.FormatString = "{0:F2}";
            this.gc_AvailableWTH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_AvailableWTH.FieldName = "AvailableWorkTimeHours";
            this.gc_AvailableWTH.Name = "gc_AvailableWTH";
            this.gc_AvailableWTH.OptionsColumn.AllowEdit = false;
            this.gc_AvailableWTH.OptionsColumn.ReadOnly = true;
            this.gc_AvailableWTH.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AvailableWTH.OptionsFilter.AllowFilter = false;
            this.gc_AvailableWTH.Visible = true;
            this.gc_AvailableWTH.VisibleIndex = 1;
            this.gc_AvailableWTH.Width = 38;
            // 
            // gc_CurrentlyAvailableBuffer
            // 
            this.gc_CurrentlyAvailableBuffer.Caption = "Currently available buffer";
            this.gc_CurrentlyAvailableBuffer.DisplayFormat.FormatString = "{0:F2}";
            this.gc_CurrentlyAvailableBuffer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_CurrentlyAvailableBuffer.FieldName = "AvailableBufferHours";
            this.gc_CurrentlyAvailableBuffer.Name = "gc_CurrentlyAvailableBuffer";
            this.gc_CurrentlyAvailableBuffer.OptionsColumn.AllowEdit = false;
            this.gc_CurrentlyAvailableBuffer.OptionsColumn.ReadOnly = true;
            this.gc_CurrentlyAvailableBuffer.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_CurrentlyAvailableBuffer.OptionsFilter.AllowFilter = false;
            this.gc_CurrentlyAvailableBuffer.Visible = true;
            this.gc_CurrentlyAvailableBuffer.VisibleIndex = 2;
            this.gc_CurrentlyAvailableBuffer.Width = 38;
            // 
            // gc_BusinessVolumeHours
            // 
            this.gc_BusinessVolumeHours.Caption = "Business volume hours";
            this.gc_BusinessVolumeHours.DisplayFormat.FormatString = "{0:F2}";
            this.gc_BusinessVolumeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_BusinessVolumeHours.FieldName = "BusinessVolumeHours";
            this.gc_BusinessVolumeHours.Name = "gc_BusinessVolumeHours";
            this.gc_BusinessVolumeHours.OptionsColumn.AllowEdit = false;
            this.gc_BusinessVolumeHours.OptionsColumn.ReadOnly = true;
            this.gc_BusinessVolumeHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_BusinessVolumeHours.OptionsFilter.AllowFilter = false;
            this.gc_BusinessVolumeHours.Visible = true;
            this.gc_BusinessVolumeHours.VisibleIndex = 4;
            this.gc_BusinessVolumeHours.Width = 39;
            // 
            // gc_TargetedBusinessVolume
            // 
            this.gc_TargetedBusinessVolume.Caption = "Targeted business volume";
            this.gc_TargetedBusinessVolume.DisplayFormat.FormatString = "{0:F2}";
            this.gc_TargetedBusinessVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_TargetedBusinessVolume.FieldName = "TargetedBusinessVolume";
            this.gc_TargetedBusinessVolume.Name = "gc_TargetedBusinessVolume";
            this.gc_TargetedBusinessVolume.OptionsColumn.AllowEdit = false;
            this.gc_TargetedBusinessVolume.OptionsColumn.ReadOnly = true;
            this.gc_TargetedBusinessVolume.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_TargetedBusinessVolume.OptionsFilter.AllowFilter = false;
            this.gc_TargetedBusinessVolume.Visible = true;
            this.gc_TargetedBusinessVolume.VisibleIndex = 5;
            this.gc_TargetedBusinessVolume.Width = 39;
            // 
            // gc_NetBusinessVolume
            // 
            this.gc_NetBusinessVolume.Caption = "Net business volume";
            this.gc_NetBusinessVolume.DisplayFormat.FormatString = "{0:F2}";
            this.gc_NetBusinessVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_NetBusinessVolume.FieldName = "NetBusinessVolume1";
            this.gc_NetBusinessVolume.Name = "gc_NetBusinessVolume";
            this.gc_NetBusinessVolume.OptionsColumn.AllowEdit = false;
            this.gc_NetBusinessVolume.OptionsColumn.ReadOnly = true;
            this.gc_NetBusinessVolume.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_NetBusinessVolume.OptionsFilter.AllowFilter = false;
            this.gc_NetBusinessVolume.Visible = true;
            this.gc_NetBusinessVolume.VisibleIndex = 6;
            this.gc_NetBusinessVolume.Width = 31;
            // 
            // gc_NetBusinessVolumeWithoutBuffer
            // 
            this.gc_NetBusinessVolumeWithoutBuffer.Caption = "Net business volume without buffer";
            this.gc_NetBusinessVolumeWithoutBuffer.DisplayFormat.FormatString = "{0:F2}";
            this.gc_NetBusinessVolumeWithoutBuffer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_NetBusinessVolumeWithoutBuffer.FieldName = "NetBusinessVolumeWithoutBuffer";
            this.gc_NetBusinessVolumeWithoutBuffer.Name = "gc_NetBusinessVolumeWithoutBuffer";
            this.gc_NetBusinessVolumeWithoutBuffer.OptionsColumn.AllowEdit = false;
            this.gc_NetBusinessVolumeWithoutBuffer.OptionsColumn.ReadOnly = true;
            this.gc_NetBusinessVolumeWithoutBuffer.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_NetBusinessVolumeWithoutBuffer.OptionsFilter.AllowFilter = false;
            this.gc_NetBusinessVolumeWithoutBuffer.Visible = true;
            this.gc_NetBusinessVolumeWithoutBuffer.VisibleIndex = 3;
            this.gc_NetBusinessVolumeWithoutBuffer.Width = 64;
            // 
            // gc_BenchmarkBusinessVolumePerHour
            // 
            this.gc_BenchmarkBusinessVolumePerHour.Caption = "Benchmark business volume per hour";
            this.gc_BenchmarkBusinessVolumePerHour.DisplayFormat.FormatString = "{0:F2}";
            this.gc_BenchmarkBusinessVolumePerHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gc_BenchmarkBusinessVolumePerHour.FieldName = "BenchmarkPerfomance";
            this.gc_BenchmarkBusinessVolumePerHour.Name = "gc_BenchmarkBusinessVolumePerHour";
            this.gc_BenchmarkBusinessVolumePerHour.OptionsColumn.AllowEdit = false;
            this.gc_BenchmarkBusinessVolumePerHour.OptionsColumn.ReadOnly = true;
            this.gc_BenchmarkBusinessVolumePerHour.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_BenchmarkBusinessVolumePerHour.OptionsFilter.AllowFilter = false;
            this.gc_BenchmarkBusinessVolumePerHour.Visible = true;
            this.gc_BenchmarkBusinessVolumePerHour.VisibleIndex = 7;
            // 
            // gc_MinPer
            // 
            this.gc_MinPer.Caption = "Minimum pepsons";
            this.gc_MinPer.FieldName = "Min";
            this.gc_MinPer.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_MinPer.MinWidth = 55;
            this.gc_MinPer.Name = "gc_MinPer";
            this.gc_MinPer.OptionsColumn.AllowEdit = false;
            this.gc_MinPer.OptionsColumn.ReadOnly = true;
            this.gc_MinPer.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_MinPer.OptionsFilter.AllowFilter = false;
            this.gc_MinPer.Visible = true;
            this.gc_MinPer.VisibleIndex = 8;
            this.gc_MinPer.Width = 55;
            // 
            // gc_MaxPer
            // 
            this.gc_MaxPer.Caption = "Maximum persons";
            this.gc_MaxPer.FieldName = "Max";
            this.gc_MaxPer.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_MaxPer.MinWidth = 55;
            this.gc_MaxPer.Name = "gc_MaxPer";
            this.gc_MaxPer.OptionsColumn.AllowEdit = false;
            this.gc_MaxPer.OptionsColumn.ReadOnly = true;
            this.gc_MaxPer.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_MaxPer.OptionsFilter.AllowFilter = false;
            this.gc_MaxPer.Visible = true;
            this.gc_MaxPer.VisibleIndex = 9;
            this.gc_MaxPer.Width = 55;
            // 
            // vGrid
            // 
            this.vGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrid.ContextMenuStrip = this.cms;
            this.vGrid.Location = new System.Drawing.Point(27, 149);
            this.vGrid.Name = "vGrid";
            this.vGrid.OptionsBehavior.Editable = false;
            this.vGrid.RecordWidth = 108;
            this.vGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repWorld});
            this.vGrid.RowHeaderWidth = 222;
            this.vGrid.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.vc_WorldName,
            this.vc_AvailableWTH,
            this.vc_CurrentlyAvailableBuffer,
            this.vc_BusinessVolumeHours,
            this.vc_TargetedBusinessVolume,
            this.vc_NetBusinessVolume,
            this.vc_NetBusinessVolumeWithoutBuffer,
            this.vc_BenchmarkBusinessVolumePerHour,
            this.vc_MinPer,
            this.vc_MaxPer});
            this.vGrid.Size = new System.Drawing.Size(307, 284);
            this.vGrid.TabIndex = 1;
            this.vGrid.Visible = false;
            this.vGrid.FocusedRecordChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.vGrid_FocusedRecordChanged);
            // 
            // vc_WorldName
            // 
            this.vc_WorldName.Name = "vc_WorldName";
            this.vc_WorldName.Properties.Caption = "World name";
            this.vc_WorldName.Properties.FieldName = "WorldName";
            this.vc_WorldName.Properties.RowEdit = this.repWorld;
            // 
            // vc_AvailableWTH
            // 
            this.vc_AvailableWTH.Name = "vc_AvailableWTH";
            this.vc_AvailableWTH.Properties.Caption = "Available work-time-hours";
            this.vc_AvailableWTH.Properties.FieldName = "AvailableWorkTimeHours";
            this.vc_AvailableWTH.Properties.Format.FormatString = "{0:F2}";
            this.vc_AvailableWTH.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_CurrentlyAvailableBuffer
            // 
            this.vc_CurrentlyAvailableBuffer.Height = 16;
            this.vc_CurrentlyAvailableBuffer.Name = "vc_CurrentlyAvailableBuffer";
            this.vc_CurrentlyAvailableBuffer.Properties.Caption = "Currently available buffer";
            this.vc_CurrentlyAvailableBuffer.Properties.FieldName = "AvailableBufferHours";
            this.vc_CurrentlyAvailableBuffer.Properties.Format.FormatString = "{0:F2}";
            this.vc_CurrentlyAvailableBuffer.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_BusinessVolumeHours
            // 
            this.vc_BusinessVolumeHours.Name = "vc_BusinessVolumeHours";
            this.vc_BusinessVolumeHours.Properties.Caption = "Business volume hours";
            this.vc_BusinessVolumeHours.Properties.FieldName = "BusinessVolumeHours";
            this.vc_BusinessVolumeHours.Properties.Format.FormatString = "{0:F2}";
            this.vc_BusinessVolumeHours.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_TargetedBusinessVolume
            // 
            this.vc_TargetedBusinessVolume.Name = "vc_TargetedBusinessVolume";
            this.vc_TargetedBusinessVolume.Properties.Caption = "Targeted business volume";
            this.vc_TargetedBusinessVolume.Properties.FieldName = "TargetedBusinessVolume";
            this.vc_TargetedBusinessVolume.Properties.Format.FormatString = "{0:F2}";
            this.vc_TargetedBusinessVolume.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_NetBusinessVolume
            // 
            this.vc_NetBusinessVolume.Name = "vc_NetBusinessVolume";
            this.vc_NetBusinessVolume.Properties.Caption = "Net business volume";
            this.vc_NetBusinessVolume.Properties.FieldName = "NetBusinessVolume1";
            this.vc_NetBusinessVolume.Properties.Format.FormatString = "{0:F2}";
            this.vc_NetBusinessVolume.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_NetBusinessVolumeWithoutBuffer
            // 
            this.vc_NetBusinessVolumeWithoutBuffer.Name = "vc_NetBusinessVolumeWithoutBuffer";
            this.vc_NetBusinessVolumeWithoutBuffer.Properties.Caption = "Net business volume without buffer";
            this.vc_NetBusinessVolumeWithoutBuffer.Properties.FieldName = "NetBusinessVolumeWithoutBuffer";
            this.vc_NetBusinessVolumeWithoutBuffer.Properties.Format.FormatString = "{0:F2}";
            this.vc_NetBusinessVolumeWithoutBuffer.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_BenchmarkBusinessVolumePerHour
            // 
            this.vc_BenchmarkBusinessVolumePerHour.Name = "vc_BenchmarkBusinessVolumePerHour";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.Caption = "Benchmark business volume per hour";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.FieldName = "BenchmarkPerfomance";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.Format.FormatString = "{0:F2}";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // vc_MinPer
            // 
            this.vc_MinPer.Name = "vc_MinPer";
            this.vc_MinPer.Properties.Caption = "Minimum pepsons";
            this.vc_MinPer.Properties.FieldName = "Min";
            // 
            // vc_MaxPer
            // 
            this.vc_MaxPer.Name = "vc_MaxPer";
            this.vc_MaxPer.Properties.Caption = "Maximum persons";
            this.vc_MaxPer.Properties.FieldName = "Max";
            // 
            // UCWorldDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vGrid);
            this.Controls.Add(this.gridControl);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldDetail";
            this.Size = new System.Drawing.Size(561, 297);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UCWorldDetail_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorldName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AvailableWTH;
        private DevExpress.XtraGrid.Columns.GridColumn gc_CurrentlyAvailableBuffer;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BusinessVolumeHours;
        private DevExpress.XtraGrid.Columns.GridColumn gc_TargetedBusinessVolume;
        private DevExpress.XtraGrid.Columns.GridColumn gc_NetBusinessVolume;
        private DevExpress.XtraGrid.Columns.GridColumn gc_NetBusinessVolumeWithoutBuffer;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BenchmarkBusinessVolumePerHour;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem ts_Refresh;
        private DevExpress.XtraGrid.Columns.GridColumn gc_MinPer;
        private DevExpress.XtraGrid.Columns.GridColumn gc_MaxPer;
        private System.Windows.Forms.ToolStripMenuItem ts_ViewMinMax;
        private DevExpress.Utils.ImageCollection m_images;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repWorld;
        private DevExpress.XtraGrid.Views.Card.CardView cardView;
        private DevExpress.XtraGrid.Columns.GridColumn cc_AvailableWTH;
        private DevExpress.XtraGrid.Columns.GridColumn cc_CurrentlyAvailableBuffer;
        private DevExpress.XtraGrid.Columns.GridColumn cc_BusinessVolumeHours;
        private DevExpress.XtraGrid.Columns.GridColumn cc_TargetedBusinessVolume;
        private DevExpress.XtraGrid.Columns.GridColumn cc_NetBusinessVolume;
        private DevExpress.XtraGrid.Columns.GridColumn cc_NetBusinessVolumeWithoutBuffer;
        private DevExpress.XtraGrid.Columns.GridColumn cc_BenchmarkBusinessVolumePerHour;
        private DevExpress.XtraGrid.Columns.GridColumn cc_MaxPer;
        private DevExpress.XtraGrid.Columns.GridColumn cc_MinPer;
        private DevExpress.XtraVerticalGrid.VGridControl vGrid;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_WorldName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_AvailableWTH;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_CurrentlyAvailableBuffer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_BusinessVolumeHours;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_TargetedBusinessVolume;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_NetBusinessVolume;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_NetBusinessVolumeWithoutBuffer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_BenchmarkBusinessVolumePerHour;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_MinPer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_MaxPer;
    }
}
