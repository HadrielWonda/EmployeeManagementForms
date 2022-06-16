namespace Baumax.ClientUI.FormEntities.EntityStore
{
    partial class UCOpenCloseHours
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
			this.teSunday = new DevExpress.XtraEditors.TextEdit();
			this.teSaturday = new DevExpress.XtraEditors.TextEdit();
			this.teFriday = new DevExpress.XtraEditors.TextEdit();
			this.teThursday = new DevExpress.XtraEditors.TextEdit();
			this.teWednesday = new DevExpress.XtraEditors.TextEdit();
			this.teTuesday = new DevExpress.XtraEditors.TextEdit();
			this.teMonday = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lbl_Monday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lbl_Tuesday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lbl_Wednesday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lbl_Thursday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lbl_Friday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lnl_Saturday = new DevExpress.XtraLayout.LayoutControlItem();
			this.lbl_Sunday = new DevExpress.XtraLayout.LayoutControlItem();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnNew = new DevExpress.XtraEditors.SimpleButton();
			this.btnOK = new DevExpress.XtraEditors.SimpleButton();
			this.deEnd = new DevExpress.XtraEditors.DateEdit();
			this.deStart = new DevExpress.XtraEditors.DateEdit();
			this.lbl_EndDate = new DevExpress.XtraEditors.LabelControl();
			this.lbl_BeginDate = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.teSunday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teSaturday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teFriday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teThursday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teWednesday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teTuesday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teMonday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Monday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Tuesday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Wednesday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Thursday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Friday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lnl_Saturday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Sunday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.AllowCustomizationMenu = false;
			this.layoutControl1.Controls.Add(this.teSunday);
			this.layoutControl1.Controls.Add(this.teSaturday);
			this.layoutControl1.Controls.Add(this.teFriday);
			this.layoutControl1.Controls.Add(this.teThursday);
			this.layoutControl1.Controls.Add(this.teWednesday);
			this.layoutControl1.Controls.Add(this.teTuesday);
			this.layoutControl1.Controls.Add(this.teMonday);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 54);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.ShowLayoutTreeView = false;
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(473, 221);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// teSunday
			// 
			this.teSunday.Location = new System.Drawing.Point(69, 193);
			this.teSunday.Name = "teSunday";
			this.teSunday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teSunday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teSunday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teSunday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teSunday.Size = new System.Drawing.Size(398, 20);
			this.teSunday.StyleController = this.layoutControl1;
			this.teSunday.TabIndex = 10;
			this.teSunday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teSaturday
			// 
			this.teSaturday.Location = new System.Drawing.Point(69, 162);
			this.teSaturday.Name = "teSaturday";
			this.teSaturday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teSaturday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teSaturday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teSaturday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teSaturday.Size = new System.Drawing.Size(398, 20);
			this.teSaturday.StyleController = this.layoutControl1;
			this.teSaturday.TabIndex = 9;
			this.teSaturday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teFriday
			// 
			this.teFriday.Location = new System.Drawing.Point(69, 131);
			this.teFriday.Name = "teFriday";
			this.teFriday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teFriday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teFriday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teFriday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teFriday.Size = new System.Drawing.Size(398, 20);
			this.teFriday.StyleController = this.layoutControl1;
			this.teFriday.TabIndex = 8;
			this.teFriday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teThursday
			// 
			this.teThursday.Location = new System.Drawing.Point(69, 100);
			this.teThursday.Name = "teThursday";
			this.teThursday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teThursday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teThursday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teThursday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teThursday.Size = new System.Drawing.Size(398, 20);
			this.teThursday.StyleController = this.layoutControl1;
			this.teThursday.TabIndex = 7;
			this.teThursday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teWednesday
			// 
			this.teWednesday.Location = new System.Drawing.Point(69, 69);
			this.teWednesday.Name = "teWednesday";
			this.teWednesday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teWednesday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teWednesday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teWednesday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teWednesday.Size = new System.Drawing.Size(398, 20);
			this.teWednesday.StyleController = this.layoutControl1;
			this.teWednesday.TabIndex = 6;
			this.teWednesday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teTuesday
			// 
			this.teTuesday.Location = new System.Drawing.Point(69, 38);
			this.teTuesday.Name = "teTuesday";
			this.teTuesday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teTuesday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teTuesday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teTuesday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teTuesday.Size = new System.Drawing.Size(398, 20);
			this.teTuesday.StyleController = this.layoutControl1;
			this.teTuesday.TabIndex = 5;
			this.teTuesday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// teMonday
			// 
			this.teMonday.Location = new System.Drawing.Point(69, 7);
			this.teMonday.Name = "teMonday";
			this.teMonday.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.teMonday.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.teMonday.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)-(0?\\d|1\\d|2[0-3])\\:(00|15|30|45)";
			this.teMonday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.teMonday.Size = new System.Drawing.Size(398, 20);
			this.teMonday.StyleController = this.layoutControl1;
			this.teMonday.TabIndex = 4;
			this.teMonday.Validating += new System.ComponentModel.CancelEventHandler(this.teMonday_Validating);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lbl_Monday,
            this.lbl_Tuesday,
            this.lbl_Wednesday,
            this.lbl_Thursday,
            this.lbl_Friday,
            this.lnl_Saturday,
            this.lbl_Sunday});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Size = new System.Drawing.Size(473, 221);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// lbl_Monday
			// 
			this.lbl_Monday.Control = this.teMonday;
			this.lbl_Monday.CustomizationFormText = "Monday";
			this.lbl_Monday.Location = new System.Drawing.Point(0, 0);
			this.lbl_Monday.Name = "lbl_Monday";
			this.lbl_Monday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Monday.Size = new System.Drawing.Size(471, 31);
			this.lbl_Monday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Monday.Text = "Monday";
			this.lbl_Monday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lbl_Tuesday
			// 
			this.lbl_Tuesday.Control = this.teTuesday;
			this.lbl_Tuesday.CustomizationFormText = "Tuesday";
			this.lbl_Tuesday.Location = new System.Drawing.Point(0, 31);
			this.lbl_Tuesday.Name = "lbl_Tuesday";
			this.lbl_Tuesday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Tuesday.Size = new System.Drawing.Size(471, 31);
			this.lbl_Tuesday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Tuesday.Text = "Tuesday";
			this.lbl_Tuesday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lbl_Wednesday
			// 
			this.lbl_Wednesday.Control = this.teWednesday;
			this.lbl_Wednesday.CustomizationFormText = "Wednesday";
			this.lbl_Wednesday.Location = new System.Drawing.Point(0, 62);
			this.lbl_Wednesday.Name = "lbl_Wednesday";
			this.lbl_Wednesday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Wednesday.Size = new System.Drawing.Size(471, 31);
			this.lbl_Wednesday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Wednesday.Text = "Wednesday";
			this.lbl_Wednesday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lbl_Thursday
			// 
			this.lbl_Thursday.Control = this.teThursday;
			this.lbl_Thursday.CustomizationFormText = "Thursday";
			this.lbl_Thursday.Location = new System.Drawing.Point(0, 93);
			this.lbl_Thursday.Name = "lbl_Thursday";
			this.lbl_Thursday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Thursday.Size = new System.Drawing.Size(471, 31);
			this.lbl_Thursday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Thursday.Text = "Thursday";
			this.lbl_Thursday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lbl_Friday
			// 
			this.lbl_Friday.Control = this.teFriday;
			this.lbl_Friday.CustomizationFormText = "Friday";
			this.lbl_Friday.Location = new System.Drawing.Point(0, 124);
			this.lbl_Friday.Name = "lbl_Friday";
			this.lbl_Friday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Friday.Size = new System.Drawing.Size(471, 31);
			this.lbl_Friday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Friday.Text = "Friday";
			this.lbl_Friday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lnl_Saturday
			// 
			this.lnl_Saturday.Control = this.teSaturday;
			this.lnl_Saturday.CustomizationFormText = "Saturday";
			this.lnl_Saturday.Location = new System.Drawing.Point(0, 155);
			this.lnl_Saturday.Name = "lnl_Saturday";
			this.lnl_Saturday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lnl_Saturday.Size = new System.Drawing.Size(471, 31);
			this.lnl_Saturday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lnl_Saturday.Text = "Saturday";
			this.lnl_Saturday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// lbl_Sunday
			// 
			this.lbl_Sunday.Control = this.teSunday;
			this.lbl_Sunday.CustomizationFormText = "Sunday";
			this.lbl_Sunday.Location = new System.Drawing.Point(0, 186);
			this.lbl_Sunday.Name = "lbl_Sunday";
			this.lbl_Sunday.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lbl_Sunday.Size = new System.Drawing.Size(471, 33);
			this.lbl_Sunday.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lbl_Sunday.Text = "Sunday";
			this.lbl_Sunday.TextSize = new System.Drawing.Size(57, 20);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnDelete);
			this.panelControl1.Controls.Add(this.btnNew);
			this.panelControl1.Controls.Add(this.btnOK);
			this.panelControl1.Controls.Add(this.deEnd);
			this.panelControl1.Controls.Add(this.deStart);
			this.panelControl1.Controls.Add(this.lbl_EndDate);
			this.panelControl1.Controls.Add(this.lbl_BeginDate);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(473, 54);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.TabStop = true;
			// 
			// btnDelete
			// 
			this.btnDelete.Image = global::Baumax.ClientUI.Properties.Resources.document_delete;
			this.btnDelete.Location = new System.Drawing.Point(414, 6);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(43, 43);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.ToolTip = "New";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnNew
			// 
			this.btnNew.Image = global::Baumax.ClientUI.Properties.Resources.document_add;
			this.btnNew.Location = new System.Drawing.Point(365, 6);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(43, 43);
			this.btnNew.TabIndex = 3;
			this.btnNew.ToolTip = "New";
			this.btnNew.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// btnOK
			// 
			this.btnOK.Image = global::Baumax.ClientUI.Properties.Resources.data_disk;
			this.btnOK.Location = new System.Drawing.Point(316, 6);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(43, 43);
			this.btnOK.TabIndex = 2;
			this.btnOK.ToolTip = "Save";
			this.btnOK.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// deEnd
			// 
			this.deEnd.EditValue = null;
			this.deEnd.Location = new System.Drawing.Point(181, 25);
			this.deEnd.Name = "deEnd";
			this.deEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.deEnd.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.deEnd.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
			this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.deEnd.Size = new System.Drawing.Size(129, 20);
			this.deEnd.TabIndex = 1;
			this.deEnd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deEnd_ButtonClick);
			this.deEnd.DateTimeChanged += new System.EventHandler(this.deStart_DateTimeChanged);
			// 
			// deStart
			// 
			this.deStart.EditValue = null;
			this.deStart.Location = new System.Drawing.Point(6, 25);
			this.deStart.Name = "deStart";
			this.deStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.deStart.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
			this.deStart.Properties.AppearanceDisabled.Options.UseForeColor = true;
			this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.deStart.Size = new System.Drawing.Size(123, 20);
			this.deStart.TabIndex = 0;
			this.deStart.DateTimeChanged += new System.EventHandler(this.deStart_DateTimeChanged);
			// 
			// lbl_EndDate
			// 
			this.lbl_EndDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbl_EndDate.Location = new System.Drawing.Point(181, 6);
			this.lbl_EndDate.Name = "lbl_EndDate";
			this.lbl_EndDate.Size = new System.Drawing.Size(129, 13);
			this.lbl_EndDate.TabIndex = 1;
			this.lbl_EndDate.Text = "End";
			// 
			// lbl_BeginDate
			// 
			this.lbl_BeginDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbl_BeginDate.Location = new System.Drawing.Point(6, 6);
			this.lbl_BeginDate.Name = "lbl_BeginDate";
			this.lbl_BeginDate.Size = new System.Drawing.Size(169, 13);
			this.lbl_BeginDate.TabIndex = 0;
			this.lbl_BeginDate.Text = "Start";
			// 
			// UCOpenCloseHours
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layoutControl1);
			this.Controls.Add(this.panelControl1);
			this.LookAndFeel.SkinName = "iMaginary";
			this.Name = "UCOpenCloseHours";
			this.Size = new System.Drawing.Size(473, 275);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.teSunday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teSaturday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teFriday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teThursday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teWednesday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teTuesday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teMonday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Monday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Tuesday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Wednesday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Thursday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Friday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lnl_Saturday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbl_Sunday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit teMonday;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Monday;
        private DevExpress.XtraEditors.TextEdit teSunday;
        private DevExpress.XtraEditors.TextEdit teSaturday;
        private DevExpress.XtraEditors.TextEdit teFriday;
        private DevExpress.XtraEditors.TextEdit teThursday;
        private DevExpress.XtraEditors.TextEdit teWednesday;
        private DevExpress.XtraEditors.TextEdit teTuesday;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Tuesday;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Wednesday;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Thursday;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Friday;
        private DevExpress.XtraLayout.LayoutControlItem lnl_Saturday;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Sunday;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.DateEdit deEnd;
        private DevExpress.XtraEditors.DateEdit deStart;
        private DevExpress.XtraEditors.LabelControl lbl_EndDate;
        private DevExpress.XtraEditors.LabelControl lbl_BeginDate;
        private DevExpress.XtraEditors.SimpleButton btnNew;
		private DevExpress.XtraEditors.SimpleButton btnDelete;

    }
}
