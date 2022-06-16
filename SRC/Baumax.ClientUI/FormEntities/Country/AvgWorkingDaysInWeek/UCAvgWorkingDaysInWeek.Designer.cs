namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCAvgWorkingDaysInWeek
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.bi_NewAverageDaysInWeek = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditAverageDaysInWeek = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteAverageDaysInWeek = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlAvgWDiWeek = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripAvgWDInWeek = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NewAverageDaysInWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditAverageDaysInWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteAverageDaysInWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewAvgWDiWeek = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_yearappearance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_AverageWorkingDayInWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAvgWDiWeek)).BeginInit();
            this.contextMenuStripAvgWDInWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAvgWDiWeek)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewAverageDaysInWeek,
            this.bi_EditAverageDaysInWeek,
            this.bi_DeleteAverageDaysInWeek});
            this.barManager1.MaxItemId = 4;
            // 
            // barTools
            // 
            this.barTools.BarName = "Tools";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewAverageDaysInWeek, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditAverageDaysInWeek),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteAverageDaysInWeek)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DisableClose = true;
            this.barTools.OptionsBar.DisableCustomization = true;
            this.barTools.OptionsBar.DrawDragBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
            // 
            // bi_NewAverageDaysInWeek
            // 
            this.bi_NewAverageDaysInWeek.Caption = "New Avg WD in Week";
            this.bi_NewAverageDaysInWeek.Glyph = global::Baumax.ClientUI.Properties.Resources.table_add;
            this.bi_NewAverageDaysInWeek.Id = 0;
            this.bi_NewAverageDaysInWeek.Name = "bi_NewAverageDaysInWeek";
            this.bi_NewAverageDaysInWeek.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewAverageDaysInWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewAvgWorkingDaysInWeek_ItemClick);
            // 
            // bi_EditAverageDaysInWeek
            // 
            this.bi_EditAverageDaysInWeek.Caption = "Edit Avg WD in Week";
            this.bi_EditAverageDaysInWeek.Glyph = global::Baumax.ClientUI.Properties.Resources.table_replace;
            this.bi_EditAverageDaysInWeek.Id = 1;
            this.bi_EditAverageDaysInWeek.Name = "bi_EditAverageDaysInWeek";
            this.bi_EditAverageDaysInWeek.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_EditAverageDaysInWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditAvgWorkingDaysInWeek_ItemClick);
            // 
            // bi_DeleteAverageDaysInWeek
            // 
            this.bi_DeleteAverageDaysInWeek.Caption = "Delete Avg WD in Week";
            this.bi_DeleteAverageDaysInWeek.Glyph = global::Baumax.ClientUI.Properties.Resources.tables_delete;
            this.bi_DeleteAverageDaysInWeek.Id = 2;
            this.bi_DeleteAverageDaysInWeek.Name = "bi_DeleteAverageDaysInWeek";
            this.bi_DeleteAverageDaysInWeek.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteAverageDaysInWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteAvgWorkingDaysInWeek_ItemClick);
            // 
            // gridControlAvgWDiWeek
            // 
            this.gridControlAvgWDiWeek.ContextMenuStrip = this.contextMenuStripAvgWDInWeek;
            this.gridControlAvgWDiWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAvgWDiWeek.EmbeddedNavigator.Name = "";
            this.gridControlAvgWDiWeek.Location = new System.Drawing.Point(0, 34);
            this.gridControlAvgWDiWeek.MainView = this.gridViewAvgWDiWeek;
            this.gridControlAvgWDiWeek.Name = "gridControlAvgWDiWeek";
            this.gridControlAvgWDiWeek.Size = new System.Drawing.Size(561, 321);
            this.gridControlAvgWDiWeek.TabIndex = 5;
            this.gridControlAvgWDiWeek.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAvgWDiWeek});
            this.gridControlAvgWDiWeek.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseDoubleClick);
            // 
            // contextMenuStripAvgWDInWeek
            // 
            this.contextMenuStripAvgWDInWeek.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NewAverageDaysInWeek,
            this.toolStripMenuItem_EditAverageDaysInWeek,
            this.toolStripMenuItem_DeleteAverageDaysInWeek});
            this.contextMenuStripAvgWDInWeek.Name = "contextMenuStripAvgWDInWeek";
            this.contextMenuStripAvgWDInWeek.Size = new System.Drawing.Size(196, 70);
            this.contextMenuStripAvgWDInWeek.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAvgWDInWeek_Opening);
            // 
            // toolStripMenuItem_NewAverageDaysInWeek
            // 
            this.toolStripMenuItem_NewAverageDaysInWeek.Name = "toolStripMenuItem_NewAverageDaysInWeek";
            this.toolStripMenuItem_NewAverageDaysInWeek.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_NewAverageDaysInWeek.Text = "New Avg WD in Week";
            this.toolStripMenuItem_NewAverageDaysInWeek.Click += new System.EventHandler(this.NewAvgWDInWeekTollMenuStrip_Click);
            // 
            // toolStripMenuItem_EditAverageDaysInWeek
            // 
            this.toolStripMenuItem_EditAverageDaysInWeek.Name = "toolStripMenuItem_EditAverageDaysInWeek";
            this.toolStripMenuItem_EditAverageDaysInWeek.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_EditAverageDaysInWeek.Text = "Edit Avg WD in Week";
            this.toolStripMenuItem_EditAverageDaysInWeek.Click += new System.EventHandler(this.EditAvgWDInWeekTollMenuStrip_Click);
            // 
            // toolStripMenuItem_DeleteAverageDaysInWeek
            // 
            this.toolStripMenuItem_DeleteAverageDaysInWeek.Name = "toolStripMenuItem_DeleteAverageDaysInWeek";
            this.toolStripMenuItem_DeleteAverageDaysInWeek.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_DeleteAverageDaysInWeek.Text = "Delete Avg WD in Week";
            this.toolStripMenuItem_DeleteAverageDaysInWeek.Click += new System.EventHandler(this.DeleteAvgWDInWeekTollMenuStrip_Click);
            // 
            // gridViewAvgWDiWeek
            // 
            this.gridViewAvgWDiWeek.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_yearappearance,
            this.gc_AverageWorkingDayInWeek});
            this.gridViewAvgWDiWeek.GridControl = this.gridControlAvgWDiWeek;
            this.gridViewAvgWDiWeek.Name = "gridViewAvgWDiWeek";
            this.gridViewAvgWDiWeek.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewAvgWDiWeek.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewAvgWDiWeek.OptionsFilter.AllowFilterEditor = false;
            this.gridViewAvgWDiWeek.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewAvgWDiWeek.OptionsMenu.EnableColumnMenu = false;
            this.gridViewAvgWDiWeek.OptionsMenu.EnableFooterMenu = false;
            this.gridViewAvgWDiWeek.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewAvgWDiWeek.OptionsView.ShowFooter = true;
            this.gridViewAvgWDiWeek.OptionsView.ShowGroupPanel = false;
            this.gridViewAvgWDiWeek.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_yearappearance, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAvgWDiWeek.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridViewAvgWDiWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewAvgWDInWeek_KeyDown);
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
            this.gc_yearappearance.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_yearappearance.SummaryItem.DisplayFormat = "{0}";
            this.gc_yearappearance.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_yearappearance.Visible = true;
            this.gc_yearappearance.VisibleIndex = 0;
            // 
            // gc_AverageWorkingDayInWeek
            // 
            this.gc_AverageWorkingDayInWeek.Caption = "Avg Working DayMasks In Week";
            this.gc_AverageWorkingDayInWeek.FieldName = "DaysCount";
            this.gc_AverageWorkingDayInWeek.Name = "gc_AverageWorkingDayInWeek";
            this.gc_AverageWorkingDayInWeek.OptionsColumn.AllowEdit = false;
            this.gc_AverageWorkingDayInWeek.OptionsColumn.AllowMove = false;
            this.gc_AverageWorkingDayInWeek.OptionsColumn.ReadOnly = true;
            this.gc_AverageWorkingDayInWeek.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AverageWorkingDayInWeek.OptionsFilter.AllowAutoFilter = false;
            this.gc_AverageWorkingDayInWeek.OptionsFilter.AllowFilter = false;
            this.gc_AverageWorkingDayInWeek.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_AverageWorkingDayInWeek.Visible = true;
            this.gc_AverageWorkingDayInWeek.VisibleIndex = 1;
            // 
            // UCAvgWorkingDaysInWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlAvgWDiWeek);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCAvgWorkingDaysInWeek";
            this.Size = new System.Drawing.Size(561, 355);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAvgWDiWeek)).EndInit();
            this.contextMenuStripAvgWDInWeek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAvgWDiWeek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlAvgWDiWeek;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAvgWDiWeek;
        private DevExpress.XtraBars.BarButtonItem bi_NewAverageDaysInWeek;
        private DevExpress.XtraBars.BarButtonItem bi_EditAverageDaysInWeek;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteAverageDaysInWeek;
        private DevExpress.XtraGrid.Columns.GridColumn gc_yearappearance;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AverageWorkingDayInWeek;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAvgWDInWeek;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NewAverageDaysInWeek;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditAverageDaysInWeek;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteAverageDaysInWeek;
    }
}
