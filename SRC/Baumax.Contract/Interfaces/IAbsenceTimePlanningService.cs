using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.Interfaces
{
    public interface IAbsenceTimePlanningService : IBaseService<AbsenceTimePlanning>
    {
        List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<AbsenceTimePlanning> SetAbsenceTimePlannings(long[] employeeIDs, List<AbsenceTimePlanning> absenceTimePlannings, DateTime beginDate, DateTime endDate);
        void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks);

        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
        void SaveEmployeeWeek(EmployeeWeek week);

        List<AbsenceTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end);
    }
}

