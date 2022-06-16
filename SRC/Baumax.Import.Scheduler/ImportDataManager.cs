using System;
using Common.Logging;
using Baumax.Contract.Interfaces;
using Baumax.Import.Util;
using System.Threading;
using System.IO;
using System.Collections;
using Baumax.AppServer.Environment;
using Baumax.Contract.Exceptions;

namespace Baumax.Import.Scheduler
{
    public class ImportDataManager
    {
        const string _ImportSeparatorString= "-----------------------------------------------------";
        const string _ImportStartMessage = "'{0}' import started";
        const string _ImportCompleteMessage = "'{0}' import completed {1}";
        static readonly ILog log;

        ICountryService _CountryService;
        IRegionService _RegionService;
        IStoreService _StoreService;
        IEmployeeService _EmployeeService;

        string _SourceFolder;
        string _ImportedFolder;
        string _ImportErrorsFolder;
        string _LogsFolder;
        static bool _ImportAllRunning;
        bool _ImportFileRunning;
        bool _ImportCompleteWithErrors;
        bool _CurrentImportResult;

        ImportManager _ImportManager;
        ImportType _CurrImportType;

        static object _SyncRoot = new Object();
        static object _SyncImportAllRunning = new Object();
        object _SyncImportFileRunning = new Object();
        object _SyncImportCompleteWithErrors = new Object();
        object _SyncCurrentImportResult = new Object();

        CIComparer _CIComparer;

        string[] _LogFileNames;

        static bool ImportAllRunning 
        {
            set
            {
                if (_ImportAllRunning != value)
                {
                    lock (_SyncImportAllRunning)
                    {
                        if (_ImportAllRunning != value)
                        {
                            _ImportAllRunning = value;
                        }
                    }
                }
            }
            get 
            {
                return _ImportAllRunning;   
            }
        }

        bool ImportFileRunning
        {
            set
            {
                lock (_SyncImportFileRunning)
                {
                    if (_ImportFileRunning != value)
                    {
                        _ImportFileRunning = value;
                    }
                }
            }
            get
            {
                return _ImportFileRunning;
            }
        }

        bool ImportCompleteWithErrors
        {
            set
            {
                lock (_SyncImportCompleteWithErrors)
                {
                    if (_ImportCompleteWithErrors != value)
                    {
                        _ImportCompleteWithErrors = value;
                    }
                }
            }
            get
            {
                return _ImportCompleteWithErrors;
            }
        }

        bool CurrentImportResult
        {
            set 
            {
                lock (_SyncCurrentImportResult)
                {
                    if (_CurrentImportResult != value)
                    {
                        _CurrentImportResult = value;
                    }
                }
            }
            get
            {
                return _CurrentImportResult;
            }
        }

        #region Contructors

        static ImportDataManager()
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private static volatile ImportDataManager _ImportDataManager;

        static public ImportDataManager Instance
		{
			get
			{
				if (_ImportDataManager == null)
				{
					lock (_SyncRoot)
					{
						if (_ImportDataManager == null)
						{
                            _ImportDataManager = new ImportDataManager();
						}
					}
				}
				return _ImportDataManager;
			}
		}

        private ImportDataManager ()
            :this
            (
                ServerEnvironment.ImportSettings.SourceFolder,
                ServerEnvironment.ImportSettings.ImportedFolder,
                ServerEnvironment.ImportSettings.ImportErrorsFolder,
                ServerEnvironment.ImportSettings.ImportLogsFolder,
                ServerEnvironment.CountryService,
                ServerEnvironment.RegionService,
                ServerEnvironment.StoreService,
                ServerEnvironment.EmployeeService
            )
        {

        }

        private ImportDataManager(string sourceFolder, string importedFolder, string importErrorsFolder, string logsFolder, ICountryService countryService, IRegionService regionService, IStoreService storeService, IEmployeeService employeeService)
        {
            _SourceFolder = sourceFolder;
            _ImportedFolder = importedFolder;
            _ImportErrorsFolder = importErrorsFolder;
            _LogsFolder = logsFolder;
            _CountryService = countryService;
            _RegionService = regionService;
            _StoreService = storeService;
            _EmployeeService = employeeService;

            _CIComparer = new CIComparer();
            _LogFileNames = GetImportLogFileNames();
            _ImportManager = CreateImportManager();
        }

        #endregion

        private object[] GetServicesArray(ImportType importType)
        {
            object[] services; 
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
                    throw new NotSupported();
            }
            return services;
        }

        public void Import(ImportType importType)
        {
            if (importType == ImportType.All)
                throw new NotSupported();
            if (ImportAllRunning)
                throw new AnotherImportRunning ();
            else
                ImportAllRunning = true;
            try
            {
                log.Info(string.Format(_ImportStartMessage, importType.ToString ()));
                ImportCompleteWithErrors = false;
                _CurrImportType = importType;
                string[] files = GetImportFilesList(_SourceFolder, importType);
                if (files.Length > 0)
                {
                    ImportManagerEventsSubscribe();
                    object[] services = GetServicesArray(importType);
                    try
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            ImportFileRunning = true;
                            _ImportManager.Import(files[i], importType, services);
                            while (ImportFileRunning)
                            {
                                Thread.Sleep(1000);
                            }
                            MoveImportedFileIntoFolder(CurrentImportResult, files[i]);
                        }
                        AddTextToImportLog(_ImportSeparatorString, true);
                        if (ImportCompleteWithErrors)
                        {
                            log.Info(string.Format(_ImportCompleteMessage, importType.ToString(),"with error(s)."));
                            throw new ImportCompleteWithErrors();
                        }
                        else
                        {
                            log.Info(string.Format(_ImportCompleteMessage, importType.ToString(), "successfully."));
                        }
                    }
                    finally
                    {
                        ImportManagerEventsUnSubscribe();
                    }
                }
            }
            finally
            {
                ImportAllRunning = false;
            }
        }

        private void MoveImportedFileIntoFolder(bool importSuccess, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            string folderName;
            if (importSuccess)
                folderName = _ImportedFolder;
            else
                folderName = _ImportErrorsFolder;
            ImportUtil.MoveFilesInFolder(folderName, new string[] { fileName });
        }

        private void ImportManagerEventsSubscribe()
        {
            _ImportManager.OnAllComplete += new CompleteEventHandler(OnAllComplete);
            _ImportManager.OnMessage += new MessageEventHandler(OnMessage);
        }

        private void ImportManagerEventsUnSubscribe()
        {
            _ImportManager.OnAllComplete -= new CompleteEventHandler(OnAllComplete);
            _ImportManager.OnMessage -= new MessageEventHandler(OnMessage);
        }


        private ImportManager CreateImportManager()
        {
            ImportManager importManager = new ImportManager();
            return importManager;
        }
        
        private void OnAllComplete(object sender, CompleteEventArgs e)
        {
            CurrentImportResult = e.Success;
            if (!e.Success)
                ImportCompleteWithErrors = true;
            ImportFileRunning = false;
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            AddTextToImportLog(e.Message, e.NewLine);
        }

        private void AddTextToImportLog(string message, bool newLine)
        {
            string fileName = GetLogFileName(_CurrImportType);
            Util.AddTextToLogFile(fileName, message, newLine);
        }

        private string GetLogFileName(ImportType importType)
        {
            return _LogFileNames[(int)importType];
        }

        private string[] GetImportLogFileNames ()
        {
            string[] files = ImportUtil.GetImportLogFileNames();
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.Combine(_LogsFolder, string.Format("{0}.log",files[i]));
            return files;
        }

        private string[] GetImportFilesList(string sourceFolder, ImportType importType)
        {
            string[] files;
            switch (importType)
            {
                case ImportType.CashRegisterReceipt:
                case ImportType.ActualBusinessVolume:
                case ImportType.TargetBusinessVolume:
                    files = new string[1];
                    files[0] = "";
                    break;
                default:
                    files = ImportUtil.GetImportFilesList(_SourceFolder, importType);
                    break;
            }
            Array.Sort(files, _CIComparer);
            return files;
        }

        private class CIComparer : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(x, y));
            }
        }


    }
}
