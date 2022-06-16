namespace Baumax.ClientUI.TranslationUI
{
    partial class TranslationUIControl
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
            this.lookUpEditTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControlUI = new DevExpress.XtraGrid.GridControl();
            this.gridViewUI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumnTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpEditTo);
            this.panelControl1.Controls.Add(this.lookUpEditFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(704, 34);
            this.panelControl1.TabIndex = 0;
            // 
            // lookUpEditTo
            // 
            this.lookUpEditTo.Location = new System.Drawing.Point(252, 7);
            this.lookUpEditTo.Name = "lookUpEditTo";
            this.lookUpEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditTo.Properties.DisplayMember = "Name";
            this.lookUpEditTo.Properties.NullText = "";
            this.lookUpEditTo.Properties.ValueMember = "ID";
            this.lookUpEditTo.Size = new System.Drawing.Size(207, 20);
            this.lookUpEditTo.TabIndex = 1;
            this.lookUpEditTo.EditValueChanged += new System.EventHandler(this.lookUpEditTo_EditValueChanged);
            // 
            // lookUpEditFrom
            // 
            this.lookUpEditFrom.Location = new System.Drawing.Point(18, 7);
            this.lookUpEditFrom.Name = "lookUpEditFrom";
            this.lookUpEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 70, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditFrom.Properties.DisplayMember = "Name";
            this.lookUpEditFrom.Properties.NullText = "";
            this.lookUpEditFrom.Properties.ValueMember = "ID";
            this.lookUpEditFrom.Size = new System.Drawing.Size(207, 20);
            this.lookUpEditFrom.TabIndex = 0;
            this.lookUpEditFrom.EditValueChanged += new System.EventHandler(this.lookUpEditTo_EditValueChanged);
            // 
            // gridControlUI
            // 
            this.gridControlUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUI.EmbeddedNavigator.Name = "";
            this.gridControlUI.Location = new System.Drawing.Point(0, 34);
            this.gridControlUI.MainView = this.gridViewUI;
            this.gridControlUI.Name = "gridControlUI";
            this.gridControlUI.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemEdit});
            this.gridControlUI.Size = new System.Drawing.Size(704, 591);
            this.gridControlUI.TabIndex = 1;
            this.gridControlUI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUI,
            this.gridView2});
            // 
            // gridViewUI
            // 
            this.gridViewUI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnFrom,
            this.gridColumnTo});
            this.gridViewUI.GridControl = this.gridControlUI;
            this.gridViewUI.Name = "gridViewUI";
            this.gridViewUI.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewUI.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewUI.OptionsFilter.AllowFilterEditor = false;
            this.gridViewUI.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewUI.OptionsMenu.EnableColumnMenu = false;
            this.gridViewUI.OptionsMenu.EnableFooterMenu = false;
            this.gridViewUI.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewUI.OptionsView.RowAutoHeight = true;
            this.gridViewUI.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewUI.OptionsView.ShowGroupPanel = false;
            this.gridViewUI.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridViewUI_ShowingEditor);
            this.gridViewUI.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewUI_CellValueChanged);
            // 
            // gridColumnFrom
            // 
            this.gridColumnFrom.Caption = "From";
            this.gridColumnFrom.ColumnEdit = this.repItemEdit;
            this.gridColumnFrom.FieldName = "NameFrom";
            this.gridColumnFrom.Name = "gridColumnFrom";
            this.gridColumnFrom.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumnFrom.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnFrom.OptionsFilter.AllowFilter = false;
            this.gridColumnFrom.Visible = true;
            this.gridColumnFrom.VisibleIndex = 0;
            // 
            // repItemEdit
            // 
            this.repItemEdit.MaxLength = 500;
            this.repItemEdit.Name = "repItemEdit";
            // 
            // gridColumnTo
            // 
            this.gridColumnTo.Caption = "To";
            this.gridColumnTo.ColumnEdit = this.repItemEdit;
            this.gridColumnTo.FieldName = "NameTo";
            this.gridColumnTo.Name = "gridColumnTo";
            this.gridColumnTo.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumnTo.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnTo.OptionsFilter.AllowFilter = false;
            this.gridColumnTo.Visible = true;
            this.gridColumnTo.VisibleIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlUI;
            this.gridView2.Name = "gridView2";
            // 
            // TranslationUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlUI);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "TranslationUIControl";
            this.Size = new System.Drawing.Size(704, 625);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlUI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemEdit;
    }
}
