namespace Baumax.ClientUI.FormEntities.Country
{
    partial class AbsenceListControl
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
            this.contextMenuStripAbsence = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_NewHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_NewIllness = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_EditAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DeleteAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RefreshAbsences = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewAbsence = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_AbsenceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AbsenceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Abbreviation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AbsenceColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridColumn_AbsenceAliquotTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AbsenceCountFixedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_WithoutFixedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_UseAsWorkingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_availablein = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_CountAsOneDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bartools = new DevExpress.XtraBars.Bar();
            this.bi_NewAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewHoliday = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewIllness = new DevExpress.XtraBars.BarButtonItem();
            this.bi_editabsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStripAbsence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStripAbsence;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridViewAbsence;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.gridControl.Size = new System.Drawing.Size(638, 428);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAbsence});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_keyDown);
            // 
            // contextMenuStripAbsence
            // 
            this.contextMenuStripAbsence.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewAbsence,
            this.mi_NewHoliday,
            this.mi_NewIllness,
            this.toolStripSeparator1,
            this.mi_EditAbsence,
            this.mi_DeleteAbsence,
            this.toolStripSeparator3,
            this.toolStripMenuItem_RefreshAbsences});
            this.contextMenuStripAbsence.Name = "contextMenuStripAbsence";
            this.contextMenuStripAbsence.Size = new System.Drawing.Size(179, 148);
            this.contextMenuStripAbsence.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAbsence_Opening);
            // 
            // mi_NewAbsence
            // 
            this.mi_NewAbsence.Name = "mi_NewAbsence";
            this.mi_NewAbsence.Size = new System.Drawing.Size(178, 22);
            this.mi_NewAbsence.Text = "New Absence";
            this.mi_NewAbsence.Click += new System.EventHandler(this.toolStripMenuItem_NewAbsence_Click);
            // 
            // mi_NewHoliday
            // 
            this.mi_NewHoliday.Name = "mi_NewHoliday";
            this.mi_NewHoliday.Size = new System.Drawing.Size(178, 22);
            this.mi_NewHoliday.Text = "New Holiday";
            this.mi_NewHoliday.Click += new System.EventHandler(this.toolStripMenuItem_NewHoliday_Click);
            // 
            // mi_NewIllness
            // 
            this.mi_NewIllness.Name = "mi_NewIllness";
            this.mi_NewIllness.Size = new System.Drawing.Size(178, 22);
            this.mi_NewIllness.Text = "New illness";
            this.mi_NewIllness.Click += new System.EventHandler(this.mi_NewIllness_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // mi_EditAbsence
            // 
            this.mi_EditAbsence.Name = "mi_EditAbsence";
            this.mi_EditAbsence.Size = new System.Drawing.Size(178, 22);
            this.mi_EditAbsence.Text = "Edit Absence";
            this.mi_EditAbsence.Click += new System.EventHandler(this.toolStripMenuItem_Edit_Click);
            // 
            // mi_DeleteAbsence
            // 
            this.mi_DeleteAbsence.Name = "mi_DeleteAbsence";
            this.mi_DeleteAbsence.Size = new System.Drawing.Size(178, 22);
            this.mi_DeleteAbsence.Text = "Delete Absence";
            this.mi_DeleteAbsence.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItem_RefreshAbsences
            // 
            this.toolStripMenuItem_RefreshAbsences.Name = "toolStripMenuItem_RefreshAbsences";
            this.toolStripMenuItem_RefreshAbsences.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_RefreshAbsences.Text = "Refresh absences";
            this.toolStripMenuItem_RefreshAbsences.Click += new System.EventHandler(this.toolStripMenuItem_RefreshAbsences_Click);
            // 
            // gridViewAbsence
            // 
            this.gridViewAbsence.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_AbsenceType,
            this.gridColumn_AbsenceName,
            this.gridColumn_Abbreviation,
            this.gridColumn_AbsenceColor,
            this.gridColumn_AbsenceAliquotTime,
            this.gridColumn_AbsenceCountFixedAmount,
            this.gridColumn_WithoutFixedTime,
            this.gridColumn_UseAsWorkingTime,
            this.gridColumn_availablein,
            this.gridColumn_CountAsOneDay});
            this.gridViewAbsence.GridControl = this.gridControl;
            this.gridViewAbsence.Name = "gridViewAbsence";
            this.gridViewAbsence.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewAbsence.OptionsBehavior.Editable = false;
            this.gridViewAbsence.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewAbsence.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewAbsence.OptionsFilter.AllowFilterEditor = false;
            this.gridViewAbsence.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewAbsence.OptionsMenu.EnableColumnMenu = false;
            this.gridViewAbsence.OptionsMenu.EnableFooterMenu = false;
            this.gridViewAbsence.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewAbsence.OptionsView.ShowGroupPanel = false;
            this.gridViewAbsence.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewAbsence_CustomUnboundColumnData);
            this.gridViewAbsence.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewAbsence_FocusedRowChanged);
            // 
            // gridColumn_AbsenceType
            // 
            this.gridColumn_AbsenceType.Caption = "Type";
            this.gridColumn_AbsenceType.FieldName = "gridColumn_AbsenceType";
            this.gridColumn_AbsenceType.Name = "gridColumn_AbsenceType";
            this.gridColumn_AbsenceType.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceType.OptionsColumn.AllowMove = false;
            this.gridColumn_AbsenceType.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceType.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceType.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn_AbsenceType.Visible = true;
            this.gridColumn_AbsenceType.VisibleIndex = 3;
            this.gridColumn_AbsenceType.Width = 59;
            // 
            // gridColumn_AbsenceName
            // 
            this.gridColumn_AbsenceName.Caption = "Name";
            this.gridColumn_AbsenceName.FieldName = "Name";
            this.gridColumn_AbsenceName.Name = "gridColumn_AbsenceName";
            this.gridColumn_AbsenceName.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceName.OptionsColumn.AllowMove = false;
            this.gridColumn_AbsenceName.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceName.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceName.Visible = true;
            this.gridColumn_AbsenceName.VisibleIndex = 0;
            this.gridColumn_AbsenceName.Width = 72;
            // 
            // gridColumn_Abbreviation
            // 
            this.gridColumn_Abbreviation.Caption = "Abbreviation";
            this.gridColumn_Abbreviation.FieldName = "CharID";
            this.gridColumn_Abbreviation.Name = "gridColumn_Abbreviation";
            this.gridColumn_Abbreviation.OptionsColumn.AllowEdit = false;
            this.gridColumn_Abbreviation.OptionsColumn.AllowMove = false;
            this.gridColumn_Abbreviation.OptionsColumn.ReadOnly = true;
            this.gridColumn_Abbreviation.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Abbreviation.OptionsFilter.AllowFilter = false;
            this.gridColumn_Abbreviation.Visible = true;
            this.gridColumn_Abbreviation.VisibleIndex = 1;
            this.gridColumn_Abbreviation.Width = 59;
            // 
            // gridColumn_AbsenceColor
            // 
            this.gridColumn_AbsenceColor.Caption = "Color";
            this.gridColumn_AbsenceColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_AbsenceColor.FieldName = "Color";
            this.gridColumn_AbsenceColor.Name = "gridColumn_AbsenceColor";
            this.gridColumn_AbsenceColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceColor.OptionsColumn.AllowMove = false;
            this.gridColumn_AbsenceColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceColor.Visible = true;
            this.gridColumn_AbsenceColor.VisibleIndex = 2;
            this.gridColumn_AbsenceColor.Width = 59;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
            // 
            // gridColumn_AbsenceAliquotTime
            // 
            this.gridColumn_AbsenceAliquotTime.Caption = "Count aliquot time";
            this.gridColumn_AbsenceAliquotTime.FieldName = "IsFixed";
            this.gridColumn_AbsenceAliquotTime.Name = "gridColumn_AbsenceAliquotTime";
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.AllowMove = false;
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceAliquotTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceAliquotTime.Visible = true;
            this.gridColumn_AbsenceAliquotTime.VisibleIndex = 4;
            this.gridColumn_AbsenceAliquotTime.Width = 59;
            // 
            // gridColumn_AbsenceCountFixedAmount
            // 
            this.gridColumn_AbsenceCountFixedAmount.Caption = "Count fixed amount";
            this.gridColumn_AbsenceCountFixedAmount.FieldName = "Value";
            this.gridColumn_AbsenceCountFixedAmount.Name = "gridColumn_AbsenceCountFixedAmount";
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.AllowMove = false;
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceCountFixedAmount.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceCountFixedAmount.Visible = true;
            this.gridColumn_AbsenceCountFixedAmount.VisibleIndex = 5;
            this.gridColumn_AbsenceCountFixedAmount.Width = 59;
            // 
            // gridColumn_WithoutFixedTime
            // 
            this.gridColumn_WithoutFixedTime.Caption = "Without fixed time";
            this.gridColumn_WithoutFixedTime.FieldName = "WithoutFixedTime";
            this.gridColumn_WithoutFixedTime.Name = "gridColumn_WithoutFixedTime";
            this.gridColumn_WithoutFixedTime.OptionsColumn.AllowEdit = false;
            this.gridColumn_WithoutFixedTime.OptionsColumn.AllowMove = false;
            this.gridColumn_WithoutFixedTime.OptionsColumn.ReadOnly = true;
            this.gridColumn_WithoutFixedTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_WithoutFixedTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_WithoutFixedTime.Visible = true;
            this.gridColumn_WithoutFixedTime.VisibleIndex = 6;
            this.gridColumn_WithoutFixedTime.Width = 59;
            // 
            // gridColumn_UseAsWorkingTime
            // 
            this.gridColumn_UseAsWorkingTime.Caption = "Calculates as working time";
            this.gridColumn_UseAsWorkingTime.FieldName = "UseInCalck";
            this.gridColumn_UseAsWorkingTime.Name = "gridColumn_UseAsWorkingTime";
            this.gridColumn_UseAsWorkingTime.OptionsColumn.AllowMove = false;
            this.gridColumn_UseAsWorkingTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_UseAsWorkingTime.Visible = true;
            this.gridColumn_UseAsWorkingTime.VisibleIndex = 8;
            this.gridColumn_UseAsWorkingTime.Width = 59;
            // 
            // gridColumn_availablein
            // 
            this.gridColumn_availablein.Caption = "Available in";
            this.gridColumn_availablein.FieldName = "gridColumn_availablein";
            this.gridColumn_availablein.Name = "gridColumn_availablein";
            this.gridColumn_availablein.OptionsColumn.AllowEdit = false;
            this.gridColumn_availablein.OptionsColumn.AllowMove = false;
            this.gridColumn_availablein.OptionsColumn.ReadOnly = true;
            this.gridColumn_availablein.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_availablein.OptionsFilter.AllowFilter = false;
            this.gridColumn_availablein.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn_availablein.Visible = true;
            this.gridColumn_availablein.VisibleIndex = 9;
            this.gridColumn_availablein.Width = 73;
            // 
            // gridColumn_CountAsOneDay
            // 
            this.gridColumn_CountAsOneDay.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_CountAsOneDay.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_CountAsOneDay.Caption = "Count as one day";
            this.gridColumn_CountAsOneDay.FieldName = "CountAsOneDay";
            this.gridColumn_CountAsOneDay.Name = "gridColumn_CountAsOneDay";
            this.gridColumn_CountAsOneDay.OptionsColumn.AllowEdit = false;
            this.gridColumn_CountAsOneDay.OptionsColumn.ReadOnly = true;
            this.gridColumn_CountAsOneDay.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_CountAsOneDay.OptionsFilter.AllowFilter = false;
            this.gridColumn_CountAsOneDay.Visible = true;
            this.gridColumn_CountAsOneDay.VisibleIndex = 7;
            this.gridColumn_CountAsOneDay.Width = 59;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bartools});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_NewAbsence,
            this.bi_NewHoliday,
            this.bi_NewIllness,
            this.bi_Delete,
            this.barToolbarsListItem1,
            this.bi_editabsence,
            this.barStaticItem1});
            this.barManager1.MaxItemId = 7;
            // 
            // bartools
            // 
            this.bartools.BarName = "bar tool";
            this.bartools.DockCol = 0;
            this.bartools.DockRow = 0;
            this.bartools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bartools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewAbsence),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewHoliday),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewIllness),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_editabsence, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_Delete)});
            this.bartools.OptionsBar.AllowQuickCustomization = false;
            this.bartools.OptionsBar.DisableClose = true;
            this.bartools.OptionsBar.DisableCustomization = true;
            this.bartools.OptionsBar.DrawDragBorder = false;
            this.bartools.OptionsBar.UseWholeRow = true;
            this.bartools.Text = "Custom 3";
            // 
            // bi_NewAbsence
            // 
            this.bi_NewAbsence.Caption = "New Absence";
            this.bi_NewAbsence.Glyph = global::Baumax.ClientUI.Properties.Resources.breakpoint_add;
            this.bi_NewAbsence.Id = 0;
            this.bi_NewAbsence.Name = "bi_NewAbsence";
            this.bi_NewAbsence.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewAbsence_Click);
            // 
            // bi_NewHoliday
            // 
            this.bi_NewHoliday.Caption = "New Holiday";
            this.bi_NewHoliday.Glyph = global::Baumax.ClientUI.Properties.Resources.document_add;
            this.bi_NewHoliday.Id = 1;
            this.bi_NewHoliday.Name = "bi_NewHoliday";
            this.bi_NewHoliday.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewHoliday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewHoliday_Click);
            // 
            // bi_NewIllness
            // 
            this.bi_NewIllness.Caption = "New Illness";
            this.bi_NewIllness.Glyph = global::Baumax.ClientUI.Properties.Resources.table_add;
            this.bi_NewIllness.Id = 2;
            this.bi_NewIllness.Name = "bi_NewIllness";
            this.bi_NewIllness.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_NewIllness.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewIllness_Click);
            // 
            // bi_editabsence
            // 
            this.bi_editabsence.Caption = "Edit";
            this.bi_editabsence.Glyph = global::Baumax.ClientUI.Properties.Resources.document_edit;
            this.bi_editabsence.Id = 5;
            this.bi_editabsence.Name = "bi_editabsence";
            this.bi_editabsence.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_editabsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_edit_Click);
            // 
            // bi_Delete
            // 
            this.bi_Delete.Caption = "Delete";
            this.bi_Delete.Glyph = global::Baumax.ClientUI.Properties.Resources.del;
            this.bi_Delete.Id = 3;
            this.bi_Delete.Name = "bi_Delete";
            this.bi_Delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bi_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_Delete_Click);
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "barToolbarsListItem1";
            this.barToolbarsListItem1.Id = 4;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 6;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // AbsenceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "AbsenceListControl";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStripAbsence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Abbreviation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAbsence;
        private System.Windows.Forms.ToolStripMenuItem mi_NewAbsence;
        private System.Windows.Forms.ToolStripMenuItem mi_EditAbsence;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteAbsence;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewHoliday;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RefreshAbsences;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mi_NewIllness;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceAliquotTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceCountFixedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_WithoutFixedTime;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_UseAsWorkingTime;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bartools;
        private DevExpress.XtraBars.BarButtonItem bi_NewAbsence;
        private DevExpress.XtraBars.BarButtonItem bi_NewHoliday;
        private DevExpress.XtraBars.BarButtonItem bi_NewIllness;
        private DevExpress.XtraBars.BarButtonItem bi_Delete;
        private DevExpress.XtraBars.BarButtonItem bi_editabsence;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_availablein;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_CountAsOneDay;
    }
}
