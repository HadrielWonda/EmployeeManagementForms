namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FormFeast
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
            this.feastEntityControl1 = new Baumax.ClientUI.FormEntities.Country.FeastEntityControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(464, 34);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 246);
            this.panelBottom.Size = new System.Drawing.Size(464, 40);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.feastEntityControl1);
            this.panelClient.Size = new System.Drawing.Size(464, 212);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(204, 8);
            // 
            // feastEntityControl1
            // 
            this.feastEntityControl1.AppCtx = null;
            this.feastEntityControl1.Country = null;
            this.feastEntityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feastEntityControl1.Location = new System.Drawing.Point(2, 2);
            this.feastEntityControl1.Modified = false;
            this.feastEntityControl1.Name = "feastEntityControl1";
            this.feastEntityControl1.Size = new System.Drawing.Size(460, 208);
            this.feastEntityControl1.TabIndex = 0;
            // 
            // FormFeast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(464, 286);
            this.Name = "FormFeast";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FeastEntityControl feastEntityControl1;
    }
}
