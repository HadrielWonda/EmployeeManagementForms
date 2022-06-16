namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCEmployeeSelectGrid
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewEntities;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(638, 462);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_FirstName,
            this.gc_LastName});
            this.gridViewEntities.GridControl = this.gridControl;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
            this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.OptionsView.ShowAutoFilterRow = true;
            this.gridViewEntities.OptionsView.ShowFooter = true;
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
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
            this.gc_FirstName.SummaryItem.DisplayFormat = "{0}";
            this.gc_FirstName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gc_FirstName.Visible = true;
            this.gc_FirstName.VisibleIndex = 0;
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
            this.gc_LastName.VisibleIndex = 1;
            // 
            // UCEmployeeSelectGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCEmployeeSelectGrid";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gc_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LastName;
    }
}
