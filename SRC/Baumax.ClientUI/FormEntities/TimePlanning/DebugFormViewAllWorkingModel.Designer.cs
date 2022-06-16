namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class DebugFormViewAllWorkingModel
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Employee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_WorkingModelMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemMemoEditWMMessage = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gc_AddHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_AsAddOrPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemMemoEditWMMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemMemoEditWMMessage});
            this.gridControl.Size = new System.Drawing.Size(815, 315);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Employee,
            this.gc_Date,
            this.gc_WorkingModel,
            this.gc_WorkingModelMessage,
            this.gc_AddHours,
            this.gc_AsAddOrPlan});
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
            this.gc_Date.Width = 49;
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
            this.gc_WorkingModel.Width = 200;
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
            this.gc_WorkingModelMessage.Width = 241;
            // 
            // repItemMemoEditWMMessage
            // 
            this.repItemMemoEditWMMessage.Name = "repItemMemoEditWMMessage";
            this.repItemMemoEditWMMessage.ReadOnly = true;
            // 
            // gc_AddHours
            // 
            this.gc_AddHours.Caption = "AddHours";
            this.gc_AddHours.FieldName = "AdditionalCharges";
            this.gc_AddHours.Name = "gc_AddHours";
            this.gc_AddHours.OptionsColumn.AllowEdit = false;
            this.gc_AddHours.OptionsColumn.ReadOnly = true;
            this.gc_AddHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AddHours.OptionsFilter.AllowAutoFilter = false;
            this.gc_AddHours.OptionsFilter.AllowFilter = false;
            this.gc_AddHours.Visible = true;
            this.gc_AddHours.VisibleIndex = 3;
            this.gc_AddHours.Width = 36;
            // 
            // gc_AsAddOrPlan
            // 
            this.gc_AsAddOrPlan.Caption = "Hours";
            this.gc_AsAddOrPlan.FieldName = "Hours";
            this.gc_AsAddOrPlan.Name = "gc_AsAddOrPlan";
            this.gc_AsAddOrPlan.OptionsColumn.AllowEdit = false;
            this.gc_AsAddOrPlan.OptionsColumn.ReadOnly = true;
            this.gc_AsAddOrPlan.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_AsAddOrPlan.OptionsFilter.AllowAutoFilter = false;
            this.gc_AsAddOrPlan.OptionsFilter.AllowFilter = false;
            this.gc_AsAddOrPlan.Visible = true;
            this.gc_AsAddOrPlan.VisibleIndex = 4;
            this.gc_AsAddOrPlan.Width = 31;
            // 
            // DebugFormViewAllWorkingModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 315);
            this.Controls.Add(this.gridControl);
            this.MinimizeBox = false;
            this.Name = "DebugFormViewAllWorkingModel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Working models";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemMemoEditWMMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Date;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModel;
        private DevExpress.XtraGrid.Columns.GridColumn gc_WorkingModelMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemMemoEditWMMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AddHours;
        private DevExpress.XtraGrid.Columns.GridColumn gc_AsAddOrPlan;
    }
}