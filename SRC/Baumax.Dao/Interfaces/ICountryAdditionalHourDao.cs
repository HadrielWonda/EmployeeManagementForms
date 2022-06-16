using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface ICountryAdditionalHourDao : IDao<CountryAdditionalHour>
    {
        List<CountryAdditionalHour> GetCountryAdditionalHourFiltered(long CountryID, short? Year);
    }
}