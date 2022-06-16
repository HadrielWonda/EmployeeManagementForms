namespace Baumax.ClientUI.FormEntities.User
{
    partial class FormUser
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
            this.ctrlUser = new Baumax.ClientUI.FormEntities.User.UserCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(741, 0);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ctrlUser);
            this.panelClient.Location = new System.Drawing.Point(0, 0);
            this.panelClient.Size = new System.Drawing.Size(741, 319);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.button_OK.Location = new System.Drawing.Point(12, 6);
            this.button_OK.Size = new System.Drawing.Size(83, 23);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(483, 5);
            this.button_Cancel.Size = new System.Drawing.Size(83, 23);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 319);
            this.panelBottom.Size = new System.Drawing.Size(741, 34);
            // 
            // ctrlUser
            // 
            this.ctrlUser.Entity = null;
            this.ctrlUser.Location = new System.Drawing.Point(5, 5);
            this.ctrlUser.LookAndFeel.SkinName = "iMaginary";
            this.ctrlUser.Name = "ctrlUser";
            this.ctrlUser.Size = new System.Drawing.Size(736, 301);
            this.ctrlUser.TabIndex = 0;
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 353);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormUser";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserCtrl ctrlUser;

    }
}
