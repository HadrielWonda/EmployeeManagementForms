namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCLunchBrakes
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
            this.bartools = new DevExpress.XtraBars.Bar();
            this.bi_NewLunch = new DevExpress.XtraBars.BarButtonItem();
            this.bi_editLunch = new DevExpress.XtraBars.BarButtonItem();
            this.bi_deleteLunch = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlLunch = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem_NewLunch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editLunch = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_deleteLunch = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewLunch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_LunchModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_beginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_condition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_lunchHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_typeLunchModel = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLunch)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLunch)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bartools});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewLunch,
            this.bi_editLunch,
            this.bi_deleteLunch});
            this.barManager1.MaxItemId = 3;
            // 
            // bartools
            // 
            this.bartools.BarName = "Tools";
            this.bartools.DockCol = 0;
            this.bartools.DockRow = 0;
            this.bartools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bartools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewLunch),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_editLunch),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_deleteLunch)});
            this.bartools.OptionsBar.AllowQuickCustomization = false;
            this.bartools.OptionsBar.DisableClose = true;
            this.bartools.OptionsBar.DisableCustomization = true;
            this.bartools.OptionsBar.DrawDragBorder = false;
            this.bartools.OptionsBar.UseWholeRow = true;
            this.bartools.Text = "Tools";
            // 
            // bi_NewLunch
            // 
            this.bi_NewLunch.Caption = "New Lunch Model";
            this.bi_NewLunch.Glyph = global::Baumax.ClientUI.Properties.Resources.coffeebean_add;
            this.bi_NewLunch.Id = 0;
            this.bi_NewLunch.Name = "bi_NewLunch";
            this.bi_NewLunch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewLunch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewLunch_ItemClick);
            // 
            // bi_editLunch
            // 
            this.bi_editLunch.Caption = "Edit Lunch Model";
            this.bi_editLunch.Glyph = global::Baumax.ClientUI.Properties.Resources.coffeebean_enterprise_view;
            this.bi_editLunch.Id = 1;
            this.bi_editLunch.Name = "bi_editLunch";
            this.bi_editLunch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_editLunch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_editLunch_ItemClick);
            // 
            // bi_deleteLunch
            // 
            this.bi_deleteLunch.Caption = "Delete Lunch Model";
            this.bi_deleteLunch.Glyph = global::Baumax.ClientUI.Properties.Resources.coffeebean_delete;
            this.bi_deleteLunch.Id = 2;
            this.bi_deleteLunch.Name = "bi_deleteLunch";
            this.bi_deleteLunch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_deleteLunch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_deletetLunch_ItemClick);
            // 
            // gridControlLunch
            // 
            this.gridControlLunch.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlLunch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLunch.EmbeddedNavigator.Name = "";
            this.gridControlLunch.Location = new System.Drawing.Point(0, 34);
            this.gridControlLunch.MainView = this.gridViewLunch;
            this.gridControlLunch.Name = "gridControlLunch";
            this.gridControlLunch.Size = new System.Drawing.Size(478, 255);
            this.gridControlLunch.TabIndex = 4;
            this.gridControlLunch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLunch});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem_NewLunch,
            this.toolStripMenuItem_editLunch,
            this.ToolStripMenuItem_deleteLunch});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // newToolStripMenuItem_NewLunch
            // 
            this.newToolStripMenuItem_NewLunch.Name = "newToolStripMenuItem_NewLunch";
            this.newToolStripMenuItem_NewLunch.Size = new System.Drawing.Size(108, 22);
            this.newToolStripMenuItem_NewLunch.Text = "New";
            this.newToolStripMenuItem_NewLunch.Click += new System.EventHandler(this.newToolStripMenuItem_NewLunch_Click);
            // 
            // toolStripMenuItem_editLunch
            // 
            this.toolStripMenuItem_editLunch.Name = "toolStripMenuItem_editLunch";
            this.toolStripMenuItem_editLunch.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem_editLunch.Text = "Edit";
            this.toolStripMenuItem_editLunch.Click += new System.EventHandler(this.toolStripMenuItem_editLunch_Click);
            // 
            // ToolStripMenuItem_deleteLunch
            // 
            this.ToolStripMenuItem_deleteLunch.Name = "ToolStripMenuItem_deleteLunch";
            this.ToolStripMenuItem_deleteLunch.Size = new System.Drawing.Size(108, 22);
            this.ToolStripMenuItem_deleteLunch.Text = "Delete";
            this.ToolStripMenuItem_deleteLunch.Click += new System.EventHandler(this.ToolStripMenuItem_deleteLunch_Click);
            // 
            // gridViewLunch
            // 
            this.gridViewLunch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_LunchModelName,
            this.gc_beginDate,
            this.gc_EndDate,
            this.gc_condition,
            this.gc_lunchHour,
            this.gc_typeLunchModel});
            this.gridViewLunch.GridControl = this.gridControlLunch;
            this.gridViewLunch.Name = "gridViewLunch";
            this.gridViewLunch.OptionsCustomization.AllowFilter = false;
            this.gridViewLunch.OptionsCustomization.AllowGroup = false;
            this.gridViewLunch.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewLunch.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewLunch.OptionsFilter.AllowFilterEditor = false;
            this.gridViewLunch.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewLunch.OptionsMenu.EnableColumnMenu = false;
            this.gridViewLunch.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewLunch.OptionsView.ShowGroupPanel = false;
            this.gridViewLunch.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewLunch_CustomUnboundColumnData);
            this.gridViewLunch.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridViewLunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gc_LunchModelName
            // 
            this.gc_LunchModelName.Caption = "Lunch-brake model name";
            this.gc_LunchModelName.FieldName = "Name";
            this.gc_LunchModelName.Name = "gc_LunchModelName";
            this.gc_LunchModelName.OptionsColumn.AllowEdit = false;
            this.gc_LunchModelName.OptionsColumn.AllowFocus = false;
            this.gc_LunchModelName.OptionsColumn.AllowMove = false;
            this.gc_LunchModelName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LunchModelName.OptionsFilter.AllowAutoFilter = false;
            this.gc_LunchModelName.OptionsFilter.AllowFilter = false;
            this.gc_LunchModelName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_LunchModelName.Visible = true;
            this.gc_LunchModelName.VisibleIndex = 0;
            // 
            // gc_beginDate
            // 
            this.gc_beginDate.Caption = "Begin Data";
            this.gc_beginDate.DisplayFormat.FormatString = "d";
            this.gc_beginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_beginDate.FieldName = "BeginTime";
            this.gc_beginDate.Name = "gc_beginDate";
            this.gc_beginDate.OptionsColumn.AllowEdit = false;
            this.gc_beginDate.OptionsColumn.AllowFocus = false;
            this.gc_beginDate.OptionsColumn.AllowMove = false;
            this.gc_beginDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_beginDate.OptionsFilter.AllowAutoFilter = false;
            this.gc_beginDate.OptionsFilter.AllowFilter = false;
            this.gc_beginDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_beginDate.Visible = true;
            this.gc_beginDate.VisibleIndex = 1;
            // 
            // gc_EndDate
            // 
            this.gc_EndDate.Caption = "End Data";
            this.gc_EndDate.DisplayFormat.FormatString = "d";
            this.gc_EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_EndDate.FieldName = "EndTime";
            this.gc_EndDate.Name = "gc_EndDate";
            this.gc_EndDate.OptionsColumn.AllowEdit = false;
            this.gc_EndDate.OptionsColumn.AllowFocus = false;
            this.gc_EndDate.OptionsColumn.AllowMove = false;
            this.gc_EndDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_EndDate.OptionsFilter.AllowAutoFilter = false;
            this.gc_EndDate.OptionsFilter.AllowFilter = false;
            this.gc_EndDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_EndDate.Visible = true;
            this.gc_EndDate.VisibleIndex = 2;
            // 
            // gc_condition
            // 
            this.gc_condition.Caption = "Condition";
            this.gc_condition.FieldName = "AddValue";
            this.gc_condition.Name = "gc_condition";
            this.gc_condition.OptionsColumn.AllowEdit = false;
            this.gc_condition.OptionsColumn.AllowFocus = false;
            this.gc_condition.OptionsColumn.AllowMove = false;
            this.gc_condition.OptionsColumn.ReadOnly = true;
            this.gc_condition.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_condition.OptionsFilter.AllowAutoFilter = false;
            this.gc_condition.OptionsFilter.AllowFilter = false;
            this.gc_condition.Visible = true;
            this.gc_condition.VisibleIndex = 3;
            // 
            // gc_lunchHour
            // 
            this.gc_lunchHour.Caption = "Hours";
            this.gc_lunchHour.FieldName = "MultiplyValue";
            this.gc_lunchHour.Name = "gc_lunchHour";
            this.gc_lunchHour.OptionsColumn.AllowEdit = false;
            this.gc_lunchHour.OptionsColumn.AllowFocus = false;
            this.gc_lunchHour.OptionsColumn.AllowMove = false;
            this.gc_lunchHour.OptionsColumn.ReadOnly = true;
            this.gc_lunchHour.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_lunchHour.OptionsFilter.AllowAutoFilter = false;
            this.gc_lunchHour.OptionsFilter.AllowFilter = false;
            this.gc_lunchHour.Visible = true;
            this.gc_lunchHour.VisibleIndex = 4;
            // 
            // gc_typeLunchModel
            // 
            this.gc_typeLunchModel.Caption = "Type";
            this.gc_typeLunchModel.FieldName = "gc_typeLunchModel";
            this.gc_typeLunchModel.Name = "gc_typeLunchModel";
            this.gc_typeLunchModel.OptionsColumn.AllowEdit = false;
            this.gc_typeLunchModel.OptionsColumn.AllowFocus = false;
            this.gc_typeLunchModel.OptionsColumn.AllowMove = false;
            this.gc_typeLunchModel.OptionsColumn.ReadOnly = true;
            this.gc_typeLunchModel.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_typeLunchModel.OptionsFilter.AllowAutoFilter = false;
            this.gc_typeLunchModel.OptionsFilter.AllowFilter = false;
            this.gc_typeLunchModel.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_typeLunchModel.Visible = true;
            this.gc_typeLunchModel.VisibleIndex = 5;
            // 
            // UCLunchBrakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLunch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLunchBrakes";
            this.Size = new System.Drawing.Size(478, 289);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLunch)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLunch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bartools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlLunch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLunch;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LunchModelName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_beginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraBars.BarButtonItem bi_NewLunch;
        private DevExpress.XtraBars.BarButtonItem bi_editLunch;
        private DevExpress.XtraBars.BarButtonItem bi_deleteLunch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem_NewLunch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editLunch;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_deleteLunch;
        private DevExpress.XtraGrid.Columns.GridColumn gc_condition;
        private DevExpress.XtraGrid.Columns.GridColumn gc_lunchHour;
        private DevExpress.XtraGrid.Columns.GridColumn gc_typeLunchModel;
    }
}
