using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.LocalServices
{
    public class LocalLongTimeAbsenceService : LocalBaseCachingService<LongTimeAbsence>, ILongTimeAbsenceService
    {
        private ILongTimeAbsenceService RemoteService
        {
            get { return (ILongTimeAbsenceService) _remoteService; }
        }
        
        public SaveDataResult ImportLongTimeAbsence(List<ImportLongTimeAbsenceData> list)
        {
            return RemoteService.ImportLongTimeAbsence(list);
        }

        public List<LongTimeAbsence> FindAllByCountry(long countryid)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(LongTimeAbsence entity)
                                          {
                                              return (entity.CountryID == countryid);
                                          });
            }
            else
            {
                return RemoteService.FindAllByCountry(countryid);
            }
        }

        public bool IsExistCodeNameOrAbbreviation(long? countryID, string codeName, string charID, long id)
        {
            return RemoteService.IsExistCodeNameOrAbbreviation(countryID, codeName, charID, id);
        }
    }
}