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

namespace Baumax.DBInstallUpdateForms
{
	public partial class FrmBase : Form
	{
        protected Resources res;
        bool canClose = true;
        bool immediatelyRun = false;
        bool closeAfterRun = false;

		public FrmBase(bool immediatelyRun, bool closeAfterRun)
            :this()
        {
            this.immediatelyRun = immediatelyRun;
            this.closeAfterRun = closeAfterRun;
        }
		public FrmBase()
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

		protected virtual void setLocalization()
		{
			try
			{
				Locale locale = (Locale)cbLanguage.SelectedItem;
				Localization.Instance.ResourcesLoad(locale);
			}
			catch { }
			res = Localization.Instance.Resources;
			lLanguage.Text = res.FrmMainl_cLanguage;
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
			tbServerName.Text = "DEVSERVER\\BAUMAX";
            tbDBName.Text = "baumax_db";
			cbIntegratedSecurity.Checked = true;
#endif
			getLanguages();
			setLocalization();
			if (immediatelyRun)
				runOperation();
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

		protected virtual void enableControls(bool enabled)
		{
			btnRunOperation.Enabled = enabled;
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

		protected virtual void runOperation()
		{
			canClose = false;
			enableControls(false);
			memoEdit.Focus();
			memoEdit.Text = "";
		}

		private void btnInstallDB_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbDBName.Text))
				MessageBox.Show(res.DBNameCantBeEmpty, res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				runOperation();
		}

		protected void operationComplite(bool success)
		{
			operationComplite(success, "", "");
		}

		protected void operationComplite(bool success, string dbErrorMsg, string dbErrorMsgCaption)
		{
			progressBar.Value = 0;
			canClose = true;
			enableControls(true);
			if (!success)
				if (MessageBox.Show(dbErrorMsg, dbErrorMsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
					saveLog();
			if (immediatelyRun && closeAfterRun)
				Application.Exit();
		}

		protected void addTextToMemo(string message)
		{
			string str = "\r\n";
			if (string.IsNullOrEmpty(memoEdit.Text))
				str = "";
			memoEdit.Text += (str + message);
			memoEdit.SelectionStart = memoEdit.Text.Length;
			memoEdit.ScrollToCaret();
		}
	}
}