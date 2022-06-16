namespace Baumax.ClientUI.NotificationServiceUI
{
	partial class UCStoresListNotification
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
			this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_PostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
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
			this.gridControl.Size = new System.Drawing.Size(572, 232);
			this.gridControl.TabIndex = 2;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
			// 
			// gridViewEntities
			// 
			this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Country,
            this.gridColumn_Region,
            this.gridColumn_Store,
            this.gridColumn_City,
            this.gridColumn_Address,
            this.gridColumn_Area,
            this.gridColumn_PostalCode});
			this.gridViewEntities.GridControl = this.gridControl;
			this.gridViewEntities.GroupCount = 2;
			this.gridViewEntities.Name = "gridViewEntities";
			this.gridViewEntities.OptionsBehavior.AutoPopulateColumns = false;
			this.gridViewEntities.OptionsBehavior.Editable = false;
			this.gridViewEntities.OptionsDetail.EnableMasterViewMode = false;
			this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
			this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
			this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
			this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
			this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
			this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
			this.gridViewEntities.OptionsView.ShowGroupPanel = false;
			this.gridViewEntities.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Country, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Region, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn_Country
			// 
			this.gridColumn_Country.Caption = "Country";
			this.gridColumn_Country.FieldName = "CountryName";
			this.gridColumn_Country.Name = "gridColumn_Country";
			this.gridColumn_Country.OptionsColumn.AllowEdit = false;
			this.gridColumn_Country.OptionsColumn.ReadOnly = true;
			this.gridColumn_Country.OptionsFilter.AllowFilter = false;
			this.gridColumn_Country.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.gridColumn_Country.Visible = true;
			this.gridColumn_Country.VisibleIndex = 0;
			// 
			// gridColumn_Region
			// 
			this.gridColumn_Region.Caption = "Region";
			this.gridColumn_Region.FieldName = "RegionName";
			this.gridColumn_Region.Name = "gridColumn_Region";
			this.gridColumn_Region.OptionsColumn.AllowEdit = false;
			this.gridColumn_Region.OptionsColumn.ReadOnly = true;
			this.gridColumn_Region.OptionsFilter.AllowFilter = false;
			this.gridColumn_Region.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.gridColumn_Region.Visible = true;
			this.gridColumn_Region.VisibleIndex = 0;
			// 
			// gridColumn_Store
			// 
			this.gridColumn_Store.Caption = "Store";
			this.gridColumn_Store.FieldName = "StoreName";
			this.gridColumn_Store.Name = "gridColumn_Store";
			this.gridColumn_Store.OptionsColumn.AllowEdit = false;
			this.gridColumn_Store.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn_Store.OptionsColumn.ReadOnly = true;
			this.gridColumn_Store.OptionsFilter.AllowFilter = false;
			this.gridColumn_Store.Visible = true;
			this.gridColumn_Store.VisibleIndex = 0;
			// 
			// gridColumn_City
			// 
			this.gridColumn_City.Caption = "City";
			this.gridColumn_City.FieldName = "City";
			this.gridColumn_City.Name = "gridColumn_City";
			this.gridColumn_City.OptionsColumn.AllowEdit = false;
			this.gridColumn_City.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn_City.OptionsColumn.ReadOnly = true;
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
			this.gridColumn_Address.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn_Address.OptionsColumn.ReadOnly = true;
			this.gridColumn_Address.OptionsFilter.AllowFilter = false;
			this.gridColumn_Address.Visible = true;
			this.gridColumn_Address.VisibleIndex = 2;
			// 
			// gridColumn_Area
			// 
			this.gridColumn_Area.Caption = "Area";
			this.gridColumn_Area.FieldName = "Area";
			this.gridColumn_Area.Name = "gridColumn_Area";
			this.gridColumn_Area.OptionsColumn.AllowEdit = false;
			this.gridColumn_Area.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn_Area.OptionsColumn.ReadOnly = true;
			this.gridColumn_Area.OptionsFilter.AllowFilter = false;
			this.gridColumn_Area.Visible = true;
			this.gridColumn_Area.VisibleIndex = 3;
			// 
			// gridColumn_PostalCode
			// 
			this.gridColumn_PostalCode.Caption = "PostalCode";
			this.gridColumn_PostalCode.FieldName = "PostCode";
			this.gridColumn_PostalCode.Name = "gridColumn_PostalCode";
			this.gridColumn_PostalCode.OptionsColumn.AllowEdit = false;
			this.gridColumn_PostalCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn_PostalCode.OptionsColumn.ReadOnly = true;
			this.gridColumn_PostalCode.OptionsFilter.AllowFilter = false;
			this.gridColumn_PostalCode.Visible = true;
			this.gridColumn_PostalCode.VisibleIndex = 4;
			// 
			// UCStoresListNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControl);
			this.Name = "UCStoresListNotification";
			this.Size = new System.Drawing.Size(572, 232);
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostalCode;
	}
}