namespace Baumax.ClientUI.FormEntities.Language
{
    partial class FormLanguage2
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
            this.ucLanguageEntity1 = new Baumax.ClientUI.FormEntities.Language.UCLanguageEntity();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCaption);
            this.panelTop.Size = new System.Drawing.Size(269, 34);
            this.panelTop.TabIndex = 0;
            this.panelTop.Visible = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 104);
            this.panelBottom.Size = new System.Drawing.Size(269, 40);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucLanguageEntity1);
            this.panelClient.Size = new System.Drawing.Size(269, 70);
            // 
            // button_OK
            // 
            this.button_OK.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(177, 8);
            this.button_Cancel.TabIndex = 1;
            // 
            // ucLanguageEntity1
            // 
            this.ucLanguageEntity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLanguageEntity1.Entity = null;
            this.ucLanguageEntity1.Language = null;
            this.ucLanguageEntity1.Location = new System.Drawing.Point(2, 2);
            this.ucLanguageEntity1.Name = "ucLanguageEntity1";
            this.ucLanguageEntity1.Size = new System.Drawing.Size(265, 66);
            this.ucLanguageEntity1.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(265, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Language";
            // 
            // FormLanguage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 144);
            this.ControlBox = true;
            this.Name = "FormLanguage2";
            this.Text = "     ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCLanguageEntity ucLanguageEntity1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
    }
}