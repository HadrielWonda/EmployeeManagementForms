using System;
using System.IO;
using System.Xml;
using Baumax.Contract.Interfaces;
using Baumax.Dao.Interfaces;
using Baumax.ServerState;
using Spring.Context;
using Spring.Context.Support;
using Baumax.Domain;
using System.Reflection;

namespace Baumax.AppServer.Environment
{
    public static class ServerEnvironment
    {
        private static IApplicationContext _ctx;

        private static IUserService _UserService;
        private static ICountryService _CountryService;
        private static ILanguageService _LanguageService;
        private static IEmployeeService _EmployeeService;
        private static IStoreService _StoreService;
        private static IRegionService _RegionService;
        private static IAuthorizationService _AuthService;
        private static IRoleService _RoleService;
        private static IServerStateService _ServerStateService;

        private static IDbPropertiesDao _DbProperties;

        // TODO: move constants (perhaps and config reader too) to separate class (module?)
        // these consts and read methods are currently in server.configurator and ServerEnvironment
        private const string _CurrentdbVersion = "0.0.8";
        private const string _elDatabaseSettings = "databaseSettings";
        private const string _elAdd = "add";
        private const string _attrKey = "key";
        private const string _keyConnectionString = "db.connection_string";
        private const string _attrValue = "value";

        private const string _elImportSettings = "importSettings";
        private const string _keySourceFolder = "sourceFolder";
        private const string _keyImportedFolder = "importedFolder";
        private const string _keyImportErrorsFolder = "importErrorsFolder";
        private const string _keyImportLogsFolder = "importLogsFolder";
        private const string _keyDaysFilesOutOfDate = "daysFilesOutOfDate";
        
        private static readonly object _DbManagerSyncRoot = new Object();
        private static volatile bool _SetDbManagerOn;

        private static string _connectionString;
        private static readonly Version _ServerVersion;

        private static void ReadConfig()
        {
            string appConfigFileName =
                string.Format("{0}.config", System.Reflection.Assembly.GetEntryAssembly().Location);
            if (!File.Exists(appConfigFileName))
            {
                throw new IOException(string.Format("File {0} does not exist", appConfigFileName));
            }
            XmlDocument _xmlDoc = new XmlDocument();
            _xmlDoc.Load(appConfigFileName);
            XmlNodeList xNl = _xmlDoc.GetElementsByTagName(_elDatabaseSettings);
            if ((xNl == null) || (xNl.Count < 1))
            {
                // !!! should we create any missing elements ???
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elDatabaseSettings));
            }
            string connString = null;
            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elAdd) &&
                        (xn.Attributes != null) &&
                        (xn.Attributes[_attrKey] != null) &&
                        (string.Compare(xn.Attributes[_attrKey].Value, _keyConnectionString, true) == 0))
                    {
                        connString = xn.Attributes[_attrValue].Value;
                        break;
                    }
                }
            }
            if (connString == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyConnectionString, _elDatabaseSettings));
            }
            _connectionString = connString;

            xNl = _xmlDoc.GetElementsByTagName(_elImportSettings);
            if ((xNl == null) || (xNl.Count < 1))
            {
                // !!! should we create any missing elements ???
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elImportSettings));
            }
            string sourceFolder = null;
            string importedFolder = null;
            string importErrorFolder = null;
            string importLogsFolder = null;
            int daysFilesOutOfDate = -1;

            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elAdd) &&
                        (xn.Attributes != null) &&
                        (xn.Attributes[_attrKey] != null))
                    {
                        if ((sourceFolder == null) &&
                            (string.Compare(xn.Attributes[_attrKey].Value, _keySourceFolder, true) == 0))
                        {
                            sourceFolder = xn.Attributes[_attrValue].Value;
                        }
                        else if ((importedFolder == null) &&
                                 (string.Compare(xn.Attributes[_attrKey].Value, _keyImportedFolder, true) == 0))
                        {
                            importedFolder = xn.Attributes[_attrValue].Value;
                        }
                        else if ((importLogsFolder == null) &&
                                 (string.Compare(xn.Attributes[_attrKey].Value, _keyImportLogsFolder, true) == 0))
                        {
                            importLogsFolder = xn.Attributes[_attrValue].Value;
                        }
                        else if ((importErrorFolder == null) &&
                            (string.Compare(xn.Attributes[_attrKey].Value, _keyImportErrorsFolder, true) == 0))
                        {
                            importErrorFolder = xn.Attributes[_attrValue].Value;
                        }
                        else if ((daysFilesOutOfDate == -1) &&
                            (string.Compare(xn.Attributes[_attrKey].Value, _keyDaysFilesOutOfDate, true) == 0))
                        {
                            daysFilesOutOfDate = int.Parse(xn.Attributes[_attrValue].Value);
                        }

                        if ((sourceFolder != null) && (importedFolder != null) && (importErrorFolder != null) &&
                            (importLogsFolder != null) && (daysFilesOutOfDate != -1))
                        {
                            break;
                        }
                    }
                }
            }
            if (sourceFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keySourceFolder, _elImportSettings));
            }
            if (importedFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportedFolder, _elImportSettings));
            }

            if (importErrorFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportErrorsFolder, _elImportSettings));
            }
            if (importLogsFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportLogsFolder, _elImportSettings));
            }
            if (daysFilesOutOfDate == -1)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportLogsFolder, _elImportSettings));
            }

            ImportSettings._sourceFolder = sourceFolder;
            ImportSettings._importedFolder = importedFolder;
            ImportSettings._importErrorsFolder = importErrorFolder;
            ImportSettings._importLogsFolder = importLogsFolder;
            ImportSettings._daysFilesOutOfDate = daysFilesOutOfDate;
        }

        #region BLToolkit settings

        private static void SetDbManager()
        {
            if (!_SetDbManagerOn)
            {
                lock (_DbManagerSyncRoot)
                {
                    if (!_SetDbManagerOn)
                    {
                        _SetDbManagerOn = true;
                        Rsdn.Framework.Data.DbManager.AddConnectionString(_connectionString);
                    }
                }
            }
        }

        #endregion

        public static string LogUserPrefix
        {
            get
            {
                User user = AuthorizationService.GetCurrentUser();
                return String.Format("User:{0};Time:'{1}' - ", ((user != null) ? user.LoginName : "Unknown"), DateTime.Now);
            }
        }
        public static IApplicationContext AppCtx
        {
            get
            {
                if (_ctx == null)
                {
                    _ctx = ContextRegistry.GetContext();
                }
                return _ctx;
            }
        }

        public static IAuthorizationService AuthorizationService
        {
            get
            {
                if (_AuthService == null)
                {
                    _AuthService = (IAuthorizationService) AppCtx.GetObject("authorizationService");
                }
                return _AuthService;
            }
        }

        public static IUserService UserService
        {
            get
            {
                if (_UserService == null)
                {
                    _UserService = (IUserService) AppCtx.GetObject("userService");
                }
                return _UserService;
            }

            set { _UserService = value; }
        }

        public static ICountryService CountryService
        {
            get
            {
                if (_CountryService == null)
                {
                    _CountryService = (ICountryService) AppCtx.GetObject("countryService");
                }
                return _CountryService;
            }
        }

        public static IWorkingTimePlanningService WorkingTimePlanningService
        {
            get { return EmployeeTimeService.WorkingTimePlanningService; }
        }

        public static IAbsenceTimePlanningService AbsenceTimePlanningService
        {
            get { return EmployeeTimeService.AbsenceTimePlanningService; }
        }

        public static IAbsenceTimeRecordingService AbsenceTimeRecordingService
        {
            get { return EmployeeTimeService.AbsenceTimeRecordingService; }
        }

        public static IWorkingTimeRecordingService WorkingTimeRecordingService
        {
            get { return EmployeeTimeService.WorkingTimeRecordingService; }
        }

        public static IEmployeeDayStatePlanningService EmployeeDayStatePlanningService
        {
            get { return EmployeeTimeService.EmployeeDayStatePlanningService; }
        }

        public static IEmployeeDayStateRecordingService EmployeeDayStateRecordingService
        {
            get { return EmployeeTimeService.EmployeeDayStateRecordingService; }
        }

        public static IEmployeeWeekTimePlanningService EmployeeWeekTimePlanningService
        {
            get { return EmployeeTimeService.EmployeeWeekTimePlanningService; }
        }

        public static IEmployeeWeekTimeRecordingService EmployeeWeekTimeRecordingService
        {
            get { return EmployeeTimeService.EmployeeWeekTimeRecordingService; }
        }

        public static IEmployeePlanningWorkingModelService EmployeePlanningWorkingModelService
        {
            get { return EmployeeTimeService.EmployeePlanningWorkingModelService; }
        }

        public static IEmployeeRecordingWorkingModelService EmployeeRecordingWorkingModelService
        {
            get { return EmployeeTimeService.EmployeeRecordingWorkingModelService; }
        }

        public static ILanguageService LanguageService
        {
            get
            {
                if (_LanguageService == null)
                {
                    _LanguageService = (ILanguageService) AppCtx.GetObject("languageService");
                }
                return _LanguageService;
            }
        }

        public static ICountryAdditionalHourService CountryAdditionalHourService
        {
            get { return (CountryService.CountryAdditionalHourService); }
        }

        public static IAvgAmountService AvgAmountService
        {
            get { return (CountryService.AvgAmountService); }
        }

        public static IAvgWorkingDaysInWeekService AvgWorkingDaysInWeekService
        {
            get { return (CountryService.AvgWorkingDaysInWeekService); }
        }

        public static IColouringService ColouringService
        {
            get { return CountryService.ColouringService; }
        }

        public static IFeastService FeastService
        {
            get { return CountryService.FeastService; }
        }

        public static IAbsenceService AbsenceService
        {
            get { return CountryService.AbsenceService; }
        }

        public static IWorkingModelService WorkingModelService
        {
            get { return CountryService.WorkingModelService; }
        }

        public static IYearlyWorkingDayService YearlyWorkingDayService
        {
            get { return CountryService.YearlyWorkingDayService; }
        }

        public static IEmployeeService EmployeeService
        {
            get
            {
                if (_EmployeeService == null)
                {
                    _EmployeeService = (IEmployeeService) AppCtx.GetObject("employeeService");
                }

                return _EmployeeService;
            }
        }

        public static IEmployeeRelationService EmployeeRelationService
        {
            get { return EmployeeService.EmployeeRelationService; }
        }

        public static IEmployeeContractService EmployeeContractService
        {
            get { return EmployeeService.EmployeeContractService; }
        }

        public static ILongTimeAbsenceService LongTimeAbsenceService
        {
            get { return EmployeeService.LongTimeAbsenceService; }
        }

        public static IEmployeeLongTimeAbsenceService EmployeeLongTimeAbsenceService
        {
            get { return EmployeeService.EmployeeLongTimeAbsenceService; }
        }

        public static IStoreService StoreService
        {
            get
            {
                if (_StoreService == null)
                {
                    _StoreService = (IStoreService) AppCtx.GetObject("storeService");
                }

                return _StoreService;
            }
        }

        public static IWGRService WGRService
        {
            get { return StoreService.WGRService; }
        }

        public static IHWGRService HWGRService
        {
            get { return StoreService.HWGRService; }
        }

        public static IWorldService WorldService
        {
            get { return StoreService.WorldService; }
        }

        public static IStoreToWorldService StoreToWorldService
        {
            get { return StoreService.StoreToWorldService; }
        }

        public static IWorldToHwgrService WorldToHWGRService
        {
            get { return StoreService.WorldToHWGRService; }
        }

        public static IHwgrToWgrService HwgrToWgrService
        {
            get { return StoreService.HwgrToWgrService; }
        }

        public static IStoreWorkingTimeService StoreWorkingTimeService
        {
            get { return StoreService.StoreWorkingTimeService; }
        }

        public static IStoreAdditionalHourService StoreAdditionalHourService
        {
            get { return StoreService.StoreAdditionalHourService; }
        }

        public static IBufferHoursService BufferHoursService
        {
            get { return StoreService.BufferHoursService; }
        }

        public static IBenchmarkService BenchmarkService
        {
            get { return StoreService.BenchmarkService; }
        }

        public static ITrendCorrectionService TrendCorrectionService
        {
            get { return StoreService.TrendCorrectionService; }
        }

        public static IPersonMinMaxService PersonMinMaxService
        {
            get { return StoreService.PersonMinMaxService; }
        }

        public static IRegionService RegionService
        {
            get
            {
                if (_RegionService == null)
                {
                    _RegionService = (IRegionService) AppCtx.GetObject("regionService");
                }

                return _RegionService;
            }
        }

        public static IRoleService RoleService
        {
            get
            {
                if (_RoleService == null)
                {
                    _RoleService = (IRoleService) AppCtx.GetObject("roleService");
                }

                return _RoleService;
            }
        }

        public static IServerStateService ServerStateService
        {
            get
            {
                if (_ServerStateService == null)
                {
                    _ServerStateService = (IServerStateService) AppCtx.GetObject("serverStateService");
                }

                return _ServerStateService;
            }
        }

        public static IEmployeeTimeService EmployeeTimeService
        {
            get { return EmployeeService.EmployeeTimeService; }
        }

        public static IDbPropertiesDao DbProperties
        {
            get
            {
                if (_DbProperties == null)
                {
                    _DbProperties = (IDbPropertiesDao) AppCtx.GetObject("dbPropertiesDao");
                }

                return _DbProperties;
            }
        }

        public static Version ServerVersion
        {
            get { return _ServerVersion; }
        }

        private static Version GetServerVersion()
        {
            AssemblyName contractInfo = AssemblyName.GetAssemblyName("Baumax.Contract.dll");
            return contractInfo.Version;
        }

        static ServerEnvironment()
        {
            ReadConfig();
            SetDbManager();
            _ctx = ContextRegistry.GetContext();
            _ServerVersion = GetServerVersion();
        }

        private static void CheckDBVersion ()
        {
            string dbVersion = DbProperties.GetDbVersion();
            if (_CurrentdbVersion != dbVersion)
                throw new Baumax.Contract.Exceptions.WrongDBVersionException(string.Format("DB has version: {0}. Application server can work with DB version: {1}.", dbVersion, _CurrentdbVersion));
        }

        public static void Configure()
        {
            CheckDBVersion();
            // dummy. just to make sure that static constructor is called.
#if DEBUG
            // only for testing if names in GetObject()'s parameters are correct
            TestServices();
#endif
        }

#if DEBUG
        private static void TestServices()
        {
            RoleService.Init();
            UserService.Init();
            CountryService.Init();
            LanguageService.Init();
            AvgAmountService.Init();
            CountryAdditionalHourService.Init();
            ColouringService.Init();
            FeastService.Init();
            AbsenceService.Init();
            WorkingModelService.Init();
            YearlyWorkingDayService.Init();
            EmployeeService.Init();
            EmployeeRelationService.Init();
            EmployeeContractService.Init();
            LongTimeAbsenceService.Init();
            EmployeeLongTimeAbsenceService.Init();
            StoreService.Init();
            WGRService.Init();
            HWGRService.Init();
            WorldService.Init();
            StoreToWorldService.Init();
            WorldToHWGRService.Init();
            HwgrToWgrService.Init();
            StoreWorkingTimeService.Init();
            StoreAdditionalHourService.Init();
            BufferHoursService.Init();
            BenchmarkService.Init();
            TrendCorrectionService.Init();
            PersonMinMaxService.Init();
            RegionService.Init();

            AbsenceTimePlanningService.Init();
            AbsenceTimeRecordingService.Init();
            WorkingTimePlanningService.Init();
            WorkingTimeRecordingService.Init();
            EmployeeTimeService.Init();
            AvgWorkingDaysInWeekService.Init();
            EmployeeDayStatePlanningService.Init();
            EmployeeDayStateRecordingService.Init();
            EmployeeWeekTimePlanningService.Init();
            EmployeeWeekTimeRecordingService.Init();
            EmployeePlanningWorkingModelService.Init();
            EmployeeRecordingWorkingModelService.Init();
        }
#endif

        public static class ImportSettings
        {
            internal static string _sourceFolder;
            internal static string _importedFolder;
            internal static string _importErrorsFolder;
            internal static string _importLogsFolder;
            internal static int _daysFilesOutOfDate;

            public static string ImportLogsFolder
            {
                get { return _importLogsFolder; }
            }

            public static string SourceFolder
            {
                get { return _sourceFolder; }
            }

            public static string ImportedFolder
            {
                get { return _importedFolder; }
            }

            public static string ImportErrorsFolder
            {
                get { return _importErrorsFolder; }
            }

            public static int DaysFilesOutOfDate
            {
                get { return _daysFilesOutOfDate; }
            }
        }
    }
}