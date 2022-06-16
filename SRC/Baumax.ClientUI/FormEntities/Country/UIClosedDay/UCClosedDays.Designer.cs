namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCClosedDays
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
            this.gridControlCloseDay = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripCloseDay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NewClosedDays = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteClosedDays = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewCloseDay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_ClosedDaysDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_DayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_tools = new DevExpress.XtraBars.Bar();
            this.bi_Import = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewClosedDays = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteClosedDays = new DevExpress.XtraBars.BarButtonItem();
            this.barFilter = new DevExpress.XtraBars.Bar();
            this.lb_FilterByDate = new DevExpress.XtraBars.BarStaticItem();
            this.de_Begin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lb_to = new DevExpress.XtraBars.BarStaticItem();
            this.de_End = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bt_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCloseDay)).BeginInit();
            this.contextMenuStripCloseDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCloseDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCloseDay
            // 
            this.gridControlCloseDay.ContextMenuStrip = this.contextMenuStripCloseDay;
            this.gridControlCloseDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCloseDay.EmbeddedNavigator.Name = "";
            this.gridControlCloseDay.Location = new System.Drawing.Point(0, 59);
            this.gridControlCloseDay.MainView = this.gridViewCloseDay;
            this.gridControlCloseDay.Name = "gridControlCloseDay";
            this.gridControlCloseDay.Size = new System.Drawing.Size(638, 403);
            this.gridControlCloseDay.TabIndex = 0;
            this.gridControlCloseDay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCloseDay});
            // 
            // contextMenuStripCloseDay
            // 
            this.contextMenuStripCloseDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NewClosedDays,
            this.toolStripMenuItem_DeleteClosedDays});
            this.contextMenuStripCloseDay.Name = "contextMenuStripWorkingDay";
            this.contextMenuStripCloseDay.Size = new System.Drawing.Size(163, 48);
            this.contextMenuStripCloseDay.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCloseDay_Opening);
            // 
            // toolStripMenuItem_NewClosedDays
            // 
            this.toolStripMenuItem_NewClosedDays.Name = "toolStripMenuItem_NewClosedDays";
            this.toolStripMenuItem_NewClosedDays.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem_NewClosedDays.Text = "New closed days";
            this.toolStripMenuItem_NewClosedDays.Click += new System.EventHandler(this.newClosedDayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_DeleteClosedDays
            // 
            this.toolStripMenuItem_DeleteClosedDays.Name = "toolStripMenuItem_DeleteClosedDays";
            this.toolStripMenuItem_DeleteClosedDays.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem_DeleteClosedDays.Text = "Delete closed day";
            this.toolStripMenuItem_DeleteClosedDays.Click += new System.EventHandler(this.deleteClosedDayToolStripMenuItem_Click);
            // 
            // gridViewCloseDay
            // 
            this.gridViewCloseDay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_ClosedDaysDate,
            this.gc_DayOfWeek});
            this.gridViewCloseDay.GridControl = this.gridControlCloseDay;
            this.gridViewCloseDay.Name = "gridViewCloseDay";
            this.gridViewCloseDay.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewCloseDay.OptionsFilter.AllowFilterEditor = false;
            this.gridViewCloseDay.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewCloseDay.OptionsMenu.EnableColumnMenu = false;
            this.gridViewCloseDay.OptionsMenu.EnableFooterMenu = false;
            this.gridViewCloseDay.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewCloseDay.OptionsSelection.MultiSelect = true;
            this.gridViewCloseDay.OptionsView.ShowFooter = true;
            this.gridViewCloseDay.OptionsView.ShowGroupPanel = false;
            this.gridViewCloseDay.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_ClosedDaysDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewCloseDay.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewWorkingDay_CustomUnboundColumnData);
            this.gridViewCloseDay.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridViewCloseDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewCloseDay_KeyDown);
            // 
            // gridColumn_ClosedDaysDate
            // 
            this.gridColumn_ClosedDaysDate.Caption = "Date";
            this.gridColumn_ClosedDaysDate.FieldName = "WorkingDay";
            this.gridColumn_ClosedDaysDate.Name = "gridColumn_ClosedDaysDate";
            this.gridColumn_ClosedDaysDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_ClosedDaysDate.OptionsColumn.AllowMove = false;
            this.gridColumn_ClosedDaysDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_ClosedDaysDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_ClosedDaysDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_ClosedDaysDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_ClosedDaysDate.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn_ClosedDaysDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn_ClosedDaysDate.Visible = true;
            this.gridColumn_ClosedDaysDate.VisibleIndex = 0;
            this.gridColumn_ClosedDaysDate.Width = 275;
            // 
            // gc_DayOfWeek
            // 
            this.gc_DayOfWeek.Caption = "day of week";
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
            this.gc_DayOfWeek.Width = 342;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_tools,
            this.barFilter});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewClosedDays,
            this.bi_DeleteClosedDays,
            this.bi_Import,
            this.lb_FilterByDate,
            this.de_Begin,
            this.lb_to,
            this.de_End,
            this.bt_Apply});
            this.barManager1.MaxItemId = 12;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            // 
            // bar_tools
            // 
            this.bar_tools.BarName = "Tools";
            this.bar_tools.DockCol = 0;
            this.bar_tools.DockRow = 0;
            this.bar_tools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_tools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Import),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewClosedDays),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteClosedDays)});
            this.bar_tools.OptionsBar.AllowQuickCustomization = false;
            this.bar_tools.OptionsBar.DisableClose = true;
            this.bar_tools.OptionsBar.DisableCustomization = true;
            this.bar_tools.OptionsBar.DrawDragBorder = false;
            this.bar_tools.OptionsBar.UseWholeRow = true;
            this.bar_tools.Text = "Tools";
            // 
            // bi_Import
            // 
            this.bi_Import.Caption = "Import";
            this.bi_Import.Glyph = global::Baumax.ClientUI.Properties.Resources.data_replace;
            this.bi_Import.Id = 2;
            this.bi_Import.Name = "bi_Import";
            this.bi_Import.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_Import.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_Import_ItemClick);
            // 
            // bi_NewClosedDays
            // 
            this.bi_NewClosedDays.AccessibleName = "";
            this.bi_NewClosedDays.Caption = "New closed days";
            this.bi_NewClosedDays.Glyph = global::Baumax.ClientUI.Properties.Resources.document_add;
            this.bi_NewClosedDays.Id = 0;
            this.bi_NewClosedDays.Name = "bi_NewClosedDays";
            this.bi_NewClosedDays.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewClosedDays.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewCloseDay_ItemClick);
            // 
            // bi_DeleteClosedDays
            // 
            this.bi_DeleteClosedDays.Caption = "Delete closed day";
            this.bi_DeleteClosedDays.Glyph = global::Baumax.ClientUI.Properties.Resources.document_delete;
            this.bi_DeleteClosedDays.Id = 1;
            this.bi_DeleteClosedDays.Name = "bi_DeleteClosedDays";
            this.bi_DeleteClosedDays.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteClosedDays.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteCloseDay_ItemClick);
            // 
            // barFilter
            // 
            this.barFilter.BarName = "Custom 4";
            this.barFilter.DockCol = 0;
            this.barFilter.DockRow = 1;
            this.barFilter.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barFilter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lb_FilterByDate),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.de_Begin, "", false, true, true, 82),
            new DevExpress.XtraBars.LinkPersistInfo(this.lb_to),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.de_End, "", false, true, true, 82),
            new DevExpress.XtraBars.LinkPersistInfo(this.bt_Apply)});
            this.barFilter.OptionsBar.AllowQuickCustomization = false;
            this.barFilter.OptionsBar.DisableClose = true;
            this.barFilter.OptionsBar.DisableCustomization = true;
            this.barFilter.OptionsBar.DrawDragBorder = false;
            this.barFilter.OptionsBar.DrawSizeGrip = true;
            this.barFilter.OptionsBar.UseWholeRow = true;
            this.barFilter.Text = "Custom 4";
            // 
            // lb_FilterByDate
            // 
            this.lb_FilterByDate.Caption = "Filter By Date";
            this.lb_FilterByDate.Id = 3;
            this.lb_FilterByDate.Name = "lb_FilterByDate";
            this.lb_FilterByDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // de_Begin
            // 
            this.de_Begin.Caption = "Begin";
            this.de_Begin.Edit = this.repositoryItemDateEdit1;
            this.de_Begin.Id = 4;
            this.de_Begin.Name = "de_Begin";
            this.de_Begin.EditValueChanged += new System.EventHandler(this.edBegin_EditValueChanged);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            this.de_End.Caption = "End";
            this.de_End.Edit = this.repositoryItemDateEdit2;
            this.de_End.Id = 6;
            this.de_End.Name = "de_End";
            this.de_End.EditValueChanged += new System.EventHandler(this.edEnd_EditValueChanged);
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            this.repositoryItemDateEdit2.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // bt_Apply
            // 
            this.bt_Apply.Caption = "Apply";
            this.bt_Apply.Id = 7;
            this.bt_Apply.Name = "bt_Apply";
            this.bt_Apply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Apply_Click);
            // 
            // UCClosedDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlCloseDay);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCClosedDays";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCloseDay)).EndInit();
            this.contextMenuStripCloseDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCloseDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCloseDay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCloseDay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ClosedDaysDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCloseDay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NewClosedDays;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteClosedDays;
        private DevExpress.XtraGrid.Columns.GridColumn gc_DayOfWeek;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar_tools;
        private DevExpress.XtraBars.BarButtonItem bi_NewClosedDays;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteClosedDays;
        private DevExpress.XtraBars.BarButtonItem bi_Import;
        private DevExpress.XtraBars.BarStaticItem lb_FilterByDate;
        private DevExpress.XtraBars.BarEditItem de_Begin;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarStaticItem lb_to;
        private DevExpress.XtraBars.BarEditItem de_End;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem bt_Apply;
        private DevExpress.XtraBars.Bar barFilter;
    }
}
