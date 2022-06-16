namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCWorldDetailVertical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWorldDetailVertical));
            this.vGrid = new DevExpress.XtraVerticalGrid.VGridControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_ViewMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.repWorld = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.m_images = new DevExpress.Utils.ImageCollection(this.components);
            this.vc_World = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_AvailableWTH = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_CurrentlyAvailableBuffer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_BusinessVolumeHours = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_TargetedBusinessVolume = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_NetBusinessVolume = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_NetBusinessVolumeWithoutBuffer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_BenchmarkBusinessVolumePerHour = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_MinPer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vc_MaxPer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.vGrid)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).BeginInit();
            this.SuspendLayout();
            // 
            // vGrid
            // 
            this.vGrid.ContextMenuStrip = this.cms;
            this.vGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrid.Location = new System.Drawing.Point(0, 0);
            this.vGrid.Name = "vGrid";
            this.vGrid.OptionsBehavior.Editable = false;
            this.vGrid.RecordWidth = 108;
            this.vGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repWorld});
            this.vGrid.RowHeaderWidth = 222;
            this.vGrid.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.vc_World,
            this.vc_AvailableWTH,
            this.vc_CurrentlyAvailableBuffer,
            this.vc_BusinessVolumeHours,
            this.vc_TargetedBusinessVolume,
            this.vc_NetBusinessVolume,
            this.vc_NetBusinessVolumeWithoutBuffer,
            this.vc_BenchmarkBusinessVolumePerHour,
            this.vc_MinPer,
            this.vc_MaxPer});
            this.vGrid.Size = new System.Drawing.Size(542, 284);
            this.vGrid.TabIndex = 0;
            this.vGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UC_MouseDoubleClick);
            this.vGrid.FocusedRecordChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.vGrid_FocusedRecordChanged);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ViewMinMax,
            this.ts_Refresh});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(164, 48);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // ts_ViewMinMax
            // 
            this.ts_ViewMinMax.Image = global::Baumax.ClientUI.Properties.Resources.view_all_minmax;
            this.ts_ViewMinMax.Name = "ts_ViewMinMax";
            this.ts_ViewMinMax.Size = new System.Drawing.Size(163, 22);
            this.ts_ViewMinMax.Text = "View all min/max";
            // 
            // ts_Refresh
            // 
            this.ts_Refresh.Image = global::Baumax.ClientUI.Properties.Resources._REFRESH;
            this.ts_Refresh.Name = "ts_Refresh";
            this.ts_Refresh.Size = new System.Drawing.Size(163, 22);
            this.ts_Refresh.Text = "Refresh";
            // 
            // repWorld
            // 
            this.repWorld.AutoHeight = false;
            this.repWorld.Name = "repWorld";
            this.repWorld.SmallImages = this.m_images;
            // 
            // m_images
            // 
            this.m_images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("m_images.ImageStream")));
            // 
            // vc_World
            // 
            this.vc_World.Name = "vc_World";
            this.vc_World.Properties.Caption = "World name";
            this.vc_World.Properties.FieldName = "Name";
            this.vc_World.Properties.RowEdit = this.repWorld;
            // 
            // vc_AvailableWTH
            // 
            this.vc_AvailableWTH.Name = "vc_AvailableWTH";
            this.vc_AvailableWTH.Properties.Caption = "Available work-time-hours";
            this.vc_AvailableWTH.Properties.FieldName = "AvailableWorkTimeHours";
            // 
            // vc_CurrentlyAvailableBuffer
            // 
            this.vc_CurrentlyAvailableBuffer.Name = "vc_CurrentlyAvailableBuffer";
            this.vc_CurrentlyAvailableBuffer.Properties.Caption = "Currently available buffer";
            this.vc_CurrentlyAvailableBuffer.Properties.FieldName = "AvailableBufferHours";
            // 
            // vc_BusinessVolumeHours
            // 
            this.vc_BusinessVolumeHours.Name = "vc_BusinessVolumeHours";
            this.vc_BusinessVolumeHours.Properties.Caption = "Business volume hours";
            this.vc_BusinessVolumeHours.Properties.FieldName = "BusinessVolumeHours";
            // 
            // vc_TargetedBusinessVolume
            // 
            this.vc_TargetedBusinessVolume.Name = "vc_TargetedBusinessVolume";
            this.vc_TargetedBusinessVolume.Properties.Caption = "Targeted business volume";
            this.vc_TargetedBusinessVolume.Properties.FieldName = "TargetedBusinessVolume";
            // 
            // vc_NetBusinessVolume
            // 
            this.vc_NetBusinessVolume.Name = "vc_NetBusinessVolume";
            this.vc_NetBusinessVolume.Properties.Caption = "Net business volume";
            this.vc_NetBusinessVolume.Properties.FieldName = "NetBusinessVolume1";
            // 
            // vc_NetBusinessVolumeWithoutBuffer
            // 
            this.vc_NetBusinessVolumeWithoutBuffer.Name = "vc_NetBusinessVolumeWithoutBuffer";
            this.vc_NetBusinessVolumeWithoutBuffer.Properties.Caption = "Net business volume without buffer";
            // 
            // vc_BenchmarkBusinessVolumePerHour
            // 
            this.vc_BenchmarkBusinessVolumePerHour.Name = "vc_BenchmarkBusinessVolumePerHour";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.Caption = "Benchmark business volume per hour";
            this.vc_BenchmarkBusinessVolumePerHour.Properties.FieldName = "BenchmarkPerfomance";
            // 
            // vc_MinPer
            // 
            this.vc_MinPer.Name = "vc_MinPer";
            this.vc_MinPer.Properties.Caption = "Minimum pepsons";
            // 
            // vc_MaxPer
            // 
            this.vc_MaxPer.Name = "vc_MaxPer";
            this.vc_MaxPer.Properties.Caption = "Maximum persons";
            // 
            // UCWorldDetailVertical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vGrid);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldDetailVertical";
            this.Size = new System.Drawing.Size(542, 284);
            ((System.ComponentModel.ISupportInitialize)(this.vGrid)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repWorld;
        private DevExpress.Utils.ImageCollection m_images;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem ts_ViewMinMax;
        private System.Windows.Forms.ToolStripMenuItem ts_Refresh;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_World;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_AvailableWTH;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_CurrentlyAvailableBuffer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_BusinessVolumeHours;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_TargetedBusinessVolume;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_NetBusinessVolume;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_NetBusinessVolumeWithoutBuffer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_BenchmarkBusinessVolumePerHour;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_MinPer;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow vc_MaxPer;
    }
}
