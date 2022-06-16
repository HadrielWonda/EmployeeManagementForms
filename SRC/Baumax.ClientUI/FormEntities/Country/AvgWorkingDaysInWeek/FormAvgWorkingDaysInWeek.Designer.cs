namespace Baumax.ClientUI.FormEntities.Country
{
    partial class AvgWorkingDaysInWeekForm
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
            this.lb_AverageWorkingDayInWeek = new DevExpress.XtraEditors.LabelControl();
            this.ecAvgWorkingDaysInWeek1 = new Baumax.ClientUI.FormEntities.Country.ECAvgWorkingDaysInWeek();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lb_AverageWorkingDayInWeek);
            this.panelTop.Size = new System.Drawing.Size(476, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ecAvgWorkingDaysInWeek1);
            this.panelClient.Size = new System.Drawing.Size(476, 150);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-5767, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 184);
            this.panelBottom.Size = new System.Drawing.Size(476, 40);
            // 
            // lb_AverageWorkingDayInWeek
            // 
            this.lb_AverageWorkingDayInWeek.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_AverageWorkingDayInWeek.Appearance.Options.UseFont = true;
            this.lb_AverageWorkingDayInWeek.Appearance.Options.UseTextOptions = true;
            this.lb_AverageWorkingDayInWeek.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_AverageWorkingDayInWeek.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_AverageWorkingDayInWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_AverageWorkingDayInWeek.Location = new System.Drawing.Point(2, 2);
            this.lb_AverageWorkingDayInWeek.Name = "lb_AverageWorkingDayInWeek";
            this.lb_AverageWorkingDayInWeek.Size = new System.Drawing.Size(472, 32);
            this.lb_AverageWorkingDayInWeek.TabIndex = 0;
            this.lb_AverageWorkingDayInWeek.Text = "Avg Working DayMasks In Week";
            // 
            // ecAvgWorkingDaysInWeek1
            // 
            this.ecAvgWorkingDaysInWeek1.Amount = null;
            this.ecAvgWorkingDaysInWeek1.Country = null;
            this.ecAvgWorkingDaysInWeek1.Days = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ecAvgWorkingDaysInWeek1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecAvgWorkingDaysInWeek1.Entity = null;
            this.ecAvgWorkingDaysInWeek1.Location = new System.Drawing.Point(2, 2);
            this.ecAvgWorkingDaysInWeek1.LookAndFeel.SkinName = "iMaginary";
            this.ecAvgWorkingDaysInWeek1.Name = "ecAvgWorkingDaysInWeek1";
            this.ecAvgWorkingDaysInWeek1.Size = new System.Drawing.Size(472, 146);
            this.ecAvgWorkingDaysInWeek1.TabIndex = 1;
            this.ecAvgWorkingDaysInWeek1.Year = ((short)(2007));
            // 
            // AvgWorkingDaysInWeekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 224);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "AvgWorkingDaysInWeekForm";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvgWDInWeekForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_AverageWorkingDayInWeek;
        private ECAvgWorkingDaysInWeek ecAvgWorkingDaysInWeek1;
    }
}