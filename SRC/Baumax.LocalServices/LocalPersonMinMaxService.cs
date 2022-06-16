using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalPersonMinMaxService : LocalBaseCachingService<PersonMinMax>, IPersonMinMaxService
    {
        #region IPersonMinMaxService Members

        public List<PersonMinMax> GetPersonMinMaxFiltered(long storeID)
        {
            return ((IPersonMinMaxService) _remoteService).GetPersonMinMaxFiltered(storeID);
        }

        public List<PersonMinMax> GetPersonMinMaxFiltered(long storeID, int year)
        {
            return ((IPersonMinMaxService)_remoteService).GetPersonMinMaxFiltered(storeID, year);
        }

        public PersonMinMax GetPersonMinMaxByStoreWorld(long storeworldID, int year)
        {
            return ((IPersonMinMaxService)_remoteService).GetPersonMinMaxByStoreWorld(storeworldID, year);
        }

        #endregion
    }
}