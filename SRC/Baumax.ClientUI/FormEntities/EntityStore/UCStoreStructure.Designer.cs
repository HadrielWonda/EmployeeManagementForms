namespace Baumax.ClientUI.FormEntities.EntityStore
{
    partial class UCStoreStructure
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
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_HWGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_WGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Stores = new DevExpress.XtraEditors.GroupControl();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_date = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_StoreDetail = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Stores)).BeginInit();
            this.gc_Stores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 108);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(638, 354);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_World,
            this.gridColumn_HWGR,
            this.gridColumn_WGR});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            // 
            // gridColumn_World
            // 
            this.gridColumn_World.Caption = "World";
            this.gridColumn_World.FieldName = "WorldDisplayName";
            this.gridColumn_World.Name = "gridColumn_World";
            this.gridColumn_World.OptionsColumn.AllowEdit = false;
            this.gridColumn_World.OptionsColumn.ReadOnly = true;
            this.gridColumn_World.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_World.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_World.OptionsFilter.AllowFilter = false;
            this.gridColumn_World.Visible = true;
            this.gridColumn_World.VisibleIndex = 0;
            // 
            // gridColumn_HWGR
            // 
            this.gridColumn_HWGR.Caption = "HWGR";
            this.gridColumn_HWGR.FieldName = "HwgrDisplayName";
            this.gridColumn_HWGR.Name = "gridColumn_HWGR";
            this.gridColumn_HWGR.OptionsColumn.AllowEdit = false;
            this.gridColumn_HWGR.OptionsColumn.ReadOnly = true;
            this.gridColumn_HWGR.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_HWGR.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_HWGR.OptionsFilter.AllowFilter = false;
            this.gridColumn_HWGR.Visible = true;
            this.gridColumn_HWGR.VisibleIndex = 1;
            // 
            // gridColumn_WGR
            // 
            this.gridColumn_WGR.Caption = "WGR";
            this.gridColumn_WGR.FieldName = "WgrDisplayName";
            this.gridColumn_WGR.Name = "gridColumn_WGR";
            this.gridColumn_WGR.OptionsColumn.AllowEdit = false;
            this.gridColumn_WGR.OptionsColumn.ReadOnly = true;
            this.gridColumn_WGR.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_WGR.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_WGR.OptionsFilter.AllowFilter = false;
            this.gridColumn_WGR.Visible = true;
            this.gridColumn_WGR.VisibleIndex = 2;
            // 
            // gc_Stores
            // 
            this.gc_Stores.Controls.Add(this.gridLookUpEdit1);
            this.gc_Stores.Dock = System.Windows.Forms.DockStyle.Top;
            this.gc_Stores.Location = new System.Drawing.Point(0, 30);
            this.gc_Stores.Name = "gc_Stores";
            this.gc_Stores.Size = new System.Drawing.Size(638, 44);
            this.gc_Stores.TabIndex = 1;
            this.gc_Stores.Text = "Stores";
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLookUpEdit1.Location = new System.Drawing.Point(2, 20);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.DisplayMember = "StoreName";
            this.gridLookUpEdit1.Properties.NullText = "";
            this.gridLookUpEdit1.Properties.ValueMember = "ID";
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(634, 20);
            this.gridLookUpEdit1.TabIndex = 0;
            this.gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.gridLookUpEdit1_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Country,
            this.gridColumn_Region,
            this.gridColumn_Store});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.gridLookUpEdit1View.OptionsDetail.EnableMasterViewMode = false;
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
            this.gridColumn_Country.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_Country.OptionsFilter.AllowFilter = false;
            this.gridColumn_Country.Visible = true;
            this.gridColumn_Country.VisibleIndex = 2;
            // 
            // gridColumn_Region
            // 
            this.gridColumn_Region.Caption = "Region";
            this.gridColumn_Region.FieldName = "RegionName";
            this.gridColumn_Region.Name = "gridColumn_Region";
            this.gridColumn_Region.OptionsColumn.AllowEdit = false;
            this.gridColumn_Region.OptionsColumn.ReadOnly = true;
            this.gridColumn_Region.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_Region.OptionsFilter.AllowFilter = false;
            this.gridColumn_Region.Visible = true;
            this.gridColumn_Region.VisibleIndex = 0;
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
            this.gridColumn_Store.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbl_date);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 74);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 34);
            this.panelControl1.TabIndex = 2;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_date.Location = new System.Drawing.Point(5, 12);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(124, 13);
            this.lbl_date.TabIndex = 2;
            this.lbl_date.Text = "Date";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(135, 9);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(159, 20);
            this.dateEdit1.TabIndex = 1;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbl_StoreDetail);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(638, 30);
            this.panelControl2.TabIndex = 3;
            // 
            // lbl_StoreDetail
            // 
            this.lbl_StoreDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_StoreDetail.Appearance.Options.UseFont = true;
            this.lbl_StoreDetail.Appearance.Options.UseTextOptions = true;
            this.lbl_StoreDetail.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_StoreDetail.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_StoreDetail.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_StoreDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_StoreDetail.Location = new System.Drawing.Point(2, 2);
            this.lbl_StoreDetail.Name = "lbl_StoreDetail";
            this.lbl_StoreDetail.Size = new System.Drawing.Size(634, 26);
            this.lbl_StoreDetail.TabIndex = 0;
            this.lbl_StoreDetail.Text = "Store Detail";
            // 
            // UCStoreStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_Stores);
            this.Controls.Add(this.panelControl2);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCStoreStructure";
            this.Resize += new System.EventHandler(this.UCStoreStructure_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Stores)).EndInit();
            this.gc_Stores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_World;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_HWGR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_WGR;
        private DevExpress.XtraEditors.GroupControl gc_Stores;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_date;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_StoreDetail;

    }
}
