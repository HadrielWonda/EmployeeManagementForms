using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Baumax.Contract;
using Baumax.ServerState;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Spring.Context;
using Baumax.Contract.Interfaces;
using Spring.Context.Support;
using Baumax.Import;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Baumax.Environment
{
    // !important: unfortunately, all services require to call "Init" method AFTER login.
    // otherwise it is impossible to subscribe server-services' events because of
    // security violation. so please call manually "Init" method for EVERY 
    // service (including nested ones) in "InitServices" method. thanx.

    public static class ClientEnvironment
    {
        private static ImportParam _ImportParam;
        private static IUserService _UserService;
        private static ICountryService _CountryService;
        private static ILanguageService _LanguageService;
        private static IEmployeeService _EmployeeService;
        private static IStoreService _StoreService;
        private static IRegionService _RegionService;
        private static IAuthorizationService _AuthService;
        private static IRoleService _RoleService;
        private static IServerStateService _ServerStateService;
        private static Form _MainForm;

        private static IApplicationContext _ctx;

        private static bool _isRuntimeMode = false;

        private static ReaderWriterLock _isConnectedLock = new ReaderWriterLock();
        private static bool _isConnected = false;
        private static readonly Version _ClientVersion;


        private static bool IsConnectedInternal
        {
            get
            {
                _isConnectedLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    return _isConnected;
                }
                finally
                {
                    _isConnectedLock.ReleaseReaderLock();
                }
            }
            set
            {
                _isConnectedLock.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    _isConnected = value;
                }
                finally
                {
                    _isConnectedLock.ReleaseWriterLock();
                }
            }
        }

        public static ImportParam ImportParam
        {
            get { return _ImportParam; }
        }

        public static bool IsRuntimeMode
        {
            get { return _isRuntimeMode; }
            set { _isRuntimeMode = value; }
        }

        public static bool IsConnected
        {
            get { return IsConnectedInternal; }
        }

        public static long UserLanguageId
        {
            get
            {
                long id = SharedConsts.NeutralLangId;

                if (AuthorizationService != null)
                {
                    Domain.User user = AuthorizationService.GetCurrentUser();
                    if (user != null && user.LanguageID.HasValue)
                    {
                        id = user.LanguageID.Value;
                    }
                }
                return id;
            }
        }

        //private static HostConfigSection _HostConfig;

        public static Version ClientVerision
        {
            get 
            {
                return _ClientVersion;
            }
        }

        private static Version GetClientVersion()
        {
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Baumax.Contract.dll");
            AssemblyName contractInfo = AssemblyName.GetAssemblyName(path);
            return contractInfo.Version;
        }

        static ClientEnvironment()
        {
            GenuineGlobalEventProvider.GenuineChannelsGlobalEvent +=
                new GenuineChannelsGlobalEventHandler(GenuineGlobalEventProvider_GenuineChannelsGlobalEvent);
            _ImportParam = new ImportParam();
            _ClientVersion = GetClientVersion();
            /*
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            _HostConfig = (HostConfigSection)config.Sections["hostSettings"];
            if (_HostConfig == null)
            {
                _HostConfig = new HostConfigSection();
                _HostConfig.SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
                _HostConfig.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
                _HostConfig.SectionInformation.ForceSave = true;
                
                config.Sections.Add("hostSettings", _HostConfig);
                config.Save(ConfigurationSaveMode.Minimal);
            }*/
        }

        private static void GenuineGlobalEventProvider_GenuineChannelsGlobalEvent(object sender, GenuineEventArgs e)
        {
            switch (e.EventType)
            {
                case GenuineEventType.GeneralConnectionReestablishing:
                case GenuineEventType.GeneralConnectionClosed:
                    IsConnectedInternal = false;
                    break;
                default:
                    break;
            }
        }

        #region Public properties

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

        public static IEmployeeHolidaysInfoService EmployeeHolidaysInfoService
        {
            get { return EmployeeTimeService.EmployeeHolidaysInfoService; }
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

        public static IEmployeeAllInService EmployeeAllInService
        {
            get { return EmployeeService.EmployeeAllInService; }
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

        public static IBufferHourAvailableService BufferHourAvailableService
        {
            get { return StoreService.BufferHourAvailableService; }
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

        private static IEmployeeTimeService EmployeeTimeService
        {
            get { return EmployeeService.EmployeeTimeService; }
        }

        public static long LanguageId
        {
            get
            {
                Domain.User usr = AuthorizationService.GetCurrentUser();
                if (usr == null || !usr.LanguageID.HasValue)
                {
                    return SharedConsts.NeutralLangId;
                }
                else
                {
                    return usr.LanguageID.Value;
                }
            }
        }

        public static Form MainForm
        {
            get { return _MainForm; }
            set { _MainForm = value; }
        }

        #endregion

        public static LoginResult DoLogin(string username, string password)
        {
            Domain.User usr;
            LoginResult result = AuthorizationService.LoginVersionCheck(username, password, out usr, ClientEnvironment.ClientVerision); 
            if (result == LoginResult.Successful)
            {
                IsConnectedInternal = true;
            }
            return result;
        }

        public static void DoLogout()
        {
            if (IsConnectedInternal)
            {
                AuthorizationService.Logout();
                IsConnectedInternal = false;
            }
        }

        public static void InitServices()
        {
            // when connection is lost, it seems old references are no longer valid
            _ImportParam.CountryService = null;
            _ImportParam.EmployeeService = null;
            _ImportParam.RegionService = null;
            _ImportParam.StoreService = null;
            _UserService = null;
            _CountryService = null;
            _LanguageService = null;
            _EmployeeService = null;
            _StoreService = null;
            _RegionService = null;
            _AuthService = null;
            _RoleService = null;

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
            EmployeeAllInService.Init();
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
            BufferHourAvailableService.Init();
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
            EmployeeHolidaysInfoService.Init();

            _ImportParam.CountryService = CountryService;
            _ImportParam.EmployeeService = EmployeeService;
            _ImportParam.RegionService = RegionService;
            _ImportParam.StoreService = StoreService;
        }
    }
}