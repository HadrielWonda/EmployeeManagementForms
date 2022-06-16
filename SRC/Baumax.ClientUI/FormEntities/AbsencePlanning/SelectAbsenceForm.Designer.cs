namespace Baumax.ClientUI.FormEntities.AbsencePlanning
{
    partial class SelectAbsenceForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.popupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this.ucSelectIgnore1 = new Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning.UCSelectIgnore();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
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
            this.gridColumn_CountAsOneDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.teEnd = new DevExpress.XtraEditors.TimeEdit();
            this.teBegin = new DevExpress.XtraEditors.TimeEdit();
            this.lb_to = new DevExpress.XtraEditors.LabelControl();
            this.lbl_From = new DevExpress.XtraEditors.LabelControl();
            this.lb_IgnoredDays = new DevExpress.XtraEditors.LabelControl();
            this.edIgnore = new DevExpress.XtraEditors.PopupContainerEdit();
            this.edEndDate = new DevExpress.XtraEditors.DateEdit();
            this.lb_EndDate = new DevExpress.XtraEditors.LabelControl();
            this.edBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.lb_BeginDate = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Select = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_SelectAbsence = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainer)).BeginInit();
            this.popupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edIgnore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_SelectAbsence);
            this.panelTop.Size = new System.Drawing.Size(736, 34);
            this.panelTop.TabIndex = 0;
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.panelControl1);
            this.panelClient.Controls.Add(this.panelControl2);
            this.panelClient.Size = new System.Drawing.Size(736, 334);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 21);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(516, 17);
            this.button_Cancel.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.None;
            this.panelBottom.Location = new System.Drawing.Point(93, 416);
            this.panelBottom.Size = new System.Drawing.Size(617, 59);
            this.panelBottom.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.popupContainer);
            this.panelControl1.Controls.Add(this.gridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(732, 230);
            this.panelControl1.TabIndex = 0;
            // 
            // popupContainer
            // 
            this.popupContainer.Controls.Add(this.ucSelectIgnore1);
            this.popupContainer.Location = new System.Drawing.Point(103, 76);
            this.popupContainer.Name = "popupContainer";
            this.popupContainer.Size = new System.Drawing.Size(251, 208);
            this.popupContainer.TabIndex = 18;
            // 
            // ucSelectIgnore1
            // 
            this.ucSelectIgnore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSelectIgnore1.Entity = null;
            this.ucSelectIgnore1.Location = new System.Drawing.Point(0, 0);
            this.ucSelectIgnore1.LookAndFeel.SkinName = "iMaginary";
            this.ucSelectIgnore1.Name = "ucSelectIgnore1";
            this.ucSelectIgnore1.Size = new System.Drawing.Size(251, 208);
            this.ucSelectIgnore1.TabIndex = 0;
            this.ucSelectIgnore1.IgnoreSelected += new System.EventHandler(this.SelectIgnoreIgnoreSelected);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridViewAbsence;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.gridControl.Size = new System.Drawing.Size(728, 226);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAbsence});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // gridViewAbsence
            // 
            this.gridViewAbsence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewAbsence.ColumnPanelRowHeight = 50;
            this.gridViewAbsence.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_AbsenceType,
            this.gridColumn_AbsenceName,
            this.gridColumn_Abbreviation,
            this.gridColumn_AbsenceColor,
            this.gridColumn_AbsenceAliquotTime,
            this.gridColumn_AbsenceCountFixedAmount,
            this.gridColumn_WithoutFixedTime,
            this.gridColumn_UseAsWorkingTime,
            this.gridColumn_CountAsOneDay});
            this.gridViewAbsence.GridControl = this.gridControl;
            this.gridViewAbsence.GroupCount = 1;
            this.gridViewAbsence.Name = "gridViewAbsence";
            this.gridViewAbsence.OptionsBehavior.AutoExpandAllGroups = true;
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
            this.gridViewAbsence.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_AbsenceType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAbsence.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewAbsence_CustomUnboundColumnData);
            this.gridViewAbsence.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewAbsence_FocusedRowChanged);
            // 
            // gridColumn_AbsenceType
            // 
            this.gridColumn_AbsenceType.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_AbsenceType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_AbsenceType.Caption = "Type";
            this.gridColumn_AbsenceType.FieldName = "gridColumn_AbsenceType";
            this.gridColumn_AbsenceType.Name = "gridColumn_AbsenceType";
            this.gridColumn_AbsenceType.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceType.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceType.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceType.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // gridColumn_AbsenceName
            // 
            this.gridColumn_AbsenceName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_AbsenceName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_AbsenceName.Caption = "Name";
            this.gridColumn_AbsenceName.FieldName = "Name";
            this.gridColumn_AbsenceName.Name = "gridColumn_AbsenceName";
            this.gridColumn_AbsenceName.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceName.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceName.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceName.Visible = true;
            this.gridColumn_AbsenceName.VisibleIndex = 0;
            this.gridColumn_AbsenceName.Width = 100;
            // 
            // gridColumn_Abbreviation
            // 
            this.gridColumn_Abbreviation.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Abbreviation.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_Abbreviation.Caption = "Abbreviation";
            this.gridColumn_Abbreviation.FieldName = "CharID";
            this.gridColumn_Abbreviation.Name = "gridColumn_Abbreviation";
            this.gridColumn_Abbreviation.OptionsColumn.AllowEdit = false;
            this.gridColumn_Abbreviation.OptionsColumn.ReadOnly = true;
            this.gridColumn_Abbreviation.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Abbreviation.OptionsFilter.AllowFilter = false;
            this.gridColumn_Abbreviation.Visible = true;
            this.gridColumn_Abbreviation.VisibleIndex = 1;
            this.gridColumn_Abbreviation.Width = 53;
            // 
            // gridColumn_AbsenceColor
            // 
            this.gridColumn_AbsenceColor.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_AbsenceColor.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_AbsenceColor.Caption = "Color";
            this.gridColumn_AbsenceColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_AbsenceColor.FieldName = "Color";
            this.gridColumn_AbsenceColor.Name = "gridColumn_AbsenceColor";
            this.gridColumn_AbsenceColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceColor.Visible = true;
            this.gridColumn_AbsenceColor.VisibleIndex = 2;
            this.gridColumn_AbsenceColor.Width = 62;
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
            this.gridColumn_AbsenceAliquotTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_AbsenceAliquotTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_AbsenceAliquotTime.Caption = "Count aliquot time";
            this.gridColumn_AbsenceAliquotTime.FieldName = "IsFixed";
            this.gridColumn_AbsenceAliquotTime.Name = "gridColumn_AbsenceAliquotTime";
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceAliquotTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceAliquotTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceAliquotTime.Visible = true;
            this.gridColumn_AbsenceAliquotTime.VisibleIndex = 3;
            this.gridColumn_AbsenceAliquotTime.Width = 53;
            // 
            // gridColumn_AbsenceCountFixedAmount
            // 
            this.gridColumn_AbsenceCountFixedAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_AbsenceCountFixedAmount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_AbsenceCountFixedAmount.Caption = "Count fixed amount";
            this.gridColumn_AbsenceCountFixedAmount.FieldName = "Value";
            this.gridColumn_AbsenceCountFixedAmount.Name = "gridColumn_AbsenceCountFixedAmount";
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.AllowEdit = false;
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.ReadOnly = true;
            this.gridColumn_AbsenceCountFixedAmount.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_AbsenceCountFixedAmount.OptionsFilter.AllowFilter = false;
            this.gridColumn_AbsenceCountFixedAmount.Visible = true;
            this.gridColumn_AbsenceCountFixedAmount.VisibleIndex = 4;
            this.gridColumn_AbsenceCountFixedAmount.Width = 53;
            // 
            // gridColumn_WithoutFixedTime
            // 
            this.gridColumn_WithoutFixedTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_WithoutFixedTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_WithoutFixedTime.Caption = "Without fixed time";
            this.gridColumn_WithoutFixedTime.FieldName = "WithoutFixedTime";
            this.gridColumn_WithoutFixedTime.Name = "gridColumn_WithoutFixedTime";
            this.gridColumn_WithoutFixedTime.OptionsColumn.AllowEdit = false;
            this.gridColumn_WithoutFixedTime.OptionsColumn.ReadOnly = true;
            this.gridColumn_WithoutFixedTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_WithoutFixedTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_WithoutFixedTime.Visible = true;
            this.gridColumn_WithoutFixedTime.VisibleIndex = 5;
            this.gridColumn_WithoutFixedTime.Width = 53;
            // 
            // gridColumn_UseAsWorkingTime
            // 
            this.gridColumn_UseAsWorkingTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_UseAsWorkingTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_UseAsWorkingTime.Caption = "Calculates as working time";
            this.gridColumn_UseAsWorkingTime.FieldName = "UseInCalck";
            this.gridColumn_UseAsWorkingTime.Name = "gridColumn_UseAsWorkingTime";
            this.gridColumn_UseAsWorkingTime.OptionsColumn.AllowEdit = false;
            this.gridColumn_UseAsWorkingTime.OptionsColumn.ReadOnly = true;
            this.gridColumn_UseAsWorkingTime.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_UseAsWorkingTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_UseAsWorkingTime.Visible = true;
            this.gridColumn_UseAsWorkingTime.VisibleIndex = 7;
            this.gridColumn_UseAsWorkingTime.Width = 84;
            // 
            // gridColumn_CountAsOneDay
            // 
            this.gridColumn_CountAsOneDay.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_CountAsOneDay.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_CountAsOneDay.Caption = "Count as one day";
            this.gridColumn_CountAsOneDay.FieldName = "CountAsOneDay";
            this.gridColumn_CountAsOneDay.Name = "gridColumn_CountAsOneDay";
            this.gridColumn_CountAsOneDay.OptionsColumn.AllowEdit = false;
            this.gridColumn_CountAsOneDay.OptionsColumn.AllowMove = false;
            this.gridColumn_CountAsOneDay.OptionsColumn.ReadOnly = true;
            this.gridColumn_CountAsOneDay.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_CountAsOneDay.OptionsFilter.AllowFilter = false;
            this.gridColumn_CountAsOneDay.Visible = true;
            this.gridColumn_CountAsOneDay.VisibleIndex = 6;
            this.gridColumn_CountAsOneDay.Width = 87;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.teEnd);
            this.panelControl2.Controls.Add(this.teBegin);
            this.panelControl2.Controls.Add(this.lb_to);
            this.panelControl2.Controls.Add(this.lbl_From);
            this.panelControl2.Controls.Add(this.lb_IgnoredDays);
            this.panelControl2.Controls.Add(this.edIgnore);
            this.panelControl2.Controls.Add(this.edEndDate);
            this.panelControl2.Controls.Add(this.lb_EndDate);
            this.panelControl2.Controls.Add(this.edBeginDate);
            this.panelControl2.Controls.Add(this.lb_BeginDate);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 232);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(732, 100);
            this.panelControl2.TabIndex = 0;
            // 
            // teEnd
            // 
            this.teEnd.EditValue = new System.DateTime(2007, 9, 30, 0, 0, 0, 0);
            this.teEnd.Location = new System.Drawing.Point(71, 64);
            this.teEnd.Name = "teEnd";
            this.teEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEnd.Properties.Mask.EditMask = "t";
            this.teEnd.Size = new System.Drawing.Size(60, 20);
            this.teEnd.TabIndex = 4;
            // 
            // teBegin
            // 
            this.teBegin.EditValue = new System.DateTime(2007, 9, 30, 0, 0, 0, 0);
            this.teBegin.Location = new System.Drawing.Point(5, 64);
            this.teBegin.Name = "teBegin";
            this.teBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teBegin.Properties.Mask.EditMask = "t";
            this.teBegin.Size = new System.Drawing.Size(60, 20);
            this.teBegin.TabIndex = 3;
            // 
            // lb_to
            // 
            this.lb_to.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_to.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_to.Location = new System.Drawing.Point(71, 45);
            this.lb_to.Name = "lb_to";
            this.lb_to.Size = new System.Drawing.Size(53, 13);
            this.lb_to.TabIndex = 25;
            this.lb_to.Text = "To";
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_From.Location = new System.Drawing.Point(5, 45);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(60, 13);
            this.lbl_From.TabIndex = 24;
            this.lbl_From.Text = "From";
            // 
            // lb_IgnoredDays
            // 
            this.lb_IgnoredDays.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_IgnoredDays.Location = new System.Drawing.Point(270, 6);
            this.lb_IgnoredDays.Name = "lb_IgnoredDays";
            this.lb_IgnoredDays.Size = new System.Drawing.Size(162, 13);
            this.lb_IgnoredDays.TabIndex = 23;
            this.lb_IgnoredDays.Text = "Ignore days";
            // 
            // edIgnore
            // 
            this.edIgnore.EditValue = "None";
            this.edIgnore.Location = new System.Drawing.Point(270, 22);
            this.edIgnore.Name = "edIgnore";
            this.edIgnore.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.edIgnore.Properties.Appearance.Options.UseBackColor = true;
            this.edIgnore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edIgnore.Properties.PopupControl = this.popupContainer;
            this.edIgnore.Properties.ShowPopupCloseButton = false;
            this.edIgnore.Size = new System.Drawing.Size(240, 20);
            this.edIgnore.TabIndex = 2;
            // 
            // edEndDate
            // 
            this.edEndDate.EditValue = null;
            this.edEndDate.Location = new System.Drawing.Point(129, 22);
            this.edEndDate.Name = "edEndDate";
            this.edEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edEndDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edEndDate.Size = new System.Drawing.Size(110, 20);
            this.edEndDate.TabIndex = 1;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_EndDate.Location = new System.Drawing.Point(129, 6);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(115, 13);
            this.lb_EndDate.TabIndex = 20;
            this.lb_EndDate.Text = "End date";
            // 
            // edBeginDate
            // 
            this.edBeginDate.EditValue = null;
            this.edBeginDate.Location = new System.Drawing.Point(3, 22);
            this.edBeginDate.Name = "edBeginDate";
            this.edBeginDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edBeginDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edBeginDate.Size = new System.Drawing.Size(110, 20);
            this.edBeginDate.TabIndex = 0;
            // 
            // lb_BeginDate
            // 
            this.lb_BeginDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_BeginDate.Location = new System.Drawing.Point(5, 6);
            this.lb_BeginDate.Name = "lb_BeginDate";
            this.lb_BeginDate.Size = new System.Drawing.Size(109, 13);
            this.lb_BeginDate.TabIndex = 18;
            this.lb_BeginDate.Text = "Begin date";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btn_Select);
            this.panelControl3.Controls.Add(this.btn_Close);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 368);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(736, 47);
            this.panelControl3.TabIndex = 2;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(28, 12);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(127, 23);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "Select";
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(574, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(127, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_SelectAbsence
            // 
            this.lbl_SelectAbsence.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_SelectAbsence.Appearance.Options.UseFont = true;
            this.lbl_SelectAbsence.Appearance.Options.UseTextOptions = true;
            this.lbl_SelectAbsence.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_SelectAbsence.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_SelectAbsence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_SelectAbsence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SelectAbsence.Location = new System.Drawing.Point(2, 2);
            this.lbl_SelectAbsence.Name = "lbl_SelectAbsence";
            this.lbl_SelectAbsence.Size = new System.Drawing.Size(732, 30);
            this.lbl_SelectAbsence.TabIndex = 0;
            this.lbl_SelectAbsence.Text = "Select absence";
            // 
            // SelectAbsenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 415);
            this.Controls.Add(this.panelControl3);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "SelectAbsenceForm";
            this.Text = " ";
            this.Controls.SetChildIndex(this.panelControl3, 0);
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.Controls.SetChildIndex(this.panelTop, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainer)).EndInit();
            this.popupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edIgnore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraGrid.GridControl gridControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridViewAbsence;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceType;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceName;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_Abbreviation;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceColor;
        protected DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceAliquotTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_AbsenceCountFixedAmount;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_WithoutFixedTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_UseAsWorkingTime;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lb_IgnoredDays;
        private DevExpress.XtraEditors.PopupContainerEdit edIgnore;
        private DevExpress.XtraEditors.DateEdit edEndDate;
        private DevExpress.XtraEditors.LabelControl lb_EndDate;
        private DevExpress.XtraEditors.DateEdit edBeginDate;
        private DevExpress.XtraEditors.LabelControl lb_BeginDate;
        private DevExpress.XtraEditors.PopupContainerControl popupContainer;
        private Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning.UCSelectIgnore ucSelectIgnore1;
        protected DevExpress.XtraEditors.TimeEdit teEnd;
        protected DevExpress.XtraEditors.TimeEdit teBegin;
        protected DevExpress.XtraEditors.LabelControl lb_to;
        protected DevExpress.XtraEditors.LabelControl lbl_From;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Select;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.LabelControl lbl_SelectAbsence;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn_CountAsOneDay;
    }
}