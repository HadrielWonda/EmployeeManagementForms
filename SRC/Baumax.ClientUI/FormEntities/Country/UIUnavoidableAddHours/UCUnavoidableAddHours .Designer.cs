namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCUnavoidableAddHours
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
            this.gridControl_UnAdHours = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip_UnAdHours = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sm_NewUAAH = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_EditUAAH = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_DeleteUAAH = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_UnAdHours = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_yearappearance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_DayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_FactorBegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_FinishTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_FactorEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager_UnAdHours = new DevExpress.XtraBars.BarManager(this.components);
            this.barTool = new DevExpress.XtraBars.Bar();
            this.bi_NewUAAH = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditUAAH = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteUAAH = new DevExpress.XtraBars.BarButtonItem();
            this.Calculate = new DevExpress.XtraBars.BarButtonItem();
            this.barFilter = new DevExpress.XtraBars.Bar();
            this.lb_FilterByDate = new DevExpress.XtraBars.BarStaticItem();
            this.de_Begin = new DevExpress.XtraBars.BarEditItem();
            this.seBegin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lb_to = new DevExpress.XtraBars.BarStaticItem();
            this.de_End = new DevExpress.XtraBars.BarEditItem();
            this.seEnd = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bt_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UnAdHours)).BeginInit();
            this.contextMenuStrip_UnAdHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UnAdHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_UnAdHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_UnAdHours
            // 
            this.gridControl_UnAdHours.ContextMenuStrip = this.contextMenuStrip_UnAdHours;
            this.gridControl_UnAdHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_UnAdHours.EmbeddedNavigator.Name = "";
            this.gridControl_UnAdHours.Location = new System.Drawing.Point(0, 59);
            this.gridControl_UnAdHours.MainView = this.gridView_UnAdHours;
            this.gridControl_UnAdHours.Name = "gridControl_UnAdHours";
            this.gridControl_UnAdHours.Size = new System.Drawing.Size(642, 403);
            this.gridControl_UnAdHours.TabIndex = 0;
            this.gridControl_UnAdHours.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_UnAdHours});
            this.gridControl_UnAdHours.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseDoubleClick);
            // 
            // contextMenuStrip_UnAdHours
            // 
            this.contextMenuStrip_UnAdHours.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sm_NewUAAH,
            this.sm_EditUAAH,
            this.sm_DeleteUAAH});
            this.contextMenuStrip_UnAdHours.Name = "contextMenuStrip_UnAdHours";
            this.contextMenuStrip_UnAdHours.Size = new System.Drawing.Size(252, 70);
            this.contextMenuStrip_UnAdHours.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // sm_NewUAAH
            // 
            this.sm_NewUAAH.Name = "sm_NewUAAH";
            this.sm_NewUAAH.Size = new System.Drawing.Size(251, 22);
            this.sm_NewUAAH.Text = "New Unavoidable Additional Hours";
            this.sm_NewUAAH.Click += new System.EventHandler(this.contextmenuItemNew_Click);
            // 
            // sm_EditUAAH
            // 
            this.sm_EditUAAH.Name = "sm_EditUAAH";
            this.sm_EditUAAH.Size = new System.Drawing.Size(251, 22);
            this.sm_EditUAAH.Text = "Edit Unavoidable Additional Hours";
            this.sm_EditUAAH.Click += new System.EventHandler(this.contextmenuItemEdit_Click);
            // 
            // sm_DeleteUAAH
            // 
            this.sm_DeleteUAAH.Name = "sm_DeleteUAAH";
            this.sm_DeleteUAAH.Size = new System.Drawing.Size(251, 22);
            this.sm_DeleteUAAH.Text = "Delete Unavoidable Additional Hours";
            this.sm_DeleteUAAH.Click += new System.EventHandler(this.contextmenuItemDelete_Click);
            // 
            // gridView_UnAdHours
            // 
            this.gridView_UnAdHours.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_yearappearance,
            this.gc_DayOfWeek,
            this.gc_StartTime,
            this.gc_FactorBegin,
            this.gc_FinishTime,
            this.gc_FactorEnd});
            this.gridView_UnAdHours.GridControl = this.gridControl_UnAdHours;
            this.gridView_UnAdHours.Name = "gridView_UnAdHours";
            this.gridView_UnAdHours.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView_UnAdHours.OptionsFilter.AllowFilterEditor = false;
            this.gridView_UnAdHours.OptionsFilter.AllowMRUFilterList = false;
            this.gridView_UnAdHours.OptionsMenu.EnableColumnMenu = false;
            this.gridView_UnAdHours.OptionsMenu.EnableFooterMenu = false;
            this.gridView_UnAdHours.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView_UnAdHours.OptionsView.ShowFooter = true;
            this.gridView_UnAdHours.OptionsView.ShowGroupPanel = false;
            this.gridView_UnAdHours.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_yearappearance, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_UnAdHours.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewUnAdHours_CustomUnboundColumnData);
            this.gridView_UnAdHours.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView_UnAdHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gc_yearappearance
            // 
            this.gc_yearappearance.Caption = "Year";
            this.gc_yearappearance.FieldName = "Year";
            this.gc_yearappearance.Name = "gc_yearappearance";
            this.gc_yearappearance.OptionsColumn.AllowEdit = false;
            this.gc_yearappearance.OptionsColumn.AllowMove = false;
            this.gc_yearappearance.OptionsColumn.ReadOnly = true;
            this.gc_yearappearance.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_yearappearance.OptionsFilter.AllowAutoFilter = false;
            this.gc_yearappearance.OptionsFilter.AllowFilter = false;
            this.gc_yearappearance.SummaryItem.DisplayFormat = "{0}";
            this.gc_yearappearance.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_yearappearance.Visible = true;
            this.gc_yearappearance.VisibleIndex = 0;
            // 
            // gc_DayOfWeek
            // 
            this.gc_DayOfWeek.Caption = "Week Day";
            this.gc_DayOfWeek.FieldName = "gc_DayOfWeek";
            this.gc_DayOfWeek.Name = "gc_DayOfWeek";
            this.gc_DayOfWeek.OptionsColumn.AllowEdit = false;
            this.gc_DayOfWeek.OptionsColumn.AllowMove = false;
            this.gc_DayOfWeek.OptionsColumn.ReadOnly = true;
            this.gc_DayOfWeek.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_DayOfWeek.OptionsFilter.AllowAutoFilter = false;
            this.gc_DayOfWeek.OptionsFilter.AllowFilter = false;
            this.gc_DayOfWeek.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_DayOfWeek.Visible = true;
            this.gc_DayOfWeek.VisibleIndex = 1;
            // 
            // gc_StartTime
            // 
            this.gc_StartTime.Caption = "Begin Time";
            this.gc_StartTime.DisplayFormat.FormatString = "t";
            this.gc_StartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_StartTime.FieldName = "gc_StartTime";
            this.gc_StartTime.Name = "gc_StartTime";
            this.gc_StartTime.OptionsColumn.AllowEdit = false;
            this.gc_StartTime.OptionsColumn.AllowMove = false;
            this.gc_StartTime.OptionsColumn.ReadOnly = true;
            this.gc_StartTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_StartTime.OptionsFilter.AllowAutoFilter = false;
            this.gc_StartTime.OptionsFilter.AllowFilter = false;
            this.gc_StartTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gc_StartTime.Visible = true;
            this.gc_StartTime.VisibleIndex = 2;
            // 
            // gc_FactorBegin
            // 
            this.gc_FactorBegin.Caption = "FactorBegin";
            this.gc_FactorBegin.FieldName = "FactorEarly";
            this.gc_FactorBegin.Name = "gc_FactorBegin";
            this.gc_FactorBegin.OptionsColumn.AllowEdit = false;
            this.gc_FactorBegin.OptionsColumn.AllowMove = false;
            this.gc_FactorBegin.OptionsColumn.ReadOnly = true;
            this.gc_FactorBegin.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_FactorBegin.OptionsFilter.AllowAutoFilter = false;
            this.gc_FactorBegin.OptionsFilter.AllowFilter = false;
            this.gc_FactorBegin.Visible = true;
            this.gc_FactorBegin.VisibleIndex = 3;
            // 
            // gc_FinishTime
            // 
            this.gc_FinishTime.Caption = "End Time";
            this.gc_FinishTime.DisplayFormat.FormatString = "t";
            this.gc_FinishTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_FinishTime.FieldName = "gc_FinishTime";
            this.gc_FinishTime.Name = "gc_FinishTime";
            this.gc_FinishTime.OptionsColumn.AllowEdit = false;
            this.gc_FinishTime.OptionsColumn.AllowMove = false;
            this.gc_FinishTime.OptionsColumn.ReadOnly = true;
            this.gc_FinishTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_FinishTime.OptionsFilter.AllowAutoFilter = false;
            this.gc_FinishTime.OptionsFilter.AllowFilter = false;
            this.gc_FinishTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gc_FinishTime.Visible = true;
            this.gc_FinishTime.VisibleIndex = 4;
            // 
            // gc_FactorEnd
            // 
            this.gc_FactorEnd.Caption = "FactorEnd";
            this.gc_FactorEnd.FieldName = "FactorLate";
            this.gc_FactorEnd.Name = "gc_FactorEnd";
            this.gc_FactorEnd.OptionsColumn.AllowEdit = false;
            this.gc_FactorEnd.OptionsColumn.AllowMove = false;
            this.gc_FactorEnd.OptionsColumn.ReadOnly = true;
            this.gc_FactorEnd.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_FactorEnd.OptionsFilter.AllowAutoFilter = false;
            this.gc_FactorEnd.OptionsFilter.AllowFilter = false;
            this.gc_FactorEnd.Visible = true;
            this.gc_FactorEnd.VisibleIndex = 5;
            // 
            // barManager_UnAdHours
            // 
            this.barManager_UnAdHours.AllowCustomization = false;
            this.barManager_UnAdHours.AllowQuickCustomization = false;
            this.barManager_UnAdHours.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTool,
            this.barFilter});
            this.barManager_UnAdHours.DockControls.Add(this.barDockControlTop);
            this.barManager_UnAdHours.DockControls.Add(this.barDockControlBottom);
            this.barManager_UnAdHours.DockControls.Add(this.barDockControlLeft);
            this.barManager_UnAdHours.DockControls.Add(this.barDockControlRight);
            this.barManager_UnAdHours.Form = this;
            this.barManager_UnAdHours.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewUAAH,
            this.bi_EditUAAH,
            this.bi_DeleteUAAH,
            this.Calculate,
            this.lb_FilterByDate,
            this.lb_to,
            this.de_Begin,
            this.de_End,
            this.bt_Apply,
            this.barEditItem1});
            this.barManager_UnAdHours.MaxItemId = 10;
            this.barManager_UnAdHours.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seBegin,
            this.seEnd,
            this.repositoryItemButtonEdit1});
            // 
            // barTool
            // 
            this.barTool.BarName = "Tools";
            this.barTool.DockCol = 0;
            this.barTool.DockRow = 0;
            this.barTool.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTool.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewUAAH),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditUAAH),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteUAAH),
            new DevExpress.XtraBars.LinkPersistInfo(this.Calculate)});
            this.barTool.OptionsBar.AllowQuickCustomization = false;
            this.barTool.OptionsBar.DisableClose = true;
            this.barTool.OptionsBar.DisableCustomization = true;
            this.barTool.OptionsBar.DrawDragBorder = false;
            this.barTool.OptionsBar.UseWholeRow = true;
            this.barTool.Text = "Tools";
            // 
            // bi_NewUAAH
            // 
            this.bi_NewUAAH.Caption = "New Unavoidable Additional Hours";
            this.bi_NewUAAH.Glyph = global::Baumax.ClientUI.Properties.Resources.clock_preferences;
            this.bi_NewUAAH.Id = 0;
            this.bi_NewUAAH.Name = "bi_NewUAAH";
            this.bi_NewUAAH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewUAAH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewUAAH_Click);
            // 
            // bi_EditUAAH
            // 
            this.bi_EditUAAH.Caption = "Edit Unavoidable Additional Hours";
            this.bi_EditUAAH.Glyph = global::Baumax.ClientUI.Properties.Resources.clock_refresh;
            this.bi_EditUAAH.Id = 1;
            this.bi_EditUAAH.Name = "bi_EditUAAH";
            this.bi_EditUAAH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_EditUAAH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditUAAH_Click);
            // 
            // bi_DeleteUAAH
            // 
            this.bi_DeleteUAAH.Caption = "Delete Unavoidable Additional Hours";
            this.bi_DeleteUAAH.Glyph = global::Baumax.ClientUI.Properties.Resources.del;
            this.bi_DeleteUAAH.Id = 2;
            this.bi_DeleteUAAH.Name = "bi_DeleteUAAH";
            this.bi_DeleteUAAH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteUAAH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteUAAH_Click);
            // 
            // Calculate
            // 
            this.Calculate.Caption = "calculate";
            this.Calculate.Id = 3;
            this.Calculate.Name = "Calculate";
            this.Calculate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_calculate_click);
            // 
            // barFilter
            // 
            this.barFilter.BarName = "Filter";
            this.barFilter.DockCol = 0;
            this.barFilter.DockRow = 1;
            this.barFilter.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barFilter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lb_FilterByDate),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.de_Begin, "", false, true, true, 64),
            new DevExpress.XtraBars.LinkPersistInfo(this.lb_to),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.de_End, "", false, true, true, 78),
            new DevExpress.XtraBars.LinkPersistInfo(this.bt_Apply)});
            this.barFilter.OptionsBar.AllowQuickCustomization = false;
            this.barFilter.OptionsBar.DisableClose = true;
            this.barFilter.OptionsBar.DisableCustomization = true;
            this.barFilter.OptionsBar.DrawDragBorder = false;
            this.barFilter.OptionsBar.UseWholeRow = true;
            this.barFilter.Text = "Filter";
            // 
            // lb_FilterByDate
            // 
            this.lb_FilterByDate.Caption = "Filter by Date";
            this.lb_FilterByDate.Id = 4;
            this.lb_FilterByDate.Name = "lb_FilterByDate";
            this.lb_FilterByDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // de_Begin
            // 
            this.de_Begin.Caption = "barEditItem1";
            this.de_Begin.Edit = this.seBegin;
            this.de_Begin.Id = 6;
            this.de_Begin.Name = "de_Begin";
            // 
            // seBegin
            // 
            this.seBegin.AutoHeight = false;
            this.seBegin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seBegin.IsFloatValue = false;
            this.seBegin.Mask.EditMask = "0000";
            this.seBegin.MaxLength = 4;
            this.seBegin.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.seBegin.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seBegin.Name = "seBegin";
            // 
            // lb_to
            // 
            this.lb_to.Caption = "to";
            this.lb_to.Id = 5;
            this.lb_to.Name = "lb_to";
            this.lb_to.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // de_End
            // 
            this.de_End.Caption = "barEditItem2";
            this.de_End.Edit = this.seEnd;
            this.de_End.Id = 7;
            this.de_End.Name = "de_End";
            this.de_End.EditValueChanged += new System.EventHandler(this.de_End_EditValueChanged);
            // 
            // seEnd
            // 
            this.seEnd.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.seEnd.AutoHeight = false;
            this.seEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.seEnd.IsFloatValue = false;
            this.seEnd.Mask.EditMask = "0000";
            this.seEnd.MaxLength = 4;
            this.seEnd.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.seEnd.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seEnd.Name = "seEnd";
            this.seEnd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.seEnd_buttonClick);
            // 
            // bt_Apply
            // 
            this.bt_Apply.Caption = "Apply";
            this.bt_Apply.Id = 8;
            this.bt_Apply.Name = "bt_Apply";
            this.bt_Apply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Apply_Click);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemButtonEdit1;
            this.barEditItem1.Id = 9;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // UCUnavoidableAddHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_UnAdHours);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCUnavoidableAddHours";
            this.Size = new System.Drawing.Size(642, 462);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UnAdHours)).EndInit();
            this.contextMenuStrip_UnAdHours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UnAdHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_UnAdHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_UnAdHours;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_UnAdHours;
        private DevExpress.XtraBars.BarManager barManager_UnAdHours;
        private DevExpress.XtraBars.Bar barTool;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_UnAdHours;
        private DevExpress.XtraBars.BarButtonItem bi_NewUAAH;
        private DevExpress.XtraBars.BarButtonItem bi_EditUAAH;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteUAAH;
        private System.Windows.Forms.ToolStripMenuItem sm_NewUAAH;
        private System.Windows.Forms.ToolStripMenuItem sm_EditUAAH;
        private System.Windows.Forms.ToolStripMenuItem sm_DeleteUAAH;
        private DevExpress.XtraGrid.Columns.GridColumn gc_yearappearance;
        private DevExpress.XtraGrid.Columns.GridColumn gc_StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FinishTime;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FactorBegin;
        private DevExpress.XtraBars.BarButtonItem Calculate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_DayOfWeek;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FactorE;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FactorEnd;
        private DevExpress.XtraBars.Bar barFilter;
        private DevExpress.XtraBars.BarStaticItem lb_FilterByDate;
        private DevExpress.XtraBars.BarEditItem de_Begin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seBegin;
        private DevExpress.XtraBars.BarStaticItem lb_to;
        private DevExpress.XtraBars.BarEditItem de_End;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seEnd;
        private DevExpress.XtraBars.BarButtonItem bt_Apply;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
