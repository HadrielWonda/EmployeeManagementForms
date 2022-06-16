namespace Baumax.Client
{
    partial class AboutForm
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
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.hyperLink = new DevExpress.XtraEditors.HyperLinkEdit();
            this.lb_mess = new DevExpress.XtraEditors.LabelControl();
            this.lb_InstalledComponent = new DevExpress.XtraEditors.LabelControl();
            this.lb_copyright = new DevExpress.XtraEditors.LabelControl();
            this.lb_ver = new DevExpress.XtraEditors.ListBoxControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(392, 288);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.Click += new System.EventHandler(this.btnOK_click);
            // 
            // logo
            // 
            this.logo.EditValue = global::Baumax.Client.Properties.Resources.logo;
            this.logo.Location = new System.Drawing.Point(272, 187);
            this.logo.Name = "logo";
            this.logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.logo.Properties.ReadOnly = true;
            this.logo.Properties.ShowMenu = false;
            this.logo.Size = new System.Drawing.Size(195, 75);
            this.logo.TabIndex = 1;
            // 
            // hyperLink
            // 
            this.hyperLink.EditValue = "http://www.specific-group.com";
            this.hyperLink.Location = new System.Drawing.Point(272, 163);
            this.hyperLink.Name = "hyperLink";
            this.hyperLink.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLink.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLink.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLink.Size = new System.Drawing.Size(189, 18);
            this.hyperLink.TabIndex = 2;
            // 
            // lb_mess
            // 
            this.lb_mess.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lb_mess.Appearance.Options.UseFont = true;
            this.lb_mess.Location = new System.Drawing.Point(12, 27);
            this.lb_mess.Name = "lb_mess";
            this.lb_mess.Size = new System.Drawing.Size(316, 16);
            this.lb_mess.TabIndex = 4;
            this.lb_mess.Text = "Manpower planning tool for bauMax chain stores";
            // 
            // lb_InstalledComponent
            // 
            this.lb_InstalledComponent.Location = new System.Drawing.Point(12, 56);
            this.lb_InstalledComponent.Name = "lb_InstalledComponent";
            this.lb_InstalledComponent.Size = new System.Drawing.Size(106, 13);
            this.lb_InstalledComponent.TabIndex = 5;
            this.lb_InstalledComponent.Text = "Installed components:";
            // 
            // lb_copyright
            // 
            this.lb_copyright.LineVisible = true;
            this.lb_copyright.Location = new System.Drawing.Point(272, 144);
            this.lb_copyright.Name = "lb_copyright";
            this.lb_copyright.Size = new System.Drawing.Size(137, 13);
            this.lb_copyright.TabIndex = 6;
            this.lb_copyright.Text = "© Specific-Group 2007-2008";
            // 
            // lb_ver
            // 
            this.lb_ver.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lb_ver.Location = new System.Drawing.Point(12, 75);
            this.lb_ver.Name = "lb_ver";
            this.lb_ver.Size = new System.Drawing.Size(234, 187);
            this.lb_ver.TabIndex = 8;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Baumax.Client.Properties.Resources.logo_baumax_neu;
            this.pictureEdit1.Location = new System.Drawing.Point(272, 75);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(195, 63);
            this.pictureEdit1.TabIndex = 9;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btn_OK;
            this.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.Appearance.BorderColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 328);
            this.ControlBox = false;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.lb_ver);
            this.Controls.Add(this.lb_copyright);
            this.Controls.Add(this.lb_InstalledComponent);
            this.Controls.Add(this.lb_mess);
            this.Controls.Add(this.hyperLink);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(489, 360);
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Specific-Group Baumax";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLink;
        private DevExpress.XtraEditors.LabelControl lb_mess;
        private DevExpress.XtraEditors.LabelControl lb_InstalledComponent;
        private DevExpress.XtraEditors.LabelControl lb_copyright;
        private DevExpress.XtraEditors.ListBoxControl lb_ver;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
