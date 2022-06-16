namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCRegisterList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRegisterList));
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
			this.nb_Imports = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_ImportWgr = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_ImportHwgr = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_ImportWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_ImportStore = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_Registers = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_Worlds = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_HWGRs = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_WGRs = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_Store = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_NewStore = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_EditStore = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_DeleteStore = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_World = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_NewWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_EditWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_DeleteWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_HWGR = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_NewHWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_EditHWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_DeleteHWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.nb_WGR = new DevExpress.XtraNavBar.NavBarGroup();
			this.nbi_NewWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_EditWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.nbi_DeleteWGR = new DevExpress.XtraNavBar.NavBarItem();
			this.imagesNavBar = new DevExpress.Utils.ImageCollection(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imagesNavBar)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(626, 538);
			this.splitContainerControl1.SplitterPosition = 172;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// navBarControl1
			// 
			this.navBarControl1.ActiveGroup = this.nb_Imports;
			this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navBarControl1.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_Registers,
            this.nb_Store,
            this.nb_World,
            this.nb_HWGR,
            this.nb_WGR,
            this.nb_Imports});
			this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_Worlds,
            this.nbi_HWGRs,
            this.nbi_WGRs,
            this.nbi_NewStore,
            this.nbi_EditStore,
            this.nbi_DeleteStore,
            this.nbi_NewWorld,
            this.nbi_EditWorld,
            this.nbi_DeleteWorld,
            this.nbi_NewHWGR,
            this.nbi_EditHWGR,
            this.nbi_DeleteHWGR,
            this.nbi_NewWGR,
            this.nbi_EditWGR,
            this.nbi_DeleteWGR,
            this.nbi_ImportStore,
            this.nbi_ImportWorld,
            this.nb_ImportHwgr,
            this.nbi_ImportWgr});
			this.navBarControl1.LargeImages = this.imagesNavBar;
			this.navBarControl1.Location = new System.Drawing.Point(0, 0);
			this.navBarControl1.Name = "navBarControl1";
			this.navBarControl1.OptionsNavPane.ExpandedWidth = 168;
			this.navBarControl1.Size = new System.Drawing.Size(168, 534);
			this.navBarControl1.TabIndex = 0;
			this.navBarControl1.Text = "navBarControl1";
			// 
			// nb_Imports
			// 
			this.nb_Imports.Caption = "Imports";
			this.nb_Imports.Expanded = true;
			this.nb_Imports.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
			this.nb_Imports.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportWgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_ImportHwgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportStore)});
			this.nb_Imports.Name = "nb_Imports";
			// 
			// nbi_ImportWgr
			// 
			this.nbi_ImportWgr.Caption = "Import WGR";
			this.nbi_ImportWgr.LargeImageIndex = 1;
			this.nbi_ImportWgr.Name = "nbi_ImportWgr";
			// 
			// nb_ImportHwgr
			// 
			this.nb_ImportHwgr.Caption = "Import HWGR";
			this.nb_ImportHwgr.LargeImageIndex = 0;
			this.nb_ImportHwgr.Name = "nb_ImportHwgr";
			// 
			// nbi_ImportWorld
			// 
			this.nbi_ImportWorld.Caption = "Import world";
			this.nbi_ImportWorld.LargeImageIndex = 2;
			this.nbi_ImportWorld.Name = "nbi_ImportWorld";
			// 
			// nbi_ImportStore
			// 
			this.nbi_ImportStore.Caption = "Import store";
			this.nbi_ImportStore.LargeImageIndex = 9;
			this.nbi_ImportStore.Name = "nbi_ImportStore";
			// 
			// nb_Registers
			// 
			this.nb_Registers.Caption = "Registers";
			this.nb_Registers.Expanded = true;
			this.nb_Registers.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
			this.nb_Registers.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_Worlds),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_HWGRs),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_WGRs)});
			this.nb_Registers.Name = "nb_Registers";
			// 
			// nbi_Worlds
			// 
			this.nbi_Worlds.Caption = "Worlds";
			this.nbi_Worlds.LargeImageIndex = 18;
			this.nbi_Worlds.Name = "nbi_Worlds";
			this.nbi_Worlds.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EnableWorld);
			// 
			// nbi_HWGRs
			// 
			this.nbi_HWGRs.Caption = "HWGRs";
			this.nbi_HWGRs.LargeImageIndex = 6;
			this.nbi_HWGRs.Name = "nbi_HWGRs";
			this.nbi_HWGRs.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EnableHWGR);
			// 
			// nbi_WGRs
			// 
			this.nbi_WGRs.Caption = "WGRs";
			this.nbi_WGRs.LargeImageIndex = 14;
			this.nbi_WGRs.Name = "nbi_WGRs";
			this.nbi_WGRs.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EnableWGR);
			// 
			// nb_Store
			// 
			this.nb_Store.Caption = "Store";
			this.nb_Store.Expanded = true;
			this.nb_Store.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
			this.nb_Store.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_NewStore),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_EditStore),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_DeleteStore)});
			this.nb_Store.Name = "nb_Store";
			this.nb_Store.Visible = false;
			// 
			// nbi_NewStore
			// 
			this.nbi_NewStore.Caption = "NewStore";
			this.nbi_NewStore.LargeImageIndex = 19;
			this.nbi_NewStore.Name = "nbi_NewStore";
			this.nbi_NewStore.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NewStore);
			// 
			// nbi_EditStore
			// 
			this.nbi_EditStore.Caption = "Edit World";
			this.nbi_EditStore.LargeImageIndex = 8;
			this.nbi_EditStore.Name = "nbi_EditStore";
			this.nbi_EditStore.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EditStore);
			// 
			// nbi_DeleteStore
			// 
			this.nbi_DeleteStore.Caption = "DeleteStore";
			this.nbi_DeleteStore.LargeImageIndex = 7;
			this.nbi_DeleteStore.Name = "nbi_DeleteStore";
			this.nbi_DeleteStore.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DeleteStore);
			// 
			// nb_World
			// 
			this.nb_World.Caption = "World";
			this.nb_World.Expanded = true;
			this.nb_World.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
			this.nb_World.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_NewWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_EditWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_DeleteWorld)});
			this.nb_World.Name = "nb_World";
			this.nb_World.Visible = false;
			// 
			// nbi_NewWorld
			// 
			this.nbi_NewWorld.Caption = "New World";
			this.nbi_NewWorld.LargeImageIndex = 17;
			this.nbi_NewWorld.Name = "nbi_NewWorld";
			this.nbi_NewWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NewWorld);
			// 
			// nbi_EditWorld
			// 
			this.nbi_EditWorld.Caption = "Edit World";
			this.nbi_EditWorld.LargeImageIndex = 16;
			this.nbi_EditWorld.Name = "nbi_EditWorld";
			this.nbi_EditWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EditWorld);
			// 
			// nbi_DeleteWorld
			// 
			this.nbi_DeleteWorld.Caption = "Delete World";
			this.nbi_DeleteWorld.LargeImageIndex = 15;
			this.nbi_DeleteWorld.Name = "nbi_DeleteWorld";
			this.nbi_DeleteWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DeleteWorld);
			// 
			// nb_HWGR
			// 
			this.nb_HWGR.Caption = "HWGR";
			this.nb_HWGR.Expanded = true;
			this.nb_HWGR.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
			this.nb_HWGR.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_NewHWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_EditHWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_DeleteHWGR)});
			this.nb_HWGR.Name = "nb_HWGR";
			this.nb_HWGR.Visible = false;
			// 
			// nbi_NewHWGR
			// 
			this.nbi_NewHWGR.Caption = "New HWGR";
			this.nbi_NewHWGR.LargeImageIndex = 5;
			this.nbi_NewHWGR.Name = "nbi_NewHWGR";
			this.nbi_NewHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NewHWGR);
			// 
			// nbi_EditHWGR
			// 
			this.nbi_EditHWGR.Caption = "EditHWGR";
			this.nbi_EditHWGR.LargeImageIndex = 4;
			this.nbi_EditHWGR.Name = "nbi_EditHWGR";
			this.nbi_EditHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EditHWGR);
			// 
			// nbi_DeleteHWGR
			// 
			this.nbi_DeleteHWGR.Caption = "Delete HWGR";
			this.nbi_DeleteHWGR.LargeImageIndex = 3;
			this.nbi_DeleteHWGR.Name = "nbi_DeleteHWGR";
			this.nbi_DeleteHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DeleteHWGR);
			// 
			// nb_WGR
			// 
			this.nb_WGR.Caption = "WGR";
			this.nb_WGR.Expanded = true;
			this.nb_WGR.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
			this.nb_WGR.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_NewWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_EditWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_DeleteWGR)});
			this.nb_WGR.Name = "nb_WGR";
			this.nb_WGR.Visible = false;
			// 
			// nbi_NewWGR
			// 
			this.nbi_NewWGR.Caption = "New WGR";
			this.nbi_NewWGR.LargeImageIndex = 13;
			this.nbi_NewWGR.Name = "nbi_NewWGR";
			this.nbi_NewWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NewWGR);
			// 
			// nbi_EditWGR
			// 
			this.nbi_EditWGR.Caption = "Edit WGR";
			this.nbi_EditWGR.LargeImageIndex = 11;
			this.nbi_EditWGR.Name = "nbi_EditWGR";
			this.nbi_EditWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.EditWgr);
			// 
			// nbi_DeleteWGR
			// 
			this.nbi_DeleteWGR.Caption = "Delete WGR";
			this.nbi_DeleteWGR.LargeImageIndex = 11;
			this.nbi_DeleteWGR.Name = "nbi_DeleteWGR";
			this.nbi_DeleteWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DeleteWGR);
			// 
			// imagesNavBar
			// 
			this.imagesNavBar.ImageSize = new System.Drawing.Size(32, 32);
			this.imagesNavBar.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imagesNavBar.ImageStream")));
			// 
			// UCRegisterList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerControl1);
			this.LookAndFeel.SkinName = "iMaginary";
			this.Name = "UCRegisterList";
			this.Size = new System.Drawing.Size(626, 538);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imagesNavBar)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nb_Registers;
        private DevExpress.XtraNavBar.NavBarGroup nb_Store;
        private DevExpress.XtraNavBar.NavBarGroup nb_World;
        private DevExpress.XtraNavBar.NavBarGroup nb_HWGR;
        private DevExpress.XtraNavBar.NavBarGroup nb_WGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_Worlds;
        private DevExpress.XtraNavBar.NavBarItem nbi_HWGRs;
        private DevExpress.XtraNavBar.NavBarItem nbi_WGRs;
        private DevExpress.XtraNavBar.NavBarItem nbi_NewStore;
        private DevExpress.XtraNavBar.NavBarItem nbi_EditStore;
        private DevExpress.XtraNavBar.NavBarItem nbi_DeleteStore;
        private DevExpress.XtraNavBar.NavBarItem nbi_NewWorld;
        private DevExpress.XtraNavBar.NavBarItem nbi_EditWorld;
        private DevExpress.XtraNavBar.NavBarItem nbi_DeleteWorld;
        private DevExpress.XtraNavBar.NavBarItem nbi_DeleteWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_EditWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_NewWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_DeleteHWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_EditHWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_NewHWGR;
        private DevExpress.Utils.ImageCollection imagesNavBar;
        private DevExpress.XtraNavBar.NavBarGroup nb_Imports;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportStore;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportWorld;
        private DevExpress.XtraNavBar.NavBarItem nb_ImportHwgr;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportWgr;
    }
}
