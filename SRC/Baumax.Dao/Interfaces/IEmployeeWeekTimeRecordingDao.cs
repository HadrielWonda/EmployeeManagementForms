using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System;

namespace Baumax.Dao
{
    public interface IEmployeeWeekTimeRecordingDao : IDao<EmployeeWeekTimeRecording>
    {
        EmployeeWeekTimeRecording GetEmployeeWeekState(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimeRecording> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimeRecording> GetEmployeeWeekStateByDateRange(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimeRecording> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeWeekTimeRecording> GetEmployeeWeekStatesFrom(long emplid, DateTime beginDate);

        void SaveEmployeeWeek(EmployeeWeek planningweek);
        void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks);
        EmployeeWeek GetEmployeeWeek(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeWeek> GetEmployeesWeekStates(long[] emplids, DateTime beginDate, DateTime endDate);
        EmployeeWeekTimeRecording GetLastWeek(long emplid);
        EmployeeWeekTimeRecording GetLastWeek(long emplid, DateTime date);


        List<EmployeeWeekTimeRecording> LoadAllFromDateSorted(DateTime monday);
    }
}