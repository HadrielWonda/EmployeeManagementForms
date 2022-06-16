using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Dao.QueryResult
{
    [Serializable ]
    public class EmployeePlanningWeek
    {
        private Employee _employee;
        private DateTime _beginWeekDate;
        private DateTime _endWeekDate;

        private long _EmployeeId = 0;
        private string _EmployeeFullName = String.Empty;
        private int _EmployeeContractHoursPerWeek = 0;

        public int ContractHoursPerWeek
        {
            get { return _EmployeeContractHoursPerWeek; }
            set { _EmployeeContractHoursPerWeek = value; }
        }
        
        public long EmployeeId
        {
            get { return _EmployeeId; }
        }

        /*public Employee PlanningEmployee
        {
            get { return _employee; }
            set { _employee = value; }
        }*/
        public string FullName
        {
            get
            {
                return _EmployeeFullName;
            }
        }
        public DateTime BeginDate
        {
            get { return _beginWeekDate; }
            set { _beginWeekDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endWeekDate; }
            set { _endWeekDate = value; }
        }

        private Dictionary<DateTime, EmployeePlanningDay> _dictionDays = new Dictionary<DateTime, EmployeePlanningDay>();

        public Dictionary<DateTime, EmployeePlanningDay> Days
        {
            get
            {
                return _dictionDays;
            }
        }

        /*public EmployeePlanningWeek(Employee empl, DateTime from,DateTime to)
        {
            Debug.Assert(from.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(to.DayOfWeek == DayOfWeek.Sunday);

            _employee = empl;
            BeginDate = from;
            EndDate = to;

            DateTime d = BeginDate ;
            while (d <= EndDate)
            {
                _dictionDays[d] = new EmployeePlanningDay(this, PlanningEmployee, d);
                d = d.AddDays(1);
            }
        }*/

        public EmployeePlanningWeek(long id, string fullname, DateTime from, DateTime to)
        {
            Debug.Assert(from.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(to.DayOfWeek == DayOfWeek.Sunday);

            _EmployeeId = id;
            _EmployeeFullName = fullname;
            BeginDate = from;
            EndDate = to;

            DateTime d = BeginDate;
            while (d <= EndDate)
            {
                _dictionDays[d] = new EmployeePlanningDay(this, d);
                d = d.AddDays(1);
            }
        }

        #region Service function

        public bool IsHasWorld(long id)
        {
            foreach (EmployeePlanningDay epd in Days.Values)
            {
                if (epd.WorldId == id) return true;
            }
            return false;
        }
        public bool IsHasWorldByDate(long id, DateTime date)
        {
            EmployeePlanningDay epd = Days[date];
            return epd.WorldId == id;
        }

        public int CountWeeklyPlanningWorkingHours = 0;

        public int CountWeeklyPlusMinusHours = 0;

        public int CountWeeklyAdditionalCharges = 0;

        public int CountWeeklyWorkingHours = 0;
        public int Saldo = 0;
        public int LastSaldo = 0;

        public void Calculate()
        {
            CountWeeklyPlanningWorkingHours = 0;
            CountWeeklyAdditionalCharges = 0;
            CountWeeklyWorkingHours = 0;
            foreach (EmployeePlanningDay epd in this.Days.Values)
            {
                epd.Calculate();
                CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
                CountWeeklyWorkingHours += epd.CountDailyWorkingHours;
            }

            CountWeeklyPlusMinusHours = ContractHoursPerWeek - CountWeeklyPlanningWorkingHours - CountWeeklyAdditionalCharges;

            Saldo = ContractHoursPerWeek + LastSaldo - CountWeeklyPlanningWorkingHours - CountWeeklyAdditionalCharges;

        }
        public void Calculate2()
        {
            CountWeeklyPlanningWorkingHours = 0;
            CountWeeklyAdditionalCharges = 0;

            foreach (EmployeePlanningDay epd in this.Days.Values)
            {
                CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
            }

            CountWeeklyPlusMinusHours = ContractHoursPerWeek - CountWeeklyPlanningWorkingHours - CountWeeklyAdditionalCharges;

            Saldo = ContractHoursPerWeek + LastSaldo - CountWeeklyPlanningWorkingHours - CountWeeklyAdditionalCharges;

        }
        #endregion
    }


    public class PlanningWeekProcessor
    {
        public static List<EmployeePlanningWeek> GetEmployeesByWorld(long worldid, List<EmployeePlanningWeek> planningemployee)
        {
            List<EmployeePlanningWeek> result = new List<EmployeePlanningWeek>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    if (epw.IsHasWorld(worldid))
                        result.Add(epw);

                }
            }

            return result;
        }

        public static List<EmployeePlanningWeek> GetEmployeesByWorldAndDate(long worldid, DateTime date, List<EmployeePlanningWeek> planningemployee)
        {
            List<EmployeePlanningWeek> result = new List<EmployeePlanningWeek>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    if (epw.IsHasWorldByDate(worldid, date))
                        result.Add(epw);
                }
            }

            return result;
        }


        public static Dictionary<long, EmployeePlanningWeek> ListToDictionary(List<EmployeePlanningWeek> planningemployee)
        {

            Dictionary<long, EmployeePlanningWeek> result = new Dictionary<long, EmployeePlanningWeek>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                        result[epw.EmployeeId] = epw;
                }
            }

            return result;
        }

        public static long[] ListToEmployeeIds(List<EmployeePlanningWeek> planningemployee)
        {

            List<long> list = new List<long>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    list.Add(epw.EmployeeId);
                }
            }

            return list.ToArray ();
        }


        public static void ResetTimesForDate(List<EmployeePlanningWeek> planningemployee, DateTime date)
        {
            if (planningemployee != null)
            {
                EmployeePlanningDay epd = null;

                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    if (epw.Days.ContainsKey(date))
                    {
                        epd = epw.Days[date];
                        if (epd.WorkingTimeList  != null)
                        {
                            epd.WorkingTimeList.Clear();
                        }
                        if (epd.AbsenceTimeList != null)
                        {
                            epd.AbsenceTimeList.Clear();
                        }

                    }
                }
            }
        }
        public static void ResetTimes(List<EmployeePlanningWeek> planningemployee)
        {
            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    foreach (EmployeePlanningDay epd in epw.Days.Values )
                    {
                        if (epd.WorkingTimeList != null)
                        {
                            epd.WorkingTimeList.Clear();
                        }
                        if (epd.AbsenceTimeList != null)
                        {
                            epd.AbsenceTimeList.Clear();
                        }

                    }
                }
            }
        }


        public static void AssignTimes(List<EmployeePlanningWeek> planningemployee,
            List<WorkingTimePlanning> worktimes,
            List<AbsenceTimePlanning> absencetimes)
        {
            Dictionary<long, EmployeePlanningWeek> dict = ListToDictionary(planningemployee);


            EmployeePlanningWeek currentWeekEmployee = null;
            EmployeePlanningDay currentDayEmployee = null;
            if (worktimes != null)
            {
                foreach (WorkingTimePlanning wtp in worktimes)
                {
                    if (dict.TryGetValue (wtp.EmployeeID, out currentWeekEmployee ))
                    {
                        if (currentWeekEmployee.Days.TryGetValue (wtp.Date, out currentDayEmployee ))
                        {
                            if (currentDayEmployee.WorkingTimeList == null) currentDayEmployee.WorkingTimeList = new List<WorkingTimePlanning> ();
                            currentDayEmployee.WorkingTimeList.Add(wtp);
                        }
                    }
                }
            }

            if (absencetimes != null)
            {
                foreach (AbsenceTimePlanning atp in absencetimes)
                {
                    if (dict.TryGetValue(atp.EmployeeID, out currentWeekEmployee))
                    {
                        if (currentWeekEmployee.Days.TryGetValue(atp.Date, out currentDayEmployee))
                        {
                            if (currentDayEmployee.AbsenceTimeList == null) currentDayEmployee.AbsenceTimeList = new List<AbsenceTimePlanning>();
                            currentDayEmployee.AbsenceTimeList.Add(atp);
                        }
                    }
                }
            }
        }

        public static void AssignTimes(List<EmployeePlanningWeek> planningemployee,
            long employeeid,
            DateTime date,
            List<WorkingTimePlanning> worktimes,
            List<AbsenceTimePlanning> absencetimes)
        {
            Dictionary<long, EmployeePlanningWeek> dict = ListToDictionary(planningemployee);


            EmployeePlanningWeek currentWeekEmployee = null;
            EmployeePlanningDay currentDayEmployee = null;


            if (dict.TryGetValue(employeeid, out currentWeekEmployee))
            {
                if (currentWeekEmployee.Days.TryGetValue(date, out currentDayEmployee))
                {
                    currentDayEmployee.WorkingTimeList = worktimes;
                    currentDayEmployee.AbsenceTimeList = absencetimes;
                }
            }
        }

    }
}
