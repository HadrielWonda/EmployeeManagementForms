namespace Baumax.ClientUI.FormEntities.Region
{
    partial class UCRegionStores
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
            this.gridViewStores = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_StoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStores)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewStores;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(603, 350);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStores});
            // 
            // gridViewStores
            // 
            this.gridViewStores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_StoreName,
            this.gridColumn_City,
            this.gridColumn_Address,
            this.gridColumn_PostCode,
            this.gridColumn_Area});
            this.gridViewStores.GridControl = this.gridControl;
            this.gridViewStores.Name = "gridViewStores";
            this.gridViewStores.OptionsMenu.EnableColumnMenu = false;
            this.gridViewStores.OptionsMenu.EnableFooterMenu = false;
            this.gridViewStores.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewStores.OptionsView.ShowAutoFilterRow = true;
            this.gridViewStores.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_StoreName
            // 
            this.gridColumn_StoreName.Caption = "Store";
            this.gridColumn_StoreName.FieldName = "Name";
            this.gridColumn_StoreName.Name = "gridColumn_StoreName";
            this.gridColumn_StoreName.OptionsColumn.AllowEdit = false;
            this.gridColumn_StoreName.OptionsColumn.ReadOnly = true;
            this.gridColumn_StoreName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_StoreName.OptionsFilter.AllowFilter = false;
            this.gridColumn_StoreName.Visible = true;
            this.gridColumn_StoreName.VisibleIndex = 0;
            // 
            // gridColumn_City
            // 
            this.gridColumn_City.Caption = "City";
            this.gridColumn_City.FieldName = "City";
            this.gridColumn_City.Name = "gridColumn_City";
            this.gridColumn_City.OptionsColumn.AllowEdit = false;
            this.gridColumn_City.OptionsColumn.ReadOnly = true;
            this.gridColumn_City.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_City.OptionsFilter.AllowFilter = false;
            this.gridColumn_City.Visible = true;
            this.gridColumn_City.VisibleIndex = 1;
            // 
            // gridColumn_Address
            // 
            this.gridColumn_Address.Caption = "Address";
            this.gridColumn_Address.FieldName = "Address";
            this.gridColumn_Address.Name = "gridColumn_Address";
            this.gridColumn_Address.OptionsColumn.AllowEdit = false;
            this.gridColumn_Address.OptionsColumn.ReadOnly = true;
            this.gridColumn_Address.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Address.OptionsFilter.AllowFilter = false;
            this.gridColumn_Address.Visible = true;
            this.gridColumn_Address.VisibleIndex = 2;
            // 
            // gridColumn_PostCode
            // 
            this.gridColumn_PostCode.Caption = "PostCode";
            this.gridColumn_PostCode.FieldName = "Number";
            this.gridColumn_PostCode.Name = "gridColumn_PostCode";
            this.gridColumn_PostCode.OptionsColumn.AllowEdit = false;
            this.gridColumn_PostCode.OptionsColumn.ReadOnly = true;
            this.gridColumn_PostCode.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_PostCode.OptionsFilter.AllowFilter = false;
            this.gridColumn_PostCode.Visible = true;
            this.gridColumn_PostCode.VisibleIndex = 3;
            // 
            // gridColumn_Area
            // 
            this.gridColumn_Area.Caption = "Area";
            this.gridColumn_Area.FieldName = "Area";
            this.gridColumn_Area.Name = "gridColumn_Area";
            this.gridColumn_Area.OptionsColumn.AllowEdit = false;
            this.gridColumn_Area.OptionsColumn.ReadOnly = true;
            this.gridColumn_Area.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Area.OptionsFilter.AllowFilter = false;
            this.gridColumn_Area.Visible = true;
            this.gridColumn_Area.VisibleIndex = 4;
            // 
            // UCRegionStores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "UCRegionStores";
            this.Size = new System.Drawing.Size(603, 350);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStores;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_StoreName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
    }
}
