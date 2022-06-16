namespace Baumax.ClientUI.FormEntities.Country.UIColoring
{
    partial class ColoringListControl
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewColor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_ColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LowCriticalColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridColumn_LowValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LowColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_NormalYValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_NormalColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_NormalXValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_HighColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_HighValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_HighCriticalColor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewColor;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.gridControl.Size = new System.Drawing.Size(638, 344);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewColor});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // gridViewColor
            // 
            this.gridViewColor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_ColorName,
            this.gridColumn_LowCriticalColor,
            this.gridColumn_LowValue,
            this.gridColumn_LowColor,
            this.gridColumn_NormalYValue,
            this.gridColumn_NormalColor,
            this.gridColumn_NormalXValue,
            this.gridColumn_HighColor,
            this.gridColumn_HighValue,
            this.gridColumn_HighCriticalColor});
            this.gridViewColor.GridControl = this.gridControl;
            this.gridViewColor.Name = "gridViewColor";
            this.gridViewColor.OptionsBehavior.Editable = false;
            this.gridViewColor.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewColor.OptionsFilter.AllowFilterEditor = false;
            this.gridViewColor.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewColor.OptionsMenu.EnableColumnMenu = false;
            this.gridViewColor.OptionsMenu.EnableFooterMenu = false;
            this.gridViewColor.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewColor.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_ColorName
            // 
            this.gridColumn_ColorName.Caption = "ColorName";
            this.gridColumn_ColorName.FieldName = "ColorName";
            this.gridColumn_ColorName.Name = "gridColumn_ColorName";
            this.gridColumn_ColorName.OptionsColumn.AllowEdit = false;
            this.gridColumn_ColorName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_ColorName.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_ColorName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_ColorName.OptionsColumn.AllowMove = false;
            this.gridColumn_ColorName.OptionsColumn.ReadOnly = true;
            this.gridColumn_ColorName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_ColorName.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_ColorName.OptionsFilter.AllowFilter = false;
            this.gridColumn_ColorName.Visible = true;
            this.gridColumn_ColorName.VisibleIndex = 0;
            this.gridColumn_ColorName.Width = 220;
            // 
            // gridColumn_LowCriticalColor
            // 
            this.gridColumn_LowCriticalColor.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_LowCriticalColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_LowCriticalColor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn_LowCriticalColor.Caption = "LC Color";
            this.gridColumn_LowCriticalColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_LowCriticalColor.FieldName = "LCColour";
            this.gridColumn_LowCriticalColor.Name = "gridColumn_LowCriticalColor";
            this.gridColumn_LowCriticalColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_LowCriticalColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowCriticalColor.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_LowCriticalColor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowCriticalColor.OptionsColumn.AllowMove = false;
            this.gridColumn_LowCriticalColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_LowCriticalColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LowCriticalColor.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_LowCriticalColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_LowCriticalColor.Visible = true;
            this.gridColumn_LowCriticalColor.VisibleIndex = 1;
            this.gridColumn_LowCriticalColor.Width = 43;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemColorEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemColorEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
            // 
            // gridColumn_LowValue
            // 
            this.gridColumn_LowValue.Caption = "Low Value";
            this.gridColumn_LowValue.FieldName = "L";
            this.gridColumn_LowValue.Name = "gridColumn_LowValue";
            this.gridColumn_LowValue.OptionsColumn.AllowEdit = false;
            this.gridColumn_LowValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowValue.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_LowValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowValue.OptionsColumn.AllowMove = false;
            this.gridColumn_LowValue.OptionsColumn.ReadOnly = true;
            this.gridColumn_LowValue.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LowValue.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_LowValue.OptionsFilter.AllowFilter = false;
            this.gridColumn_LowValue.Visible = true;
            this.gridColumn_LowValue.VisibleIndex = 2;
            this.gridColumn_LowValue.Width = 43;
            // 
            // gridColumn_LowColor
            // 
            this.gridColumn_LowColor.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_LowColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_LowColor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn_LowColor.Caption = "Low Color";
            this.gridColumn_LowColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_LowColor.FieldName = "LColour";
            this.gridColumn_LowColor.Name = "gridColumn_LowColor";
            this.gridColumn_LowColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_LowColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowColor.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_LowColor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LowColor.OptionsColumn.AllowMove = false;
            this.gridColumn_LowColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_LowColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LowColor.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_LowColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_LowColor.Visible = true;
            this.gridColumn_LowColor.VisibleIndex = 3;
            this.gridColumn_LowColor.Width = 43;
            // 
            // gridColumn_NormalYValue
            // 
            this.gridColumn_NormalYValue.Caption = "Y Value";
            this.gridColumn_NormalYValue.FieldName = "Y";
            this.gridColumn_NormalYValue.Name = "gridColumn_NormalYValue";
            this.gridColumn_NormalYValue.OptionsColumn.AllowEdit = false;
            this.gridColumn_NormalYValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalYValue.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_NormalYValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalYValue.OptionsColumn.AllowMove = false;
            this.gridColumn_NormalYValue.OptionsColumn.ReadOnly = true;
            this.gridColumn_NormalYValue.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_NormalYValue.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_NormalYValue.OptionsFilter.AllowFilter = false;
            this.gridColumn_NormalYValue.Visible = true;
            this.gridColumn_NormalYValue.VisibleIndex = 4;
            this.gridColumn_NormalYValue.Width = 43;
            // 
            // gridColumn_NormalColor
            // 
            this.gridColumn_NormalColor.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_NormalColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_NormalColor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn_NormalColor.Caption = "Normal Color";
            this.gridColumn_NormalColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_NormalColor.FieldName = "NColour";
            this.gridColumn_NormalColor.Name = "gridColumn_NormalColor";
            this.gridColumn_NormalColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_NormalColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalColor.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_NormalColor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalColor.OptionsColumn.AllowMove = false;
            this.gridColumn_NormalColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_NormalColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_NormalColor.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_NormalColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_NormalColor.Visible = true;
            this.gridColumn_NormalColor.VisibleIndex = 5;
            this.gridColumn_NormalColor.Width = 43;
            // 
            // gridColumn_NormalXValue
            // 
            this.gridColumn_NormalXValue.Caption = "X Value";
            this.gridColumn_NormalXValue.FieldName = "X";
            this.gridColumn_NormalXValue.Name = "gridColumn_NormalXValue";
            this.gridColumn_NormalXValue.OptionsColumn.AllowEdit = false;
            this.gridColumn_NormalXValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalXValue.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_NormalXValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_NormalXValue.OptionsColumn.AllowMove = false;
            this.gridColumn_NormalXValue.OptionsColumn.ReadOnly = true;
            this.gridColumn_NormalXValue.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_NormalXValue.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_NormalXValue.OptionsFilter.AllowFilter = false;
            this.gridColumn_NormalXValue.Visible = true;
            this.gridColumn_NormalXValue.VisibleIndex = 6;
            this.gridColumn_NormalXValue.Width = 43;
            // 
            // gridColumn_HighColor
            // 
            this.gridColumn_HighColor.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_HighColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_HighColor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn_HighColor.Caption = "High Color";
            this.gridColumn_HighColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_HighColor.FieldName = "HColour";
            this.gridColumn_HighColor.Name = "gridColumn_HighColor";
            this.gridColumn_HighColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_HighColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighColor.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_HighColor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighColor.OptionsColumn.AllowMove = false;
            this.gridColumn_HighColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_HighColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_HighColor.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_HighColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_HighColor.Visible = true;
            this.gridColumn_HighColor.VisibleIndex = 7;
            this.gridColumn_HighColor.Width = 43;
            // 
            // gridColumn_HighValue
            // 
            this.gridColumn_HighValue.Caption = "High Value";
            this.gridColumn_HighValue.FieldName = "H";
            this.gridColumn_HighValue.Name = "gridColumn_HighValue";
            this.gridColumn_HighValue.OptionsColumn.AllowEdit = false;
            this.gridColumn_HighValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighValue.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_HighValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighValue.OptionsColumn.AllowMove = false;
            this.gridColumn_HighValue.OptionsColumn.ReadOnly = true;
            this.gridColumn_HighValue.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_HighValue.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_HighValue.OptionsFilter.AllowFilter = false;
            this.gridColumn_HighValue.Visible = true;
            this.gridColumn_HighValue.VisibleIndex = 8;
            this.gridColumn_HighValue.Width = 43;
            // 
            // gridColumn_HighCriticalColor
            // 
            this.gridColumn_HighCriticalColor.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_HighCriticalColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_HighCriticalColor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn_HighCriticalColor.Caption = "HC Color";
            this.gridColumn_HighCriticalColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn_HighCriticalColor.FieldName = "HCColour";
            this.gridColumn_HighCriticalColor.Name = "gridColumn_HighCriticalColor";
            this.gridColumn_HighCriticalColor.OptionsColumn.AllowEdit = false;
            this.gridColumn_HighCriticalColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighCriticalColor.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_HighCriticalColor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_HighCriticalColor.OptionsColumn.AllowMove = false;
            this.gridColumn_HighCriticalColor.OptionsColumn.ReadOnly = true;
            this.gridColumn_HighCriticalColor.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_HighCriticalColor.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_HighCriticalColor.OptionsFilter.AllowFilter = false;
            this.gridColumn_HighCriticalColor.Visible = true;
            this.gridColumn_HighCriticalColor.VisibleIndex = 9;
            this.gridColumn_HighCriticalColor.Width = 53;
            // 
            // ColoringListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gridControl);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ColoringListControl";
            this.Size = new System.Drawing.Size(638, 344);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LowCriticalColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LowValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LowColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_NormalYValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_NormalColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_NormalXValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_HighColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_HighValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_HighCriticalColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ColorName;
    }
}
