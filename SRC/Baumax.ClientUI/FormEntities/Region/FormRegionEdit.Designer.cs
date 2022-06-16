namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormRegionEdit
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
            this.lbl_EditRegion = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblRegion = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage_DefineBufferHours = new DevExpress.XtraTab.XtraTabPage();
            this.ucBufferHoursView1 = new Baumax.ClientUI.FormEntities.Region.UCBufferHoursView();
            this.tabPage_DefineBenchmarks = new DevExpress.XtraTab.XtraTabPage();
            this.ucBenchmarksView1 = new Baumax.ClientUI.FormEntities.Region.UCBenchmarksView();
            this.tabPage_DefineTrendcorrections = new DevExpress.XtraTab.XtraTabPage();
            this.ucTrendCorrectionsView1 = new Baumax.ClientUI.FormEntities.Region.UCTrendCorrectionsView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpStores = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_StoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbl_Store = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPage_DefineBufferHours.SuspendLayout();
            this.tabPage_DefineBenchmarks.SuspendLayout();
            this.tabPage_DefineTrendcorrections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_EditRegion);
            this.panelTop.Size = new System.Drawing.Size(846, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.xtraTabControl1);
            this.panelClient.Controls.Add(this.panelControl2);
            this.panelClient.Controls.Add(this.panelControl1);
            this.panelClient.Size = new System.Drawing.Size(846, 493);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(1634, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 527);
            this.panelBottom.Size = new System.Drawing.Size(846, 40);
            // 
            // lbl_EditRegion
            // 
            this.lbl_EditRegion.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_EditRegion.Appearance.Options.UseFont = true;
            this.lbl_EditRegion.Appearance.Options.UseTextOptions = true;
            this.lbl_EditRegion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_EditRegion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_EditRegion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EditRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EditRegion.Location = new System.Drawing.Point(2, 2);
            this.lbl_EditRegion.Name = "lbl_EditRegion";
            this.lbl_EditRegion.Size = new System.Drawing.Size(842, 30);
            this.lbl_EditRegion.TabIndex = 0;
            this.lbl_EditRegion.Text = "Edit region";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblRegion);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(842, 30);
            this.panelControl1.TabIndex = 0;
            // 
            // lblRegion
            // 
            this.lblRegion.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRegion.Appearance.Options.UseFont = true;
            this.lblRegion.Appearance.Options.UseTextOptions = true;
            this.lblRegion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblRegion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRegion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegion.Location = new System.Drawing.Point(2, 2);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(838, 26);
            this.lblRegion.TabIndex = 1;
            this.lblRegion.Text = "Region:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 62);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabPage_DefineBufferHours;
            this.xtraTabControl1.Size = new System.Drawing.Size(842, 429);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage_DefineBufferHours,
            this.tabPage_DefineBenchmarks,
            this.tabPage_DefineTrendcorrections});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // tabPage_DefineBufferHours
            // 
            this.tabPage_DefineBufferHours.Controls.Add(this.ucBufferHoursView1);
            this.tabPage_DefineBufferHours.Name = "tabPage_DefineBufferHours";
            this.tabPage_DefineBufferHours.Size = new System.Drawing.Size(833, 399);
            this.tabPage_DefineBufferHours.Text = "Define buffer-hours";
            // 
            // ucBufferHoursView1
            // 
            this.ucBufferHoursView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBufferHoursView1.Entity = null;
            this.ucBufferHoursView1.EntityStore = null;
            this.ucBufferHoursView1.Location = new System.Drawing.Point(0, 0);
            this.ucBufferHoursView1.LookAndFeel.SkinName = "iMaginary";
            this.ucBufferHoursView1.Name = "ucBufferHoursView1";
            this.ucBufferHoursView1.Size = new System.Drawing.Size(833, 399);
            this.ucBufferHoursView1.SWController = null;
            this.ucBufferHoursView1.TabIndex = 0;
            // 
            // tabPage_DefineBenchmarks
            // 
            this.tabPage_DefineBenchmarks.Controls.Add(this.ucBenchmarksView1);
            this.tabPage_DefineBenchmarks.Name = "tabPage_DefineBenchmarks";
            this.tabPage_DefineBenchmarks.Size = new System.Drawing.Size(613, 107);
            this.tabPage_DefineBenchmarks.Text = "Define benchmarks";
            // 
            // ucBenchmarksView1
            // 
            this.ucBenchmarksView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBenchmarksView1.Entity = null;
            this.ucBenchmarksView1.EntityStore = null;
            this.ucBenchmarksView1.Location = new System.Drawing.Point(0, 0);
            this.ucBenchmarksView1.LookAndFeel.SkinName = "iMaginary";
            this.ucBenchmarksView1.Name = "ucBenchmarksView1";
            this.ucBenchmarksView1.Size = new System.Drawing.Size(613, 107);
            this.ucBenchmarksView1.SWController = null;
            this.ucBenchmarksView1.TabIndex = 0;
            // 
            // tabPage_DefineTrendcorrections
            // 
            this.tabPage_DefineTrendcorrections.Controls.Add(this.ucTrendCorrectionsView1);
            this.tabPage_DefineTrendcorrections.Name = "tabPage_DefineTrendcorrections";
            this.tabPage_DefineTrendcorrections.Size = new System.Drawing.Size(613, 107);
            this.tabPage_DefineTrendcorrections.Text = "Define trend corrections";
            // 
            // ucTrendCorrectionsView1
            // 
            this.ucTrendCorrectionsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTrendCorrectionsView1.EndDate = null;
            this.ucTrendCorrectionsView1.Entity = null;
            this.ucTrendCorrectionsView1.EntityStore = null;
            this.ucTrendCorrectionsView1.Location = new System.Drawing.Point(0, 0);
            this.ucTrendCorrectionsView1.LookAndFeel.SkinName = "iMaginary";
            this.ucTrendCorrectionsView1.Name = "ucTrendCorrectionsView1";
            this.ucTrendCorrectionsView1.Size = new System.Drawing.Size(613, 107);
            this.ucTrendCorrectionsView1.StartDate = new System.DateTime(2007, 7, 21, 0, 0, 0, 0);
            this.ucTrendCorrectionsView1.SWController = null;
            this.ucTrendCorrectionsView1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lookUpStores);
            this.panelControl2.Controls.Add(this.lbl_Store);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 32);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(842, 30);
            this.panelControl2.TabIndex = 3;
            // 
            // lookUpStores
            // 
            this.lookUpStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpStores.Location = new System.Drawing.Point(116, 5);
            this.lookUpStores.Name = "lookUpStores";
            this.lookUpStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpStores.Properties.DisplayMember = "Name";
            this.lookUpStores.Properties.NullText = "";
            this.lookUpStores.Properties.ValueMember = "ID";
            this.lookUpStores.Properties.View = this.gridLookUpEdit1View;
            this.lookUpStores.Size = new System.Drawing.Size(721, 20);
            this.lookUpStores.TabIndex = 1;
            this.lookUpStores.EditValueChanged += new System.EventHandler(this.lookUpStores_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_StoreName,
            this.gridColumn_City,
            this.gridColumn_Address,
            this.gridColumn_PostCode,
            this.gridColumn_Area});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_StoreName
            // 
            this.gridColumn_StoreName.Caption = "Store";
            this.gridColumn_StoreName.FieldName = "Name";
            this.gridColumn_StoreName.Name = "gridColumn_StoreName";
            this.gridColumn_StoreName.Visible = true;
            this.gridColumn_StoreName.VisibleIndex = 0;
            // 
            // gridColumn_City
            // 
            this.gridColumn_City.Caption = "City";
            this.gridColumn_City.FieldName = "City";
            this.gridColumn_City.Name = "gridColumn_City";
            this.gridColumn_City.Visible = true;
            this.gridColumn_City.VisibleIndex = 1;
            // 
            // gridColumn_Address
            // 
            this.gridColumn_Address.Caption = "Address";
            this.gridColumn_Address.FieldName = "Address";
            this.gridColumn_Address.Name = "gridColumn_Address";
            this.gridColumn_Address.Visible = true;
            this.gridColumn_Address.VisibleIndex = 2;
            // 
            // gridColumn_PostCode
            // 
            this.gridColumn_PostCode.Caption = "PostCode";
            this.gridColumn_PostCode.FieldName = "Number";
            this.gridColumn_PostCode.Name = "gridColumn_PostCode";
            this.gridColumn_PostCode.Visible = true;
            this.gridColumn_PostCode.VisibleIndex = 3;
            // 
            // gridColumn_Area
            // 
            this.gridColumn_Area.Caption = "Area";
            this.gridColumn_Area.FieldName = "Area";
            this.gridColumn_Area.Name = "gridColumn_Area";
            this.gridColumn_Area.Visible = true;
            this.gridColumn_Area.VisibleIndex = 4;
            // 
            // lbl_Store
            // 
            this.lbl_Store.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Store.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Store.Location = new System.Drawing.Point(2, 2);
            this.lbl_Store.Name = "lbl_Store";
            this.lbl_Store.Size = new System.Drawing.Size(108, 26);
            this.lbl_Store.TabIndex = 0;
            this.lbl_Store.Text = "Store";
            // 
            // FormRegionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 567);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormRegionEdit";
            this.Text = "    ";
            this.Resize += new System.EventHandler(this.FormRegionEdit_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPage_DefineBufferHours.ResumeLayout(false);
            this.tabPage_DefineBenchmarks.ResumeLayout(false);
            this.tabPage_DefineTrendcorrections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_EditRegion;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblRegion;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPage_DefineBufferHours;
        private DevExpress.XtraTab.XtraTabPage tabPage_DefineBenchmarks;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit lookUpStores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lbl_Store;
        private DevExpress.XtraTab.XtraTabPage tabPage_DefineTrendcorrections;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_StoreName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_City;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Area;
        private UCBufferHoursView ucBufferHoursView1;
        private UCBenchmarksView ucBenchmarksView1;
        private UCTrendCorrectionsView ucTrendCorrectionsView1;
    }
}