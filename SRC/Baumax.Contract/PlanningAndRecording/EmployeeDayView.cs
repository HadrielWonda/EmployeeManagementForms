using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Baumax.Domain;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.TimePlanning
{

    public class EmployeeDayViewList:Dictionary<long, EmployeeDayView>
    {

        private StoreWorldWeekPlanningState _WorldWeekState = null;
        private List<EmployeePlanningWeek> _DayWeeklyList = null;
        int[] m_totalTimes = new int[24 * 4];
        int[] m_UnitPerHour = new int[24];
        private int _TotalWorkingHoursPerWeek = 0;
        private int _TotalPlannedWorkingHours = 0;
        private int _TotalSumOfAdditianalCharges = 0;
        private int _TotalPlusMinusHours = 0;
        private int _TotalEmployeeBalanceHours = 0;
        private int _TotalPlannedHoursPerDay = 0;
        private DateTime _date;
        public bool _bCashDesk = false;
        

        public EmployeeDayViewList(StoreWorldWeekPlanningState state, DateTime date)
        {
            AddEmployeePlanningWeeks(state, date);
        }
        public DateTime ViewDate
        {
            get { return _date; }
        }
        public StoreWorldWeekPlanningState WorldWeekState
        {
            get { return _WorldWeekState; }
        }
        public List<EmployeePlanningWeek> DayWeeklyList
        {
            get { return _DayWeeklyList; }
        }
        public int TotalWorkingHoursPerWeek
        {
            get { return _TotalWorkingHoursPerWeek; }
            set { _TotalWorkingHoursPerWeek = value; }
        }
        public int TotalPlannedHoursPerDay
        {
            get { return _TotalPlannedHoursPerDay; }
            set { _TotalPlannedHoursPerDay = value; }
        }
        public int TotalPlannedWorkingHours
        {
            get { return _TotalPlannedWorkingHours; }
            set { _TotalPlannedWorkingHours = value; }
        }

        public int TotalSumOfAdditianalCharges
        {
            get { return _TotalSumOfAdditianalCharges; }
            set { _TotalSumOfAdditianalCharges = value; }
        }

        public int TotalPlusMinusHours
        {
            get { return _TotalPlusMinusHours; }
            set { _TotalPlusMinusHours = value; }
        }

        public int TotalEmployeeBalanceHours
        {
            get { return _TotalEmployeeBalanceHours; }
            set { _TotalEmployeeBalanceHours = value; }
        }

        public EmployeeDayView GetByEmployeeId(long id)
        {
            EmployeeDayView obj = null;
            this.TryGetValue(id, out obj);
            return obj;
        }

        public void ClearAll()
        {
            for (int i = 0; i < 24 * 4; i++)
            {
                m_totalTimes[i] = 0;
                m_UnitPerHour[i / 4] = 0;
            }
            TotalPlannedHoursPerDay = 0;
            _TotalWorkingHoursPerWeek = 0;
            _TotalPlannedWorkingHours = 0;
            _TotalSumOfAdditianalCharges = 0;
            _TotalPlusMinusHours = 0;
            _TotalEmployeeBalanceHours = 0;
        }
        
        public void RecalculateTotals()
        {
            ClearAll();

            foreach (EmployeeDayView  var in this.Values)
            {
                var.UpdateCountWorkingTime();
                for (int i = 0; i < 24*4; i++)
                {
                    if (var.IsWorkingTime(i))
                    {
                        m_totalTimes[i] += 15;
                        TotalPlannedHoursPerDay += 15;
                    }

                    if (_bCashDesk)
                    {
                        if (i % 4 == 0)
                        {
                            int ii = i / 4;
                            bool b = false;
                            b |= var.IsWorkingTime(i);
                            b |= var.IsWorkingTime(i + 1);
                            b |= var.IsWorkingTime(i + 2);
                            b |= var.IsWorkingTime(i + 3);
                            if (b)
                            {
                                m_UnitPerHour[ii]++;
                            }
                        }
                    }
                }
            }



            if (_WorldWeekState != null && _DayWeeklyList != null)
            {
                _WorldWeekState.Calculate();

                EmployeePlanningDay epd = null;
                foreach (EmployeePlanningWeek epw in _DayWeeklyList)
                {

                    epd = epw.Days[ViewDate];

                    TotalWorkingHoursPerWeek += epw.ContractHoursPerWeek;
                    TotalPlannedWorkingHours += epd.CountDailyPlannedWorkingHours;
                    TotalSumOfAdditianalCharges += epd.CountDailyAdditionalCharges;
                    TotalPlusMinusHours += epw.CountWeeklyPlusMinusHours;
                    TotalEmployeeBalanceHours += epw.Saldo;

                }
            }
        }


        public int[] GetUnitsPerHour()
        {
            int[] array = new int[24];
            m_UnitPerHour.CopyTo(array, 0);
            return array;
        }
        public int GetTotals(int time, DailyViewStyle vstyle)
        {
            int iCount = 1;
            int aIndex = time / 15;
            int result = 0;

            if (vstyle == DailyViewStyle.View30) iCount = 2;
            else 
                if (vstyle == DailyViewStyle.View60) iCount = 4;
            
            iCount += aIndex;
            for (int i = aIndex; i < iCount; i++)
            {
                result += m_totalTimes[i];
            }
            
            return result;

        }
        public int[] GetTotalsSumByHours()
        {
            int[] array = new int[24];
            for (int i = 0; i < 24; i++)
            {
                array[i] = GetTotals(i * 60, DailyViewStyle.View60);
            }
            return array;
        }
        private void AddEmployeePlanningWeeks(StoreWorldWeekPlanningState worldweekstate, DateTime date)
        {
            ClearAll();
            _WorldWeekState = worldweekstate;
            _date = date;
            if (WorldWeekState != null)
            {
                _DayWeeklyList = PlanningWeekProcessor.GetEmployeesByWorldAndDate(WorldWeekState.StoreWorldId, date, WorldWeekState.List);
                if (_DayWeeklyList != null)
                {
                    EmployeeDayView dayView = null;
                    EmployeePlanningDay dayPlanning = null;
                    foreach (EmployeePlanningWeek emplWeek in _DayWeeklyList)
                    {

                        if (emplWeek.Days.TryGetValue(date, out dayPlanning))
                        {
                            if (!dayPlanning.HasContract || dayPlanning.HasLongAbsence
                                || !dayPlanning.HasRelation) continue;


                            dayView = new EmployeeDayView(emplWeek.EmployeeId, date);
                            this[emplWeek.EmployeeId] = dayView;

                            dayView.SetEmployeePlanningDay(dayPlanning);
                            TotalWorkingHoursPerWeek += dayView.ContractHoursPerWeek;
                        }

                    }
                }
            }
            else
            {
                ClearAll();
            }
        }
    }

    public class EmployeeDayView
    {
        private List<WorkingTimeRange> m_list = new List<WorkingTimeRange>(24*4);

        private long m_employeeId = 0;
        private bool m_modified = false;
        private int m_contracthoursperweek = 0;
        private int m_totalworkingtime = 0;
        private DateTime _ViewDate;
        private EmployeePlanningDay _planningday = null;


        public bool Modified
        {
            get { return m_modified; }
            set { m_modified = value; }
        }

        public long EmployeeId
        {
            get { return m_employeeId; }
            set { m_employeeId = value; }
        }

        public DateTime ViewDate { get { return _ViewDate; } }

        public EmployeePlanningDay PlanningDay 
        { 
            get { return _planningday; }
            set { _planningday = value; }
        }

        public int TotalWorkingTime
        {
            get
            {
                return m_totalworkingtime;
            }
        }

        public int ContractHoursPerWeek
        {
            get { return m_contracthoursperweek; }
            set { m_contracthoursperweek = value; }
        }

        public EmployeeDayView(long emplid, DateTime viewdate)
        {
            m_employeeId = emplid;
            _ViewDate = viewdate;
            for (int i = 0; i < 24*4; i++)
            {
                m_list.Add (new WorkingTimeRange (EmployeeId, (i * 15)));
            }
        }

        public void Reset()
        {
            if (m_list.Count == 0)
            {
                for (int i = 0; i < 24 * 4; i++)
                {
                    m_list.Add(new WorkingTimeRange(EmployeeId, (i * 15)));
                }
            }
            else
            {
                foreach (WorkingTimeRange wtr in m_list)
                {
                    wtr.Clear();
                    wtr.EmployeeId = EmployeeId;
                }
            }
            Modified = false;
        }

        public void AddWorkingTime(int begintime, int endtime)
        {
            int beginIndex = (int)(begintime / 15);
            int endIndex = (int)(endtime / 15);

            for (int i = beginIndex; i < endIndex; i++)
            {
                if (m_list [i].SetAsWorkignTime ()) Modified = true;
            }

        }

        public void SetAsWorkingTimeIfEmpty(int index)
        {
            if (!m_list[index].Bizy)

                Modified |= m_list[index].SetAsWorkignTime();
        }

        public void RemoveWorkingTime(int begintime, int endtime)
        {
            foreach (WorkingTimeRange var in m_list)
            {
                if (begintime <= var.Time && var.Time < endtime)
                {
                    if (var.ResetRange()) Modified = true;
                }
            }
        }

        public int UpdateCountWorkingTime()
        {
            m_totalworkingtime = 0;
            
            foreach (WorkingTimeRange  var in m_list)
            {
                if (var.IsWorkigntime) m_totalworkingtime += 15;
                else if (var.Absence != null && var.Absence.UseInCalck) m_totalworkingtime += 15;
            }

            return m_totalworkingtime;
        }

        public bool IsBuzyByTimeRange(int begintime, int endtime)
        {
            int b_index = begintime / 15;
            int e_index = endtime / 15;

            for (int i = b_index; i < e_index; i++)
            {
                if (IsBizy(i)) return true;
            }
            return false;
        }

        public bool IsBizy(int index)
        {
            if (index >= 0 && index < 24 * 4)
                return m_list[index].Bizy;
            else return false;
        }

        public bool IsWorkingTime(int index)
        {
            if (index >= 0 && index < 24 * 4)
                return m_list[index].IsWorkigntime;
            else return false;
        }

        public bool IsAbsenceTime(int index)
        {
            if (index >= 0 && index < 24 * 4)
                return m_list[index].Absence != null;
            return false;
        }

        public void SetAbsence(Absence absence, int begintime, int endtime)
        {
            foreach (WorkingTimeRange var in m_list)
            {
                if (begintime <= var.Time && var.Time < endtime)
                {
                    if (var.SetAsAbsence(absence)) Modified = true;
                }
            }
        }

        public Color GetColor(int index)
        {
            if (index >= 0 && index < 24 * 4)
                return m_list[index].RangeColor;
            else return Color.White;
        }

        public long GetAbsenceId(int index)
        {
            if (index >= 0 && index < 24 * 4)
                return m_list[index].AbsenceId;
            else return 0;
        }

        public void SetEmployeePlanningDay(EmployeePlanningDay emp_day)
        {
            _planningday = emp_day;
            ContractHoursPerWeek = Convert.ToInt32(_planningday.ContractHoursPerWeek * 60);
            SetWorkingTimePlanningEntities(_planningday.WorkingTimeList);
            SetAbsenceTimePlanningEntities(_planningday.AbsenceTimeList);
            Modified = false;
        }

        public void UpdateEmployeePlanningDay()
        {
            if (Modified)
            {
                _planningday.WorkingTimeList = GetWorkingTimePlanningEntities(ViewDate);
                _planningday.AbsenceTimeList = GetAbsenceTimePlanningEntities(ViewDate);
                _planningday.Modified = true;
                Modified = false;
            }
        }

        public List<WorkingTimePlanning> GetWorkingTimePlanningEntities(DateTime date)
        {
            int starttime = -1;
            int endtime = -1;
            List<WorkingTimePlanning> resultList = new List<WorkingTimePlanning>();
            for (int i = 0; i <= 24*4; i++)
            {
                if (IsWorkingTime(i))
                {
                    if (starttime == -1)
                    {
                        starttime = i * 15;
                        endtime = i * 15 + 15;
                        continue;
                    }
                    endtime = i * 15 + 15;;
                }
                else
                {
                    if (starttime != -1)
                    {
                        WorkingTimePlanning entity = new WorkingTimePlanning (
                            date, 
                            (short)(starttime),
                            (short)(endtime),
                            (short) (endtime - starttime),
                            EmployeeId );

                        resultList.Add(entity);
                        starttime = -1;

                    }
                }
            }

            return resultList;
        }

        public void SetWorkingTimePlanningEntities(List<WorkingTimePlanning> times)
        {
            if (times != null && times.Count > 0)
            {
                foreach (WorkingTimePlanning  wtp in times)
                {
                    AddWorkingTime(wtp.Begin, wtp.End);
                }
            }
        }

        public void SetAbsenceTimePlanningEntities(List<AbsenceTimePlanning> times)
        {
            if (times != null && times.Count > 0)
            {
                foreach (AbsenceTimePlanning wtp in times)
                {
                    SetAbsence(wtp.Absence , wtp.Begin, wtp.End);
                }
            }
        }
        public List<AbsenceTimePlanning> GetAbsenceTimePlanningEntities(DateTime date)
        {
            List<AbsenceTimePlanning> resultList = new List<AbsenceTimePlanning>();
            AbsenceTimePlanning absence = null;
            for (int i = 0; i <= 24 * 4; i++)
            {
                if (IsAbsenceTime(i))
                {

                    if (absence != null && absence.AbsenceID != GetAbsenceId(i))
                    {
                        absence.End = (short)(i * 15);// - 15);
                        resultList.Add(absence);
                        absence = null;
                    }
                    if (absence == null)
                    {
                        absence = new AbsenceTimePlanning();
                        absence.AbsenceID = GetAbsenceId(i);
                        absence.Begin = (short)(i * 15);
                        absence.Date = date;
                        absence.EmployeeID = EmployeeId;
                    }
                    
                }
                else
                {
                    if (absence != null)
                    {
                        absence.End = (short)(i * 15 );//- 15);
                        resultList.Add(absence);
                        absence = null;
                    }
                }
            }

            return resultList;
        }


        public bool Compare(EmployeeDayView view)
        {
            for (int i = 0; i < m_list.Count; i++)
            {
                if (!m_list[i].Compare(view.m_list[i])) return false;
            }
            return true;
        }

    }

    public class WorkingTimeRange
    {
        private static Color EMPTY_COLOR = Color.White;
        private static Color WORK_COLOR = Color.Blue;
        long m_employeeId = 0;
        int m_Time = 0;
        Absence _absence = null;
        Color m_color;
        bool m_isWorkigntime = false;

        public WorkingTimeRange()
        {
            m_color = EMPTY_COLOR;
            m_Time = 0;
            _absence = null;
            m_employeeId = 0;
            m_isWorkigntime = false;
        }
        public bool Compare(WorkingTimeRange range)
        {
            return (_absence == range.Absence &&
                    m_Time == range.Time &&
                    m_isWorkigntime == range.IsWorkigntime
                    );

        }


        public long EmployeeId
        {
            get { return m_employeeId; }
            set { m_employeeId = value; }
        }

        public bool Bizy
        {
            get { return m_isWorkigntime || Absence != null; }
        }

        public bool IsWorkigntime
        {
            get { return m_isWorkigntime; }
            set 
            { 
                m_isWorkigntime = value;
                if (IsWorkigntime)
                {
                    _absence = null;
                    RangeColor = WORK_COLOR;
                }
            }
            
        }
        public long AbsenceId
        {
            get 
            {
                if (Absence != null) return Absence.ID;
                else return (long)0; 
            }
        }
        public Color RangeColor
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }

        public Absence Absence
        {
            get { return _absence; }
            set
            {
                if (value != null)
                {
                    _absence = value;
                    m_isWorkigntime = false;
                    RangeColor = Color.FromArgb(Absence.Color); 
                }
                else
                {
                    _absence = null;
                    RangeColor = EMPTY_COLOR;
                }
            }
        }

        public WorkingTimeRange(long emplid)
            : this()
        {
            m_employeeId = emplid;
        }
        public WorkingTimeRange(long emplid, int a):this()
        {
            m_employeeId = emplid;
            m_Time = a;
        }

        public bool SetAsWorkignTime()
        {
            bool modified = false;
            if (!Bizy) modified = true;

            if (this.Absence != null) modified = true;

            IsWorkigntime = true;

            return modified;
        }

        public bool SetAsAbsence(Absence absence)
        {
            bool modified = false;
            if (!Bizy) modified = true;
            if (IsWorkigntime) modified = true;

            this.Absence = absence ;
            return modified;
        }
        public bool ResetRange()
        {
            bool modified = false;
            if (Bizy) modified = true;
            if (IsWorkigntime) modified = true;
            if (this.Absence != null) modified = true;

            this.Absence = null;

            RangeColor = EMPTY_COLOR;
            IsWorkigntime = false;

            return modified;
        }

        public void Clear()
        {
            Absence = null;
            RangeColor = EMPTY_COLOR;
            IsWorkigntime = false;
            EmployeeId = 0;
        }
    }

    public enum DailyViewStyle
    {
        View15 = 15,
        View30 = 30,
        View60 = 60
    }

    public class TimeColumnInfo
    {
        // time-range - store open
        bool m_opening = true;

        int m_fromTime = 0;
        int m_toTime = 0;

        public TimeColumnInfo( int a, int b, bool isopen)
        {
            m_fromTime = a;
            m_toTime = b;
            m_opening = isopen;
        }


        public int FromTime { get { return m_fromTime; } }
        public int ToTime { get { return m_toTime; } }
        public bool IsOpening
        {
            get { return m_opening; }
            set { m_opening = value; }
        }

    }
}
