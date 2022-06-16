namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FormUnavoidableAddHours
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
            this.lb_NewUAAH = new DevExpress.XtraEditors.LabelControl();
            this.eCadditionHours1 = new Baumax.ClientUI.FormEntities.Country.ECadditionHours();
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
            this.panelTop.Controls.Add(this.lb_NewUAAH);
            this.panelTop.Size = new System.Drawing.Size(432, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.eCadditionHours1);
            this.panelClient.Size = new System.Drawing.Size(432, 460);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1608, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 494);
            this.panelBottom.Size = new System.Drawing.Size(432, 40);
            // 
            // lb_NewUAAH
            // 
            this.lb_NewUAAH.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_NewUAAH.Appearance.Options.UseFont = true;
            this.lb_NewUAAH.Appearance.Options.UseTextOptions = true;
            this.lb_NewUAAH.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_NewUAAH.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_NewUAAH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_NewUAAH.Location = new System.Drawing.Point(2, 2);
            this.lb_NewUAAH.Name = "lb_NewUAAH";
            this.lb_NewUAAH.Size = new System.Drawing.Size(428, 30);
            this.lb_NewUAAH.TabIndex = 0;
            this.lb_NewUAAH.Text = "Unavoidable Additional Hours";
            // 
            // eCadditionHours1
            // 
            this.eCadditionHours1.Amount = null;
            this.eCadditionHours1.BeginTime = ((short)(0));
            this.eCadditionHours1.Country = null;
            this.eCadditionHours1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eCadditionHours1.EndTime = ((short)(0));
            this.eCadditionHours1.Entity = null;
            this.eCadditionHours1.FactorBegin = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eCadditionHours1.FactorEnd = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eCadditionHours1.Location = new System.Drawing.Point(2, 2);
            this.eCadditionHours1.LookAndFeel.SkinName = "iMaginary";
            this.eCadditionHours1.Name = "eCadditionHours1";
            this.eCadditionHours1.Size = new System.Drawing.Size(428, 456);
            this.eCadditionHours1.TabIndex = 0;
            this.eCadditionHours1.Year = ((short)(1900));
            // 
            // FormUnavoidableAddHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 534);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormUnavoidableAddHours";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_NewUAAH;
        private ECadditionHours eCadditionHours1;
    }
}