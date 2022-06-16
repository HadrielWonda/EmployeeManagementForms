namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCHwgrGrid
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
            this.gridViewHWGR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmsHWGR = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_NewHWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_EditHWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeleteHWGR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHWGR)).BeginInit();
            this.cmsHWGR.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridViewHWGR;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(566, 397);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHWGR});
            this.gridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcKeyDown);
            // 
            // gridViewHWGR
            // 
            this.gridViewHWGR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Name,
            this.gc_Import});
            this.gridViewHWGR.GridControl = this.gridControl1;
            this.gridViewHWGR.Name = "gridViewHWGR";
            this.gridViewHWGR.OptionsBehavior.Editable = false;
            this.gridViewHWGR.OptionsView.ShowGroupPanel = false;
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
            this.gc_Import.Visible = true;
            this.gc_Import.VisibleIndex = 1;
            // 
            // cmsHWGR
            // 
            this.cmsHWGR.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NewHWGR,
            this.ts_EditHWGR,
            this.ts_DeleteHWGR,
            this.toolStripSeparator1,
            this.ts_Refresh});
            this.cmsHWGR.Name = "cmsHWGR";
            this.cmsHWGR.Size = new System.Drawing.Size(153, 120);
            // 
            // ts_NewHWGR
            // 
            this.ts_NewHWGR.Enabled = false;
            this.ts_NewHWGR.Name = "ts_NewHWGR";
            this.ts_NewHWGR.Size = new System.Drawing.Size(152, 22);
            this.ts_NewHWGR.Text = "New HWGR";
            this.ts_NewHWGR.Click += new System.EventHandler(this.tsNewHWGRClick);
            // 
            // ts_EditHWGR
            // 
            this.ts_EditHWGR.Enabled = false;
            this.ts_EditHWGR.Name = "ts_EditHWGR";
            this.ts_EditHWGR.Size = new System.Drawing.Size(152, 22);
            this.ts_EditHWGR.Text = "Edit HWGR";
            this.ts_EditHWGR.Click += new System.EventHandler(this.tsEditHWGRClick);
            // 
            // ts_DeleteHWGR
            // 
            this.ts_DeleteHWGR.Enabled = false;
            this.ts_DeleteHWGR.Name = "ts_DeleteHWGR";
            this.ts_DeleteHWGR.Size = new System.Drawing.Size(152, 22);
            this.ts_DeleteHWGR.Text = "Delete HWGR";
            this.ts_DeleteHWGR.Click += new System.EventHandler(this.tsDeleteHWGRClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // ts_Refresh
            // 
            this.ts_Refresh.Name = "ts_Refresh";
            this.ts_Refresh.Size = new System.Drawing.Size(152, 22);
            this.ts_Refresh.Text = "Refresh";
            // 
            // UCHwgrGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCHwgrGrid";
            this.Size = new System.Drawing.Size(566, 397);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHWGR)).EndInit();
            this.cmsHWGR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHWGR;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Import;
        private System.Windows.Forms.ContextMenuStrip cmsHWGR;
        private System.Windows.Forms.ToolStripMenuItem ts_NewHWGR;
        private System.Windows.Forms.ToolStripMenuItem ts_EditHWGR;
        private System.Windows.Forms.ToolStripMenuItem ts_DeleteHWGR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ts_Refresh;
    }
}
