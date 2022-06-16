namespace Baumax.ClientUI.FormEntities
{
    partial class TreeBaumax
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn_EntityName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuStriptree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_newCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_deleteCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.CountryRegionSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_newRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_deleteRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.RegionStoreSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_newStore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editStore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_deleteStore = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.menuStriptree.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn_EntityName});
            this.treeList1.ContextMenuStrip = this.menuStriptree;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "NodeId";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.Size = new System.Drawing.Size(638, 462);
            this.treeList1.TabIndex = 0;
            // 
            // treeListColumn_EntityName
            // 
            this.treeListColumn_EntityName.Caption = "Entity name";
            this.treeListColumn_EntityName.FieldName = "NodeName";
            this.treeListColumn_EntityName.Name = "treeListColumn_EntityName";
            this.treeListColumn_EntityName.OptionsColumn.AllowEdit = false;
            this.treeListColumn_EntityName.OptionsColumn.ReadOnly = true;
            this.treeListColumn_EntityName.Visible = true;
            this.treeListColumn_EntityName.VisibleIndex = 0;
            // 
            // menuStriptree
            // 
            this.menuStriptree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_newCountry,
            this.toolStripMenuItem_editCountry,
            this.toolStripMenuItem_deleteCountry,
            this.CountryRegionSeparator,
            this.toolStripMenuItem_newRegion,
            this.toolStripMenuItem_editRegion,
            this.toolStripMenuItem_deleteRegion,
            this.RegionStoreSeparator,
            this.toolStripMenuItem_newStore,
            this.toolStripMenuItem_editStore,
            this.toolStripMenuItem_deleteStore});
            this.menuStriptree.Name = "menuStriptree";
            this.menuStriptree.Size = new System.Drawing.Size(157, 236);
            this.menuStriptree.Opening += new System.ComponentModel.CancelEventHandler(this.menuStriptree_Opening);
            // 
            // toolStripMenuItem_newCountry
            // 
            this.toolStripMenuItem_newCountry.Name = "toolStripMenuItem_newCountry";
            this.toolStripMenuItem_newCountry.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_newCountry.Text = "New country";
            this.toolStripMenuItem_newCountry.Click += new System.EventHandler(this.toolStripMenuItem_newCountry_Click);
            // 
            // toolStripMenuItem_editCountry
            // 
            this.toolStripMenuItem_editCountry.Name = "toolStripMenuItem_editCountry";
            this.toolStripMenuItem_editCountry.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_editCountry.Text = "Edit country";
            // 
            // toolStripMenuItem_deleteCountry
            // 
            this.toolStripMenuItem_deleteCountry.Name = "toolStripMenuItem_deleteCountry";
            this.toolStripMenuItem_deleteCountry.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_deleteCountry.Text = "Delete country";
            // 
            // CountryRegionSeparator
            // 
            this.CountryRegionSeparator.Name = "CountryRegionSeparator";
            this.CountryRegionSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // toolStripMenuItem_newRegion
            // 
            this.toolStripMenuItem_newRegion.Name = "toolStripMenuItem_newRegion";
            this.toolStripMenuItem_newRegion.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_newRegion.Text = "New region";
            this.toolStripMenuItem_newRegion.Click += new System.EventHandler(this.toolStripMenuItem_newRegion_Click);
            // 
            // toolStripMenuItem_editRegion
            // 
            this.toolStripMenuItem_editRegion.Name = "toolStripMenuItem_editRegion";
            this.toolStripMenuItem_editRegion.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_editRegion.Text = "Edit region";
            // 
            // toolStripMenuItem_deleteRegion
            // 
            this.toolStripMenuItem_deleteRegion.Name = "toolStripMenuItem_deleteRegion";
            this.toolStripMenuItem_deleteRegion.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_deleteRegion.Text = "Delete region";
            // 
            // RegionStoreSeparator
            // 
            this.RegionStoreSeparator.Name = "RegionStoreSeparator";
            this.RegionStoreSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // toolStripMenuItem_newStore
            // 
            this.toolStripMenuItem_newStore.Name = "toolStripMenuItem_newStore";
            this.toolStripMenuItem_newStore.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_newStore.Text = "New store";
            // 
            // toolStripMenuItem_editStore
            // 
            this.toolStripMenuItem_editStore.Name = "toolStripMenuItem_editStore";
            this.toolStripMenuItem_editStore.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_editStore.Text = "Edit store";
            // 
            // toolStripMenuItem_deleteStore
            // 
            this.toolStripMenuItem_deleteStore.Name = "toolStripMenuItem_deleteStore";
            this.toolStripMenuItem_deleteStore.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem_deleteStore.Text = "Delete store";
            // 
            // TreeBaumax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "TreeBaumax";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.menuStriptree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn_EntityName;
        private System.Windows.Forms.ContextMenuStrip menuStriptree;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newCountry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editCountry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteCountry;
        private System.Windows.Forms.ToolStripSeparator CountryRegionSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newRegion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editRegion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteRegion;
        private System.Windows.Forms.ToolStripSeparator RegionStoreSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newStore;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editStore;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteStore;
    }
}
