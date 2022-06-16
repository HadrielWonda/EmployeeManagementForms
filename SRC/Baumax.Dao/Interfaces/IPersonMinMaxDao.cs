using System.Collections;
using Baumax.Domain;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IPersonMinMaxDao : IDao<PersonMinMax>
    {
        IList GetPersonMinMaxFiltered(long storeID);
        IList GetPersonMinMaxFiltered(long storeID, int year);
        PersonMinMax GetPersonMinMaxByStoreWorld(long storeworldID, int year);
        List<PersonMinMax> GetPersonMinMaxByStoreWorld(long storeworldID);
    }
}