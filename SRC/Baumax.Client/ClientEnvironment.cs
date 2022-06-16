using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Spring.Context;
using Baumax.Contract.Interfaces;
using Spring.Context.Support;
using Baumax.Contract.Exceptions;
using DevExpress.XtraEditors;
using Baumax.TestGUIClient.LocalizerUI;

namespace Baumax.TestGUIClient
{
    public static class ClientEnvironment
    {
        private static IUserService _UserService;
        private static ICountryService _CountryService;
        private static ILanguageService _LanguageService;
        private static IAbsenceTypeService _AbsenceTypeService;
        //<!--now imported with countryService-->
        //private static IColouringService _ColouringService;
        private static IEmployeeService _EmployeeService;
        private static IStoreService _StoreService;

        private static IApplicationContext _ctx;

        private static bool _isruntimemode = false;
        private static UILocalizer _ui = null;

        public static bool IsRuntimeMode
        {
            get { return _isruntimemode; }
            set { _isruntimemode = value; }
        }

        public static UILocalizer UI
        {
            get 
            {
                if (_ui == null) _ui = new UILocalizer();
                return _ui; 
            }
        }



        private static Domain.User _logonUser = null;


        //private static HostConfigSection _HostConfig;

        static ClientEnvironment()
        {
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
            get { return (IAuthorizationService) AppCtx.GetObject("authorizationService"); }
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

        public static Domain.User LogonUser
        {
            get { return _logonUser; }
        }

        public static IAbsenceTypeService AbsenceTypeService
        {
            get
            {
                if (_AbsenceTypeService == null)
                {
                    _AbsenceTypeService = (IAbsenceTypeService) AppCtx.GetObject("absenceTypeService");
                }
                return _AbsenceTypeService;
            }
        }

        public static IAvgAmountService AvgAmountService
        {
            get
            {
                return (CountryService.AvgAmountService);
            }
        }

        //<!--now imported with countryService-->
        /*public static IColouringService ColouringService
        {
            get 
            { 
                if (_ColouringService == null)
                    _ColouringService = (IColouringService)AppCtx.GetObject("colouringService");
                return _ColouringService; 
            }
        }*/

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

        public static IStoreService StoreService
        {
            get
            {
                if (_StoreService == null)
                {
                    _StoreService = (IStoreService)AppCtx.GetObject("storeService");
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

        /*public static HostConfigSection HostConfig
        {
            get { return _HostConfig; }
        }*/

        #endregion

        public static void DoLogin(string username, string password)
        {
            _logonUser = AuthorizationService.Login(username, password);
        }
    }
}
