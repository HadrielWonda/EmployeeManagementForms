using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Dao
{
    public interface IAbsenceTimeRecordingDao : IDao<AbsenceTimeRecording>
    {
        List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<AbsenceTimeRecording> SetAbsenceTimeRecordings(long[] employeeIDs, List<AbsenceTimeRecording> absenceTimeRecordings, DateTime beginDate, DateTime endDate);
        List<AbsenceTimeRecording> GetAbsenceTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);
        List<AbsenceTimeRecording> GetCountryHolidayTimeRecordingsBetweenDate(long countryid, DateTime beginDate, DateTime endDate);
        void SaveEmployeeWeek(EmployeeWeek week);
        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
    }
}
