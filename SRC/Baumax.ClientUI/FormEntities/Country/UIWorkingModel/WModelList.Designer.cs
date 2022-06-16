namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    partial class WModelList
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NewWorkingModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditWorkingModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteWorkingModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RefreshWorkingModel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_WorkingModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Enddate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModelMultiplyFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModelSubAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModelMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_ApplyAdditionalCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_UseInRecording = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager_tools = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bi_NewWorkingModel = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditWorkingModel = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteWorkingModel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_tools)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(638, 428);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NewWorkingModel,
            this.toolStripMenuItem_EditWorkingModel,
            this.toolStripMenuItem_DeleteWorkingModel,
            this.toolStripSeparator1,
            this.toolStripMenuItem_RefreshWorkingModel});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(180, 98);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItem_NewWorkingModel
            // 
            this.toolStripMenuItem_NewWorkingModel.Name = "toolStripMenuItem_NewWorkingModel";
            this.toolStripMenuItem_NewWorkingModel.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_NewWorkingModel.Text = "New working model";
            this.toolStripMenuItem_NewWorkingModel.Click += new System.EventHandler(this.toolStripMenuItem_NewWorkingModel_Click);
            // 
            // toolStripMenuItem_EditWorkingModel
            // 
            this.toolStripMenuItem_EditWorkingModel.Name = "toolStripMenuItem_EditWorkingModel";
            this.toolStripMenuItem_EditWorkingModel.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_EditWorkingModel.Text = "Edit working model";
            this.toolStripMenuItem_EditWorkingModel.Click += new System.EventHandler(this.toolStripMenuItem_EditWorkingModel_Click);
            // 
            // toolStripMenuItem_DeleteWorkingModel
            // 
            this.toolStripMenuItem_DeleteWorkingModel.Name = "toolStripMenuItem_DeleteWorkingModel";
            this.toolStripMenuItem_DeleteWorkingModel.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_DeleteWorkingModel.Text = "Delete working model";
            this.toolStripMenuItem_DeleteWorkingModel.Click += new System.EventHandler(this.toolStripMenuItem_DeleteWorkingModel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // toolStripMenuItem_RefreshWorkingModel
            // 
            this.toolStripMenuItem_RefreshWorkingModel.Name = "toolStripMenuItem_RefreshWorkingModel";
            this.toolStripMenuItem_RefreshWorkingModel.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem_RefreshWorkingModel.Text = "Refresh";
            this.toolStripMenuItem_RefreshWorkingModel.Click += new System.EventHandler(this.toolStripMenuItem_RefreshWorkingModel_Click);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_WorkingModelName,
            this.gc_BeginDate,
            this.gc_Enddate,
            this.gc_WorkingModelMultiplyFactor,
            this.gc_WorkingModelSubAdd,
            this.gc_WorkingModelMessage,
            this.gc_ApplyAdditionalCharge,
            this.gc_UseInRecording});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsFilter.AllowMRUFilterList = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gridColumn_WorkingModelName
            // 
            this.gridColumn_WorkingModelName.Caption = "Name";
            this.gridColumn_WorkingModelName.FieldName = "Name";
            this.gridColumn_WorkingModelName.Name = "gridColumn_WorkingModelName";
            this.gridColumn_WorkingModelName.OptionsColumn.AllowEdit = false;
            this.gridColumn_WorkingModelName.OptionsColumn.AllowMove = false;
            this.gridColumn_WorkingModelName.OptionsColumn.ReadOnly = true;
            this.gridColumn_WorkingModelName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_WorkingModelName.OptionsFilter.AllowFilter = false;
            this.gridColumn_WorkingModelName.Visible = true;
            this.gridColumn_WorkingModelName.VisibleIndex = 0;
            this.gridColumn_WorkingModelName.Width = 450;
            // 
            // gc_BeginDate
            // 
            this.gc_BeginDate.Caption = "Begin";
            this.gc_BeginDate.DisplayFormat.FormatString = "d";
            this.gc_BeginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_BeginDate.FieldName = "BeginTime";
            this.gc_BeginDate.Name = "gc_BeginDate";
            this.gc_BeginDate.OptionsColumn.AllowEdit = false;
            this.gc_BeginDate.OptionsColumn.AllowMove = false;
            this.gc_BeginDate.OptionsColumn.FixedWidth = true;
            this.gc_BeginDate.OptionsColumn.ReadOnly = true;
            this.gc_BeginDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_BeginDate.OptionsFilter.AllowFilter = false;
            this.gc_BeginDate.Visible = true;
            this.gc_BeginDate.VisibleIndex = 1;
            this.gc_BeginDate.Width = 100;
            // 
            // gc_Enddate
            // 
            this.gc_Enddate.Caption = "End";
            this.gc_Enddate.DisplayFormat.FormatString = "d";
            this.gc_Enddate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_Enddate.FieldName = "EndTime";
            this.gc_Enddate.Name = "gc_Enddate";
            this.gc_Enddate.OptionsColumn.AllowEdit = false;
            this.gc_Enddate.OptionsColumn.AllowMove = false;
            this.gc_Enddate.OptionsColumn.FixedWidth = true;
            this.gc_Enddate.OptionsColumn.ReadOnly = true;
            this.gc_Enddate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Enddate.OptionsFilter.AllowFilter = false;
            this.gc_Enddate.Visible = true;
            this.gc_Enddate.VisibleIndex = 2;
            this.gc_Enddate.Width = 100;
            // 
            // gc_WorkingModelMultiplyFactor
            // 
            this.gc_WorkingModelMultiplyFactor.Caption = "Multiply";
            this.gc_WorkingModelMultiplyFactor.FieldName = "MultiplyValue";
            this.gc_WorkingModelMultiplyFactor.Name = "gc_WorkingModelMultiplyFactor";
            this.gc_WorkingModelMultiplyFactor.OptionsColumn.AllowEdit = false;
            this.gc_WorkingModelMultiplyFactor.OptionsColumn.AllowMove = false;
            this.gc_WorkingModelMultiplyFactor.OptionsColumn.ReadOnly = true;
            this.gc_WorkingModelMultiplyFactor.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_WorkingModelMultiplyFactor.OptionsFilter.AllowFilter = false;
            this.gc_WorkingModelMultiplyFactor.Visible = true;
            this.gc_WorkingModelMultiplyFactor.VisibleIndex = 3;
            // 
            // gc_WorkingModelSubAdd
            // 
            this.gc_WorkingModelSubAdd.Caption = "Add value";
            this.gc_WorkingModelSubAdd.FieldName = "AddValue";
            this.gc_WorkingModelSubAdd.Name = "gc_WorkingModelSubAdd";
            this.gc_WorkingModelSubAdd.OptionsColumn.AllowEdit = false;
            this.gc_WorkingModelSubAdd.OptionsColumn.AllowMove = false;
            this.gc_WorkingModelSubAdd.OptionsColumn.ReadOnly = true;
            this.gc_WorkingModelSubAdd.OptionsFilter.AllowFilter = false;
            this.gc_WorkingModelSubAdd.Visible = true;
            this.gc_WorkingModelSubAdd.VisibleIndex = 4;
            // 
            // gc_WorkingModelMessage
            // 
            this.gc_WorkingModelMessage.Caption = "Message";
            this.gc_WorkingModelMessage.FieldName = "Message";
            this.gc_WorkingModelMessage.Name = "gc_WorkingModelMessage";
            this.gc_WorkingModelMessage.OptionsColumn.AllowEdit = false;
            this.gc_WorkingModelMessage.OptionsColumn.AllowMove = false;
            this.gc_WorkingModelMessage.OptionsColumn.ReadOnly = true;
            this.gc_WorkingModelMessage.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_WorkingModelMessage.OptionsFilter.AllowFilter = false;
            this.gc_WorkingModelMessage.Visible = true;
            this.gc_WorkingModelMessage.VisibleIndex = 5;
            this.gc_WorkingModelMessage.Width = 150;
            // 
            // gc_ApplyAdditionalCharge
            // 
            this.gc_ApplyAdditionalCharge.Caption = "Apply";
            this.gc_ApplyAdditionalCharge.FieldName = "AddCharges";
            this.gc_ApplyAdditionalCharge.Name = "gc_ApplyAdditionalCharge";
            this.gc_ApplyAdditionalCharge.OptionsColumn.AllowEdit = false;
            this.gc_ApplyAdditionalCharge.OptionsColumn.AllowMove = false;
            this.gc_ApplyAdditionalCharge.OptionsColumn.FixedWidth = true;
            this.gc_ApplyAdditionalCharge.OptionsFilter.AllowFilter = false;
            this.gc_ApplyAdditionalCharge.Visible = true;
            this.gc_ApplyAdditionalCharge.VisibleIndex = 6;
            // 
            // gc_UseInRecording
            // 
            this.gc_UseInRecording.Caption = "Use";
            this.gc_UseInRecording.FieldName = "UseInRecording";
            this.gc_UseInRecording.Name = "gc_UseInRecording";
            this.gc_UseInRecording.OptionsColumn.AllowEdit = false;
            this.gc_UseInRecording.OptionsColumn.AllowMove = false;
            this.gc_UseInRecording.OptionsColumn.ReadOnly = true;
            this.gc_UseInRecording.OptionsFilter.AllowFilter = false;
            this.gc_UseInRecording.Visible = true;
            this.gc_UseInRecording.VisibleIndex = 7;
            // 
            // barManager_tools
            // 
            this.barManager_tools.AllowCustomization = false;
            this.barManager_tools.AllowMoveBarOnToolbar = false;
            this.barManager_tools.AllowQuickCustomization = false;
            this.barManager_tools.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager_tools.DockControls.Add(this.barDockControlTop);
            this.barManager_tools.DockControls.Add(this.barDockControlBottom);
            this.barManager_tools.DockControls.Add(this.barDockControlLeft);
            this.barManager_tools.DockControls.Add(this.barDockControlRight);
            this.barManager_tools.Form = this;
            this.barManager_tools.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewWorkingModel,
            this.bi_EditWorkingModel,
            this.bi_DeleteWorkingModel});
            this.barManager_tools.MainMenu = this.bar2;
            this.barManager_tools.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewWorkingModel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditWorkingModel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteWorkingModel)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bi_NewWorkingModel
            // 
            this.bi_NewWorkingModel.Caption = "add";
            this.bi_NewWorkingModel.Glyph = global::Baumax.ClientUI.Properties.Resources.document_add;
            this.bi_NewWorkingModel.Id = 0;
            this.bi_NewWorkingModel.Name = "bi_NewWorkingModel";
            this.bi_NewWorkingModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewWorkingModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewWorkingModel_Click);
            // 
            // bi_EditWorkingModel
            // 
            this.bi_EditWorkingModel.Caption = "edit";
            this.bi_EditWorkingModel.Glyph = global::Baumax.ClientUI.Properties.Resources.document_edit;
            this.bi_EditWorkingModel.Id = 1;
            this.bi_EditWorkingModel.Name = "bi_EditWorkingModel";
            this.bi_EditWorkingModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_EditWorkingModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditWorkingModel_Click);
            // 
            // bi_DeleteWorkingModel
            // 
            this.bi_DeleteWorkingModel.Caption = "delete";
            this.bi_DeleteWorkingModel.Glyph = global::Baumax.ClientUI.Properties.Resources.document_delete;
            this.bi_DeleteWorkingModel.Id = 2;
            this.bi_DeleteWorkingModel.Name = "bi_DeleteWorkingModel";
            this.bi_DeleteWorkingModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteWorkingModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteWorkingModel_Click);
            // 
            // WModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "WModelList";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_tools)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_WorkingModelName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NewWorkingModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditWorkingModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteWorkingModel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RefreshWorkingModel;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Enddate;
        private DevExpress.XtraBars.BarManager barManager_tools;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bi_NewWorkingModel;
        private DevExpress.XtraBars.BarButtonItem bi_EditWorkingModel;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteWorkingModel;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModelMultiplyFactor;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModelSubAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModelMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gc_ApplyAdditionalCharge;
        private DevExpress.XtraGrid.Columns.GridColumn gc_UseInRecording;
    }
}
