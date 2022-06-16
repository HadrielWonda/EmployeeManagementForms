using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IAvgAmountDao : IDao<AvgAmount>
    {
        IList GetCountryAvgAmounts(long countryID);
    }
}