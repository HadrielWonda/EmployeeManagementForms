namespace Baumax.ClientUI.Admin
{
    partial class RegionSelectForm
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
            this.lbl_SelectRegions = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_SelectRegions);
            this.panelTop.Size = new System.Drawing.Size(543, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Size = new System.Drawing.Size(543, 307);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(285, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 341);
            this.panelBottom.Size = new System.Drawing.Size(543, 40);
            // 
            // lbl_SelectRegions
            // 
            this.lbl_SelectRegions.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_SelectRegions.Appearance.Options.UseFont = true;
            this.lbl_SelectRegions.Appearance.Options.UseTextOptions = true;
            this.lbl_SelectRegions.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_SelectRegions.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_SelectRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SelectRegions.Location = new System.Drawing.Point(2, 2);
            this.lbl_SelectRegions.Name = "lbl_SelectRegions";
            this.lbl_SelectRegions.Size = new System.Drawing.Size(539, 30);
            this.lbl_SelectRegions.TabIndex = 0;
            this.lbl_SelectRegions.Text = "Select Regions";
            // 
            // RegionSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 381);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "RegionSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_SelectRegions;


    }
}