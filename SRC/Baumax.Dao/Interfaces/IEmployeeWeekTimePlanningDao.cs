using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;


namespace Baumax.Dao
{
    public interface IEmployeeWeekTimePlanningDao : IDao<EmployeeWeekTimePlanning>
    {
        EmployeeWeekTimePlanning GetEmployeeWeekState(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimePlanning> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimePlanning> GetEmployeeWeekStatesInFuture(long emplid, DateTime fromDate);

        void SaveEmployeePlanningWeek(EmployeePlanningWeek planningweek);
        void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks);

        void SaveEmployeeWeek(EmployeeWeek planningweek);
        void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks);
        
        EmployeeWeek GetEmployeeWeek(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeWeek> GetEmployeesWeekStates(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimePlanning> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimePlanning> LoadAllFromDateSorted(DateTime monday);
    }
}