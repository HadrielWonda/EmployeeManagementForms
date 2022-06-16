namespace Baumax.ClientUI.FormEntities.Country
{
    partial class ECAvgWorkingDaysInWeek
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
            this.lbl_yearappearance = new DevExpress.XtraEditors.LabelControl();
            this.lbl_AverageWorkingDayInWeek = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit_Years = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_AvgWDIWeek = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Years.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_AvgWDIWeek.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_yearappearance
            // 
            this.lbl_yearappearance.Location = new System.Drawing.Point(21, 19);
            this.lbl_yearappearance.Name = "lbl_yearappearance";
            this.lbl_yearappearance.Size = new System.Drawing.Size(22, 13);
            this.lbl_yearappearance.TabIndex = 0;
            this.lbl_yearappearance.Text = "Year";
            // 
            // lbl_AverageWorkingDayInWeek
            // 
            this.lbl_AverageWorkingDayInWeek.Location = new System.Drawing.Point(21, 68);
            this.lbl_AverageWorkingDayInWeek.Name = "lbl_AverageWorkingDayInWeek";
            this.lbl_AverageWorkingDayInWeek.Size = new System.Drawing.Size(148, 13);
            this.lbl_AverageWorkingDayInWeek.TabIndex = 1;
            this.lbl_AverageWorkingDayInWeek.Text = "Average Working DayMask In Week";
            // 
            // spinEdit_Years
            // 
            this.spinEdit_Years.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.spinEdit_Years.Location = new System.Drawing.Point(396, 16);
            this.spinEdit_Years.Name = "spinEdit_Years";
            this.spinEdit_Years.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Years.Properties.IsFloatValue = false;
            this.spinEdit_Years.Properties.Mask.EditMask = "\\d\\d\\d\\d";
            this.spinEdit_Years.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit_Years.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.spinEdit_Years.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.spinEdit_Years.Size = new System.Drawing.Size(63, 20);
            this.spinEdit_Years.TabIndex = 2;
            // 
            // spinEdit_AvgWDIWeek
            // 
            this.spinEdit_AvgWDIWeek.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_AvgWDIWeek.Location = new System.Drawing.Point(21, 98);
            this.spinEdit_AvgWDIWeek.Name = "spinEdit_AvgWDIWeek";
            this.spinEdit_AvgWDIWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_AvgWDIWeek.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_AvgWDIWeek.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.spinEdit_AvgWDIWeek.Properties.Mask.EditMask = "n1";
            this.spinEdit_AvgWDIWeek.Properties.MaxValue = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.spinEdit_AvgWDIWeek.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_AvgWDIWeek.Size = new System.Drawing.Size(438, 20);
            this.spinEdit_AvgWDIWeek.TabIndex = 3;
            // 
            // ECAvgWorkingDaysInWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinEdit_AvgWDIWeek);
            this.Controls.Add(this.spinEdit_Years);
            this.Controls.Add(this.lbl_AverageWorkingDayInWeek);
            this.Controls.Add(this.lbl_yearappearance);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ECAvgWorkingDaysInWeek";
            this.Size = new System.Drawing.Size(462, 148);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Years.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_AvgWDIWeek.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_yearappearance;
        private DevExpress.XtraEditors.LabelControl lbl_AverageWorkingDayInWeek;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Years;
        private DevExpress.XtraEditors.SpinEdit spinEdit_AvgWDIWeek;
    }
}
