using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Baumax.DBInstaller;

namespace Baumax.DBInstallUpdateForms
{
	public partial class FrmDBInstall : Baumax.DBInstallUpdateForms.FrmBase
	{
		public FrmDBInstall()
			:base()
		{
			InitializeComponent();
		}

		public FrmDBInstall(bool immediatelyRun, bool closeAfterRun)
			:base(immediatelyRun,closeAfterRun)
		{
			InitializeComponent();
		}

		protected override void runOperation()
		{
			base.runOperation();
			installDB();
		}

		protected override void setLocalization()
		{
			base.setLocalization();
			btnRunOperation.Text = res.FrmMain_sbInstall;
			Text = res.FrmMain_Text;
		}

		#region install

		private void installDB()
		{
			try
			{
				DBInstallManager dbInstaller;
				if (cbIntegratedSecurity.Checked)
					dbInstaller = new DBInstallManager(tbServerName.Text, tbDBName.Text);
				else
					dbInstaller = new DBInstallManager(tbServerName.Text, tbDBName.Text, tbUserName.Text, tbPassword.Text);
				dbInstaller.OnMessage += new MessageEventHandler(onDbInstallMessage);
				dbInstaller.OnInstallProgressChanged += new InstallProgressEventHangler(onDbInstallProgress);
				dbInstaller.OnDbInstallComplete += new InstallCompleteEventHandler(onDbInstallComplete);
				dbInstaller.OnInstallBatchProgressChanged += new InstallProgressEventHangler(onDbInstallBatchProgress);
				dbInstaller.OnInstallBatchComplete += new InstallCompleteEventHandler(onDbInstallBatchComplete);
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
				operationComplite(e.Success, res.FrmMain_installDBErrorMsg, res.FrmMain_installDBErrorMsgCaption);
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
				addTextToMemo(e.Message);
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

