namespace Baumax.ClientUI.ManageEntityControls
{
    partial class CountryManageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryManageControl));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControlCountries = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup_CountryGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_ImportCountry = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_EditCountry = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_CountryDetails = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_RunCashDeskEstimate = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_RunWorkingTimeEstimate = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.ucCountryList21 = new Baumax.ClientUI.FormEntities.Country.UCCountryList2();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.navBarControlCountries);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(130, 462);
            this.panelControl1.TabIndex = 0;
            // 
            // navBarControlCountries
            // 
            this.navBarControlCountries.ActiveGroup = this.navBarGroup_CountryGroup;
            this.navBarControlCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControlCountries.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControlCountries.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup_CountryGroup,
            this.navBarGroup1});
            this.navBarControlCountries.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_ImportCountry,
            this.navBarItem_EditCountry,
            this.navBarItem_CountryDetails,
            this.bi_RunCashDeskEstimate,
            this.bi_RunWorkingTimeEstimate});
            this.navBarControlCountries.LargeImages = this.imageCollection1;
            this.navBarControlCountries.Location = new System.Drawing.Point(2, 2);
            this.navBarControlCountries.Name = "navBarControlCountries";
            this.navBarControlCountries.OptionsNavPane.ExpandedWidth = 126;
            this.navBarControlCountries.Size = new System.Drawing.Size(126, 458);
            this.navBarControlCountries.TabIndex = 0;
            this.navBarControlCountries.Text = "navBarControl1";
            this.navBarControlCountries.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // navBarGroup_CountryGroup
            // 
            this.navBarGroup_CountryGroup.Caption = "Country";
            this.navBarGroup_CountryGroup.Expanded = true;
            this.navBarGroup_CountryGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_CountryGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_ImportCountry),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_EditCountry),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CountryDetails)});
            this.navBarGroup_CountryGroup.Name = "navBarGroup_CountryGroup";
            // 
            // navBarItem_ImportCountry
            // 
            this.navBarItem_ImportCountry.Caption = "New country";
            this.navBarItem_ImportCountry.LargeImageIndex = 0;
            this.navBarItem_ImportCountry.Name = "navBarItem_ImportCountry";
            this.navBarItem_ImportCountry.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_NewCountry_LinkClicked);
            // 
            // navBarItem_EditCountry
            // 
            this.navBarItem_EditCountry.Caption = "Edit country";
            this.navBarItem_EditCountry.LargeImageIndex = 2;
            this.navBarItem_EditCountry.Name = "navBarItem_EditCountry";
            this.navBarItem_EditCountry.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_EditCountry_LinkClicked);
            // 
            // navBarItem_CountryDetails
            // 
            this.navBarItem_CountryDetails.Caption = "Country details";
            this.navBarItem_CountryDetails.LargeImageIndex = 1;
            this.navBarItem_CountryDetails.Name = "navBarItem_CountryDetails";
            this.navBarItem_CountryDetails.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_DeleteCountry_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_RunCashDeskEstimate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_RunWorkingTimeEstimate)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // bi_RunCashDeskEstimate
            // 
            this.bi_RunCashDeskEstimate.Caption = "Run CashDesk estimate";
            this.bi_RunCashDeskEstimate.LargeImageIndex = 4;
            this.bi_RunCashDeskEstimate.Name = "bi_RunCashDeskEstimate";
            this.bi_RunCashDeskEstimate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_RunCashDeskEstimate_LinkClicked);
            // 
            // bi_RunWorkingTimeEstimate
            // 
            this.bi_RunWorkingTimeEstimate.Caption = "Run working time estimate";
            this.bi_RunWorkingTimeEstimate.LargeImageIndex = 3;
            this.bi_RunWorkingTimeEstimate.Name = "bi_RunWorkingTimeEstimate";
            this.bi_RunWorkingTimeEstimate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_RunStoreWorkingTimeEstimate_LinkClicked);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(130, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(508, 462);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.ucCountryList21);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(504, 458);
            this.panelControl3.TabIndex = 0;
            // 
            // ucCountryList21
            // 
            this.ucCountryList21.CountryList = null;
            this.ucCountryList21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCountryList21.Entity = null;
            this.ucCountryList21.Location = new System.Drawing.Point(2, 2);
            this.ucCountryList21.LookAndFeel.SkinName = "iMaginary";
            this.ucCountryList21.Name = "ucCountryList21";
            this.ucCountryList21.Size = new System.Drawing.Size(500, 454);
            this.ucCountryList21.TabIndex = 0;
            this.ucCountryList21.OnChangeFocusedEntity += new Baumax.ClientUI.FormEntities.Country.UCCountryList2.ChangeFocusedEntity(this.ucCountryList21_OnChangeFocusedEntity);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(130, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 462);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // CountryManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "CountryManageControl";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControlCountries;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_CountryGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_ImportCountry;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_EditCountry;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CountryDetails;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private Baumax.ClientUI.FormEntities.Country.UCCountryList2 ucCountryList21;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem bi_RunCashDeskEstimate;
        private DevExpress.XtraNavBar.NavBarItem bi_RunWorkingTimeEstimate;
    }
}
