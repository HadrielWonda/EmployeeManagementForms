namespace Baumax.ClientUI.FormEntities.Region
{
    partial class UCBufferHoursView
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
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.si_FilterByYear = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemStartYear = new DevExpress.XtraBars.BarEditItem();
            this.seStartYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.si_To = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemEndYear = new DevExpress.XtraBars.BarEditItem();
            this.seEndYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bi_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewBufferHours = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditBufferHours = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControlEntities = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewBufferHours = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditBufferHours = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_BufferHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bi_DeleteBufferHours = new DevExpress.XtraBars.BarButtonItem();
            this.mi_DeleteBufferHours = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStartYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEndYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
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
            this.bar1});
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
            this.bi_NewBufferHours,
            this.bi_EditBufferHours,
            this.bi_DeleteBufferHours});
            this.barManager1.MaxItemId = 15;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.seStartYear,
            this.seEndYear});
            // 
            // bar1
            // 
            this.bar1.BarName = "Buffer-hours menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.si_FilterByYear),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemStartYear, "", false, true, true, 97),
            new DevExpress.XtraBars.LinkPersistInfo(this.si_To),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemEndYear, "", false, true, true, 112),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Apply),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewBufferHours, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditBufferHours),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteBufferHours)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Buffer-hours menu";
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
            // bi_NewBufferHours
            // 
            this.bi_NewBufferHours.Caption = "New buffer-hours";
            this.bi_NewBufferHours.Id = 6;
            this.bi_NewBufferHours.Name = "bi_NewBufferHours";
            this.bi_NewBufferHours.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewBufferHours_ItemClick);
            // 
            // bi_EditBufferHours
            // 
            this.bi_EditBufferHours.Caption = "Edit buffer-hours";
            this.bi_EditBufferHours.Id = 7;
            this.bi_EditBufferHours.Name = "bi_EditBufferHours";
            this.bi_EditBufferHours.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditBufferHours_ItemClick);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            this.gridControlEntities.Size = new System.Drawing.Size(701, 262);
            this.gridControlEntities.TabIndex = 4;
            this.gridControlEntities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControlEntities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlEntities_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewBufferHours,
            this.mi_EditBufferHours,
            this.mi_DeleteBufferHours,
            this.toolStripSeparator1,
            this.mi_ExpandedAll,
            this.mi_CollapseAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_NewBufferHours
            // 
            this.mi_NewBufferHours.Name = "mi_NewBufferHours";
            this.mi_NewBufferHours.Size = new System.Drawing.Size(175, 22);
            this.mi_NewBufferHours.Text = "New buffer-hour";
            this.mi_NewBufferHours.Click += new System.EventHandler(this.mi_NewBufferHour_Click);
            // 
            // mi_EditBufferHours
            // 
            this.mi_EditBufferHours.Name = "mi_EditBufferHours";
            this.mi_EditBufferHours.Size = new System.Drawing.Size(175, 22);
            this.mi_EditBufferHours.Text = "Edit buffer-hour";
            this.mi_EditBufferHours.Click += new System.EventHandler(this.mi_EditBufferHour_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // mi_ExpandedAll
            // 
            this.mi_ExpandedAll.Name = "mi_ExpandedAll";
            this.mi_ExpandedAll.Size = new System.Drawing.Size(175, 22);
            this.mi_ExpandedAll.Text = "Expanded All";
            this.mi_ExpandedAll.Click += new System.EventHandler(this.mi_ExpandedAll_Click);
            // 
            // mi_CollapseAll
            // 
            this.mi_CollapseAll.Name = "mi_CollapseAll";
            this.mi_CollapseAll.Size = new System.Drawing.Size(175, 22);
            this.mi_CollapseAll.Text = "Collapse All";
            this.mi_CollapseAll.Click += new System.EventHandler(this.mi_CollapseAll_Click);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_World,
            this.gridColumn_Year,
            this.gridColumn_BufferHours});
            this.gridViewEntities.GridControl = this.gridControlEntities;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Year, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            this.gridViewEntities.RowCountChanged += new System.EventHandler(this.gridViewEntities_RowCountChanged);
            this.gridViewEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewBufferHours_KeyDown);
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
            // gridColumn_BufferHours
            // 
            this.gridColumn_BufferHours.Caption = "Buffer-Hours";
            this.gridColumn_BufferHours.FieldName = "Value";
            this.gridColumn_BufferHours.Name = "gridColumn_BufferHours";
            this.gridColumn_BufferHours.OptionsColumn.AllowEdit = false;
            this.gridColumn_BufferHours.OptionsColumn.ReadOnly = true;
            this.gridColumn_BufferHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_BufferHours.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_BufferHours.OptionsFilter.AllowFilter = false;
            this.gridColumn_BufferHours.Visible = true;
            this.gridColumn_BufferHours.VisibleIndex = 2;
            // 
            // bi_DeleteBufferHours
            // 
            this.bi_DeleteBufferHours.Caption = "Delete bufer-hours";
            this.bi_DeleteBufferHours.Id = 14;
            this.bi_DeleteBufferHours.Name = "bi_DeleteBufferHours";
            this.bi_DeleteBufferHours.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteBufferHours_ItemClick);
            // 
            // mi_DeleteBufferHours
            // 
            this.mi_DeleteBufferHours.Name = "mi_DeleteBufferHours";
            this.mi_DeleteBufferHours.Size = new System.Drawing.Size(175, 22);
            this.mi_DeleteBufferHours.Text = "Delete buffer-hour";
            this.mi_DeleteBufferHours.Click += new System.EventHandler(this.mi_DeleteBufferHour_Click);
            // 
            // UCBufferHoursView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlEntities);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCBufferHoursView";
            this.Size = new System.Drawing.Size(701, 286);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStartYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEndYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntities)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem si_FilterByYear;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItemStartYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seStartYear;
        private DevExpress.XtraBars.BarStaticItem si_To;
        private DevExpress.XtraBars.BarEditItem barEditItemEndYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seEndYear;
        private DevExpress.XtraBars.BarButtonItem bi_Apply;
        private DevExpress.XtraBars.BarButtonItem bi_NewBufferHours;
        private DevExpress.XtraBars.BarButtonItem bi_EditBufferHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl gridControlEntities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_World;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Year;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_BufferHours;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewBufferHours;
        private System.Windows.Forms.ToolStripMenuItem mi_EditBufferHours;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mi_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem mi_CollapseAll;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteBufferHours;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteBufferHours;
    }
}
