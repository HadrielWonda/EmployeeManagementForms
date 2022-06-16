using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;


namespace Baumax.Dao
{
    public interface IWorkingTimePlanningDao : IDao<WorkingTimePlanning>
    {
        IList GetWorkingTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate);

        List<WorkingTimePlanning> GetWorkingTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);

        IList SetWorkingTimePlannings(long[] employeeIDs, List<WorkingTimePlanning> workingTimePlannings, DateTime beginDate, DateTime endDate);
        IList SetWorkingTimeByEmployeeId(long employeeID, List<WorkingTimePlanning> workingTimePlannings, DateTime beginDate, DateTime endDate);

        void SaveEmployeeWeek(EmployeeWeek week);
        void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks);
        List<WorkingTimePlanning> GetEntitiesByStoreRelation(long storeid, DateTime begin, DateTime end);
        //void SetWeekWorkingTimePlanning(List<EmployeePlanningWeek> planningweeks);
        
    }
}
