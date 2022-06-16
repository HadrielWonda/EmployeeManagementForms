namespace Baumax.DBInstallGUI
{
	partial class FrmMain
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
			this.btnInstallDB = new System.Windows.Forms.Button();
			this.btnSaveLog = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.progressBarBatch = new System.Windows.Forms.ProgressBar();
			this.memoEdit = new System.Windows.Forms.TextBox();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.lLanguage = new System.Windows.Forms.Label();
			this.tbServerName = new System.Windows.Forms.TextBox();
			this.lServerName = new System.Windows.Forms.Label();
			this.lDBName = new System.Windows.Forms.Label();
			this.tbDBName = new System.Windows.Forms.TextBox();
			this.lUserName = new System.Windows.Forms.Label();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lPassword = new System.Windows.Forms.Label();
			this.cbIntegratedSecurity = new System.Windows.Forms.CheckBox();
			this.lIntegratedSecurity = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnInstallDB
			// 
			this.btnInstallDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInstallDB.Location = new System.Drawing.Point(433, 293);
			this.btnInstallDB.Name = "btnInstallDB";
			this.btnInstallDB.Size = new System.Drawing.Size(116, 23);
			this.btnInstallDB.TabIndex = 6;
			this.btnInstallDB.Text = "Install DB";
			this.btnInstallDB.UseVisualStyleBackColor = true;
			this.btnInstallDB.Click += new System.EventHandler(this.btnInstallDB_Click);
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveLog.Location = new System.Drawing.Point(433, 322);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(116, 23);
			this.btnSaveLog.TabIndex = 7;
			this.btnSaveLog.Text = "Save log";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 293);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(412, 18);
			this.progressBar.TabIndex = 2;
			// 
			// progressBarBatch
			// 
			this.progressBarBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarBatch.Location = new System.Drawing.Point(12, 322);
			this.progressBarBatch.Name = "progressBarBatch";
			this.progressBarBatch.Size = new System.Drawing.Size(412, 18);
			this.progressBarBatch.TabIndex = 3;
			// 
			// memoEdit
			// 
			this.memoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEdit.Location = new System.Drawing.Point(12, 12);
			this.memoEdit.Multiline = true;
			this.memoEdit.Name = "memoEdit";
			this.memoEdit.ReadOnly = true;
			this.memoEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoEdit.Size = new System.Drawing.Size(412, 271);
			this.memoEdit.TabIndex = 8;
			// 
			// cbLanguage
			// 
			this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Location = new System.Drawing.Point(433, 28);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(116, 21);
			this.cbLanguage.TabIndex = 0;
			// 
			// lLanguage
			// 
			this.lLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lLanguage.AutoSize = true;
			this.lLanguage.Location = new System.Drawing.Point(430, 12);
			this.lLanguage.Name = "lLanguage";
			this.lLanguage.Size = new System.Drawing.Size(58, 13);
			this.lLanguage.TabIndex = 6;
			this.lLanguage.Text = "Language:";
			// 
			// tbServerName
			// 
			this.tbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbServerName.Location = new System.Drawing.Point(433, 75);
			this.tbServerName.Name = "tbServerName";
			this.tbServerName.Size = new System.Drawing.Size(116, 20);
			this.tbServerName.TabIndex = 1;
			// 
			// lServerName
			// 
			this.lServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lServerName.AutoSize = true;
			this.lServerName.Location = new System.Drawing.Point(430, 59);
			this.lServerName.Name = "lServerName";
			this.lServerName.Size = new System.Drawing.Size(70, 13);
			this.lServerName.TabIndex = 8;
			this.lServerName.Text = "Server name:";
			// 
			// lDBName
			// 
			this.lDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lDBName.AutoSize = true;
			this.lDBName.Location = new System.Drawing.Point(430, 107);
			this.lDBName.Name = "lDBName";
			this.lDBName.Size = new System.Drawing.Size(54, 13);
			this.lDBName.TabIndex = 9;
			this.lDBName.Text = "DB name:";
			// 
			// tbDBName
			// 
			this.tbDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDBName.Location = new System.Drawing.Point(433, 123);
			this.tbDBName.Name = "tbDBName";
			this.tbDBName.Size = new System.Drawing.Size(116, 20);
			this.tbDBName.TabIndex = 2;
			// 
			// lUserName
			// 
			this.lUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lUserName.AutoSize = true;
			this.lUserName.Location = new System.Drawing.Point(430, 158);
			this.lUserName.Name = "lUserName";
			this.lUserName.Size = new System.Drawing.Size(61, 13);
			this.lUserName.TabIndex = 11;
			this.lUserName.Text = "User name:";
			// 
			// tbUserName
			// 
			this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserName.Location = new System.Drawing.Point(433, 174);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(116, 20);
			this.tbUserName.TabIndex = 3;
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(433, 221);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(116, 20);
			this.tbPassword.TabIndex = 4;
			// 
			// lPassword
			// 
			this.lPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lPassword.AutoSize = true;
			this.lPassword.Location = new System.Drawing.Point(430, 205);
			this.lPassword.Name = "lPassword";
			this.lPassword.Size = new System.Drawing.Size(56, 13);
			this.lPassword.TabIndex = 14;
			this.lPassword.Text = "Password:";
			// 
			// cbIntegratedSecurity
			// 
			this.cbIntegratedSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbIntegratedSecurity.AutoSize = true;
			this.cbIntegratedSecurity.Location = new System.Drawing.Point(433, 269);
			this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
			this.cbIntegratedSecurity.Size = new System.Drawing.Size(15, 14);
			this.cbIntegratedSecurity.TabIndex = 5;
			this.cbIntegratedSecurity.UseVisualStyleBackColor = true;
			this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbIntegratedSecurity_CheckedChanged);
			// 
			// lIntegratedSecurity
			// 
			this.lIntegratedSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lIntegratedSecurity.AutoSize = true;
			this.lIntegratedSecurity.Location = new System.Drawing.Point(430, 253);
			this.lIntegratedSecurity.Name = "lIntegratedSecurity";
			this.lIntegratedSecurity.Size = new System.Drawing.Size(94, 13);
			this.lIntegratedSecurity.TabIndex = 15;
			this.lIntegratedSecurity.Text = "Integrated security";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 353);
			this.Controls.Add(this.lIntegratedSecurity);
			this.Controls.Add(this.cbIntegratedSecurity);
			this.Controls.Add(this.lPassword);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUserName);
			this.Controls.Add(this.lUserName);
			this.Controls.Add(this.tbDBName);
			this.Controls.Add(this.lDBName);
			this.Controls.Add(this.lServerName);
			this.Controls.Add(this.tbServerName);
			this.Controls.Add(this.lLanguage);
			this.Controls.Add(this.cbLanguage);
			this.Controls.Add(this.memoEdit);
			this.Controls.Add(this.progressBarBatch);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.btnInstallDB);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(569, 387);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Install DB";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnInstallDB;
		private System.Windows.Forms.Button btnSaveLog;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ProgressBar progressBarBatch;
		private System.Windows.Forms.TextBox memoEdit;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Label lLanguage;
		private System.Windows.Forms.TextBox tbServerName;
		private System.Windows.Forms.Label lServerName;
		private System.Windows.Forms.Label lDBName;
		private System.Windows.Forms.TextBox tbDBName;
		private System.Windows.Forms.Label lUserName;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label lPassword;
		private System.Windows.Forms.CheckBox cbIntegratedSecurity;
		private System.Windows.Forms.Label lIntegratedSecurity;
	}
}

