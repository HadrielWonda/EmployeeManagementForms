using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalCountryAdditionalHourService : LocalBaseCachingService<CountryAdditionalHour>, ICountryAdditionalHourService
    {
        private ICountryAdditionalHourService RemoteService
        {
            get { return (ICountryAdditionalHourService)_remoteService; }
        }

        #region ICountryAdditionalHourService Members

        public List<CountryAdditionalHour> GetCountryAdditionalHourFiltered(long CountryID, short? Year)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(CountryAdditionalHour entity)
                                          {
                                              if(entity.CountryID != CountryID)
                                              {
                                                  return false;
                                              }
                                              if(!Year.HasValue)
                                              {
                                                  return true;
                                              }
                                              return (entity.Year == Year.Value);
                                          });
            }

            return RemoteService.GetCountryAdditionalHourFiltered(CountryID, Year);
        }

        #endregion
    }
}