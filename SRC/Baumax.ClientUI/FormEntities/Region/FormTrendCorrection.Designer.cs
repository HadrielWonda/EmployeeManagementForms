namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormTrendCorrection
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
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.ceValue = new DevExpress.XtraEditors.SpinEdit();
            this.deEndDate = new DevExpress.XtraEditors.DateEdit();
            this.deStartDate = new DevExpress.XtraEditors.DateEdit();
            this.lookUpWorlds = new DevExpress.XtraEditors.LookUpEdit();
            this.teStore = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_Store = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_BeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_TrendCorrection = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_Name = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl_DefineTrendCorrection = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_TrendCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Name)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_DefineTrendCorrection);
            this.panelTop.Size = new System.Drawing.Size(466, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.layoutControl1);
            this.panelClient.Size = new System.Drawing.Size(466, 204);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1546, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 238);
            this.panelBottom.Size = new System.Drawing.Size(466, 40);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.teName);
            this.layoutControl1.Controls.Add(this.ceValue);
            this.layoutControl1.Controls.Add(this.deEndDate);
            this.layoutControl1.Controls.Add(this.deStartDate);
            this.layoutControl1.Controls.Add(this.lookUpWorlds);
            this.layoutControl1.Controls.Add(this.teStore);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.DrawItemBorders = true;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(462, 200);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(90, 69);
            this.teName.Name = "teName";
            this.teName.Properties.MaxLength = 256;
            this.teName.Size = new System.Drawing.Size(366, 20);
            this.teName.StyleController = this.layoutControl1;
            this.teName.TabIndex = 10;
            // 
            // ceValue
            // 
            this.ceValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ceValue.Location = new System.Drawing.Point(7, 156);
            this.ceValue.Name = "ceValue";
            this.ceValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ceValue.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ceValue.Properties.Mask.EditMask = "f";
            this.ceValue.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ceValue.Size = new System.Drawing.Size(449, 20);
            this.ceValue.StyleController = this.layoutControl1;
            this.ceValue.TabIndex = 9;
            this.ceValue.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ceValue_EditValueChanging);
            // 
            // deEndDate
            // 
            this.deEndDate.EditValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deEndDate.Location = new System.Drawing.Point(320, 100);
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deEndDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.deEndDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.deEndDate.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.deEndDate.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndDate.Properties.MaxValue = new System.DateTime(2079, 1, 1, 0, 0, 0, 0);
            this.deEndDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndDate.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            this.deEndDate.Size = new System.Drawing.Size(136, 20);
            this.deEndDate.StyleController = this.layoutControl1;
            this.deEndDate.TabIndex = 7;
            this.deEndDate.EditValueChanged += new System.EventHandler(this.deEndDate_EditValueChanged);
            // 
            // deStartDate
            // 
            this.deStartDate.EditValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deStartDate.Location = new System.Drawing.Point(90, 100);
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deStartDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.deStartDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.deStartDate.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.deStartDate.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.deStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Properties.MaxValue = new System.DateTime(2079, 1, 1, 0, 0, 0, 0);
            this.deStartDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.deStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStartDate.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            this.deStartDate.Size = new System.Drawing.Size(136, 20);
            this.deStartDate.StyleController = this.layoutControl1;
            this.deStartDate.TabIndex = 6;
            // 
            // lookUpWorlds
            // 
            this.lookUpWorlds.Location = new System.Drawing.Point(90, 38);
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
            this.lookUpWorlds.Size = new System.Drawing.Size(366, 20);
            this.lookUpWorlds.StyleController = this.layoutControl1;
            this.lookUpWorlds.TabIndex = 5;
            // 
            // teStore
            // 
            this.teStore.Enabled = false;
            this.teStore.Location = new System.Drawing.Point(90, 7);
            this.teStore.Name = "teStore";
            this.teStore.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teStore.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.teStore.Properties.ReadOnly = true;
            this.teStore.Size = new System.Drawing.Size(366, 20);
            this.teStore.StyleController = this.layoutControl1;
            this.teStore.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_Store,
            this.li_World,
            this.li_BeginDate,
            this.li_EndDate,
            this.li_TrendCorrection,
            this.li_Name});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.ShowInCustomizationForm = false;
            this.layoutControlGroup1.Size = new System.Drawing.Size(462, 200);
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
            this.li_Store.ShowInCustomizationForm = false;
            this.li_Store.Size = new System.Drawing.Size(460, 31);
            this.li_Store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Store.Text = "Store";
            this.li_Store.TextSize = new System.Drawing.Size(78, 20);
            // 
            // li_World
            // 
            this.li_World.Control = this.lookUpWorlds;
            this.li_World.CustomizationFormText = "World";
            this.li_World.Location = new System.Drawing.Point(0, 31);
            this.li_World.Name = "li_World";
            this.li_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_World.ShowInCustomizationForm = false;
            this.li_World.Size = new System.Drawing.Size(460, 31);
            this.li_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_World.Text = "World";
            this.li_World.TextSize = new System.Drawing.Size(78, 20);
            // 
            // li_BeginDate
            // 
            this.li_BeginDate.Control = this.deStartDate;
            this.li_BeginDate.CustomizationFormText = "Begin Date";
            this.li_BeginDate.Location = new System.Drawing.Point(0, 93);
            this.li_BeginDate.Name = "li_BeginDate";
            this.li_BeginDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_BeginDate.Size = new System.Drawing.Size(230, 31);
            this.li_BeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_BeginDate.Text = "Start Date";
            this.li_BeginDate.TextSize = new System.Drawing.Size(78, 20);
            // 
            // li_EndDate
            // 
            this.li_EndDate.Control = this.deEndDate;
            this.li_EndDate.CustomizationFormText = "End Date";
            this.li_EndDate.Location = new System.Drawing.Point(230, 93);
            this.li_EndDate.Name = "li_EndDate";
            this.li_EndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_EndDate.Size = new System.Drawing.Size(230, 31);
            this.li_EndDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_EndDate.Text = "End Date";
            this.li_EndDate.TextSize = new System.Drawing.Size(78, 20);
            // 
            // li_TrendCorrection
            // 
            this.li_TrendCorrection.Control = this.ceValue;
            this.li_TrendCorrection.CustomizationFormText = "TrendCorrection";
            this.li_TrendCorrection.Location = new System.Drawing.Point(0, 124);
            this.li_TrendCorrection.Name = "li_TrendCorrection";
            this.li_TrendCorrection.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_TrendCorrection.ShowInCustomizationForm = false;
            this.li_TrendCorrection.Size = new System.Drawing.Size(460, 74);
            this.li_TrendCorrection.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_TrendCorrection.Text = "TrendCorrection";
            this.li_TrendCorrection.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_TrendCorrection.TextSize = new System.Drawing.Size(78, 20);
            // 
            // li_Name
            // 
            this.li_Name.Control = this.teName;
            this.li_Name.CustomizationFormText = "Name";
            this.li_Name.Location = new System.Drawing.Point(0, 62);
            this.li_Name.Name = "li_Name";
            this.li_Name.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_Name.Size = new System.Drawing.Size(460, 31);
            this.li_Name.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_Name.Text = "Name";
            this.li_Name.TextSize = new System.Drawing.Size(78, 20);
            // 
            // lbl_DefineTrendCorrection
            // 
            this.lbl_DefineTrendCorrection.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DefineTrendCorrection.Appearance.Options.UseFont = true;
            this.lbl_DefineTrendCorrection.Appearance.Options.UseTextOptions = true;
            this.lbl_DefineTrendCorrection.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_DefineTrendCorrection.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_DefineTrendCorrection.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DefineTrendCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DefineTrendCorrection.Location = new System.Drawing.Point(2, 2);
            this.lbl_DefineTrendCorrection.Name = "lbl_DefineTrendCorrection";
            this.lbl_DefineTrendCorrection.Size = new System.Drawing.Size(462, 30);
            this.lbl_DefineTrendCorrection.TabIndex = 0;
            this.lbl_DefineTrendCorrection.Text = "Define trend correction";
            // 
            // FormTrendCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 278);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormTrendCorrection";
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_TrendCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_Name)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_DefineTrendCorrection;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit deEndDate;
        private DevExpress.XtraEditors.DateEdit deStartDate;
        private DevExpress.XtraEditors.LookUpEdit lookUpWorlds;
        private DevExpress.XtraEditors.TextEdit teStore;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem li_Store;
        private DevExpress.XtraLayout.LayoutControlItem li_World;
        private DevExpress.XtraLayout.LayoutControlItem li_BeginDate;
        private DevExpress.XtraLayout.LayoutControlItem li_EndDate;
        private DevExpress.XtraEditors.SpinEdit ceValue;
        private DevExpress.XtraLayout.LayoutControlItem li_TrendCorrection;
		private DevExpress.XtraEditors.TextEdit teName;
		private DevExpress.XtraLayout.LayoutControlItem li_Name;
    }
}