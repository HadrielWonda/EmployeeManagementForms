using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IAvgWorkingDaysInWeekService: IBaseService<AvgWorkingDaysInWeek>
    {
        List<AvgWorkingDaysInWeek> GetAvgWorkingDaysInWeekFiltered(long countryID, short? yearFrom, short? yearTo);
        double GetAvgWorkingDaysInWeek(long countryID, int year);
        double GetAvgWorkingDaysInWeekByStore(long storeid, int year);
    }
}
