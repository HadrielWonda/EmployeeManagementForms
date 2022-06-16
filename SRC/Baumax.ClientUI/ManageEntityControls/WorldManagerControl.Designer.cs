namespace Baumax.ClientUI.ManageEntityControls
{
    partial class WorldManagerControl
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.nb_Import = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_ImportWorlds = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_ImportHwgrs = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_ImportWgrs = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_WorldManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_ChangeTimeRange = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_AssignWgr = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_AssignHwgr = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_EditWorld = new DevExpress.XtraNavBar.NavBarItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pcWorldList = new DevExpress.XtraEditors.PanelControl();
            this.ucWorldDetail1 = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldDetail();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.pcWorldTree = new DevExpress.XtraEditors.PanelControl();
            this.ucStoreTree1 = new Baumax.ClientUI.FormEntities.UCStoreTree();
            this.gc_Store = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditStores = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWorldList)).BeginInit();
            this.pcWorldList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWorldTree)).BeginInit();
            this.pcWorldTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Store)).BeginInit();
            this.gc_Store.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.navBarControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(176, 718);
            this.panelControl1.TabIndex = 0;
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.nb_Import;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_Import,
            this.nb_WorldManager});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_ImportWorlds,
            this.nbi_EditWorld,
            this.nbi_AssignHwgr,
            this.nbi_AssignWgr,
            this.nbi_ChangeTimeRange,
            this.nbi_ImportHwgrs,
            this.nbi_ImportWgrs});
            this.navBarControl.Location = new System.Drawing.Point(2, 2);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 172;
            this.navBarControl.Size = new System.Drawing.Size(172, 714);
            this.navBarControl.TabIndex = 1;
            this.navBarControl.Text = "navBarControl1";
            this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // nb_Import
            // 
            this.nb_Import.Caption = "Import";
            this.nb_Import.Expanded = true;
            this.nb_Import.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_Import.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportWorlds),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportHwgrs),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportWgrs)});
            this.nb_Import.Name = "nb_Import";
            // 
            // nbi_ImportWorlds
            // 
            this.nbi_ImportWorlds.Caption = "Import Worlds";
            this.nbi_ImportWorlds.LargeImageIndex = 4;
            this.nbi_ImportWorlds.Name = "nbi_ImportWorlds";
            this.nbi_ImportWorlds.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_ImportWorlds_LinkClicked);
            // 
            // nbi_ImportHwgrs
            // 
            this.nbi_ImportHwgrs.Caption = "Import HWGRs";
            this.nbi_ImportHwgrs.LargeImageIndex = 6;
            this.nbi_ImportHwgrs.Name = "nbi_ImportHwgrs";
            this.nbi_ImportHwgrs.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_ImportHwgrs_LinkClicked);
            // 
            // nbi_ImportWgrs
            // 
            this.nbi_ImportWgrs.Caption = "Import WGRs";
            this.nbi_ImportWgrs.LargeImageIndex = 5;
            this.nbi_ImportWgrs.Name = "nbi_ImportWgrs";
            this.nbi_ImportWgrs.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_ImportWgrs_LinkClicked);
            // 
            // nb_WorldManager
            // 
            this.nb_WorldManager.Caption = "World manager";
            this.nb_WorldManager.Expanded = true;
            this.nb_WorldManager.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_WorldManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ChangeTimeRange),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_AssignWgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_AssignHwgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_EditWorld)});
            this.nb_WorldManager.Name = "nb_WorldManager";
            // 
            // nbi_ChangeTimeRange
            // 
            this.nbi_ChangeTimeRange.Caption = "Change time range";
            this.nbi_ChangeTimeRange.LargeImageIndex = 2;
            this.nbi_ChangeTimeRange.Name = "nbi_ChangeTimeRange";
            // 
            // nbi_AssignWgr
            // 
            this.nbi_AssignWgr.Caption = "Assign WGR";
            this.nbi_AssignWgr.LargeImageIndex = 1;
            this.nbi_AssignWgr.Name = "nbi_AssignWgr";
            // 
            // nbi_AssignHwgr
            // 
            this.nbi_AssignHwgr.Caption = "Assign HWGR";
            this.nbi_AssignHwgr.LargeImageIndex = 0;
            this.nbi_AssignHwgr.Name = "nbi_AssignHwgr";
            // 
            // nbi_EditWorld
            // 
            this.nbi_EditWorld.Caption = "Edit world";
            this.nbi_EditWorld.LargeImageIndex = 3;
            this.nbi_EditWorld.Name = "nbi_EditWorld";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(176, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 718);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.pcWorldList);
            this.panelControl2.Controls.Add(this.splitterControl2);
            this.panelControl2.Controls.Add(this.pcWorldTree);
            this.panelControl2.Controls.Add(this.gc_Store);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(182, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(670, 718);
            this.panelControl2.TabIndex = 2;
            // 
            // pcWorldList
            // 
            this.pcWorldList.Controls.Add(this.ucWorldDetail1);
            this.pcWorldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcWorldList.Location = new System.Drawing.Point(2, 47);
            this.pcWorldList.Name = "pcWorldList";
            this.pcWorldList.Size = new System.Drawing.Size(666, 387);
            this.pcWorldList.TabIndex = 3;
            // 
            // ucWorldDetail1
            // 
            this.ucWorldDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorldDetail1.Entity = null;
            this.ucWorldDetail1.Location = new System.Drawing.Point(2, 2);
            this.ucWorldDetail1.LookAndFeel.SkinName = "iMaginary";
            this.ucWorldDetail1.Name = "ucWorldDetail1";
            this.ucWorldDetail1.Size = new System.Drawing.Size(662, 383);
            this.ucWorldDetail1.TabIndex = 0;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl2.Location = new System.Drawing.Point(2, 434);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(666, 6);
            this.splitterControl2.TabIndex = 2;
            this.splitterControl2.TabStop = false;
            // 
            // pcWorldTree
            // 
            this.pcWorldTree.Controls.Add(this.ucStoreTree1);
            this.pcWorldTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcWorldTree.Location = new System.Drawing.Point(2, 440);
            this.pcWorldTree.Name = "pcWorldTree";
            this.pcWorldTree.Size = new System.Drawing.Size(666, 276);
            this.pcWorldTree.TabIndex = 1;
            // 
            // ucStoreTree1
            // 
            this.ucStoreTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStoreTree1.Location = new System.Drawing.Point(2, 2);
            this.ucStoreTree1.Name = "ucStoreTree1";
            this.ucStoreTree1.Size = new System.Drawing.Size(662, 272);
            this.ucStoreTree1.TabIndex = 0;
            // 
            // gc_Store
            // 
            this.gc_Store.Controls.Add(this.lookUpEditStores);
            this.gc_Store.Dock = System.Windows.Forms.DockStyle.Top;
            this.gc_Store.Location = new System.Drawing.Point(2, 2);
            this.gc_Store.Name = "gc_Store";
            this.gc_Store.Size = new System.Drawing.Size(666, 45);
            this.gc_Store.TabIndex = 0;
            this.gc_Store.Text = "Store";
            // 
            // lookUpEditStores
            // 
            this.lookUpEditStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEditStores.Location = new System.Drawing.Point(2, 20);
            this.lookUpEditStores.Name = "lookUpEditStores";
            this.lookUpEditStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditStores.Properties.DisplayMember = "StoreName";
            this.lookUpEditStores.Properties.NullText = "";
            this.lookUpEditStores.Properties.ValueMember = "ID";
            this.lookUpEditStores.Properties.View = this.gridLookUpEdit1View;
            this.lookUpEditStores.Size = new System.Drawing.Size(662, 20);
            this.lookUpEditStores.TabIndex = 1;
            this.lookUpEditStores.EditValueChanged += new System.EventHandler(this.lookUpEditStores_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Country,
            this.gridColumn_Region,
            this.gridColumn_Store,
            this.gridColumn_City,
            this.gridColumn_Address,
            this.gridColumn_PostCode,
            this.gridColumn_Area});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridLookUpEdit1View.OptionsFilter.AllowFilterEditor = false;
            this.gridLookUpEdit1View.OptionsFilter.AllowMRUFilterList = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableColumnMenu = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableFooterMenu = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_Country
            // 
            this.gridColumn_Country.Caption = "Country";
            this.gridColumn_Country.FieldName = "CountryName";
            this.gridColumn_Country.Name = "gridColumn_Country";
            this.gridColumn_Country.OptionsColumn.AllowEdit = false;
            this.gridColumn_Country.OptionsColumn.ReadOnly = true;
            this.gridColumn_Country.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Country.OptionsFilter.AllowFilter = false;
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
            this.gridColumn_Region.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Region.OptionsFilter.AllowFilter = false;
            this.gridColumn_Region.Visible = true;
            this.gridColumn_Region.VisibleIndex = 1;
            // 
            // gridColumn_Store
            // 
            this.gridColumn_Store.Caption = "Store";
            this.gridColumn_Store.FieldName = "StoreName";
            this.gridColumn_Store.Name = "gridColumn_Store";
            this.gridColumn_Store.OptionsColumn.AllowEdit = false;
            this.gridColumn_Store.OptionsColumn.ReadOnly = true;
            this.gridColumn_Store.OptionsColumn.ShowInCustomizationForm = false;
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
            this.gridColumn_City.OptionsColumn.ReadOnly = true;
            this.gridColumn_City.OptionsColumn.ShowInCustomizationForm = false;
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
            this.gridColumn_Address.OptionsColumn.ReadOnly = true;
            this.gridColumn_Address.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_Address.OptionsFilter.AllowFilter = false;
            this.gridColumn_Address.Visible = true;
            this.gridColumn_Address.VisibleIndex = 4;
            // 
            // gridColumn_PostCode
            // 
            this.gridColumn_PostCode.Caption = "Post Code";
            this.gridColumn_PostCode.FieldName = "PostCode";
            this.gridColumn_PostCode.Name = "gridColumn_PostCode";
            this.gridColumn_PostCode.OptionsColumn.AllowEdit = false;
            this.gridColumn_PostCode.OptionsColumn.ReadOnly = true;
            this.gridColumn_PostCode.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_PostCode.OptionsFilter.AllowFilter = false;
            this.gridColumn_PostCode.Visible = true;
            this.gridColumn_PostCode.VisibleIndex = 5;
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
            this.gridColumn_Area.VisibleIndex = 6;
            // 
            // WorldManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "WorldManagerControl";
            this.Size = new System.Drawing.Size(852, 718);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcWorldList)).EndInit();
            this.pcWorldList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcWorldTree)).EndInit();
            this.pcWorldTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Store)).EndInit();
            this.gc_Store.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup nb_Import;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportWorlds;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportHwgrs;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportWgrs;
        private DevExpress.XtraNavBar.NavBarGroup nb_WorldManager;
        private DevExpress.XtraNavBar.NavBarItem nbi_ChangeTimeRange;
        private DevExpress.XtraNavBar.NavBarItem nbi_AssignWgr;
        private DevExpress.XtraNavBar.NavBarItem nbi_AssignHwgr;
        private DevExpress.XtraNavBar.NavBarItem nbi_EditWorld;
        private DevExpress.XtraEditors.GroupControl gc_Store;
        private DevExpress.XtraEditors.GridLookUpEdit lookUpEditStores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl pcWorldTree;
        private DevExpress.XtraEditors.PanelControl pcWorldList;
        private Baumax.ClientUI.FormEntities.UCStoreTree ucStoreTree1;
        private Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldDetail ucWorldDetail1;
    }
}
