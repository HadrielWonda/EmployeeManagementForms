namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormAssignHwgrToWorld
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
            this.ucEditWorldToHwgr1 = new Baumax.ClientUI.FormEntities.AnotherWorld.UCEditWorldToHwgr();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Size = new System.Drawing.Size(398, 10);
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClient.Controls.Add(this.ucEditWorldToHwgr1);
            this.panelClient.Location = new System.Drawing.Point(0, 10);
            this.panelClient.Size = new System.Drawing.Size(398, 160);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-2020, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 170);
            this.panelBottom.Size = new System.Drawing.Size(398, 40);
            // 
            // ucEditWorldToHwgr1
            // 
            this.ucEditWorldToHwgr1.BeginTime = new System.DateTime(((long)(0)));
            this.ucEditWorldToHwgr1.Context = null;
            this.ucEditWorldToHwgr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditWorldToHwgr1.EndTime = new System.DateTime(((long)(0)));
            this.ucEditWorldToHwgr1.Entity = null;
            this.ucEditWorldToHwgr1.HwgrId = ((long)(0));
            this.ucEditWorldToHwgr1.Location = new System.Drawing.Point(0, 0);
            this.ucEditWorldToHwgr1.LookAndFeel.SkinName = "iMaginary";
            this.ucEditWorldToHwgr1.Name = "ucEditWorldToHwgr1";
            this.ucEditWorldToHwgr1.Size = new System.Drawing.Size(398, 160);
            this.ucEditWorldToHwgr1.TabIndex = 0;
            this.ucEditWorldToHwgr1.WorldId = ((long)(0));
            // 
            // FormAssignHwgrToWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 210);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignHwgrToWorld";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCEditWorldToHwgr ucEditWorldToHwgr1;
    }
}