using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalColouringService : LocalBaseCachingService<Colouring>, IColouringService
    {
        #region IColouringService Members

        public List<Colouring> GetCountryColouring(long countryID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(Colouring entity)
                                          {
                                              return (entity.CountryID == countryID);
                                          });
            }
            else
            {
                return ((IColouringService)_remoteService).GetCountryColouring(countryID);
            }
        }

        #endregion
    }
}
