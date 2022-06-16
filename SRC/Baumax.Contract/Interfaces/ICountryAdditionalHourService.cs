using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface ICountryAdditionalHourService : IBaseService<CountryAdditionalHour>
    {
        List<CountryAdditionalHour> GetCountryAdditionalHourFiltered(long CountryID, short? Year);
    }
}