using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.ZLib;
using Baumax.Domain;
using Baumax.Environment;
using Spring.Context;
using Spring.Context.Support;

namespace Baumax.LocalServices
{
    public class LocalCountryService : LocalBaseCachingService<Country>, ICountryService
    {
        private long _AustriaCountryID;
        private IAvgAmountService _avgAmountService;
        private IColouringService _colouringService;
        private IFeastService _feastService;
        private IAbsenceService _absenceService;
        private IWorkingModelService _workingModelService;
        private IYearlyWorkingDayService _yearlyWorkingDayService;
        private IAvgWorkingDaysInWeekService _avgWorkingDaysInWeekService;
        private ICountryAdditionalHourService _countryAdditionalHourService;
        
        private ICountryService RemoteService
        {
            get { return (ICountryService)_remoteService; }
        }

        #region Constructors
        public LocalCountryService()
        {
            _AustriaCountryID = 0;
        }
        #endregion

        #region ICountryService Members

        public IAvgWorkingDaysInWeekService AvgWorkingDaysInWeekService
        {
            get { return _avgWorkingDaysInWeekService; }
        }

        public IFeastService FeastService
        {
            get { return _feastService; }
        }

        public IAbsenceService AbsenceService
        {
            get { return _absenceService; }
        }

        public IAvgAmountService AvgAmountService
        {
            get { return _avgAmountService; }
        }

        public IWorkingModelService WorkingModelService
        {
            get { return _workingModelService; }
        }

        public IColouringService ColouringService
        {
            get { return _colouringService; }
        }

        public IYearlyWorkingDayService YearlyWorkingDayService
        {
            get { return _yearlyWorkingDayService; }
        }

        public ICountryAdditionalHourService CountryAdditionalHourService
        {
            get { return _countryAdditionalHourService; }
        }

        public long AustriaCountryID
        {
            get 
            {
                if (_AustriaCountryID == 0)
                    _AustriaCountryID = RemoteService.AustriaCountryID;
                return _AustriaCountryID;
            }
        }

        public bool IsCountryExist(long c_id, string c_name)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                Country res = _cache.Find(delegate(Country item)
                                          {
                                              return c_id != item.ID && c_name == item.Name;
                                          }
                    );

                return res != null;
            }
            return RemoteService.IsCountryExist(c_id, c_name);
        }

        public IList<Country> GetUserCountries(long userId)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                User user = ClientEnvironment.UserService.FindById(userId);
                if (user.UserCountryList == null)
                    return null;

                IList<Country> res = _cache.GetFiltered(delegate(Country item)
                                                        {
                                                            foreach (UserCountry uc in user.UserCountryList)
                                                            {
                                                                if (uc.CountryID == item.ID)
                                                                    return true;
                                                            }
                                                            return false;
                                                        }
                    );
                return res;
            }
            return RemoteService.GetUserCountries(userId);
        }

        public long[] GetCountryNoWorkingFeastDaysIDList()
        {
            return RemoteService.GetCountryNoWorkingFeastDaysIDList();
        }

        public long[] GetInUseIDList(InUseEntity inUseEntity, long countryID)
        {
            return RemoteService.GetInUseIDList(inUseEntity, countryID);
        }

        public void TestImportServerSide()
        {
            RemoteService.TestImportServerSide();
        }

        #endregion
    }
}
