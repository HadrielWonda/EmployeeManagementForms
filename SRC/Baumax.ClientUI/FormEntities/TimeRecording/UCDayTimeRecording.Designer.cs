namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCDayTimeRecording
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk_ShowHidePlannedRow = new DevExpress.XtraEditors.CheckEdit();
            this.deDate = new DevExpress.XtraEditors.DateEdit();
            this.lbl_Date = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblAvailableWorldBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.lblDifference = new DevExpress.XtraEditors.LabelControl();
            this.lblPlannedHours = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumPresence = new DevExpress.XtraEditors.LabelControl();
            this.lblMinimumPresence = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_MarkAsWorkingTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Absence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MarkAsAbsence = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tm_ClearTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_CopyFromPlanned = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CopyAllFromPlanned = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.band_Employee = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gc_Employee = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemEmployeeName = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.band_HWGR = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gc_HWGR = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.riLookupHwgr = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcHoursPlanned = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcHoursActual = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band_ContractWorkingHours = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcContractHoursPerWeek = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band_SummOfAdditionalCharges = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcAdditionalHoursPlanned = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcAdditionalHoursActual = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band_PlusMinusHours = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcPlusMinusHoursPlanned = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcPlusMinusHoursActual = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band_EmployeeBalanceHours = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcSaldoPlanned = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcSaldoActual = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repItemCellData = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.ucActualCashDeskDailyInfo = new Baumax.ClientUI.FormEntities.TimeRecording.UCActualCashDeskDailyInfo();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ShowHidePlannedRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookupHwgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCellData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chk_ShowHidePlannedRow);
            this.panelControl1.Controls.Add(this.deDate);
            this.panelControl1.Controls.Add(this.lbl_Date);
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(798, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // chk_ShowHidePlannedRow
            // 
            this.chk_ShowHidePlannedRow.EditValue = true;
            this.chk_ShowHidePlannedRow.Location = new System.Drawing.Point(395, 6);
            this.chk_ShowHidePlannedRow.Name = "chk_ShowHidePlannedRow";
            this.chk_ShowHidePlannedRow.Properties.Caption = "Show/Hide planning row";
            this.chk_ShowHidePlannedRow.Size = new System.Drawing.Size(201, 19);
            this.chk_ShowHidePlannedRow.TabIndex = 8;
            this.chk_ShowHidePlannedRow.CheckedChanged += new System.EventHandler(this.chk_ShowHidePlannedRow_CheckedChanged);
            // 
            // deDate
            // 
            this.deDate.EditValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deDate.Location = new System.Drawing.Point(99, 5);
            this.deDate.Name = "deDate";
            this.deDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate.Properties.ShowWeekNumbers = true;
            this.deDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDate.Size = new System.Drawing.Size(100, 20);
            this.deDate.TabIndex = 7;
            this.deDate.DateTimeChanged += new System.EventHandler(this.deDate_DateTimeChanged);
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Date.Location = new System.Drawing.Point(7, 8);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(86, 13);
            this.lbl_Date.TabIndex = 6;
            this.lbl_Date.Text = "Date";
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = 2;
            this.radioGroup1.Location = new System.Drawing.Point(215, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "15"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "30"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "60")});
            this.radioGroup1.Size = new System.Drawing.Size(174, 20);
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblAvailableWorldBufferHours);
            this.panelControl2.Controls.Add(this.lblDifference);
            this.panelControl2.Controls.Add(this.lblPlannedHours);
            this.panelControl2.Controls.Add(this.lblMaximumPresence);
            this.panelControl2.Controls.Add(this.lblMinimumPresence);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 476);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(798, 31);
            this.panelControl2.TabIndex = 1;
            // 
            // lblAvailableWorldBufferHours
            // 
            this.lblAvailableWorldBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailableWorldBufferHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAvailableWorldBufferHours.Location = new System.Drawing.Point(148, 3);
            this.lblAvailableWorldBufferHours.Name = "lblAvailableWorldBufferHours";
            this.lblAvailableWorldBufferHours.Size = new System.Drawing.Size(210, 12);
            this.lblAvailableWorldBufferHours.TabIndex = 15;
            this.lblAvailableWorldBufferHours.Text = "Available world buffer hours :";
            // 
            // lblDifference
            // 
            this.lblDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifference.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDifference.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblDifference.Location = new System.Drawing.Point(580, 4);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(210, 11);
            this.lblDifference.TabIndex = 14;
            this.lblDifference.Text = "Difference:";
            // 
            // lblPlannedHours
            // 
            this.lblPlannedHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlannedHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPlannedHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPlannedHours.Location = new System.Drawing.Point(364, 3);
            this.lblPlannedHours.Name = "lblPlannedHours";
            this.lblPlannedHours.Size = new System.Drawing.Size(210, 13);
            this.lblPlannedHours.TabIndex = 13;
            this.lblPlannedHours.Text = "Targeted hours:";
            // 
            // lblMaximumPresence
            // 
            this.lblMaximumPresence.Appearance.Options.UseTextOptions = true;
            this.lblMaximumPresence.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblMaximumPresence.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblMaximumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaximumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMaximumPresence.Location = new System.Drawing.Point(5, 16);
            this.lblMaximumPresence.Name = "lblMaximumPresence";
            this.lblMaximumPresence.Size = new System.Drawing.Size(137, 13);
            this.lblMaximumPresence.TabIndex = 12;
            this.lblMaximumPresence.Text = "Maximum presence:";
            // 
            // lblMinimumPresence
            // 
            this.lblMinimumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMinimumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMinimumPresence.Location = new System.Drawing.Point(5, 3);
            this.lblMinimumPresence.Name = "lblMinimumPresence";
            this.lblMinimumPresence.Size = new System.Drawing.Size(137, 11);
            this.lblMinimumPresence.TabIndex = 11;
            this.lblMinimumPresence.Text = "Minimum presence:";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl);
            this.panelControl3.Controls.Add(this.ucActualCashDeskDailyInfo);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 32);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(798, 444);
            this.panelControl3.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemEmployeeName,
            this.repItemCellData,
            this.riLookupHwgr});
            this.gridControl.Size = new System.Drawing.Size(794, 276);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            this.gridControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_MarkAsWorkingTime,
            this.toolStripSeparator3,
            this.mi_Absence,
            this.mi_MarkAsAbsence,
            this.toolStripSeparator2,
            this.tm_ClearTime,
            this.toolStripSeparator1,
            this.mi_CopyFromPlanned,
            this.mi_CopyAllFromPlanned});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 154);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_MarkAsWorkingTime
            // 
            this.mi_MarkAsWorkingTime.Name = "mi_MarkAsWorkingTime";
            this.mi_MarkAsWorkingTime.Size = new System.Drawing.Size(178, 22);
            this.mi_MarkAsWorkingTime.Text = "Working time";
            this.mi_MarkAsWorkingTime.Click += new System.EventHandler(this.mi_MarkAsWorkingTime_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // mi_Absence
            // 
            this.mi_Absence.Name = "mi_Absence";
            this.mi_Absence.Size = new System.Drawing.Size(178, 22);
            this.mi_Absence.Text = "Absence";
            this.mi_Absence.Click += new System.EventHandler(this.mi_Absence_Click);
            // 
            // mi_MarkAsAbsence
            // 
            this.mi_MarkAsAbsence.Name = "mi_MarkAsAbsence";
            this.mi_MarkAsAbsence.Size = new System.Drawing.Size(178, 22);
            this.mi_MarkAsAbsence.Text = "Mark as absence";
            this.mi_MarkAsAbsence.Click += new System.EventHandler(this.mi_MarkAsAbsence_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // tm_ClearTime
            // 
            this.tm_ClearTime.Name = "tm_ClearTime";
            this.tm_ClearTime.Size = new System.Drawing.Size(178, 22);
            this.tm_ClearTime.Text = "Clear";
            this.tm_ClearTime.Click += new System.EventHandler(this.tm_ClearTime_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // mi_CopyFromPlanned
            // 
            this.mi_CopyFromPlanned.Name = "mi_CopyFromPlanned";
            this.mi_CopyFromPlanned.Size = new System.Drawing.Size(178, 22);
            this.mi_CopyFromPlanned.Text = "Copy from planned";
            this.mi_CopyFromPlanned.Click += new System.EventHandler(this.copyFromPlannedToolStripMenuItem_Click);
            // 
            // mi_CopyAllFromPlanned
            // 
            this.mi_CopyAllFromPlanned.Name = "mi_CopyAllFromPlanned";
            this.mi_CopyAllFromPlanned.Size = new System.Drawing.Size(178, 22);
            this.mi_CopyAllFromPlanned.Text = "Copy all from planned";
            this.mi_CopyAllFromPlanned.Click += new System.EventHandler(this.mi_CopyAllFromPlanned_Click);
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BandPanelRowHeight = 50;
            this.gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.band_Employee,
            this.band_HWGR,
            this.gridBand1,
            this.band_ContractWorkingHours,
            this.band_SummOfAdditionalCharges,
            this.band_PlusMinusHours,
            this.band_EmployeeBalanceHours});
            this.gridView.ColumnPanelRowHeight = 40;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gc_Employee,
            this.gc_HWGR,
            this.gcContractHoursPerWeek,
            this.gcAdditionalHoursPlanned,
            this.gcAdditionalHoursActual,
            this.gcPlusMinusHoursPlanned,
            this.gcPlusMinusHoursActual,
            this.gcSaldoPlanned,
            this.gcSaldoActual,
            this.gcHoursPlanned,
            this.gcHoursActual});
            this.gridView.FooterPanelHeight = 62;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowChangeBandParent = true;
            this.gridView.OptionsCustomization.AllowChangeColumnParent = true;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowRowSizing = true;
            this.gridView.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsView.ShowColumnHeaders = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowSeparatorHeight = 2;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_Employee, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_HWGR, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView_CustomSummaryCalculate);
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseMove);
            this.gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
            this.gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            // 
            // band_Employee
            // 
            this.band_Employee.AppearanceHeader.Options.UseTextOptions = true;
            this.band_Employee.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.band_Employee.Caption = "Employee";
            this.band_Employee.Columns.Add(this.gc_Employee);
            this.band_Employee.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.band_Employee.Name = "band_Employee";
            this.band_Employee.OptionsBand.AllowMove = false;
            this.band_Employee.OptionsBand.ShowInCustomizationForm = false;
            this.band_Employee.Width = 115;
            // 
            // gc_Employee
            // 
            this.gc_Employee.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.gc_Employee.AppearanceCell.Options.UseForeColor = true;
            this.gc_Employee.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Employee.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Employee.AutoFillDown = true;
            this.gc_Employee.Caption = "Employee";
            this.gc_Employee.ColumnEdit = this.repItemEmployeeName;
            this.gc_Employee.FieldName = "FullName";
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.OptionsColumn.AllowEdit = false;
            this.gc_Employee.OptionsColumn.ReadOnly = true;
            this.gc_Employee.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Employee.OptionsFilter.AllowAutoFilter = false;
            this.gc_Employee.OptionsFilter.AllowFilter = false;
            this.gc_Employee.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gc_Employee.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_Employee.Visible = true;
            this.gc_Employee.Width = 115;
            // 
            // repItemEmployeeName
            // 
            this.repItemEmployeeName.Name = "repItemEmployeeName";
            this.repItemEmployeeName.ReadOnly = true;
            // 
            // band_HWGR
            // 
            this.band_HWGR.AppearanceHeader.Options.UseTextOptions = true;
            this.band_HWGR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.band_HWGR.Caption = "HWGR";
            this.band_HWGR.Columns.Add(this.gc_HWGR);
            this.band_HWGR.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.band_HWGR.Name = "band_HWGR";
            this.band_HWGR.OptionsBand.AllowMove = false;
            this.band_HWGR.OptionsBand.ShowInCustomizationForm = false;
            this.band_HWGR.Width = 75;
            // 
            // gc_HWGR
            // 
            this.gc_HWGR.AutoFillDown = true;
            this.gc_HWGR.Caption = "HWGR";
            this.gc_HWGR.ColumnEdit = this.riLookupHwgr;
            this.gc_HWGR.FieldName = "OrderHWGR";
            this.gc_HWGR.Name = "gc_HWGR";
            this.gc_HWGR.OptionsColumn.AllowEdit = false;
            this.gc_HWGR.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gc_HWGR.OptionsColumn.AllowMove = false;
            this.gc_HWGR.OptionsColumn.ReadOnly = true;
            this.gc_HWGR.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_HWGR.OptionsFilter.AllowAutoFilter = false;
            this.gc_HWGR.OptionsFilter.AllowFilter = false;
            this.gc_HWGR.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gc_HWGR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_HWGR.Visible = true;
            // 
            // riLookupHwgr
            // 
            this.riLookupHwgr.AutoHeight = false;
            this.riLookupHwgr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLookupHwgr.DisplayMember = "Name";
            this.riLookupHwgr.Name = "riLookupHwgr";
            this.riLookupHwgr.NullText = "";
            this.riLookupHwgr.ValueMember = "ID";
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand1.Caption = "Allready planned working hours";
            this.gridBand1.Columns.Add(this.gcHoursPlanned);
            this.gridBand1.Columns.Add(this.gcHoursActual);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.OptionsBand.AllowPress = false;
            this.gridBand1.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand1.Width = 75;
            // 
            // gcHoursPlanned
            // 
            this.gcHoursPlanned.Caption = "PlannedHours";
            this.gcHoursPlanned.FieldName = "PlannedWorkingHours";
            this.gcHoursPlanned.Name = "gcHoursPlanned";
            this.gcHoursPlanned.OptionsColumn.AllowEdit = false;
            this.gcHoursPlanned.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursPlanned.OptionsColumn.AllowIncrementalSearch = false;
            this.gcHoursPlanned.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursPlanned.OptionsColumn.AllowMove = false;
            this.gcHoursPlanned.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursPlanned.OptionsColumn.ReadOnly = true;
            this.gcHoursPlanned.OptionsColumn.ShowInCustomizationForm = false;
            this.gcHoursPlanned.OptionsFilter.AllowAutoFilter = false;
            this.gcHoursPlanned.OptionsFilter.AllowFilter = false;
            this.gcHoursPlanned.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcHoursPlanned.SummaryItem.FieldName = "PlannedHours";
            this.gcHoursPlanned.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcHoursPlanned.Visible = true;
            // 
            // gcHoursActual
            // 
            this.gcHoursActual.AutoFillDown = true;
            this.gcHoursActual.Caption = "ActualPlannedWorkingHours";
            this.gcHoursActual.FieldName = "ActualPlannedWorkingHours";
            this.gcHoursActual.Name = "gcHoursActual";
            this.gcHoursActual.OptionsColumn.AllowEdit = false;
            this.gcHoursActual.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursActual.OptionsColumn.AllowIncrementalSearch = false;
            this.gcHoursActual.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursActual.OptionsColumn.AllowMove = false;
            this.gcHoursActual.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcHoursActual.OptionsColumn.ReadOnly = true;
            this.gcHoursActual.OptionsColumn.ShowInCustomizationForm = false;
            this.gcHoursActual.OptionsFilter.AllowAutoFilter = false;
            this.gcHoursActual.OptionsFilter.AllowFilter = false;
            this.gcHoursActual.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcHoursActual.RowIndex = 1;
            this.gcHoursActual.SummaryItem.FieldName = "ActualHours";
            this.gcHoursActual.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcHoursActual.Visible = true;
            // 
            // band_ContractWorkingHours
            // 
            this.band_ContractWorkingHours.AppearanceHeader.Options.UseTextOptions = true;
            this.band_ContractWorkingHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.band_ContractWorkingHours.Caption = "Contract hours per week";
            this.band_ContractWorkingHours.Columns.Add(this.gcContractHoursPerWeek);
            this.band_ContractWorkingHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.band_ContractWorkingHours.Name = "band_ContractWorkingHours";
            this.band_ContractWorkingHours.OptionsBand.AllowMove = false;
            this.band_ContractWorkingHours.OptionsBand.AllowPress = false;
            this.band_ContractWorkingHours.OptionsBand.ShowInCustomizationForm = false;
            this.band_ContractWorkingHours.Visible = false;
            this.band_ContractWorkingHours.Width = 75;
            // 
            // gcContractHoursPerWeek
            // 
            this.gcContractHoursPerWeek.AutoFillDown = true;
            this.gcContractHoursPerWeek.Caption = "Contract hours per week";
            this.gcContractHoursPerWeek.FieldName = "ContractHoursPerWeek";
            this.gcContractHoursPerWeek.Name = "gcContractHoursPerWeek";
            this.gcContractHoursPerWeek.OptionsColumn.AllowEdit = false;
            this.gcContractHoursPerWeek.OptionsColumn.AllowFocus = false;
            this.gcContractHoursPerWeek.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcContractHoursPerWeek.OptionsColumn.AllowIncrementalSearch = false;
            this.gcContractHoursPerWeek.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcContractHoursPerWeek.OptionsColumn.AllowMove = false;
            this.gcContractHoursPerWeek.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcContractHoursPerWeek.OptionsColumn.ReadOnly = true;
            this.gcContractHoursPerWeek.OptionsColumn.ShowInCustomizationForm = false;
            this.gcContractHoursPerWeek.OptionsFilter.AllowAutoFilter = false;
            this.gcContractHoursPerWeek.OptionsFilter.AllowFilter = false;
            this.gcContractHoursPerWeek.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcContractHoursPerWeek.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcContractHoursPerWeek.Visible = true;
            // 
            // band_SummOfAdditionalCharges
            // 
            this.band_SummOfAdditionalCharges.AppearanceHeader.Options.UseTextOptions = true;
            this.band_SummOfAdditionalCharges.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.band_SummOfAdditionalCharges.Caption = "Additional hours";
            this.band_SummOfAdditionalCharges.Columns.Add(this.gcAdditionalHoursPlanned);
            this.band_SummOfAdditionalCharges.Columns.Add(this.gcAdditionalHoursActual);
            this.band_SummOfAdditionalCharges.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.band_SummOfAdditionalCharges.Name = "band_SummOfAdditionalCharges";
            this.band_SummOfAdditionalCharges.OptionsBand.AllowMove = false;
            this.band_SummOfAdditionalCharges.OptionsBand.AllowPress = false;
            this.band_SummOfAdditionalCharges.OptionsBand.ShowInCustomizationForm = false;
            this.band_SummOfAdditionalCharges.Visible = false;
            this.band_SummOfAdditionalCharges.Width = 75;
            // 
            // gcAdditionalHoursPlanned
            // 
            this.gcAdditionalHoursPlanned.Caption = "Planned additional hours";
            this.gcAdditionalHoursPlanned.FieldName = "AdditionalHours";
            this.gcAdditionalHoursPlanned.Name = "gcAdditionalHoursPlanned";
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowEdit = false;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowFocus = false;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowIncrementalSearch = false;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowMove = false;
            this.gcAdditionalHoursPlanned.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursPlanned.OptionsColumn.ReadOnly = true;
            this.gcAdditionalHoursPlanned.OptionsColumn.ShowInCustomizationForm = false;
            this.gcAdditionalHoursPlanned.OptionsFilter.AllowAutoFilter = false;
            this.gcAdditionalHoursPlanned.OptionsFilter.AllowFilter = false;
            this.gcAdditionalHoursPlanned.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcAdditionalHoursPlanned.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcAdditionalHoursPlanned.Visible = true;
            // 
            // gcAdditionalHoursActual
            // 
            this.gcAdditionalHoursActual.Caption = "Actual additional hours ";
            this.gcAdditionalHoursActual.FieldName = "ActualAdditionalHours";
            this.gcAdditionalHoursActual.Name = "gcAdditionalHoursActual";
            this.gcAdditionalHoursActual.OptionsColumn.AllowEdit = false;
            this.gcAdditionalHoursActual.OptionsColumn.AllowFocus = false;
            this.gcAdditionalHoursActual.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursActual.OptionsColumn.AllowIncrementalSearch = false;
            this.gcAdditionalHoursActual.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursActual.OptionsColumn.AllowMove = false;
            this.gcAdditionalHoursActual.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcAdditionalHoursActual.OptionsColumn.ReadOnly = true;
            this.gcAdditionalHoursActual.OptionsColumn.ShowInCustomizationForm = false;
            this.gcAdditionalHoursActual.OptionsFilter.AllowAutoFilter = false;
            this.gcAdditionalHoursActual.OptionsFilter.AllowFilter = false;
            this.gcAdditionalHoursActual.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcAdditionalHoursActual.RowIndex = 1;
            this.gcAdditionalHoursActual.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcAdditionalHoursActual.Visible = true;
            // 
            // band_PlusMinusHours
            // 
            this.band_PlusMinusHours.AppearanceHeader.Options.UseTextOptions = true;
            this.band_PlusMinusHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.band_PlusMinusHours.Caption = "(+/-) hours";
            this.band_PlusMinusHours.Columns.Add(this.gcPlusMinusHoursPlanned);
            this.band_PlusMinusHours.Columns.Add(this.gcPlusMinusHoursActual);
            this.band_PlusMinusHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.band_PlusMinusHours.Name = "band_PlusMinusHours";
            this.band_PlusMinusHours.OptionsBand.AllowMove = false;
            this.band_PlusMinusHours.OptionsBand.AllowPress = false;
            this.band_PlusMinusHours.OptionsBand.ShowInCustomizationForm = false;
            this.band_PlusMinusHours.Visible = false;
            this.band_PlusMinusHours.Width = 75;
            // 
            // gcPlusMinusHoursPlanned
            // 
            this.gcPlusMinusHoursPlanned.Caption = "(+/-)hours (planned)";
            this.gcPlusMinusHoursPlanned.FieldName = "PlusMinusHours";
            this.gcPlusMinusHoursPlanned.Name = "gcPlusMinusHoursPlanned";
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowEdit = false;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowFocus = false;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowIncrementalSearch = false;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowMove = false;
            this.gcPlusMinusHoursPlanned.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursPlanned.OptionsColumn.ReadOnly = true;
            this.gcPlusMinusHoursPlanned.OptionsColumn.ShowInCustomizationForm = false;
            this.gcPlusMinusHoursPlanned.OptionsFilter.AllowAutoFilter = false;
            this.gcPlusMinusHoursPlanned.OptionsFilter.AllowFilter = false;
            this.gcPlusMinusHoursPlanned.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcPlusMinusHoursPlanned.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcPlusMinusHoursPlanned.Visible = true;
            // 
            // gcPlusMinusHoursActual
            // 
            this.gcPlusMinusHoursActual.Caption = "(+/-)hours (actual)";
            this.gcPlusMinusHoursActual.FieldName = "ActualPlusMinusHours";
            this.gcPlusMinusHoursActual.Name = "gcPlusMinusHoursActual";
            this.gcPlusMinusHoursActual.OptionsColumn.AllowEdit = false;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowFocus = false;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowIncrementalSearch = false;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowMove = false;
            this.gcPlusMinusHoursActual.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcPlusMinusHoursActual.OptionsColumn.ReadOnly = true;
            this.gcPlusMinusHoursActual.OptionsColumn.ShowInCustomizationForm = false;
            this.gcPlusMinusHoursActual.OptionsFilter.AllowAutoFilter = false;
            this.gcPlusMinusHoursActual.OptionsFilter.AllowFilter = false;
            this.gcPlusMinusHoursActual.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcPlusMinusHoursActual.RowIndex = 1;
            this.gcPlusMinusHoursActual.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcPlusMinusHoursActual.Visible = true;
            // 
            // band_EmployeeBalanceHours
            // 
            this.band_EmployeeBalanceHours.AppearanceHeader.Options.UseTextOptions = true;
            this.band_EmployeeBalanceHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.band_EmployeeBalanceHours.Caption = "Saldo";
            this.band_EmployeeBalanceHours.Columns.Add(this.gcSaldoPlanned);
            this.band_EmployeeBalanceHours.Columns.Add(this.gcSaldoActual);
            this.band_EmployeeBalanceHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.band_EmployeeBalanceHours.Name = "band_EmployeeBalanceHours";
            this.band_EmployeeBalanceHours.OptionsBand.AllowMove = false;
            this.band_EmployeeBalanceHours.OptionsBand.AllowPress = false;
            this.band_EmployeeBalanceHours.OptionsBand.ShowInCustomizationForm = false;
            this.band_EmployeeBalanceHours.Visible = false;
            this.band_EmployeeBalanceHours.Width = 75;
            // 
            // gcSaldoPlanned
            // 
            this.gcSaldoPlanned.Caption = "Saldo(Planned)";
            this.gcSaldoPlanned.FieldName = "Saldo";
            this.gcSaldoPlanned.Name = "gcSaldoPlanned";
            this.gcSaldoPlanned.OptionsColumn.AllowEdit = false;
            this.gcSaldoPlanned.OptionsColumn.AllowFocus = false;
            this.gcSaldoPlanned.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoPlanned.OptionsColumn.AllowIncrementalSearch = false;
            this.gcSaldoPlanned.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoPlanned.OptionsColumn.AllowMove = false;
            this.gcSaldoPlanned.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoPlanned.OptionsColumn.ReadOnly = true;
            this.gcSaldoPlanned.OptionsColumn.ShowInCustomizationForm = false;
            this.gcSaldoPlanned.OptionsFilter.AllowAutoFilter = false;
            this.gcSaldoPlanned.OptionsFilter.AllowFilter = false;
            this.gcSaldoPlanned.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcSaldoPlanned.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcSaldoPlanned.Visible = true;
            // 
            // gcSaldoActual
            // 
            this.gcSaldoActual.Caption = "Saldo(Actual)";
            this.gcSaldoActual.FieldName = "ActualSaldo";
            this.gcSaldoActual.Name = "gcSaldoActual";
            this.gcSaldoActual.OptionsColumn.AllowEdit = false;
            this.gcSaldoActual.OptionsColumn.AllowFocus = false;
            this.gcSaldoActual.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoActual.OptionsColumn.AllowIncrementalSearch = false;
            this.gcSaldoActual.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoActual.OptionsColumn.AllowMove = false;
            this.gcSaldoActual.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcSaldoActual.OptionsColumn.ReadOnly = true;
            this.gcSaldoActual.OptionsColumn.ShowInCustomizationForm = false;
            this.gcSaldoActual.OptionsFilter.AllowAutoFilter = false;
            this.gcSaldoActual.OptionsFilter.AllowFilter = false;
            this.gcSaldoActual.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gcSaldoActual.RowIndex = 1;
            this.gcSaldoActual.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gcSaldoActual.Visible = true;
            // 
            // repItemCellData
            // 
            this.repItemCellData.Name = "repItemCellData";
            // 
            // ucActualCashDeskDailyInfo
            // 
            this.ucActualCashDeskDailyInfo.CashDeskInfo = null;
            this.ucActualCashDeskDailyInfo.ColorManager = null;
            this.ucActualCashDeskDailyInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucActualCashDeskDailyInfo.Entity = null;
            this.ucActualCashDeskDailyInfo.Location = new System.Drawing.Point(2, 278);
            this.ucActualCashDeskDailyInfo.LookAndFeel.SkinName = "iMaginary";
            this.ucActualCashDeskDailyInfo.Name = "ucActualCashDeskDailyInfo";
            this.ucActualCashDeskDailyInfo.Size = new System.Drawing.Size(794, 164);
            this.ucActualCashDeskDailyInfo.TabIndex = 2;
            this.ucActualCashDeskDailyInfo.Visible = false;
            // 
            // UCDayTimeRecording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCDayTimeRecording";
            this.Size = new System.Drawing.Size(798, 507);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_ShowHidePlannedRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookupHwgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCellData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.DateEdit deDate;
        private DevExpress.XtraEditors.LabelControl lbl_Date;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_Employee;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gc_Employee;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemEmployeeName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemCellData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_ContractWorkingHours;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcContractHoursPerWeek;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_SummOfAdditionalCharges;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcAdditionalHoursPlanned;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcAdditionalHoursActual;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_PlusMinusHours;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcPlusMinusHoursPlanned;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcPlusMinusHoursActual;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_EmployeeBalanceHours;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSaldoPlanned;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSaldoActual;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_MarkAsWorkingTime;
        private System.Windows.Forms.ToolStripMenuItem mi_Absence;
        private System.Windows.Forms.ToolStripMenuItem mi_MarkAsAbsence;
        private System.Windows.Forms.ToolStripMenuItem tm_ClearTime;
        private System.Windows.Forms.ToolStripMenuItem mi_CopyFromPlanned;
        private System.Windows.Forms.ToolStripMenuItem mi_CopyAllFromPlanned;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.LabelControl lblAvailableWorldBufferHours;
        private DevExpress.XtraEditors.LabelControl lblDifference;
        private DevExpress.XtraEditors.LabelControl lblPlannedHours;
        private DevExpress.XtraEditors.LabelControl lblMaximumPresence;
        private DevExpress.XtraEditors.LabelControl lblMinimumPresence;
        private DevExpress.XtraEditors.CheckEdit chk_ShowHidePlannedRow;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcHoursPlanned;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcHoursActual;
        private Baumax.ClientUI.FormEntities.TimeRecording.UCActualCashDeskDailyInfo ucActualCashDeskDailyInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gc_HWGR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookupHwgr;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band_HWGR;
        public DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView;
    }
}
