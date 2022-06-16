namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FeastListControl
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlFeast = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NewFeast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteFeast = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewFeast = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_FeastDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_DayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManagerFeast = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_tools = new DevExpress.XtraBars.Bar();
            this.bi_Import = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewFeast = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteFeast = new DevExpress.XtraBars.BarButtonItem();
            this.barFilter = new DevExpress.XtraBars.Bar();
            this.bs_FilterByDate = new DevExpress.XtraBars.BarStaticItem();
            this.deBegin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.li_to = new DevExpress.XtraBars.BarStaticItem();
            this.deEnd = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btn_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bi_FilterByDate = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFeast)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFeast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerFeast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlFeast);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 59);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(439, 284);
            this.panelControl2.TabIndex = 1;
            // 
            // gridControlFeast
            // 
            this.gridControlFeast.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlFeast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFeast.EmbeddedNavigator.Name = "";
            this.gridControlFeast.Location = new System.Drawing.Point(2, 2);
            this.gridControlFeast.MainView = this.gridViewFeast;
            this.gridControlFeast.Name = "gridControlFeast";
            this.gridControlFeast.Size = new System.Drawing.Size(435, 280);
            this.gridControlFeast.TabIndex = 0;
            this.gridControlFeast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFeast});
            this.gridControlFeast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlFeast_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NewFeast,
            this.toolStripMenuItem_DeleteFeast});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem_NewFeast
            // 
            this.toolStripMenuItem_NewFeast.Name = "toolStripMenuItem_NewFeast";
            this.toolStripMenuItem_NewFeast.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem_NewFeast.Text = "Define new feasts";
            this.toolStripMenuItem_NewFeast.Click += new System.EventHandler(this.defineNewFeastsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_DeleteFeast
            // 
            this.toolStripMenuItem_DeleteFeast.Name = "toolStripMenuItem_DeleteFeast";
            this.toolStripMenuItem_DeleteFeast.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem_DeleteFeast.Text = "Delete feast";
            this.toolStripMenuItem_DeleteFeast.Click += new System.EventHandler(this.deleteFeastToolStripMenuItem_Click);
            // 
            // gridViewFeast
            // 
            this.gridViewFeast.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.gridViewFeast.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewFeast.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.gridViewFeast.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewFeast.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.gridViewFeast.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_FeastDate,
            this.gc_DayOfWeek});
            this.gridViewFeast.GridControl = this.gridControlFeast;
            this.gridViewFeast.Name = "gridViewFeast";
            this.gridViewFeast.OptionsBehavior.Editable = false;
            this.gridViewFeast.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewFeast.OptionsFilter.AllowFilterEditor = false;
            this.gridViewFeast.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewFeast.OptionsMenu.EnableColumnMenu = false;
            this.gridViewFeast.OptionsMenu.EnableFooterMenu = false;
            this.gridViewFeast.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewFeast.OptionsSelection.MultiSelect = true;
            this.gridViewFeast.OptionsView.ShowFooter = true;
            this.gridViewFeast.OptionsView.ShowGroupPanel = false;
            this.gridViewFeast.OptionsView.ShowPreviewLines = false;
            this.gridViewFeast.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_FeastDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewFeast.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewFeast_CustomUnboundColumnData);
            this.gridViewFeast.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewfeast_FocusedRowChanged);
            // 
            // gridColumn_FeastDate
            // 
            this.gridColumn_FeastDate.Caption = "FeastDate";
            this.gridColumn_FeastDate.FieldName = "FeastDate";
            this.gridColumn_FeastDate.Name = "gridColumn_FeastDate";
            this.gridColumn_FeastDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_FeastDate.OptionsColumn.AllowMove = false;
            this.gridColumn_FeastDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_FeastDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_FeastDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_FeastDate.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn_FeastDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn_FeastDate.Visible = true;
            this.gridColumn_FeastDate.VisibleIndex = 0;
            this.gridColumn_FeastDate.Width = 280;
            // 
            // gc_DayOfWeek
            // 
            this.gc_DayOfWeek.Caption = "DayOfWeek";
            this.gc_DayOfWeek.FieldName = "gc_DayOfWeek";
            this.gc_DayOfWeek.Name = "gc_DayOfWeek";
            this.gc_DayOfWeek.OptionsColumn.AllowEdit = false;
            this.gc_DayOfWeek.OptionsColumn.AllowMove = false;
            this.gc_DayOfWeek.OptionsColumn.ReadOnly = true;
            this.gc_DayOfWeek.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_DayOfWeek.OptionsFilter.AllowFilter = false;
            this.gc_DayOfWeek.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_DayOfWeek.Visible = true;
            this.gc_DayOfWeek.VisibleIndex = 1;
            this.gc_DayOfWeek.Width = 337;
            // 
            // barManagerFeast
            // 
            this.barManagerFeast.AllowCustomization = false;
            this.barManagerFeast.AllowMoveBarOnToolbar = false;
            this.barManagerFeast.AllowQuickCustomization = false;
            this.barManagerFeast.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_tools,
            this.barFilter});
            this.barManagerFeast.CloseButtonAffectAllTabs = false;
            this.barManagerFeast.DockControls.Add(this.barDockControlTop);
            this.barManagerFeast.DockControls.Add(this.barDockControlBottom);
            this.barManagerFeast.DockControls.Add(this.barDockControlLeft);
            this.barManagerFeast.DockControls.Add(this.barDockControlRight);
            this.barManagerFeast.Form = this;
            this.barManagerFeast.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewFeast,
            this.bi_Import,
            this.bi_DeleteFeast,
            this.bi_FilterByDate,
            this.bs_FilterByDate,
            this.btn_Apply,
            this.deBegin,
            this.deEnd,
            this.barEditItem1,
            this.li_to});
            this.barManagerFeast.MaxItemId = 13;
            this.barManagerFeast.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemDateEdit3});
            // 
            // bar_tools
            // 
            this.bar_tools.BarName = "Tools";
            this.bar_tools.DockCol = 0;
            this.bar_tools.DockRow = 0;
            this.bar_tools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_tools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Import),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewFeast),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteFeast)});
            this.bar_tools.OptionsBar.AllowQuickCustomization = false;
            this.bar_tools.OptionsBar.DisableClose = true;
            this.bar_tools.OptionsBar.DisableCustomization = true;
            this.bar_tools.OptionsBar.DrawDragBorder = false;
            this.bar_tools.OptionsBar.RotateWhenVertical = false;
            this.bar_tools.OptionsBar.UseWholeRow = true;
            this.bar_tools.Text = "Tools";
            // 
            // bi_Import
            // 
            this.bi_Import.Caption = "Import";
            this.bi_Import.Glyph = global::Baumax.ClientUI.Properties.Resources.data_replace;
            this.bi_Import.Id = 1;
            this.bi_Import.Name = "bi_Import";
            this.bi_Import.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_Import.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_Import_ItemClick);
            // 
            // bi_NewFeast
            // 
            this.bi_NewFeast.Caption = "New Feasts";
            this.bi_NewFeast.Glyph = global::Baumax.ClientUI.Properties.Resources.document_add;
            this.bi_NewFeast.Id = 0;
            this.bi_NewFeast.Name = "bi_NewFeast";
            this.bi_NewFeast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewFeast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewFeast_ItemClick);
            // 
            // bi_DeleteFeast
            // 
            this.bi_DeleteFeast.Caption = "Delete Feast";
            this.bi_DeleteFeast.Glyph = global::Baumax.ClientUI.Properties.Resources.document_delete;
            this.bi_DeleteFeast.Id = 2;
            this.bi_DeleteFeast.Name = "bi_DeleteFeast";
            this.bi_DeleteFeast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteFeast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteFeast_ItemClick);
            // 
            // barFilter
            // 
            this.barFilter.BarName = "Custom 3";
            this.barFilter.DockCol = 0;
            this.barFilter.DockRow = 1;
            this.barFilter.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barFilter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bs_FilterByDate),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.deBegin, "", false, true, true, 82),
            new DevExpress.XtraBars.LinkPersistInfo(this.li_to),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.deEnd, "", false, true, true, 82),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Apply)});
            this.barFilter.OptionsBar.AllowQuickCustomization = false;
            this.barFilter.OptionsBar.DisableClose = true;
            this.barFilter.OptionsBar.DisableCustomization = true;
            this.barFilter.OptionsBar.DrawDragBorder = false;
            this.barFilter.OptionsBar.UseWholeRow = true;
            this.barFilter.Text = "Custom 3";
            // 
            // bs_FilterByDate
            // 
            this.bs_FilterByDate.Caption = "Filter By Date";
            this.bs_FilterByDate.Id = 4;
            this.bs_FilterByDate.Name = "bs_FilterByDate";
            this.bs_FilterByDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // deBegin
            // 
            this.deBegin.Caption = "barEditItem1";
            this.deBegin.Edit = this.repositoryItemDateEdit1;
            this.deBegin.Id = 8;
            this.deBegin.Name = "deBegin";
            this.deBegin.EditValueChanged += new System.EventHandler(this.deBegin_EditValueChanged);
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
            // li_to
            // 
            this.li_to.Caption = "to";
            this.li_to.Id = 12;
            this.li_to.Name = "li_to";
            this.li_to.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // deEnd
            // 
            this.deEnd.Caption = "barEditItem2";
            this.deEnd.Edit = this.repositoryItemDateEdit2;
            this.deEnd.Id = 9;
            this.deEnd.Name = "deEnd";
            this.deEnd.EditValueChanged += new System.EventHandler(this.deEnd_EditValueChanged);
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
            // btn_Apply
            // 
            this.btn_Apply.Caption = "Apply";
            this.btn_Apply.Id = 7;
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_Click);
            // 
            // bi_FilterByDate
            // 
            this.bi_FilterByDate.Caption = "Filter By Date";
            this.bi_FilterByDate.Id = 3;
            this.bi_FilterByDate.Name = "bi_FilterByDate";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemDateEdit3;
            this.barEditItem1.Id = 10;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            this.repositoryItemDateEdit3.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // FeastListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FeastListControl";
            this.Size = new System.Drawing.Size(439, 343);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFeast)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFeast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerFeast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControlFeast;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFeast;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_FeastDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NewFeast;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteFeast;
        private DevExpress.XtraGrid.Columns.GridColumn gc_DayOfWeek;
        private DevExpress.XtraBars.BarManager barManagerFeast;
        private DevExpress.XtraBars.Bar bar_tools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bi_Import;
        private DevExpress.XtraBars.BarButtonItem bi_NewFeast;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteFeast;
        private DevExpress.XtraBars.BarButtonItem bi_FilterByDate;
        private DevExpress.XtraBars.BarStaticItem bs_FilterByDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraBars.BarButtonItem btn_Apply;
        private DevExpress.XtraBars.BarEditItem deBegin;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem deEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraBars.BarStaticItem li_to;
        private DevExpress.XtraBars.Bar barFilter;
    }
}
