using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using System.Collections;
using System.Text;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using Baumax.Services._HelperObjects.ExEntity;


namespace Baumax.Services
{
    [ServiceID("449877F0-0536-452f-8A5A-333F6F95728A")]
    public class WorkingTimePlanningService : BaseService<WorkingTimePlanning>, IWorkingTimePlanningService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        private IWorkingTimePlanningDao workingTimePlanningDao
        {
            get { return (IWorkingTimePlanningDao)_dao; }
        }

        #region IWorkingTimePlanningService Members

        [AccessType(AccessType.Read)]
        public List<WorkingTimePlanning> GetWorkingTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return
                GetTypedListFromIList(
                    workingTimePlanningDao.GetWorkingTimePlanningsByEmployeeIds(employeeIDs, beginDate, endDate));
        }
        public List<WorkingTimePlanning> GetWorkingTimeByEmployeeId(long employeeID, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return workingTimePlanningDao.GetWorkingTimeByEmployeeId (employeeID, beginDate, endDate);
        }


        [AccessType(AccessType.Write)]
        public List<WorkingTimePlanning> SetWorkingTimePlannings(long[] employeeIDs,
                                                                   List<WorkingTimePlanning> WorkingTimePlannings,
                                                                   DateTime beginDate, DateTime endDate)
        {
            return
                GetTypedListFromIList(
                    workingTimePlanningDao.SetWorkingTimePlannings(employeeIDs, WorkingTimePlannings, beginDate,
                                                                     endDate));
        }
        [AccessType(AccessType.Write)]
        public void SetWeekTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            //List<WorkingTimePlanning> lst = new List<WorkingTimePlanning>();
            if (planningweeks != null && planningweeks.Count > 0)
            {
                ExPlanningWorkingTime saver = new ExPlanningWorkingTime();
                saver.SavePlanningWeek(planningweeks);
            }

            //foreach (EmployeePlanningWeek epw in planningweeks)
            //{
            //    foreach (EmployeePlanningDay epd in epw.Days.Values)
            //    {
            //        workingTimePlanningDao.SetWorkingTimeByEmployeeId(epd.EmployeeId, epd.WorkingTimeList, epd.Date, epd.Date);
            //    }
            //}
        }


        public List<WorkingTimePlanning> DeleteByEmployeeIds(long[] p, DateTime begindate, DateTime enddate)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        [AccessType(AccessType.Write)]
        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
            workingTimePlanningDao.SaveEmployeesWeek(lstWeeks);
        }

        [AccessType(AccessType.Write)]
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            workingTimePlanningDao.SaveEmployeeWeek(week);
        }
        
        #endregion

        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<WorkingTimePlanning> lst = GetWorkingTimePlanningsByEmployeeIds(new long[] { id }, aBegin, aEnd);
            if (lst != null && lst.Count > 0)
            {
                DeleteList(lst);
            }

        }
        [AccessType(AccessType.Read)]
        public List<WorkingTimePlanning> GetEntitiesByStoreRelations(long storeid, DateTime begin, DateTime end)
        {
            return workingTimePlanningDao.GetEntitiesByStoreRelation(storeid, begin, end);
        }
    }
}
