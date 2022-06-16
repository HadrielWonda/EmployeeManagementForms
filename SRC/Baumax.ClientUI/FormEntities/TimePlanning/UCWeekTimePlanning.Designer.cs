namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCWeekTimePlanning
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.teSunday = new DevExpress.XtraEditors.TextEdit();
            this.deMonday = new DevExpress.XtraEditors.DateEdit();
            this.lbl_Week = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuWeekly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_Absence = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_ClearTime = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Employee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemEmployeeNameEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gc_HWGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riHwgrLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gc_Monday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gc_Tuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Wednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Thursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Friday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Saturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Sunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_ContractWorkingHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_SummOfAdditionalCharges = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_PlusMinusHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EmployeeBalanceHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.storeWorldPanleInfo1 = new Baumax.ClientUI.FormEntities.Controls.StoreWorldPanleInfo();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonday.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemEmployeeNameEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHwgrLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.teSunday);
            this.panelControl1.Controls.Add(this.deMonday);
            this.panelControl1.Controls.Add(this.lbl_Week);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(889, 25);
            this.panelControl1.TabIndex = 1;
            // 
            // teSunday
            // 
            this.teSunday.Location = new System.Drawing.Point(205, 3);
            this.teSunday.Name = "teSunday";
            this.teSunday.Properties.ReadOnly = true;
            this.teSunday.Size = new System.Drawing.Size(110, 20);
            this.teSunday.TabIndex = 2;
            // 
            // deMonday
            // 
            this.deMonday.EditValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deMonday.Location = new System.Drawing.Point(89, 3);
            this.deMonday.Name = "deMonday";
            this.deMonday.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.Black;
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            this.deMonday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "22", 20, false, true, true, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.deMonday.Properties.MaxValue = new System.DateTime(2079, 6, 6, 0, 0, 0, 0);
            this.deMonday.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deMonday.Properties.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deMonday.Properties.NullText = "01.01.1900";
            this.deMonday.Properties.ShowWeekNumbers = true;
            this.deMonday.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deMonday.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deMonday.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFourDayWeek;
            this.deMonday.Size = new System.Drawing.Size(110, 20);
            this.deMonday.TabIndex = 1;
            this.deMonday.DateTimeChanged += new System.EventHandler(this.deMonday_DateTimeChanged);
            // 
            // lbl_Week
            // 
            this.lbl_Week.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Week.Location = new System.Drawing.Point(5, 6);
            this.lbl_Week.Name = "lbl_Week";
            this.lbl_Week.Size = new System.Drawing.Size(78, 13);
            this.lbl_Week.TabIndex = 0;
            this.lbl_Week.Text = "Week";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 25);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(889, 387);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuWeekly;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimes,
            this.repositoryItemEmployeeNameEdit,
            this.riHwgrLookUpEdit});
            this.gridControl.Size = new System.Drawing.Size(885, 383);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView2});
            // 
            // contextMenuWeekly
            // 
            this.contextMenuWeekly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Absence,
            this.toolStripSeparator1,
            this.mi_Copy,
            this.mi_Paste,
            this.mi_ClearTime});
            this.contextMenuWeekly.Name = "contextMenuWeekly";
            this.contextMenuWeekly.Size = new System.Drawing.Size(140, 98);
            this.contextMenuWeekly.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuWeekly_Opening);
            // 
            // mi_Absence
            // 
            this.mi_Absence.Name = "mi_Absence";
            this.mi_Absence.Size = new System.Drawing.Size(139, 22);
            this.mi_Absence.Text = "Absence";
            this.mi_Absence.Click += new System.EventHandler(this.mi_Absence_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // mi_Copy
            // 
            this.mi_Copy.Name = "mi_Copy";
            this.mi_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mi_Copy.Size = new System.Drawing.Size(139, 22);
            this.mi_Copy.Text = "Copy";
            this.mi_Copy.Click += new System.EventHandler(this.mi_Copy_Click);
            // 
            // mi_Paste
            // 
            this.mi_Paste.Name = "mi_Paste";
            this.mi_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mi_Paste.Size = new System.Drawing.Size(139, 22);
            this.mi_Paste.Text = "Paste";
            this.mi_Paste.Click += new System.EventHandler(this.mi_Paste_Click);
            // 
            // mi_ClearTime
            // 
            this.mi_ClearTime.Name = "mi_ClearTime";
            this.mi_ClearTime.Size = new System.Drawing.Size(139, 22);
            this.mi_ClearTime.Text = "Clear";
            this.mi_ClearTime.Click += new System.EventHandler(this.mi_Clear_Click);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.ColumnPanelRowHeight = 50;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Employee,
            this.gc_HWGR,
            this.gc_Monday,
            this.gc_Tuesday,
            this.gc_Wednesday,
            this.gc_Thursday,
            this.gc_Friday,
            this.gc_Saturday,
            this.gc_Sunday,
            this.gc_ContractWorkingHours,
            this.gc_SummOfAdditionalCharges,
            this.gc_PlusMinusHours,
            this.gc_EmployeeBalanceHours});
            this.gridView.FooterPanelHeight = 80;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowRowSizing = true;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsFilter.AllowMRUFilterList = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            this.gridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_ValidatingEditor);
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.Click += new System.EventHandler(this.gridView_Click);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell_1);
            this.gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
            this.gridView.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridView_CalcRowHeight);
            this.gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
            this.gridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView_ShowingEditor);
            // 
            // gc_Employee
            // 
            this.gc_Employee.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Employee.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Employee.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Employee.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gc_Employee.Caption = "Employee";
            this.gc_Employee.ColumnEdit = this.repositoryItemEmployeeNameEdit;
            this.gc_Employee.FieldName = "FullName";
            this.gc_Employee.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gc_Employee.MinWidth = 50;
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.OptionsColumn.AllowEdit = false;
            this.gc_Employee.OptionsColumn.AllowIncrementalSearch = false;
            this.gc_Employee.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Employee.OptionsColumn.ReadOnly = true;
            this.gc_Employee.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Employee.OptionsFilter.AllowAutoFilter = false;
            this.gc_Employee.OptionsFilter.AllowFilter = false;
            this.gc_Employee.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gc_Employee.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_Employee.Visible = true;
            this.gc_Employee.VisibleIndex = 0;
            this.gc_Employee.Width = 120;
            // 
            // repositoryItemEmployeeNameEdit
            // 
            this.repositoryItemEmployeeNameEdit.Name = "repositoryItemEmployeeNameEdit";
            this.repositoryItemEmployeeNameEdit.ReadOnly = true;
            // 
            // gc_HWGR
            // 
            this.gc_HWGR.Caption = "HWGR";
            this.gc_HWGR.ColumnEdit = this.riHwgrLookUpEdit;
            this.gc_HWGR.FieldName = "OrderHWGR";
            this.gc_HWGR.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gc_HWGR.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gc_HWGR.Name = "gc_HWGR";
            this.gc_HWGR.OptionsColumn.AllowEdit = false;
            this.gc_HWGR.OptionsColumn.AllowIncrementalSearch = false;
            this.gc_HWGR.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_HWGR.OptionsColumn.ReadOnly = true;
            this.gc_HWGR.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_HWGR.OptionsFilter.AllowAutoFilter = false;
            this.gc_HWGR.OptionsFilter.AllowFilter = false;
            this.gc_HWGR.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gc_HWGR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_HWGR.Visible = true;
            this.gc_HWGR.VisibleIndex = 1;
            this.gc_HWGR.Width = 51;
            // 
            // riHwgrLookUpEdit
            // 
            this.riHwgrLookUpEdit.AutoHeight = false;
            this.riHwgrLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riHwgrLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.riHwgrLookUpEdit.DisplayMember = "Name";
            this.riHwgrLookUpEdit.Name = "riHwgrLookUpEdit";
            this.riHwgrLookUpEdit.NullText = "";
            this.riHwgrLookUpEdit.ValueMember = "ID";
            // 
            // gc_Monday
            // 
            this.gc_Monday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Monday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Monday.Caption = "Monday";
            this.gc_Monday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Monday.FieldName = "gc_Monday";
            this.gc_Monday.Name = "gc_Monday";
            this.gc_Monday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Monday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Monday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Monday.OptionsFilter.AllowFilter = false;
            this.gc_Monday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Monday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Monday.Visible = true;
            this.gc_Monday.VisibleIndex = 2;
            this.gc_Monday.Width = 67;
            // 
            // repositoryItemTimes
            // 
            this.repositoryItemTimes.Appearance.BackColor = System.Drawing.Color.White;
            this.repositoryItemTimes.Appearance.BackColor2 = System.Drawing.Color.White;
            this.repositoryItemTimes.Appearance.Options.UseBackColor = true;
            this.repositoryItemTimes.Name = "repositoryItemTimes";
            this.repositoryItemTimes.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.repositoryItemTimes_FormatEditValue);
            // 
            // gc_Tuesday
            // 
            this.gc_Tuesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Tuesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Tuesday.Caption = "Tuesday";
            this.gc_Tuesday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Tuesday.FieldName = "gc_Tuesday";
            this.gc_Tuesday.Name = "gc_Tuesday";
            this.gc_Tuesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Tuesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Tuesday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Tuesday.OptionsFilter.AllowFilter = false;
            this.gc_Tuesday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Tuesday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Tuesday.Visible = true;
            this.gc_Tuesday.VisibleIndex = 3;
            this.gc_Tuesday.Width = 67;
            // 
            // gc_Wednesday
            // 
            this.gc_Wednesday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Wednesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Wednesday.Caption = "Wednesday";
            this.gc_Wednesday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Wednesday.FieldName = "gc_Wednesday";
            this.gc_Wednesday.Name = "gc_Wednesday";
            this.gc_Wednesday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Wednesday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Wednesday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Wednesday.OptionsFilter.AllowFilter = false;
            this.gc_Wednesday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Wednesday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Wednesday.Visible = true;
            this.gc_Wednesday.VisibleIndex = 4;
            this.gc_Wednesday.Width = 67;
            // 
            // gc_Thursday
            // 
            this.gc_Thursday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Thursday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Thursday.Caption = "Thursday";
            this.gc_Thursday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Thursday.FieldName = "gc_Thursday";
            this.gc_Thursday.Name = "gc_Thursday";
            this.gc_Thursday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Thursday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Thursday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Thursday.OptionsFilter.AllowFilter = false;
            this.gc_Thursday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Thursday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Thursday.Visible = true;
            this.gc_Thursday.VisibleIndex = 5;
            this.gc_Thursday.Width = 67;
            // 
            // gc_Friday
            // 
            this.gc_Friday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Friday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Friday.Caption = "Friday";
            this.gc_Friday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Friday.FieldName = "gc_Friday";
            this.gc_Friday.Name = "gc_Friday";
            this.gc_Friday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Friday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Friday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Friday.OptionsFilter.AllowFilter = false;
            this.gc_Friday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Friday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Friday.Visible = true;
            this.gc_Friday.VisibleIndex = 6;
            this.gc_Friday.Width = 67;
            // 
            // gc_Saturday
            // 
            this.gc_Saturday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Saturday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Saturday.Caption = "Saturday";
            this.gc_Saturday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Saturday.FieldName = "gc_Saturday";
            this.gc_Saturday.Name = "gc_Saturday";
            this.gc_Saturday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Saturday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Saturday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Saturday.OptionsFilter.AllowFilter = false;
            this.gc_Saturday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Saturday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Saturday.Visible = true;
            this.gc_Saturday.VisibleIndex = 7;
            this.gc_Saturday.Width = 67;
            // 
            // gc_Sunday
            // 
            this.gc_Sunday.AppearanceHeader.Options.UseTextOptions = true;
            this.gc_Sunday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_Sunday.Caption = "Sunday";
            this.gc_Sunday.ColumnEdit = this.repositoryItemTimes;
            this.gc_Sunday.FieldName = "gc_Sunday";
            this.gc_Sunday.Name = "gc_Sunday";
            this.gc_Sunday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Sunday.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Sunday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Sunday.OptionsFilter.AllowFilter = false;
            this.gc_Sunday.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_Sunday.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Sunday.Visible = true;
            this.gc_Sunday.VisibleIndex = 8;
            this.gc_Sunday.Width = 87;
            // 
            // gc_ContractWorkingHours
            // 
            this.gc_ContractWorkingHours.AppearanceCell.Options.UseTextOptions = true;
            this.gc_ContractWorkingHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_ContractWorkingHours.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_ContractWorkingHours.Caption = "Working hours";
            this.gc_ContractWorkingHours.FieldName = "gc_WorkingHours";
            this.gc_ContractWorkingHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_ContractWorkingHours.MinWidth = 50;
            this.gc_ContractWorkingHours.Name = "gc_ContractWorkingHours";
            this.gc_ContractWorkingHours.OptionsColumn.AllowEdit = false;
            this.gc_ContractWorkingHours.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_ContractWorkingHours.OptionsColumn.ReadOnly = true;
            this.gc_ContractWorkingHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_ContractWorkingHours.OptionsFilter.AllowAutoFilter = false;
            this.gc_ContractWorkingHours.OptionsFilter.AllowFilter = false;
            this.gc_ContractWorkingHours.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_ContractWorkingHours.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_ContractWorkingHours.Visible = true;
            this.gc_ContractWorkingHours.VisibleIndex = 9;
            this.gc_ContractWorkingHours.Width = 50;
            // 
            // gc_SummOfAdditionalCharges
            // 
            this.gc_SummOfAdditionalCharges.AppearanceCell.Options.UseTextOptions = true;
            this.gc_SummOfAdditionalCharges.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_SummOfAdditionalCharges.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_SummOfAdditionalCharges.Caption = "Summ Of Additional Hours";
            this.gc_SummOfAdditionalCharges.FieldName = "gc_SummOfAddHours";
            this.gc_SummOfAdditionalCharges.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_SummOfAdditionalCharges.MinWidth = 50;
            this.gc_SummOfAdditionalCharges.Name = "gc_SummOfAdditionalCharges";
            this.gc_SummOfAdditionalCharges.OptionsColumn.AllowEdit = false;
            this.gc_SummOfAdditionalCharges.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_SummOfAdditionalCharges.OptionsColumn.ReadOnly = true;
            this.gc_SummOfAdditionalCharges.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_SummOfAdditionalCharges.OptionsFilter.AllowAutoFilter = false;
            this.gc_SummOfAdditionalCharges.OptionsFilter.AllowFilter = false;
            this.gc_SummOfAdditionalCharges.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_SummOfAdditionalCharges.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_SummOfAdditionalCharges.Visible = true;
            this.gc_SummOfAdditionalCharges.VisibleIndex = 10;
            this.gc_SummOfAdditionalCharges.Width = 50;
            // 
            // gc_PlusMinusHours
            // 
            this.gc_PlusMinusHours.AppearanceCell.Options.UseTextOptions = true;
            this.gc_PlusMinusHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_PlusMinusHours.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_PlusMinusHours.Caption = "(+/-)Hours";
            this.gc_PlusMinusHours.FieldName = "gc_PlusMinusHours";
            this.gc_PlusMinusHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_PlusMinusHours.MinWidth = 50;
            this.gc_PlusMinusHours.Name = "gc_PlusMinusHours";
            this.gc_PlusMinusHours.OptionsColumn.AllowEdit = false;
            this.gc_PlusMinusHours.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_PlusMinusHours.OptionsColumn.ReadOnly = true;
            this.gc_PlusMinusHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_PlusMinusHours.OptionsFilter.AllowAutoFilter = false;
            this.gc_PlusMinusHours.OptionsFilter.AllowFilter = false;
            this.gc_PlusMinusHours.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_PlusMinusHours.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_PlusMinusHours.Visible = true;
            this.gc_PlusMinusHours.VisibleIndex = 11;
            this.gc_PlusMinusHours.Width = 50;
            // 
            // gc_EmployeeBalanceHours
            // 
            this.gc_EmployeeBalanceHours.AppearanceCell.Options.UseTextOptions = true;
            this.gc_EmployeeBalanceHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gc_EmployeeBalanceHours.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gc_EmployeeBalanceHours.Caption = "Emloyee Balance Hours(Saldo)";
            this.gc_EmployeeBalanceHours.FieldName = "gc_EmloyeeBalanceHours";
            this.gc_EmployeeBalanceHours.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gc_EmployeeBalanceHours.MinWidth = 50;
            this.gc_EmployeeBalanceHours.Name = "gc_EmployeeBalanceHours";
            this.gc_EmployeeBalanceHours.OptionsColumn.AllowEdit = false;
            this.gc_EmployeeBalanceHours.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_EmployeeBalanceHours.OptionsColumn.ReadOnly = true;
            this.gc_EmployeeBalanceHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_EmployeeBalanceHours.OptionsFilter.AllowAutoFilter = false;
            this.gc_EmployeeBalanceHours.OptionsFilter.AllowFilter = false;
            this.gc_EmployeeBalanceHours.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gc_EmployeeBalanceHours.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_EmployeeBalanceHours.Visible = true;
            this.gc_EmployeeBalanceHours.VisibleIndex = 12;
            this.gc_EmployeeBalanceHours.Width = 50;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl;
            this.gridView2.Name = "gridView2";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.storeWorldPanleInfo1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 412);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(889, 33);
            this.panelControl3.TabIndex = 3;
            this.panelControl3.Visible = false;
            // 
            // storeWorldPanleInfo1
            // 
            this.storeWorldPanleInfo1.ColorManager = null;
            this.storeWorldPanleInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storeWorldPanleInfo1.Entity = null;
            this.storeWorldPanleInfo1.Location = new System.Drawing.Point(0, 0);
            this.storeWorldPanleInfo1.LookAndFeel.SkinName = "iMaginary";
            this.storeWorldPanleInfo1.Name = "storeWorldPanleInfo1";
            this.storeWorldPanleInfo1.Size = new System.Drawing.Size(889, 33);
            this.storeWorldPanleInfo1.TabIndex = 0;
            this.storeWorldPanleInfo1.WorldInfo = null;
            // 
            // UCWeekTimePlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWeekTimePlanning";
            this.Size = new System.Drawing.Size(889, 445);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teSunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonday.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuWeekly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemEmployeeNameEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riHwgrLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Week;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Monday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Tuesday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Wednesday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Thursday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Friday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Saturday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Sunday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_ContractWorkingHours;
        private DevExpress.XtraGrid.Columns.GridColumn gc_SummOfAdditionalCharges;
        private DevExpress.XtraGrid.Columns.GridColumn gc_PlusMinusHours;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EmployeeBalanceHours;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit teSunday;
        private DevExpress.XtraEditors.DateEdit deMonday;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemTimes;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemEmployeeNameEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuWeekly;
        private System.Windows.Forms.ToolStripMenuItem mi_Copy;
        private System.Windows.Forms.ToolStripMenuItem mi_Paste;
        private System.Windows.Forms.ToolStripMenuItem mi_ClearTime;
        private System.Windows.Forms.ToolStripMenuItem mi_Absence;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.Columns.GridColumn gc_HWGR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riHwgrLookUpEdit;
        private Baumax.ClientUI.FormEntities.Controls.StoreWorldPanleInfo storeWorldPanleInfo1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;

    }
}
