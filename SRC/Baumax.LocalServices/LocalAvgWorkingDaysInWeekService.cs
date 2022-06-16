using System;
using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalAvgWorkingDaysInWeekService : LocalBaseCachingService<AvgWorkingDaysInWeek>, IAvgWorkingDaysInWeekService
    {
        #region IAvgWorkingDaysInWeekService Members

        public List<AvgWorkingDaysInWeek> GetAvgWorkingDaysInWeekFiltered(long countryID, short? yearFrom, short? yearTo)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(AvgWorkingDaysInWeek entity)
                                          {
                                              if(entity.CountryID != countryID)
                                              { 
                                                  return false;
                                              }
                                              if( (yearFrom.HasValue) && (yearTo.HasValue))
                                              {
                                                  return
                                                      ((entity.Year >= yearFrom.Value) && (entity.Year <= yearTo.Value));
                                              }
                                              if(yearFrom.HasValue)
                                              {
                                                  return (entity.Year >= yearFrom.Value);
                                              }
                                              if(yearTo.HasValue)
                                              {
                                                  return (entity.Year <= yearTo.Value);
                                              }
                                              return true;
                                          }
                    );
            }
            else
            {
                return ((IAvgWorkingDaysInWeekService)_remoteService).GetAvgWorkingDaysInWeekFiltered(countryID, yearFrom, yearTo);
            }
        }


        public double GetAvgWorkingDaysInWeek(long countryID, int year)
        {
            return ((IAvgWorkingDaysInWeekService)_remoteService).GetAvgWorkingDaysInWeek(countryID, year);
        }
        public double GetAvgWorkingDaysInWeekByStore(long storeid, int year)
        {
            return ((IAvgWorkingDaysInWeekService)_remoteService).GetAvgWorkingDaysInWeekByStore(storeid, year);
        }
        #endregion
    }
}


