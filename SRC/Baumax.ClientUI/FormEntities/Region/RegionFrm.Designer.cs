namespace Baumax.ClientUI.FormEntities.Region
{
    partial class RegionFrm
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
            this.ctrlRegion = new Baumax.ClientUI.FormEntities.Region.RegionCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(248, 34);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 204);
            this.panelBottom.Size = new System.Drawing.Size(248, 40);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ctrlRegion);
            this.panelClient.Size = new System.Drawing.Size(248, 170);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(163, 8);
            // 
            // ctrlRegion
            // 
            this.ctrlRegion.Entity = null;
            this.ctrlRegion.Location = new System.Drawing.Point(6, 7);
            this.ctrlRegion.Name = "ctrlRegion";
            this.ctrlRegion.Size = new System.Drawing.Size(236, 160);
            this.ctrlRegion.TabIndex = 0;
            // 
            // RegionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 244);
            this.Name = "RegionFrm";
            this.Text = "Region";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RegionCtrl ctrlRegion;
    }
}