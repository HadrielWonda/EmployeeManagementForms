namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormAssignEmployeeToStore
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
            this.lbl_DelegateToStore = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Employee = new DevExpress.XtraEditors.LabelControl();
            this.teEmployee = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbl_BeginTime = new DevExpress.XtraEditors.LabelControl();
            this.lbl_EndTime = new DevExpress.XtraEditors.LabelControl();
            this.deBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_DelegateToStore);
            this.panelTop.Size = new System.Drawing.Size(492, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.deEndTime);
            this.panelClient.Controls.Add(this.deBeginTime);
            this.panelClient.Controls.Add(this.lbl_EndTime);
            this.panelClient.Controls.Add(this.lbl_BeginTime);
            this.panelClient.Controls.Add(this.gridControl1);
            this.panelClient.Controls.Add(this.teEmployee);
            this.panelClient.Controls.Add(this.lbl_Employee);
            this.panelClient.Size = new System.Drawing.Size(492, 290);
            // 
            // button_OK
            // 
            this.button_OK.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(266, 8);
            this.button_Cancel.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 324);
            this.panelBottom.Size = new System.Drawing.Size(492, 40);
            this.panelBottom.TabIndex = 0;
            // 
            // lbl_DelegateToStore
            // 
            this.lbl_DelegateToStore.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DelegateToStore.Appearance.Options.UseFont = true;
            this.lbl_DelegateToStore.Appearance.Options.UseTextOptions = true;
            this.lbl_DelegateToStore.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_DelegateToStore.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DelegateToStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DelegateToStore.Location = new System.Drawing.Point(2, 2);
            this.lbl_DelegateToStore.Name = "lbl_DelegateToStore";
            this.lbl_DelegateToStore.Size = new System.Drawing.Size(488, 30);
            this.lbl_DelegateToStore.TabIndex = 0;
            this.lbl_DelegateToStore.Text = "Delegate employee to store";
            // 
            // lbl_Employee
            // 
            this.lbl_Employee.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Employee.Location = new System.Drawing.Point(11, 6);
            this.lbl_Employee.Name = "lbl_Employee";
            this.lbl_Employee.Size = new System.Drawing.Size(99, 13);
            this.lbl_Employee.TabIndex = 0;
            this.lbl_Employee.Text = "Employee";
            // 
            // teEmployee
            // 
            this.teEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teEmployee.Enabled = false;
            this.teEmployee.Location = new System.Drawing.Point(116, 4);
            this.teEmployee.Name = "teEmployee";
            this.teEmployee.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teEmployee.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teEmployee.Size = new System.Drawing.Size(371, 20);
            this.teEmployee.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(5, 71);
            this.gridControl1.MainView = this.gridViewEntities;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(482, 213);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Store});
            this.gridViewEntities.GridControl = this.gridControl1;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsBehavior.Editable = false;
            this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
            this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.OptionsView.ShowAutoFilterRow = true;
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
            // 
            // gc_Store
            // 
            this.gc_Store.Caption = "Store";
            this.gc_Store.FieldName = "Name";
            this.gc_Store.Name = "gc_Store";
            this.gc_Store.OptionsColumn.AllowEdit = false;
            this.gc_Store.OptionsColumn.ReadOnly = true;
            this.gc_Store.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Store.OptionsFilter.AllowFilter = false;
            this.gc_Store.Visible = true;
            this.gc_Store.VisibleIndex = 0;
            // 
            // lbl_BeginTime
            // 
            this.lbl_BeginTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_BeginTime.Location = new System.Drawing.Point(12, 44);
            this.lbl_BeginTime.Name = "lbl_BeginTime";
            this.lbl_BeginTime.Size = new System.Drawing.Size(98, 13);
            this.lbl_BeginTime.TabIndex = 3;
            this.lbl_BeginTime.Text = "BeginTime";
            // 
            // lbl_EndTime
            // 
            this.lbl_EndTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EndTime.Location = new System.Drawing.Point(244, 44);
            this.lbl_EndTime.Name = "lbl_EndTime";
            this.lbl_EndTime.Size = new System.Drawing.Size(94, 13);
            this.lbl_EndTime.TabIndex = 4;
            this.lbl_EndTime.Text = "EndTime";
            // 
            // deBeginTime
            // 
            this.deBeginTime.EditValue = null;
            this.deBeginTime.Location = new System.Drawing.Point(116, 41);
            this.deBeginTime.Name = "deBeginTime";
            this.deBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginTime.Size = new System.Drawing.Size(122, 20);
            this.deBeginTime.TabIndex = 1;
            // 
            // deEndTime
            // 
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(360, 41);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Size = new System.Drawing.Size(127, 20);
            this.deEndTime.TabIndex = 2;
            // 
            // FormAssignEmployeeToStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 364);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignEmployeeToStore";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_DelegateToStore;
        private DevExpress.XtraEditors.TextEdit teEmployee;
        private DevExpress.XtraEditors.LabelControl lbl_Employee;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Store;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.DateEdit deBeginTime;
        private DevExpress.XtraEditors.LabelControl lbl_EndTime;
        private DevExpress.XtraEditors.LabelControl lbl_BeginTime;
    }
}