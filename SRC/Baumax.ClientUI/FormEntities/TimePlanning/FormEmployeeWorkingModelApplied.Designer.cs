namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class FormEmployeeWorkingModelApplied
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
            this.lbl_ListOfModelMessage = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Employee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModelMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemMemoEditWMMessage = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemMemoEditWMMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_ListOfModelMessage);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.gridControl);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // lbl_ListOfModelMessage
            // 
            this.lbl_ListOfModelMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_ListOfModelMessage.Appearance.Options.UseFont = true;
            this.lbl_ListOfModelMessage.Appearance.Options.UseTextOptions = true;
            this.lbl_ListOfModelMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_ListOfModelMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_ListOfModelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ListOfModelMessage.Location = new System.Drawing.Point(2, 2);
            this.lbl_ListOfModelMessage.Name = "lbl_ListOfModelMessage";
            this.lbl_ListOfModelMessage.Size = new System.Drawing.Size(622, 30);
            this.lbl_ListOfModelMessage.TabIndex = 0;
            this.lbl_ListOfModelMessage.Text = "List of working model messages";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemMemoEditWMMessage});
            this.gridControl.Size = new System.Drawing.Size(622, 197);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Employee,
            this.gc_Date,
            this.gc_WorkingModel,
            this.gc_WorkingModelMessage});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_Employee, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gc_Employee
            // 
            this.gc_Employee.Caption = "Employee";
            this.gc_Employee.FieldName = "EmployeeName";
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.OptionsColumn.AllowEdit = false;
            this.gc_Employee.OptionsColumn.ReadOnly = true;
            this.gc_Employee.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Employee.OptionsFilter.AllowAutoFilter = false;
            this.gc_Employee.OptionsFilter.AllowFilter = false;
            this.gc_Employee.Visible = true;
            this.gc_Employee.VisibleIndex = 0;
            // 
            // gc_Date
            // 
            this.gc_Date.Caption = "Date";
            this.gc_Date.FieldName = "Date";
            this.gc_Date.MinWidth = 30;
            this.gc_Date.Name = "gc_Date";
            this.gc_Date.OptionsColumn.AllowEdit = false;
            this.gc_Date.OptionsColumn.ReadOnly = true;
            this.gc_Date.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Date.OptionsFilter.AllowAutoFilter = false;
            this.gc_Date.OptionsFilter.AllowFilter = false;
            this.gc_Date.Visible = true;
            this.gc_Date.VisibleIndex = 0;
            this.gc_Date.Width = 83;
            // 
            // gc_WorkingModel
            // 
            this.gc_WorkingModel.Caption = "WorkingModel";
            this.gc_WorkingModel.FieldName = "WorkingModelName";
            this.gc_WorkingModel.Name = "gc_WorkingModel";
            this.gc_WorkingModel.OptionsColumn.AllowEdit = false;
            this.gc_WorkingModel.OptionsColumn.ReadOnly = true;
            this.gc_WorkingModel.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_WorkingModel.OptionsFilter.AllowAutoFilter = false;
            this.gc_WorkingModel.OptionsFilter.AllowFilter = false;
            this.gc_WorkingModel.Visible = true;
            this.gc_WorkingModel.VisibleIndex = 1;
            this.gc_WorkingModel.Width = 54;
            // 
            // gc_WorkingModelMessage
            // 
            this.gc_WorkingModelMessage.Caption = "Message";
            this.gc_WorkingModelMessage.ColumnEdit = this.repItemMemoEditWMMessage;
            this.gc_WorkingModelMessage.FieldName = "Message";
            this.gc_WorkingModelMessage.Name = "gc_WorkingModelMessage";
            this.gc_WorkingModelMessage.OptionsColumn.AllowEdit = false;
            this.gc_WorkingModelMessage.OptionsColumn.ReadOnly = true;
            this.gc_WorkingModelMessage.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_WorkingModelMessage.OptionsFilter.AllowAutoFilter = false;
            this.gc_WorkingModelMessage.OptionsFilter.AllowFilter = false;
            this.gc_WorkingModelMessage.Visible = true;
            this.gc_WorkingModelMessage.VisibleIndex = 2;
            this.gc_WorkingModelMessage.Width = 464;
            // 
            // repItemMemoEditWMMessage
            // 
            this.repItemMemoEditWMMessage.Name = "repItemMemoEditWMMessage";
            this.repItemMemoEditWMMessage.ReadOnly = true;
            // 
            // FormEmployeeWorkingModelApplied
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 275);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormEmployeeWorkingModelApplied";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemMemoEditWMMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_ListOfModelMessage;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Date;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModel;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModelMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemMemoEditWMMessage;
    }
}