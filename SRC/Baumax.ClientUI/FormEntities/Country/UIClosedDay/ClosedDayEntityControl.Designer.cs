namespace Baumax.ClientUI.FormEntities.Country
{
    partial class ClosedDayEntityControl
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
            this.dateNavigatorClosedDay = new DevExpress.XtraScheduler.DateNavigator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip_AddEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddStripMenuItem_DeleteClosedDays = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_ClosedDaysDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_DayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barAddClear = new DevExpress.XtraBars.Bar();
            this.btn_Add = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigatorClosedDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip_AddEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigatorClosedDay
            // 
            this.dateNavigatorClosedDay.DateTime = new System.DateTime(((long)(0)));
            this.dateNavigatorClosedDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateNavigatorClosedDay.Location = new System.Drawing.Point(0, 0);
            this.dateNavigatorClosedDay.Name = "dateNavigatorClosedDay";
            this.dateNavigatorClosedDay.ShowTodayButton = false;
            this.dateNavigatorClosedDay.Size = new System.Drawing.Size(179, 141);
            this.dateNavigatorClosedDay.TabIndex = 0;
            this.dateNavigatorClosedDay.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            this.dateNavigatorClosedDay.EditDateModified += new System.EventHandler(this.dateNavigator_EditDateModified);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip_AddEntity;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(179, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(284, 141);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip_AddEntity
            // 
            this.contextMenuStrip_AddEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStripMenuItem_DeleteClosedDays});
            this.contextMenuStrip_AddEntity.Name = "contextMenuStrip_AddEntity";
            this.contextMenuStrip_AddEntity.Size = new System.Drawing.Size(170, 26);
            this.contextMenuStrip_AddEntity.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // AddStripMenuItem_DeleteClosedDays
            // 
            this.AddStripMenuItem_DeleteClosedDays.Name = "AddStripMenuItem_DeleteClosedDays";
            this.AddStripMenuItem_DeleteClosedDays.Size = new System.Drawing.Size(169, 22);
            this.AddStripMenuItem_DeleteClosedDays.Text = "delete closed day";
            this.AddStripMenuItem_DeleteClosedDays.Click += new System.EventHandler(this.MenuStripItem_DeleteClosedDays_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_ClosedDaysDate,
            this.gc_DayOfWeek});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_ClosedDaysDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gc_ClosedDaysDate
            // 
            this.gc_ClosedDaysDate.Caption = "Date";
            this.gc_ClosedDaysDate.FieldName = "WorkingDay";
            this.gc_ClosedDaysDate.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gc_ClosedDaysDate.Name = "gc_ClosedDaysDate";
            this.gc_ClosedDaysDate.OptionsColumn.AllowEdit = false;
            this.gc_ClosedDaysDate.OptionsColumn.ReadOnly = true;
            this.gc_ClosedDaysDate.SummaryItem.DisplayFormat = "{0}";
            this.gc_ClosedDaysDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_ClosedDaysDate.Visible = true;
            this.gc_ClosedDaysDate.VisibleIndex = 0;
            // 
            // gc_DayOfWeek
            // 
            this.gc_DayOfWeek.Caption = "DayMask of week";
            this.gc_DayOfWeek.FieldName = "gc_DayOfWeek";
            this.gc_DayOfWeek.Name = "gc_DayOfWeek";
            this.gc_DayOfWeek.OptionsColumn.AllowEdit = false;
            this.gc_DayOfWeek.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_DayOfWeek.Visible = true;
            this.gc_DayOfWeek.VisibleIndex = 1;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barAddClear});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Add,
            this.btn_Delete});
            this.barManager1.MaxItemId = 12;
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
            this.btn_Add.Caption = "Add Closed DayMask";
            this.btn_Add.Glyph = global::Baumax.ClientUI.Properties.Resources.add;
            this.btn_Add.Id = 0;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddClosedDays_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_Delete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btn_Delete.Caption = "Delete Closed DayMask";
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Glyph = global::Baumax.ClientUI.Properties.Resources.del;
            this.btn_Delete.Id = 11;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_Click);
            // 
            // ClosedDayEntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dateNavigatorClosedDay);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ClosedDayEntityControl";
            this.Size = new System.Drawing.Size(463, 171);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigatorClosedDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip_AddEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigatorClosedDay;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gc_ClosedDaysDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_DayOfWeek;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_AddEntity;
        private System.Windows.Forms.ToolStripMenuItem AddStripMenuItem_DeleteClosedDays;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_Add;
        private DevExpress.XtraBars.Bar barAddClear;
        private DevExpress.XtraBars.BarButtonItem btn_Delete;
    }
}
