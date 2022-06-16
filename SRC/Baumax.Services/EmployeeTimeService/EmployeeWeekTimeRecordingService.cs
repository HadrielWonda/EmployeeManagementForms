using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.TimePlanning;
using System.Collections.Generic;
using System;

namespace Baumax.Services
{
    [ServiceID("67E591C1-0028-4d8c-A27B-3B3553831FB8")]
    public class EmployeeWeekTimeRecordingService : BaseService<EmployeeWeekTimeRecording>, 
        IEmployeeWeekTimeRecordingService,
        IServerEmployeeWeekService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }
        public IEmployeeWeekTimeRecordingDao ServiceDao
        {
            get { return (IEmployeeWeekTimeRecordingDao)_dao; }
        }

        public List<EmployeeWeekTimeRecording> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            if (emplids != null && emplids.Length > 0)
            {
                return ServiceDao.GetEmployeesWeekState(emplids, beginDate, endDate);
            }
            return null;
        }
        public List<EmployeeWeekTimeRecording> GetEmployeesWeekStatesFrom(long emplid, DateTime beginDate)
        {
            return ServiceDao.GetEmployeeWeekStatesFrom(emplid, beginDate);
        }
        public List<EmployeeWeekTimeRecording> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            if (emplids != null && emplids.Length > 0)
            {
                return ServiceDao.GetEmployeesWeekStateByDateRange(emplids, beginDate, endDate);
            }
            return null;
        }
        public void FillEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;
            long[] ids = EmployeeWeekProcessor.GetEmployeeIds(planningweeks);

            List<EmployeeWeekTimeRecording> lst = GetEmployeesWeekState(ids, planningweeks[0].BeginDate, planningweeks[0].EndDate);

            if (lst == null || lst.Count == 0) return;


            Dictionary<long, EmployeeWeekTimeRecording> dict = new Dictionary<long, EmployeeWeekTimeRecording>();
            foreach (EmployeeWeekTimeRecording ewtp in lst)
                dict[ewtp.EmployeeID] = ewtp;

            EmployeeWeekTimeRecording entity = null;

            foreach (EmployeeWeek ew in planningweeks)
            {
                if (dict.TryGetValue(ew.EmployeeId, out entity))
                {
                    EmployeeWeekProcessor.Assign(entity, ew);
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

        public EmployeeWeekTimeRecording GetLastWeek(long emplid)
        {
            return ServiceDao.GetLastWeek(emplid);
        }

        public EmployeeWeekTimeRecording GetLastWeek(long emplid, DateTime date)
        {
            return ServiceDao.GetLastWeek(emplid, date);
        }
    }
}