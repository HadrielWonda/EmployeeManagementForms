namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FeastEntityControl
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
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripAddEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_DeleteFeast = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_FeastDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_DayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager_AddClear = new DevExpress.XtraBars.BarManager(this.components);
            this.barAddClear = new DevExpress.XtraBars.Bar();
            this.btn_Add = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStripAddEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_AddClear)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2007, 6, 20, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.ShowTodayButton = false;
            this.dateNavigator1.Size = new System.Drawing.Size(179, 147);
            this.dateNavigator1.TabIndex = 0;
            this.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator_EditDateModified);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStripAddEntity;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(179, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(288, 147);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStripAddEntity
            // 
            this.contextMenuStripAddEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_DeleteFeast});
            this.contextMenuStripAddEntity.Name = "contextMenuStripAddEntity";
            this.contextMenuStripAddEntity.Size = new System.Drawing.Size(138, 26);
            this.contextMenuStripAddEntity.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // ToolStripMenuItem_DeleteFeast
            // 
            this.ToolStripMenuItem_DeleteFeast.Name = "ToolStripMenuItem_DeleteFeast";
            this.ToolStripMenuItem_DeleteFeast.Size = new System.Drawing.Size(137, 22);
            this.ToolStripMenuItem_DeleteFeast.Text = "Delete Feast";
            this.ToolStripMenuItem_DeleteFeast.Click += new System.EventHandler(this.deleteFeastContextMenuStrip_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_FeastDate,
            this.gc_DayOfWeek});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_FeastDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gridColumn_FeastDate
            // 
            this.gridColumn_FeastDate.Caption = "Date";
            this.gridColumn_FeastDate.FieldName = "FeastDate";
            this.gridColumn_FeastDate.Name = "gridColumn_FeastDate";
            this.gridColumn_FeastDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_FeastDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_FeastDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_FeastDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_FeastDate.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn_FeastDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gridColumn_FeastDate.Visible = true;
            this.gridColumn_FeastDate.VisibleIndex = 0;
            // 
            // gc_DayOfWeek
            // 
            this.gc_DayOfWeek.Caption = "DayMask of week";
            this.gc_DayOfWeek.FieldName = "gc_DayOfWeek";
            this.gc_DayOfWeek.Name = "gc_DayOfWeek";
            this.gc_DayOfWeek.OptionsColumn.AllowEdit = false;
            this.gc_DayOfWeek.OptionsColumn.ReadOnly = true;
            this.gc_DayOfWeek.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_DayOfWeek.OptionsFilter.AllowFilter = false;
            this.gc_DayOfWeek.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_DayOfWeek.Visible = true;
            this.gc_DayOfWeek.VisibleIndex = 1;
            // 
            // barManager_AddClear
            // 
            this.barManager_AddClear.AllowCustomization = false;
            this.barManager_AddClear.AllowMoveBarOnToolbar = false;
            this.barManager_AddClear.AllowQuickCustomization = false;
            this.barManager_AddClear.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barAddClear});
            this.barManager_AddClear.DockControls.Add(this.barDockControlTop);
            this.barManager_AddClear.DockControls.Add(this.barDockControlBottom);
            this.barManager_AddClear.DockControls.Add(this.barDockControlLeft);
            this.barManager_AddClear.DockControls.Add(this.barDockControlRight);
            this.barManager_AddClear.Form = this;
            this.barManager_AddClear.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Add,
            this.btn_Delete});
            this.barManager_AddClear.MaxItemId = 12;
            // 
            // barAddClear
            // 
            this.barAddClear.BarName = "Custom 3";
            this.barAddClear.DockCol = 0;
            this.barAddClear.DockRow = 0;
            this.barAddClear.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barAddClear.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Delete)});
            this.barAddClear.OptionsBar.AllowQuickCustomization = false;
            this.barAddClear.OptionsBar.DisableClose = true;
            this.barAddClear.OptionsBar.DisableCustomization = true;
            this.barAddClear.OptionsBar.DrawDragBorder = false;
            this.barAddClear.OptionsBar.UseWholeRow = true;
            this.barAddClear.Text = "Custom 3";
            // 
            // btn_Add
            // 
            this.btn_Add.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.btn_Add.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btn_Add.Caption = "Add";
            this.btn_Add.Glyph = global::Baumax.ClientUI.Properties.Resources.add;
            this.btn_Add.Id = 0;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btAdd_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_Delete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btn_Delete.Caption = "Delete";
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Glyph = global::Baumax.ClientUI.Properties.Resources.del;
            this.btn_Delete.Id = 10;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DeleteFeast_Click);
            // 
            // FeastEntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FeastEntityControl";
            this.Size = new System.Drawing.Size(467, 177);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStripAddEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_AddClear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_FeastDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_DayOfWeek;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAddEntity;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DeleteFeast;
        private DevExpress.XtraBars.BarManager barManager_AddClear;
        private DevExpress.XtraBars.BarButtonItem btn_Add;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar barAddClear;
        private DevExpress.XtraBars.BarButtonItem btn_Delete;


    }
}
