using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Contract.TimePlanning
{
    [Serializable]
    public sealed class EmployeeWeek : /*BaseEntity, */IBaumaxEmployeeWeek, IWorkingModelData
    {
        [NonSerialized]
        private bool _PlannedWeek = true;
        [NonSerialized]
        private bool _NewWeek = true;

        private DateTime _beginWeekDate;
        private DateTime _endWeekDate;

        private long _EmployeeId = 0;
        private long _orderHWGR;
        private string _EmployeeFullName = String.Empty;
        private int _EmployeeContractHoursPerWeek = 0;


        private int _CountWeeklyPlanningWorkingHours = 0;
        private int _CountWeeklyPlusMinusHours = 0;
        private int _CountWeeklyAdditionalCharges = 0;
        private int _CountWeeklyWorkingHours = 0;

        private int _Saldo = 0;
        
        private int _LastSaldo = 0;
        private int _WorkingTimeByMonth = 0;
        private byte _CountSunday = 0;
        private byte _CountSaturday = 0;
        private byte _WorkingDaysBefore = 0;
        private byte _WorkingDaysAfter = 0;


        private bool _AllIn = false;
        private bool _IsValidWeek = false;
        private EmployeeDay[] _days = new EmployeeDay[7];
        private bool _customedit = false;
        #region properties
        public bool IsValidWeek
        {
            get { return _IsValidWeek; }
        }
        public bool CustomEdit
        {
            get { return _customedit; }
            set { _customedit = value; }
        }
        public bool AllIn
        {
            get { return _AllIn; }
            set { _AllIn = value; }
        }
        public bool NewWeek
        {
            get { return _NewWeek; }
            set { _NewWeek = value; }
        }
        public bool PlannedWeek
        {
            get { return _PlannedWeek; }
            set { _PlannedWeek = value; }
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

        public int WorkingTimeByMonth
        {
            get { return _WorkingTimeByMonth; }
            set { _WorkingTimeByMonth = value; }
        }

        public int ContractHoursPerWeek
        {
            get { return _EmployeeContractHoursPerWeek; }
            set { _EmployeeContractHoursPerWeek = value; }
        }

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public long OrderHWGR
        {
            get { return _orderHWGR; }
            set { _orderHWGR = value; }
        }


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

        #endregion

        #region ctor

        public EmployeeWeek(long id, string fullname, DateTime from, DateTime to, long orderHWGR)
        {
            Debug.Assert(from.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(to.DayOfWeek == DayOfWeek.Sunday);

            _EmployeeId = id;
            _orderHWGR = orderHWGR;
            _EmployeeFullName = fullname;
            BeginDate = from;
            EndDate = to;

            BuildDays();
        }

        public EmployeeWeek(IEmployeeWeek week)
        {
            EmployeeWeekProcessor.Assign(week, this);
            BuildDays();
        }
        #endregion


        private void BuildDays()
        {
            DateTime d = BeginDate;
            while (d <= EndDate)
            {
                _days[(int)d.DayOfWeek] = new EmployeeDay(EmployeeId, d);
                d = d.AddDays(1);
            }
        }

        public EmployeeDay GetDay(DateTime date)
        {
            if (date >= BeginDate && date <= EndDate)
                return _days[(int)date.DayOfWeek];
            throw new Exception("Date out of week");
        }

        public IList DaysList
        {
            get { return _days; }
        }

        public bool IsHasWorld(long worldid)
        {
            foreach (EmployeeDay epd in _days)
            {
                if (epd.StoreWorldId == worldid) return true;
            }
            return false;
        }

        public bool IsHasWorldByDate(long worldid, DateTime date)
        {
            EmployeeDay epd = GetDay(date);
            return epd.StoreWorldId == worldid;
        }

        public bool IsSundayWorking
        {
            get
            {
                return _days[(int)DayOfWeek.Sunday].CountDailyWorkingHours > 0;
            }
        }
        public bool IsSaturdayWorking
        {
            get
            {
                return _days[(int)DayOfWeek.Saturday].CountDailyWorkingHours > 0;
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

        public int CountPlannedHoursByWorld(long worldid)
        {
            int result = 0;
            foreach (EmployeeDay epd in _days)
            {
                if (epd.StoreWorldId == worldid) result += epd.CountDailyPlannedWorkingHours;
            }
            return result;
        }

        public void CalculateBeforeWorkingModels()
        {
            _CountWeeklyPlanningWorkingHours = 0;
            _CountWeeklyAdditionalCharges = 0;
            _CountWeeklyWorkingHours = 0;
            ClearWorkingModel();

            foreach (EmployeeDay epd in _days)
            {
                //epd.Calculate();
                _CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                _CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
                _CountWeeklyWorkingHours += epd.CountDailyWorkingHours;
            }

            //if (AllIn) // don't need calculate additional charges
            //    _CountWeeklyAdditionalCharges = 0;

            if (AllIn)
                _CountWeeklyPlusMinusHours = _CountWeeklyPlanningWorkingHours - ContractHoursPerWeek;
            else
                _CountWeeklyPlusMinusHours = _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges - ContractHoursPerWeek;

            if (!CustomEdit)
                _Saldo = (LastSaldo - ContractHoursPerWeek) + _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges;

        }
        public void CalculateAfterWorkingModels()
        {
            _CountWeeklyPlanningWorkingHours = 0;
            _CountWeeklyAdditionalCharges = 0;

            foreach (EmployeeDay epd in _days)
            {
                _CountWeeklyPlanningWorkingHours += epd.CountDailyPlannedWorkingHours;
                _CountWeeklyAdditionalCharges += epd.CountDailyAdditionalCharges;
            }

            //if (AllIn) // don't need calculate additional charges
            //    _CountWeeklyAdditionalCharges = 0;

            if (AllIn)
                _CountWeeklyPlusMinusHours = _CountWeeklyPlanningWorkingHours - ContractHoursPerWeek;
            else
                _CountWeeklyPlusMinusHours = _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges - ContractHoursPerWeek;

            if (!CustomEdit)
                _Saldo = (LastSaldo - ContractHoursPerWeek) + _CountWeeklyPlanningWorkingHours + _CountWeeklyAdditionalCharges;

        }
        public void ClearWorkingModel()
        {
            foreach (EmployeeDay day in _days)
            {
                if (day.WorkingModels == null) continue;

                if (day.WorkingModels.Count > 0)
                    day.WorkingModels.Clear();
            }
        }
        public void InitWeekState()
        {
            _IsValidWeek = false;
            foreach (EmployeeDay day in _days)
                _IsValidWeek |= (day.IsValidDay);
        }
    }


    public static class EmployeeWeekProcessor
    {
        public static int GetLastSaldoFromSaldo(EmployeeWeek week)
        {

            int LastSaldo = week.Saldo - week.CountWeeklyPlusMinusHours;

            if (week.CustomEdit)
                LastSaldo = 0;

            return LastSaldo;


        }
        public static long[] GetEmployeeIds(List<EmployeeWeek> lst)
        {
            if (lst == null || lst.Count == 0) return null;
            long[] ids = new long[lst.Count];
            for (int i = 0; i < lst.Count; i++)
            {
                ids[i] = lst[i].EmployeeId;
            }
            return ids;
        }

        public static Dictionary<long, EmployeeWeek> GetDictionary(List<EmployeeWeek> lst)
        {
            Dictionary<long, EmployeeWeek> diction = new Dictionary<long, EmployeeWeek>();

            if (lst != null && lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    diction[lst[i].EmployeeId] = lst[i];
                }
            }

            return diction;
        }

        public static EmployeeWeek Assign(IEmployeeWeek entity, EmployeeWeek week)
        {
            //week.ID = entity.ID;
            if (entity.ID > 0)
                week.NewWeek = false;
            week.EmployeeId = entity.EmployeeID;
            week.OrderHWGR = entity.OrderHWGR;
            week.Saldo = entity.Saldo;
            week.BeginDate = entity.WeekBegin;
            week.EndDate = entity.WeekEnd;
            week.CountWeeklyAdditionalCharges = entity.AdditionalCharge;
            week.CountWeeklyPlanningWorkingHours = entity.PlannedHours;
            week.CountWeeklyPlusMinusHours = entity.PlusMinusHours;
            week.CountWeeklyWorkingHours = entity.WorkingHours;
            week.ContractHoursPerWeek = entity.ContractHours;
            week.CustomEdit = entity.CustomEdit;
            week.AllIn = entity.AllIn;
            return week;
        }

        public static IEmployeeWeek AssignTo(IEmployeeWeek entity, EmployeeWeek week)
        {
            //entity.ID = week.ID;
            entity.EmployeeID = week.EmployeeId;
            entity.OrderHWGR = week.OrderHWGR;
            entity.Saldo = week.Saldo;
            entity.WeekBegin = week.BeginDate;
            entity.WeekEnd = week.EndDate;
            entity.WeekNumber = DateTimeHelper.GetWeekNumber(week.BeginDate, week.EndDate);
            entity.AdditionalCharge = week.CountWeeklyAdditionalCharges;
            entity.PlannedHours = week.CountWeeklyPlanningWorkingHours;
            entity.PlusMinusHours = week.CountWeeklyPlusMinusHours;
            entity.WorkingHours = week.CountWeeklyWorkingHours;
            entity.ContractHours = week.ContractHoursPerWeek;
            entity.CustomEdit = week.CustomEdit;
            entity.AllIn = week.AllIn ;
            return entity;
        }

        
        public static List<EmployeeTimeRange> GetDelta(List<EmployeeWeek> lst, out long[] ids)
        {
            List<EmployeeTimeRange> resultList = new List<EmployeeTimeRange>();
            List<long> emplids = new List<long>();
            if (lst != null)
            {
                bool bModified = false;
                foreach (EmployeeWeek ew in lst)
                {
                    bModified = false;
                    foreach (EmployeeDay ed in ew.DaysList)
                    {
                        if (ed.Modified)
                        {
                            bModified = true;
                            break;
                        }
                    }

                    if (bModified )
                    {
                        emplids.Add(ew.EmployeeId);
                        foreach (EmployeeDay ed in ew.DaysList)
                        {
                            if (ed.TimeList != null) 
                                resultList.AddRange (ed.TimeList );
                        }
                    }
                }
            }
            ids = emplids.ToArray();
            return resultList;
        }

        public static List<EmployeeWeek> MarkAsRecordingWeek(List<EmployeeWeek> lst)
        {
            if (lst != null)
            {
                MarkPlannedFlag(lst, false);
            }
            return lst;
        }
        public static List<EmployeeWeek> MarkAsPlannedWeek(List<EmployeeWeek> lst)
        {
            if (lst != null)
            {
                MarkPlannedFlag(lst, true);
            }
            return lst;
        }
        public static List<EmployeeWeek> MarkPlannedFlag(List<EmployeeWeek> lst, bool value)
        {
            if (lst != null)
            {
                lst.ForEach(delegate(EmployeeWeek week)
                            {
                                week.PlannedWeek = value;
                            });
            }
            return lst;
        }

        public static List<EmployeeWorkingModel> GetWorkingModels(EmployeeWeek week)
        {
            if (week == null)
                throw new ArgumentNullException();

            List<EmployeeWorkingModel> lstResult = new List<EmployeeWorkingModel>();

            foreach (EmployeeDay day in week.DaysList)
            {
                if (day.WorkingModels != null && day.WorkingModels.Count > 0)
                {
                    lstResult.AddRange(day.WorkingModels);
                }
            }

            return lstResult;
        }


        public static List<EmployeeWeek> GetEmployeesByWorld(long storeworldid, List<EmployeeWeek> fullList)
        {
            List<EmployeeWeek> resultList = new List<EmployeeWeek> ();
            if (fullList != null && fullList.Count > 0)
            {
                foreach (EmployeeWeek week in fullList)
                {
                    if (week.IsHasWorld(storeworldid))
                        resultList.Add(week);
                }
            }

            return resultList;
        }


        //public static int BuildCountSundayForNextWeek(EmployeeWeek week)
        //{
        //    DateTime bDate = week.BeginDate;
        //    DateTime eDate = week.EndDate;

        //    int result = week.CountSunday;

        //    if (bDate.Month == eDate.Month)
        //    {
        //        // if sunday = last month day=> result = 0
        //        if (DateTimeHelper.IsLastDayOfMonth(eDate))
        //            result = 0;
        //        else 
        //            if (week.IsSundayWorking)
        //                result++;
        //    }
        //    else 
        //        if (week.IsSundayWorking)
        //            result = 1;

        //    return result;
        //}
        //public static int BuildCountSaturdayForNextWeek(EmployeeWeek week)
        //{
        //    DateTime bDate = week.BeginDate;
        //    DateTime eDate = week.EndDate;
        //    DateTime sDate = eDate.AddDays(-1);

        //    int result = week.CountSaturday;

        //    if (bDate.Month == sDate.Month)
        //    {
        //        if (week.IsSaturdayWorking)
        //            result++;

        //        if (bDate.Month != eDate.Month || DateTimeHelper.IsLastDayOfMonth (eDate))
        //                result = 0;
        //    }
        //    else 
        //        if (week.IsSaturdayWorking)
        //            result = 1;

        //    return result;
        //}
        //public static int BuildMonthSumForNextWeek(EmployeeWeek week)
        //{
        //    DateTime bDate = week.BeginDate;
        //    DateTime eDate = week.EndDate;
        //    int result = week.WorkingTimeByMonth;

        //    if (bDate.Month == eDate.Month)
        //    {
        //        result += week.CountWeeklyPlanningWorkingHours;

        //        if (DateTimeHelper.IsLastDayOfMonth(eDate))
        //            result = 0;
        //    }
        //    else
        //    {
        //        int sum = 0;

        //        foreach (EmployeeDay day in week.DaysList)
        //            if (day.Date.Month == eDate.Month)
        //                sum += day.CountDailyPlannedWorkingHours;
        //        result = sum;
        //    }
                

        //    return result;
        //}


        public static bool IsModified(EmployeeWeekTimeRecording entity, EmployeeWeek week)
        {
            return (entity.EmployeeID != week.EmployeeId ||
            entity.Saldo != week.Saldo ||
            entity.WeekBegin != week.BeginDate ||
            entity.WeekEnd != week.EndDate ||
            entity.WeekNumber != DateTimeHelper.GetWeekNumber(week.BeginDate, week.EndDate) ||
            entity.AdditionalCharge != week.CountWeeklyAdditionalCharges ||
            entity.PlannedHours != week.CountWeeklyPlanningWorkingHours ||
            entity.PlusMinusHours != week.CountWeeklyPlusMinusHours ||
            entity.WorkingHours != week.CountWeeklyWorkingHours ||
            entity.ContractHours != week.ContractHoursPerWeek ||
            entity.CustomEdit != week.CustomEdit ||
            entity.AllIn != week.AllIn );
        }

        public static bool IsModified(EmployeeWeekTimePlanning entity, EmployeeWeek week)
        {
            return (entity.EmployeeID != week.EmployeeId ||
            entity.Saldo != week.Saldo ||
            entity.WeekBegin != week.BeginDate ||
            entity.WeekEnd != week.EndDate ||
            entity.WeekNumber != DateTimeHelper.GetWeekNumber(week.BeginDate, week.EndDate) ||
            entity.AdditionalCharge != week.CountWeeklyAdditionalCharges ||
            entity.PlannedHours != week.CountWeeklyPlanningWorkingHours ||
            entity.PlusMinusHours != week.CountWeeklyPlusMinusHours ||
            entity.WorkingHours != week.CountWeeklyWorkingHours ||
            entity.ContractHours != week.ContractHoursPerWeek ||
            entity.CustomEdit != week.CustomEdit ||
            entity.AllIn != week.AllIn);
        }
    }
}
