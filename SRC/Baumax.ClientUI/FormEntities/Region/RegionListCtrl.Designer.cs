namespace Baumax.ClientUI.FormEntities
{
    partial class RegionListCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionListCtrl));
            this.ctrlNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.grp_RegionGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_ImportRegion = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_EditRegion = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_RegionDetails = new DevExpress.XtraNavBar.NavBarItem();
            this.images = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlNavBar
            // 
            this.ctrlNavBar.ActiveGroup = this.grp_RegionGroup;
            this.ctrlNavBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNavBar.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.ctrlNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grp_RegionGroup});
            this.ctrlNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.bi_ImportRegion,
            this.bi_RegionDetails,
            this.bi_EditRegion});
            this.ctrlNavBar.LargeImages = this.images;
            this.ctrlNavBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlNavBar.Name = "ctrlNavBar";
            this.ctrlNavBar.OptionsNavPane.ExpandedWidth = 154;
            this.ctrlNavBar.Size = new System.Drawing.Size(170, 458);
            this.ctrlNavBar.TabIndex = 0;
            this.ctrlNavBar.Text = "navBarControl1";
            this.ctrlNavBar.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // grp_RegionGroup
            // 
            this.grp_RegionGroup.Caption = "";
            this.grp_RegionGroup.Expanded = true;
            this.grp_RegionGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.grp_RegionGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_ImportRegion),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_EditRegion),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_RegionDetails)});
            this.grp_RegionGroup.Name = "grp_RegionGroup";
            // 
            // bi_ImportRegion
            // 
            this.bi_ImportRegion.Caption = "Import region";
            this.bi_ImportRegion.LargeImageIndex = 2;
            this.bi_ImportRegion.Name = "bi_ImportRegion";
            this.bi_ImportRegion.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbNew_LinkClicked);
            // 
            // bi_EditRegion
            // 
            this.bi_EditRegion.Caption = "Edit region";
            this.bi_EditRegion.LargeImageIndex = 1;
            this.bi_EditRegion.Name = "bi_EditRegion";
            this.bi_EditRegion.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // bi_RegionDetails
            // 
            this.bi_RegionDetails.Caption = "Region details";
            this.bi_RegionDetails.LargeImageIndex = 0;
            this.bi_RegionDetails.Name = "bi_RegionDetails";
            this.bi_RegionDetails.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEdit_LinkClicked);
            // 
            // images
            // 
            this.images.ImageSize = new System.Drawing.Size(32, 32);
            this.images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("images.ImageStream")));
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.ctrlNavBar);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(638, 462);
            this.splitContainer.SplitterPosition = 174;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.Text = "splitContainerControl1";
            // 
            // RegionListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "RegionListCtrl";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraNavBar.NavBarControl ctrlNavBar;
        private DevExpress.XtraNavBar.NavBarGroup grp_RegionGroup;
        private DevExpress.XtraNavBar.NavBarItem bi_ImportRegion;
        private DevExpress.XtraNavBar.NavBarItem bi_RegionDetails;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraNavBar.NavBarItem bi_EditRegion;
        private DevExpress.Utils.ImageCollection images;
    }
}
