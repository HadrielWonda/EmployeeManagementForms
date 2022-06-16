namespace Baumax.ClientUI.FormEntities.Country.LunchBrakes
{
    partial class ECLunchModel
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
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.lb_LunchModelName = new DevExpress.XtraEditors.LabelControl();
            this.lbl_BeginDate = new DevExpress.XtraEditors.LabelControl();
            this.lbl_EndDate = new DevExpress.XtraEditors.LabelControl();
            this.deBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.lb_lunchHour = new DevExpress.XtraEditors.LabelControl();
            this.sEhour = new DevExpress.XtraEditors.SpinEdit();
            this.sEcondition = new DevExpress.XtraEditors.SpinEdit();
            this.lb_condition = new DevExpress.XtraEditors.LabelControl();
            this.lbmin = new DevExpress.XtraEditors.LabelControl();
            this.lb_typeLunchModel = new DevExpress.XtraEditors.LabelControl();
            this.rb_DurationTime = new System.Windows.Forms.RadioButton();
            this.rb_DurationWorkingDay = new System.Windows.Forms.RadioButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEhour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEcondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(16, 31);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 50;
            this.textEditName.Size = new System.Drawing.Size(319, 20);
            this.textEditName.TabIndex = 1;
            // 
            // lb_LunchModelName
            // 
            this.lb_LunchModelName.Location = new System.Drawing.Point(16, 12);
            this.lb_LunchModelName.Name = "lb_LunchModelName";
            this.lb_LunchModelName.Size = new System.Drawing.Size(89, 13);
            this.lb_LunchModelName.TabIndex = 1;
            this.lb_LunchModelName.Text = "Lunch Model Name";
            // 
            // lbl_BeginDate
            // 
            this.lbl_BeginDate.Location = new System.Drawing.Point(16, 66);
            this.lbl_BeginDate.Name = "lbl_BeginDate";
            this.lbl_BeginDate.Size = new System.Drawing.Size(52, 13);
            this.lbl_BeginDate.TabIndex = 2;
            this.lbl_BeginDate.Text = "Begin Date";
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_EndDate.Location = new System.Drawing.Point(235, 66);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(44, 13);
            this.lbl_EndDate.TabIndex = 3;
            this.lbl_EndDate.Text = "End Date";
            // 
            // deBeginTime
            // 
            this.deBeginTime.EditValue = null;
            this.deBeginTime.Location = new System.Drawing.Point(16, 85);
            this.deBeginTime.Name = "deBeginTime";
            this.deBeginTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deBeginTime.Size = new System.Drawing.Size(100, 20);
            this.deBeginTime.TabIndex = 2;
            this.deBeginTime.EditValueChanged += new System.EventHandler(this.BeginDate_EditValueChanged);
            // 
            // deEndTime
            // 
            this.deEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(235, 85);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Size = new System.Drawing.Size(100, 20);
            this.deEndTime.TabIndex = 3;
            this.deEndTime.EditValueChanged += new System.EventHandler(this.EndDate_EditValueChanged);
            // 
            // lb_lunchHour
            // 
            this.lb_lunchHour.Location = new System.Drawing.Point(16, 223);
            this.lb_lunchHour.Name = "lb_lunchHour";
            this.lb_lunchHour.Size = new System.Drawing.Size(53, 13);
            this.lb_lunchHour.TabIndex = 7;
            this.lb_lunchHour.Text = "Lunch hour";
            // 
            // sEhour
            // 
            this.sEhour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sEhour.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.sEhour.Location = new System.Drawing.Point(282, 220);
            this.sEhour.Name = "sEhour";
            this.sEhour.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sEhour.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sEhour.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sEhour.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.sEhour.Properties.Mask.EditMask = "f1";
            this.sEhour.Properties.MaxLength = 3;
            this.sEhour.Properties.MaxValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.sEhour.Properties.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.sEhour.Size = new System.Drawing.Size(53, 20);
            this.sEhour.TabIndex = 8;
            // 
            // sEcondition
            // 
            this.sEcondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sEcondition.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sEcondition.Location = new System.Drawing.Point(282, 189);
            this.sEcondition.Name = "sEcondition";
            this.sEcondition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sEcondition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sEcondition.Properties.EditFormat.FormatString = "f1";
            this.sEcondition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sEcondition.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.sEcondition.Properties.Mask.EditMask = "n2";
            this.sEcondition.Size = new System.Drawing.Size(53, 20);
            this.sEcondition.TabIndex = 7;
            this.sEcondition.Visible = false;
            // 
            // lb_condition
            // 
            this.lb_condition.Location = new System.Drawing.Point(16, 192);
            this.lb_condition.Name = "lb_condition";
            this.lb_condition.Size = new System.Drawing.Size(45, 13);
            this.lb_condition.TabIndex = 10;
            this.lb_condition.Text = "Condition";
            this.lb_condition.Visible = false;
            // 
            // lbmin
            // 
            this.lbmin.Location = new System.Drawing.Point(260, 192);
            this.lbmin.Name = "lbmin";
            this.lbmin.Size = new System.Drawing.Size(16, 13);
            this.lbmin.TabIndex = 12;
            this.lbmin.Text = ">=";
            // 
            // lb_typeLunchModel
            // 
            this.lb_typeLunchModel.Location = new System.Drawing.Point(5, 5);
            this.lb_typeLunchModel.Name = "lb_typeLunchModel";
            this.lb_typeLunchModel.Size = new System.Drawing.Size(22, 13);
            this.lb_typeLunchModel.TabIndex = 13;
            this.lb_typeLunchModel.Text = "type";
            // 
            // rb_DurationTime
            // 
            this.rb_DurationTime.AutoSize = true;
            this.rb_DurationTime.Location = new System.Drawing.Point(5, 24);
            this.rb_DurationTime.Name = "rb_DurationTime";
            this.rb_DurationTime.Size = new System.Drawing.Size(88, 17);
            this.rb_DurationTime.TabIndex = 5;
            this.rb_DurationTime.TabStop = true;
            this.rb_DurationTime.Text = "duration time";
            this.rb_DurationTime.UseVisualStyleBackColor = true;
            // 
            // rb_DurationWorkingDay
            // 
            this.rb_DurationWorkingDay.AutoSize = true;
            this.rb_DurationWorkingDay.Location = new System.Drawing.Point(5, 44);
            this.rb_DurationWorkingDay.Name = "rb_DurationWorkingDay";
            this.rb_DurationWorkingDay.Size = new System.Drawing.Size(126, 17);
            this.rb_DurationWorkingDay.TabIndex = 6;
            this.rb_DurationWorkingDay.TabStop = true;
            this.rb_DurationWorkingDay.Text = "duration working day";
            this.rb_DurationWorkingDay.UseVisualStyleBackColor = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.lb_typeLunchModel);
            this.panelControl1.Controls.Add(this.rb_DurationWorkingDay);
            this.panelControl1.Controls.Add(this.rb_DurationTime);
            this.panelControl1.Location = new System.Drawing.Point(16, 120);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(319, 66);
            this.panelControl1.TabIndex = 4;
            // 
            // ECLunchModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lbmin);
            this.Controls.Add(this.lb_condition);
            this.Controls.Add(this.sEcondition);
            this.Controls.Add(this.sEhour);
            this.Controls.Add(this.lb_lunchHour);
            this.Controls.Add(this.deEndTime);
            this.Controls.Add(this.deBeginTime);
            this.Controls.Add(this.lbl_EndDate);
            this.Controls.Add(this.lbl_BeginDate);
            this.Controls.Add(this.lb_LunchModelName);
            this.Controls.Add(this.textEditName);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ECLunchModel";
            this.Size = new System.Drawing.Size(351, 257);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEhour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEcondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl lb_LunchModelName;
        private DevExpress.XtraEditors.LabelControl lbl_BeginDate;
        private DevExpress.XtraEditors.LabelControl lbl_EndDate;
        private DevExpress.XtraEditors.DateEdit deBeginTime;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.LabelControl lb_lunchHour;
        private DevExpress.XtraEditors.SpinEdit sEhour;
        private DevExpress.XtraEditors.SpinEdit sEcondition;
        private DevExpress.XtraEditors.LabelControl lb_condition;
        private DevExpress.XtraEditors.LabelControl lbmin;
        private DevExpress.XtraEditors.LabelControl lb_typeLunchModel;
        private System.Windows.Forms.RadioButton rb_DurationTime;
        private System.Windows.Forms.RadioButton rb_DurationWorkingDay;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
