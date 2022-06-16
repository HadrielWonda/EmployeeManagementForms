namespace Baumax.Client
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Password = new DevExpress.XtraEditors.LabelControl();
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            this.lbl_LoginName = new DevExpress.XtraEditors.LabelControl();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtState = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.tePassword);
            this.groupControl.Controls.Add(this.lbl_Password);
            this.groupControl.Controls.Add(this.teLogin);
            this.groupControl.Controls.Add(this.lbl_LoginName);
            this.groupControl.Location = new System.Drawing.Point(71, 12);
            this.groupControl.Name = "groupControl";
            this.groupControl.ShowCaption = false;
            this.groupControl.Size = new System.Drawing.Size(328, 102);
            this.groupControl.TabIndex = 0;
            // 
            // tePassword
            // 
            this.tePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tePassword.EditValue = "";
            this.tePassword.Location = new System.Drawing.Point(5, 69);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.MaxLength = 255;
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(318, 20);
            this.tePassword.TabIndex = 7;
            // 
            // lbl_Password
            // 
            this.lbl_Password.Location = new System.Drawing.Point(5, 50);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(46, 13);
            this.lbl_Password.TabIndex = 6;
            this.lbl_Password.Text = "Password";
            // 
            // teLogin
            // 
            this.teLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teLogin.Location = new System.Drawing.Point(5, 24);
            this.teLogin.Name = "teLogin";
            this.teLogin.Properties.MaxLength = 50;
            this.teLogin.Size = new System.Drawing.Size(318, 20);
            this.teLogin.TabIndex = 5;
            // 
            // lbl_LoginName
            // 
            this.lbl_LoginName.Location = new System.Drawing.Point(5, 5);
            this.lbl_LoginName.Name = "lbl_LoginName";
            this.lbl_LoginName.Size = new System.Drawing.Size(25, 13);
            this.lbl_LoginName.TabIndex = 4;
            this.lbl_LoginName.Text = "Login";
            // 
            // btn_Login
            // 
            this.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Login.Location = new System.Drawing.Point(235, 161);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "Login";
            this.btn_Login.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btn_Exit.Location = new System.Drawing.Point(316, 161);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Baumax.Client.Properties.Resources.keys;
            this.pictureEdit1.Location = new System.Drawing.Point(8, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(57, 102);
            this.pictureEdit1.TabIndex = 3;
            // 
            // txtState
            // 
            this.txtState.Enabled = false;
            this.txtState.Location = new System.Drawing.Point(13, 121);
            this.txtState.Name = "txtState";
            this.txtState.Properties.AcceptsReturn = false;
            this.txtState.Properties.ReadOnly = true;
            this.txtState.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtState.Size = new System.Drawing.Size(386, 34);
            this.txtState.TabIndex = 4;
            // 
            // LoginFrm
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(403, 190);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.groupControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bauMax Login";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.LabelControl lbl_Password;
        private DevExpress.XtraEditors.TextEdit teLogin;
        private DevExpress.XtraEditors.LabelControl lbl_LoginName;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private DevExpress.XtraEditors.SimpleButton btn_Exit;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.MemoEdit txtState;
    }
}