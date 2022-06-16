using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IYearlyWorkingDayService : IBaseService<YearlyWorkingDay>
    {
        List<YearlyWorkingDay> GetYearlyWorkingDaysFiltered(long countryID, DateTime? from, DateTime? to);
    }

    
}