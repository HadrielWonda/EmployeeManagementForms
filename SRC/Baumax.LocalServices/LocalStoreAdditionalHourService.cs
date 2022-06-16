using System;
using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalStoreAdditionalHourService : LocalBaseCachingService<StoreAdditionalHour>,
                                                   IStoreAdditionalHourService
    {
        private IStoreAdditionalHourService RemoteService
        {
            get { return (IStoreAdditionalHourService) _remoteService; }
        }

        #region IStoreAdditionalHourService Members

        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, DateTime Begin, DateTime End)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(StoreAdditionalHour entity)
                                          {
                                              return ((entity.StoreID == storeID) &&
                                                      (entity.BeginDate == Begin) &&
                                                      (entity.EndDate == End));
                                          }
                    );
            }
            return RemoteService.GetStoreAdditionalHourFiltered(storeID, Begin, End);
        }


        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, int beginYear, byte dayOfWeek)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(StoreAdditionalHour entity)
                                          {
                                              return ((entity.StoreID == storeID) &&
                                                      (entity.BeginDate.Year == beginYear) &&
                                                      (entity.WeekDay == dayOfWeek));
                                          }
                    );
            }
            return RemoteService.GetStoreAdditionalHourFiltered(storeID, beginYear, dayOfWeek);
        }

        #endregion
    }
}