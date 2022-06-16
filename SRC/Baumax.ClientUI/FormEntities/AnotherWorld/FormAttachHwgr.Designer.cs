namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormAttachHwgr
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
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCAttachHwgr();
            this.lbl_AttachHWGR = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_AttachHWGR);
            this.panelTop.Size = new System.Drawing.Size(285, 34);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.uc);
            this.panelClient.Size = new System.Drawing.Size(285, 170);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 204);
            this.panelBottom.Size = new System.Drawing.Size(285, 40);
            // 
            // uc
            // 
            this.uc.Attached = null;
            this.uc.BeginTime = new System.DateTime(2007, 7, 31, 21, 32, 44, 687);
            this.uc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc.EndTime = new System.DateTime(2007, 7, 31, 21, 32, 44, 687);
            this.uc.Entity = null;
            this.uc.EntityName = null;
            this.uc.Location = new System.Drawing.Point(2, 2);
            this.uc.LookAndFeel.SkinName = "iMaginary";
            this.uc.Modified = true;
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(281, 166);
            this.uc.TabIndex = 0;
            // 
            // lbl_AttachHWGR
            // 
            this.lbl_AttachHWGR.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_AttachHWGR.Appearance.Options.UseFont = true;
            this.lbl_AttachHWGR.Appearance.Options.UseTextOptions = true;
            this.lbl_AttachHWGR.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_AttachHWGR.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_AttachHWGR.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_AttachHWGR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AttachHWGR.Location = new System.Drawing.Point(2, 2);
            this.lbl_AttachHWGR.Name = "lbl_AttachHWGR";
            this.lbl_AttachHWGR.Size = new System.Drawing.Size(281, 30);
            this.lbl_AttachHWGR.TabIndex = 0;
            this.lbl_AttachHWGR.Text = "Attach HWGR";
            // 
            // FormAttachHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 244);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAttachHwgr";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCAttachHwgr uc;
        private DevExpress.XtraEditors.LabelControl lbl_AttachHWGR;
    }
}