namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCEditWgrToHwgr
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnHistory = new DevExpress.XtraEditors.SimpleButton();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.deBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.wgrLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.WgrLookUpCtrl();
            this.hwgrLookUpCtrl = new Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_HWGR = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_WGR = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_BeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.historyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_HWGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wgrLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwgrLookUpCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblCaption);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(404, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(404, 40);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Assign Wgr to Hwgr";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Appearance.Control.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Appearance.Control.Options.UseBorderColor = true;
            this.layoutControl1.Controls.Add(this.btnHistory);
            this.layoutControl1.Controls.Add(this.deEndTime);
            this.layoutControl1.Controls.Add(this.deBeginTime);
            this.layoutControl1.Controls.Add(this.wgrLookUpCtrl);
            this.layoutControl1.Controls.Add(this.hwgrLookUpCtrl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(404, 217);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::Baumax.ClientUI.Properties.Resources.view_histoty_16x16;
            this.btnHistory.Location = new System.Drawing.Point(352, 35);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(35, 24);
            this.btnHistory.StyleController = this.layoutControl1;
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = " ";
            this.btnHistory.ToolTip = "View history";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // deEndTime
            // 
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(208, 93);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "◊", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.deEndTime.Properties.HighlightHolidays = false;
            this.deEndTime.Properties.NullDate = new System.DateTime(2007, 8, 20, 17, 22, 42, 42);
            this.deEndTime.Properties.ShowWeekNumbers = true;
            this.deEndTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.deEndTime.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Time_Properties_ButtonClick);
            this.deEndTime.Size = new System.Drawing.Size(179, 20);
            this.deEndTime.StyleController = this.layoutControl1;
            this.deEndTime.TabIndex = 8;
            this.deEndTime.EditValueChanged += new System.EventHandler(this.deEndTime_EditValueChanged);
            // 
            // deBeginTime
            // 
            this.deBeginTime.EditValue = null;
            this.deBeginTime.Location = new System.Drawing.Point(9, 93);
            this.deBeginTime.Name = "deBeginTime";
            this.deBeginTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deBeginTime.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.deBeginTime.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.deBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deBeginTime.Properties.HighlightHolidays = false;
            this.deBeginTime.Properties.NullDate = new System.DateTime(2007, 8, 20, 17, 21, 35, 0);
            this.deBeginTime.Properties.ShowWeekNumbers = true;
            this.deBeginTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.deBeginTime.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Time_Properties_ButtonClick);
            this.deBeginTime.Size = new System.Drawing.Size(188, 20);
            this.deBeginTime.StyleController = this.layoutControl1;
            this.deBeginTime.TabIndex = 7;
            this.deBeginTime.EditValueChanged += new System.EventHandler(this.deBeginTime_EditValueChanged);
            // 
            // wgrLookUpCtrl
            // 
            this.wgrLookUpCtrl.CurrentEntity = null;
            this.wgrLookUpCtrl.CurrentId = ((long)(0));
            this.wgrLookUpCtrl.EntityList = null;
            this.wgrLookUpCtrl.Location = new System.Drawing.Point(65, 37);
            this.wgrLookUpCtrl.Name = "wgrLookUpCtrl";
            this.wgrLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.wgrLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.wgrLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.wgrLookUpCtrl.Properties.NullText = "";
            this.wgrLookUpCtrl.Size = new System.Drawing.Size(281, 20);
            this.wgrLookUpCtrl.StyleController = this.layoutControl1;
            this.wgrLookUpCtrl.TabIndex = 5;
            this.wgrLookUpCtrl.EditValueChanged += new System.EventHandler(this.wgrLookUpCtrl_EditValueChanged);
            // 
            // hwgrLookUpCtrl
            // 
            this.hwgrLookUpCtrl.CurrentEntity = null;
            this.hwgrLookUpCtrl.CurrentId = ((long)(0));
            this.hwgrLookUpCtrl.EntityList = null;
            this.hwgrLookUpCtrl.Location = new System.Drawing.Point(65, 6);
            this.hwgrLookUpCtrl.Name = "hwgrLookUpCtrl";
            this.hwgrLookUpCtrl.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.hwgrLookUpCtrl.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.hwgrLookUpCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.hwgrLookUpCtrl.Properties.NullText = "";
            this.hwgrLookUpCtrl.Size = new System.Drawing.Size(322, 20);
            this.hwgrLookUpCtrl.StyleController = this.layoutControl1;
            this.hwgrLookUpCtrl.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_HWGR,
            this.li_WGR,
            this.li_BeginDate,
            this.li_EndDate,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(404, 217);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // li_HWGR
            // 
            this.li_HWGR.Control = this.hwgrLookUpCtrl;
            this.li_HWGR.CustomizationFormText = "Hwgr";
            this.li_HWGR.Location = new System.Drawing.Point(0, 0);
            this.li_HWGR.Name = "li_HWGR";
            this.li_HWGR.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 17, 5, 5);
            this.li_HWGR.Size = new System.Drawing.Size(404, 31);
            this.li_HWGR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_HWGR.Text = "HWGR";
            this.li_HWGR.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_WGR
            // 
            this.li_WGR.Control = this.wgrLookUpCtrl;
            this.li_WGR.CustomizationFormText = "Wgr";
            this.li_WGR.Location = new System.Drawing.Point(0, 31);
            this.li_WGR.Name = "li_WGR";
            this.li_WGR.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 5, 5, 5);
            this.li_WGR.Size = new System.Drawing.Size(351, 31);
            this.li_WGR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_WGR.Text = "WGR";
            this.li_WGR.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_BeginDate
            // 
            this.li_BeginDate.Control = this.deBeginTime;
            this.li_BeginDate.CustomizationFormText = "Begin date";
            this.li_BeginDate.Location = new System.Drawing.Point(0, 62);
            this.li_BeginDate.Name = "li_BeginDate";
            this.li_BeginDate.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 5, 5, 5);
            this.li_BeginDate.Size = new System.Drawing.Size(202, 155);
            this.li_BeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_BeginDate.Text = "Begin date";
            this.li_BeginDate.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_BeginDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // li_EndDate
            // 
            this.li_EndDate.Control = this.deEndTime;
            this.li_EndDate.CustomizationFormText = "End date";
            this.li_EndDate.Location = new System.Drawing.Point(202, 62);
            this.li_EndDate.Name = "li_EndDate";
            this.li_EndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 17, 5, 5);
            this.li_EndDate.Size = new System.Drawing.Size(202, 155);
            this.li_EndDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_EndDate.Text = "End date";
            this.li_EndDate.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_EndDate.TextSize = new System.Drawing.Size(51, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnHistory;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(351, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 17, 3, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(53, 31);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // historyView
            // 
            this.historyView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.historyView.Name = "historyView";
            this.historyView.OptionsBehavior.Editable = false;
            this.historyView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.historyView.OptionsFilter.AllowFilterEditor = false;
            this.historyView.OptionsFilter.AllowMRUFilterList = false;
            this.historyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.historyView.OptionsView.ShowAutoFilterRow = true;
            this.historyView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.historyView.OptionsView.ShowGroupPanel = false;
            // 
            // gc_HWGR
            // 
            this.gc_HWGR.Caption = "HWGR";
            this.gc_HWGR.FieldName = "gc_HWGR";
            this.gc_HWGR.Name = "gc_HWGR";
            this.gc_HWGR.OptionsFilter.AllowFilter = false;
            this.gc_HWGR.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_HWGR.Visible = true;
            this.gc_HWGR.VisibleIndex = 0;
            // 
            // gc_BeginDate
            // 
            this.gc_BeginDate.Caption = "Begin date";
            this.gc_BeginDate.FieldName = "BeginTime";
            this.gc_BeginDate.Name = "gc_BeginDate";
            this.gc_BeginDate.OptionsFilter.AllowFilter = false;
            this.gc_BeginDate.Visible = true;
            this.gc_BeginDate.VisibleIndex = 1;
            // 
            // gc_EndDate
            // 
            this.gc_EndDate.Caption = "End date";
            this.gc_EndDate.FieldName = "EndTime";
            this.gc_EndDate.Name = "gc_EndDate";
            this.gc_EndDate.OptionsFilter.AllowFilter = false;
            this.gc_EndDate.Visible = true;
            this.gc_EndDate.VisibleIndex = 2;
            // 
            // UCEditWgrToHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCEditWgrToHwgr";
            this.Size = new System.Drawing.Size(404, 257);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wgrLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hwgrLookUpCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HWGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.DateEdit deBeginTime;
        private Baumax.ClientUI.FormEntities.Controls.WgrLookUpCtrl wgrLookUpCtrl;
        private Baumax.ClientUI.FormEntities.Controls.HwgrLookUpCtrl hwgrLookUpCtrl;
        private DevExpress.XtraLayout.LayoutControlItem li_HWGR;
        private DevExpress.XtraLayout.LayoutControlItem li_WGR;
        private DevExpress.XtraLayout.LayoutControlItem li_BeginDate;
        private DevExpress.XtraLayout.LayoutControlItem li_EndDate;
        private DevExpress.XtraGrid.Views.Grid.GridView historyView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_HWGR;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraEditors.SimpleButton btnHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
