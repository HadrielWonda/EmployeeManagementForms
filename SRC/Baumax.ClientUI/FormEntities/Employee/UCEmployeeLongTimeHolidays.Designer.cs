namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCEmployeeLongTimeHolidays
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridLookUpEditEmployees = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpAbsence = new DevExpress.XtraEditors.LookUpEdit();
            this.deBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.deEndDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_BeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_LongTimeAbsence = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_Employee = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditEmployees.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAbsence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_LongTimeAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.gridLookUpEditEmployees);
            this.layoutControl1.Controls.Add(this.lookUpAbsence);
            this.layoutControl1.Controls.Add(this.deBeginDate);
            this.layoutControl1.Controls.Add(this.deEndDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(392, 204);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridLookUpEditEmployees
            // 
            this.gridLookUpEditEmployees.Location = new System.Drawing.Point(63, 7);
            this.gridLookUpEditEmployees.Name = "gridLookUpEditEmployees";
            this.gridLookUpEditEmployees.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.gridLookUpEditEmployees.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.gridLookUpEditEmployees.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditEmployees.Properties.DisplayMember = "FullName";
            this.gridLookUpEditEmployees.Properties.NullText = "";
            this.gridLookUpEditEmployees.Properties.ValueMember = "ID";
            this.gridLookUpEditEmployees.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEditEmployees.Size = new System.Drawing.Size(323, 20);
            this.gridLookUpEditEmployees.StyleController = this.layoutControl1;
            this.gridLookUpEditEmployees.TabIndex = 8;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_LastName,
            this.gc_FirstName});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridLookUpEdit1View.OptionsFilter.AllowFilterEditor = false;
            this.gridLookUpEdit1View.OptionsFilter.AllowMRUFilterList = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableColumnMenu = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableFooterMenu = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gc_LastName
            // 
            this.gc_LastName.Caption = "Last name";
            this.gc_LastName.FieldName = "LastName";
            this.gc_LastName.Name = "gc_LastName";
            this.gc_LastName.OptionsColumn.AllowEdit = false;
            this.gc_LastName.OptionsColumn.ReadOnly = true;
            this.gc_LastName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LastName.OptionsFilter.AllowFilter = false;
            this.gc_LastName.Visible = true;
            this.gc_LastName.VisibleIndex = 0;
            // 
            // gc_FirstName
            // 
            this.gc_FirstName.Caption = "First name";
            this.gc_FirstName.FieldName = "FirstName";
            this.gc_FirstName.Name = "gc_FirstName";
            this.gc_FirstName.OptionsColumn.AllowEdit = false;
            this.gc_FirstName.OptionsColumn.ReadOnly = true;
            this.gc_FirstName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_FirstName.OptionsFilter.AllowFilter = false;
            this.gc_FirstName.Visible = true;
            this.gc_FirstName.VisibleIndex = 1;
            // 
            // lookUpAbsence
            // 
            this.lookUpAbsence.Location = new System.Drawing.Point(63, 38);
            this.lookUpAbsence.Name = "lookUpAbsence";
            this.lookUpAbsence.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lookUpAbsence.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lookUpAbsence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpAbsence.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodeName", "LongTimeAbsence", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpAbsence.Properties.DisplayMember = "CodeName";
            this.lookUpAbsence.Properties.NullText = "";
            this.lookUpAbsence.Properties.ValueMember = "ID";
            this.lookUpAbsence.Size = new System.Drawing.Size(323, 20);
            this.lookUpAbsence.StyleController = this.layoutControl1;
            this.lookUpAbsence.TabIndex = 7;
            // 
            // deBeginDate
            // 
            this.deBeginDate.EditValue = null;
            this.deBeginDate.Location = new System.Drawing.Point(63, 69);
            this.deBeginDate.Name = "deBeginDate";
            this.deBeginDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.deBeginDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.deBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginDate.Size = new System.Drawing.Size(323, 20);
            this.deBeginDate.StyleController = this.layoutControl1;
            this.deBeginDate.TabIndex = 6;
            // 
            // deEndDate
            // 
            this.deEndDate.EditValue = null;
            this.deEndDate.Location = new System.Drawing.Point(63, 100);
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndDate.Size = new System.Drawing.Size(323, 20);
            this.deEndDate.StyleController = this.layoutControl1;
            this.deEndDate.TabIndex = 5;
            this.deEndDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deEndDate_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowCustomizeChildren = false;
            this.layoutControlGroup1.AllowHide = false;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_BeginDate,
            this.li_EndDate,
            this.li_LongTimeAbsence,
            this.li_Employee});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.ShowInCustomizationForm = false;
            this.layoutControlGroup1.Size = new System.Drawing.Size(392, 204);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_BeginDate
            // 
            this.li_BeginDate.Control = this.deBeginDate;
            this.li_BeginDate.CustomizationFormText = "Begin date";
            this.li_BeginDate.Location = new System.Drawing.Point(0, 62);
            this.li_BeginDate.Name = "li_BeginDate";
            this.li_BeginDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_BeginDate.Size = new System.Drawing.Size(390, 31);
            this.li_BeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_BeginDate.Text = "Begin date";
            this.li_BeginDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_EndDate
            // 
            this.li_EndDate.Control = this.deEndDate;
            this.li_EndDate.CustomizationFormText = "End date";
            this.li_EndDate.Location = new System.Drawing.Point(0, 93);
            this.li_EndDate.Name = "li_EndDate";
            this.li_EndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_EndDate.Size = new System.Drawing.Size(390, 109);
            this.li_EndDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_EndDate.Text = "End date";
            this.li_EndDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_LongTimeAbsence
            // 
            this.li_LongTimeAbsence.Control = this.lookUpAbsence;
            this.li_LongTimeAbsence.CustomizationFormText = "Absence";
            this.li_LongTimeAbsence.Location = new System.Drawing.Point(0, 31);
            this.li_LongTimeAbsence.Name = "li_LongTimeAbsence";
            this.li_LongTimeAbsence.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_LongTimeAbsence.Size = new System.Drawing.Size(390, 31);
            this.li_LongTimeAbsence.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_LongTimeAbsence.Text = "Absence";
            this.li_LongTimeAbsence.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_Employee
            // 
            this.li_Employee.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.li_Employee.AppearanceItemCaption.Options.UseForeColor = true;
            this.li_Employee.Control = this.gridLookUpEditEmployees;
            this.li_Employee.CustomizationFormText = "layoutControlItem5";
            this.li_Employee.Location = new System.Drawing.Point(0, 0);
            this.li_Employee.Name = "li_Employee";
            this.li_Employee.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Employee.Size = new System.Drawing.Size(390, 31);
            this.li_Employee.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Employee.Text = "Employee";
            this.li_Employee.TextSize = new System.Drawing.Size(51, 20);
            // 
            // UCEmployeeLongTimeHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCEmployeeLongTimeHolidays";
            this.Size = new System.Drawing.Size(392, 204);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditEmployees.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAbsence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_LongTimeAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lookUpAbsence;
        private DevExpress.XtraEditors.DateEdit deBeginDate;
        private DevExpress.XtraEditors.DateEdit deEndDate;
        private DevExpress.XtraLayout.LayoutControlItem li_BeginDate;
        private DevExpress.XtraLayout.LayoutControlItem li_EndDate;
        private DevExpress.XtraLayout.LayoutControlItem li_LongTimeAbsence;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem li_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LastName;
    }
}
