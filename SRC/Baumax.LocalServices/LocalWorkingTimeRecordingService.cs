using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalWorkingTimeRecordingService : LocalBaseCachingService<WorkingTimeRecording>,
                                                    IWorkingTimeRecordingService
    {
        #region IWorkingTimeRecordingService Members

        public List<WorkingTimeRecording> GetWorkingTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return
                ((IWorkingTimeRecordingService) _remoteService).GetWorkingTimeRecordingsByEmployeeIds(employeeIDs,
                                                                                                      beginDate, endDate);
        }

        public List<WorkingTimeRecording> SetWorkingTimeRecordings(long[] employeeIDs,
                                                                   List<WorkingTimeRecording> workingTimeRecordings,
                                                                   DateTime beginDate, DateTime endDate)
        {
            return
                ((IWorkingTimeRecordingService) _remoteService).SetWorkingTimeRecordings(employeeIDs,
                                                                                         workingTimeRecordings,
                                                                                         beginDate, endDate);
        }
        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
        }
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
        }
        #endregion
    }
}