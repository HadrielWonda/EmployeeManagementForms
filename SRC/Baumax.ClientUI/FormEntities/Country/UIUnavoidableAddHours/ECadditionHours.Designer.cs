namespace Baumax.ClientUI.FormEntities.Country
{
    partial class ECadditionHours
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
            this.lb_yearappearance = new DevExpress.XtraEditors.LabelControl();
            this.lb_StartTime = new DevExpress.XtraEditors.LabelControl();
            this.lb_FinishTime = new DevExpress.XtraEditors.LabelControl();
            this.lb_FactorEnd = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit_Year = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_FactorE = new DevExpress.XtraEditors.SpinEdit();
            this.timeEdit_BeginTime = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit_EndTime = new DevExpress.XtraEditors.TimeEdit();
            this.lb_dayofweek = new DevExpress.XtraEditors.LabelControl();
            this.checkedListBoxControl_week = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lb_FactorBegin = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit_FactorB = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_FactorE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_BeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_week)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_FactorB.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_yearappearance
            // 
            this.lb_yearappearance.Location = new System.Drawing.Point(22, 26);
            this.lb_yearappearance.Name = "lb_yearappearance";
            this.lb_yearappearance.Size = new System.Drawing.Size(22, 13);
            this.lb_yearappearance.TabIndex = 0;
            this.lb_yearappearance.Text = "Year";
            // 
            // lb_StartTime
            // 
            this.lb_StartTime.Location = new System.Drawing.Point(22, 240);
            this.lb_StartTime.Name = "lb_StartTime";
            this.lb_StartTime.Size = new System.Drawing.Size(183, 13);
            this.lb_StartTime.TabIndex = 4;
            this.lb_StartTime.Text = "Start-Time until Begin of Opening Time";
            // 
            // lb_FinishTime
            // 
            this.lb_FinishTime.Location = new System.Drawing.Point(22, 344);
            this.lb_FinishTime.Name = "lb_FinishTime";
            this.lb_FinishTime.Size = new System.Drawing.Size(175, 13);
            this.lb_FinishTime.TabIndex = 5;
            this.lb_FinishTime.Text = "Start-Time until End of Opening Time";
            // 
            // lb_FactorEnd
            // 
            this.lb_FactorEnd.Location = new System.Drawing.Point(22, 389);
            this.lb_FactorEnd.Name = "lb_FactorEnd";
            this.lb_FactorEnd.Size = new System.Drawing.Size(52, 13);
            this.lb_FactorEnd.TabIndex = 6;
            this.lb_FactorEnd.Text = "Factor End";
            // 
            // spinEdit_Year
            // 
            this.spinEdit_Year.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.spinEdit_Year.Location = new System.Drawing.Point(22, 45);
            this.spinEdit_Year.Name = "spinEdit_Year";
            this.spinEdit_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Year.Properties.IsFloatValue = false;
            this.spinEdit_Year.Properties.Mask.EditMask = "\\d\\d\\d\\d";
            this.spinEdit_Year.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit_Year.Properties.Mask.ShowPlaceHolders = false;
            this.spinEdit_Year.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.spinEdit_Year.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.spinEdit_Year.Size = new System.Drawing.Size(383, 20);
            this.spinEdit_Year.TabIndex = 1;
            // 
            // spinEdit_FactorE
            // 
            this.spinEdit_FactorE.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_FactorE.Location = new System.Drawing.Point(22, 408);
            this.spinEdit_FactorE.Name = "spinEdit_FactorE";
            this.spinEdit_FactorE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_FactorE.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEdit_FactorE.Properties.Mask.EditMask = "n2";
            this.spinEdit_FactorE.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinEdit_FactorE.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_FactorE.Size = new System.Drawing.Size(383, 20);
            this.spinEdit_FactorE.TabIndex = 6;
            // 
            // timeEdit_BeginTime
            // 
            this.timeEdit_BeginTime.EditValue = new System.DateTime(2007, 10, 5, 0, 0, 0, 0);
            this.timeEdit_BeginTime.Location = new System.Drawing.Point(22, 259);
            this.timeEdit_BeginTime.Name = "timeEdit_BeginTime";
            this.timeEdit_BeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_BeginTime.Properties.Mask.EditMask = "t";
            this.timeEdit_BeginTime.Size = new System.Drawing.Size(383, 20);
            this.timeEdit_BeginTime.TabIndex = 3;
            this.timeEdit_BeginTime.EditValueChanged += new System.EventHandler(this.timeEdit_BeginTime_EditValueChanged);
            // 
            // timeEdit_EndTime
            // 
            this.timeEdit_EndTime.EditValue = new System.DateTime(2007, 10, 5, 0, 0, 0, 0);
            this.timeEdit_EndTime.Location = new System.Drawing.Point(22, 363);
            this.timeEdit_EndTime.Name = "timeEdit_EndTime";
            this.timeEdit_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_EndTime.Properties.Mask.EditMask = "t";
            this.timeEdit_EndTime.Size = new System.Drawing.Size(383, 20);
            this.timeEdit_EndTime.TabIndex = 5;
            this.timeEdit_EndTime.EditValueChanged += new System.EventHandler(this.timeEdit_EndTime_EditValueChanged);
            // 
            // lb_dayofweek
            // 
            this.lb_dayofweek.Location = new System.Drawing.Point(22, 89);
            this.lb_dayofweek.Name = "lb_dayofweek";
            this.lb_dayofweek.Size = new System.Drawing.Size(93, 13);
            this.lb_dayofweek.TabIndex = 1;
            this.lb_dayofweek.Text = "DayMasks of week:";
            // 
            // checkedListBoxControl_week
            // 
            this.checkedListBoxControl_week.CheckOnClick = true;
            this.checkedListBoxControl_week.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.checkedListBoxControl_week.Location = new System.Drawing.Point(22, 108);
            this.checkedListBoxControl_week.Name = "checkedListBoxControl_week";
            this.checkedListBoxControl_week.Size = new System.Drawing.Size(383, 126);
            this.checkedListBoxControl_week.TabIndex = 2;
            // 
            // lb_FactorBegin
            // 
            this.lb_FactorBegin.Location = new System.Drawing.Point(22, 285);
            this.lb_FactorBegin.Name = "lb_FactorBegin";
            this.lb_FactorBegin.Size = new System.Drawing.Size(60, 13);
            this.lb_FactorBegin.TabIndex = 13;
            this.lb_FactorBegin.Text = "Factor Begin";
            // 
            // spinEdit_FactorB
            // 
            this.spinEdit_FactorB.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_FactorB.Location = new System.Drawing.Point(22, 304);
            this.spinEdit_FactorB.Name = "spinEdit_FactorB";
            this.spinEdit_FactorB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_FactorB.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEdit_FactorB.Properties.Mask.EditMask = "n2";
            this.spinEdit_FactorB.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinEdit_FactorB.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_FactorB.Size = new System.Drawing.Size(383, 20);
            this.spinEdit_FactorB.TabIndex = 4;
            // 
            // ECadditionHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinEdit_FactorB);
            this.Controls.Add(this.lb_FactorBegin);
            this.Controls.Add(this.checkedListBoxControl_week);
            this.Controls.Add(this.timeEdit_EndTime);
            this.Controls.Add(this.timeEdit_BeginTime);
            this.Controls.Add(this.spinEdit_FactorE);
            this.Controls.Add(this.spinEdit_Year);
            this.Controls.Add(this.lb_FactorEnd);
            this.Controls.Add(this.lb_FinishTime);
            this.Controls.Add(this.lb_StartTime);
            this.Controls.Add(this.lb_dayofweek);
            this.Controls.Add(this.lb_yearappearance);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ECadditionHours";
            this.Size = new System.Drawing.Size(434, 467);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_FactorE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_BeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_week)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_FactorB.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_yearappearance;
        private DevExpress.XtraEditors.LabelControl lb_StartTime;
        private DevExpress.XtraEditors.LabelControl lb_FinishTime;
        private DevExpress.XtraEditors.LabelControl lb_FactorEnd;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Year;
        private DevExpress.XtraEditors.SpinEdit spinEdit_FactorE;
        private DevExpress.XtraEditors.TimeEdit timeEdit_BeginTime;
        private DevExpress.XtraEditors.TimeEdit timeEdit_EndTime;
        private DevExpress.XtraEditors.LabelControl lb_dayofweek;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl_week;
        private DevExpress.XtraEditors.LabelControl lb_FactorBegin;
        private DevExpress.XtraEditors.SpinEdit spinEdit_FactorB;
    }
}
