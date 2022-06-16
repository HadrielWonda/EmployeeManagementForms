namespace Baumax.ClientUI.FormEntities.Country
{
    partial class UCCountryProperties
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.seCriticalTime = new DevExpress.XtraEditors.SpinEdit();
            this.seWarningTime = new DevExpress.XtraEditors.SpinEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_MaxTimeRangeRecording = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_CriticalDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_WarningDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCriticalTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWarningTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_MaxTimeRangeRecording)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_CriticalDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WarningDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.seCriticalTime);
            this.layoutControl1.Controls.Add(this.seWarningTime);
            this.layoutControl1.Controls.Add(this.btn_Save);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(580, 198);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // seCriticalTime
            // 
            this.seCriticalTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCriticalTime.Location = new System.Drawing.Point(10, 109);
            this.seCriticalTime.Name = "seCriticalTime";
            this.seCriticalTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seCriticalTime.Properties.IsFloatValue = false;
            this.seCriticalTime.Properties.Mask.EditMask = "d";
            this.seCriticalTime.Properties.Mask.SaveLiteral = false;
            this.seCriticalTime.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.seCriticalTime.Size = new System.Drawing.Size(561, 20);
            this.seCriticalTime.StyleController = this.layoutControl1;
            this.seCriticalTime.TabIndex = 6;
            this.seCriticalTime.ToolTip = "Time which that timerecording possible (0-255)";
            // 
            // seWarningTime
            // 
            this.seWarningTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seWarningTime.Location = new System.Drawing.Point(10, 53);
            this.seWarningTime.Name = "seWarningTime";
            this.seWarningTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seWarningTime.Properties.IsFloatValue = false;
            this.seWarningTime.Properties.Mask.EditMask = "d";
            this.seWarningTime.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.seWarningTime.Size = new System.Drawing.Size(561, 20);
            this.seWarningTime.StyleController = this.layoutControl1;
            this.seWarningTime.TabIndex = 5;
            this.seWarningTime.ToolTip = "Time a warning (0-255)";
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::Baumax.ClientUI.Properties.Resources.data_disk;
            this.btn_Save.Location = new System.Drawing.Point(414, 140);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(157, 32);
            this.btn_Save.StyleController = this.layoutControl1;
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowCustomizeChildren = false;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_MaxTimeRangeRecording});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.ShowInCustomizationForm = false;
            this.layoutControlGroup1.Size = new System.Drawing.Size(580, 198);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_MaxTimeRangeRecording
            // 
            this.li_MaxTimeRangeRecording.CustomizationFormText = "Maximum time-range recording";
            this.li_MaxTimeRangeRecording.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_CriticalDays,
            this.li_WarningDays,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.li_MaxTimeRangeRecording.Location = new System.Drawing.Point(0, 0);
            this.li_MaxTimeRangeRecording.Name = "li_MaxTimeRangeRecording";
            this.li_MaxTimeRangeRecording.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_MaxTimeRangeRecording.Size = new System.Drawing.Size(578, 196);
            this.li_MaxTimeRangeRecording.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.li_MaxTimeRangeRecording.Text = "Maximum time-range recording";
            // 
            // li_CriticalDays
            // 
            this.li_CriticalDays.Control = this.seCriticalTime;
            this.li_CriticalDays.CustomizationFormText = "Critical";
            this.li_CriticalDays.Location = new System.Drawing.Point(0, 56);
            this.li_CriticalDays.Name = "li_CriticalDays";
            this.li_CriticalDays.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_CriticalDays.Size = new System.Drawing.Size(572, 56);
            this.li_CriticalDays.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_CriticalDays.Text = "Critical";
            this.li_CriticalDays.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_CriticalDays.TextSize = new System.Drawing.Size(40, 20);
            // 
            // li_WarningDays
            // 
            this.li_WarningDays.Control = this.seWarningTime;
            this.li_WarningDays.CustomizationFormText = "Warnign";
            this.li_WarningDays.Location = new System.Drawing.Point(0, 0);
            this.li_WarningDays.Name = "li_WarningDays";
            this.li_WarningDays.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_WarningDays.Size = new System.Drawing.Size(572, 56);
            this.li_WarningDays.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_WarningDays.Text = "Warnign";
            this.li_WarningDays.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_WarningDays.TextSize = new System.Drawing.Size(40, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Save;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(404, 112);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(168, 60);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 112);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(404, 60);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UCCountryProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCCountryProperties";
            this.Size = new System.Drawing.Size(580, 198);
            this.Resize += new System.EventHandler(this.UCCountryProperties_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seCriticalTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seWarningTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_MaxTimeRangeRecording)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_CriticalDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WarningDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit seCriticalTime;
        private DevExpress.XtraEditors.SpinEdit seWarningTime;
        private DevExpress.XtraLayout.LayoutControlGroup li_MaxTimeRangeRecording;
        private DevExpress.XtraLayout.LayoutControlItem li_CriticalDays;
        private DevExpress.XtraLayout.LayoutControlItem li_WarningDays;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
