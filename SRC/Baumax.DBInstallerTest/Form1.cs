using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Baumax.DBInstaller;
using Baumax.DBUpdater;
using Baumax.DBIULocalization;

namespace Baumax.DBInstallerTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			//test();
			installDB();
		}
		#region install
		private void test()
		{
		}

		private void installDB()
		{
			try
			{
				Locale locale = (Locale)cbLang.SelectedItem;
				Localization.Instance.ResourcesLoad(locale);
			}
			catch { }
			//DBInstallManager dbInstaller = new DBInstallManager("SERVER\\BAUMAX", "BauMax_Test", teUserName.Text, tePassword.Text);
			DBInstallManager dbInstaller = new DBInstallManager("SERVER\\BAUMAX", "BauMax_Test");
			dbInstaller.OnMessage += new Baumax.DBInstaller.MessageEventHandler(onDbInstallMessage);
			dbInstaller.OnInstallProgressChanged += new InstallProgressEventHangler(onDbInstallProgress);
			dbInstaller.OnDbInstallComplete += new InstallCompleteEventHandler(onDbInstallComplete);
			dbInstaller.OnInstallBatchProgressChanged += new InstallProgressEventHangler(onDbInstallBatchProgress);
			dbInstaller.OnInstallBatchComplete += new InstallCompleteEventHandler(onDbInstallBatchComplete);
			memoEdit.Text = "";
			dbInstaller.InstallDB();
		}

		private void onDbInstallComplete(object sender, InstallCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBInstaller.InstallCompleteEventHandler(onDbInstallComplete), new object[] { sender, e });
			}
			else
			{
				progressBar.Position = 0;
			}
		}

		private void onDbInstallBatchComplete(object sender, InstallCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBInstaller.InstallCompleteEventHandler(onDbInstallBatchComplete), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Position = 0;
			}
		}

		private void onDbInstallMessage(object sender, DBInstaller.MessageEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBInstaller.MessageEventHandler(onDbInstallMessage), new object[] { sender, e });
			}
			else
			{
				string str = "\r\n";
				if (string.IsNullOrEmpty(memoEdit.Text))
					str = "";
				memoEdit.Text += (str + e.Message);
			}
		}

		private void onDbInstallProgress(object sender, InstallProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBInstaller.InstallProgressEventHangler(onDbInstallProgress), new object[] { sender, e });
			}
			else
			{
				progressBar.Properties.Maximum = e.MaxValue;
				progressBar.Position = e.CurrValue;
			}
		}

		private void onDbInstallBatchProgress(object sender, InstallProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBInstaller.InstallProgressEventHangler(onDbInstallBatchProgress), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Properties.Maximum = e.MaxValue;
				progressBarBatch.Position = e.CurrValue;
			}
		}
		


		#endregion 
		
		private void simpleButton2_Click(object sender, EventArgs e)
		{
			updateDB();
		}

		#region update 
		private void updateDB()
		{
			try
			{
				Locale locale = (Locale)cbLang.SelectedItem;
				Localization.Instance.ResourcesLoad(locale);
			}
			catch { }
			UpdateManager updateManager = new UpdateManager("SERVER\\BAUMAX", "BauMax_Test");
			updateManager.OnMessage += new Baumax.DBUpdater.MessageEventHandler(onDbUpdateMessage);
			updateManager.OnDbUpdateComplete += new UpdateCompleteEventHandler(onDbUpdateComplete);
			updateManager.OnBatchComplete += new UpdateCompleteEventHandler(onDbUpdateBatchComplete);
			updateManager.OnProgressUpdateChanged += new UpdateProgressEventHangler(onDbUpdateProgress);
			updateManager.OnProgressBatchChanged += new UpdateProgressEventHangler(onDbUpdateBatchProgress);
			memoEdit.Text = "";
			updateManager.Update(new Version("0.0.5"));
		}

		private void onDbUpdateComplete(object sender, UpdateCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new UpdateCompleteEventHandler(onDbUpdateComplete), new object[] { sender, e });
			}
			else
			{
				progressBar.Position = 0;
			}
		}

		private void onDbUpdateBatchComplete(object sender, UpdateCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new UpdateCompleteEventHandler(onDbUpdateBatchComplete), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Position = 0;
			}
		}

		private void onDbUpdateMessage(object sender, DBUpdater.MessageEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new DBUpdater.MessageEventHandler(onDbUpdateMessage), new object[] { sender, e });
			}
			else
			{
				string str = "\r\n";
				if (string.IsNullOrEmpty(memoEdit.Text))
					str = "";
				memoEdit.Text += (str + e.Message);
			}
		}

		private void onDbUpdateProgress(object sender, UpdateProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new UpdateProgressEventHangler(onDbUpdateProgress), new object[] { sender, e });
			}
			else
			{
				progressBar.Properties.Maximum = e.MaxValue;
				progressBar.Position = e.CurrValue;
			}
		}

		private void onDbUpdateBatchProgress(object sender, UpdateProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new UpdateProgressEventHangler(onDbUpdateBatchProgress), new object[] { sender, e });
			}
			else
			{
				progressBarBatch.Properties.Maximum = e.MaxValue;
				progressBarBatch.Position = e.CurrValue;
			}
		}

		#endregion

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			Locale locale = Localization.Instance.Locales[1];
			Localization.Instance.ResourcesLoad(locale);
			MessageBox.Show(Localization.Instance.Resources.CantConnect);
		}

		private void getLanguages()
		{ 
			Locale[] locales= Localization.Instance.Locales;
			for(int i= 0; i < locales.Length; i++)
				cbLang.Properties.Items.Add(locales[i]);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			getLanguages();
		}
	}
}