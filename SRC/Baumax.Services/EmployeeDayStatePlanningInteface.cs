using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services
{
    interface IInternalEmployeeDayStatePlanning: IEmployeeDayStatePlanningService
    {
        
        void SaveEmployeePlanningDay(EmployeePlanningDay plday);
        void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks);
        List<EmployeeDayStatePlanning> GetEmployeesState(long[] emplids, DateTime beginDate, DateTime endDate);

        int GetWorkingHoursByMonth(long employeeid,DateTime date);

        void FillEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks, DateTime beginDate, DateTime endDate);
    }

    interface IServerEmployeeDayService
    {
        //void SaveEmployeeState(long emplid, DateTime date, int plannedhours, int addhours, long storeworldid);
        void SaveEmployeeDay(EmployeeDay plday);
        void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks);
        List<EmployeeDay> GetEmployeesStateByIds(long[] emplids, DateTime beginDate, DateTime endDate);
        int GetWorkingHoursByMonth(long employeeid, DateTime date);
        void FillEmployeeWeeks(List<EmployeeWeek> weeks, DateTime beginDate, DateTime endDate);
    }

    interface IServerEmployeeWeekService
    {
        void FillEmployeeWeeks(List<EmployeeWeek> weeks);
        void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks);
    }

    

    interface IServerEmployeeTimeRangeService
    {
        void SaveEmployeeTimeRanges(long[] emplids, List<EmployeeTimeRange> ranges, DateTime aBegin, DateTime aEnd);
    }

}
