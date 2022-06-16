using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalYearlyWorkingDayService : LocalBaseCachingService<YearlyWorkingDay>, IYearlyWorkingDayService
    {
        #region IYearlyWorkingDayService Members

        public List<YearlyWorkingDay> GetYearlyWorkingDaysFiltered(long countryID, DateTime? from, DateTime? to)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(YearlyWorkingDay entity)
                                          {
                                              if (entity.CountryID != countryID)
                                              {
                                                  return false;
                                              }
                                              if ((from.HasValue) && (to.HasValue))
                                              {
                                                  return
                                                      ((entity.WorkingDay >= from.Value) &&
                                                       (entity.WorkingDay <= to.Value));
                                              }
                                              if (from.HasValue)
                                              {
                                                  return (entity.WorkingDay >= from.Value);
                                              }
                                              if (to.HasValue)
                                              {
                                                  return (entity.WorkingDay <= to.Value);
                                              }
                                              return true;
                                          });
            }
            else
            {
                return ((IYearlyWorkingDayService) _remoteService).GetYearlyWorkingDaysFiltered(countryID, from, to);
            }
        }

        #endregion
    }
}