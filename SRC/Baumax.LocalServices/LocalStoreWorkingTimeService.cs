using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalStoreWorkingTimeService : LocalBaseCachingService<StoreWorkingTime>, IStoreWorkingTimeService
    {
        private IStoreWorkingTimeService RemoteService
        {
            get { return (IStoreWorkingTimeService) _remoteService; }
        }

        #region IStoreWorkingTimeService Members

        public List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime? dateOn)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(StoreWorkingTime entity)
                                          {
                                              return ((entity.StoreID == storeID) &&
                                                      ((!dateOn.HasValue) || (
                                                                                 (entity.BeginTime <= dateOn.Value) &&
                                                                                 (dateOn.Value <= entity.EndTime)
                                                                             )
                                                      )
                                                     );
                                          },
                                          delegate(StoreWorkingTime x, StoreWorkingTime y)
                                          {
                                              // inverse logic
                                              return -DateTime.Compare(x.BeginTime, y.BeginTime);
                                          }
                    );
            }
            return RemoteService.GetWorkingTimeFiltered(storeID, dateOn);
        }

        public List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime aBegin, DateTime aEnd)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(StoreWorkingTime entity)
                                          {
                                              return
                                                  ((entity.StoreID == storeID) &&
                                                   !((entity.BeginTime > aEnd) || (entity.EndTime < aBegin)));
                                          });
            }
            else
            {
                return RemoteService.GetWorkingTimeFiltered(storeID, aBegin, aEnd);
            }
        }

        #endregion

        public override StoreWorkingTime CreateEntity()
        {
            StoreWorkingTime result = base.CreateEntity();
            Array list = Enum.GetValues(typeof (DayOfWeek));
            result.StoreWTWeekdays.Clear();
            for (byte i = 0; i < list.Length; i++)
            {
                result.StoreWTWeekdays.Add(new StoreWTWeekday(Convert.ToByte((int) list.GetValue(i)), 0, 0, result));
            }
            return result;
        }
    }
}