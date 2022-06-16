namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCAssignEmployeeToWorld
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
            this.storeWorldLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.deBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.teEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_Employee = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_BeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_World = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.storeWorldLookUpCtrl);
            this.layoutControl1.Controls.Add(this.deEndTime);
            this.layoutControl1.Controls.Add(this.deBeginTime);
            this.layoutControl1.Controls.Add(this.teEmployeeName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(330, 206);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // storeWorldLookUpCtrl
            // 
            this.storeWorldLookUpCtrl.CurrentEntity = null;
            this.storeWorldLookUpCtrl.CurrentId = ((long)(0));
            this.storeWorldLookUpCtrl.EntityList = null;
            this.storeWorldLookUpCtrl.Location = new System.Drawing.Point(63, 38);
            this.storeWorldLookUpCtrl.Name = "storeWorldLookUpCtrl";
            this.storeWorldLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.storeWorldLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.storeWorldLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeWorldLookUpCtrl.Properties.NullText = "";
            this.storeWorldLookUpCtrl.Size = new System.Drawing.Size(261, 20);
            this.storeWorldLookUpCtrl.StyleController = this.layoutControl1;
            this.storeWorldLookUpCtrl.TabIndex = 9;
            this.storeWorldLookUpCtrl.WorldId = ((long)(0));
            // 
            // deEndTime
            // 
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(63, 100);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Size = new System.Drawing.Size(261, 20);
            this.deEndTime.StyleController = this.layoutControl1;
            this.deEndTime.TabIndex = 7;
            // 
            // deBeginTime
            // 
            this.deBeginTime.EditValue = null;
            this.deBeginTime.Location = new System.Drawing.Point(63, 69);
            this.deBeginTime.Name = "deBeginTime";
            this.deBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginTime.Size = new System.Drawing.Size(261, 20);
            this.deBeginTime.StyleController = this.layoutControl1;
            this.deBeginTime.TabIndex = 6;
            // 
            // teEmployeeName
            // 
            this.teEmployeeName.Enabled = false;
            this.teEmployeeName.Location = new System.Drawing.Point(63, 7);
            this.teEmployeeName.Name = "teEmployeeName";
            this.teEmployeeName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teEmployeeName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teEmployeeName.Properties.ReadOnly = true;
            this.teEmployeeName.Size = new System.Drawing.Size(261, 20);
            this.teEmployeeName.StyleController = this.layoutControl1;
            this.teEmployeeName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_Employee,
            this.li_BeginDate,
            this.li_EndDate,
            this.li_World});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(330, 206);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_Employee
            // 
            this.li_Employee.Control = this.teEmployeeName;
            this.li_Employee.CustomizationFormText = "Employee";
            this.li_Employee.Location = new System.Drawing.Point(0, 0);
            this.li_Employee.Name = "li_Employee";
            this.li_Employee.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Employee.Size = new System.Drawing.Size(328, 31);
            this.li_Employee.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Employee.Text = "Employee";
            this.li_Employee.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_BeginDate
            // 
            this.li_BeginDate.Control = this.deBeginTime;
            this.li_BeginDate.CustomizationFormText = "Begin date";
            this.li_BeginDate.Location = new System.Drawing.Point(0, 62);
            this.li_BeginDate.Name = "li_BeginDate";
            this.li_BeginDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_BeginDate.Size = new System.Drawing.Size(328, 31);
            this.li_BeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_BeginDate.Text = "Begin date";
            this.li_BeginDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_EndDate
            // 
            this.li_EndDate.Control = this.deEndTime;
            this.li_EndDate.CustomizationFormText = "End Date";
            this.li_EndDate.Location = new System.Drawing.Point(0, 93);
            this.li_EndDate.Name = "li_EndDate";
            this.li_EndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_EndDate.Size = new System.Drawing.Size(328, 111);
            this.li_EndDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_EndDate.Text = "End Date";
            this.li_EndDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_World
            // 
            this.li_World.Control = this.storeWorldLookUpCtrl;
            this.li_World.CustomizationFormText = "World";
            this.li_World.Location = new System.Drawing.Point(0, 31);
            this.li_World.Name = "li_World";
            this.li_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_World.Size = new System.Drawing.Size(328, 31);
            this.li_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_World.Text = "World";
            this.li_World.TextSize = new System.Drawing.Size(51, 20);
            // 
            // UCAssignEmployeeToWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCAssignEmployeeToWorld";
            this.Size = new System.Drawing.Size(330, 206);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit teEmployeeName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem li_Employee;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.DateEdit deBeginTime;
        private DevExpress.XtraLayout.LayoutControlItem li_BeginDate;
        private DevExpress.XtraLayout.LayoutControlItem li_EndDate;
        private Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl storeWorldLookUpCtrl;
        private DevExpress.XtraLayout.LayoutControlItem li_World;

    }
}
