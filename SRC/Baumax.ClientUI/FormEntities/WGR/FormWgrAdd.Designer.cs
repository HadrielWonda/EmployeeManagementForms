namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class FormWgrAdd
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
            this.entity = new Baumax.ClientUI.FormEntities.WGR.UCWgrEntity();
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
            this.panelClient.Controls.Add(this.entity);
            this.panelClient.Size = new System.Drawing.Size(282, 63);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-505, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 97);
            this.panelBottom.Size = new System.Drawing.Size(282, 40);
            // 
            // entity
            // 
            this.entity.Entity = null;
            this.entity.Location = new System.Drawing.Point(0, 0);
            this.entity.LookAndFeel.SkinName = "iMaginary";
            this.entity.Name = "entity";
            this.entity.Size = new System.Drawing.Size(280, 55);
            this.entity.TabIndex = 0;
            this.entity.WGR = null;
            // 
            // FormWgrAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 137);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormWgrAdd";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        UCWgrEntity entity;
    }
}