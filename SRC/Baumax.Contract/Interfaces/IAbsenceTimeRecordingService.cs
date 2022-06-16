using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.Interfaces
{
    public interface IAbsenceTimeRecordingService : IBaseService<AbsenceTimeRecording>
    {
        List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<AbsenceTimeRecording> SetAbsenceTimeRecordings(long[] employeeIDs, List<AbsenceTimeRecording> absenceTimeRecordings, DateTime beginDate, DateTime endDate);

        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
        void SaveEmployeeWeek(EmployeeWeek week);
        
        
    }
}

