namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCTimePlanning
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
            this.pcHeader = new DevExpress.XtraEditors.PanelControl();
            this.btn_ShowHideWorkingModelMessages = new DevExpress.XtraEditors.SimpleButton();
            this.chk_ShowHideWorkingModelMessages = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroupViews = new DevExpress.XtraEditors.RadioGroup();
            this.storeWorldLookUpCtrl1 = new Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl();
            this.lbl_World = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Store = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditStores = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Region = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcDummy = new DevExpress.XtraEditors.PanelControl();
            this.ucWeekTimePlanning = new Baumax.ClientUI.FormEntities.TimePlanning.UCWeekTimePlanning();
            ((System.ComponentModel.ISupportInitialize)(this.pcHeader)).BeginInit();
            this.pcHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ShowHideWorkingModelMessages.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupViews.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDummy)).BeginInit();
            this.pcDummy.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcHeader
            // 
            this.pcHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcHeader.Controls.Add(this.btn_ShowHideWorkingModelMessages);
            this.pcHeader.Controls.Add(this.chk_ShowHideWorkingModelMessages);
            this.pcHeader.Controls.Add(this.btn_Save);
            this.pcHeader.Controls.Add(this.btn_Print);
            this.pcHeader.Controls.Add(this.radioGroupViews);
            this.pcHeader.Controls.Add(this.storeWorldLookUpCtrl1);
            this.pcHeader.Controls.Add(this.lbl_World);
            this.pcHeader.Controls.Add(this.lbl_Store);
            this.pcHeader.Controls.Add(this.lookUpEditStores);
            this.pcHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcHeader.Location = new System.Drawing.Point(0, 0);
            this.pcHeader.Name = "pcHeader";
            this.pcHeader.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.pcHeader.Size = new System.Drawing.Size(800, 49);
            this.pcHeader.TabIndex = 0;
            // 
            // btn_ShowHideWorkingModelMessages
            // 
            this.btn_ShowHideWorkingModelMessages.Location = new System.Drawing.Point(457, 25);
            this.btn_ShowHideWorkingModelMessages.Name = "btn_ShowHideWorkingModelMessages";
            this.btn_ShowHideWorkingModelMessages.Size = new System.Drawing.Size(313, 23);
            this.btn_ShowHideWorkingModelMessages.TabIndex = 9;
            this.btn_ShowHideWorkingModelMessages.Text = "Show WM";
            this.btn_ShowHideWorkingModelMessages.Click += new System.EventHandler(this.btn_ShowHideWorkingModelMessages_Click);
            // 
            // chk_ShowHideWorkingModelMessages
            // 
            this.chk_ShowHideWorkingModelMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_ShowHideWorkingModelMessages.EditValue = true;
            this.chk_ShowHideWorkingModelMessages.Location = new System.Drawing.Point(612, 26);
            this.chk_ShowHideWorkingModelMessages.Name = "chk_ShowHideWorkingModelMessages";
            this.chk_ShowHideWorkingModelMessages.Properties.Caption = "Show/Hide working model messages";
            this.chk_ShowHideWorkingModelMessages.Size = new System.Drawing.Size(0, 19);
            this.chk_ShowHideWorkingModelMessages.TabIndex = 8;
            this.chk_ShowHideWorkingModelMessages.Visible = false;
            this.chk_ShowHideWorkingModelMessages.CheckedChanged += new System.EventHandler(this.chk_ShowHideWorkingModelMessages_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(625, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(86, 46);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Print.Enabled = false;
            this.btn_Print.Location = new System.Drawing.Point(711, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(86, 46);
            this.btn_Print.TabIndex = 7;
            this.btn_Print.Text = "Print";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // radioGroupViews
            // 
            this.radioGroupViews.EditValue = 0;
            this.radioGroupViews.Location = new System.Drawing.Point(212, 25);
            this.radioGroupViews.Name = "radioGroupViews";
            this.radioGroupViews.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Weekly view"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), "Daily view")});
            this.radioGroupViews.Size = new System.Drawing.Size(239, 21);
            this.radioGroupViews.TabIndex = 6;
            this.radioGroupViews.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
            this.radioGroupViews.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // storeWorldLookUpCtrl1
            // 
            this.storeWorldLookUpCtrl1.CurrentEntity = null;
            this.storeWorldLookUpCtrl1.CurrentId = ((long)(0));
            this.storeWorldLookUpCtrl1.EntityList = null;
            this.storeWorldLookUpCtrl1.InitFirstValue = true;
            this.storeWorldLookUpCtrl1.Location = new System.Drawing.Point(100, 25);
            this.storeWorldLookUpCtrl1.Name = "storeWorldLookUpCtrl1";
            this.storeWorldLookUpCtrl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeWorldLookUpCtrl1.Properties.NullText = "";
            this.storeWorldLookUpCtrl1.Size = new System.Drawing.Size(106, 20);
            this.storeWorldLookUpCtrl1.TabIndex = 4;
            this.storeWorldLookUpCtrl1.WorldId = ((long)(0));
            this.storeWorldLookUpCtrl1.EditValueChanged += new System.EventHandler(this.storeWorldLookUpCtrl1_EditValueChanged);
            // 
            // lbl_World
            // 
            this.lbl_World.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_World.Location = new System.Drawing.Point(6, 26);
            this.lbl_World.Name = "lbl_World";
            this.lbl_World.Size = new System.Drawing.Size(91, 17);
            this.lbl_World.TabIndex = 3;
            this.lbl_World.Text = "World";
            // 
            // lbl_Store
            // 
            this.lbl_Store.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Store.Location = new System.Drawing.Point(6, 6);
            this.lbl_Store.Name = "lbl_Store";
            this.lbl_Store.Size = new System.Drawing.Size(91, 13);
            this.lbl_Store.TabIndex = 2;
            this.lbl_Store.Text = "Store";
            // 
            // lookUpEditStores
            // 
            this.lookUpEditStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditStores.Location = new System.Drawing.Point(100, 3);
            this.lookUpEditStores.Name = "lookUpEditStores";
            this.lookUpEditStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditStores.Properties.DisplayMember = "StoreName";
            this.lookUpEditStores.Properties.NullText = "";
            this.lookUpEditStores.Properties.ValueMember = "ID";
            this.lookUpEditStores.Properties.View = this.gridLookUpEdit1View;
            this.lookUpEditStores.Size = new System.Drawing.Size(502, 20);
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
            // pcDummy
            // 
            this.pcDummy.Controls.Add(this.ucWeekTimePlanning);
            this.pcDummy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcDummy.Location = new System.Drawing.Point(0, 49);
            this.pcDummy.Name = "pcDummy";
            this.pcDummy.Size = new System.Drawing.Size(800, 413);
            this.pcDummy.TabIndex = 1;
            // 
            // ucWeekTimePlanning
            // 
            this.ucWeekTimePlanning.BeginDate = new System.DateTime(((long)(0)));
            this.ucWeekTimePlanning.Context = null;
            this.ucWeekTimePlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWeekTimePlanning.Entity = null;
            this.ucWeekTimePlanning.Location = new System.Drawing.Point(2, 2);
            this.ucWeekTimePlanning.LookAndFeel.SkinName = "iMaginary";
            this.ucWeekTimePlanning.Name = "ucWeekTimePlanning";
            this.ucWeekTimePlanning.Size = new System.Drawing.Size(796, 409);
            this.ucWeekTimePlanning.TabIndex = 0;
            this.ucWeekTimePlanning.EventChangedToDailyView += new Baumax.ClientUI.FormEntities.TimePlanning.ChangedToDailyView(this.ucWeekTimePlanning_EventChangedToDailyView);
            // 
            // UCTimePlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcDummy);
            this.Controls.Add(this.pcHeader);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCTimePlanning";
            this.Size = new System.Drawing.Size(800, 462);
            this.Resize += new System.EventHandler(this.UCTimePlanning_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pcHeader)).EndInit();
            this.pcHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_ShowHideWorkingModelMessages.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupViews.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDummy)).EndInit();
            this.pcDummy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcHeader;
        private DevExpress.XtraEditors.PanelControl pcDummy;
        private DevExpress.XtraEditors.LabelControl lbl_Store;
        private DevExpress.XtraEditors.GridLookUpEdit lookUpEditStores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Country;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Region;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
        private DevExpress.XtraEditors.LabelControl lbl_World;
        private Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl storeWorldLookUpCtrl1;
        private UCWeekTimePlanning ucWeekTimePlanning;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.RadioGroup radioGroupViews;
        private DevExpress.XtraEditors.SimpleButton btn_Print;
        private DevExpress.XtraEditors.CheckEdit chk_ShowHideWorkingModelMessages;
        private DevExpress.XtraEditors.SimpleButton btn_ShowHideWorkingModelMessages;
    }
}
