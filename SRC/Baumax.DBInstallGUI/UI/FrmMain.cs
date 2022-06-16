using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Baumax.DBIULocalization;
using Baumax.DBInstaller;

namespace Baumax.DBInstallGUI
{
	public partial class FrmMain : Form
	{
        Resources res;
        bool canClose = true;
        bool immediatelyRun = false;
        bool closeAfterRun = false;

		public FrmMain(bool immediatelyRun, bool closeAfterRun)
            :this()
        {
            this.immediatelyRun = immediatelyRun;
            this.closeAfterRun = closeAfterRun;
        }
		public FrmMain()
		{
			InitializeComponent();
		}

		private void btnSaveLog_Click(object sender, EventArgs e)
		{
			saveLog();
		}

		private void saveLog()
		{
			using (SaveFileDialog fd = new SaveFileDialog())
			{
				res = Localization.Instance.Resources;
				fd.Filter = string.Format("{0} (*.log)|*.log|{1} (*.*)|*.*", res.FrmMain_logFiles, res.FrmMain_allFiles);
				fd.FilterIndex = 0;
				if (fd.ShowDialog() == DialogResult.OK)
				{
					using (StreamWriter sw = new StreamWriter(fd.FileName, false, Encoding.Unicode))
					{
						sw.Write(memoEdit.Text);
					}
				}
			}

		}

		private void setIntegratedSecurity(bool on)
		{
			lUserName.Enabled = !on;
			tbUserName.Enabled = !on;
			lPassword.Enabled = !on;
			tbPassword.Enabled = !on;
		}

		private void cbIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
		{
			setIntegratedSecurity(cbIntegratedSecurity.Checked);
		}

		private void setLocalization()
		{
			try
			{
				Locale locale = (Locale)cbLanguage.SelectedItem;
				Localization.Instance.ResourcesLoad(locale);
			}
			catch { }
			res = Localization.Instance.Resources;
			Text = res.FrmMain_Text;
			lLanguage.Text = res.FrmMainl_cLanguage;
			btnInstallDB.Text = res.FrmMain_sbInstall;
			btnSaveLog.Text = res.FrmMain_sbSaveLog;
			lPassword.Text = res.FrmMain_Password;
			lServerName.Text = res.FrmMain_ServerName;
			lUserName.Text = res.FrmMain_UserName;
			lDBName.Text = res.FrmMain_DBName;
			lIntegratedSecurity.Text = res.FrmMain_IntegratedSecurity;
		}

		private void getLanguages()
		{
			Locale[] locales = Localization.Instance.Locales;
			for (int i = 0; i < locales.Length; i++)
				cbLanguage.Items.Add(locales[i]);
			cbLanguage.SelectedIndex = 0;
			cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);

		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
                frmLoad();
        }

        private void frmLoad()
        {
#if DEBUG
			tbServerName.Text = "SERVER\\BAUMAX";
			tbDBName.Text = "BauMax_Test11";
			cbIntegratedSecurity.Checked = true;
#endif
			getLanguages();
			setLocalization();
			if (immediatelyRun)
                installDB();
        }

		private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			setLocalization();
		}

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!canClose)
				e.Cancel = true;
		}

		private void enableControls(bool enabled)
		{
			btnInstallDB.Enabled = enabled;
			cbLanguage.Enabled = enabled;
			lLanguage.Enabled = enabled;
			btnSaveLog.Enabled = enabled;
			lServerName.Enabled = enabled;
			tbServerName.Enabled = enabled;
			lIntegratedSecurity.Enabled = enabled;
			cbIntegratedSecurity.Enabled = enabled;
			tbDBName.Enabled = enabled;
			lDBName.Enabled = enabled;
			if (!enabled)
			{
				setIntegratedSecurity(!enabled);
			}
			else
			{
				if (!cbIntegratedSecurity.Checked)
					setIntegratedSecurity(!enabled);
			}
		}

		private void btnInstallDB_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbDBName.Text))
				MessageBox.Show(res.DBNameCantBeEmpty, res.FrmMain_installDBErrorMsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				installDB();
		}

		#region install

		private void installDB()
		{
			try
			{
				canClose = false;
				enableControls(false);
				memoEdit.Focus();
				DBInstallManager dbInstaller;
				if (cbIntegratedSecurity.Checked)
					dbInstaller = new DBInstallManager(tbServerName.Text,tbDBName.Text);
				else
					dbInstaller = new DBInstallManager(tbServerName.Text, tbDBName.Text,tbUserName.Text,tbPassword.Text);
				dbInstaller.OnMessage += new MessageEventHandler(onDbInstallMessage);
				dbInstaller.OnInstallProgressChanged += new InstallProgressEventHangler(onDbInstallProgress);
				dbInstaller.OnDbInstallComplete += new InstallCompleteEventHandler(onDbInstallComplete);
				dbInstaller.OnInstallBatchProgressChanged += new InstallProgressEventHangler(onDbInstallBatchProgress);
				dbInstaller.OnInstallBatchComplete += new InstallCompleteEventHandler(onDbInstallBatchComplete);
				memoEdit.Text = "";
				dbInstaller.InstallDB();
			}
			catch (Exception ex)
			{
				memoEdit.Text = ex.Message;
				onDbInstallComplete(this, new InstallCompleteEventArgs(false));
			}
		}

		private void onDbInstallComplete(object sender, InstallCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new InstallCompleteEventHandler(onDbInstallComplete), new object[] { sender, e });
			}
			else
			{
				progressBar.Value = 0;
				canClose = true;
				enableControls(true);
				if (!e.Success)
					if (MessageBox.Show(res.FrmMain_installDBErrorMsg, res.FrmMain_installDBErrorMsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
						saveLog();
				if (immediatelyRun && closeAfterRun)
					Application.Exit();
			}
		}

		private void onDbInstallBatchComplete(object sender, InstallCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new InstallCompleteEventHandler(onDbInstallBatchComplete), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Value = 0;
			}
		}

		private void onDbInstallMessage(object sender, MessageEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MessageEventHandler(onDbInstallMessage), new object[] { sender, e });
			}
			else
			{
				string str = "\r\n";
				if (string.IsNullOrEmpty(memoEdit.Text))
					str = "";
				memoEdit.Text += (str + e.Message);
				memoEdit.SelectionStart = memoEdit.Text.Length;
				memoEdit.ScrollToCaret();
			}
		}

		private void onDbInstallProgress(object sender, InstallProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new InstallProgressEventHangler(onDbInstallProgress), new object[] { sender, e });
			}
			else
			{
				progressBar.Maximum = e.MaxValue;
				progressBar.Value = e.CurrValue;
			}
		}

		private void onDbInstallBatchProgress(object sender, InstallProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new InstallProgressEventHangler(onDbInstallBatchProgress), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Maximum = e.MaxValue;
				progressBarBatch.Value = e.CurrValue;
			}
		}

		#endregion 

	}
}