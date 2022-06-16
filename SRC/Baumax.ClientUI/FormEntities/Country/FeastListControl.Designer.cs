namespace Baumax.TestGUIClient.UI.FormEntities.Country
{
    partial class FeastListControl
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
            this.components = new System.ComponentModel.Container();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlFeast = new DevExpress.XtraGrid.GridControl();
            this.gridViewFeast = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_FeastDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.defineNewFeastsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFeastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFeast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFeast)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlFeast);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(380, 343);
            this.panelControl2.TabIndex = 1;
            this.panelControl2.Text = "panelControl2";
            // 
            // gridControlFeast
            // 
            this.gridControlFeast.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlFeast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFeast.EmbeddedNavigator.Name = "";
            this.gridControlFeast.Location = new System.Drawing.Point(2, 2);
            this.gridControlFeast.MainView = this.gridViewFeast;
            this.gridControlFeast.Name = "gridControlFeast";
            this.gridControlFeast.Size = new System.Drawing.Size(376, 339);
            this.gridControlFeast.TabIndex = 0;
            this.gridControlFeast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFeast});
            // 
            // gridViewFeast
            // 
            this.gridViewFeast.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_FeastDate});
            this.gridViewFeast.GridControl = this.gridControlFeast;
            this.gridViewFeast.Name = "gridViewFeast";
            this.gridViewFeast.OptionsBehavior.Editable = false;
            this.gridViewFeast.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewFeast.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewFeast.OptionsFilter.AllowFilterEditor = false;
            this.gridViewFeast.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewFeast.OptionsMenu.EnableColumnMenu = false;
            this.gridViewFeast.OptionsMenu.EnableFooterMenu = false;
            this.gridViewFeast.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewFeast.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_FeastDate
            // 
            this.gridColumn_FeastDate.Caption = "Date";
            this.gridColumn_FeastDate.Name = "gridColumn_FeastDate";
            this.gridColumn_FeastDate.Visible = true;
            this.gridColumn_FeastDate.VisibleIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineNewFeastsToolStripMenuItem,
            this.deleteFeastToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // defineNewFeastsToolStripMenuItem
            // 
            this.defineNewFeastsToolStripMenuItem.Name = "defineNewFeastsToolStripMenuItem";
            this.defineNewFeastsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.defineNewFeastsToolStripMenuItem.Text = "Define new feasts";
            this.defineNewFeastsToolStripMenuItem.Click += new System.EventHandler(this.defineNewFeastsToolStripMenuItem_Click);
            // 
            // deleteFeastToolStripMenuItem
            // 
            this.deleteFeastToolStripMenuItem.Name = "deleteFeastToolStripMenuItem";
            this.deleteFeastToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deleteFeastToolStripMenuItem.Text = "Delete feast";
            this.deleteFeastToolStripMenuItem.Click += new System.EventHandler(this.deleteFeastToolStripMenuItem_Click);
            // 
            // FeastListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelControl2);
            this.Name = "FeastListControl";
            this.Size = new System.Drawing.Size(380, 343);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFeast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFeast)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControlFeast;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFeast;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_FeastDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem defineNewFeastsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFeastToolStripMenuItem;
    }
}
