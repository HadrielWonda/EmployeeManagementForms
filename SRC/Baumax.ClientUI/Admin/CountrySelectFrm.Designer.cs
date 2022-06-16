namespace Baumax.ClientUI.Admin
{
    partial class CountrySelectFrm
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
            this.lbl_SelectCountries = new DevExpress.XtraEditors.LabelControl();
            this.gridControlCountries = new DevExpress.XtraGrid.GridControl();
            this.gridViewCountries = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_SystemID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_SystemID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_CountryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LanguageName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_SelectCountries);
            this.panelTop.Size = new System.Drawing.Size(694, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.gridControlCountries);
            this.panelClient.Size = new System.Drawing.Size(694, 318);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(942, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 352);
            this.panelBottom.Size = new System.Drawing.Size(694, 40);
            // 
            // lbl_SelectCountries
            // 
            this.lbl_SelectCountries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SelectCountries.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_SelectCountries.Appearance.Options.UseFont = true;
            this.lbl_SelectCountries.Location = new System.Drawing.Point(299, 9);
            this.lbl_SelectCountries.Name = "lbl_SelectCountries";
            this.lbl_SelectCountries.Size = new System.Drawing.Size(96, 16);
            this.lbl_SelectCountries.TabIndex = 0;
            this.lbl_SelectCountries.Text = "Select Country";
            // 
            // gridControlCountries
            // 
            this.gridControlCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCountries.EmbeddedNavigator.Name = "";
            this.gridControlCountries.Location = new System.Drawing.Point(2, 2);
            this.gridControlCountries.MainView = this.gridViewCountries;
            this.gridControlCountries.Name = "gridControlCountries";
            this.gridControlCountries.Size = new System.Drawing.Size(690, 314);
            this.gridControlCountries.TabIndex = 1;
            this.gridControlCountries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCountries});
            this.gridControlCountries.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlCountries_MouseDoubleClick);
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
            this.gridViewCountries.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCountries.OptionsSelection.MultiSelect = true;
            this.gridViewCountries.OptionsSelection.UseIndicatorForSelection = false;
            this.gridViewCountries.OptionsView.ShowGroupPanel = false;
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
            // CountrySelectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 392);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "CountrySelectFrm";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCountries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_SelectCountries;
        private DevExpress.XtraGrid.GridControl gridControlCountries;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCountries;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SystemID1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SystemID2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_CountryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LanguageName;

    }
}