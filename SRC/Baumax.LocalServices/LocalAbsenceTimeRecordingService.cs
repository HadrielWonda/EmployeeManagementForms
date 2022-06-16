using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalAbsenceTimeRecordingService : LocalBaseCachingService<AbsenceTimeRecording>, IAbsenceTimeRecordingService
    {
        #region IAbsenceTimeRecordingService Members

        public List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return
                ((IAbsenceTimeRecordingService) _remoteService).GetAbsenceTimeRecordingsByEmployeeIds(employeeIDs,
                                                                                                      beginDate, endDate);
        }

        public List<AbsenceTimeRecording> SetAbsenceTimeRecordings(long[] employeeIDs,
                                                                   List<AbsenceTimeRecording> absenceTimeRecordings,
                                                                   DateTime beginDate, DateTime endDate)
        {
            return
                ((IAbsenceTimeRecordingService) _remoteService).SetAbsenceTimeRecordings(employeeIDs,
                                                                                         absenceTimeRecordings,
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
