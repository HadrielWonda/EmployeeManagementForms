namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCAssignToEmployee
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
            this.gridControlEmployee = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teEmployee = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_Employee = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlEmployee);
            this.layoutControl1.Controls.Add(this.teEmployee);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(411, 303);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlEmployee
            // 
            this.gridControlEmployee.EmbeddedNavigator.Name = "";
            this.gridControlEmployee.Location = new System.Drawing.Point(7, 38);
            this.gridControlEmployee.MainView = this.gridViewEmployee;
            this.gridControlEmployee.Name = "gridControlEmployee";
            this.gridControlEmployee.Size = new System.Drawing.Size(398, 259);
            this.gridControlEmployee.TabIndex = 5;
            this.gridControlEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmployee});
            this.gridControlEmployee.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlEmployee_MouseDoubleClick);
            // 
            // gridViewEmployee
            // 
            this.gridViewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_FirstName,
            this.gc_LastName,
            this.gc_CreateDate});
            this.gridViewEmployee.GridControl = this.gridControlEmployee;
            this.gridViewEmployee.Name = "gridViewEmployee";
            this.gridViewEmployee.OptionsView.ShowAutoFilterRow = true;
            this.gridViewEmployee.OptionsView.ShowGroupPanel = false;
            // 
            // gc_FirstName
            // 
            this.gc_FirstName.Caption = "First Name";
            this.gc_FirstName.FieldName = "FirstName";
            this.gc_FirstName.Name = "gc_FirstName";
            this.gc_FirstName.OptionsColumn.AllowEdit = false;
            this.gc_FirstName.OptionsColumn.ReadOnly = true;
            this.gc_FirstName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_FirstName.OptionsFilter.AllowFilter = false;
            this.gc_FirstName.Visible = true;
            this.gc_FirstName.VisibleIndex = 0;
            // 
            // gc_LastName
            // 
            this.gc_LastName.Caption = "Last Name";
            this.gc_LastName.FieldName = "LastName";
            this.gc_LastName.Name = "gc_LastName";
            this.gc_LastName.OptionsColumn.AllowEdit = false;
            this.gc_LastName.OptionsColumn.ReadOnly = true;
            this.gc_LastName.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LastName.OptionsFilter.AllowFilter = false;
            this.gc_LastName.Visible = true;
            this.gc_LastName.VisibleIndex = 1;
            // 
            // gc_CreateDate
            // 
            this.gc_CreateDate.Caption = "Create date";
            this.gc_CreateDate.FieldName = "CreateDate";
            this.gc_CreateDate.Name = "gc_CreateDate";
            this.gc_CreateDate.OptionsColumn.AllowEdit = false;
            this.gc_CreateDate.OptionsColumn.ReadOnly = true;
            this.gc_CreateDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_CreateDate.OptionsFilter.AllowFilter = false;
            this.gc_CreateDate.Visible = true;
            this.gc_CreateDate.VisibleIndex = 2;
            // 
            // teEmployee
            // 
            this.teEmployee.Location = new System.Drawing.Point(58, 7);
            this.teEmployee.Name = "teEmployee";
            this.teEmployee.Size = new System.Drawing.Size(347, 20);
            this.teEmployee.StyleController = this.layoutControl1;
            this.teEmployee.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_Employee,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(411, 303);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_Employee
            // 
            this.li_Employee.Control = this.teEmployee;
            this.li_Employee.CustomizationFormText = "Employee";
            this.li_Employee.Location = new System.Drawing.Point(0, 0);
            this.li_Employee.Name = "li_Employee";
            this.li_Employee.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Employee.Size = new System.Drawing.Size(409, 31);
            this.li_Employee.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Employee.Text = "Employee";
            this.li_Employee.TextSize = new System.Drawing.Size(46, 20);
            this.li_Employee.TextVisible = true;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlEmployee;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(409, 270);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // UCAssignToEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCAssignToEmployee";
            this.Size = new System.Drawing.Size(411, 303);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LastName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_CreateDate;
        private DevExpress.XtraEditors.TextEdit teEmployee;
        private DevExpress.XtraLayout.LayoutControlItem li_Employee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
