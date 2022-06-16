using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Baumax.DBUpdater;

namespace Baumax.DBInstallUpdateForms
{
	public partial class FrmDBUpdate : Baumax.DBInstallUpdateForms.FrmBase
	{
		UpdateManager updateManager;
		Version dbVersion;
		bool _ConnectionON;
		string _Ñonnect;
		string _Disconnect;
		string _ConnectedToServer;

        private bool ConnectionON
        {
            get { return _ConnectionON; }
            set { setConnectionON(value); }
        }

        void setConnectionON(bool value)
        {
            _ConnectionON = value;
            enableControlsConnectionON();
        }

        void enableControlsConnectionON()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox && Controls[i].Name != "memoEdit")
                    Controls[i].Enabled = !_ConnectionON;
            }
            cbIntegratedSecurity.Enabled = !_ConnectionON;
            cbLanguage.Enabled = !_ConnectionON;
        }

        public FrmDBUpdate()
			:base()
		{
			InitializeComponent();
			getVersions();
		}

		public FrmDBUpdate(bool immediatelyRun, bool closeAfterRun)
			:base(immediatelyRun,closeAfterRun)
		{
			InitializeComponent();
			getVersions();
		}

		protected override void runOperation()
		{
			base.runOperation();
			updateDB();
		}

		protected override void enableControls(bool enabled)
		{
			base.enableControls(enabled);
			lVersions.Enabled = enabled;
			cbVersions.Enabled = enabled;
			btnConnect.Enabled = enabled;
            enableControlsConnectionON();
		}

		protected override void setLocalization()
		{
			base.setLocalization();
			btnRunOperation.Text = res.DBUpdate;
			Text = res.DBUpdate;
			lVersions.Text = res.Versions;
			_Ñonnect = res.Connect;
			_Disconnect = res.Disconnect;
			if (!ConnectionON)
				btnConnect.Text = _Ñonnect;
			else
				btnConnect.Text = _Disconnect;

		}

		private void getVersions()
		{
            System.Version[] versions = UpdateManager.GetVersionList().ToArray();
            Array.Sort(versions);
            cbVersions.Items.AddRange(versions);
			if (cbVersions.Items.Count > 0)
				cbVersions.SelectedIndex = 0;
		}

		private void connect()
		{
			try
			{
				if (updateManager == null)
				{
					if (cbIntegratedSecurity.Checked)
						updateManager = new UpdateManager(tbServerName.Text, tbDBName.Text);
					else
						updateManager = new UpdateManager(tbServerName.Text, tbDBName.Text, tbUserName.Text, tbPassword.Text);
					updateManager.OnMessage += new Baumax.DBUpdater.MessageEventHandler(onDbUpdateMessage);
					updateManager.OnDbUpdateComplete += new UpdateCompleteEventHandler(onDbUpdateComplete);
					updateManager.OnBatchComplete += new UpdateCompleteEventHandler(onDbUpdateBatchComplete);
					updateManager.OnProgressUpdateChanged += new UpdateProgressEventHangler(onDbUpdateProgress);
					updateManager.OnProgressBatchChanged += new UpdateProgressEventHangler(onDbUpdateBatchProgress);
					dbVersion = updateManager.GetDBVersion();
					_ConnectedToServer = string.Format(res.ConnectedToServer, tbServerName.Text, tbDBName.Text, dbVersion.ToString());
					addTextToMemo(_ConnectedToServer);
					ConnectionON = true;
				}
			}
			catch (Exception ex)
			{
				addTextToMemo(ex.Message);
				addTextToMemo(res.ConnectionError);
				ConnectionON = false;
			}
			
		}

		private void disconnect()
		{
			updateManager = null;
			ConnectionON = false;
			addTextToMemo(res.Disconnected);
		}

		#region update
		private void updateDB()
		{
			if (updateManager == null)
			{
				operationComplite(true);
				MessageBox.Show(res.MustConnect);
			}
			else
			{
				try
				{
					addTextToMemo(_ConnectedToServer);
					updateManager.Update((Version)cbVersions.Items[cbVersions.SelectedIndex]);
				}
				catch (Exception ex)
				{
					addTextToMemo(ex.Message);
					onDbUpdateComplete(this, new UpdateCompleteEventArgs(false));
				}
			}
		}

		private void onDbUpdateComplete(object sender, UpdateCompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new UpdateCompleteEventHandler(onDbUpdateComplete), new object[] { sender, e });
			}
			else
			{
				operationComplite(e.Success, res.FrmMain_installDBErrorMsg, res.FrmMain_installDBErrorMsgCaption);
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
				progressBarBatch.Value = 0;
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
                addTextToMemo(e.Message);
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
				progressBar.Maximum = e.MaxValue;
				progressBar.Value = e.CurrValue;
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
				progressBarBatch.Maximum = e.MaxValue;
				progressBarBatch.Value = e.CurrValue;
			}
		}

		#endregion

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (ConnectionON)
			{
				disconnect();
				btnConnect.Text = _Ñonnect;
			}
			else
			{
				connect();
				if (ConnectionON) btnConnect.Text = _Disconnect;
			}
		}

	}
}

