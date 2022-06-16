using System;
using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IYearlyWorkingDayDao : IDao<YearlyWorkingDay>
    {
        IList GetYearlyWorkingDaysFiltered(long countryID, DateTime? from, DateTime? to);
    }
}