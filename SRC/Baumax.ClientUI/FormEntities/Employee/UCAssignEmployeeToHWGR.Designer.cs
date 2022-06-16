namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCAssignEmployeeToHWGR
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
            this.HwgrLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl();
            this.teEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_Employee = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_HWGR = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HwgrLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.HwgrLookUpCtrl);
            this.layoutControl1.Controls.Add(this.teEmployeeName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(367, 125);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // HwgrLookUpCtrl
            // 
            this.HwgrLookUpCtrl.CurrentEntity = null;
            this.HwgrLookUpCtrl.CurrentId = ((long)(0));
            this.HwgrLookUpCtrl.EntityList = null;
            this.HwgrLookUpCtrl.Location = new System.Drawing.Point(58, 38);
            this.HwgrLookUpCtrl.Name = "HwgrLookUpCtrl";
            this.HwgrLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.HwgrLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.HwgrLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Delete))});
            this.HwgrLookUpCtrl.Properties.NullText = "";
            this.HwgrLookUpCtrl.Size = new System.Drawing.Size(303, 20);
            this.HwgrLookUpCtrl.StyleController = this.layoutControl1;
            this.HwgrLookUpCtrl.TabIndex = 9;
            this.HwgrLookUpCtrl.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.HwgrLookUpCtrl_ButtonClick);
            // 
            // teEmployeeName
            // 
            this.teEmployeeName.Enabled = false;
            this.teEmployeeName.Location = new System.Drawing.Point(58, 7);
            this.teEmployeeName.Name = "teEmployeeName";
            this.teEmployeeName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teEmployeeName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teEmployeeName.Properties.ReadOnly = true;
            this.teEmployeeName.Size = new System.Drawing.Size(303, 20);
            this.teEmployeeName.StyleController = this.layoutControl1;
            this.teEmployeeName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_Employee,
            this.li_HWGR});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(367, 125);
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
            this.li_Employee.Size = new System.Drawing.Size(365, 31);
            this.li_Employee.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Employee.Text = "Employee";
            this.li_Employee.TextSize = new System.Drawing.Size(46, 20);
            // 
            // li_HWGR
            // 
            this.li_HWGR.Control = this.HwgrLookUpCtrl;
            this.li_HWGR.CustomizationFormText = "World";
            this.li_HWGR.Location = new System.Drawing.Point(0, 31);
            this.li_HWGR.Name = "li_HWGR";
            this.li_HWGR.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_HWGR.Size = new System.Drawing.Size(365, 92);
            this.li_HWGR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_HWGR.Text = "HWGR";
            this.li_HWGR.TextSize = new System.Drawing.Size(46, 20);
            // 
            // UCAssignEmployeeToHWGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCAssignEmployeeToHWGR";
            this.Size = new System.Drawing.Size(367, 125);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HwgrLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl HwgrLookUpCtrl;
        private DevExpress.XtraEditors.TextEdit teEmployeeName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem li_Employee;
        private DevExpress.XtraLayout.LayoutControlItem li_HWGR;
    }
}
