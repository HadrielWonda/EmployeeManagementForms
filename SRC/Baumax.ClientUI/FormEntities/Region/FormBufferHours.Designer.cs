namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormBufferHours
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
            this.lbl_DefineBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.ucBufferHours1 = new Baumax.ClientUI.FormEntities.Region.UCBufferHours();
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
            this.panelTop.Controls.Add(this.lbl_DefineBufferHours);
            this.panelTop.Size = new System.Drawing.Size(407, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucBufferHours1);
            this.panelClient.Size = new System.Drawing.Size(407, 151);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(96, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 185);
            this.panelBottom.Size = new System.Drawing.Size(407, 40);
            // 
            // lbl_DefineBufferHours
            // 
            this.lbl_DefineBufferHours.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DefineBufferHours.Appearance.Options.UseFont = true;
            this.lbl_DefineBufferHours.Appearance.Options.UseTextOptions = true;
            this.lbl_DefineBufferHours.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_DefineBufferHours.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_DefineBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DefineBufferHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DefineBufferHours.Location = new System.Drawing.Point(2, 2);
            this.lbl_DefineBufferHours.Name = "lbl_DefineBufferHours";
            this.lbl_DefineBufferHours.Size = new System.Drawing.Size(403, 30);
            this.lbl_DefineBufferHours.TabIndex = 0;
            this.lbl_DefineBufferHours.Text = "Define buffer-hours";
            // 
            // ucBufferHours1
            // 
            this.ucBufferHours1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBufferHours1.Entity = null;
            this.ucBufferHours1.Location = new System.Drawing.Point(2, 2);
            this.ucBufferHours1.LookAndFeel.SkinName = "iMaginary";
            this.ucBufferHours1.Name = "ucBufferHours1";
            this.ucBufferHours1.RegionStore = null;
            this.ucBufferHours1.Size = new System.Drawing.Size(403, 147);
            this.ucBufferHours1.TabIndex = 0;
            // 
            // FormBufferHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 225);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormBufferHours";
            this.Text = "    ";
            this.Load += new System.EventHandler(this.FormBufferHours_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_DefineBufferHours;
        private UCBufferHours ucBufferHours1;
    }
}