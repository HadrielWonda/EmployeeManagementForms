namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCWorldList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorldList));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nb_Import = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_ImportWorlds = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_WorldManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_AttachHWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_StopWorkingNow = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_ChangeTimeRange = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_AttachWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.imagesNavBar = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this._worldGrid = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldManagerGrid();
            this.layoutTop = new DevExpress.XtraLayout.LayoutControl();
            this.edStore = new DevExpress.XtraEditors.LookUpEdit();
            this.edBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.edWorld = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lc_StartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_Store = new DevExpress.XtraLayout.LayoutControlItem();
            this.worldDetail = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldSpace();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesNavBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTop)).BeginInit();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Store)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(641, 462);
            this.splitContainerControl1.SplitterPosition = 161;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nb_Import;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_Import,
            this.nb_WorldManager});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_AttachWGR,
            this.nbi_AttachHWGR,
            this.nbi_ChangeTimeRange,
            this.nbi_StopWorkingNow,
            this.nbi_ImportWorlds});
            this.navBarControl1.LargeImages = this.imagesNavBar;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.Size = new System.Drawing.Size(157, 458);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // nb_Import
            // 
            this.nb_Import.Caption = "Import";
            this.nb_Import.Expanded = true;
            this.nb_Import.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_Import.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ImportWorlds)});
            this.nb_Import.Name = "nb_Import";
            // 
            // nbi_ImportWorlds
            // 
            this.nbi_ImportWorlds.Caption = "Import Worlds";
            this.nbi_ImportWorlds.LargeImageIndex = 4;
            this.nbi_ImportWorlds.Name = "nbi_ImportWorlds";
            this.nbi_ImportWorlds.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ImportClick);
            // 
            // nb_WorldManager
            // 
            this.nb_WorldManager.Caption = "World manager";
            this.nb_WorldManager.Expanded = true;
            this.nb_WorldManager.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nb_WorldManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_AttachHWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_StopWorkingNow),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_ChangeTimeRange),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_AttachWGR)});
            this.nb_WorldManager.Name = "nb_WorldManager";
            // 
            // nbi_AttachHWGR
            // 
            this.nbi_AttachHWGR.Caption = "Assign HWGR";
            this.nbi_AttachHWGR.Enabled = false;
            this.nbi_AttachHWGR.LargeImageIndex = 2;
            this.nbi_AttachHWGR.Name = "nbi_AttachHWGR";
            this.nbi_AttachHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.AttachHwgrClick);
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
            this.nbi_AttachWGR.LargeImageIndex = 3;
            this.nbi_AttachWGR.Name = "nbi_AttachWGR";
            this.nbi_AttachWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.AttachWgrClick);
            // 
            // imagesNavBar
            // 
            this.imagesNavBar.ImageSize = new System.Drawing.Size(32, 32);
            this.imagesNavBar.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imagesNavBar.ImageStream")));
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel1.Controls.Add(this._worldGrid);
            this.splitContainerControl2.Panel1.Controls.Add(this.layoutTop);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel2.Controls.Add(this.worldDetail);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(468, 458);
            this.splitContainerControl2.SplitterPosition = 345;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // _worldGrid
            // 
            this._worldGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._worldGrid.Enabled = false;
            this._worldGrid.Entity = null;
            this._worldGrid.Location = new System.Drawing.Point(0, 95);
            this._worldGrid.LookAndFeel.SkinName = "iMaginary";
            this._worldGrid.Name = "_worldGrid";
            this._worldGrid.Size = new System.Drawing.Size(468, 250);
            this._worldGrid.TabIndex = 0;
            this._worldGrid.SelectEntity += new System.EventHandler(this.gridelectEntity);
            // 
            // layoutTop
            // 
            this.layoutTop.Controls.Add(this.edStore);
            this.layoutTop.Controls.Add(this.edBeginDate);
            this.layoutTop.Controls.Add(this.edWorld);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Root = this.layoutControlGroup1;
            this.layoutTop.Size = new System.Drawing.Size(468, 95);
            this.layoutTop.TabIndex = 0;
            this.layoutTop.Text = "layoutControl1";
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
            this.edStore.Properties.ValueMember = "ID";
            this.edStore.Size = new System.Drawing.Size(401, 20);
            this.edStore.StyleController = this.layoutTop;
            this.edStore.TabIndex = 8;
            this.edStore.TextChanged += new System.EventHandler(this.Storeselected);
            // 
            // edBeginDate
            // 
            this.edBeginDate.EditValue = null;
            this.edBeginDate.Location = new System.Drawing.Point(61, 69);
            this.edBeginDate.Name = "edBeginDate";
            this.edBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edBeginDate.Size = new System.Drawing.Size(401, 20);
            this.edBeginDate.StyleController = this.layoutTop;
            this.edBeginDate.TabIndex = 6;
            this.edBeginDate.EditValueChanged += new System.EventHandler(this.FilterChanged);
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
            this.edWorld.Size = new System.Drawing.Size(401, 20);
            this.edWorld.StyleController = this.layoutTop;
            this.edWorld.TabIndex = 7;
            this.edWorld.TextChanged += new System.EventHandler(this.WorldSelect);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lc_StartDate,
            this.lc_World,
            this.lc_Store});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(468, 95);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lc_StartDate
            // 
            this.lc_StartDate.Control = this.edBeginDate;
            this.lc_StartDate.CustomizationFormText = "Start date";
            this.lc_StartDate.Location = new System.Drawing.Point(0, 62);
            this.lc_StartDate.Name = "lc_StartDate";
            this.lc_StartDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_StartDate.Size = new System.Drawing.Size(466, 31);
            this.lc_StartDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_StartDate.Text = "Filter date";
            this.lc_StartDate.TextSize = new System.Drawing.Size(49, 20);
            this.lc_StartDate.TextVisible = true;
            // 
            // lc_World
            // 
            this.lc_World.Control = this.edWorld;
            this.lc_World.CustomizationFormText = "World";
            this.lc_World.Location = new System.Drawing.Point(0, 31);
            this.lc_World.Name = "lc_World";
            this.lc_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_World.Size = new System.Drawing.Size(466, 31);
            this.lc_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_World.Text = "World";
            this.lc_World.TextSize = new System.Drawing.Size(49, 20);
            this.lc_World.TextVisible = true;
            // 
            // lc_Store
            // 
            this.lc_Store.Control = this.edStore;
            this.lc_Store.CustomizationFormText = "Store";
            this.lc_Store.Location = new System.Drawing.Point(0, 0);
            this.lc_Store.Name = "lc_Store";
            this.lc_Store.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_Store.Size = new System.Drawing.Size(466, 31);
            this.lc_Store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_Store.Text = "Store";
            this.lc_Store.TextSize = new System.Drawing.Size(49, 20);
            this.lc_Store.TextVisible = true;
            // 
            // worldDetail
            // 
            this.worldDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldDetail.Enabled = false;
            this.worldDetail.Entity = null;
            this.worldDetail.Location = new System.Drawing.Point(0, 0);
            this.worldDetail.LookAndFeel.SkinName = "iMaginary";
            this.worldDetail.Name = "worldDetail";
            this.worldDetail.Size = new System.Drawing.Size(468, 105);
            this.worldDetail.TabIndex = 0;
            // 
            // UCWorldList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldList";
            this.Size = new System.Drawing.Size(641, 462);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesNavBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutTop)).EndInit();
            this.layoutTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Store)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UCWorldManagerGrid _worldGrid;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.Utils.ImageCollection imagesNavBar;
        private DevExpress.XtraLayout.LayoutControl layoutTop;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit edBeginDate;
        private DevExpress.XtraLayout.LayoutControlItem lc_StartDate;
        private DevExpress.XtraNavBar.NavBarGroup nb_WorldManager;
        private DevExpress.XtraNavBar.NavBarItem nbi_AttachHWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_AttachWGR;
        private DevExpress.XtraNavBar.NavBarItem nbi_ChangeTimeRange;
        private DevExpress.XtraNavBar.NavBarItem nbi_StopWorkingNow;
        private UCWorldSpace worldDetail;
        private DevExpress.XtraEditors.LookUpEdit edStore;
        private DevExpress.XtraEditors.LookUpEdit edWorld;
        private DevExpress.XtraLayout.LayoutControlItem lc_World;
        private DevExpress.XtraLayout.LayoutControlItem lc_Store;
        private DevExpress.XtraNavBar.NavBarGroup nb_Import;
        private DevExpress.XtraNavBar.NavBarItem nbi_ImportWorlds;
    }
}
