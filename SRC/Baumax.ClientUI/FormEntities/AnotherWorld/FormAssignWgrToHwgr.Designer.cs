namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormAssignWgrToHwgr
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
            this.ucEditWgrToHwgr1 = new Baumax.ClientUI.FormEntities.AnotherWorld.UCEditWgrToHwgr();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(374, 13);
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClient.Controls.Add(this.ucEditWgrToHwgr1);
            this.panelClient.Location = new System.Drawing.Point(0, 13);
            this.panelClient.Size = new System.Drawing.Size(374, 160);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1228, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 173);
            this.panelBottom.Size = new System.Drawing.Size(374, 40);
            // 
            // ucEditWgrToHwgr1
            // 
            this.ucEditWgrToHwgr1.BeginTime = new System.DateTime(((long)(0)));
            this.ucEditWgrToHwgr1.Context = null;
            this.ucEditWgrToHwgr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditWgrToHwgr1.EndTime = new System.DateTime(1, 1, 7, 0, 0, 0, 0);
            this.ucEditWgrToHwgr1.Entity = null;
            this.ucEditWgrToHwgr1.HwgrId = ((long)(0));
            this.ucEditWgrToHwgr1.Location = new System.Drawing.Point(0, 0);
            this.ucEditWgrToHwgr1.LookAndFeel.SkinName = "iMaginary";
            this.ucEditWgrToHwgr1.Name = "ucEditWgrToHwgr1";
            this.ucEditWgrToHwgr1.Size = new System.Drawing.Size(374, 160);
            this.ucEditWgrToHwgr1.TabIndex = 0;
            this.ucEditWgrToHwgr1.WgrId = ((long)(0));
            // 
            // FormAssignWgrToHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 213);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignWgrToHwgr";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCEditWgrToHwgr ucEditWgrToHwgr1;
    }
}