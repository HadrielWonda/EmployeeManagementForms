using System;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.QueryResult;
using System.Collections.Generic;
using Baumax.Contract.TimePlanning;


namespace Baumax.Services
{
    [ServiceID("6DE0208A-058C-430a-BF5D-5B9229DFE073")]
    public class EmployeeDayStatePlanningService : BaseService<EmployeeDayStatePlanning>, 
        IEmployeeDayStatePlanningService,
        IInternalEmployeeDayStatePlanning,
        IServerEmployeeDayService

    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        private IEmployeeDayStatePlanningDao servicedao
        {
            get { return (IEmployeeDayStatePlanningDao)Dao; }
        }
        
        public void SaveEmployeePlanningDay(EmployeePlanningDay plday)
        {
            servicedao.SaveEmployeePlanningDay(plday);
        }
        public void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            servicedao.SaveEmployeePlanningWeeks(planningweeks);
        }
        public List<EmployeeDayStatePlanning> GetEmployeesState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            return servicedao.GetEmployeesStates(emplids, beginDate, endDate);
        }

        public List<EmployeeDayStatePlanning> GetEmployeeStates(long emplid, DateTime beginDate, DateTime endDate)
        {
            return servicedao.GetEmployeeStates(emplid, beginDate, endDate);
        }

        public int GetWorkingHoursByMonth(long employeeid, DateTime date)
        {
            return servicedao.GetWorkingHoursByMonth(employeeid, date);
        }

        public void FillEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks, DateTime beginDate, DateTime endDate)
        {
            if (planningweeks != null && planningweeks.Count > 0)
            {
                List<long> lstIds = new List<long>(planningweeks.Count);
                Dictionary<long, EmployeePlanningWeek> _diction = new Dictionary<long, EmployeePlanningWeek>();
                foreach (EmployeePlanningWeek epw in planningweeks)
                {
                    lstIds.Add(epw.EmployeeId);
                    _diction[epw.EmployeeId] = epw;
                }

                long[] ids = lstIds.ToArray();

                List<EmployeeDayStatePlanning> daystates = GetEmployeesState(ids, beginDate, endDate);

                if (daystates != null)
                {
                    EmployeePlanningWeek lastWeek = planningweeks [0];
                    EmployeePlanningDay day = null;
                    foreach (EmployeeDayStatePlanning edsp in daystates)
                    {
                        if (edsp.EmployeeID != lastWeek.EmployeeId )
                            lastWeek = _diction[edsp.EmployeeID];

                        day = lastWeek.Days[edsp.Date];

                        day.CountDailyAdditionalCharges = edsp.SumOfAddHours;
                        day.CountDailyPlannedWorkingHours = edsp.AllreadyPlannedHours;
                        day.CountDailyWorkingHours = edsp.WorkingHours;
                    }
                }

            }
        }

        #region IInternalEmployeeDayState

        //public void SaveEmployeeState(long emplid, DateTime date, int plannedhours, int addhours, long storeworldid)
        //{
        //    servicedao.SaveEmployeeState(emplid, date, plannedhours, addhours, storeworldid);
        //}

        public void SaveEmployeeDay(EmployeeDay plday)
        {
            //EmployeePlanningDay entity = new EmployeeDay();
            servicedao.SaveEmployeeDay(plday);

        }

        public void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            servicedao.SaveEmployeeWeeks(planningweeks);
        }

        public List<EmployeeDay> GetEmployeesStateByIds(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStatePlanning> states = servicedao.GetEmployeesStates(emplids, beginDate, endDate);
            List<EmployeeDay> result = null;
            if (states != null)
            {
                result = new List<EmployeeDay>();
                
                foreach (EmployeeDayStatePlanning entity in states)
                {
                    result.Add(new EmployeeDay(entity));
                }

            }

            return result;
        }

        public void FillEmployeeWeeks(List<EmployeeWeek> weeks, DateTime beginDate, DateTime endDate)
        {
            if (weeks != null && weeks.Count > 0)
            {
                List<long> lstIds = new List<long>(weeks.Count);
                Dictionary<long, EmployeeWeek> _diction = new Dictionary<long, EmployeeWeek>();
                foreach (EmployeeWeek epw in weeks)
                {
                    lstIds.Add(epw.EmployeeId);
                    _diction[epw.EmployeeId] = epw;
                }

                long[] ids = lstIds.ToArray();

                List<EmployeeDayStatePlanning> daystates = GetEmployeesState(ids, beginDate, endDate);

                if (daystates != null)
                {
                    EmployeeWeek lastWeek = null;
                    EmployeeDay day = null;
                    foreach (EmployeeDayStatePlanning edsp in daystates)
                    {
                        if ((lastWeek == null) || (edsp.EmployeeID != lastWeek.EmployeeId))
                        {
                            lastWeek = null;
                            _diction.TryGetValue(edsp.EmployeeID, out lastWeek);
                        }

                        if (lastWeek != null)
                        {
                            day = lastWeek.GetDay(edsp.Date);
                            if (day != null)
                            {
                                EmployeeDayProcessor.AssignDay (edsp, day);
                            }

                        }
                    }
                }

            }
        }



        public void FillEmployeeWeeks(List<EmployeeWeek> weeks, DateTime beginDate, DateTime endDate,
            long[] emplIds, Dictionary <long, EmployeeWeek> dictWeek)
        {
            if (weeks != null && weeks.Count > 0)
            {
                List<EmployeeDayStatePlanning> daystates = GetEmployeesState(emplIds, beginDate, endDate);

                if (daystates != null)
                {
                    EmployeeWeek lastWeek = null;
                    EmployeeDay day = null;
                    foreach (EmployeeDayStatePlanning edsp in daystates)
                    {
                        if ((lastWeek == null) || (edsp.EmployeeID != lastWeek.EmployeeId))
                        {
                            lastWeek = null;
                            dictWeek.TryGetValue(edsp.EmployeeID, out lastWeek);
                        }

                        if (lastWeek != null)
                        {
                            day = lastWeek.GetDay(edsp.Date);
                            if (day != null)
                            {
                                EmployeeDayProcessor.AssignDay(edsp, day);
                            }

                        }
                    }
                }

            }
        }
        #endregion



        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeDayStatePlanning> lst = GetEmployeesState(new long[] { id }, aBegin, aEnd);
            if (lst != null && lst.Count > 0)
            {
                foreach (EmployeeDayStatePlanning entity in lst)
                    DeleteByID(entity.ID);
            }
        }
    }
}
