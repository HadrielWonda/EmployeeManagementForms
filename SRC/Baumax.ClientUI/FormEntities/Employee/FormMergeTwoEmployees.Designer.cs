namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormMergeTwoEmployees
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
            this.lbl_MergeEmployee = new DevExpress.XtraEditors.LabelControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.categ_persinfo = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.row_PersonID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_FirstName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_LastName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_OldHolidays = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_NewHolidays = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_EmployeeBalanceHours = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.categ_ContractInfo = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.row_ContractBeginTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_ContractEndTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row_ContractWorkingHours = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.panelCustomButtons = new DevExpress.XtraEditors.PanelControl();
            this.button_NextExt = new DevExpress.XtraEditors.SimpleButton();
            this.button_NextInt = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomButtons)).BeginInit();
            this.panelCustomButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_MergeEmployee);
            this.panelTop.Size = new System.Drawing.Size(515, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.panelCustomButtons);
            this.panelClient.Controls.Add(this.vGridControl1);
            this.panelClient.Size = new System.Drawing.Size(515, 251);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-711, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 285);
            this.panelBottom.Size = new System.Drawing.Size(515, 40);
            // 
            // lbl_MergeEmployee
            // 
            this.lbl_MergeEmployee.Appearance.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MergeEmployee.Appearance.Options.UseFont = true;
            this.lbl_MergeEmployee.Appearance.Options.UseTextOptions = true;
            this.lbl_MergeEmployee.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_MergeEmployee.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_MergeEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MergeEmployee.Location = new System.Drawing.Point(2, 2);
            this.lbl_MergeEmployee.Name = "lbl_MergeEmployee";
            this.lbl_MergeEmployee.Size = new System.Drawing.Size(511, 30);
            this.lbl_MergeEmployee.TabIndex = 0;
            this.lbl_MergeEmployee.Text = "Merge employees";
            // 
            // vGridControl1
            // 
            this.vGridControl1.Appearance.Category.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.Category.Options.UseForeColor = true;
            this.vGridControl1.Appearance.ReadOnlyRow.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.ReadOnlyRow.Options.UseForeColor = true;
            this.vGridControl1.Appearance.RecordValue.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.RecordValue.Options.UseForeColor = true;
            this.vGridControl1.Appearance.RowHeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseForeColor = true;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(2, 2);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsBehavior.Editable = false;
            this.vGridControl1.OptionsView.ShowButtons = false;
            this.vGridControl1.RecordWidth = 163;
            this.vGridControl1.RowHeaderWidth = 143;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categ_persinfo,
            this.row_PersonID,
            this.row_FirstName,
            this.row_LastName,
            this.row_OldHolidays,
            this.row_NewHolidays,
            this.row_EmployeeBalanceHours,
            this.categ_ContractInfo,
            this.row_ContractBeginTime,
            this.row_ContractEndTime,
            this.row_ContractWorkingHours});
            this.vGridControl1.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowOnlyInEditor;
            this.vGridControl1.Size = new System.Drawing.Size(511, 247);
            this.vGridControl1.TabIndex = 0;
            // 
            // categ_persinfo
            // 
            this.categ_persinfo.Height = 19;
            this.categ_persinfo.Name = "categ_persinfo";
            this.categ_persinfo.Properties.Caption = "Personal infomation";
            // 
            // row_PersonID
            // 
            this.row_PersonID.Name = "row_PersonID";
            this.row_PersonID.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_PersonID.OptionsRow.AllowSize = false;
            this.row_PersonID.OptionsRow.ShowInCustomizationForm = false;
            this.row_PersonID.Properties.Caption = "PersonalID";
            this.row_PersonID.Properties.FieldName = "PersID";
            this.row_PersonID.Properties.ReadOnly = true;
            // 
            // row_FirstName
            // 
            this.row_FirstName.Name = "row_FirstName";
            this.row_FirstName.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_FirstName.OptionsRow.AllowSize = false;
            this.row_FirstName.OptionsRow.ShowInCustomizationForm = false;
            this.row_FirstName.Properties.Caption = "First name";
            this.row_FirstName.Properties.FieldName = "FirstName";
            this.row_FirstName.Properties.ReadOnly = true;
            // 
            // row_LastName
            // 
            this.row_LastName.Name = "row_LastName";
            this.row_LastName.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_LastName.OptionsRow.AllowSize = false;
            this.row_LastName.OptionsRow.ShowInCustomizationForm = false;
            this.row_LastName.Properties.Caption = "Last name";
            this.row_LastName.Properties.FieldName = "LastName";
            this.row_LastName.Properties.ReadOnly = true;
            // 
            // row_OldHolidays
            // 
            this.row_OldHolidays.Name = "row_OldHolidays";
            this.row_OldHolidays.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_OldHolidays.OptionsRow.AllowSize = false;
            this.row_OldHolidays.OptionsRow.ShowInCustomizationForm = false;
            this.row_OldHolidays.Properties.Caption = "Old holidays";
            this.row_OldHolidays.Properties.FieldName = "OldHolidays";
            this.row_OldHolidays.Properties.ReadOnly = true;
            // 
            // row_NewHolidays
            // 
            this.row_NewHolidays.Name = "row_NewHolidays";
            this.row_NewHolidays.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_NewHolidays.OptionsRow.AllowSize = false;
            this.row_NewHolidays.OptionsRow.ShowInCustomizationForm = false;
            this.row_NewHolidays.Properties.Caption = "New holidays";
            this.row_NewHolidays.Properties.FieldName = "NewHolidays";
            this.row_NewHolidays.Properties.ReadOnly = true;
            // 
            // row_EmployeeBalanceHours
            // 
            this.row_EmployeeBalanceHours.Name = "row_EmployeeBalanceHours";
            this.row_EmployeeBalanceHours.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_EmployeeBalanceHours.OptionsRow.AllowSize = false;
            this.row_EmployeeBalanceHours.OptionsRow.ShowInCustomizationForm = false;
            this.row_EmployeeBalanceHours.Properties.Caption = "Employee balance hours";
            this.row_EmployeeBalanceHours.Properties.FieldName = "BalanceHours";
            this.row_EmployeeBalanceHours.Properties.ReadOnly = true;
            // 
            // categ_ContractInfo
            // 
            this.categ_ContractInfo.Name = "categ_ContractInfo";
            this.categ_ContractInfo.Properties.Caption = "Contract information";
            // 
            // row_ContractBeginTime
            // 
            this.row_ContractBeginTime.Name = "row_ContractBeginTime";
            this.row_ContractBeginTime.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_ContractBeginTime.OptionsRow.AllowSize = false;
            this.row_ContractBeginTime.OptionsRow.ShowInCustomizationForm = false;
            this.row_ContractBeginTime.Properties.Caption = "Begin date";
            this.row_ContractBeginTime.Properties.FieldName = "ContractBegin";
            this.row_ContractBeginTime.Properties.Format.FormatString = "d";
            this.row_ContractBeginTime.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.row_ContractBeginTime.Properties.ReadOnly = true;
            // 
            // row_ContractEndTime
            // 
            this.row_ContractEndTime.Name = "row_ContractEndTime";
            this.row_ContractEndTime.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_ContractEndTime.OptionsRow.AllowSize = false;
            this.row_ContractEndTime.OptionsRow.ShowInCustomizationForm = false;
            this.row_ContractEndTime.Properties.Caption = "End date";
            this.row_ContractEndTime.Properties.FieldName = "ContractEnd";
            this.row_ContractEndTime.Properties.Format.FormatString = "d";
            this.row_ContractEndTime.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.row_ContractEndTime.Properties.ReadOnly = true;
            // 
            // row_ContractWorkingHours
            // 
            this.row_ContractWorkingHours.Name = "row_ContractWorkingHours";
            this.row_ContractWorkingHours.OptionsRow.AllowMoveToCustomizationForm = false;
            this.row_ContractWorkingHours.OptionsRow.AllowSize = false;
            this.row_ContractWorkingHours.OptionsRow.ShowInCustomizationForm = false;
            this.row_ContractWorkingHours.Properties.Caption = "Hours per week";
            this.row_ContractWorkingHours.Properties.FieldName = "ContractWorkingHours";
            this.row_ContractWorkingHours.Properties.ReadOnly = true;
            // 
            // panelCustomButtons
            // 
            this.panelCustomButtons.Controls.Add(this.button_NextExt);
            this.panelCustomButtons.Controls.Add(this.button_NextInt);
            this.panelCustomButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCustomButtons.Location = new System.Drawing.Point(2, 216);
            this.panelCustomButtons.Name = "panelCustomButtons";
            this.panelCustomButtons.Size = new System.Drawing.Size(511, 33);
            this.panelCustomButtons.TabIndex = 1;
            // 
            // button_NextExt
            // 
            this.button_NextExt.Location = new System.Drawing.Point(369, 5);
            this.button_NextExt.Name = "button_NextExt";
            this.button_NextExt.Size = new System.Drawing.Size(93, 23);
            this.button_NextExt.TabIndex = 1;
            this.button_NextExt.Text = "next";
            this.button_NextExt.Click += new System.EventHandler(this.button_NextExt_Click);
            // 
            // button_NextInt
            // 
            this.button_NextInt.Location = new System.Drawing.Point(180, 5);
            this.button_NextInt.Name = "button_NextInt";
            this.button_NextInt.Size = new System.Drawing.Size(93, 23);
            this.button_NextInt.TabIndex = 0;
            this.button_NextInt.Text = "next";
            this.button_NextInt.Click += new System.EventHandler(this.button_NextInt_Click);
            // 
            // FormMergeTwoEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 325);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormMergeTwoEmployees";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomButtons)).EndInit();
            this.panelCustomButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_MergeEmployee;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_PersonID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_FirstName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_LastName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_OldHolidays;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categ_persinfo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_NewHolidays;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_EmployeeBalanceHours;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categ_ContractInfo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_ContractBeginTime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_ContractEndTime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row_ContractWorkingHours;
        private DevExpress.XtraEditors.PanelControl panelCustomButtons;
        private DevExpress.XtraEditors.SimpleButton button_NextInt;
        private DevExpress.XtraEditors.SimpleButton button_NextExt;
    }
}