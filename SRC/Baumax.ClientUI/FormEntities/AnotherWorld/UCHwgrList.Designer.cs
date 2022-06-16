namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCHwgrList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCHwgrList));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarHWGR = new DevExpress.XtraNavBar.NavBarControl();
            this.nb_Import = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_ImportHWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_HWGRManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_StopWorkingNow = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_ChangeTimeRange = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_AttachWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.barImages = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this._hwgrGrid = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldManagerGrid();
            this.layoutTop = new DevExpress.XtraLayout.LayoutControl();
            this.edBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.edHwgr = new DevExpress.XtraEditors.LookUpEdit();
            this.edWorld = new DevExpress.XtraEditors.LookUpEdit();
            this.edStore = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lc_Store = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_HWGR = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_FilterDate = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarHWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTop)).BeginInit();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHwgr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_HWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_FilterDate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarHWGR);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(638, 462);
            this.splitContainerControl1.SplitterPosition = 159;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarHWGR
            // 
            this.navBarHWGR.ActiveGroup = this.nb_Import;
            this.navBarHWGR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarHWGR.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_Import,
            this.nb_HWGRManager});
            this.navBarHWGR.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_AttachWGR,
            this.nbi_ChangeTimeRange,
            this.nbi_StopWorkingNow,
            this.nbi_ImportHWGR});
            this.navBarHWGR.LargeImages = this.barImages;
            this.navBarHWGR.Location = new System.Drawing.Point(0, 0);
            this.navBarHWGR.Name = "navBarHWGR";
            this.navBarHWGR.Size = new System.Drawing.Size(155, 458);
            this.navBarHWGR.TabIndex = 0;
            this.navBarHWGR.Text = "navBarControl1";
            // 
            // nb_Import
            // 
            this.nb_Import.Caption = "Import";
            this.nb_Import.Expanded = true;
            this.nb_Import.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_Import.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportHWGR)});
            this.nb_Import.Name = "nb_Import";
            // 
            // nbi_ImportHWGR
            // 
            this.nbi_ImportHWGR.Caption = "Import HWGR";
            this.nbi_ImportHWGR.LargeImageIndex = 3;
            this.nbi_ImportHWGR.Name = "nbi_ImportHWGR";
            this.nbi_ImportHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ImportClick);
            // 
            // nb_HWGRManager
            // 
            this.nb_HWGRManager.Caption = "HWGR manager";
            this.nb_HWGRManager.Expanded = true;
            this.nb_HWGRManager.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_HWGRManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_StopWorkingNow),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ChangeTimeRange),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_AttachWGR)});
            this.nb_HWGRManager.Name = "nb_HWGRManager";
            // 
            // nbi_StopWorkingNow
            // 
            this.nbi_StopWorkingNow.Caption = "Stop working now";
            this.nbi_StopWorkingNow.Enabled = false;
            this.nbi_StopWorkingNow.LargeImageIndex = 1;
            this.nbi_StopWorkingNow.Name = "nbi_StopWorkingNow";
            this.nbi_StopWorkingNow.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.StopWorkingNowClick);
            // 
            // nbi_ChangeTimeRange
            // 
            this.nbi_ChangeTimeRange.Caption = "Change time range";
            this.nbi_ChangeTimeRange.Enabled = false;
            this.nbi_ChangeTimeRange.LargeImageIndex = 0;
            this.nbi_ChangeTimeRange.Name = "nbi_ChangeTimeRange";
            this.nbi_ChangeTimeRange.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ChangeTimeRangeClick);
            // 
            // nbi_AttachWGR
            // 
            this.nbi_AttachWGR.Caption = "Assign WGR";
            this.nbi_AttachWGR.Enabled = false;
            this.nbi_AttachWGR.LargeImageIndex = 2;
            this.nbi_AttachWGR.Name = "nbi_AttachWGR";
            this.nbi_AttachWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.AttachWgrClick);
            // 
            // barImages
            // 
            this.barImages.ImageSize = new System.Drawing.Size(32, 32);
            this.barImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("barImages.ImageStream")));
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel1.Controls.Add(this._hwgrGrid);
            this.splitContainerControl2.Panel1.Controls.Add(this.layoutTop);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(467, 458);
            this.splitContainerControl2.SplitterPosition = 427;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // _hwgrGrid
            // 
            this._hwgrGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hwgrGrid.Enabled = false;
            this._hwgrGrid.Entity = null;
            this._hwgrGrid.Location = new System.Drawing.Point(0, 126);
            this._hwgrGrid.LookAndFeel.SkinName = "iMaginary";
            this._hwgrGrid.Name = "_hwgrGrid";
            this._hwgrGrid.Size = new System.Drawing.Size(467, 299);
            this._hwgrGrid.TabIndex = 1;
            // 
            // layoutTop
            // 
            this.layoutTop.Controls.Add(this.edBeginDate);
            this.layoutTop.Controls.Add(this.edHwgr);
            this.layoutTop.Controls.Add(this.edWorld);
            this.layoutTop.Controls.Add(this.edStore);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Root = this.layoutControlGroup1;
            this.layoutTop.Size = new System.Drawing.Size(467, 126);
            this.layoutTop.TabIndex = 0;
            this.layoutTop.Text = "layoutControl1";
            // 
            // edBeginDate
            // 
            this.edBeginDate.EditValue = null;
            this.edBeginDate.Location = new System.Drawing.Point(61, 100);
            this.edBeginDate.Name = "edBeginDate";
            this.edBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edBeginDate.Size = new System.Drawing.Size(400, 20);
            this.edBeginDate.StyleController = this.layoutTop;
            this.edBeginDate.TabIndex = 11;
            this.edBeginDate.EditValueChanged += new System.EventHandler(this.FilterChanged);
            // 
            // edHwgr
            // 
            this.edHwgr.Location = new System.Drawing.Point(61, 69);
            this.edHwgr.Name = "edHwgr";
            this.edHwgr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edHwgr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edHwgr.Properties.DisplayMember = "Name";
            this.edHwgr.Properties.NullText = "";
            this.edHwgr.Properties.ShowFooter = false;
            this.edHwgr.Properties.ShowHeader = false;
            this.edHwgr.Size = new System.Drawing.Size(400, 20);
            this.edHwgr.StyleController = this.layoutTop;
            this.edHwgr.TabIndex = 10;
            this.edHwgr.EditValueChanged += new System.EventHandler(this.HwgrSelect);
            // 
            // edWorld
            // 
            this.edWorld.Location = new System.Drawing.Point(61, 38);
            this.edWorld.Name = "edWorld";
            this.edWorld.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edWorld.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edWorld.Properties.DisplayMember = "Name";
            this.edWorld.Properties.NullText = "";
            this.edWorld.Properties.ShowFooter = false;
            this.edWorld.Properties.ShowHeader = false;
            this.edWorld.Size = new System.Drawing.Size(400, 20);
            this.edWorld.StyleController = this.layoutTop;
            this.edWorld.TabIndex = 9;
            this.edWorld.EditValueChanged += new System.EventHandler(this.WorldSelect);
            // 
            // edStore
            // 
            this.edStore.Location = new System.Drawing.Point(61, 7);
            this.edStore.Name = "edStore";
            this.edStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edStore.Properties.DisplayMember = "Name";
            this.edStore.Properties.NullText = "";
            this.edStore.Properties.ShowFooter = false;
            this.edStore.Properties.ShowHeader = false;
            this.edStore.Size = new System.Drawing.Size(400, 20);
            this.edStore.StyleController = this.layoutTop;
            this.edStore.TabIndex = 8;
            this.edStore.EditValueChanged += new System.EventHandler(this.Storeselected);
            this.edStore.TextChanged += new System.EventHandler(this.Storeselected);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lc_Store,
            this.lc_World,
            this.lc_HWGR,
            this.lc_FilterDate});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(467, 126);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lc_Store
            // 
            this.lc_Store.Control = this.edStore;
            this.lc_Store.CustomizationFormText = "Store";
            this.lc_Store.Location = new System.Drawing.Point(0, 0);
            this.lc_Store.Name = "lc_Store";
            this.lc_Store.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_Store.Size = new System.Drawing.Size(465, 31);
            this.lc_Store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_Store.Text = "Store";
            this.lc_Store.TextSize = new System.Drawing.Size(49, 20);
            this.lc_Store.TextVisible = true;
            // 
            // lc_World
            // 
            this.lc_World.Control = this.edWorld;
            this.lc_World.CustomizationFormText = "World";
            this.lc_World.Location = new System.Drawing.Point(0, 31);
            this.lc_World.Name = "lc_World";
            this.lc_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_World.Size = new System.Drawing.Size(465, 31);
            this.lc_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_World.Text = "World";
            this.lc_World.TextSize = new System.Drawing.Size(49, 20);
            this.lc_World.TextVisible = true;
            // 
            // lc_HWGR
            // 
            this.lc_HWGR.Control = this.edHwgr;
            this.lc_HWGR.CustomizationFormText = "HWGR";
            this.lc_HWGR.Location = new System.Drawing.Point(0, 62);
            this.lc_HWGR.Name = "lc_HWGR";
            this.lc_HWGR.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_HWGR.Size = new System.Drawing.Size(465, 31);
            this.lc_HWGR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_HWGR.Text = "HWGR";
            this.lc_HWGR.TextSize = new System.Drawing.Size(49, 20);
            this.lc_HWGR.TextVisible = true;
            // 
            // lc_FilterDate
            // 
            this.lc_FilterDate.Control = this.edBeginDate;
            this.lc_FilterDate.CustomizationFormText = "Filter date";
            this.lc_FilterDate.Location = new System.Drawing.Point(0, 93);
            this.lc_FilterDate.Name = "lc_FilterDate";
            this.lc_FilterDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_FilterDate.Size = new System.Drawing.Size(465, 31);
            this.lc_FilterDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_FilterDate.Text = "Filter date";
            this.lc_FilterDate.TextSize = new System.Drawing.Size(49, 20);
            this.lc_FilterDate.TextVisible = true;
            // 
            // UCHwgrList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCHwgrList";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarHWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutTop)).EndInit();
            this.layoutTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHwgr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_HWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_FilterDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarHWGR;
        private DevExpress.XtraNavBar.NavBarGroup nb_HWGRManager;
        private DevExpress.XtraNavBar.NavBarItem nbi_AttachWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_ChangeTimeRange;
        private DevExpress.XtraNavBar.NavBarItem nbi_StopWorkingNow;
        private DevExpress.Utils.ImageCollection barImages;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraLayout.LayoutControl layoutTop;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private UCWorldManagerGrid _hwgrGrid;
        private DevExpress.XtraEditors.LookUpEdit edStore;
        private DevExpress.XtraLayout.LayoutControlItem lc_Store;
        private DevExpress.XtraEditors.LookUpEdit edHwgr;
        private DevExpress.XtraEditors.LookUpEdit edWorld;
        private DevExpress.XtraLayout.LayoutControlItem lc_World;
        private DevExpress.XtraLayout.LayoutControlItem lc_HWGR;
        private DevExpress.XtraEditors.DateEdit edBeginDate;
        private DevExpress.XtraLayout.LayoutControlItem lc_FilterDate;
        private DevExpress.XtraNavBar.NavBarGroup nb_Import;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportHWGR;
    }
}
