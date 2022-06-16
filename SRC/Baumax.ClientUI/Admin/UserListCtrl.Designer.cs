namespace Baumax.ClientUI.Admin
{
    partial class UserListCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListCtrl));
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.ctrlNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.grpNED_user = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbNew_newuser = new DevExpress.XtraNavBar.NavBarItem();
            this.nbEdit_edituser = new DevExpress.XtraNavBar.NavBarItem();
            this.nbDelete_deleteuser = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.ctrlNavBar);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(622, 373);
            this.splitContainer.SplitterPosition = 148;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.Text = "splitContainerControl1";
            // 
            // ctrlNavBar
            // 
            this.ctrlNavBar.ActiveGroup = this.grpNED_user;
            this.ctrlNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpNED_user});
            this.ctrlNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbNew_newuser,
            this.nbEdit_edituser,
            this.nbDelete_deleteuser});
            this.ctrlNavBar.LargeImages = this.imageCollection1;
            this.ctrlNavBar.Location = new System.Drawing.Point(1, 1);
            this.ctrlNavBar.Name = "ctrlNavBar";
            this.ctrlNavBar.OptionsNavPane.ExpandedWidth = 140;
            this.ctrlNavBar.Size = new System.Drawing.Size(140, 300);
            this.ctrlNavBar.TabIndex = 0;
            this.ctrlNavBar.Text = "navBarControl1";
            this.ctrlNavBar.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // grpNED_user
            // 
            this.grpNED_user.Caption = "User";
            this.grpNED_user.Expanded = true;
            this.grpNED_user.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.grpNED_user.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbNew_newuser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbEdit_edituser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbDelete_deleteuser)});
            this.grpNED_user.Name = "grpNED_user";
            // 
            // nbNew_newuser
            // 
            this.nbNew_newuser.Caption = "New";
            this.nbNew_newuser.LargeImageIndex = 2;
            this.nbNew_newuser.Name = "nbNew_newuser";
            this.nbNew_newuser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbNew_LinkClicked);
            // 
            // nbEdit_edituser
            // 
            this.nbEdit_edituser.Caption = "Edit";
            this.nbEdit_edituser.LargeImageIndex = 1;
            this.nbEdit_edituser.Name = "nbEdit_edituser";
            this.nbEdit_edituser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEdit_LinkClicked);
            // 
            // nbDelete_deleteuser
            // 
            this.nbDelete_deleteuser.Caption = "Delete";
            this.nbDelete_deleteuser.LargeImageIndex = 0;
            this.nbDelete_deleteuser.Name = "nbDelete_deleteuser";
            this.nbDelete_deleteuser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbDelete_LinkClicked);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // UserListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UserListCtrl";
            this.Size = new System.Drawing.Size(622, 373);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraNavBar.NavBarGroup grpNED_user;
        private DevExpress.XtraNavBar.NavBarItem nbNew_newuser;
        private DevExpress.XtraNavBar.NavBarItem nbEdit_edituser;
        private DevExpress.XtraNavBar.NavBarItem nbDelete_deleteuser;
        protected DevExpress.XtraNavBar.NavBarControl ctrlNavBar;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}
