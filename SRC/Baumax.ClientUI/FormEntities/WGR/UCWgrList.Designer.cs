namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCWgrList
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
            this._ucWgrGrid = new Baumax.ClientUI.FormEntities.WGR.UCWgrGrid();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.grpNED = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_NewWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_EditWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_DeleteWGR = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // _ucWgrGrid
            // 
            this._ucWgrGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ucWgrGrid.Entity = null;
            this._ucWgrGrid.Location = new System.Drawing.Point(0, 0);
            this._ucWgrGrid.Name = "_ucWgrGrid";
            this._ucWgrGrid.Size = new System.Drawing.Size(476, 440);
            this._ucWgrGrid.TabIndex = 0;
            this._ucWgrGrid.WGRList = null;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this._ucWgrGrid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(626, 444);
            this.splitContainerControl1.SplitterPosition = 140;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.grpNED;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpNED});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nb_NewWGR,
            this.nb_EditWGR,
            this.nb_DeleteWGR});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.Size = new System.Drawing.Size(136, 179);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // grpNED
            // 
            this.grpNED.Caption = "";
            this.grpNED.Expanded = true;
            this.grpNED.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_NewWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_EditWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_DeleteWGR)});
            this.grpNED.Name = "grpNED";
            // 
            // nb_NewWGR
            // 
            this.nb_NewWGR.Caption = "New WGR";
            this.nb_NewWGR.Name = "nb_NewWGR";
            this.nb_NewWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_NewClick);
            // 
            // nb_EditWGR
            // 
            this.nb_EditWGR.Caption = "Edit WGR";
            this.nb_EditWGR.Name = "nb_EditWGR";
            this.nb_EditWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_EditClick);
            // 
            // nb_DeleteWGR
            // 
            this.nb_DeleteWGR.Caption = "Delete WGR";
            this.nb_DeleteWGR.Name = "nb_DeleteWGR";
            this.nb_DeleteWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbDeleteClick);
            // 
            // UCWgrList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCWgrList";
            this.Size = new System.Drawing.Size(626, 444);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UCWgrGrid _ucWgrGrid;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup grpNED;
        private DevExpress.XtraNavBar.NavBarItem nb_NewWGR;
        private DevExpress.XtraNavBar.NavBarItem nb_EditWGR;
        private DevExpress.XtraNavBar.NavBarItem nb_DeleteWGR;
    }
}
