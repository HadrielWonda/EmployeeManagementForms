namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCWorldMinMaxEntity
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lbWorldName = new DevExpress.XtraEditors.LabelControl();
            this.lbSpan = new DevExpress.XtraEditors.LabelControl();
            this.lbl_World = new DevExpress.XtraEditors.LabelControl();
            this.edMaximum = new DevExpress.XtraEditors.SpinEdit();
            this.edMinimum = new DevExpress.XtraEditors.SpinEdit();
            this.edYear = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lc_Year = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_MinPer = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_MaxPer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edMaximum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMinimum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_MinPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_MaxPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomizationMenu = false;
            this.layoutControl.Controls.Add(this.lbWorldName);
            this.layoutControl.Controls.Add(this.lbSpan);
            this.layoutControl.Controls.Add(this.lbl_World);
            this.layoutControl.Controls.Add(this.edMaximum);
            this.layoutControl.Controls.Add(this.edMinimum);
            this.layoutControl.Controls.Add(this.edYear);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(290, 125);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lbWorldName
            // 
            this.lbWorldName.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbWorldName.Appearance.Options.UseFont = true;
            this.lbWorldName.Location = new System.Drawing.Point(69, 6);
            this.lbWorldName.Name = "lbWorldName";
            this.lbWorldName.Size = new System.Drawing.Size(36, 13);
            this.lbWorldName.StyleController = this.layoutControl;
            this.lbWorldName.TabIndex = 9;
            this.lbWorldName.Text = "Admin";
            // 
            // lbSpan
            // 
            this.lbSpan.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbSpan.Appearance.Options.UseFont = true;
            this.lbSpan.Location = new System.Drawing.Point(55, 6);
            this.lbSpan.Name = "lbSpan";
            this.lbSpan.Size = new System.Drawing.Size(3, 13);
            this.lbSpan.StyleController = this.layoutControl;
            this.lbSpan.TabIndex = 8;
            this.lbSpan.Text = ":";
            // 
            // lbl_World
            // 
            this.lbl_World.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_World.Appearance.Options.UseFont = true;
            this.lbl_World.Location = new System.Drawing.Point(11, 6);
            this.lbl_World.Name = "lbl_World";
            this.lbl_World.Size = new System.Drawing.Size(33, 13);
            this.lbl_World.StyleController = this.layoutControl;
            this.lbl_World.TabIndex = 7;
            this.lbl_World.Text = "World";
            // 
            // edMaximum
            // 
            this.edMaximum.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.edMaximum.Location = new System.Drawing.Point(60, 92);
            this.edMaximum.Name = "edMaximum";
            this.edMaximum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edMaximum.Properties.IsFloatValue = false;
            this.edMaximum.Properties.Mask.EditMask = "d";
            this.edMaximum.Properties.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edMaximum.Size = new System.Drawing.Size(215, 20);
            this.edMaximum.StyleController = this.layoutControl;
            this.edMaximum.TabIndex = 6;
            this.edMaximum.ToolTip = "(0 - 500)";
            // 
            // edMinimum
            // 
            this.edMinimum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edMinimum.Location = new System.Drawing.Point(60, 61);
            this.edMinimum.Name = "edMinimum";
            this.edMinimum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edMinimum.Properties.IsFloatValue = false;
            this.edMinimum.Properties.Mask.EditMask = "f0";
            this.edMinimum.Properties.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edMinimum.Size = new System.Drawing.Size(215, 20);
            this.edMinimum.StyleController = this.layoutControl;
            this.edMinimum.TabIndex = 5;
            this.edMinimum.ToolTip = "(0 - 500)";
            // 
            // edYear
            // 
            this.edYear.EditValue = new decimal(new int[] {
            2007,
            0,
            0,
            0});
            this.edYear.Location = new System.Drawing.Point(60, 30);
            this.edYear.Name = "edYear";
            this.edYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edYear.Properties.Mask.EditMask = "f0";
            this.edYear.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.edYear.Properties.MinValue = new decimal(new int[] {
            1901,
            0,
            0,
            0});
            this.edYear.Size = new System.Drawing.Size(215, 20);
            this.edYear.StyleController = this.layoutControl;
            this.edYear.TabIndex = 4;
            this.edYear.ToolTip = "(1901 - 2079)";
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "layoutControlGroup";
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lc_Year,
            this.lc_MinPer,
            this.lc_MaxPer,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Size = new System.Drawing.Size(290, 125);
            this.layoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Text = "layoutControlGroup";
            this.layoutControlGroup.TextVisible = false;
            // 
            // lc_Year
            // 
            this.lc_Year.Control = this.edYear;
            this.lc_Year.CustomizationFormText = "lc_";
            this.lc_Year.Location = new System.Drawing.Point(0, 24);
            this.lc_Year.Name = "lc_Year";
            this.lc_Year.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 15, 5, 5);
            this.lc_Year.Size = new System.Drawing.Size(290, 31);
            this.lc_Year.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_Year.Text = "Year";
            this.lc_Year.TextSize = new System.Drawing.Size(44, 20);
            // 
            // lc_MinPer
            // 
            this.lc_MinPer.Control = this.edMinimum;
            this.lc_MinPer.CustomizationFormText = "layoutControlItem2";
            this.lc_MinPer.Location = new System.Drawing.Point(0, 55);
            this.lc_MinPer.Name = "lc_MinPer";
            this.lc_MinPer.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 15, 5, 5);
            this.lc_MinPer.Size = new System.Drawing.Size(290, 31);
            this.lc_MinPer.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_MinPer.Text = "Minimum";
            this.lc_MinPer.TextSize = new System.Drawing.Size(44, 20);
            // 
            // lc_MaxPer
            // 
            this.lc_MaxPer.Control = this.edMaximum;
            this.lc_MaxPer.CustomizationFormText = "layoutControlItem3";
            this.lc_MaxPer.Location = new System.Drawing.Point(0, 86);
            this.lc_MaxPer.Name = "lc_MaxPer";
            this.lc_MaxPer.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 15, 5, 5);
            this.lc_MaxPer.Size = new System.Drawing.Size(290, 39);
            this.lc_MaxPer.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_MaxPer.Text = "Maximum";
            this.lc_MaxPer.TextSize = new System.Drawing.Size(44, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lbl_World;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(49, 24);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lbSpan;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(49, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(14, 24);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lbWorldName;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(63, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(227, 24);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // UCWorldMinMaxEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWorldMinMaxEntity";
            this.Size = new System.Drawing.Size(290, 125);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edMaximum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMinimum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_MinPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_MaxPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.SpinEdit edMaximum;
        private DevExpress.XtraEditors.SpinEdit edMinimum;
        private DevExpress.XtraEditors.SpinEdit edYear;
        private DevExpress.XtraLayout.LayoutControlItem lc_Year;
        private DevExpress.XtraLayout.LayoutControlItem lc_MinPer;
        private DevExpress.XtraLayout.LayoutControlItem lc_MaxPer;
        private DevExpress.XtraEditors.LabelControl lbWorldName;
        private DevExpress.XtraEditors.LabelControl lbSpan;
        private DevExpress.XtraEditors.LabelControl lbl_World;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
