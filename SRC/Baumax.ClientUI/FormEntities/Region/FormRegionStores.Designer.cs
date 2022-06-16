namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormRegionStores
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
            this.lbl_RegionDetails = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblRegionName = new DevExpress.XtraEditors.LabelControl();
            this.ucRegionStores1 = new Baumax.ClientUI.FormEntities.Region.UCRegionStores();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_RegionDetails);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucRegionStores1);
            this.panelClient.Controls.Add(this.panelControl1);
            this.panelClient.Size = new System.Drawing.Size(626, 282);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 316);
            // 
            // lbl_RegionDetails
            // 
            this.lbl_RegionDetails.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_RegionDetails.Appearance.Options.UseFont = true;
            this.lbl_RegionDetails.Appearance.Options.UseTextOptions = true;
            this.lbl_RegionDetails.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_RegionDetails.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_RegionDetails.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_RegionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RegionDetails.Location = new System.Drawing.Point(2, 2);
            this.lbl_RegionDetails.Name = "lbl_RegionDetails";
            this.lbl_RegionDetails.Size = new System.Drawing.Size(622, 30);
            this.lbl_RegionDetails.TabIndex = 0;
            this.lbl_RegionDetails.Text = "Stores of region";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblRegionName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(622, 30);
            this.panelControl1.TabIndex = 0;
            // 
            // lblRegionName
            // 
            this.lblRegionName.Appearance.Options.UseTextOptions = true;
            this.lblRegionName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblRegionName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRegionName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRegionName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegionName.Location = new System.Drawing.Point(2, 2);
            this.lblRegionName.Name = "lblRegionName";
            this.lblRegionName.Size = new System.Drawing.Size(618, 26);
            this.lblRegionName.TabIndex = 0;
            this.lblRegionName.Text = "Region:";
            // 
            // ucRegionStores1
            // 
            this.ucRegionStores1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegionStores1.Entity = null;
            this.ucRegionStores1.Location = new System.Drawing.Point(2, 32);
            this.ucRegionStores1.LookAndFeel.SkinName = "iMaginary";
            this.ucRegionStores1.Name = "ucRegionStores1";
            this.ucRegionStores1.Size = new System.Drawing.Size(622, 248);
            this.ucRegionStores1.TabIndex = 1;
            // 
            // FormRegionStores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 356);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormRegionStores";
            this.Text = "     ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_RegionDetails;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblRegionName;
        private UCRegionStores ucRegionStores1;
    }
}