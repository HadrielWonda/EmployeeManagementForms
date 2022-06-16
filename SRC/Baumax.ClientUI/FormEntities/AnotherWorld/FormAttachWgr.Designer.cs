namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormAttachWgr
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
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCAttachWgr();
            this.lbl_AttachWGR = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_AttachWGR);
            this.panelTop.Size = new System.Drawing.Size(361, 34);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.uc);
            this.panelClient.Size = new System.Drawing.Size(361, 196);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 6);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-544, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 230);
            this.panelBottom.Size = new System.Drawing.Size(361, 40);
            // 
            // uc
            // 
            this.uc.Attached = null;
            this.uc.BeginTime = new System.DateTime(2007, 7, 31, 12, 18, 58, 861);
            this.uc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc.EndTime = new System.DateTime(((long)(0)));
            this.uc.Entity = null;
            this.uc.EntityName = null;
            this.uc.Location = new System.Drawing.Point(2, 2);
            this.uc.LookAndFeel.SkinName = "iMaginary";
            this.uc.Modified = true;
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(357, 192);
            this.uc.TabIndex = 0;
            // 
            // lbl_AttachWGR
            // 
            this.lbl_AttachWGR.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_AttachWGR.Appearance.Options.UseFont = true;
            this.lbl_AttachWGR.Appearance.Options.UseTextOptions = true;
            this.lbl_AttachWGR.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_AttachWGR.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_AttachWGR.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_AttachWGR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AttachWGR.Location = new System.Drawing.Point(2, 2);
            this.lbl_AttachWGR.Name = "lbl_AttachWGR";
            this.lbl_AttachWGR.Size = new System.Drawing.Size(357, 30);
            this.lbl_AttachWGR.TabIndex = 1;
            this.lbl_AttachWGR.Text = "Attach WGR";
            // 
            // FormAttachWgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 270);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAttachWgr";
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

        private UCAttachWgr uc;
        private DevExpress.XtraEditors.LabelControl lbl_AttachWGR;

    }
}