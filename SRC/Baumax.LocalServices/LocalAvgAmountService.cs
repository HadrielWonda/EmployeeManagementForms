using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Baumax.LocalServices
{
    class LocalAvgAmountService : LocalBaseCachingService<AvgAmount>, IAvgAmountService
    {
        private IAvgAmountService RemoteService
        {
            get { return (IAvgAmountService) _remoteService; }
        }
        
        #region IAvgAmountService Members

        public List<AvgAmount> GetCountryAvgAmounts(long countryID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(AvgAmount entity)
                                          {
                                              return (entity.CountryID == countryID);
                                          });
            }

            return RemoteService.GetCountryAvgAmounts(countryID);
        }

        public bool CheckYear(short year, long entityid, long countryid)
        {
            IList<AvgAmount> lst = GetCountryAvgAmounts(countryid);
            bool bNew = entityid <= 0;
            if (lst != null)
            {
                foreach (AvgAmount avg in lst)
                {
                    if (avg.CountryID == countryid)
                    {
                        if (bNew || avg.ID != entityid)
                        {
                            if (avg.Year == year)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        public AvgAmount GetAvgAmountByYear(long countryid, int year)
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
}