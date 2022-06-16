namespace Baumax.ClientUI.Printout
{
	partial class FormPrintTimePlanning
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
            this.rdo_DaylyView = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lb_StoreName = new DevExpress.XtraEditors.LabelControl();
            this.rdo_World = new DevExpress.XtraEditors.CheckEdit();
            this.rdo_AllWorlds = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.de_EndDate = new DevExpress.XtraEditors.DateEdit();
            this.chk_HideReportSums = new DevExpress.XtraEditors.CheckEdit();
            this.chk_ManualFillingOnly = new DevExpress.XtraEditors.CheckEdit();
            this.rdo_WeeklyView = new DevExpress.XtraEditors.CheckEdit();
            this.de_StartDate = new DevExpress.XtraEditors.DateEdit();
            this.chk_AddManualFilling = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_AdditionalManualFilling = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_ManualFillOnly = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_HideSums = new DevExpress.XtraLayout.LayoutControlItem();
            this.lg_ViewType = new DevExpress.XtraLayout.LayoutControlGroup();
            this.li_WeeklyView = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_DailyView = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_AllWorlds = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_OneWorld = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_StartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_ToDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_printButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_cancelButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_buttonsFiller = new DevExpress.XtraLayout.EmptySpaceItem();
            this.li_HR = new DevExpress.XtraLayout.EmptySpaceItem();
            this.li_StoreName = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DaylyView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_World.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_AllWorlds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_EndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_EndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_HideReportSums.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ManualFillingOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_WeeklyView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_StartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_StartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_AddManualFilling.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_AdditionalManualFilling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_ManualFillOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HideSums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_ViewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WeeklyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_DailyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_AllWorlds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_OneWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_printButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_buttonsFiller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_StoreName)).BeginInit();
            this.SuspendLayout();
            // 
            // rdo_DaylyView
            // 
            this.rdo_DaylyView.Location = new System.Drawing.Point(194, 52);
            this.rdo_DaylyView.Name = "rdo_DaylyView";
            this.rdo_DaylyView.Properties.Caption = "Daily";
            this.rdo_DaylyView.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_DaylyView.Properties.RadioGroupIndex = 1;
            this.rdo_DaylyView.Size = new System.Drawing.Size(175, 19);
            this.rdo_DaylyView.StyleController = this.layoutControl;
            this.rdo_DaylyView.TabIndex = 1;
            this.rdo_DaylyView.TabStop = false;
            this.rdo_DaylyView.CheckedChanged += new System.EventHandler(this.ViewTypeChanged);
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lb_StoreName);
            this.layoutControl.Controls.Add(this.rdo_World);
            this.layoutControl.Controls.Add(this.rdo_AllWorlds);
            this.layoutControl.Controls.Add(this.btn_Close);
            this.layoutControl.Controls.Add(this.btn_Print);
            this.layoutControl.Controls.Add(this.de_EndDate);
            this.layoutControl.Controls.Add(this.chk_HideReportSums);
            this.layoutControl.Controls.Add(this.chk_ManualFillingOnly);
            this.layoutControl.Controls.Add(this.rdo_WeeklyView);
            this.layoutControl.Controls.Add(this.de_StartDate);
            this.layoutControl.Controls.Add(this.chk_AddManualFilling);
            this.layoutControl.Controls.Add(this.rdo_DaylyView);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroupRoot;
            this.layoutControl.Size = new System.Drawing.Size(378, 274);
            this.layoutControl.TabIndex = 6;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lb_StoreName
            // 
            this.lb_StoreName.Location = new System.Drawing.Point(43, 7);
            this.lb_StoreName.Name = "lb_StoreName";
            this.lb_StoreName.Size = new System.Drawing.Size(329, 13);
            this.lb_StoreName.StyleController = this.layoutControl;
            this.lb_StoreName.TabIndex = 9;
            // 
            // rdo_World
            // 
            this.rdo_World.EditValue = true;
            this.rdo_World.Location = new System.Drawing.Point(194, 82);
            this.rdo_World.Name = "rdo_World";
            this.rdo_World.Properties.Caption = "World:";
            this.rdo_World.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_World.Properties.RadioGroupIndex = 2;
            this.rdo_World.Size = new System.Drawing.Size(175, 19);
            this.rdo_World.StyleController = this.layoutControl;
            this.rdo_World.TabIndex = 8;
            // 
            // rdo_AllWorlds
            // 
            this.rdo_AllWorlds.Location = new System.Drawing.Point(10, 82);
            this.rdo_AllWorlds.Name = "rdo_AllWorlds";
            this.rdo_AllWorlds.Properties.Caption = "All worlds";
            this.rdo_AllWorlds.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_AllWorlds.Properties.RadioGroupIndex = 2;
            this.rdo_AllWorlds.Size = new System.Drawing.Size(173, 19);
            this.rdo_AllWorlds.StyleController = this.layoutControl;
            this.rdo_AllWorlds.TabIndex = 7;
            this.rdo_AllWorlds.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Location = new System.Drawing.Point(292, 246);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 22);
            this.btn_Close.StyleController = this.layoutControl;
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "Cancel";
            // 
            // btn_Print
            // 
            this.btn_Print.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Print.Location = new System.Drawing.Point(201, 246);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(80, 22);
            this.btn_Print.StyleController = this.layoutControl;
            this.btn_Print.TabIndex = 5;
            this.btn_Print.Text = "Print";
            // 
            // de_EndDate
            // 
            this.de_EndDate.EditValue = null;
            this.de_EndDate.Location = new System.Drawing.Point(230, 112);
            this.de_EndDate.Name = "de_EndDate";
            this.de_EndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.de_EndDate.Properties.ReadOnly = true;
            this.de_EndDate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.de_EndDate.Properties.ShowPopupShadow = false;
            this.de_EndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.de_EndDate.Size = new System.Drawing.Size(139, 20);
            this.de_EndDate.StyleController = this.layoutControl;
            this.de_EndDate.TabIndex = 3;
            // 
            // chk_HideReportSums
            // 
            this.chk_HideReportSums.EditValue = true;
            this.chk_HideReportSums.Location = new System.Drawing.Point(7, 206);
            this.chk_HideReportSums.Name = "chk_HideReportSums";
            this.chk_HideReportSums.Properties.Caption = "Hide sums";
            this.chk_HideReportSums.Size = new System.Drawing.Size(365, 19);
            this.chk_HideReportSums.StyleController = this.layoutControl;
            this.chk_HideReportSums.TabIndex = 3;
            // 
            // chk_ManualFillingOnly
            // 
            this.chk_ManualFillingOnly.Location = new System.Drawing.Point(7, 176);
            this.chk_ManualFillingOnly.Name = "chk_ManualFillingOnly";
            this.chk_ManualFillingOnly.Properties.Caption = "Manual filling only";
            this.chk_ManualFillingOnly.Size = new System.Drawing.Size(365, 19);
            this.chk_ManualFillingOnly.StyleController = this.layoutControl;
            this.chk_ManualFillingOnly.TabIndex = 4;
            // 
            // rdo_WeeklyView
            // 
            this.rdo_WeeklyView.EditValue = true;
            this.rdo_WeeklyView.Location = new System.Drawing.Point(10, 52);
            this.rdo_WeeklyView.Name = "rdo_WeeklyView";
            this.rdo_WeeklyView.Properties.Caption = "Weekly";
            this.rdo_WeeklyView.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_WeeklyView.Properties.RadioGroupIndex = 1;
            this.rdo_WeeklyView.Size = new System.Drawing.Size(173, 19);
            this.rdo_WeeklyView.StyleController = this.layoutControl;
            this.rdo_WeeklyView.TabIndex = 0;
            this.rdo_WeeklyView.CheckedChanged += new System.EventHandler(this.ViewTypeChanged);
            // 
            // de_StartDate
            // 
            this.de_StartDate.EditValue = null;
            this.de_StartDate.Location = new System.Drawing.Point(46, 112);
            this.de_StartDate.Name = "de_StartDate";
            this.de_StartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.de_StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_StartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.de_StartDate.Size = new System.Drawing.Size(137, 20);
            this.de_StartDate.StyleController = this.layoutControl;
            this.de_StartDate.TabIndex = 1;
            this.de_StartDate.EditValueChanged += new System.EventHandler(this.ViewTypeChanged);
            // 
            // chk_AddManualFilling
            // 
            this.chk_AddManualFilling.Location = new System.Drawing.Point(7, 146);
            this.chk_AddManualFilling.Name = "chk_AddManualFilling";
            this.chk_AddManualFilling.Properties.Caption = "Add spaces for manual filling";
            this.chk_AddManualFilling.Size = new System.Drawing.Size(365, 19);
            this.chk_AddManualFilling.StyleController = this.layoutControl;
            this.chk_AddManualFilling.TabIndex = 2;
            // 
            // layoutControlGroupRoot
            // 
            this.layoutControlGroupRoot.AllowCustomizeChildren = false;
            this.layoutControlGroupRoot.CustomizationFormText = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_AdditionalManualFilling,
            this.li_ManualFillOnly,
            this.li_HideSums,
            this.lg_ViewType,
            this.li_printButton,
            this.li_cancelButton,
            this.li_buttonsFiller,
            this.li_HR,
            this.li_StoreName});
            this.layoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(378, 274);
            this.layoutControlGroupRoot.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupRoot.Text = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.TextVisible = false;
            // 
            // li_AdditionalManualFilling
            // 
            this.li_AdditionalManualFilling.Control = this.chk_AddManualFilling;
            this.li_AdditionalManualFilling.CustomizationFormText = "li_AdditionalManualFilling";
            this.li_AdditionalManualFilling.Location = new System.Drawing.Point(0, 139);
            this.li_AdditionalManualFilling.Name = "li_AdditionalManualFilling";
            this.li_AdditionalManualFilling.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_AdditionalManualFilling.Size = new System.Drawing.Size(376, 30);
            this.li_AdditionalManualFilling.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_AdditionalManualFilling.Text = "li_AdditionalManualFilling";
            this.li_AdditionalManualFilling.TextSize = new System.Drawing.Size(0, 0);
            this.li_AdditionalManualFilling.TextToControlDistance = 0;
            this.li_AdditionalManualFilling.TextVisible = false;
            // 
            // li_ManualFillOnly
            // 
            this.li_ManualFillOnly.Control = this.chk_ManualFillingOnly;
            this.li_ManualFillOnly.CustomizationFormText = "li_ManualFillOnly";
            this.li_ManualFillOnly.Location = new System.Drawing.Point(0, 169);
            this.li_ManualFillOnly.Name = "li_ManualFillOnly";
            this.li_ManualFillOnly.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_ManualFillOnly.Size = new System.Drawing.Size(376, 30);
            this.li_ManualFillOnly.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_ManualFillOnly.Text = "li_ManualFillOnly";
            this.li_ManualFillOnly.TextSize = new System.Drawing.Size(0, 0);
            this.li_ManualFillOnly.TextToControlDistance = 0;
            this.li_ManualFillOnly.TextVisible = false;
            // 
            // li_HideSums
            // 
            this.li_HideSums.Control = this.chk_HideReportSums;
            this.li_HideSums.CustomizationFormText = "li_HideSums";
            this.li_HideSums.Location = new System.Drawing.Point(0, 199);
            this.li_HideSums.Name = "li_HideSums";
            this.li_HideSums.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_HideSums.Size = new System.Drawing.Size(376, 30);
            this.li_HideSums.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_HideSums.Text = "li_HideSums";
            this.li_HideSums.TextSize = new System.Drawing.Size(0, 0);
            this.li_HideSums.TextToControlDistance = 0;
            this.li_HideSums.TextVisible = false;
            // 
            // lg_ViewType
            // 
            this.lg_ViewType.CustomizationFormText = "View type";
            this.lg_ViewType.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.li_WeeklyView,
            this.li_DailyView,
            this.li_AllWorlds,
            this.li_OneWorld,
            this.li_StartDate,
            this.li_ToDate});
            this.lg_ViewType.Location = new System.Drawing.Point(0, 24);
            this.lg_ViewType.Name = "lg_ViewType";
            this.lg_ViewType.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lg_ViewType.Size = new System.Drawing.Size(376, 115);
            this.lg_ViewType.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lg_ViewType.Text = "Print type";
            // 
            // li_WeeklyView
            // 
            this.li_WeeklyView.Control = this.rdo_WeeklyView;
            this.li_WeeklyView.CustomizationFormText = "li_WeeklyView";
            this.li_WeeklyView.Location = new System.Drawing.Point(0, 0);
            this.li_WeeklyView.Name = "li_WeeklyView";
            this.li_WeeklyView.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_WeeklyView.Size = new System.Drawing.Size(184, 30);
            this.li_WeeklyView.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_WeeklyView.Text = "li_WeeklyView";
            this.li_WeeklyView.TextSize = new System.Drawing.Size(0, 0);
            this.li_WeeklyView.TextToControlDistance = 0;
            this.li_WeeklyView.TextVisible = false;
            // 
            // li_DailyView
            // 
            this.li_DailyView.Control = this.rdo_DaylyView;
            this.li_DailyView.CustomizationFormText = "li_DailyView";
            this.li_DailyView.Location = new System.Drawing.Point(184, 0);
            this.li_DailyView.Name = "li_DailyView";
            this.li_DailyView.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_DailyView.Size = new System.Drawing.Size(186, 30);
            this.li_DailyView.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_DailyView.Text = "li_DailyView";
            this.li_DailyView.TextSize = new System.Drawing.Size(0, 0);
            this.li_DailyView.TextToControlDistance = 0;
            this.li_DailyView.TextVisible = false;
            // 
            // li_AllWorlds
            // 
            this.li_AllWorlds.Control = this.rdo_AllWorlds;
            this.li_AllWorlds.CustomizationFormText = "layoutControlItem1";
            this.li_AllWorlds.Location = new System.Drawing.Point(0, 30);
            this.li_AllWorlds.Name = "li_AllWorlds";
            this.li_AllWorlds.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_AllWorlds.Size = new System.Drawing.Size(184, 30);
            this.li_AllWorlds.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_AllWorlds.Text = "li_AllWorlds";
            this.li_AllWorlds.TextSize = new System.Drawing.Size(0, 0);
            this.li_AllWorlds.TextToControlDistance = 0;
            this.li_AllWorlds.TextVisible = false;
            // 
            // li_OneWorld
            // 
            this.li_OneWorld.Control = this.rdo_World;
            this.li_OneWorld.CustomizationFormText = "layoutControlItem2";
            this.li_OneWorld.Location = new System.Drawing.Point(184, 30);
            this.li_OneWorld.Name = "li_OneWorld";
            this.li_OneWorld.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_OneWorld.Size = new System.Drawing.Size(186, 30);
            this.li_OneWorld.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_OneWorld.Text = "li_OneWorld";
            this.li_OneWorld.TextSize = new System.Drawing.Size(0, 0);
            this.li_OneWorld.TextToControlDistance = 0;
            this.li_OneWorld.TextVisible = false;
            // 
            // li_StartDate
            // 
            this.li_StartDate.Control = this.de_StartDate;
            this.li_StartDate.CustomizationFormText = "Week:";
            this.li_StartDate.Location = new System.Drawing.Point(0, 60);
            this.li_StartDate.Name = "li_StartDate";
            this.li_StartDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_StartDate.Size = new System.Drawing.Size(184, 31);
            this.li_StartDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_StartDate.Text = "Week:";
            this.li_StartDate.TextSize = new System.Drawing.Size(31, 20);
            // 
            // li_ToDate
            // 
            this.li_ToDate.Control = this.de_EndDate;
            this.li_ToDate.CustomizationFormText = "to";
            this.li_ToDate.Location = new System.Drawing.Point(184, 60);
            this.li_ToDate.Name = "li_ToDate";
            this.li_ToDate.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_ToDate.Size = new System.Drawing.Size(186, 31);
            this.li_ToDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_ToDate.Text = "-";
            this.li_ToDate.TextSize = new System.Drawing.Size(31, 20);
            // 
            // li_printButton
            // 
            this.li_printButton.Control = this.btn_Print;
            this.li_printButton.CustomizationFormText = "li_printButton";
            this.li_printButton.Location = new System.Drawing.Point(194, 239);
            this.li_printButton.MaxSize = new System.Drawing.Size(91, 33);
            this.li_printButton.MinSize = new System.Drawing.Size(91, 33);
            this.li_printButton.Name = "li_printButton";
            this.li_printButton.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_printButton.Size = new System.Drawing.Size(91, 33);
            this.li_printButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.li_printButton.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_printButton.Text = "li_printButton";
            this.li_printButton.TextSize = new System.Drawing.Size(0, 0);
            this.li_printButton.TextToControlDistance = 0;
            this.li_printButton.TextVisible = false;
            // 
            // li_cancelButton
            // 
            this.li_cancelButton.Control = this.btn_Close;
            this.li_cancelButton.CustomizationFormText = "li_cancelButton";
            this.li_cancelButton.Location = new System.Drawing.Point(285, 239);
            this.li_cancelButton.MaxSize = new System.Drawing.Size(91, 33);
            this.li_cancelButton.MinSize = new System.Drawing.Size(91, 33);
            this.li_cancelButton.Name = "li_cancelButton";
            this.li_cancelButton.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_cancelButton.Size = new System.Drawing.Size(91, 33);
            this.li_cancelButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.li_cancelButton.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_cancelButton.Text = "li_cancelButton";
            this.li_cancelButton.TextSize = new System.Drawing.Size(0, 0);
            this.li_cancelButton.TextToControlDistance = 0;
            this.li_cancelButton.TextVisible = false;
            // 
            // li_buttonsFiller
            // 
            this.li_buttonsFiller.CustomizationFormText = "li_buttonsFiller";
            this.li_buttonsFiller.Location = new System.Drawing.Point(0, 239);
            this.li_buttonsFiller.Name = "li_buttonsFiller";
            this.li_buttonsFiller.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_buttonsFiller.Size = new System.Drawing.Size(194, 33);
            this.li_buttonsFiller.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_buttonsFiller.Text = "li_buttonsFiller";
            this.li_buttonsFiller.TextSize = new System.Drawing.Size(0, 0);
            // 
            // li_HR
            // 
            this.li_HR.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.li_HR.AppearanceItemCaption.Options.UseBorderColor = true;
            this.li_HR.CustomizationFormText = "li_HR";
            this.li_HR.Location = new System.Drawing.Point(0, 229);
            this.li_HR.Name = "li_HR";
            this.li_HR.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_HR.Size = new System.Drawing.Size(376, 10);
            this.li_HR.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_HR.Text = "li_HR";
            this.li_HR.TextSize = new System.Drawing.Size(0, 0);
            // 
            // li_StoreName
            // 
            this.li_StoreName.Control = this.lb_StoreName;
            this.li_StoreName.CustomizationFormText = "Store:";
            this.li_StoreName.Location = new System.Drawing.Point(0, 0);
            this.li_StoreName.Name = "li_StoreName";
            this.li_StoreName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_StoreName.Size = new System.Drawing.Size(376, 24);
            this.li_StoreName.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_StoreName.Text = "Store:";
            this.li_StoreName.TextSize = new System.Drawing.Size(31, 20);
            // 
            // FormPrintTimePlanning
            // 
            this.AcceptButton = this.btn_Print;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(378, 274);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintTimePlanning";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Manpower Time Planning";
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DaylyView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdo_World.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_AllWorlds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_EndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_EndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_HideReportSums.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ManualFillingOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_WeeklyView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_StartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_StartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_AddManualFilling.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_AdditionalManualFilling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_ManualFillOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HideSums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_ViewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_WeeklyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_DailyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_AllWorlds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_OneWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_printButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_buttonsFiller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_HR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_StoreName)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.CheckEdit rdo_DaylyView;
		private DevExpress.XtraEditors.CheckEdit rdo_WeeklyView;
		private DevExpress.XtraEditors.DateEdit de_EndDate;
		private DevExpress.XtraEditors.DateEdit de_StartDate;
		private DevExpress.XtraEditors.CheckEdit chk_AddManualFilling;
		private DevExpress.XtraEditors.CheckEdit chk_HideReportSums;
		private DevExpress.XtraEditors.CheckEdit chk_ManualFillingOnly;
		private DevExpress.XtraLayout.LayoutControl layoutControl;
		private DevExpress.XtraEditors.SimpleButton btn_Close;
		private DevExpress.XtraEditors.SimpleButton btn_Print;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
		private DevExpress.XtraLayout.LayoutControlItem li_AdditionalManualFilling;
		private DevExpress.XtraLayout.LayoutControlItem li_ManualFillOnly;
		private DevExpress.XtraLayout.LayoutControlItem li_HideSums;
		private DevExpress.XtraLayout.LayoutControlGroup lg_ViewType;
		private DevExpress.XtraLayout.LayoutControlItem li_WeeklyView;
		private DevExpress.XtraLayout.LayoutControlItem li_DailyView;
		private DevExpress.XtraLayout.LayoutControlItem li_StartDate;
		private DevExpress.XtraLayout.LayoutControlItem li_ToDate;
		private DevExpress.XtraLayout.LayoutControlItem li_printButton;
		private DevExpress.XtraLayout.LayoutControlItem li_cancelButton;
		private DevExpress.XtraLayout.EmptySpaceItem li_buttonsFiller;
		private DevExpress.XtraLayout.EmptySpaceItem li_HR;
		private DevExpress.XtraEditors.CheckEdit rdo_World;
		private DevExpress.XtraEditors.CheckEdit rdo_AllWorlds;
		private DevExpress.XtraLayout.LayoutControlItem li_AllWorlds;
		private DevExpress.XtraLayout.LayoutControlItem li_OneWorld;
		private DevExpress.XtraEditors.LabelControl lb_StoreName;
		private DevExpress.XtraLayout.LayoutControlItem li_StoreName;
	}
}