namespace Baumax.ClientUI.FormEntities.Country
{
    partial class YearlyAppearanceListControl
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
            this.components = new System.ComponentModel.Container();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripYearly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_newYearlyAppearance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editYearlyAppearance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_deleteYearlyAppearance = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewYearly = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_YearAppearance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AvgWeeks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AvgContractTimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AvgCashDeskAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_AvgRestingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager_YA = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_tools = new DevExpress.XtraBars.Bar();
            this.bi_NewYearlyAppearance = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditYearlyAppearance = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteYearlyAppearance = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStripYearly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewYearly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_YA)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStripYearly;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridViewYearly;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(669, 390);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewYearly});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // contextMenuStripYearly
            // 
            this.contextMenuStripYearly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_newYearlyAppearance,
            this.toolStripMenuItem_editYearlyAppearance,
            this.toolStripMenuItem_deleteYearlyAppearance});
            this.contextMenuStripYearly.Name = "contextMenuStripYearly";
            this.contextMenuStripYearly.Size = new System.Drawing.Size(199, 70);
            this.contextMenuStripYearly.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripYearly_Opening);
            // 
            // toolStripMenuItem_newYearlyAppearance
            // 
            this.toolStripMenuItem_newYearlyAppearance.Name = "toolStripMenuItem_newYearlyAppearance";
            this.toolStripMenuItem_newYearlyAppearance.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem_newYearlyAppearance.Text = "New yearly appearance";
            this.toolStripMenuItem_newYearlyAppearance.Click += new System.EventHandler(this.newYearlyAppearanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_editYearlyAppearance
            // 
            this.toolStripMenuItem_editYearlyAppearance.Name = "toolStripMenuItem_editYearlyAppearance";
            this.toolStripMenuItem_editYearlyAppearance.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem_editYearlyAppearance.Text = "Edit yearly appearance";
            this.toolStripMenuItem_editYearlyAppearance.Click += new System.EventHandler(this.editYearlyAppearanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_deleteYearlyAppearance
            // 
            this.toolStripMenuItem_deleteYearlyAppearance.Name = "toolStripMenuItem_deleteYearlyAppearance";
            this.toolStripMenuItem_deleteYearlyAppearance.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem_deleteYearlyAppearance.Text = "Delete yearly appearance";
            this.toolStripMenuItem_deleteYearlyAppearance.Click += new System.EventHandler(this.deleteYearlyAppearanceToolStripMenuItem_Click);
            // 
            // gridViewYearly
            // 
            this.gridViewYearly.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_YearAppearance,
            this.gridColumn_AvgWeeks,
            this.gridColumn_AvgContractTimes,
            this.gridColumn_AvgCashDeskAmount,
            this.gc_AvgRestingTime});
            this.gridViewYearly.GridControl = this.gridControl;
            this.gridViewYearly.Name = "gridViewYearly";
            this.gridViewYearly.OptionsBehavior.Editable = false;
            this.gridViewYearly.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewYearly.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewYearly.OptionsFilter.AllowFilterEditor = false;
            this.gridViewYearly.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewYearly.OptionsMenu.EnableColumnMenu = false;
            this.gridViewYearly.OptionsMenu.EnableFooterMenu = false;
            this.gridViewYearly.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewYearly.OptionsView.ShowFooter = true;
            this.gridViewYearly.OptionsView.ShowGroupPanel = false;
            this.gridViewYearly.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_YearAppearance, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewYearly.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewYearly_focusedRowChanged);
            this.gridViewYearly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewYearly_KeyDown);
            // 
            // gridColumn_YearAppearance
            // 
            this.gridColumn_YearAppearance.Caption = "Year";
            this.gridColumn_YearAppearance.FieldName = "Year";
            this.gridColumn_YearAppearance.Name = "gridColumn_YearAppearance";
            this.gridColumn_YearAppearance.OptionsColumn.AllowEdit = false;
            this.gridColumn_YearAppearance.OptionsColumn.AllowMove = false;
            this.gridColumn_YearAppearance.OptionsColumn.ReadOnly = true;
            this.gridColumn_YearAppearance.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_YearAppearance.OptionsFilter.AllowFilter = false;
            this.gridColumn_YearAppearance.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn_YearAppearance.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn_YearAppearance.Visible = true;
            this.gridColumn_YearAppearance.VisibleIndex = 0;
            this.gridColumn_YearAppearance.Width = 140;
            // 
            // gridColumn_AvgWeeks
            // 
            this.gridColumn_AvgWeeks.Caption = "Weeks";
            this.gridColumn_AvgWeeks.FieldName = "AvgWeeks";
            this.gridColumn_AvgWeeks.Name = "gridColumn_AvgWeeks";
            this.gridColumn_AvgWeeks.OptionsColumn.AllowEdit = false;
            this.gridColumn_AvgWeeks.OptionsColumn.AllowMove = false;
            this.gridColumn_AvgWeeks.OptionsColumn.ReadOnly = true;
            this.gridColumn_AvgWeeks.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AvgWeeks.OptionsFilter.AllowFilter = false;
            this.gridColumn_AvgWeeks.Visible = true;
            this.gridColumn_AvgWeeks.VisibleIndex = 1;
            this.gridColumn_AvgWeeks.Width = 157;
            // 
            // gridColumn_AvgContractTimes
            // 
            this.gridColumn_AvgContractTimes.Caption = "Avg Contract Time";
            this.gridColumn_AvgContractTimes.FieldName = "AvgContractTime";
            this.gridColumn_AvgContractTimes.Name = "gridColumn_AvgContractTimes";
            this.gridColumn_AvgContractTimes.OptionsColumn.AllowEdit = false;
            this.gridColumn_AvgContractTimes.OptionsColumn.AllowMove = false;
            this.gridColumn_AvgContractTimes.OptionsColumn.ReadOnly = true;
            this.gridColumn_AvgContractTimes.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AvgContractTimes.OptionsFilter.AllowFilter = false;
            this.gridColumn_AvgContractTimes.Visible = true;
            this.gridColumn_AvgContractTimes.VisibleIndex = 2;
            this.gridColumn_AvgContractTimes.Width = 170;
            // 
            // gridColumn_AvgCashDeskAmount
            // 
            this.gridColumn_AvgCashDeskAmount.Caption = "Cash desk amount";
            this.gridColumn_AvgCashDeskAmount.FieldName = "CashDeskAmount";
            this.gridColumn_AvgCashDeskAmount.Name = "gridColumn_AvgCashDeskAmount";
            this.gridColumn_AvgCashDeskAmount.OptionsColumn.AllowEdit = false;
            this.gridColumn_AvgCashDeskAmount.OptionsColumn.AllowMove = false;
            this.gridColumn_AvgCashDeskAmount.OptionsColumn.ReadOnly = true;
            this.gridColumn_AvgCashDeskAmount.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AvgCashDeskAmount.OptionsFilter.AllowFilter = false;
            this.gridColumn_AvgCashDeskAmount.Visible = true;
            this.gridColumn_AvgCashDeskAmount.VisibleIndex = 4;
            this.gridColumn_AvgCashDeskAmount.Width = 181;
            // 
            // gc_AvgRestingTime
            // 
            this.gc_AvgRestingTime.Caption = "Avg Resting time";
            this.gc_AvgRestingTime.FieldName = "AvgRestingTime";
            this.gc_AvgRestingTime.Name = "gc_AvgRestingTime";
            this.gc_AvgRestingTime.OptionsColumn.AllowEdit = false;
            this.gc_AvgRestingTime.OptionsColumn.ReadOnly = true;
            this.gc_AvgRestingTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AvgRestingTime.OptionsFilter.AllowFilter = false;
            this.gc_AvgRestingTime.Visible = true;
            this.gc_AvgRestingTime.VisibleIndex = 3;
            // 
            // barManager_YA
            // 
            this.barManager_YA.AllowCustomization = false;
            this.barManager_YA.AllowQuickCustomization = false;
            this.barManager_YA.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_tools});
            this.barManager_YA.DockControls.Add(this.barDockControlTop);
            this.barManager_YA.DockControls.Add(this.barDockControlBottom);
            this.barManager_YA.DockControls.Add(this.barDockControlLeft);
            this.barManager_YA.DockControls.Add(this.barDockControlRight);
            this.barManager_YA.Form = this;
            this.barManager_YA.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewYearlyAppearance,
            this.bi_EditYearlyAppearance,
            this.bi_DeleteYearlyAppearance});
            this.barManager_YA.MaxItemId = 3;
            // 
            // bar_tools
            // 
            this.bar_tools.BarName = "Tools";
            this.bar_tools.DockCol = 0;
            this.bar_tools.DockRow = 0;
            this.bar_tools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_tools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewYearlyAppearance),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditYearlyAppearance),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteYearlyAppearance)});
            this.bar_tools.OptionsBar.AllowQuickCustomization = false;
            this.bar_tools.OptionsBar.DisableClose = true;
            this.bar_tools.OptionsBar.DisableCustomization = true;
            this.bar_tools.OptionsBar.DrawDragBorder = false;
            this.bar_tools.OptionsBar.UseWholeRow = true;
            this.bar_tools.Text = "Custom 3";
            // 
            // bi_NewYearlyAppearance
            // 
            this.bi_NewYearlyAppearance.Caption = "New Yearly Appearance";
            this.bi_NewYearlyAppearance.Glyph = global::Baumax.ClientUI.Properties.Resources.gear_add;
            this.bi_NewYearlyAppearance.Id = 0;
            this.bi_NewYearlyAppearance.Name = "bi_NewYearlyAppearance";
            this.bi_NewYearlyAppearance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewYearlyAppearance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewYearlyAppearance_Click);
            // 
            // bi_EditYearlyAppearance
            // 
            this.bi_EditYearlyAppearance.Caption = "Edit Yearly Appearance";
            this.bi_EditYearlyAppearance.Glyph = global::Baumax.ClientUI.Properties.Resources.gear_refresh;
            this.bi_EditYearlyAppearance.Id = 1;
            this.bi_EditYearlyAppearance.Name = "bi_EditYearlyAppearance";
            this.bi_EditYearlyAppearance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_EditYearlyAppearance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditYearlyAppearance_click);
            // 
            // bi_DeleteYearlyAppearance
            // 
            this.bi_DeleteYearlyAppearance.Caption = "Delete Yearly Appearance";
            this.bi_DeleteYearlyAppearance.Glyph = global::Baumax.ClientUI.Properties.Resources.gear_delete;
            this.bi_DeleteYearlyAppearance.Id = 2;
            this.bi_DeleteYearlyAppearance.Name = "bi_DeleteYearlyAppearance";
            this.bi_DeleteYearlyAppearance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteYearlyAppearance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteYearlyAppearance_click);
            // 
            // YearlyAppearanceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "YearlyAppearanceListControl";
            this.Size = new System.Drawing.Size(669, 424);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStripYearly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewYearly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_YA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewYearly;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_YearAppearance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AvgWeeks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripYearly;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newYearlyAppearance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteYearlyAppearance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editYearlyAppearance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AvgContractTimes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AvgCashDeskAmount;
        private DevExpress.XtraBars.BarManager barManager_YA;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar_tools;
        private DevExpress.XtraBars.BarButtonItem bi_NewYearlyAppearance;
        private DevExpress.XtraBars.BarButtonItem bi_EditYearlyAppearance;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteYearlyAppearance;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AvgRestingTime;
    }
}
