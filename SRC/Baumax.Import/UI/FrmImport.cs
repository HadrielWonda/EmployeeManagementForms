using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

using Baumax.Import;
using Baumax.Contract.Interfaces;
using Baumax.Localization;
using Baumax.Contract.Import;

namespace Baumax.Import.UI
{
	public partial class FrmImport : XtraForm
	{
		ICountryService _CountryService;
		IRegionService _RegionService;
		IStoreService _StoreService;
		IEmployeeService _EmployeeService;

		bool _CanClose;
        bool _NeedFileDialog;
		bool _BeenRunSuccessfully;
        ImportType _ImportFormType;
        long[] _EmployeeIDContractChanged;

        public long[] EmployeeIDContractChanged
        {
            get
            {
                if (_ImportFormType != ImportType.Employee)
                    throw new NotSupported();
                if (_EmployeeIDContractChanged == null)
                    _EmployeeIDContractChanged = new long[0];
                return _EmployeeIDContractChanged;
            }
        }


        public FrmImport(ImportParam importParam)
            : this(importParam, ImportType.All)
        {

        }

        public FrmImport(ImportParam importParam, ImportType importFormType)
        {
            InitializeComponent();
            _ImportFormType = importFormType;
            _BeenRunSuccessfully = false;
            _CountryService = importParam.CountryService;
            _RegionService = importParam.RegionService;
            _StoreService = importParam.StoreService;
            _EmployeeService = importParam.EmployeeService;
            _CanClose = true;
            _NeedFileDialog = isNeedFileDialog();
            if (!_NeedFileDialog)
                setBusinessVolumeParams(importParam, importFormType);
            LocalizeUI();
        }

        private void setBusinessVolumeParams(ImportParam importParam, ImportType importType)
        {
            string fileName;
            switch (importType)
            {
                case ImportType.ActualBusinessVolume:
                    fileName = ImportManager.BusinessVolumeActualFileSearchPattern;
                    break;
                case ImportType.TargetBusinessVolume:
                    fileName = ImportManager.BusinessVolumeTargetFileSearchPattern;
                    break;
                case ImportType.CashRegisterReceipt:
                    fileName = ImportManager.CashRegisterReceiptFileSearchPattern;
                    break;
                default:
                    goto case ImportType.ActualBusinessVolume;
            }
            ServerImportFoldersInfo serverImportFoldersInfo = importParam.StoreService.GetServerImportFoldersInfo();
            addTextToMemo(string.Format(GetLocalized("BVInformation"), serverImportFoldersInfo.SourceFolder, fileName, serverImportFoldersInfo.ImportedFolder));
            _ImportFormType = importType;

        }

		private void LocalizeUI()
		{
			Text = string.Format("{0} {1}",GetLocalized("frmText"), ImportManager.ImportName(_ImportFormType));
			btnImport.Text = GetLocalized("btnImport");
			btnSaveLog.Text = GetLocalized("btnSavelog");
            btnClose.Text = GetLocalized("importBtnClose");
		}

		public bool BeenRunSuccessfully
		{
			get { return _BeenRunSuccessfully; }
		}

		public string GetLocalized(string key)
		{
			return Localizer.GetLocalized(key);
		}

		public string GetLocalized(int key)
		{
			return Localizer.GetLocalized(key);
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			runImport();
		}

		private void runImport()
		{
			memoEdit.Text = "";
			import();
		}

		#region import

        bool isNeedFileDialog()
        {
            return _ImportFormType != ImportType.ActualBusinessVolume && _ImportFormType != ImportType.TargetBusinessVolume && _ImportFormType != ImportType.CashRegisterReceipt;
        }

        void import()
		{
            
            bool result= true;
            string fileName = "";
            if (_NeedFileDialog)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.InitialDirectory = "";
                openFileDialog.RestoreDirectory = true;
                result = openFileDialog.ShowDialog() == DialogResult.OK;
                fileName = openFileDialog.FileName;
            }
            if (result)
			{
				object[] services= null;
                ImportType importType;
                try
                {
                    if (_NeedFileDialog)
                    {
                        importType = ImportManager.FileImportType(fileName);
                        if (_ImportFormType != ImportType.All)
                        {
                            if (importType != _ImportFormType)
                            {
                                ShowMessageError(string.Format(GetLocalized("ImportFileNotContainData"), ImportManager.ImportName(_ImportFormType)));
                                return;
                            }
                        }
                    }
                    else
                        importType = _ImportFormType;
                    ImportManager importManager = createImportManager();
                    switch (importType)
                    {
                        case ImportType.Country:
                        case ImportType.Absence:
                        case ImportType.Feast:
                        case ImportType.WorkingDays:
                            services = new object[] { _CountryService };
                            break;
                        case ImportType.Region:
                            services = new object[] { _CountryService, _RegionService };
                            break;
                        case ImportType.Store:
                            services = new object[] { _CountryService, _RegionService, _StoreService };
                            break;
                        case ImportType.World:
                        case ImportType.HWGR:
                        case ImportType.WGR:
                        case ImportType.ActualBusinessVolume:
                        case ImportType.TargetBusinessVolume:
                        case ImportType.CashRegisterReceipt:
                            services = new object[] { _StoreService };
                            break;
                        case ImportType.Employee:
                        case ImportType.LongTimeAbsence:
                        case ImportType.TimePlanning:
                        case ImportType.TimeRecording:
                            services = new object[] { _EmployeeService };
                            break;
                        default:
                            ShowMessage(string.Format(GetLocalized("msgImportTypeNotRealized"), importType.ToString()));
                            break;
                    }
                    if (services != null)
                    {
                        _CanClose = false;
                        enableControls(false);
                        importManager.Import(fileName, importType, services);
                    }
                }
                catch (SameColumnsInImportFile)
                {
                    ShowMessageError(GetLocalized("msgSameColumns"));
                }
                catch (UnknownImportFile)
                {
                    ShowMessageError(GetLocalized("msgImportFileUnknown"));
                }
            }
		}

		private ImportManager createImportManager()
		{
			ImportManager importManager = new ImportManager();
			importManager.OnAllComplete += new CompleteEventHandler(OnAllComplete);
			importManager.OnAllProgressChanged += new ProgressEventHandler(OnAllProgressChanged);
			importManager.OnMessage += new MessageEventHandler(OnMessage);
			importManager.OnTaskComplete += new CompleteEventHandler(OnTaskComplete);
			importManager.OnTaskProgressChanged += new ProgressEventHandler(OnTaskProgressChanged);
			return importManager;
		}

		private void OnAllComplete(object sender, CompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new CompleteEventHandler(OnAllComplete), new object[] { sender, e });
			}
			else
			{
				_CanClose = true;
				enableControls(true);
				progressBarAll.Position = 0;
				if (e.Success)
					_BeenRunSuccessfully = true;
			}
		}

		private void ShowMessage(string message)
		{
			ShowMessage(message, MessageType.Normal);
		}

		private void ShowMessageError (string message)
		{
			ShowMessage(message, MessageType.Error);
		}

		private void ShowMessage(string message, MessageType messageType)
		{
			switch (messageType)
			{
				case MessageType.Normal:
					XtraMessageBox.Show(message,"", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				case MessageType.Error:
					XtraMessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				default:
					goto case MessageType.Normal;
			}
		}

		private void OnAllProgressChanged(object sender, ProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new ProgressEventHandler(OnAllProgressChanged), new object[] { sender, e });
			}
			else
			{
				progressBarAll.Properties.Maximum = e.MaxValue;
				progressBarAll.Position = e.CurrValue;
			}
		}

		private void OnMessage(object sender, MessageEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MessageEventHandler(OnMessage), new object[] { sender, e });
			}
			else
			{
				addTextToMemo(e.Message,e.NewLine);
			}
		}

		private void OnTaskComplete(object sender, CompleteEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new CompleteEventHandler(OnTaskComplete), new object[] { sender, e });
			}
			else
			{
				progressBar.Position = 0;
			}
		}

		private void OnTaskProgressChanged(object sender, ProgressEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new ProgressEventHandler(OnTaskProgressChanged), new object[] { sender, e });
			}
			else
			{
				progressBar.Properties.Maximum = e.MaxValue;
				progressBar.Position = e.CurrValue;
			}
		}

        private void addTextToMemo(string message)
        { 
            addTextToMemo (message,true);
        }

		private void addTextToMemo(string message, bool newLine)
		{
			string str;
            if (newLine)
                str = "\r\n";
            else
                str = " ";
			if (string.IsNullOrEmpty(memoEdit.Text))
				str = "";
			memoEdit.Text += (str + message);
			memoEdit.SelectionStart = memoEdit.Text.Length;
			memoEdit.ScrollToCaret();
		}

		#endregion

		private void saveLog()
		{
			using (SaveFileDialog fd = new SaveFileDialog())
			{
				fd.Filter = string.Format("{0} (*.log)|*.log|{1} (*.*)|*.*", GetLocalized("LogFiles"), GetLocalized("AllFiles"));
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

		private void btnSaveLog_Click(object sender, EventArgs e)
		{
			saveLog();
		}

		private void FrmImport_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_CanClose)
				e.Cancel = true;
		}

		private void enableControls(bool enabled)
		{
			memoEdit.Enabled = enabled;
			btnImport.Enabled = enabled;
			btnSaveLog.Enabled = enabled;
            btnClose.Enabled = enabled;
		}

		private enum MessageType { Normal, Error }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}