namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class FormHwgrAdd
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
            this.myEntity = new Baumax.ClientUI.FormEntities.WGR.UCHwgrEntity();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(282, 34);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.myEntity);
            this.panelClient.Size = new System.Drawing.Size(282, 63);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-154, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 97);
            this.panelBottom.Size = new System.Drawing.Size(282, 40);
            // 
            // myEntity
            // 
            this.myEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEntity.Entity = null;
            this.myEntity.HWGR = null;
            this.myEntity.Location = new System.Drawing.Point(2, 2);
            this.myEntity.LookAndFeel.SkinName = "iMaginary";
            this.myEntity.Name = "myEntity";
            this.myEntity.Size = new System.Drawing.Size(278, 59);
            this.myEntity.TabIndex = 0;
            // 
            // FormHwgrAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 137);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormHwgrAdd";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        UCHwgrEntity myEntity;
        #endregion
    }
}