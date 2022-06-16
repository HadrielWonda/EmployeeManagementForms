namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCStoreTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStoreTree));
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.tc_Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tc_StartDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tc_EndDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_AssignHwgr = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_AssignWgr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_images = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryEdit)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tc_Name,
            this.tc_StartDate,
            this.tc_EndDate});
            this.treeList.ContextMenuStrip = this.cms;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsView.ShowButtons = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryEdit});
            this.treeList.SelectImageList = this.m_images;
            this.treeList.Size = new System.Drawing.Size(480, 384);
            this.treeList.TabIndex = 0;
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treeList.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
            // 
            // tc_Name
            // 
            this.tc_Name.Caption = "Name";
            this.tc_Name.FieldName = "ItemName";
            this.tc_Name.MinWidth = 27;
            this.tc_Name.Name = "tc_Name";
            this.tc_Name.OptionsColumn.AllowEdit = false;
            this.tc_Name.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.tc_Name.OptionsColumn.ReadOnly = true;
            this.tc_Name.OptionsColumn.ShowInCustomizationForm = false;
            this.tc_Name.Visible = true;
            this.tc_Name.VisibleIndex = 0;
            // 
            // tc_StartDate
            // 
            this.tc_StartDate.Caption = "Start";
            this.tc_StartDate.ColumnEdit = this.repositoryEdit;
            this.tc_StartDate.FieldName = "BeginTime";
            this.tc_StartDate.Format.FormatString = "d";
            this.tc_StartDate.Name = "tc_StartDate";
            this.tc_StartDate.OptionsColumn.AllowEdit = false;
            this.tc_StartDate.OptionsColumn.AllowMove = false;
            this.tc_StartDate.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.tc_StartDate.OptionsColumn.ReadOnly = true;
            this.tc_StartDate.OptionsColumn.ShowInCustomizationForm = false;
            this.tc_StartDate.Visible = true;
            this.tc_StartDate.VisibleIndex = 1;
            // 
            // repositoryEdit
            // 
            this.repositoryEdit.AutoHeight = false;
            this.repositoryEdit.DisplayFormat.FormatString = "d";
            this.repositoryEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryEdit.Mask.EditMask = "d";
            this.repositoryEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.repositoryEdit.Name = "repositoryEdit";
            // 
            // tc_EndDate
            // 
            this.tc_EndDate.Caption = "End";
            this.tc_EndDate.ColumnEdit = this.repositoryEdit;
            this.tc_EndDate.FieldName = "EndTime";
            this.tc_EndDate.Format.FormatString = "d";
            this.tc_EndDate.Name = "tc_EndDate";
            this.tc_EndDate.OptionsColumn.AllowEdit = false;
            this.tc_EndDate.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.tc_EndDate.OptionsColumn.ReadOnly = true;
            this.tc_EndDate.OptionsColumn.ShowInCustomizationForm = false;
            this.tc_EndDate.Visible = true;
            this.tc_EndDate.VisibleIndex = 2;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_AssignHwgr,
            this.ts_AssignWgr});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(198, 48);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // ts_AssignHwgr
            // 
            this.ts_AssignHwgr.Name = "ts_AssignHwgr";
            this.ts_AssignHwgr.Size = new System.Drawing.Size(197, 22);
            this.ts_AssignHwgr.Text = "Assign  HWGR to World";
            this.ts_AssignHwgr.Click += new System.EventHandler(this.ts_AssignThisHwgrToWorld_Click);
            // 
            // ts_AssignWgr
            // 
            this.ts_AssignWgr.Name = "ts_AssignWgr";
            this.ts_AssignWgr.Size = new System.Drawing.Size(197, 22);
            this.ts_AssignWgr.Text = "Assign WGR to HWGR";
            this.ts_AssignWgr.Click += new System.EventHandler(this.ts_AssignWgrToThisHwgr_Click);
            // 
            // m_images
            // 
            this.m_images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("m_images.ImageStream")));
            // 
            // UCStoreTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCStoreTree";
            this.Size = new System.Drawing.Size(480, 384);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryEdit)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn tc_Name;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tc_StartDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tc_EndDate;
        public DevExpress.XtraTreeList.TreeList treeList;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem ts_AssignHwgr;
        private System.Windows.Forms.ToolStripMenuItem ts_AssignWgr;
        private DevExpress.Utils.ImageCollection m_images;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryEdit;
    }
}
