namespace Baumax.ClientUI.FormEntities
{
    partial class UCStoreList
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
            this.components = new System.ComponentModel.Container();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.menuStore = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_GroupByCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_GroupByRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_Stores = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.menuStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.menuStore;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 30);
            this.gridControl.MainView = this.gridViewEntities;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(638, 432);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // menuStore
            // 
            this.menuStore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_GroupByCountry,
            this.mi_GroupByRegion,
            this.toolStripSeparator2,
            this.mi_ExpandedAll,
            this.mi_CollapseAll});
            this.menuStore.Name = "menuStore";
            this.menuStore.Size = new System.Drawing.Size(170, 98);
            this.menuStore.Opening += new System.ComponentModel.CancelEventHandler(this.menuStore_Opening);
            // 
            // mi_GroupByCountry
            // 
            this.mi_GroupByCountry.Name = "mi_GroupByCountry";
            this.mi_GroupByCountry.Size = new System.Drawing.Size(169, 22);
            this.mi_GroupByCountry.Text = "Group by country";
            this.mi_GroupByCountry.Click += new System.EventHandler(this.mi_GroupByCountry_Click);
            // 
            // mi_GroupByRegion
            // 
            this.mi_GroupByRegion.Name = "mi_GroupByRegion";
            this.mi_GroupByRegion.Size = new System.Drawing.Size(169, 22);
            this.mi_GroupByRegion.Text = "Group by region";
            this.mi_GroupByRegion.Click += new System.EventHandler(this.mi_GroupByRegion_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // mi_ExpandedAll
            // 
            this.mi_ExpandedAll.Name = "mi_ExpandedAll";
            this.mi_ExpandedAll.Size = new System.Drawing.Size(169, 22);
            this.mi_ExpandedAll.Text = "Expanded All";
            this.mi_ExpandedAll.Click += new System.EventHandler(this.mi_ExpandedAll_Click);
            // 
            // mi_CollapseAll
            // 
            this.mi_CollapseAll.Name = "mi_CollapseAll";
            this.mi_CollapseAll.Size = new System.Drawing.Size(169, 22);
            this.mi_CollapseAll.Text = "Collapse All";
            this.mi_CollapseAll.Click += new System.EventHandler(this.mi_CollapseAll_Click);
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
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsBehavior.Editable = false;
            this.gridViewEntities.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
            this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.OptionsView.ShowAutoFilterRow = true;
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            this.gridViewEntities.RowCountChanged += new System.EventHandler(this.gridViewEntities_RowCountChanged);
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
            this.gridColumn_Region.VisibleIndex = 1;
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
            this.gridColumn_Store.VisibleIndex = 2;
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
            this.gridColumn_City.VisibleIndex = 3;
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
            this.gridColumn_Address.VisibleIndex = 4;
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
            this.gridColumn_Area.VisibleIndex = 5;
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
            this.gridColumn_PostalCode.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbl_Stores);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 30);
            this.panelControl1.TabIndex = 1;
            // 
            // lbl_Stores
            // 
            this.lbl_Stores.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Stores.Appearance.Options.UseFont = true;
            this.lbl_Stores.Appearance.Options.UseTextOptions = true;
            this.lbl_Stores.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_Stores.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_Stores.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Stores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Stores.Location = new System.Drawing.Point(2, 2);
            this.lbl_Stores.Name = "lbl_Stores";
            this.lbl_Stores.Size = new System.Drawing.Size(634, 26);
            this.lbl_Stores.TabIndex = 0;
            this.lbl_Stores.Text = "Stores";
            // 
            // UCStoreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCStoreList";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.menuStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
        private System.Windows.Forms.ContextMenuStrip menuStore;
        private System.Windows.Forms.ToolStripMenuItem mi_GroupByCountry;
        private System.Windows.Forms.ToolStripMenuItem mi_GroupByRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mi_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem mi_CollapseAll;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Stores;
    }
}
