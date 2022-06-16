namespace Baumax.ClientUI.FormEntities.Region
{
    partial class UCBenchmarksView
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
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.si_FilterByYear = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemStartYear = new DevExpress.XtraBars.BarEditItem();
            this.seStartYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.si_To = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemEndYear = new DevExpress.XtraBars.BarEditItem();
            this.seEndYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bi_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewBenchmark = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditBenchmark = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteBenchmark = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlEntities = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewBenchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditBenchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DeleteBenchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_BenchMark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStartYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEndYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntities)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.si_FilterByYear,
            this.barEditItemStartYear,
            this.si_To,
            this.barEditItemEndYear,
            this.bi_Apply,
            this.bi_NewBenchmark,
            this.bi_EditBenchmark,
            this.bi_DeleteBenchmark});
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seStartYear,
            this.seEndYear});
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.si_FilterByYear),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemStartYear, "", false, true, true, 97),
            new DevExpress.XtraBars.LinkPersistInfo(this.si_To),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemEndYear, "", false, true, true, 113),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Apply),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewBenchmark, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditBenchmark),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteBenchmark)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // si_FilterByYear
            // 
            this.si_FilterByYear.Caption = "Filter by year";
            this.si_FilterByYear.Id = 0;
            this.si_FilterByYear.Name = "si_FilterByYear";
            this.si_FilterByYear.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItemStartYear
            // 
            this.barEditItemStartYear.Edit = this.seStartYear;
            this.barEditItemStartYear.Id = 2;
            this.barEditItemStartYear.Name = "barEditItemStartYear";
            // 
            // seStartYear
            // 
            this.seStartYear.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.seStartYear.AutoHeight = false;
            this.seStartYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seStartYear.IsFloatValue = false;
            this.seStartYear.Mask.EditMask = "0000";
            this.seStartYear.MaxLength = 4;
            this.seStartYear.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.seStartYear.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seStartYear.Name = "seStartYear";
            // 
            // si_To
            // 
            this.si_To.Caption = "To";
            this.si_To.Id = 3;
            this.si_To.Name = "si_To";
            this.si_To.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItemEndYear
            // 
            this.barEditItemEndYear.Edit = this.seEndYear;
            this.barEditItemEndYear.Id = 4;
            this.barEditItemEndYear.Name = "barEditItemEndYear";
            // 
            // seEndYear
            // 
            this.seEndYear.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.seEndYear.AutoHeight = false;
            this.seEndYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.seEndYear.IsFloatValue = false;
            this.seEndYear.Mask.EditMask = "0000";
            this.seEndYear.MaxLength = 4;
            this.seEndYear.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.seEndYear.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seEndYear.Name = "seEndYear";
            this.seEndYear.ValueChanged += new System.EventHandler(this.seEndYear_ValueChanged);
            this.seEndYear.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.seEndYear_ButtonClick);
            // 
            // bi_Apply
            // 
            this.bi_Apply.Caption = "Load";
            this.bi_Apply.Id = 5;
            this.bi_Apply.Name = "bi_Apply";
            this.bi_Apply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_ApplyFilter_ItemClick);
            // 
            // bi_NewBenchmark
            // 
            this.bi_NewBenchmark.Caption = "New benchmark";
            this.bi_NewBenchmark.Id = 6;
            this.bi_NewBenchmark.Name = "bi_NewBenchmark";
            this.bi_NewBenchmark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewBenchmark_ItemClick);
            // 
            // bi_EditBenchmark
            // 
            this.bi_EditBenchmark.Caption = "Edit benchmark";
            this.bi_EditBenchmark.Id = 7;
            this.bi_EditBenchmark.Name = "bi_EditBenchmark";
            this.bi_EditBenchmark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditBenchmark_ItemClick);
            // 
            // bi_DeleteBenchmark
            // 
            this.bi_DeleteBenchmark.Caption = "Delete benchmark";
            this.bi_DeleteBenchmark.Id = 8;
            this.bi_DeleteBenchmark.Name = "bi_DeleteBenchmark";
            this.bi_DeleteBenchmark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteBenchmark_ItemClick);
            // 
            // gridControlEntities
            // 
            this.gridControlEntities.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEntities.EmbeddedNavigator.Name = "";
            this.gridControlEntities.Location = new System.Drawing.Point(0, 24);
            this.gridControlEntities.MainView = this.gridViewEntities;
            this.gridControlEntities.MenuManager = this.barManager1;
            this.gridControlEntities.Name = "gridControlEntities";
            this.gridControlEntities.Size = new System.Drawing.Size(702, 366);
            this.gridControlEntities.TabIndex = 5;
            this.gridControlEntities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControlEntities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlEntities_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewBenchmark,
            this.mi_EditBenchmark,
            this.mi_DeleteBenchmark,
            this.toolStripSeparator1,
            this.mi_ExpandedAll,
            this.mi_CollapseAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_NewBenchmark
            // 
            this.mi_NewBenchmark.Name = "mi_NewBenchmark";
            this.mi_NewBenchmark.Size = new System.Drawing.Size(164, 22);
            this.mi_NewBenchmark.Text = "New benchmark";
            this.mi_NewBenchmark.Click += new System.EventHandler(this.mi_NewBenchmark_Click);
            // 
            // mi_EditBenchmark
            // 
            this.mi_EditBenchmark.Name = "mi_EditBenchmark";
            this.mi_EditBenchmark.Size = new System.Drawing.Size(164, 22);
            this.mi_EditBenchmark.Text = "Edit benchmark";
            this.mi_EditBenchmark.Click += new System.EventHandler(this.mi_EditBenchmark_Click);
            // 
            // mi_DeleteBenchmark
            // 
            this.mi_DeleteBenchmark.Name = "mi_DeleteBenchmark";
            this.mi_DeleteBenchmark.Size = new System.Drawing.Size(164, 22);
            this.mi_DeleteBenchmark.Text = "Delete benchmark";
            this.mi_DeleteBenchmark.Click += new System.EventHandler(this.mi_DeleteBenchmark_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // mi_ExpandedAll
            // 
            this.mi_ExpandedAll.Name = "mi_ExpandedAll";
            this.mi_ExpandedAll.Size = new System.Drawing.Size(164, 22);
            this.mi_ExpandedAll.Text = "Expanded All";
            this.mi_ExpandedAll.Click += new System.EventHandler(this.mi_ExpandedAll_Click);
            // 
            // mi_CollapseAll
            // 
            this.mi_CollapseAll.Name = "mi_CollapseAll";
            this.mi_CollapseAll.Size = new System.Drawing.Size(164, 22);
            this.mi_CollapseAll.Text = "Collapse All";
            this.mi_CollapseAll.Click += new System.EventHandler(this.mi_CollapseAll_Click);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_World,
            this.gridColumn_Year,
            this.gridColumn_BenchMark});
            this.gridViewEntities.GridControl = this.gridControlEntities;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Year, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            this.gridViewEntities.RowCountChanged += new System.EventHandler(this.gridViewEntities_RowCountChanged);
            this.gridViewEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewEntities_KeyDown);
            // 
            // gridColumn_World
            // 
            this.gridColumn_World.Caption = "World";
            this.gridColumn_World.FieldName = "WorldName";
            this.gridColumn_World.Name = "gridColumn_World";
            this.gridColumn_World.OptionsColumn.AllowEdit = false;
            this.gridColumn_World.OptionsColumn.ReadOnly = true;
            this.gridColumn_World.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_World.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_World.OptionsFilter.AllowFilter = false;
            this.gridColumn_World.Visible = true;
            this.gridColumn_World.VisibleIndex = 0;
            // 
            // gridColumn_Year
            // 
            this.gridColumn_Year.Caption = "Year";
            this.gridColumn_Year.FieldName = "Year";
            this.gridColumn_Year.Name = "gridColumn_Year";
            this.gridColumn_Year.OptionsColumn.AllowEdit = false;
            this.gridColumn_Year.OptionsColumn.ReadOnly = true;
            this.gridColumn_Year.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Year.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_Year.OptionsFilter.AllowFilter = false;
            this.gridColumn_Year.Visible = true;
            this.gridColumn_Year.VisibleIndex = 1;
            // 
            // gridColumn_BenchMark
            // 
            this.gridColumn_BenchMark.Caption = "Benchmark";
            this.gridColumn_BenchMark.FieldName = "Value";
            this.gridColumn_BenchMark.Name = "gridColumn_BenchMark";
            this.gridColumn_BenchMark.OptionsColumn.AllowEdit = false;
            this.gridColumn_BenchMark.OptionsColumn.ReadOnly = true;
            this.gridColumn_BenchMark.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_BenchMark.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_BenchMark.OptionsFilter.AllowFilter = false;
            this.gridColumn_BenchMark.Visible = true;
            this.gridColumn_BenchMark.VisibleIndex = 2;
            // 
            // UCBenchmarksView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlEntities);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCBenchmarksView";
            this.Size = new System.Drawing.Size(702, 390);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStartYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEndYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntities)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem si_FilterByYear;
        private DevExpress.XtraBars.BarEditItem barEditItemStartYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seStartYear;
        private DevExpress.XtraBars.BarStaticItem si_To;
        private DevExpress.XtraBars.BarEditItem barEditItemEndYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seEndYear;
        private DevExpress.XtraBars.BarButtonItem bi_Apply;
        private DevExpress.XtraBars.BarButtonItem bi_NewBenchmark;
        private DevExpress.XtraBars.BarButtonItem bi_EditBenchmark;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlEntities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_World;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Year;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_BenchMark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewBenchmark;
        private System.Windows.Forms.ToolStripMenuItem mi_EditBenchmark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mi_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem mi_CollapseAll;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteBenchmark;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteBenchmark;

    }
}
