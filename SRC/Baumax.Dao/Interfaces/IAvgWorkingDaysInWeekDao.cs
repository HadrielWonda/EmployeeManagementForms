using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IAvgWorkingDaysInWeekDao: IDao<AvgWorkingDaysInWeek>
    {
        IList GetAvgWorkingDaysInWeekFiltered(long countryID, short? yearFrom, short? yearTo);
        double GetAvgWorkingDaysInWeek(long countryID, int year);
        List<AvgWorkingDaysInWeek> GetAllAvgWorkingDaysInWeekByCountry(long countryid);
        List<AvgWorkingDaysInWeek> GetAllAvgWorkingDaysInWeek();
    }
}
