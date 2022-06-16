using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using System;
using Baumax.Contract.TimePlanning;

namespace Baumax.Dao
{
    public interface IEmployeeDayStateRecordingDao : IDao<EmployeeDayStateRecording>
    {
        List<EmployeeDayStateRecording> GetEmployeesStates(long[] emplids, DateTime beginDate, DateTime endDate);
        List<EmployeeDayStateRecording> GetEmployeeStates(long emplid, DateTime beginDate, DateTime endDate);
        List<EmployeeDay> GetEmployeeDayStates(long[] emplids, DateTime beginDate, DateTime endDate);

        int GetWorkingHoursByMonth(long employeeid, DateTime date);

        void SaveEmployeeDay(EmployeeDay plday);
        void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks);

    }
}