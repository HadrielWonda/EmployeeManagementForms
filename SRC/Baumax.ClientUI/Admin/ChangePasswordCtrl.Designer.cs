namespace Baumax.ClientUI.Admin
{
    partial class ChangePasswordCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtRetypeNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbl_RetypeNewPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbl_NewPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbl_OldPassword = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypeNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // txtRetypeNewPassword
            // 
            this.txtRetypeNewPassword.Location = new System.Drawing.Point(15, 120);
            this.txtRetypeNewPassword.Name = "txtRetypeNewPassword";
            this.txtRetypeNewPassword.Properties.PasswordChar = '*';
            this.txtRetypeNewPassword.Size = new System.Drawing.Size(217, 20);
            this.txtRetypeNewPassword.TabIndex = 2;
            // 
            // lbl_RetypeNewPassword
            // 
            this.lbl_RetypeNewPassword.Location = new System.Drawing.Point(15, 101);
            this.lbl_RetypeNewPassword.Name = "lbl_RetypeNewPassword";
            this.lbl_RetypeNewPassword.Size = new System.Drawing.Size(108, 13);
            this.lbl_RetypeNewPassword.TabIndex = 4;
            this.lbl_RetypeNewPassword.Text = "Retype New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(15, 74);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(217, 20);
            this.txtNewPassword.TabIndex = 1;
            // 
            // lbl_NewPassword
            // 
            this.lbl_NewPassword.Location = new System.Drawing.Point(15, 55);
            this.lbl_NewPassword.Name = "lbl_NewPassword";
            this.lbl_NewPassword.Size = new System.Drawing.Size(70, 13);
            this.lbl_NewPassword.TabIndex = 2;
            this.lbl_NewPassword.Text = "New Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(15, 27);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(217, 20);
            this.txtOldPassword.TabIndex = 0;
            // 
            // lbl_OldPassword
            // 
            this.lbl_OldPassword.Location = new System.Drawing.Point(15, 8);
            this.lbl_OldPassword.Name = "lbl_OldPassword";
            this.lbl_OldPassword.Size = new System.Drawing.Size(65, 13);
            this.lbl_OldPassword.TabIndex = 3;
            this.lbl_OldPassword.Text = "Old Password";
            // 
            // ChangePasswordCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRetypeNewPassword);
            this.Controls.Add(this.lbl_RetypeNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lbl_NewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lbl_OldPassword);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ChangePasswordCtrl";
            this.Size = new System.Drawing.Size(249, 154);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypeNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit txtRetypeNewPassword;
        private DevExpress.XtraEditors.LabelControl lbl_RetypeNewPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.LabelControl lbl_NewPassword;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.LabelControl lbl_OldPassword;
    }
}
