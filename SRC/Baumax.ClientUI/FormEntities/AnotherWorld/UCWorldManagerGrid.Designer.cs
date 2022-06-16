namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldManagerGrid
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorldManagerGrid));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridWGR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcImage2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.image16x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.gg_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gg_BeginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gg_EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_AttachHwgrTo = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_AttachWgr = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_ChangeTimeRange = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_StopWorkingNow = new System.Windows.Forms.ToolStripMenuItem();
            this.gridHWGR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWGR
            // 
            this.gridWGR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcImage2,
            this.gg_Name,
            this.gg_BeginTime,
            this.gg_EndTime});
            this.gridWGR.GridControl = this.gridControl1;
            this.gridWGR.Images = this.image16x16;
            this.gridWGR.Name = "gridWGR";
            this.gridWGR.OptionsView.ShowGroupPanel = false;
            this.gridWGR.ViewCaption = "WGRsss";
            this.gridWGR.DragObjectStart += new DevExpress.XtraGrid.Views.Base.DragObjectStartEventHandler(this.wgrDragStart);
            this.gridWGR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridWGR_MouseDown);
            this.gridWGR.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.wgrDragDopEnd);
            this.gridWGR.DragObjectOver += new DevExpress.XtraGrid.Views.Base.DragObjectOverEventHandler(this.wgrDragProcess);
            this.gridWGR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridWGR_MouseMove);
            // 
            // gcImage2
            // 
            this.gcImage2.ColumnEdit = this.repositoryItemImageComboBox2;
            this.gcImage2.CustomizationCaption = "Image";
            this.gcImage2.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gcImage2.ImageIndex = 2;
            this.gcImage2.Name = "gcImage2";
            this.gcImage2.OptionsColumn.AllowEdit = false;
            this.gcImage2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcImage2.OptionsColumn.AllowMove = false;
            this.gcImage2.OptionsColumn.AllowSize = false;
            this.gcImage2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcImage2.OptionsColumn.FixedWidth = true;
            this.gcImage2.OptionsColumn.ReadOnly = true;
            this.gcImage2.OptionsFilter.AllowFilter = false;
            this.gcImage2.Visible = true;
            this.gcImage2.VisibleIndex = 0;
            this.gcImage2.Width = 30;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 2)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.ReadOnly = true;
            this.repositoryItemImageComboBox2.SmallImages = this.image16x16;
            // 
            // image16x16
            // 
            this.image16x16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("image16x16.ImageStream")));
            // 
            // gg_Name
            // 
            this.gg_Name.Caption = "Name";
            this.gg_Name.FieldName = "Name";
            this.gg_Name.Name = "gg_Name";
            this.gg_Name.OptionsColumn.AllowEdit = false;
            this.gg_Name.Visible = true;
            this.gg_Name.VisibleIndex = 1;
            // 
            // gg_BeginTime
            // 
            this.gg_BeginTime.Caption = "Begin Time";
            this.gg_BeginTime.FieldName = "BeginTime";
            this.gg_BeginTime.Name = "gg_BeginTime";
            this.gg_BeginTime.OptionsColumn.AllowEdit = false;
            this.gg_BeginTime.Visible = true;
            this.gg_BeginTime.VisibleIndex = 2;
            // 
            // gg_EndTime
            // 
            this.gg_EndTime.Caption = "End Time";
            this.gg_EndTime.FieldName = "EndTime";
            this.gg_EndTime.Name = "gg_EndTime";
            this.gg_EndTime.OptionsColumn.AllowEdit = false;
            this.gg_EndTime.Visible = true;
            this.gg_EndTime.VisibleIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenu;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.gridWGR;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.SkinName = "Money Twins";
            this.gridControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.gridControl1.MainView = this.gridHWGR;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2});
            this.gridControl1.Size = new System.Drawing.Size(602, 357);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridHWGR,
            this.gridWGR});
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_AttachHwgrTo,
            this.ts_AttachWgr,
            this.separator2,
            this.ts_ChangeTimeRange,
            this.ts_StopWorkingNow});
            this.contextMenu.Name = "contextHWGR";
            this.contextMenu.Size = new System.Drawing.Size(179, 120);
            // 
            // ts_AttachHwgrTo
            // 
            this.ts_AttachHwgrTo.Name = "ts_AttachHwgrTo";
            this.ts_AttachHwgrTo.Size = new System.Drawing.Size(178, 22);
            this.ts_AttachHwgrTo.Text = "Assign new HWGR";
            this.ts_AttachHwgrTo.Click += new System.EventHandler(this.AttachHwgrClick);
            // 
            // ts_AttachWgr
            // 
            this.ts_AttachWgr.Name = "ts_AttachWgr";
            this.ts_AttachWgr.Size = new System.Drawing.Size(178, 22);
            this.ts_AttachWgr.Text = "Assign new WGR...";
            this.ts_AttachWgr.Click += new System.EventHandler(this.AttachWgrClick);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(175, 6);
            // 
            // ts_ChangeTimeRange
            // 
            this.ts_ChangeTimeRange.Name = "ts_ChangeTimeRange";
            this.ts_ChangeTimeRange.Size = new System.Drawing.Size(178, 22);
            this.ts_ChangeTimeRange.Text = "Change time range";
            this.ts_ChangeTimeRange.Click += new System.EventHandler(this.ChangeTimeRangeClick);
            // 
            // ts_StopWorkingNow
            // 
            this.ts_StopWorkingNow.Name = "ts_StopWorkingNow";
            this.ts_StopWorkingNow.Size = new System.Drawing.Size(178, 22);
            this.ts_StopWorkingNow.Text = "Stop working now";
            this.ts_StopWorkingNow.Click += new System.EventHandler(this.StopWorkingNowClick);
            // 
            // gridHWGR
            // 
            this.gridHWGR.ChildGridLevelName = "Level1";
            this.gridHWGR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcImage,
            this.gc_Name,
            this.gc_BeginTime,
            this.gc_EndTime});
            this.gridHWGR.GridControl = this.gridControl1;
            this.gridHWGR.Images = this.image16x16;
            this.gridHWGR.Name = "gridHWGR";
            this.gridHWGR.OptionsBehavior.Editable = false;
            this.gridHWGR.OptionsView.ShowGroupPanel = false;
            this.gridHWGR.SynchronizeClones = false;
            this.gridHWGR.MasterRowGetLevelDefaultView += new DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventHandler(this.gridHWGR_GetChild);
            this.gridHWGR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridHWGR_MouseDown);
            this.gridHWGR.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.DragDrop);
            // 
            // gcImage
            // 
            this.gcImage.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gcImage.CustomizationCaption = "Image";
            this.gcImage.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gcImage.ImageIndex = 1;
            this.gcImage.Name = "gcImage";
            this.gcImage.OptionsColumn.AllowEdit = false;
            this.gcImage.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcImage.OptionsColumn.AllowMove = false;
            this.gcImage.OptionsColumn.AllowSize = false;
            this.gcImage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcImage.OptionsColumn.FixedWidth = true;
            this.gcImage.OptionsFilter.AllowFilter = false;
            this.gcImage.Visible = true;
            this.gcImage.VisibleIndex = 0;
            this.gcImage.Width = 30;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.image16x16;
            // 
            // gc_Name
            // 
            this.gc_Name.Caption = "Name";
            this.gc_Name.FieldName = "Name";
            this.gc_Name.Name = "gc_Name";
            this.gc_Name.Visible = true;
            this.gc_Name.VisibleIndex = 1;
            this.gc_Name.Width = 181;
            // 
            // gc_BeginTime
            // 
            this.gc_BeginTime.Caption = "Begin Time";
            this.gc_BeginTime.FieldName = "BeginTime";
            this.gc_BeginTime.Name = "gc_BeginTime";
            this.gc_BeginTime.Visible = true;
            this.gc_BeginTime.VisibleIndex = 2;
            this.gc_BeginTime.Width = 181;
            // 
            // gc_EndTime
            // 
            this.gc_EndTime.Caption = "End Time";
            this.gc_EndTime.FieldName = "EndTime";
            this.gc_EndTime.Name = "gc_EndTime";
            this.gc_EndTime.Visible = true;
            this.gc_EndTime.VisibleIndex = 3;
            this.gc_EndTime.Width = 189;
            // 
            // UCWorldManagerGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldManagerGrid";
            this.Size = new System.Drawing.Size(602, 357);
            ((System.ComponentModel.ISupportInitialize)(this.gridWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl gridControl1;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridWGR;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridHWGR;
        protected DevExpress.XtraGrid.Columns.GridColumn gc_Name;
        protected DevExpress.XtraGrid.Columns.GridColumn gc_BeginTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gc_EndTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gg_Name;
        protected DevExpress.XtraGrid.Columns.GridColumn gg_BeginTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gg_EndTime;
        protected DevExpress.XtraGrid.Columns.GridColumn gcImage;
        protected DevExpress.XtraGrid.Columns.GridColumn gcImage2;
        protected DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        protected DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        protected DevExpress.Utils.ImageCollection image16x16;
        protected System.Windows.Forms.ContextMenuStrip contextMenu;
        protected System.Windows.Forms.ToolStripMenuItem ts_AttachHwgrTo;
        protected System.Windows.Forms.ToolStripMenuItem ts_AttachWgr;
        protected System.Windows.Forms.ToolStripSeparator separator2;
        protected System.Windows.Forms.ToolStripMenuItem ts_ChangeTimeRange;
        protected System.Windows.Forms.ToolStripMenuItem ts_StopWorkingNow;
        private System.ComponentModel.IContainer components;

    }
}
