namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCWorldGrid
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewWorld = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_NewWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_EditWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeleteWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridViewWorld;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(567, 328);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWorld,
            this.gridView2});
            this.gridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcKeyDown);
            // 
            // gridViewWorld
            // 
            this.gridViewWorld.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Name,
            this.gc_Import,
            this.gc_Type});
            this.gridViewWorld.GridControl = this.gridControl1;
            this.gridViewWorld.Name = "gridViewWorld";
            this.gridViewWorld.OptionsBehavior.Editable = false;
            this.gridViewWorld.OptionsView.ShowGroupPanel = false;
            this.gridViewWorld.RowCountChanged += new System.EventHandler(this.gvRowCountChanged);
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
            this.gc_Import.Caption = "Import";
            this.gc_Import.FieldName = "Import";
            this.gc_Import.Name = "gc_Import";
            this.gc_Import.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gc_Import.Visible = true;
            this.gc_Import.VisibleIndex = 1;
            // 
            // gc_Type
            // 
            this.gc_Type.Caption = "Type";
            this.gc_Type.FieldName = "WorldTypeID";
            this.gc_Type.Name = "gc_Type";
            this.gc_Type.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gc_Type.Visible = true;
            this.gc_Type.VisibleIndex = 2;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NewWorld,
            this.ts_EditWorld,
            this.ts_DeleteWorld,
            this.toolStripSeparator1,
            this.ts_Refresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 98);
            // 
            // ts_NewWorld
            // 
            this.ts_NewWorld.Name = "ts_NewWorld";
            this.ts_NewWorld.Size = new System.Drawing.Size(147, 22);
            this.ts_NewWorld.Text = "New World";
            this.ts_NewWorld.Click += new System.EventHandler(this.tsNewWorldClick);
            // 
            // ts_EditWorld
            // 
            this.ts_EditWorld.Name = "ts_EditWorld";
            this.ts_EditWorld.Size = new System.Drawing.Size(147, 22);
            this.ts_EditWorld.Text = "Edit World";
            this.ts_EditWorld.Click += new System.EventHandler(this.tsEditWorldClick);
            // 
            // ts_DeleteWorld
            // 
            this.ts_DeleteWorld.Name = "ts_DeleteWorld";
            this.ts_DeleteWorld.Size = new System.Drawing.Size(147, 22);
            this.ts_DeleteWorld.Text = "Delete World";
            this.ts_DeleteWorld.Click += new System.EventHandler(this.tsDeleteWorldClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // ts_Refresh
            // 
            this.ts_Refresh.Name = "ts_Refresh";
            this.ts_Refresh.Size = new System.Drawing.Size(147, 22);
            this.ts_Refresh.Text = "Refresh";
            // 
            // UCWorldGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "UCWorldGrid";
            this.Size = new System.Drawing.Size(567, 328);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorld;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Import;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Type;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ts_NewWorld;
        private System.Windows.Forms.ToolStripMenuItem ts_EditWorld;
        private System.Windows.Forms.ToolStripMenuItem ts_DeleteWorld;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ts_Refresh;
    }
}
