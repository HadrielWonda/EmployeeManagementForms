namespace Baumax.ClientUI.FormEntities.Region
{
    partial class UCTrendCorrectionsView
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
            this.bi_FilterBydate = new DevExpress.XtraBars.BarStaticItem();
            this.biStartDate = new DevExpress.XtraBars.BarEditItem();
            this.deStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bi_To = new DevExpress.XtraBars.BarStaticItem();
            this.biEndDate = new DevExpress.XtraBars.BarEditItem();
            this.deEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bi_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewTrendCorrection = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditTrendCorrection = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteTrendCorrection = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewTrendCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditTrendCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DeleteTrendCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_TrendCorrection = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.VistaTimeProperties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_FilterBydate,
            this.biStartDate,
            this.bi_To,
            this.biEndDate,
            this.bi_Apply,
            this.bi_NewTrendCorrection,
            this.bi_EditTrendCorrection,
            this.bi_DeleteTrendCorrection});
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.deStartDate,
            this.deEndDate});
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_FilterBydate),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.biStartDate, "", false, true, true, 115),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_To),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.biEndDate, "", false, true, true, 115),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Apply),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewTrendCorrection, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditTrendCorrection),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteTrendCorrection)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // bi_FilterBydate
            // 
            this.bi_FilterBydate.Caption = "Filter by date";
            this.bi_FilterBydate.Id = 0;
            this.bi_FilterBydate.Name = "bi_FilterBydate";
            this.bi_FilterBydate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // biStartDate
            // 
            this.biStartDate.Edit = this.deStartDate;
            this.biStartDate.Id = 1;
            this.biStartDate.Name = "biStartDate";
            // 
            // deStartDate
            // 
            this.deStartDate.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deStartDate.AutoHeight = false;
            this.deStartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // bi_To
            // 
            this.bi_To.Caption = "To";
            this.bi_To.Id = 2;
            this.bi_To.Name = "bi_To";
            this.bi_To.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // biEndDate
            // 
            this.biEndDate.Edit = this.deEndDate;
            this.biEndDate.Id = 3;
            this.biEndDate.Name = "biEndDate";
            this.biEndDate.EditValueChanged += new System.EventHandler(this.biEndDate_EditValueChanged);
            // 
            // deEndDate
            // 
            this.deEndDate.AutoHeight = false;
            this.deEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deEndDate_ButtonXClick);
            // 
            // bi_Apply
            // 
            this.bi_Apply.Caption = "Load";
            this.bi_Apply.Id = 4;
            this.bi_Apply.Name = "bi_Apply";
            this.bi_Apply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_Apply_ItemClick);
            // 
            // bi_NewTrendCorrection
            // 
            this.bi_NewTrendCorrection.Caption = "New trend correction";
            this.bi_NewTrendCorrection.Id = 5;
            this.bi_NewTrendCorrection.Name = "bi_NewTrendCorrection";
            this.bi_NewTrendCorrection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewTrendCorrection_ItemClick);
            // 
            // bi_EditTrendCorrection
            // 
            this.bi_EditTrendCorrection.Caption = "Edit trend correction";
            this.bi_EditTrendCorrection.Id = 6;
            this.bi_EditTrendCorrection.Name = "bi_EditTrendCorrection";
            this.bi_EditTrendCorrection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditTrendCorrection_ItemClick);
            // 
            // bi_DeleteTrendCorrection
            // 
            this.bi_DeleteTrendCorrection.Caption = "Delete trend correction";
            this.bi_DeleteTrendCorrection.Id = 7;
            this.bi_DeleteTrendCorrection.Name = "bi_DeleteTrendCorrection";
            this.bi_DeleteTrendCorrection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteTrendCorrection_ItemClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewTrendCorrection,
            this.mi_EditTrendCorrection,
            this.mi_DeleteTrendCorrection,
            this.toolStripSeparator1,
            this.mi_ExpandedAll,
            this.mi_CollapseAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_NewTrendCorrection
            // 
            this.mi_NewTrendCorrection.Name = "mi_NewTrendCorrection";
            this.mi_NewTrendCorrection.Size = new System.Drawing.Size(196, 22);
            this.mi_NewTrendCorrection.Text = "New trend correction";
            this.mi_NewTrendCorrection.Click += new System.EventHandler(this.mi_NewTrendCorrection_Click);
            // 
            // mi_EditTrendCorrection
            // 
            this.mi_EditTrendCorrection.Name = "mi_EditTrendCorrection";
            this.mi_EditTrendCorrection.Size = new System.Drawing.Size(196, 22);
            this.mi_EditTrendCorrection.Text = "Edit trend correction";
            this.mi_EditTrendCorrection.Click += new System.EventHandler(this.mi_EditTrendCorrection_Click);
            // 
            // mi_DeleteTrendCorrection
            // 
            this.mi_DeleteTrendCorrection.Name = "mi_DeleteTrendCorrection";
            this.mi_DeleteTrendCorrection.Size = new System.Drawing.Size(196, 22);
            this.mi_DeleteTrendCorrection.Text = "Delete trend correction";
            this.mi_DeleteTrendCorrection.Click += new System.EventHandler(this.mi_DeleteTrendCorrection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mi_ExpandedAll
            // 
            this.mi_ExpandedAll.Name = "mi_ExpandedAll";
            this.mi_ExpandedAll.Size = new System.Drawing.Size(196, 22);
            this.mi_ExpandedAll.Text = "Expanded All";
            this.mi_ExpandedAll.Click += new System.EventHandler(this.mi_ExpandedAll_Click);
            // 
            // mi_CollapseAll
            // 
            this.mi_CollapseAll.Name = "mi_CollapseAll";
            this.mi_CollapseAll.Size = new System.Drawing.Size(196, 22);
            this.mi_CollapseAll.Text = "Collapse All";
            this.mi_CollapseAll.Click += new System.EventHandler(this.mi_CollpaseAll_Click);
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 24);
            this.gridControl.MainView = this.gridViewEntities;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(805, 661);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Name,
            this.gridColumn_World,
            this.gridColumn_BeginDate,
            this.gridColumn_EndDate,
            this.gridColumn_TrendCorrection});
            this.gridViewEntities.GridControl = this.gridControl;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsBehavior.Editable = false;
            this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
            this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntity_FocusedRowChanged);
            this.gridViewEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewTrend_KeyDown);
            // 
            // gridColumn_Name
            // 
            this.gridColumn_Name.Caption = "Name";
            this.gridColumn_Name.FieldName = "Name";
            this.gridColumn_Name.Name = "gridColumn_Name";
            this.gridColumn_Name.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_Name.OptionsFilter.AllowFilter = false;
            this.gridColumn_Name.Visible = true;
            this.gridColumn_Name.VisibleIndex = 1;
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
            // gridColumn_BeginDate
            // 
            this.gridColumn_BeginDate.Caption = "Start";
            this.gridColumn_BeginDate.DisplayFormat.FormatString = "d";
            this.gridColumn_BeginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn_BeginDate.FieldName = "BeginTime";
            this.gridColumn_BeginDate.Name = "gridColumn_BeginDate";
            this.gridColumn_BeginDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_BeginDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_BeginDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_BeginDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_BeginDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_BeginDate.Visible = true;
            this.gridColumn_BeginDate.VisibleIndex = 2;
            // 
            // gridColumn_EndDate
            // 
            this.gridColumn_EndDate.Caption = "End";
            this.gridColumn_EndDate.DisplayFormat.FormatString = "d";
            this.gridColumn_EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn_EndDate.FieldName = "EndTime";
            this.gridColumn_EndDate.Name = "gridColumn_EndDate";
            this.gridColumn_EndDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_EndDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_EndDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_EndDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_EndDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_EndDate.Visible = true;
            this.gridColumn_EndDate.VisibleIndex = 3;
            // 
            // gridColumn_TrendCorrection
            // 
            this.gridColumn_TrendCorrection.Caption = "Trend correction";
            this.gridColumn_TrendCorrection.FieldName = "Value";
            this.gridColumn_TrendCorrection.Name = "gridColumn_TrendCorrection";
            this.gridColumn_TrendCorrection.OptionsColumn.AllowEdit = false;
            this.gridColumn_TrendCorrection.OptionsColumn.ReadOnly = true;
            this.gridColumn_TrendCorrection.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_TrendCorrection.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_TrendCorrection.OptionsFilter.AllowFilter = false;
            this.gridColumn_TrendCorrection.Visible = true;
            this.gridColumn_TrendCorrection.VisibleIndex = 4;
            // 
            // UCTrendCorrectionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCTrendCorrectionsView";
            this.Size = new System.Drawing.Size(805, 685);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem bi_FilterBydate;
        private DevExpress.XtraBars.BarEditItem biStartDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit deStartDate;
        private DevExpress.XtraBars.BarStaticItem bi_To;
        private DevExpress.XtraBars.BarEditItem biEndDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit deEndDate;
        private DevExpress.XtraBars.BarButtonItem bi_Apply;
        private DevExpress.XtraBars.BarButtonItem bi_NewTrendCorrection;
        private DevExpress.XtraBars.BarButtonItem bi_EditTrendCorrection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewTrendCorrection;
        private System.Windows.Forms.ToolStripMenuItem mi_EditTrendCorrection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mi_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem mi_CollapseAll;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_World;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_EndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_TrendCorrection;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteTrendCorrection;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteTrendCorrection;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Name;
    }
}
