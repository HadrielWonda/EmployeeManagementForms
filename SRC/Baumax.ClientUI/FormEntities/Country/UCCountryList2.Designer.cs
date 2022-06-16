namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCCountryList2
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
            this.gridControlCountries = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ImportCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CountryDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RefreshListOfCountries = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewCountries = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_SystemID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_SystemID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_CountryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LanguageName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCountries
            // 
            this.gridControlCountries.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCountries.EmbeddedNavigator.Name = "";
            this.gridControlCountries.Location = new System.Drawing.Point(0, 0);
            this.gridControlCountries.MainView = this.gridViewCountries;
            this.gridControlCountries.Name = "gridControlCountries";
            this.gridControlCountries.Size = new System.Drawing.Size(691, 492);
            this.gridControlCountries.TabIndex = 0;
            this.gridControlCountries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCountries});
            this.gridControlCountries.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlCountries_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ImportCountry,
            this.toolStripMenuItem_EditCountry,
            this.toolStripMenuItem_CountryDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItem_RefreshListOfCountries});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem_ImportCountry
            // 
            this.toolStripMenuItem_ImportCountry.Name = "toolStripMenuItem_ImportCountry";
            this.toolStripMenuItem_ImportCountry.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_ImportCountry.Text = "New country";
            this.toolStripMenuItem_ImportCountry.Click += new System.EventHandler(this.toolStripMenuItem_NewCountry_Click);
            // 
            // toolStripMenuItem_EditCountry
            // 
            this.toolStripMenuItem_EditCountry.Name = "toolStripMenuItem_EditCountry";
            this.toolStripMenuItem_EditCountry.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_EditCountry.Text = "Edit country";
            this.toolStripMenuItem_EditCountry.Click += new System.EventHandler(this.toolStripMenuItem_EditCountry_Click);
            // 
            // toolStripMenuItem_CountryDetails
            // 
            this.toolStripMenuItem_CountryDetails.Name = "toolStripMenuItem_CountryDetails";
            this.toolStripMenuItem_CountryDetails.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_CountryDetails.Text = "Country Details";
            this.toolStripMenuItem_CountryDetails.Click += new System.EventHandler(this.toolStripMenuItem_DeleteCountry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripMenuItem_RefreshListOfCountries
            // 
            this.toolStripMenuItem_RefreshListOfCountries.Name = "toolStripMenuItem_RefreshListOfCountries";
            this.toolStripMenuItem_RefreshListOfCountries.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem_RefreshListOfCountries.Text = "Refresh list of counties";
            // 
            // gridViewCountries
            // 
            this.gridViewCountries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_SystemID1,
            this.gridColumn_SystemID2,
            this.gridColumn_CountryName,
            this.gridColumn_LanguageName});
            this.gridViewCountries.GridControl = this.gridControlCountries;
            this.gridViewCountries.Name = "gridViewCountries";
            this.gridViewCountries.OptionsBehavior.Editable = false;
            this.gridViewCountries.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewCountries.OptionsMenu.EnableColumnMenu = false;
            this.gridViewCountries.OptionsMenu.EnableFooterMenu = false;
            this.gridViewCountries.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewCountries.OptionsView.ShowGroupPanel = false;
            this.gridViewCountries.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCountries_FocusedRowChanged);
            this.gridViewCountries.RowCountChanged += new System.EventHandler(this.gridViewCountries_RowCountChanged);
            this.gridViewCountries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewCountries_KeyDown);
            // 
            // gridColumn_SystemID1
            // 
            this.gridColumn_SystemID1.Caption = "BaumaxID";
            this.gridColumn_SystemID1.FieldName = "SystemID1";
            this.gridColumn_SystemID1.Name = "gridColumn_SystemID1";
            this.gridColumn_SystemID1.OptionsColumn.ReadOnly = true;
            this.gridColumn_SystemID1.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_SystemID1.OptionsFilter.AllowFilter = false;
            this.gridColumn_SystemID1.Width = 55;
            // 
            // gridColumn_SystemID2
            // 
            this.gridColumn_SystemID2.Caption = "Description";
            this.gridColumn_SystemID2.FieldName = "SystemID2";
            this.gridColumn_SystemID2.Name = "gridColumn_SystemID2";
            this.gridColumn_SystemID2.OptionsColumn.ReadOnly = true;
            this.gridColumn_SystemID2.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_SystemID2.OptionsFilter.AllowFilter = false;
            this.gridColumn_SystemID2.Width = 68;
            // 
            // gridColumn_CountryName
            // 
            this.gridColumn_CountryName.Caption = "CountryName";
            this.gridColumn_CountryName.FieldName = "Name";
            this.gridColumn_CountryName.Name = "gridColumn_CountryName";
            this.gridColumn_CountryName.OptionsColumn.ReadOnly = true;
            this.gridColumn_CountryName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_CountryName.OptionsFilter.AllowFilter = false;
            this.gridColumn_CountryName.Visible = true;
            this.gridColumn_CountryName.VisibleIndex = 0;
            this.gridColumn_CountryName.Width = 352;
            // 
            // gridColumn_LanguageName
            // 
            this.gridColumn_LanguageName.Caption = "Language";
            this.gridColumn_LanguageName.FieldName = "LanguageName";
            this.gridColumn_LanguageName.Name = "gridColumn_LanguageName";
            this.gridColumn_LanguageName.OptionsColumn.ReadOnly = true;
            this.gridColumn_LanguageName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LanguageName.OptionsFilter.AllowFilter = false;
            this.gridColumn_LanguageName.Visible = true;
            this.gridColumn_LanguageName.VisibleIndex = 1;
            this.gridColumn_LanguageName.Width = 195;
            // 
            // UCCountryList2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlCountries);
            this.Name = "UCCountryList2";
            this.Size = new System.Drawing.Size(691, 492);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCountries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCountries;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCountries;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SystemID1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SystemID2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_CountryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LanguageName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ImportCountry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditCountry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CountryDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RefreshListOfCountries;
    }
}
