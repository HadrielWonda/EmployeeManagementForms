namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCCashDeskDailyPlannedInfo
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
            this.gcCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repMultiLines = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblAvailableWorldBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumPresence = new DevExpress.XtraEditors.LabelControl();
            this.lblMinimumPresence = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMultiLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repMultiLines,
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gridControl.Size = new System.Drawing.Size(761, 442);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCaption,
            this.gcResult});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowRowSizing = true;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsFilter.AllowMRUFilterList = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
            // 
            // gcCaption
            // 
            this.gcCaption.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.gcCaption.AppearanceCell.Options.UseFont = true;
            this.gcCaption.AppearanceCell.Options.UseTextOptions = true;
            this.gcCaption.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcCaption.ColumnEdit = this.repMultiLines;
            this.gcCaption.FieldName = "ItemName";
            this.gcCaption.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcCaption.MinWidth = 100;
            this.gcCaption.Name = "gcCaption";
            this.gcCaption.OptionsColumn.AllowEdit = false;
            this.gcCaption.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcCaption.OptionsColumn.AllowMove = false;
            this.gcCaption.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcCaption.OptionsColumn.ReadOnly = true;
            this.gcCaption.OptionsColumn.ShowInCustomizationForm = false;
            this.gcCaption.OptionsFilter.AllowAutoFilter = false;
            this.gcCaption.OptionsFilter.AllowFilter = false;
            this.gcCaption.Visible = true;
            this.gcCaption.VisibleIndex = 0;
            this.gcCaption.Width = 120;
            // 
            // repMultiLines
            // 
            this.repMultiLines.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.repMultiLines.Appearance.Options.UseFont = true;
            this.repMultiLines.Appearance.Options.UseTextOptions = true;
            this.repMultiLines.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.repMultiLines.Name = "repMultiLines";
            // 
            // gcResult
            // 
            this.gcResult.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.gcResult.AppearanceCell.Options.UseFont = true;
            this.gcResult.AppearanceCell.Options.UseTextOptions = true;
            this.gcResult.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gcResult.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcResult.FieldName = "unnamed";
            this.gcResult.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gcResult.MinWidth = 100;
            this.gcResult.Name = "gcResult";
            this.gcResult.OptionsColumn.AllowEdit = false;
            this.gcResult.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcResult.OptionsColumn.AllowMove = false;
            this.gcResult.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcResult.OptionsColumn.ReadOnly = true;
            this.gcResult.OptionsColumn.ShowInCustomizationForm = false;
            this.gcResult.OptionsFilter.AllowAutoFilter = false;
            this.gcResult.OptionsFilter.AllowFilter = false;
            this.gcResult.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcResult.Visible = true;
            this.gcResult.VisibleIndex = 1;
            this.gcResult.Width = 250;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.repositoryItemMemoEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.repositoryItemTextEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lblAvailableWorldBufferHours);
            this.panelControl4.Controls.Add(this.lblMaximumPresence);
            this.panelControl4.Controls.Add(this.lblMinimumPresence);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 442);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(761, 20);
            this.panelControl4.TabIndex = 6;
            // 
            // lblAvailableWorldBufferHours
            // 
            this.lblAvailableWorldBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailableWorldBufferHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAvailableWorldBufferHours.Location = new System.Drawing.Point(310, 1);
            this.lblAvailableWorldBufferHours.Name = "lblAvailableWorldBufferHours";
            this.lblAvailableWorldBufferHours.Size = new System.Drawing.Size(208, 15);
            this.lblAvailableWorldBufferHours.TabIndex = 13;
            this.lblAvailableWorldBufferHours.Text = "Available world buffer hours :";
            // 
            // lblMaximumPresence
            // 
            this.lblMaximumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaximumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMaximumPresence.Location = new System.Drawing.Point(149, 1);
            this.lblMaximumPresence.Name = "lblMaximumPresence";
            this.lblMaximumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMaximumPresence.TabIndex = 12;
            this.lblMaximumPresence.Text = "Maximum presence:";
            // 
            // lblMinimumPresence
            // 
            this.lblMinimumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMinimumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMinimumPresence.Location = new System.Drawing.Point(5, 1);
            this.lblMinimumPresence.Name = "lblMinimumPresence";
            this.lblMinimumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMinimumPresence.TabIndex = 11;
            this.lblMinimumPresence.Text = "Minimum presence:";
            // 
            // UCCashDeskDailyPlannedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl4);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCCashDeskDailyPlannedInfo";
            this.Size = new System.Drawing.Size(761, 462);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMultiLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gcCaption;
        private DevExpress.XtraGrid.Columns.GridColumn gcResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repMultiLines;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl lblAvailableWorldBufferHours;
        private DevExpress.XtraEditors.LabelControl lblMaximumPresence;
        private DevExpress.XtraEditors.LabelControl lblMinimumPresence;
    }
}
