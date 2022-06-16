namespace Baumax.ClientUI.FormEntities
{
    partial class FormLongTimeAbsence
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
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.ucLongTimeAbsence1 = new Baumax.ClientUI.FormEntities.UCLongTimeAbsence();
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
            this.panelTop.Controls.Add(this.lblCaption);
            this.panelTop.Size = new System.Drawing.Size(375, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucLongTimeAbsence1);
            this.panelClient.Size = new System.Drawing.Size(375, 100);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-386, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 134);
            this.panelBottom.Size = new System.Drawing.Size(375, 40);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(371, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Long-time absence";
            // 
            // ucLongTimeAbsence1
            // 
            this.ucLongTimeAbsence1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLongTimeAbsence1.Entity = null;
            this.ucLongTimeAbsence1.Location = new System.Drawing.Point(2, 2);
            this.ucLongTimeAbsence1.LookAndFeel.SkinName = "iMaginary";
            this.ucLongTimeAbsence1.Name = "ucLongTimeAbsence1";
            this.ucLongTimeAbsence1.Size = new System.Drawing.Size(371, 96);
            this.ucLongTimeAbsence1.TabIndex = 0;
            // 
            // FormLongTimeAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 174);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormLongTimeAbsence";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCaption;
        private UCLongTimeAbsence ucLongTimeAbsence1;
    }
}