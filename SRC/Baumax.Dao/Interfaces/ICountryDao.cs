using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface ICountryDao : IDao<Country>
    {
        IList GetUserCountries(long userId);
        long GetAustriaCountryID();
        long[] GetCountryNoWorkingFeastDaysIDList();
        long[] GetInUseIDList(InUseEntity inUseEntity, long countryID);
    }
}