namespace Baumax.DBInstallerTest
{
	partial class Form1
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
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.teUserName = new DevExpress.XtraEditors.TextEdit();
			this.tePassword = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
			this.memoEdit = new DevExpress.XtraEditors.MemoEdit();
			this.progressBarBatch = new DevExpress.XtraEditors.ProgressBarControl();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.cbLang = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBarBatch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbLang.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton1.Location = new System.Drawing.Point(395, 274);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(75, 23);
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "Install DB";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// teUserName
			// 
			this.teUserName.Location = new System.Drawing.Point(12, 37);
			this.teUserName.Name = "teUserName";
			this.teUserName.Size = new System.Drawing.Size(100, 20);
			this.teUserName.TabIndex = 1;
			// 
			// tePassword
			// 
			this.tePassword.Location = new System.Drawing.Point(12, 89);
			this.tePassword.Name = "tePassword";
			this.tePassword.Properties.PasswordChar = '*';
			this.tePassword.Size = new System.Drawing.Size(100, 20);
			this.tePassword.TabIndex = 2;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 18);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(51, 13);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "User name";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 70);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(46, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Password";
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Location = new System.Drawing.Point(395, 314);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(75, 23);
			this.simpleButton2.TabIndex = 5;
			this.simpleButton2.Text = "Update DB";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 300);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(376, 18);
			this.progressBar.TabIndex = 6;
			// 
			// memoEdit
			// 
			this.memoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEdit.Location = new System.Drawing.Point(12, 126);
			this.memoEdit.Name = "memoEdit";
			this.memoEdit.Size = new System.Drawing.Size(375, 167);
			this.memoEdit.TabIndex = 7;
			// 
			// progressBarBatch
			// 
			this.progressBarBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarBatch.Location = new System.Drawing.Point(12, 321);
			this.progressBarBatch.Name = "progressBarBatch";
			this.progressBarBatch.Size = new System.Drawing.Size(376, 18);
			this.progressBarBatch.TabIndex = 8;
			// 
			// simpleButton3
			// 
			this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton3.Location = new System.Drawing.Point(395, 235);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new System.Drawing.Size(75, 23);
			this.simpleButton3.TabIndex = 9;
			this.simpleButton3.Text = "localization";
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// cbLang
			// 
			this.cbLang.Location = new System.Drawing.Point(151, 37);
			this.cbLang.Name = "cbLang";
			this.cbLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbLang.Size = new System.Drawing.Size(100, 20);
			this.cbLang.TabIndex = 10;
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(151, 18);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(47, 13);
			this.labelControl3.TabIndex = 11;
			this.labelControl3.Text = "Language";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 344);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.cbLang);
			this.Controls.Add(this.simpleButton3);
			this.Controls.Add(this.progressBarBatch);
			this.Controls.Add(this.memoEdit);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.tePassword);
			this.Controls.Add(this.teUserName);
			this.Controls.Add(this.simpleButton1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBarBatch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbLang.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.TextEdit teUserName;
		private DevExpress.XtraEditors.TextEdit tePassword;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.ProgressBarControl progressBar;
		private DevExpress.XtraEditors.MemoEdit memoEdit;
		private DevExpress.XtraEditors.ProgressBarControl progressBarBatch;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.ComboBoxEdit cbLang;
		private DevExpress.XtraEditors.LabelControl labelControl3;
	}
}

