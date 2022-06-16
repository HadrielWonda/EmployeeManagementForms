using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.LocalServices
{
    public class LocalAbsenceService : LocalBaseCachingService<Absence>, IAbsenceService
    {
        private IAbsenceService RemoteService
        {
            get { return (IAbsenceService) _remoteService; }
        }
        
        #region IAbsenceService Members

        public List<Absence> GetCountryAbsences(long countryID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(Absence entity)
                                          {
                                              return (entity.CountryID == countryID);
                                          });
            }
            return RemoteService.GetCountryAbsences(countryID);
        }

        public SaveDataResult ImportAbsence(List<ImportAbsenceData> list)
        {
            return RemoteService.ImportAbsence(list);
        }

        public bool IsExistAbsenceNameOrAbbreviation(long? countryID, string name, string charID, long id)
        {
            return RemoteService.IsExistAbsenceNameOrAbbreviation(countryID, name, charID, id);
        }

        #endregion
    }
}
