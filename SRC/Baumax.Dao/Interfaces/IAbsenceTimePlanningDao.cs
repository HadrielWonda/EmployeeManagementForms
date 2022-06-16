using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning ;

namespace Baumax.Dao
{
    public interface IAbsenceTimePlanningDao : IDao<AbsenceTimePlanning>
    {
        List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<AbsenceTimePlanning> GetAbsenceTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);

        List<AbsenceTimePlanning> SetAbsenceTimePlannings(long[] employeeIDs, List<AbsenceTimePlanning> absenceTimePlannings, DateTime beginDate, DateTime endDate);
        List<AbsenceTimePlanning> SetAbsenceTimeByEmployeeId(long employeeID, List<AbsenceTimePlanning> absenceTimePlannings,
                                              DateTime beginDate, DateTime endDate);

        void DeleteAbsenceTimeRange(long emplid, DateTime beginDate, DateTime endDate);
        void SetWeekAbsenceTimePlanning(List<EmployeePlanningWeek> planningweeks);


        void SaveEmployeeWeek(EmployeeWeek week);
        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);

        List<AbsenceTimePlanning> GetEntitiesByStoreRelation(long storeid, DateTime begin, DateTime end);
        
    }
}
