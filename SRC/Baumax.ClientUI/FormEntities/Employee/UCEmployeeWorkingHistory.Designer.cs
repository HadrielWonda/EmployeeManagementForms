namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class UCEmployeeWorkingHistory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCEmployeeWorkingHistory));
			this.gridControl = new DevExpress.XtraGrid.GridControl();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mi_NewAssignEmplToWorld = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_EditAssignEmplToWorld = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_DeleteAssignEmplToWorld = new System.Windows.Forms.ToolStripMenuItem();
			this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc_Store = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_World = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.teEmployee = new DevExpress.XtraEditors.TextEdit();
			this.lbl_Employee = new DevExpress.XtraEditors.LabelControl();
			this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
			this.bgItems = new DevExpress.XtraNavBar.NavBarGroup();
			this.bi_NewAssignEmplToWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.bi_EditAssignEmplToWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.bi_DeleteAssignEmplToWorld = new DevExpress.XtraNavBar.NavBarItem();
			this.barImages = new DevExpress.Utils.ImageCollection(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barImages)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl
			// 
			this.gridControl.ContextMenuStrip = this.contextMenuStrip1;
			this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl.EmbeddedNavigator.Name = "";
			this.gridControl.Location = new System.Drawing.Point(195, 33);
			this.gridControl.MainView = this.gridViewEntities;
			this.gridControl.Name = "gridControl";
			this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
			this.gridControl.Size = new System.Drawing.Size(443, 429);
			this.gridControl.TabIndex = 0;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities});
			this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_NewAssignEmplToWorld,
            this.mi_EditAssignEmplToWorld,
            this.mi_DeleteAssignEmplToWorld});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(150, 70);
			// 
			// mi_NewAssignEmplToWorld
			// 
			this.mi_NewAssignEmplToWorld.Name = "mi_NewAssignEmplToWorld";
			this.mi_NewAssignEmplToWorld.Size = new System.Drawing.Size(149, 22);
			this.mi_NewAssignEmplToWorld.Text = "New assign";
			this.mi_NewAssignEmplToWorld.Click += new System.EventHandler(this.mi_NewAssignEmplToWorld_Click);
			// 
			// mi_EditAssignEmplToWorld
			// 
			this.mi_EditAssignEmplToWorld.Name = "mi_EditAssignEmplToWorld";
			this.mi_EditAssignEmplToWorld.Size = new System.Drawing.Size(149, 22);
			this.mi_EditAssignEmplToWorld.Text = "Edit assign";
			this.mi_EditAssignEmplToWorld.Visible = false;
			this.mi_EditAssignEmplToWorld.Click += new System.EventHandler(this.mi_EditAssignEmplToWorld_Click);
			// 
			// mi_DeleteAssignEmplToWorld
			// 
			this.mi_DeleteAssignEmplToWorld.Name = "mi_DeleteAssignEmplToWorld";
			this.mi_DeleteAssignEmplToWorld.Size = new System.Drawing.Size(149, 22);
			this.mi_DeleteAssignEmplToWorld.Text = "Delete assign";
			this.mi_DeleteAssignEmplToWorld.Visible = false;
			this.mi_DeleteAssignEmplToWorld.Click += new System.EventHandler(this.mi_DeleteAssignEmplToWorld_Click);
			// 
			// gridViewEntities
			// 
			this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Store,
            this.gc_World,
            this.gc_BeginDate,
            this.gc_EndDate});
			this.gridViewEntities.GridControl = this.gridControl;
			this.gridViewEntities.Name = "gridViewEntities";
			this.gridViewEntities.OptionsCustomization.AllowColumnMoving = false;
			this.gridViewEntities.OptionsFilter.AllowColumnMRUFilterList = false;
			this.gridViewEntities.OptionsFilter.AllowFilterEditor = false;
			this.gridViewEntities.OptionsFilter.AllowMRUFilterList = false;
			this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
			this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
			this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
			this.gridViewEntities.OptionsView.ShowGroupPanel = false;
			this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
			this.gridViewEntities.RowCountChanged += new System.EventHandler(this.gridViewEntities_RowCountChanged);
			// 
			// gc_Store
			// 
			this.gc_Store.Caption = "Store";
			this.gc_Store.FieldName = "StoreName";
			this.gc_Store.Name = "gc_Store";
			this.gc_Store.OptionsColumn.AllowEdit = false;
			this.gc_Store.OptionsColumn.ReadOnly = true;
			this.gc_Store.OptionsColumn.ShowInCustomizationForm = false;
			this.gc_Store.OptionsFilter.AllowFilter = false;
			this.gc_Store.Visible = true;
			this.gc_Store.VisibleIndex = 0;
			// 
			// gc_World
			// 
			this.gc_World.Caption = "World";
			this.gc_World.FieldName = "WorldName";
			this.gc_World.Name = "gc_World";
			this.gc_World.OptionsColumn.AllowEdit = false;
			this.gc_World.OptionsColumn.ReadOnly = true;
			this.gc_World.OptionsColumn.ShowInCustomizationForm = false;
			this.gc_World.OptionsFilter.AllowFilter = false;
			this.gc_World.Visible = true;
			this.gc_World.VisibleIndex = 1;
			// 
			// gc_BeginDate
			// 
			this.gc_BeginDate.Caption = "Begin";
			this.gc_BeginDate.ColumnEdit = this.repositoryItemDateEdit1;
			this.gc_BeginDate.FieldName = "BeginTime";
			this.gc_BeginDate.Name = "gc_BeginDate";
			this.gc_BeginDate.OptionsColumn.AllowEdit = false;
			this.gc_BeginDate.OptionsColumn.ReadOnly = true;
			this.gc_BeginDate.OptionsColumn.ShowInCustomizationForm = false;
			this.gc_BeginDate.OptionsFilter.AllowFilter = false;
			this.gc_BeginDate.Visible = true;
			this.gc_BeginDate.VisibleIndex = 2;
			// 
			// repositoryItemDateEdit1
			// 
			this.repositoryItemDateEdit1.AutoHeight = false;
			this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
			this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			// 
			// gc_EndDate
			// 
			this.gc_EndDate.Caption = "End";
			this.gc_EndDate.ColumnEdit = this.repositoryItemDateEdit1;
			this.gc_EndDate.FieldName = "EndTime";
			this.gc_EndDate.Name = "gc_EndDate";
			this.gc_EndDate.OptionsColumn.AllowEdit = false;
			this.gc_EndDate.OptionsColumn.ReadOnly = true;
			this.gc_EndDate.OptionsColumn.ShowInCustomizationForm = false;
			this.gc_EndDate.OptionsFilter.AllowFilter = false;
			this.gc_EndDate.Visible = true;
			this.gc_EndDate.VisibleIndex = 3;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.teEmployee);
			this.panelControl1.Controls.Add(this.lbl_Employee);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(638, 33);
			this.panelControl1.TabIndex = 1;
			// 
			// teEmployee
			// 
			this.teEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.teEmployee.Enabled = false;
			this.teEmployee.Location = new System.Drawing.Point(120, 6);
			this.teEmployee.Name = "teEmployee";
			this.teEmployee.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teEmployee.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teEmployee.Size = new System.Drawing.Size(513, 20);
			this.teEmployee.TabIndex = 1;
			// 
			// lbl_Employee
			// 
			this.lbl_Employee.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbl_Employee.Location = new System.Drawing.Point(5, 9);
			this.lbl_Employee.Name = "lbl_Employee";
			this.lbl_Employee.Size = new System.Drawing.Size(109, 13);
			this.lbl_Employee.TabIndex = 0;
			this.lbl_Employee.Text = "Employee";
			// 
			// navBarControl1
			// 
			this.navBarControl1.ActiveGroup = this.bgItems;
			this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.navBarControl1.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.bgItems});
			this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.bi_EditAssignEmplToWorld,
            this.bi_NewAssignEmplToWorld,
            this.bi_DeleteAssignEmplToWorld});
			this.navBarControl1.LargeImages = this.barImages;
			this.navBarControl1.Location = new System.Drawing.Point(0, 33);
			this.navBarControl1.Name = "navBarControl1";
			this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
			this.navBarControl1.Size = new System.Drawing.Size(195, 429);
			this.navBarControl1.TabIndex = 2;
			this.navBarControl1.Text = "navBarControl1";
			this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
			// 
			// bgItems
			// 
			this.bgItems.Appearance.Options.UseTextOptions = true;
			this.bgItems.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.bgItems.Caption = "";
			this.bgItems.Expanded = true;
			this.bgItems.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
			this.bgItems.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_NewAssignEmplToWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_EditAssignEmplToWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_DeleteAssignEmplToWorld)});
			this.bgItems.Name = "bgItems";
			// 
			// bi_NewAssignEmplToWorld
			// 
			this.bi_NewAssignEmplToWorld.Appearance.Options.UseTextOptions = true;
			this.bi_NewAssignEmplToWorld.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.bi_NewAssignEmplToWorld.Caption = "New assign empl. to world";
			this.bi_NewAssignEmplToWorld.LargeImageIndex = 0;
			this.bi_NewAssignEmplToWorld.Name = "bi_NewAssignEmplToWorld";
			this.bi_NewAssignEmplToWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_New_LinkClicked);
			// 
			// bi_EditAssignEmplToWorld
			// 
			this.bi_EditAssignEmplToWorld.Appearance.Options.UseTextOptions = true;
			this.bi_EditAssignEmplToWorld.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.bi_EditAssignEmplToWorld.Caption = "Edit assign empl. to world";
			this.bi_EditAssignEmplToWorld.Name = "bi_EditAssignEmplToWorld";
			this.bi_EditAssignEmplToWorld.Visible = false;
			this.bi_EditAssignEmplToWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_Edit_LinkClicked);
			// 
			// bi_DeleteAssignEmplToWorld
			// 
			this.bi_DeleteAssignEmplToWorld.Appearance.Options.UseTextOptions = true;
			this.bi_DeleteAssignEmplToWorld.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.bi_DeleteAssignEmplToWorld.Caption = "Delete assign empl. to world";
			this.bi_DeleteAssignEmplToWorld.Name = "bi_DeleteAssignEmplToWorld";
			this.bi_DeleteAssignEmplToWorld.Visible = false;
			this.bi_DeleteAssignEmplToWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_Delete_LinkClicked);
			// 
			// barImages
			// 
			this.barImages.ImageSize = new System.Drawing.Size(32, 32);
			this.barImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("barImages.ImageStream")));
			// 
			// UCEmployeeWorkingHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControl);
			this.Controls.Add(this.navBarControl1);
			this.Controls.Add(this.panelControl1);
			this.LookAndFeel.SkinName = "iMaginary";
			this.Name = "UCEmployeeWorkingHistory";
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.teEmployee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barImages)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit teEmployee;
        private DevExpress.XtraEditors.LabelControl lbl_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Store;
        private DevExpress.XtraGrid.Columns.GridColumn gc_World;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup bgItems;
        private DevExpress.XtraNavBar.NavBarItem bi_NewAssignEmplToWorld;
        private DevExpress.XtraNavBar.NavBarItem bi_EditAssignEmplToWorld;
        private DevExpress.XtraNavBar.NavBarItem bi_DeleteAssignEmplToWorld;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_NewAssignEmplToWorld;
        private System.Windows.Forms.ToolStripMenuItem mi_EditAssignEmplToWorld;
        private System.Windows.Forms.ToolStripMenuItem mi_DeleteAssignEmplToWorld;
        private DevExpress.Utils.ImageCollection barImages;
    }
}
