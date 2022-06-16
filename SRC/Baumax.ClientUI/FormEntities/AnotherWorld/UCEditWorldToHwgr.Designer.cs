namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCEditWorldToHwgr
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
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.deBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.hwgrLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl();
            this.storeWorldLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl();
            this.btnHistory = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_HWGR = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_BeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblAssignHwgrToWorld = new DevExpress.XtraEditors.LabelControl();
            this.gc_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwgrLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_BeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Appearance.Control.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.Control.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.ControlDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.ControlDisabled.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.ControlDropDown.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.ControlDropDown.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.ControlDropDownHeader.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.ControlDropDownHeader.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.ControlFocused.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.ControlFocused.Options.UseBorderColor = true;
            this.layoutControl1.Controls.Add(this.deEndTime);
            this.layoutControl1.Controls.Add(this.deBeginTime);
            this.layoutControl1.Controls.Add(this.hwgrLookUpCtrl);
            this.layoutControl1.Controls.Add(this.storeWorldLookUpCtrl);
            this.layoutControl1.Controls.Add(this.btnHistory);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.ItemBorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(439, 175);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deEndTime
            // 
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(225, 93);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deEndTime.Properties.HighlightHolidays = false;
            this.deEndTime.Properties.ShowWeekNumbers = true;
            this.deEndTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.deEndTime.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Time_Properties_ButtonClick);
            this.deEndTime.Size = new System.Drawing.Size(209, 20);
            this.deEndTime.StyleController = this.layoutControl1;
            this.deEndTime.TabIndex = 12;
            this.deEndTime.DateTimeChanged += new System.EventHandler(this.deEndTime_DateTimeChanged);
            // 
            // deBeginTime
            // 
            this.deBeginTime.EditValue = null;
            this.deBeginTime.Location = new System.Drawing.Point(6, 93);
            this.deBeginTime.Name = "deBeginTime";
            this.deBeginTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deBeginTime.Properties.HighlightHolidays = false;
            this.deBeginTime.Properties.ShowWeekNumbers = true;
            this.deBeginTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.deBeginTime.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Time_Properties_ButtonClick);
            this.deBeginTime.Size = new System.Drawing.Size(208, 20);
            this.deBeginTime.StyleController = this.layoutControl1;
            this.deBeginTime.TabIndex = 11;
            this.deBeginTime.DateTimeChanged += new System.EventHandler(this.deBeginTime_DateTimeChanged);
            // 
            // hwgrLookUpCtrl
            // 
            this.hwgrLookUpCtrl.CurrentEntity = null;
            this.hwgrLookUpCtrl.CurrentId = ((long)(0));
            this.hwgrLookUpCtrl.EntityList = null;
            this.hwgrLookUpCtrl.Location = new System.Drawing.Point(65, 37);
            this.hwgrLookUpCtrl.Name = "hwgrLookUpCtrl";
            this.hwgrLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.hwgrLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.hwgrLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.hwgrLookUpCtrl.Properties.NullText = "";
            this.hwgrLookUpCtrl.Size = new System.Drawing.Size(316, 20);
            this.hwgrLookUpCtrl.StyleController = this.layoutControl1;
            this.hwgrLookUpCtrl.TabIndex = 9;
            this.hwgrLookUpCtrl.EditValueChanged += new System.EventHandler(this.hwgrLookUpCtrl_EditValueChanged);
            // 
            // storeWorldLookUpCtrl
            // 
            this.storeWorldLookUpCtrl.CurrentEntity = null;
            this.storeWorldLookUpCtrl.CurrentId = ((long)(0));
            this.storeWorldLookUpCtrl.EntityList = null;
            this.storeWorldLookUpCtrl.InitFirstValue = true;
            this.storeWorldLookUpCtrl.Location = new System.Drawing.Point(67, 6);
            this.storeWorldLookUpCtrl.Name = "storeWorldLookUpCtrl";
            this.storeWorldLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.storeWorldLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.storeWorldLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeWorldLookUpCtrl.Properties.NullText = "";
            this.storeWorldLookUpCtrl.Size = new System.Drawing.Size(355, 20);
            this.storeWorldLookUpCtrl.StyleController = this.layoutControl1;
            this.storeWorldLookUpCtrl.TabIndex = 8;
            this.storeWorldLookUpCtrl.WorldId = ((long)(0));
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::Baumax.ClientUI.Properties.Resources.view_histoty_16x16;
            this.btnHistory.Location = new System.Drawing.Point(387, 35);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(1);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(35, 24);
            this.btnHistory.StyleController = this.layoutControl1;
            this.btnHistory.TabIndex = 10;
            this.btnHistory.Text = " ";
            this.btnHistory.ToolTip = "View HWGR history";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceTabPage.Header.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceTabPage.Header.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Options.UseBorderColor = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_World,
            this.li_HWGR,
            this.layoutControlItem1,
            this.lc_BeginDate,
            this.lc_EndDate});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(439, 175);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_World
            // 
            this.li_World.Control = this.storeWorldLookUpCtrl;
            this.li_World.CustomizationFormText = "World";
            this.li_World.Location = new System.Drawing.Point(0, 0);
            this.li_World.Name = "li_World";
            this.li_World.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 17, 5, 5);
            this.li_World.Size = new System.Drawing.Size(439, 31);
            this.li_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_World.Text = "World";
            this.li_World.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_HWGR
            // 
            this.li_HWGR.Control = this.hwgrLookUpCtrl;
            this.li_HWGR.CustomizationFormText = "Hwgr";
            this.li_HWGR.Location = new System.Drawing.Point(0, 31);
            this.li_HWGR.Name = "li_HWGR";
            this.li_HWGR.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 5, 5, 5);
            this.li_HWGR.Size = new System.Drawing.Size(386, 31);
            this.li_HWGR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_HWGR.Text = "HWGR";
            this.li_HWGR.TextSize = new System.Drawing.Size(51, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnHistory;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(386, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 12, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(53, 31);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 5, 3, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lc_BeginDate
            // 
            this.lc_BeginDate.Control = this.deBeginTime;
            this.lc_BeginDate.CustomizationFormText = "Begin date";
            this.lc_BeginDate.Location = new System.Drawing.Point(0, 62);
            this.lc_BeginDate.Name = "lc_BeginDate";
            this.lc_BeginDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_BeginDate.Size = new System.Drawing.Size(219, 113);
            this.lc_BeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_BeginDate.Text = "Begin date";
            this.lc_BeginDate.TextLocation = DevExpress.Utils.Locations.Top;
            this.lc_BeginDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // lc_EndDate
            // 
            this.lc_EndDate.Control = this.deEndTime;
            this.lc_EndDate.CustomizationFormText = "End date";
            this.lc_EndDate.Location = new System.Drawing.Point(219, 62);
            this.lc_EndDate.Name = "lc_EndDate";
            this.lc_EndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_EndDate.Size = new System.Drawing.Size(220, 113);
            this.lc_EndDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_EndDate.Text = "End date";
            this.lc_EndDate.TextLocation = DevExpress.Utils.Locations.Top;
            this.lc_EndDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblAssignHwgrToWorld);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(439, 40);
            this.panelControl1.TabIndex = 1;
            // 
            // lblAssignHwgrToWorld
            // 
            this.lblAssignHwgrToWorld.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssignHwgrToWorld.Appearance.Options.UseFont = true;
            this.lblAssignHwgrToWorld.Appearance.Options.UseTextOptions = true;
            this.lblAssignHwgrToWorld.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAssignHwgrToWorld.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAssignHwgrToWorld.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAssignHwgrToWorld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAssignHwgrToWorld.Location = new System.Drawing.Point(0, 0);
            this.lblAssignHwgrToWorld.Name = "lblAssignHwgrToWorld";
            this.lblAssignHwgrToWorld.Size = new System.Drawing.Size(439, 40);
            this.lblAssignHwgrToWorld.TabIndex = 0;
            this.lblAssignHwgrToWorld.Text = "Edit assign Hwgr to world";
            // 
            // gc_World
            // 
            this.gc_World.Caption = "World";
            this.gc_World.FieldName = "gc_World";
            this.gc_World.Name = "gc_World";
            this.gc_World.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_World.Visible = true;
            this.gc_World.VisibleIndex = 0;
            // 
            // gc_BeginDate
            // 
            this.gc_BeginDate.Caption = "Begin date";
            this.gc_BeginDate.DisplayFormat.FormatString = "d";
            this.gc_BeginDate.FieldName = "DeginTime";
            this.gc_BeginDate.Name = "gc_BeginDate";
            this.gc_BeginDate.Visible = true;
            this.gc_BeginDate.VisibleIndex = 1;
            // 
            // gc_EndDate
            // 
            this.gc_EndDate.Caption = "End date";
            this.gc_EndDate.DisplayFormat.FormatString = "d";
            this.gc_EndDate.FieldName = "EndTime";
            this.gc_EndDate.Name = "gc_EndDate";
            this.gc_EndDate.Visible = true;
            this.gc_EndDate.VisibleIndex = 2;
            // 
            // UCEditWorldToHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCEditWorldToHwgr";
            this.Size = new System.Drawing.Size(439, 215);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwgrLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeWorldLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_BeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblAssignHwgrToWorld;
        private Baumax.ClientUI.FormEntities.Controls.StoreWorldLookUpCtrl storeWorldLookUpCtrl;
        private DevExpress.XtraLayout.LayoutControlItem li_World;
        private Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl hwgrLookUpCtrl;
        private DevExpress.XtraLayout.LayoutControlItem li_HWGR;
        private DevExpress.XtraEditors.SimpleButton btnHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gc_World;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.DateEdit deBeginTime;
        private DevExpress.XtraLayout.LayoutControlItem lc_BeginDate;
        private DevExpress.XtraLayout.LayoutControlItem lc_EndDate;
    }
}
