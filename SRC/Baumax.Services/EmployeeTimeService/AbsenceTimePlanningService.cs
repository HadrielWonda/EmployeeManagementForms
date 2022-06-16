using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using Spring.Transaction.Interceptor;
using Baumax.Contract.PlanningAndRecording;

namespace Baumax.Services
{
    [ServiceID("754ECD10-F7D2-43b3-A907-F94463721600")]
    public class AbsenceTimePlanningService : BaseService<AbsenceTimePlanning>, IAbsenceTimePlanningService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        private IAbsenceTimePlanningDao absenceTimePlanningDao
        {
            get { return (IAbsenceTimePlanningDao) _dao; }
        }

        #region IAbsenceTimePlanningService Members

        [AccessType(AccessType.Read)]
        public List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                              DateTime endDate)
        {
            return absenceTimePlanningDao.GetAbsenceTimePlanningsByEmployeeIds(employeeIDs, beginDate, endDate);
        }

        public List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeId(long employeeID, DateTime beginDate,
                                                                              DateTime endDate)
        {
            return absenceTimePlanningDao.GetAbsenceTimeByEmployeeId(employeeID, beginDate, endDate);
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public List<AbsenceTimePlanning> SetAbsenceTimePlannings(long[] employeeIDs,
                                                                 List<AbsenceTimePlanning> absenceTimePlannings,
                                                                 DateTime beginDate, DateTime endDate)
        {
            return absenceTimePlanningDao.SetAbsenceTimePlannings(employeeIDs, absenceTimePlannings, beginDate, endDate);
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            absenceTimePlanningDao.SetWeekAbsenceTimePlanning(planningweeks);
        }


        [AccessType(AccessType.Write)]
        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
            absenceTimePlanningDao.SaveEmployeesWeek(lstWeeks);
        }

        [AccessType(AccessType.Write)]
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            absenceTimePlanningDao.SaveEmployeeWeek(week);
        }


        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<AbsenceTimePlanning> lst = GetAbsenceTimePlanningsByEmployeeIds(new long[] { id }, aBegin, aEnd);
            if (lst != null && lst.Count > 0)
            {
                DeleteList(lst);
                //foreach (AbsenceTimePlanning model in lst)
                //    DeleteByID(model.ID);
            }

        }
        [AccessType(AccessType.Read)]
        public List<AbsenceTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end)
        {
            return absenceTimePlanningDao.GetEntitiesByStoreRelation(storeid, begin, end);
        }
        #endregion
    }
}