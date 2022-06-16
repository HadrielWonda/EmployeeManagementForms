namespace Baumax.ClientUI.FormEntities
{
    partial class UCRegionList
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
            this.menuRegion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_ImportRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_RegionDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_EditRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_GroupByCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewRegions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_CountryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_RegionName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.menuRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.menuRegion;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewRegions;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(633, 351);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRegions});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlCountries_MouseDoubleClick);
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_KeyDown);
            // 
            // menuRegion
            // 
            this.menuRegion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_ImportRegion,
            this.menuItem_RegionDetails,
            this.menuItem_EditRegion,
            this.separatorMenuItem,
            this.menuItem_GroupByCountry,
            this.menuItem_ExpandedAll,
            this.menuItem_CollapseAll});
            this.menuRegion.Name = "menuRegion";
            this.menuRegion.Size = new System.Drawing.Size(170, 164);
            this.menuRegion.Opening += new System.ComponentModel.CancelEventHandler(this.menuRegion_Opening);
            // 
            // menuItem_ImportRegion
            // 
            this.menuItem_ImportRegion.Name = "menuItem_ImportRegion";
            this.menuItem_ImportRegion.Size = new System.Drawing.Size(169, 22);
            this.menuItem_ImportRegion.Text = "Import region";
            this.menuItem_ImportRegion.Click += new System.EventHandler(this.menuItem_NewRegion_Click);
            // 
            // menuItem_RegionDetails
            // 
            this.menuItem_RegionDetails.Name = "menuItem_RegionDetails";
            this.menuItem_RegionDetails.Size = new System.Drawing.Size(169, 22);
            this.menuItem_RegionDetails.Text = "Region details";
            this.menuItem_RegionDetails.Click += new System.EventHandler(this.menuItem_EditRegion_Click);
            // 
            // menuItem_EditRegion
            // 
            this.menuItem_EditRegion.Name = "menuItem_EditRegion";
            this.menuItem_EditRegion.Size = new System.Drawing.Size(169, 22);
            this.menuItem_EditRegion.Text = "Edit Region";
            this.menuItem_EditRegion.Click += new System.EventHandler(this.menuItem_DeleteRegion_Click);
            // 
            // separatorMenuItem
            // 
            this.separatorMenuItem.Name = "separatorMenuItem";
            this.separatorMenuItem.Size = new System.Drawing.Size(166, 6);
            // 
            // menuItem_GroupByCountry
            // 
            this.menuItem_GroupByCountry.Name = "menuItem_GroupByCountry";
            this.menuItem_GroupByCountry.Size = new System.Drawing.Size(169, 22);
            this.menuItem_GroupByCountry.Text = "Group by country";
            this.menuItem_GroupByCountry.Click += new System.EventHandler(this.menuItem_GroupByCountry_Click);
            // 
            // menuItem_ExpandedAll
            // 
            this.menuItem_ExpandedAll.Name = "menuItem_ExpandedAll";
            this.menuItem_ExpandedAll.Size = new System.Drawing.Size(169, 22);
            this.menuItem_ExpandedAll.Text = "Expanded All";
            this.menuItem_ExpandedAll.Click += new System.EventHandler(this.menuItem_ExpandedAll_Click);
            // 
            // menuItem_CollapseAll
            // 
            this.menuItem_CollapseAll.Name = "menuItem_CollapseAll";
            this.menuItem_CollapseAll.Size = new System.Drawing.Size(169, 22);
            this.menuItem_CollapseAll.Text = "Collapse All";
            this.menuItem_CollapseAll.Click += new System.EventHandler(this.menuItem_CollapseAll_Click);
            // 
            // gridViewRegions
            // 
            this.gridViewRegions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_CountryName,
            this.gridColumn_RegionName});
            this.gridViewRegions.GridControl = this.gridControl;
            this.gridViewRegions.Name = "gridViewRegions";
            this.gridViewRegions.OptionsBehavior.Editable = false;
            this.gridViewRegions.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewRegions.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewRegions.OptionsFilter.AllowFilterEditor = false;
            this.gridViewRegions.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewRegions.OptionsMenu.EnableColumnMenu = false;
            this.gridViewRegions.OptionsMenu.EnableFooterMenu = false;
            this.gridViewRegions.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewRegions.OptionsView.ShowAutoFilterRow = true;
            this.gridViewRegions.OptionsView.ShowGroupPanel = false;
            this.gridViewRegions.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewRegions_FocusedRowChanged);
            // 
            // gridColumn_CountryName
            // 
            this.gridColumn_CountryName.Caption = "Country";
            this.gridColumn_CountryName.FieldName = "CountryName";
            this.gridColumn_CountryName.Name = "gridColumn_CountryName";
            this.gridColumn_CountryName.OptionsFilter.AllowFilter = false;
            this.gridColumn_CountryName.Visible = true;
            this.gridColumn_CountryName.VisibleIndex = 0;
            // 
            // gridColumn_RegionName
            // 
            this.gridColumn_RegionName.Caption = "Region";
            this.gridColumn_RegionName.FieldName = "RegionName";
            this.gridColumn_RegionName.Name = "gridColumn_RegionName";
            this.gridColumn_RegionName.OptionsFilter.AllowFilter = false;
            this.gridColumn_RegionName.Visible = true;
            this.gridColumn_RegionName.VisibleIndex = 1;
            // 
            // UCRegionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "UCRegionList";
            this.Size = new System.Drawing.Size(633, 351);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.menuRegion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRegions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRegions;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_CountryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_RegionName;
        private System.Windows.Forms.ContextMenuStrip menuRegion;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ImportRegion;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RegionDetails;
        private System.Windows.Forms.ToolStripMenuItem menuItem_EditRegion;
        private System.Windows.Forms.ToolStripSeparator separatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_GroupByCountry;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem menuItem_CollapseAll;
    }
}
