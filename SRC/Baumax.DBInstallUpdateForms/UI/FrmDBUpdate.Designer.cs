namespace Baumax.DBInstallUpdateForms
{
	partial class FrmDBUpdate
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
			this.cbVersions = new System.Windows.Forms.ComboBox();
			this.lVersions = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 366);
			// 
			// progressBarBatch
			// 
			this.progressBarBatch.Location = new System.Drawing.Point(12, 395);
			// 
			// memoEdit
			// 
			this.memoEdit.Size = new System.Drawing.Size(412, 344);
			// 
			// btnRunOperation
			// 
			this.btnRunOperation.Location = new System.Drawing.Point(433, 390);
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Location = new System.Drawing.Point(433, 361);
			// 
			// cbVersions
			// 
			this.cbVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVersions.FormattingEnabled = true;
			this.cbVersions.Location = new System.Drawing.Point(433, 304);
			this.cbVersions.Name = "cbVersions";
			this.cbVersions.Size = new System.Drawing.Size(116, 21);
			this.cbVersions.TabIndex = 16;
			// 
			// lVersions
			// 
			this.lVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lVersions.AutoSize = true;
			this.lVersions.Location = new System.Drawing.Point(430, 288);
			this.lVersions.Name = "lVersions";
			this.lVersions.Size = new System.Drawing.Size(50, 13);
			this.lVersions.TabIndex = 17;
			this.lVersions.Text = "Versions:";
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConnect.Location = new System.Drawing.Point(433, 332);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(116, 23);
			this.btnConnect.TabIndex = 18;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// FrmDBUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(561, 426);
			this.Controls.Add(this.cbVersions);
			this.Controls.Add(this.lVersions);
			this.Controls.Add(this.btnConnect);
			this.MinimumSize = new System.Drawing.Size(569, 460);
			this.Name = "FrmDBUpdate";
			this.Controls.SetChildIndex(this.btnConnect, 0);
			this.Controls.SetChildIndex(this.btnSaveLog, 0);
			this.Controls.SetChildIndex(this.btnRunOperation, 0);
			this.Controls.SetChildIndex(this.lVersions, 0);
			this.Controls.SetChildIndex(this.cbVersions, 0);
			this.Controls.SetChildIndex(this.progressBar, 0);
			this.Controls.SetChildIndex(this.progressBarBatch, 0);
			this.Controls.SetChildIndex(this.memoEdit, 0);
			this.Controls.SetChildIndex(this.tbServerName, 0);
			this.Controls.SetChildIndex(this.tbDBName, 0);
			this.Controls.SetChildIndex(this.tbUserName, 0);
			this.Controls.SetChildIndex(this.tbPassword, 0);
			this.Controls.SetChildIndex(this.cbIntegratedSecurity, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbVersions;
		private System.Windows.Forms.Label lVersions;
		private System.Windows.Forms.Button btnConnect;
	}
}
