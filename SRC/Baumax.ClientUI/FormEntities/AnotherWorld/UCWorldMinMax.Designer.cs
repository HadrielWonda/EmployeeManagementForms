namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCWorldMinMax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorldMinMax));
            this.edWorld = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnImages = new DevExpress.Utils.ImageCollection(this.components);
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lc_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_AddPersonMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_EditPersonMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeletePersonMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_MinPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_MaxPer = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // edWorld
            // 
            this.edWorld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edWorld.Location = new System.Drawing.Point(39, 6);
            this.edWorld.Name = "edWorld";
            this.edWorld.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edWorld.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorldName", "WorldName", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edWorld.Properties.DisplayMember = "WorldName";
            this.edWorld.Properties.NullText = "";
            this.edWorld.Properties.ShowFooter = false;
            this.edWorld.Properties.ShowHeader = false;
            this.edWorld.Properties.ValueMember = "ID";
            this.edWorld.Size = new System.Drawing.Size(275, 20);
            this.edWorld.StyleController = this.layoutControl1;
            this.edWorld.TabIndex = 1;
            this.edWorld.EditValueChanged += new System.EventHandler(this.edWorld_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.edWorld);
            this.layoutControl1.Controls.Add(this.btnEdit);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(444, 37);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.btnImages;
            this.btnAdd.Location = new System.Drawing.Point(325, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.ToolTip = "Add new record";
            this.btnAdd.Click += new System.EventHandler(this.ts_AddNew_Click);
            // 
            // btnImages
            // 
            this.btnImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("btnImages.ImageStream")));
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageIndex = 1;
            this.btnEdit.ImageList = this.btnImages;
            this.btnEdit.Location = new System.Drawing.Point(364, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(28, 24);
            this.btnEdit.StyleController = this.layoutControl1;
            this.btnEdit.TabIndex = 3;
            this.btnEdit.ToolTip = "Edit choose record";
            this.btnEdit.Click += new System.EventHandler(this.ts_Edit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.btnImages;
            this.btnDelete.Location = new System.Drawing.Point(403, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 24);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = " ";
            this.btnDelete.ToolTip = "Delete record";
            this.btnDelete.Click += new System.EventHandler(this.ts_Delete_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lc_World,
            this.layoutControlItem1,
            this.lcRefresh,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(444, 37);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lc_World
            // 
            this.lc_World.Control = this.edWorld;
            this.lc_World.CustomizationFormText = "World";
            this.lc_World.Location = new System.Drawing.Point(0, 0);
            this.lc_World.Name = "lc_World";
            this.lc_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_World.Size = new System.Drawing.Size(319, 37);
            this.lc_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_World.Text = "World";
            this.lc_World.TextSize = new System.Drawing.Size(28, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnAdd;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(319, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(39, 37);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcRefresh
            // 
            this.lcRefresh.Control = this.btnDelete;
            this.lcRefresh.CustomizationFormText = "lcRefresh";
            this.lcRefresh.Location = new System.Drawing.Point(397, 0);
            this.lcRefresh.Name = "lcRefresh";
            this.lcRefresh.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lcRefresh.Size = new System.Drawing.Size(47, 37);
            this.lcRefresh.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcRefresh.Text = "lcRefresh";
            this.lcRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.lcRefresh.TextToControlDistance = 0;
            this.lcRefresh.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnEdit;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(358, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(39, 37);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_AddPersonMinMax,
            this.ts_EditPersonMinMax,
            this.ts_DeletePersonMinMax});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(120, 70);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // ts_AddPersonMinMax
            // 
            this.ts_AddPersonMinMax.Image = global::Baumax.ClientUI.Properties.Resources._NEW;
            this.ts_AddPersonMinMax.Name = "ts_AddPersonMinMax";
            this.ts_AddPersonMinMax.Size = new System.Drawing.Size(119, 22);
            this.ts_AddPersonMinMax.Text = "Add new";
            this.ts_AddPersonMinMax.Click += new System.EventHandler(this.ts_AddNew_Click);
            // 
            // ts_EditPersonMinMax
            // 
            this.ts_EditPersonMinMax.Enabled = false;
            this.ts_EditPersonMinMax.Image = global::Baumax.ClientUI.Properties.Resources._EDIT;
            this.ts_EditPersonMinMax.Name = "ts_EditPersonMinMax";
            this.ts_EditPersonMinMax.Size = new System.Drawing.Size(119, 22);
            this.ts_EditPersonMinMax.Text = "Edit";
            this.ts_EditPersonMinMax.Click += new System.EventHandler(this.ts_Edit_Click);
            // 
            // ts_DeletePersonMinMax
            // 
            this.ts_DeletePersonMinMax.Enabled = false;
            this.ts_DeletePersonMinMax.Image = global::Baumax.ClientUI.Properties.Resources._DELETE;
            this.ts_DeletePersonMinMax.Name = "ts_DeletePersonMinMax";
            this.ts_DeletePersonMinMax.Size = new System.Drawing.Size(119, 22);
            this.ts_DeletePersonMinMax.Text = "Delete";
            this.ts_DeletePersonMinMax.Click += new System.EventHandler(this.ts_Delete_Click);
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.cms;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 37);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(444, 333);
            this.gridControl.TabIndex = 8;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_KeyDown);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Year,
            this.gc_MinPer,
            this.gc_MaxPer});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.RowCountChanged += new System.EventHandler(this.gridView_RowCountChanged);
            // 
            // gc_Year
            // 
            this.gc_Year.Caption = "Year";
            this.gc_Year.FieldName = "Year";
            this.gc_Year.Name = "gc_Year";
            this.gc_Year.Visible = true;
            this.gc_Year.VisibleIndex = 0;
            this.gc_Year.Width = 102;
            // 
            // gc_MinPer
            // 
            this.gc_MinPer.Caption = "Minimum";
            this.gc_MinPer.FieldName = "Min";
            this.gc_MinPer.Name = "gc_MinPer";
            this.gc_MinPer.Visible = true;
            this.gc_MinPer.VisibleIndex = 1;
            this.gc_MinPer.Width = 92;
            // 
            // gc_MaxPer
            // 
            this.gc_MaxPer.Caption = "Maximum";
            this.gc_MaxPer.FieldName = "Max";
            this.gc_MaxPer.Name = "gc_MaxPer";
            this.gc_MaxPer.Visible = true;
            this.gc_MaxPer.VisibleIndex = 2;
            this.gc_MaxPer.Width = 95;
            // 
            // UCWorldMinMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldMinMax";
            this.Size = new System.Drawing.Size(444, 370);
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit edWorld;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem ts_AddPersonMinMax;
        private System.Windows.Forms.ToolStripMenuItem ts_EditPersonMinMax;
        private System.Windows.Forms.ToolStripMenuItem ts_DeletePersonMinMax;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lc_World;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lcRefresh;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Year;
        private DevExpress.XtraGrid.Columns.GridColumn gc_MinPer;
        private DevExpress.XtraGrid.Columns.GridColumn gc_MaxPer;
        private DevExpress.Utils.ImageCollection btnImages;
    }
}
