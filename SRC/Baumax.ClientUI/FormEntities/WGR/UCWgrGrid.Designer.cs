namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCWgrGrid
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
            this.gridControlWGR = new DevExpress.XtraGrid.GridControl();
            this.gridViewWGR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewHWGR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_NewWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_EditWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeleteWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_RefreshWGR = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHWGR)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlWGR
            // 
            this.gridControlWGR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWGR.EmbeddedNavigator.Name = "";
            this.gridControlWGR.Location = new System.Drawing.Point(0, 0);
            this.gridControlWGR.MainView = this.gridViewWGR;
            this.gridControlWGR.Name = "gridControlWGR";
            this.gridControlWGR.Size = new System.Drawing.Size(618, 478);
            this.gridControlWGR.TabIndex = 0;
            this.gridControlWGR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWGR,
            this.gridViewHWGR});
            this.gridControlWGR.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubliClick);
            this.gridControlWGR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcKeyDown);
            // 
            // gridViewWGR
            // 
            this.gridViewWGR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Name,
            this.gc_Import});
            this.gridViewWGR.GridControl = this.gridControlWGR;
            this.gridViewWGR.Name = "gridViewWGR";
            this.gridViewWGR.OptionsBehavior.Editable = false;
            this.gridViewWGR.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewWGR.OptionsView.ShowGroupPanel = false;
            this.gridViewWGR.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFocusedRowChanged);
            this.gridViewWGR.RowCountChanged += new System.EventHandler(this.gvRowCountChanged);
            // 
            // gc_Name
            // 
            this.gc_Name.Caption = "Name";
            this.gc_Name.FieldName = "Name";
            this.gc_Name.Name = "gc_Name";
            this.gc_Name.Visible = true;
            this.gc_Name.VisibleIndex = 0;
            // 
            // gc_Import
            // 
            this.gc_Import.Caption = "Imported";
            this.gc_Import.FieldName = "Import";
            this.gc_Import.Name = "gc_Import";
            this.gc_Import.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gc_Import.Visible = true;
            this.gc_Import.VisibleIndex = 1;
            // 
            // gridViewHWGR
            // 
            this.gridViewHWGR.GridControl = this.gridControlWGR;
            this.gridViewHWGR.Name = "gridViewHWGR";
            this.gridViewHWGR.OptionsBehavior.Editable = false;
            this.gridViewHWGR.OptionsView.ShowGroupPanel = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NewWGR,
            this.ts_EditWGR,
            this.ts_DeleteWGR,
            this.toolStripSeparator1,
            this.ts_RefreshWGR});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOpening);
            // 
            // ts_NewWGR
            // 
            this.ts_NewWGR.Name = "ts_NewWGR";
            this.ts_NewWGR.Size = new System.Drawing.Size(166, 22);
            this.ts_NewWGR.Text = "New WGR";
            this.ts_NewWGR.Click += new System.EventHandler(this.tsNewWGRClick);
            // 
            // ts_EditWGR
            // 
            this.ts_EditWGR.Name = "ts_EditWGR";
            this.ts_EditWGR.Size = new System.Drawing.Size(166, 22);
            this.ts_EditWGR.Text = "Edit WGR";
            this.ts_EditWGR.Click += new System.EventHandler(this.tsEditWGRClick);
            // 
            // ts_DeleteWGR
            // 
            this.ts_DeleteWGR.Name = "ts_DeleteWGR";
            this.ts_DeleteWGR.Size = new System.Drawing.Size(166, 22);
            this.ts_DeleteWGR.Text = "Delete WGR";
            this.ts_DeleteWGR.Click += new System.EventHandler(this.tsDeleteWGRClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // ts_RefreshWGR
            // 
            this.ts_RefreshWGR.Name = "ts_RefreshWGR";
            this.ts_RefreshWGR.Size = new System.Drawing.Size(166, 22);
            this.ts_RefreshWGR.Text = "Refresh WGR list";
            // 
            // UCWgrGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlWGR);
            this.Name = "UCWgrGrid";
            this.Size = new System.Drawing.Size(618, 478);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHWGR)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlWGR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWGR;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Import;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ts_NewWGR;
        private System.Windows.Forms.ToolStripMenuItem ts_EditWGR;
        private System.Windows.Forms.ToolStripMenuItem ts_DeleteWGR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ts_RefreshWGR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHWGR;
    }
}
