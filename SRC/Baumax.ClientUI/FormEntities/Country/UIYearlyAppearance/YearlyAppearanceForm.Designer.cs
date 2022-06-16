namespace Baumax.ClientUI.FormEntities.Country
{
    partial class YearlyAppearanceForm
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
            this.yearAppearanceEntityControl1 = new Baumax.ClientUI.FormEntities.Country.YearAppearanceEntityControl();
            this.lbl_YearlyAppearance = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_YearlyAppearance);
            this.panelTop.Size = new System.Drawing.Size(464, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.yearAppearanceEntityControl1);
            this.panelClient.Size = new System.Drawing.Size(464, 278);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-711, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 312);
            this.panelBottom.Size = new System.Drawing.Size(464, 40);
            // 
            // yearAppearanceEntityControl1
            // 
            this.yearAppearanceEntityControl1.Amount = null;
            this.yearAppearanceEntityControl1.AvgHoursPerDay = ((short)(0));
            this.yearAppearanceEntityControl1.AvgRestingTime = ((short)(0));
            this.yearAppearanceEntityControl1.CashDeskAmount = ((short)(0));
            this.yearAppearanceEntityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearAppearanceEntityControl1.Entity = null;
            this.yearAppearanceEntityControl1.Location = new System.Drawing.Point(2, 2);
            this.yearAppearanceEntityControl1.LookAndFeel.SkinName = "iMaginary";
            this.yearAppearanceEntityControl1.Name = "yearAppearanceEntityControl1";
            this.yearAppearanceEntityControl1.Size = new System.Drawing.Size(460, 274);
            this.yearAppearanceEntityControl1.TabIndex = 0;
            this.yearAppearanceEntityControl1.Weeks = ((byte)(0));
            this.yearAppearanceEntityControl1.Year = ((short)(2007));
            // 
            // lbl_YearlyAppearance
            // 
            this.lbl_YearlyAppearance.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_YearlyAppearance.Appearance.Options.UseFont = true;
            this.lbl_YearlyAppearance.Appearance.Options.UseTextOptions = true;
            this.lbl_YearlyAppearance.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_YearlyAppearance.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_YearlyAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_YearlyAppearance.Location = new System.Drawing.Point(2, 2);
            this.lbl_YearlyAppearance.Name = "lbl_YearlyAppearance";
            this.lbl_YearlyAppearance.Size = new System.Drawing.Size(460, 30);
            this.lbl_YearlyAppearance.TabIndex = 0;
            this.lbl_YearlyAppearance.Text = "Year appearance";
            // 
            // YearlyAppearanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(464, 352);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "YearlyAppearanceForm";
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private YearAppearanceEntityControl yearAppearanceEntityControl1;
        private DevExpress.XtraEditors.LabelControl lbl_YearlyAppearance;
    }
}
