using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeWeekTimePlanningService : IBaseService<EmployeeWeekTimePlanning>
    {
        void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks);
        List<EmployeeWeekTimePlanning> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate);
        void FillEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks);
    }
}