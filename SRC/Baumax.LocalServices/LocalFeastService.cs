using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalFeastService : LocalBaseCachingService<Feast>, IFeastService
    {
        #region IFeastService Members

        public List<Feast> GetFeastsFiltered(long countryID, DateTime? from, DateTime? to)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(Feast entity)
                                          {
                                              if (entity.CountryID != countryID)
                                              {
                                                  return false;
                                              }
                                              if ((from.HasValue) && (to.HasValue))
                                              {
                                                  return
                                                      ((entity.FeastDate >= from.Value) &&
                                                       (entity.FeastDate <= to.Value));
                                              }
                                              if (from.HasValue)
                                              {
                                                  return (entity.FeastDate >= from.Value);
                                              }
                                              if (to.HasValue)
                                              {
                                                  return (entity.FeastDate <= to.Value);
                                              }
                                              return true;
                                          }
                    );
            }
            else
            {
                return ((IFeastService) _remoteService).GetFeastsFiltered(countryID, from, to);
            }
        }

        public SaveDataResult ImportFeasts(List<ImportDaysData> list)
        {
            return ((IFeastService) _remoteService).ImportFeasts(list);
        }

        #endregion
    }
}