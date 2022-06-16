using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Dao
{
    public interface IWorkingTimeRecordingDao : IDao<WorkingTimeRecording>
    {
        IList GetWorkingTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        IList SetWorkingTimeRecordings(long[] employeeIDs, List<WorkingTimeRecording> workingTimeRecordings, DateTime beginDate, DateTime endDate);
        List<WorkingTimeRecording> GetWorkingTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);
        void SaveEmployeeWeek(EmployeeWeek week);
        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
    }
}
