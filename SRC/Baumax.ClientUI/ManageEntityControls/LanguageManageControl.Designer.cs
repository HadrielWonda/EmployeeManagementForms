namespace Baumax.ClientUI.ManageEntityControls
{
    partial class LanguageManageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageManageControl));
            this.barLanguageManager = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup_LanguageGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_ListLanguage = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_NewLanguage = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_EditLanguage = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_DeleteLanguage = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_SaveTranslation = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_TranslateUI = new DevExpress.XtraNavBar.NavBarItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelDummy = new DevExpress.XtraEditors.PanelControl();
            this.cntrlLanguageList = new Baumax.ClientUI.FormEntities.Language.UCLanguageList2();
            ((System.ComponentModel.ISupportInitialize)(this.barLanguageManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDummy)).BeginInit();
            this.panelDummy.SuspendLayout();
            this.SuspendLayout();
            // 
            // barLanguageManager
            // 
            this.barLanguageManager.ActiveGroup = this.navBarGroup_LanguageGroup;
            this.barLanguageManager.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLanguageManager.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.barLanguageManager.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup_LanguageGroup});
            this.barLanguageManager.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_ListLanguage,
            this.navBarItem_NewLanguage,
            this.navBarItem_EditLanguage,
            this.navBarItem_DeleteLanguage,
            this.navBarItem_TranslateUI,
            this.navBarItem_SaveTranslation});
            this.barLanguageManager.LargeImages = this.imageList1;
            this.barLanguageManager.Location = new System.Drawing.Point(0, 0);
            this.barLanguageManager.Name = "barLanguageManager";
            this.barLanguageManager.OptionsNavPane.ExpandedWidth = 140;
            this.barLanguageManager.Size = new System.Drawing.Size(140, 527);
            this.barLanguageManager.TabIndex = 0;
            this.barLanguageManager.Text = "navBarControl1";
            this.barLanguageManager.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // navBarGroup_LanguageGroup
            // 
            this.navBarGroup_LanguageGroup.Caption = "Language";
            this.navBarGroup_LanguageGroup.Expanded = true;
            this.navBarGroup_LanguageGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navBarGroup_LanguageGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_ListLanguage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_NewLanguage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_EditLanguage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_DeleteLanguage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_SaveTranslation),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_TranslateUI)});
            this.navBarGroup_LanguageGroup.Name = "navBarGroup_LanguageGroup";
            // 
            // navBarItem_ListLanguage
            // 
            this.navBarItem_ListLanguage.Caption = "List of language";
            this.navBarItem_ListLanguage.LargeImageIndex = 0;
            this.navBarItem_ListLanguage.Name = "navBarItem_ListLanguage";
            this.navBarItem_ListLanguage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_ListLanguage_LinkClicked);
            // 
            // navBarItem_NewLanguage
            // 
            this.navBarItem_NewLanguage.Caption = "New Language";
            this.navBarItem_NewLanguage.LargeImageIndex = 1;
            this.navBarItem_NewLanguage.Name = "navBarItem_NewLanguage";
            this.navBarItem_NewLanguage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_NewLanguage_LinkClicked);
            // 
            // navBarItem_EditLanguage
            // 
            this.navBarItem_EditLanguage.Caption = "Edit Language";
            this.navBarItem_EditLanguage.LargeImageIndex = 2;
            this.navBarItem_EditLanguage.Name = "navBarItem_EditLanguage";
            this.navBarItem_EditLanguage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_EditLanguage_LinkClicked);
            // 
            // navBarItem_DeleteLanguage
            // 
            this.navBarItem_DeleteLanguage.Caption = "Delete Language";
            this.navBarItem_DeleteLanguage.LargeImageIndex = 3;
            this.navBarItem_DeleteLanguage.Name = "navBarItem_DeleteLanguage";
            this.navBarItem_DeleteLanguage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_DeleteLanguage_LinkClicked);
            // 
            // navBarItem_SaveTranslation
            // 
            this.navBarItem_SaveTranslation.Caption = "Save Translation";
            this.navBarItem_SaveTranslation.LargeImageIndex = 5;
            this.navBarItem_SaveTranslation.Name = "navBarItem_SaveTranslation";
            this.navBarItem_SaveTranslation.Visible = false;
            this.navBarItem_SaveTranslation.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_SaveTranslation_LinkClicked);
            // 
            // navBarItem_TranslateUI
            // 
            this.navBarItem_TranslateUI.Caption = "Translate UI";
            this.navBarItem_TranslateUI.LargeImageIndex = 4;
            this.navBarItem_TranslateUI.Name = "navBarItem_TranslateUI";
            this.navBarItem_TranslateUI.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_TranslateUI_LinkClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "language_list.png");
            this.imageList1.Images.SetKeyName(1, "language_new.png");
            this.imageList1.Images.SetKeyName(2, "language_edit.png");
            this.imageList1.Images.SetKeyName(3, "language_delete.png");
            this.imageList1.Images.SetKeyName(4, "language_translate.png");
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(140, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(8, 527);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelDummy
            // 
            this.panelDummy.Controls.Add(this.cntrlLanguageList);
            this.panelDummy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDummy.Location = new System.Drawing.Point(148, 0);
            this.panelDummy.Name = "panelDummy";
            this.panelDummy.Size = new System.Drawing.Size(529, 527);
            this.panelDummy.TabIndex = 2;
            // 
            // cntrlLanguageList
            // 
            this.cntrlLanguageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlLanguageList.Entity = null;
            this.cntrlLanguageList.Location = new System.Drawing.Point(2, 2);
            this.cntrlLanguageList.LookAndFeel.SkinName = "iMaginary";
            this.cntrlLanguageList.Name = "cntrlLanguageList";
            this.cntrlLanguageList.Size = new System.Drawing.Size(525, 523);
            this.cntrlLanguageList.TabIndex = 0;
            this.cntrlLanguageList.OnFocusedLanguageChanged += new Baumax.ClientUI.FormEntities.Language.UCLanguageList2.FocusedLangaugeChanged(this.cntrlLanguageList_OnFocusedLanguageChanged);
            this.cntrlLanguageList.OnActionNeeded += new Baumax.ClientUI.FormEntities.Language.UCLanguageList2.ControlNeededAction(this.cntrlLanguageList_OnActionNeeded);
            // 
            // LanguageManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDummy);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.barLanguageManager);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "LanguageManageControl";
            this.Size = new System.Drawing.Size(677, 527);
            this.Load += new System.EventHandler(this.LanguageManageControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barLanguageManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDummy)).EndInit();
            this.panelDummy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl barLanguageManager;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_LanguageGroup;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelDummy;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_ListLanguage;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_NewLanguage;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_EditLanguage;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_DeleteLanguage;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_TranslateUI;
        private Baumax.ClientUI.FormEntities.Language.UCLanguageList2 cntrlLanguageList;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_SaveTranslation;
        private System.Windows.Forms.ImageList imageList1;
    }
}
