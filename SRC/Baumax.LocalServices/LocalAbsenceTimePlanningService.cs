using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalAbsenceTimePlanningService : LocalBaseCachingService<AbsenceTimePlanning>,
                                                   IAbsenceTimePlanningService
    {
        #region IAbsenceTimePlanningService Members

        public List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                              DateTime endDate)
        {
            return
                ((IAbsenceTimePlanningService) _remoteService).GetAbsenceTimePlanningsByEmployeeIds(employeeIDs,
                                                                                                    beginDate, endDate);
        }

        public List<AbsenceTimePlanning> SetAbsenceTimePlannings(long[] employeeIDs,
                                                                 List<AbsenceTimePlanning> absenceTimePlannings,
                                                                 DateTime beginDate, DateTime endDate)
        {
            return
                ((IAbsenceTimePlanningService) _remoteService).SetAbsenceTimePlannings(employeeIDs, absenceTimePlannings,
                                                                                       beginDate, endDate);
        }
        public void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            throw new Exception("Don't execute it methods on client ");
        }


        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
        }
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
        }

        public List<AbsenceTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end)
        {
            return
                ((IAbsenceTimePlanningService)_remoteService).GetEntitiesByStoreRelations(storeid, begin, end);
        }
        #endregion
    }
}