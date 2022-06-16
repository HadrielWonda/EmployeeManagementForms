namespace Baumax.ClientUI.FormEntities.EntityStore
{
    partial class UCOpenCloseHoursList
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_NewOpenCloseRange = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_DeleteOpenCloseRange = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcOpenCloseControl = new DevExpress.XtraEditors.PanelControl();
            this.ucOpenCloseHours = new Baumax.ClientUI.FormEntities.EntityStore.UCOpenCloseHours();
            this.gp_Store = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditStores = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_OpenCloseHours = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOpenCloseControl)).BeginInit();
            this.pcOpenCloseControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gp_Store)).BeginInit();
            this.gp_Store.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 75);
            this.gridControl.MainView = this.gridViewEntities;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(238, 387);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewOpenCloseRange,
            this.mi_DeleteOpenCloseRange});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mi_NewOpenCloseRange
            // 
            this.mi_NewOpenCloseRange.Name = "mi_NewOpenCloseRange";
            this.mi_NewOpenCloseRange.Size = new System.Drawing.Size(171, 22);
            this.mi_NewOpenCloseRange.Text = "New open-close";
            this.mi_NewOpenCloseRange.Click += new System.EventHandler(this.newOpencloseToolStripMenuItem_Click);
            // 
            // mi_DeleteOpenCloseRange
            // 
            this.mi_DeleteOpenCloseRange.Name = "mi_DeleteOpenCloseRange";
            this.mi_DeleteOpenCloseRange.Size = new System.Drawing.Size(171, 22);
            this.mi_DeleteOpenCloseRange.Text = "Delete open-close";
            this.mi_DeleteOpenCloseRange.Click += new System.EventHandler(this.deleteOpencloseToolStripMenuItem_Click);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_BeginDate,
            this.gridColumn_EndDate});
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
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
            this.gridViewEntities.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_BeginDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            // 
            // gridColumn_BeginDate
            // 
            this.gridColumn_BeginDate.Caption = "Start";
            this.gridColumn_BeginDate.FieldName = "BeginTime";
            this.gridColumn_BeginDate.Name = "gridColumn_BeginDate";
            this.gridColumn_BeginDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_BeginDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_BeginDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_BeginDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_BeginDate.Visible = true;
            this.gridColumn_BeginDate.VisibleIndex = 0;
            // 
            // gridColumn_EndDate
            // 
            this.gridColumn_EndDate.Caption = "End";
            this.gridColumn_EndDate.FieldName = "EndTime";
            this.gridColumn_EndDate.Name = "gridColumn_EndDate";
            this.gridColumn_EndDate.OptionsColumn.AllowEdit = false;
            this.gridColumn_EndDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_EndDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_EndDate.OptionsFilter.AllowFilter = false;
            this.gridColumn_EndDate.Visible = true;
            this.gridColumn_EndDate.VisibleIndex = 1;
            // 
            // pcOpenCloseControl
            // 
            this.pcOpenCloseControl.Controls.Add(this.ucOpenCloseHours);
            this.pcOpenCloseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcOpenCloseControl.Location = new System.Drawing.Point(238, 75);
            this.pcOpenCloseControl.Name = "pcOpenCloseControl";
            this.pcOpenCloseControl.Size = new System.Drawing.Size(474, 387);
            this.pcOpenCloseControl.TabIndex = 2;
            // 
            // ucOpenCloseHours
            // 
            this.ucOpenCloseHours.CurrentStore = null;
            this.ucOpenCloseHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOpenCloseHours.EndDate = new System.DateTime(((long)(0)));
            this.ucOpenCloseHours.Entity = null;
            this.ucOpenCloseHours.EntityOpenCloseTime = null;
            this.ucOpenCloseHours.Location = new System.Drawing.Point(2, 2);
            this.ucOpenCloseHours.LookAndFeel.SkinName = "iMaginary";
            this.ucOpenCloseHours.Name = "ucOpenCloseHours";
            this.ucOpenCloseHours.OpenCloseTimes = null;
            this.ucOpenCloseHours.Size = new System.Drawing.Size(470, 383);
            this.ucOpenCloseHours.StartDate = new System.DateTime(((long)(0)));
            this.ucOpenCloseHours.TabIndex = 0;
            this.ucOpenCloseHours.OnEntityChanged += new Baumax.ClientUI.FormEntities.EntityStore.UCOpenCloseHours.DlgEntityChanged(this.ucOpenCloseHours_OnEntityChanged);
            this.ucOpenCloseHours.DeleteWorkingHours += new System.EventHandler(this.ucOpenCloseHours_DeleteWorkingHours);
            // 
            // gp_Store
            // 
            this.gp_Store.Controls.Add(this.lookUpEditStores);
            this.gp_Store.Dock = System.Windows.Forms.DockStyle.Top;
            this.gp_Store.Location = new System.Drawing.Point(0, 30);
            this.gp_Store.Name = "gp_Store";
            this.gp_Store.Size = new System.Drawing.Size(712, 45);
            this.gp_Store.TabIndex = 3;
            this.gp_Store.Text = "Store";
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
            this.lookUpEditStores.Size = new System.Drawing.Size(708, 20);
            this.lookUpEditStores.TabIndex = 0;
            this.lookUpEditStores.EditValueChanged += new System.EventHandler(this.lookUpEditStores_EditValueChanged);
            this.lookUpEditStores.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.lookUpEditStores_QueryPopUp);
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbl_OpenCloseHours);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(712, 30);
            this.panelControl2.TabIndex = 4;
            // 
            // lbl_OpenCloseHours
            // 
            this.lbl_OpenCloseHours.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_OpenCloseHours.Appearance.Options.UseFont = true;
            this.lbl_OpenCloseHours.Appearance.Options.UseTextOptions = true;
            this.lbl_OpenCloseHours.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_OpenCloseHours.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_OpenCloseHours.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbl_OpenCloseHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_OpenCloseHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OpenCloseHours.Location = new System.Drawing.Point(2, 2);
            this.lbl_OpenCloseHours.Name = "lbl_OpenCloseHours";
            this.lbl_OpenCloseHours.Size = new System.Drawing.Size(708, 26);
            this.lbl_OpenCloseHours.TabIndex = 0;
            this.lbl_OpenCloseHours.Text = "Open Close Hours";
            // 
            // UCOpenCloseHoursList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcOpenCloseControl);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.gp_Store);
            this.Controls.Add(this.panelControl2);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCOpenCloseHoursList";
            this.Size = new System.Drawing.Size(712, 462);
            this.Resize += new System.EventHandler(this.UCOpenCloseHoursList_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOpenCloseControl)).EndInit();
            this.pcOpenCloseControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gp_Store)).EndInit();
            this.gp_Store.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_EndDate;
        private DevExpress.XtraEditors.PanelControl pcOpenCloseControl;
        private DevExpress.XtraEditors.GroupControl gp_Store;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_OpenCloseHours;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewOpenCloseRange;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteOpenCloseRange;
        private DevExpress.XtraEditors.GridLookUpEdit lookUpEditStores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
        private UCOpenCloseHours ucOpenCloseHours;
    }
}
