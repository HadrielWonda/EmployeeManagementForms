namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FormFeast
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
            this.feastEntityControl1 = new Baumax.ClientUI.FormEntities.Country.FeastEntityControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Size = new System.Drawing.Size(469, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.feastEntityControl1);
            this.panelClient.Size = new System.Drawing.Size(469, 208);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-95, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 242);
            this.panelBottom.Size = new System.Drawing.Size(469, 40);
            // 
            // feastEntityControl1
            // 
            this.feastEntityControl1.Country = null;
            this.feastEntityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feastEntityControl1.Entity = null;
            this.feastEntityControl1.Location = new System.Drawing.Point(2, 2);
            this.feastEntityControl1.LookAndFeel.SkinName = "iMaginary";
            this.feastEntityControl1.Name = "feastEntityControl1";
            this.feastEntityControl1.Size = new System.Drawing.Size(465, 204);
            this.feastEntityControl1.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(465, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Feasts";
            // 
            // FormFeast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(469, 282);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormFeast";
            this.Text = "    ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFeast_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FeastEntityControl feastEntityControl1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
    }
}
