namespace Baumax.ClientUI.FormEntities
{
    partial class UCLongTimeAbsenceList
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
            this.bi_NewLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewLongtimeAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_EditLongtimeAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DeleteLongtimeAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_LongTimeAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_LongTimeAbsenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Abbreviation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_AbsenceColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewLongTimeAbsence,
            this.bi_EditLongTimeAbsence,
            this.bi_DeleteLongTimeAbsence});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewLongTimeAbsence),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditLongTimeAbsence),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteLongTimeAbsence)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.DrawSizeGrip = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // bi_NewLongTimeAbsence
            // 
            this.bi_NewLongTimeAbsence.Caption = "New long-time absence";
            this.bi_NewLongTimeAbsence.Glyph = global::Baumax.ClientUI.Properties.Resources.box_add;
            this.bi_NewLongTimeAbsence.Id = 0;
            this.bi_NewLongTimeAbsence.Name = "bi_NewLongTimeAbsence";
            this.bi_NewLongTimeAbsence.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewLongTimeAbsence_ItemClick);
            // 
            // bi_EditLongTimeAbsence
            // 
            this.bi_EditLongTimeAbsence.Caption = "Edit long-time absence";
            this.bi_EditLongTimeAbsence.Glyph = global::Baumax.ClientUI.Properties.Resources.box_into;
            this.bi_EditLongTimeAbsence.Id = 1;
            this.bi_EditLongTimeAbsence.Name = "bi_EditLongTimeAbsence";
            this.bi_EditLongTimeAbsence.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_EditLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditLongTimeAbsence_ItemClick);
            // 
            // bi_DeleteLongTimeAbsence
            // 
            this.bi_DeleteLongTimeAbsence.Caption = "Delete long-time absence";
            this.bi_DeleteLongTimeAbsence.Glyph = global::Baumax.ClientUI.Properties.Resources.box_delete;
            this.bi_DeleteLongTimeAbsence.Id = 2;
            this.bi_DeleteLongTimeAbsence.Name = "bi_DeleteLongTimeAbsence";
            this.bi_DeleteLongTimeAbsence.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_DeleteLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteLongTimeAbsence_ItemClick);
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridViewEntities;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.gridControl.Size = new System.Drawing.Size(516, 203);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewLongtimeAbsence,
            this.mi_EditLongtimeAbsence,
            this.mi_DeleteLongtimeAbsence});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_NewLongtimeAbsence
            // 
            this.mi_NewLongtimeAbsence.Name = "mi_NewLongtimeAbsence";
            this.mi_NewLongtimeAbsence.Size = new System.Drawing.Size(220, 22);
            this.mi_NewLongtimeAbsence.Text = "New long-time absence";
            this.mi_NewLongtimeAbsence.Click += new System.EventHandler(this.mi_NewLongtimeAbsence_Click);
            // 
            // mi_EditLongtimeAbsence
            // 
            this.mi_EditLongtimeAbsence.Name = "mi_EditLongtimeAbsence";
            this.mi_EditLongtimeAbsence.Size = new System.Drawing.Size(220, 22);
            this.mi_EditLongtimeAbsence.Text = "Edit long-time absence";
            this.mi_EditLongtimeAbsence.Click += new System.EventHandler(this.mi_EditLongtimeAbsence_Click);
            // 
            // mi_DeleteLongtimeAbsence
            // 
            this.mi_DeleteLongtimeAbsence.Name = "mi_DeleteLongtimeAbsence";
            this.mi_DeleteLongtimeAbsence.Size = new System.Drawing.Size(220, 22);
            this.mi_DeleteLongtimeAbsence.Text = "Delete long-time absence";
            this.mi_DeleteLongtimeAbsence.Click += new System.EventHandler(this.mi_DeleteLongtimeAbsence_Click);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_LongTimeAbsence,
            this.gc_LongTimeAbsenceCode,
            this.gc_Import,
            this.gc_Abbreviation,
            this.gc_AbsenceColor});
            this.gridViewEntities.GridControl = this.gridControl;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsBehavior.Editable = false;
            this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
            this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.OptionsView.ColumnAutoWidth = false;
            this.gridViewEntities.OptionsView.ShowFooter = true;
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            this.gridViewEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewEntities_KeyDown);
            // 
            // gc_LongTimeAbsence
            // 
            this.gc_LongTimeAbsence.Caption = "Long-time absence";
            this.gc_LongTimeAbsence.FieldName = "CodeName";
            this.gc_LongTimeAbsence.Name = "gc_LongTimeAbsence";
            this.gc_LongTimeAbsence.OptionsColumn.AllowEdit = false;
            this.gc_LongTimeAbsence.OptionsColumn.AllowMove = false;
            this.gc_LongTimeAbsence.OptionsColumn.ReadOnly = true;
            this.gc_LongTimeAbsence.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LongTimeAbsence.OptionsFilter.AllowFilter = false;
            this.gc_LongTimeAbsence.SummaryItem.DisplayFormat = "{0}";
            this.gc_LongTimeAbsence.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_LongTimeAbsence.Visible = true;
            this.gc_LongTimeAbsence.VisibleIndex = 0;
            this.gc_LongTimeAbsence.Width = 450;
            // 
            // gc_LongTimeAbsenceCode
            // 
            this.gc_LongTimeAbsenceCode.Caption = "Code";
            this.gc_LongTimeAbsenceCode.FieldName = "Code";
            this.gc_LongTimeAbsenceCode.Name = "gc_LongTimeAbsenceCode";
            this.gc_LongTimeAbsenceCode.OptionsColumn.AllowEdit = false;
            this.gc_LongTimeAbsenceCode.OptionsColumn.AllowMove = false;
            this.gc_LongTimeAbsenceCode.OptionsColumn.ReadOnly = true;
            this.gc_LongTimeAbsenceCode.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LongTimeAbsenceCode.OptionsFilter.AllowFilter = false;
            this.gc_LongTimeAbsenceCode.Width = 30;
            // 
            // gc_Import
            // 
            this.gc_Import.Caption = "Import";
            this.gc_Import.FieldName = "Import";
            this.gc_Import.Name = "gc_Import";
            this.gc_Import.OptionsColumn.AllowEdit = false;
            this.gc_Import.OptionsColumn.AllowMove = false;
            this.gc_Import.OptionsColumn.ReadOnly = true;
            this.gc_Import.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Import.OptionsFilter.AllowFilter = false;
            this.gc_Import.Width = 30;
            // 
            // gc_Abbreviation
            // 
            this.gc_Abbreviation.Caption = "Abbreviation";
            this.gc_Abbreviation.FieldName = "CharID";
            this.gc_Abbreviation.Name = "gc_Abbreviation";
            this.gc_Abbreviation.OptionsColumn.AllowEdit = false;
            this.gc_Abbreviation.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Abbreviation.OptionsColumn.AllowMove = false;
            this.gc_Abbreviation.OptionsColumn.FixedWidth = true;
            this.gc_Abbreviation.OptionsColumn.ReadOnly = true;
            this.gc_Abbreviation.OptionsFilter.AllowAutoFilter = false;
            this.gc_Abbreviation.OptionsFilter.AllowFilter = false;
            this.gc_Abbreviation.Visible = true;
            this.gc_Abbreviation.VisibleIndex = 1;
            this.gc_Abbreviation.Width = 250;
            // 
            // gc_AbsenceColor
            // 
            this.gc_AbsenceColor.Caption = "Color";
            this.gc_AbsenceColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gc_AbsenceColor.FieldName = "Color";
            this.gc_AbsenceColor.Name = "gc_AbsenceColor";
            this.gc_AbsenceColor.OptionsColumn.AllowEdit = false;
            this.gc_AbsenceColor.OptionsColumn.AllowFocus = false;
            this.gc_AbsenceColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gc_AbsenceColor.OptionsColumn.AllowMove = false;
            this.gc_AbsenceColor.OptionsColumn.ReadOnly = true;
            this.gc_AbsenceColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AbsenceColor.OptionsFilter.AllowAutoFilter = false;
            this.gc_AbsenceColor.OptionsFilter.AllowFilter = false;
            this.gc_AbsenceColor.Visible = true;
            this.gc_AbsenceColor.VisibleIndex = 2;
            this.gc_AbsenceColor.Width = 350;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // UCLongTimeAbsenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLongTimeAbsenceList";
            this.Size = new System.Drawing.Size(516, 237);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bi_NewLongTimeAbsence;
        private DevExpress.XtraBars.BarButtonItem bi_EditLongTimeAbsence;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteLongTimeAbsence;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LongTimeAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LongTimeAbsenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Import;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewLongtimeAbsence;
        private System.Windows.Forms.ToolStripMenuItem mi_EditLongtimeAbsence;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteLongtimeAbsence;
		private DevExpress.XtraGrid.Columns.GridColumn gc_Abbreviation;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AbsenceColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
    }
}
