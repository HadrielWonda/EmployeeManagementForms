using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IPersonMinMaxService : IBaseService<PersonMinMax>
    {
        List<PersonMinMax> GetPersonMinMaxFiltered(long storeID);
        List<PersonMinMax> GetPersonMinMaxFiltered(long storeID, int year);
        PersonMinMax GetPersonMinMaxByStoreWorld(long storeworldID, int year);
    }
}