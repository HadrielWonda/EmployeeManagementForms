namespace Baumax.ClientUI.ManageEntityControls
{
    partial class StoreManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreManagerControl));
            this.navBarStore = new DevExpress.XtraNavBar.NavBarControl();
            this.nb_Store = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_ImportStore = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_OpenCloseHours = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_ListOfStores = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_StoreDetail = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_Estimate = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_RunWorkingTimeEstimate = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_RunCashDeskEstimate = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_ViewEstimateData = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_CopyBValue = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_EditStore = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_DeleteStore = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_RunStoreWorkingTimeEstimate = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_GetValueWorkingTime = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_GetValueCashDesk = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_Getactual = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pcClient = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcClient)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarStore
            // 
            this.navBarStore.ActiveGroup = this.nb_Store;
            this.navBarStore.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarStore.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarStore.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_Store,
            this.nb_Estimate});
            this.navBarStore.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nb_ImportStore,
            this.nb_EditStore,
            this.nb_DeleteStore,
            this.nb_OpenCloseHours,
            this.nb_ListOfStores,
            this.nb_StoreDetail,
            this.bi_RunStoreWorkingTimeEstimate,
            this.bi_RunWorkingTimeEstimate,
            this.bi_RunCashDeskEstimate,
            this.bi_ViewEstimateData,
            this.bi_GetValueWorkingTime,
            this.bi_GetValueCashDesk,
            this.bi_Getactual,
            this.bi_CopyBValue});
            this.navBarStore.LargeImages = this.imageCollection1;
            this.navBarStore.Location = new System.Drawing.Point(0, 0);
            this.navBarStore.LookAndFeel.SkinName = "iMaginary";
            this.navBarStore.Name = "navBarStore";
            this.navBarStore.OptionsNavPane.ExpandedWidth = 140;
            this.navBarStore.Size = new System.Drawing.Size(140, 613);
            this.navBarStore.TabIndex = 0;
            this.navBarStore.Text = "navBarControl1";
            this.navBarStore.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // nb_Store
            // 
            this.nb_Store.Caption = "Store";
            this.nb_Store.Expanded = true;
            this.nb_Store.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_Store.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_ImportStore),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_OpenCloseHours),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_ListOfStores),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_StoreDetail)});
            this.nb_Store.Name = "nb_Store";
            // 
            // nb_ImportStore
            // 
            this.nb_ImportStore.Caption = "Import store";
            this.nb_ImportStore.LargeImageIndex = 5;
            this.nb_ImportStore.Name = "nb_ImportStore";
            this.nb_ImportStore.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_NewStore_LinkClicked);
            // 
            // nb_OpenCloseHours
            // 
            this.nb_OpenCloseHours.Caption = "Open Close Hours";
            this.nb_OpenCloseHours.LargeImageIndex = 3;
            this.nb_OpenCloseHours.Name = "nb_OpenCloseHours";
            this.nb_OpenCloseHours.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // nb_ListOfStores
            // 
            this.nb_ListOfStores.Caption = "List stores";
            this.nb_ListOfStores.LargeImageIndex = 6;
            this.nb_ListOfStores.Name = "nb_ListOfStores";
            this.nb_ListOfStores.Visible = false;
            this.nb_ListOfStores.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            // 
            // nb_StoreDetail
            // 
            this.nb_StoreDetail.Caption = "Store Details";
            this.nb_StoreDetail.LargeImageIndex = 4;
            this.nb_StoreDetail.Name = "nb_StoreDetail";
            this.nb_StoreDetail.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem3_LinkClicked);
            // 
            // nb_Estimate
            // 
            this.nb_Estimate.Caption = "Estimate";
            this.nb_Estimate.Expanded = true;
            this.nb_Estimate.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_Estimate.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_RunWorkingTimeEstimate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_RunCashDeskEstimate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_ViewEstimateData),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_CopyBValue)});
            this.nb_Estimate.Name = "nb_Estimate";
            // 
            // bi_RunWorkingTimeEstimate
            // 
            this.bi_RunWorkingTimeEstimate.Caption = "Run working time estimate";
            this.bi_RunWorkingTimeEstimate.LargeImage = ((System.Drawing.Image)(resources.GetObject("bi_RunWorkingTimeEstimate.LargeImage")));
            this.bi_RunWorkingTimeEstimate.Name = "bi_RunWorkingTimeEstimate";
            this.bi_RunWorkingTimeEstimate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_RunWorkingTimeEstimate_LinkClicked);
            // 
            // bi_RunCashDeskEstimate
            // 
            this.bi_RunCashDeskEstimate.Caption = "Run CashDesk estimate";
            this.bi_RunCashDeskEstimate.LargeImage = ((System.Drawing.Image)(resources.GetObject("bi_RunCashDeskEstimate.LargeImage")));
            this.bi_RunCashDeskEstimate.Name = "bi_RunCashDeskEstimate";
            this.bi_RunCashDeskEstimate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_RunCashDeskEstimate_LinkClicked);
            // 
            // bi_ViewEstimateData
            // 
            this.bi_ViewEstimateData.Caption = "View estimate data";
            this.bi_ViewEstimateData.LargeImageIndex = 7;
            this.bi_ViewEstimateData.Name = "bi_ViewEstimateData";
            this.bi_ViewEstimateData.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked_1);
            // 
            // bi_CopyBValue
            // 
            this.bi_CopyBValue.Caption = "Copy business data";
            this.bi_CopyBValue.LargeImageIndex = 8;
            this.bi_CopyBValue.Name = "bi_CopyBValue";
            this.bi_CopyBValue.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_GetValue_LinkClicked);
            // 
            // nb_EditStore
            // 
            this.nb_EditStore.Caption = "Edit store";
            this.nb_EditStore.LargeImageIndex = 1;
            this.nb_EditStore.Name = "nb_EditStore";
            // 
            // nb_DeleteStore
            // 
            this.nb_DeleteStore.Caption = "Delete store";
            this.nb_DeleteStore.LargeImageIndex = 2;
            this.nb_DeleteStore.Name = "nb_DeleteStore";
            // 
            // bi_RunStoreWorkingTimeEstimate
            // 
            this.bi_RunStoreWorkingTimeEstimate.Caption = "Run store estimate";
            this.bi_RunStoreWorkingTimeEstimate.Name = "bi_RunStoreWorkingTimeEstimate";
            // 
            // bi_GetValueWorkingTime
            // 
            this.bi_GetValueWorkingTime.Name = "bi_GetValueWorkingTime";
            // 
            // bi_GetValueCashDesk
            // 
            this.bi_GetValueCashDesk.Name = "bi_GetValueCashDesk";
            // 
            // bi_Getactual
            // 
            this.bi_Getactual.Name = "bi_Getactual";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(140, 0);
            this.splitterControl1.LookAndFeel.SkinName = "iMaginary";
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 613);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // pcClient
            // 
            this.pcClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcClient.Location = new System.Drawing.Point(146, 0);
            this.pcClient.Name = "pcClient";
            this.pcClient.Size = new System.Drawing.Size(594, 613);
            this.pcClient.TabIndex = 2;
            // 
            // StoreManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcClient);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarStore);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "StoreManagerControl";
            this.Size = new System.Drawing.Size(740, 613);
            ((System.ComponentModel.ISupportInitialize)(this.navBarStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarStore;
        private DevExpress.XtraNavBar.NavBarGroup nb_Store;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl pcClient;
        private DevExpress.XtraNavBar.NavBarItem nb_ImportStore;
        private DevExpress.XtraNavBar.NavBarItem nb_EditStore;
        private DevExpress.XtraNavBar.NavBarItem nb_DeleteStore;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraNavBar.NavBarItem nb_OpenCloseHours;
        private DevExpress.XtraNavBar.NavBarItem nb_ListOfStores;
        private DevExpress.XtraNavBar.NavBarItem nb_StoreDetail;
        private DevExpress.XtraNavBar.NavBarItem bi_RunStoreWorkingTimeEstimate;
        private DevExpress.XtraNavBar.NavBarGroup nb_Estimate;
        private DevExpress.XtraNavBar.NavBarItem bi_RunWorkingTimeEstimate;
        private DevExpress.XtraNavBar.NavBarItem bi_RunCashDeskEstimate;
        private DevExpress.XtraNavBar.NavBarItem bi_ViewEstimateData;
        private DevExpress.XtraNavBar.NavBarItem bi_GetValueWorkingTime;
        private DevExpress.XtraNavBar.NavBarItem bi_GetValueCashDesk;
        private DevExpress.XtraNavBar.NavBarItem bi_Getactual;
        private DevExpress.XtraNavBar.NavBarItem bi_CopyBValue;
    }
}
