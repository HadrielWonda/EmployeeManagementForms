namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormBenchmark
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.seBenchmark = new DevExpress.XtraEditors.SpinEdit();
            this.seYear = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpWorlds = new DevExpress.XtraEditors.LookUpEdit();
            this.teStore = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_Store = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_Year = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_Benchmark = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl_DefineBenchmarks = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seBenchmark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Benchmark)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_DefineBenchmarks);
            this.panelTop.Size = new System.Drawing.Size(377, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Size = new System.Drawing.Size(377, 149);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1209, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 183);
            this.panelBottom.Size = new System.Drawing.Size(377, 40);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.seBenchmark);
            this.layoutControl1.Controls.Add(this.seYear);
            this.layoutControl1.Controls.Add(this.lookUpWorlds);
            this.layoutControl1.Controls.Add(this.teStore);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.DrawItemBorders = true;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(377, 149);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // seBenchmark
            // 
            this.seBenchmark.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seBenchmark.Location = new System.Drawing.Point(194, 94);
            this.seBenchmark.Name = "seBenchmark";
            this.seBenchmark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seBenchmark.Properties.Mask.EditMask = "f";
            this.seBenchmark.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.seBenchmark.Size = new System.Drawing.Size(177, 20);
            this.seBenchmark.StyleController = this.layoutControl1;
            this.seBenchmark.TabIndex = 8;
            // 
            // seYear
            // 
            this.seYear.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seYear.Location = new System.Drawing.Point(7, 94);
            this.seYear.Name = "seYear";
            this.seYear.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.seYear.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.seYear.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.seYear.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.seYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seYear.Properties.Mask.EditMask = "0000";
            this.seYear.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.seYear.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seYear.Size = new System.Drawing.Size(176, 20);
            this.seYear.StyleController = this.layoutControl1;
            this.seYear.TabIndex = 6;
            // 
            // lookUpWorlds
            // 
            this.lookUpWorlds.Location = new System.Drawing.Point(64, 38);
            this.lookUpWorlds.Name = "lookUpWorlds";
            this.lookUpWorlds.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lookUpWorlds.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lookUpWorlds.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.lookUpWorlds.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.lookUpWorlds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpWorlds.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorldName", "WorldName", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpWorlds.Properties.DisplayMember = "WorldName";
            this.lookUpWorlds.Properties.NullText = "";
            this.lookUpWorlds.Properties.ValueMember = "ID";
            this.lookUpWorlds.Size = new System.Drawing.Size(307, 20);
            this.lookUpWorlds.StyleController = this.layoutControl1;
            this.lookUpWorlds.TabIndex = 5;
            // 
            // teStore
            // 
            this.teStore.Enabled = false;
            this.teStore.Location = new System.Drawing.Point(64, 7);
            this.teStore.Name = "teStore";
            this.teStore.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.teStore.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceDisabled.Options.UseFont = true;
            this.teStore.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teStore.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.teStore.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.teStore.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.teStore.Properties.ReadOnly = true;
            this.teStore.Size = new System.Drawing.Size(307, 20);
            this.teStore.StyleController = this.layoutControl1;
            this.teStore.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowHide = false;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_Store,
            this.li_World,
            this.li_Year,
            this.li_Benchmark});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(377, 149);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_Store
            // 
            this.li_Store.Control = this.teStore;
            this.li_Store.CustomizationFormText = "Store";
            this.li_Store.Location = new System.Drawing.Point(0, 0);
            this.li_Store.Name = "li_Store";
            this.li_Store.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Store.Size = new System.Drawing.Size(375, 31);
            this.li_Store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Store.Text = "Store";
            this.li_Store.TextSize = new System.Drawing.Size(52, 20);
            // 
            // li_World
            // 
            this.li_World.Control = this.lookUpWorlds;
            this.li_World.CustomizationFormText = "World";
            this.li_World.Location = new System.Drawing.Point(0, 31);
            this.li_World.Name = "li_World";
            this.li_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_World.Size = new System.Drawing.Size(375, 31);
            this.li_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_World.Text = "World";
            this.li_World.TextSize = new System.Drawing.Size(52, 20);
            // 
            // li_Year
            // 
            this.li_Year.Control = this.seYear;
            this.li_Year.CustomizationFormText = "Year";
            this.li_Year.Location = new System.Drawing.Point(0, 62);
            this.li_Year.Name = "li_Year";
            this.li_Year.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Year.Size = new System.Drawing.Size(187, 85);
            this.li_Year.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Year.Text = "Year";
            this.li_Year.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_Year.TextSize = new System.Drawing.Size(52, 20);
            // 
            // li_Benchmark
            // 
            this.li_Benchmark.Control = this.seBenchmark;
            this.li_Benchmark.CustomizationFormText = "Benchmark";
            this.li_Benchmark.Location = new System.Drawing.Point(187, 62);
            this.li_Benchmark.Name = "li_Benchmark";
            this.li_Benchmark.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Benchmark.Size = new System.Drawing.Size(188, 85);
            this.li_Benchmark.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Benchmark.Text = "Benchmark";
            this.li_Benchmark.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_Benchmark.TextSize = new System.Drawing.Size(52, 20);
            // 
            // lbl_DefineBenchmarks
            // 
            this.lbl_DefineBenchmarks.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DefineBenchmarks.Appearance.Options.UseFont = true;
            this.lbl_DefineBenchmarks.Appearance.Options.UseTextOptions = true;
            this.lbl_DefineBenchmarks.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_DefineBenchmarks.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_DefineBenchmarks.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DefineBenchmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DefineBenchmarks.Location = new System.Drawing.Point(2, 2);
            this.lbl_DefineBenchmarks.Name = "lbl_DefineBenchmarks";
            this.lbl_DefineBenchmarks.Size = new System.Drawing.Size(373, 30);
            this.lbl_DefineBenchmarks.TabIndex = 0;
            this.lbl_DefineBenchmarks.Text = "Define Benchmark";
            // 
            // FormBenchmark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 223);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormBenchmark";
            this.Text = "    ";
            this.Controls.SetChildIndex(this.panelTop, 0);
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seBenchmark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Benchmark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit seYear;
        private DevExpress.XtraEditors.LookUpEdit lookUpWorlds;
        private DevExpress.XtraEditors.TextEdit teStore;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem li_Store;
        private DevExpress.XtraLayout.LayoutControlItem li_World;
        private DevExpress.XtraLayout.LayoutControlItem li_Year;
        private DevExpress.XtraEditors.LabelControl lbl_DefineBenchmarks;
        private DevExpress.XtraEditors.SpinEdit seBenchmark;
        private DevExpress.XtraLayout.LayoutControlItem li_Benchmark;

    }
}