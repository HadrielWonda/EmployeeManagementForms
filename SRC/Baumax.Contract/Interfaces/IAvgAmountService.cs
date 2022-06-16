using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IAvgAmountService : IBaseService<AvgAmount>
    {
        List<AvgAmount> GetCountryAvgAmounts(long countryID);

        bool CheckYear(short year, long entityid, long countryid);
        AvgAmount GetAvgAmountByYear(long countryid, int year);
    }
}