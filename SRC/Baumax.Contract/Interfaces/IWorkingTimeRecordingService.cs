using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.Interfaces
{
    public interface IWorkingTimeRecordingService : IBaseService<WorkingTimeRecording>
    {
        List<WorkingTimeRecording> GetWorkingTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<WorkingTimeRecording> SetWorkingTimeRecordings(long[] employeeIDs, List<WorkingTimeRecording> workingTimeRecordings, DateTime beginDate, DateTime endDate);

        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
        void SaveEmployeeWeek(EmployeeWeek week);
    }
}

