namespace Baumax.ClientUI.Admin
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.ctrlChangePassword = new Baumax.ClientUI.Admin.ChangePasswordCtrl();
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
            this.panelTop.Size = new System.Drawing.Size(262, 34);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ctrlChangePassword);
            this.panelClient.Size = new System.Drawing.Size(262, 172);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-558, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 206);
            this.panelBottom.Size = new System.Drawing.Size(262, 40);
            // 
            // ctrlChangePassword
            // 
            this.ctrlChangePassword.Entity = null;
            this.ctrlChangePassword.Location = new System.Drawing.Point(5, 5);
            this.ctrlChangePassword.LookAndFeel.SkinName = "iMaginary";
            this.ctrlChangePassword.Name = "ctrlChangePassword";
            this.ctrlChangePassword.Size = new System.Drawing.Size(249, 185);
            this.ctrlChangePassword.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(258, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "labelControl1";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 246);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ChangePasswordForm";
            this.ShowInTaskbar = true;
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

        private ChangePasswordCtrl ctrlChangePassword;
        private DevExpress.XtraEditors.LabelControl lblCaption;
    }
}