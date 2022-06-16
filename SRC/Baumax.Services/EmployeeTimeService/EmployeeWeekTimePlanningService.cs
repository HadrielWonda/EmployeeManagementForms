using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System;
using System.Collections.Generic;
using Baumax.Contract.TimePlanning;
using Baumax.Dao;
using Baumax.Contract;

namespace Baumax.Services
{
    [ServiceID("3DB78DC8-D7CE-4b92-8EA3-CBDA6FBF2A45")]
    public class EmployeeWeekTimePlanningService : BaseService<EmployeeWeekTimePlanning>, 
        IEmployeeWeekTimePlanningService,
        IServerEmployeeWeekService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        public IEmployeeWeekTimePlanningDao ServiceDao
        {
            get { return (IEmployeeWeekTimePlanningDao)_dao; }
        }

        public void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            if (planningweeks != null)
            {
                ServiceDao.SaveEmployeePlanningWeeks(planningweeks);
            }
        }
        public void SaveEmployeePlanningWeek(EmployeePlanningWeek planningweek)
        {
            ServiceDao.SaveEmployeePlanningWeek(planningweek);
        }

        public List<EmployeeWeekTimePlanning> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            if (emplids != null && emplids.Length > 0)
            {
                return ServiceDao.GetEmployeesWeekState(emplids, beginDate, endDate);
            }
            return null;
        }
        public List<EmployeeWeekTimePlanning> GetEmployeeWeekStatesFrom(long emplid, DateTime beginDate)
        {
            return ServiceDao.GetEmployeeWeekStatesInFuture(emplid, beginDate);
        }

        public List<EmployeeWeekTimePlanning> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            if (emplids != null && emplids.Length > 0)
            {
                return ServiceDao.GetEmployeesWeekStateByDateRange(emplids, beginDate, endDate);
            }
            return null;
        }
        public void FillEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;
            long[] ids = new long[planningweeks.Count];
            int i = 0;

            foreach (EmployeePlanningWeek epw in planningweeks)
                ids[i++] = epw.EmployeeId;

            List<EmployeeWeekTimePlanning> lst = GetEmployeesWeekState(ids, planningweeks[0].BeginDate, planningweeks[0].EndDate);

            if (lst == null || lst.Count == 0) return;

            Dictionary<long, EmployeeWeekTimePlanning> dict = new Dictionary<long, EmployeeWeekTimePlanning>();
            foreach (EmployeeWeekTimePlanning ewtp in lst)
                dict[ewtp.EmployeeID] = ewtp;

            EmployeeWeekTimePlanning entity = null;

            foreach (EmployeePlanningWeek epw in planningweeks)
            {
                if (dict.TryGetValue(epw.EmployeeId, out entity))
                {
                    epw.Assign(entity);
                }
            }
        }

        public void FillEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;
            long[] ids = EmployeeWeekProcessor.GetEmployeeIds(planningweeks);

            List<EmployeeWeekTimePlanning> lst = GetEmployeesWeekState(ids, planningweeks[0].BeginDate, planningweeks[0].EndDate);

            if (lst == null || lst.Count == 0) return;


            Dictionary<long, EmployeeWeekTimePlanning> dict = new Dictionary<long, EmployeeWeekTimePlanning>();
            foreach (EmployeeWeekTimePlanning ewtp in lst)
                dict[ewtp.EmployeeID] = ewtp;

            EmployeeWeekTimePlanning entity = null;

            foreach (EmployeeWeek ew in planningweeks)
            {
                if (dict.TryGetValue(ew.EmployeeId, out entity))
                {
                    EmployeeWeekProcessor.Assign(entity, ew);
                }
            }
        }

        public void FillEmployeeWeeks(List<EmployeeWeek> planningweeks, long[] emplIds, Dictionary <long, EmployeeWeek> dictWeek)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;

            List<EmployeeWeekTimePlanning> lst = GetEmployeesWeekState(emplIds, planningweeks[0].BeginDate, planningweeks[0].EndDate);

            if (lst == null || lst.Count == 0) return;

            EmployeeWeek ew = null;
            foreach (EmployeeWeekTimePlanning ewtp in lst)
            {
                if (dictWeek.TryGetValue (ewtp.EmployeeID, out ew))
                {
                    EmployeeWeekProcessor.Assign(ewtp, ew);
                }
            }
        }

        public void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            if (planningweeks != null)
            {
                foreach (EmployeeWeek ew in planningweeks)
                {
                    ServiceDao.SaveEmployeeWeek(ew);
                }
            }
        }
        public void SaveEmployeeWeek(EmployeeWeek planningweek)
        {
            if (planningweek != null)
            {
                ServiceDao.SaveEmployeeWeek(planningweek);
            }
        }
        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeWeekTimePlanning> lst = ServiceDao.GetEmployeesWeekStateByDateRange(new long[] { id }, aBegin, aEnd);
            if (lst != null && lst.Count > 0)
            {
                foreach (EmployeeWeekTimePlanning entity in lst)
                    DeleteByID(entity.ID);
            }
        }
    }
}