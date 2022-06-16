namespace Baumax.ClientUI.NotificationServiceUI
{
	partial class UCCountriesListNotification
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
			this.gridControlCountries = new DevExpress.XtraGrid.GridControl();
			this.gridViewCountries = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_SystemID1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_SystemID2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_CountryName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_LanguageName = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCountries)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControlCountries
			// 
			this.gridControlCountries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControlCountries.EmbeddedNavigator.Name = "";
			this.gridControlCountries.Location = new System.Drawing.Point(0, 0);
			this.gridControlCountries.MainView = this.gridViewCountries;
			this.gridControlCountries.Name = "gridControlCountries";
			this.gridControlCountries.Size = new System.Drawing.Size(572, 232);
			this.gridControlCountries.TabIndex = 1;
			this.gridControlCountries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCountries});
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
			// UCCountriesListNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControlCountries);
			this.MinimumSize = new System.Drawing.Size(572, 232);
			this.Name = "UCCountriesListNotification";
			this.Size = new System.Drawing.Size(572, 232);
			((System.ComponentModel.ISupportInitialize)(this.gridControlCountries)).EndInit();
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
	}
}
