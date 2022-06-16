using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Contract.TimePlanning
{
    [Serializable ]
    public sealed class EmployeePlanningWeek : BaseEntity, IWorkingModelData
    {
        //private Employee _employee;
        private DateTime _beginWeekDate;
        private DateTime _endWeekDate;

        private long _EmployeeId = 0;
        private string _EmployeeFullName = String.Empty;
        private int _EmployeeContractHoursPerWeek = 0;

        private int _CountWeeklyPlanningWorkingHours = 0;
        private int _CountWeeklyPlusMinusHours = 0;
        private int _CountWeeklyAdditionalCharges = 0;
        private int _CountWeeklyWorkingHours = 0;
        private int _Saldo = 0;

        private int _LastSaldo = 0;
        private int _MonthWorkingTime = 0;
        private byte _CountSunday = 0;
        private byte _CountSaturday = 0;
        private byte _WorkingDaysBefore = 0;
        private byte _WorkingDaysAfter = 0;

        private bool _AllIn = false;
        private bool _IsValidWeek = false;
        private bool _CustomEdit = false;
        private long _OrderHWGR = 0;
        private Dictionary<DateTime, EmployeePlanningDay> _dictionDays = new Dictionary<DateTime, EmployeePlanningDay>();

        public double AvgDaysWeek = 0;

        #region Employee info

        public int ContractHoursPerWeek
        {
            get { return _EmployeeContractHoursPerWeek; }
            set { _EmployeeContractHoursPerWeek = value; }
        }
        
        public long EmployeeId
        {
            get { return _EmployeeId; }
        }

        
        public string FullName
        {
            get
            {
                return _EmployeeFullName;
            }
        }


        #endregion

        #region week info and entity
        public EmployeeWeekTimePlanning Assign(EmployeeWeekTimePlanning weekinfo)
        {
            if (weekinfo == null)
                throw new NullReferenceException();
            ID = weekinfo.ID;
            CountWeeklyWorkingHours = weekinfo.WorkingHours;
            ContractHoursPerWeek = weekinfo.ContractHours;
            CountWeeklyPlusMinusHours = weekinfo.PlusMinusHours;
            CountWeeklyPlanningWorkingHours = weekinfo.PlannedHours;
            CountWeeklyAdditionalCharges = weekinfo.AdditionalCharge;
            Saldo = weekinfo.Saldo;
            _CustomEdit = weekinfo.CustomEdit;
            AllIn = weekinfo.AllIn;
            return weekinfo;
        }
        public EmployeeWeekTimePlanning AssignTo(EmployeeWeekTimePlanning weekinfo)
        {
            if (weekinfo == null)
                throw new ArgumentNullException ();
            //weekinfo.ID = ID;
            weekinfo.WorkingHours = CountWeeklyWorkingHours ;
            weekinfo.ContractHours = ContractHoursPerWeek ;
            weekinfo.PlusMinusHours = CountWeeklyPlusMinusHours ;
            weekinfo.PlannedHours = CountWeeklyPlanningWorkingHours ;
            weekinfo.AdditionalCharge = CountWeeklyAdditionalCharges ;
            weekinfo.EmployeeID = EmployeeId;

            weekinfo.Saldo = Saldo;

            weekinfo.WeekBegin = BeginDate;
            weekinfo.WeekEnd = EndDate;
            weekinfo.CustomEdit = _CustomEdit;
            weekinfo.AllIn = AllIn;
            return weekinfo;
        }

        public EmployeeWeekTimePlanning CreateEntity()
        {
            return AssignTo(new EmployeeWeekTimePlanning()); ;
        }

        public bool AllIn
        {
            get { return _AllIn; }
            set { _AllIn = value; }
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

        

        public Dictionary<DateTime, EmployeePlanningDay> Days
        {
            get
            {
                return _dictionDays;
            }
        }

        #endregion

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

        public EmployeePlanningWeek(long id, string fullname, DateTime from, DateTime to, long orderHWGR) : this(id, fullname, from, to)
        {
            _OrderHWGR = orderHWGR;
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

        public int CountPlannedHoursByWorld(long storeworldid)
        {
            int result = 0;
            foreach (EmployeePlanningDay epd in Days.Values)
            {
                if (epd.WorldId == storeworldid) result += epd.CountDailyPlannedWorkingHours;
            }
            return result;
        }

        public bool IsSundayWorking
        {
            get
            {
                return Days[EndDate].CountDailyWorkingHours > 0;
            }
        }
        public bool IsSaturdayWorking
        {
            get
            {
                return Days[EndDate.AddDays (-1)].CountDailyWorkingHours > 0;
            }
        }
        public int CountWorkingSundayPerMonth
        {
            get
            {
                int iCount = CountSunday;
                if (BeginDate.Month == EndDate.Month)
                {
                    if (IsSundayWorking) iCount++;

                }
                
                return iCount;
            }
        }
        public int CountWorkingSundayAndSaturdayPerMonth
        {
            get
            {
                int iCount = CountWorkingSundayPerMonth + CountSaturday;
                DateTime dtSaturday = EndDate.AddDays(-1);
                int beginweekMonth = BeginDate.Month;

                if (beginweekMonth == EndDate.Month
                    || beginweekMonth == dtSaturday.Month)
                {
                    if (IsSaturdayWorking) iCount++;

                }

                return iCount;
            }
        }
        #endregion
        
        #region properties
        public bool IsValidWeek
        {
            get { return _IsValidWeek; }
        }
        public int WorkingTimeByMonth
        {
            get { return _MonthWorkingTime; }
            set { _MonthWorkingTime = value; }
        }

        public byte CountSunday
        {
            get { return _CountSunday; }
            set { _CountSunday = value; }
        }

        public byte CountSaturday
        {
            get { return _CountSaturday; }
            set { _CountSaturday = value; }
        }

        public byte WorkingDaysBefore
        {
            get { return _WorkingDaysBefore; }
            set { _WorkingDaysBefore = value; }
        }

        public byte WorkingDaysAfter
        {
            get { return _WorkingDaysAfter; }
            set { _WorkingDaysAfter = value; }
        }


        public int CountWeeklyPlanningWorkingHours
        {
            get { return _CountWeeklyPlanningWorkingHours; }
            set { _CountWeeklyPlanningWorkingHours = value; }
        }

        

        public int CountWeeklyPlusMinusHours
        {
            get { return _CountWeeklyPlusMinusHours; }
            set { _CountWeeklyPlusMinusHours = value; }
        }

        

        public int CountWeeklyAdditionalCharges
        {
            get { return _CountWeeklyAdditionalCharges; }
            set { _CountWeeklyAdditionalCharges = value; }
        }

        

        public int CountWeeklyWorkingHours
        {
            get { return _CountWeeklyWorkingHours; }
            set { _CountWeeklyWorkingHours = value; }
        }
        

        public int Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }
        

        public int LastSaldo
        {
            get { return _LastSaldo; }
            set { _LastSaldo = value; }
        }

        public long OrderHWGR
        {
            get { return _OrderHWGR; }
            set { _OrderHWGR = value; }
        }

        
        #endregion

        #region Calculation

        public void CalculateWithoutWorkingModels()
        {
            CalculateHolidaysDay();

            _CountWeeklyPlanningWorkingHours = 0;
            _CountWeeklyAdditionalCharges = 0;
            _CountWeeklyWorkingHours = 0;
            ClearWorkingModel();

            foreach (EmployeePlanningDay epd in this.Days.Values)
            {
                //epd.Calculate();
                _CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                _CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
                _CountWeeklyWorkingHours += epd.CountDailyWorkingHours;
            }
            //if (AllIn) // don't need calculate additional charges
            //    _CountWeeklyAdditionalCharges = 0;
            if (AllIn )
                _CountWeeklyPlusMinusHours = -ContractHoursPerWeek + _CountWeeklyPlanningWorkingHours;
            else
                _CountWeeklyPlusMinusHours = -ContractHoursPerWeek + _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges;

            _Saldo = LastSaldo + _CountWeeklyPlusMinusHours;
        }

        public void CalculateAfterWorkingModels()
        {
            _CountWeeklyPlanningWorkingHours = 0;
            _CountWeeklyAdditionalCharges = 0;

            foreach (EmployeePlanningDay epd in this.Days.Values)
            {
                _CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                _CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
            }
            //if (AllIn) // don't need calculate additional charges
            //    _CountWeeklyAdditionalCharges = 0;

            if (AllIn)
                _CountWeeklyPlusMinusHours = -ContractHoursPerWeek + _CountWeeklyPlanningWorkingHours;
            else
                _CountWeeklyPlusMinusHours = -ContractHoursPerWeek + _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges;

            _Saldo = LastSaldo + _CountWeeklyPlusMinusHours;

        }

        #endregion


        public void ClearWorkingModel()
        {
            foreach (EmployeePlanningDay day in Days.Values)
            {
                if (day.WorkingModels == null) continue;

                if (day.WorkingModels.Count > 0)
                    day.WorkingModels.Clear();
            }
        }

        public void InitWeekState()
        {
            _IsValidWeek = false;
            foreach (EmployeePlanningDay day in _dictionDays.Values)
                _IsValidWeek |= (!day.IsBlockedDay);
        }

        public void CalculateHolidaysDay()
        {
            foreach (EmployeePlanningDay day in Days.Values)
            {
                if (day.AbsenceTimeList != null)
                {
                    foreach (AbsenceTimePlanning absencetime in day.AbsenceTimeList)
                    {
                        if (absencetime.Absence != null)
                        {
                            if (absencetime.Absence.AbsenceTypeID == AbsenceType.Holiday)
                            {
                                if (AvgDaysWeek != 0)
                                    absencetime.ApplyTime(ContractHoursPerWeek, AvgDaysWeek);
                            }
                        }
                    }
                }
            }
        }
    }


    public class PlanningWeekProcessor
    {
        public static int GetLastSaldoFromSaldo(EmployeePlanningWeek week)
        {

            int LastSaldo = week.Saldo - week.CountWeeklyPlusMinusHours;

            return LastSaldo;

        }
        public static List<EmployeePlanningWeek> GetEmployeesByWorld(long storeworldid, List<EmployeePlanningWeek> planningemployee)
        {
            if (storeworldid == 0) return null;

            List<EmployeePlanningWeek> result = new List<EmployeePlanningWeek>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    if (epw.IsHasWorld(storeworldid))
                        result.Add(epw);

                }
            }

            return result;
        }

        public static List<EmployeePlanningWeek> GetEmployeesByWorldAndDate(long storeworldid, DateTime date, List<EmployeePlanningWeek> planningemployee)
        {
            if (storeworldid == 0) return null;

            List<EmployeePlanningWeek> result = new List<EmployeePlanningWeek>();

            if (planningemployee != null)
            {
                foreach (EmployeePlanningWeek epw in planningemployee)
                {
                    if (epw.IsHasWorldByDate(storeworldid, date))
                    {
                        EmployeePlanningDay plday = epw.Days[date];
                        if (plday.HasRelation && !plday.HasLongAbsence && plday.HasContract) 
                            result.Add(epw);
                    }
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


        public static List<EmployeePlanningWorkingModel> GetWorkingModels(EmployeePlanningWeek week)
        {
            if (week == null)
                throw new ArgumentNullException();

            List<EmployeePlanningWorkingModel> lstResult = new List<EmployeePlanningWorkingModel>();

            foreach (EmployeePlanningDay day in week.Days.Values)
            {
                if (day.WorkingModels != null && day.WorkingModels.Count > 0)
                {
                    lstResult.AddRange(day.WorkingModels);
                }
            }

            return lstResult;
        }

    }
}
