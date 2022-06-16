using System;
using System.Collections.Generic;
using Baumax.Domain;
using System.Collections;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.Interfaces
{
    public interface IWorkingTimePlanningService : IBaseService<WorkingTimePlanning>
    {
        List<WorkingTimePlanning> GetWorkingTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);
        List<WorkingTimePlanning> SetWorkingTimePlannings(long[] employeeIDs, List<WorkingTimePlanning> workingTimePlannings, DateTime beginDate, DateTime endDate);
        void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks);

        List<WorkingTimePlanning> DeleteByEmployeeIds(long[] p, DateTime begindate, DateTime enddate);

        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
        void SaveEmployeeWeek(EmployeeWeek week);

        List<WorkingTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end);
        
    }
}
