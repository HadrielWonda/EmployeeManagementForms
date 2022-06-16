using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using System.Collections;
using System;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalWorkingTimePlanningService : LocalBaseCachingService<WorkingTimePlanning>,
                                                   IWorkingTimePlanningService
    {
        #region IWorkingTimePlanningService Members

        public List<WorkingTimePlanning> GetWorkingTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                              DateTime endDate)
        {
            return
                ((IWorkingTimePlanningService) _remoteService).GetWorkingTimePlanningsByEmployeeIds(employeeIDs,
                                                                                                    beginDate, endDate);
        }

        public List<WorkingTimePlanning> SetWorkingTimePlannings(long[] employeeIDs,
                                                                 List<WorkingTimePlanning> workingTimePlannings,
                                                                 DateTime beginDate, DateTime endDate)
        {
            return
                ((IWorkingTimePlanningService) _remoteService).SetWorkingTimePlannings(employeeIDs,
                                                                                       workingTimePlannings,
                                                                                       beginDate, endDate);
        }


        public void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            throw new Exception("Don't execute it methods on client ");
        }

        public List<WorkingTimePlanning> DeleteByEmployeeIds(long[] p, DateTime begindate, DateTime enddate)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
        }
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
        }

        public List<WorkingTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end)
        {
            return
                ((IWorkingTimePlanningService)_remoteService).GetEntitiesByStoreRelations(storeid, begin, end);
        }
    }
}