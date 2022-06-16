using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using System.Diagnostics;

namespace Baumax.Services._HelperObjects
{
    public class EmployeeMonthWorkingTime
    {
        EmployeeTimeService _timeservice;

        //Dictionary<DateTime, EmployeeWeekTimePlanning> _planningWeek = new Dictionary<DateTime, EmployeeWeekTimePlanning>();
        //Dictionary<DateTime, EmployeeWeekTimeRecording> _recordingWeek = new Dictionary<DateTime, EmployeeWeekTimeRecording>();

        //Dictionary<DateTime, EmployeeDayStatePlanning> _planningDay = new Dictionary<DateTime, EmployeeDayStatePlanning>();
        //Dictionary<DateTime, EmployeeDayStateRecording> _recordingDay = new Dictionary<DateTime, EmployeeDayStateRecording>();

        Dictionary<DateTime, IEmployeeDay> _days_diction = new Dictionary<DateTime, IEmployeeDay>(31);
        private bool _IsPlanning = true;

        public bool IsPlanning
        {
            get { return _IsPlanning; }
            set { _IsPlanning = value; }
        }



        public EmployeeMonthWorkingTime(EmployeeTimeService timeservice)
        {
            if (timeservice == null)
                throw new ArgumentNullException();

            _timeservice = timeservice;
        }

        private DateTime _currentMonday;

        public DateTime CurrentMonday
        {
            get { return _currentMonday; }
            set { _currentMonday = value; }
        }
        private DateTime _beginMonth = DateTime.Today;
        private DateTime _beginMonthMonday = DateTime.Today;


        private int _CountSaturday;

        public int CountSaturday
        {
            get { return _CountSaturday; }
            set { _CountSaturday = value; }
        }
        private int _CountSunday;

        public int CountSunday
        {
            get { return _CountSunday; }
            set { _CountSunday = value; }
        }
        private int _workingDaysBefore;

        public int WorkingDaysBefore
        {
            get { return _workingDaysBefore; }
            set { _workingDaysBefore = value; }
        }
        private int _workingdaysafter;

        public int WorkingDaysAfter
        {
            get { return _workingdaysafter; }
            set { _workingdaysafter = value; }
        }
        
        //public int GetMonthWorkingTime2(long employeeid)
        //{
        //    CountSaturday = 0;
        //    CountSunday = 0;
        //    _beginMonth = new DateTime(CurrentMonday.Year, CurrentMonday.Month, 1);
        //    _beginMonthMonday = DateTimeHelper.GetMonday(_beginMonth);
        //    DateTime endDateSunday = CurrentMonday.AddDays(-1);


        //    #region Load data



        //    _planningWeek.Clear();
        //    if (IsPlanning)
        //    {
        //        EmployeeWeekTimePlanningService weekplanningservice = _timeservice.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService;

        //        List<EmployeeWeekTimePlanning> lstPlanning =
        //            weekplanningservice.GetEmployeesWeekStateByDateRange(new long[] { employeeid }, _beginMonthMonday, endDateSunday);


        //        if (lstPlanning != null && lstPlanning.Count > 0)
        //        {
        //            for (int i = 0; i < lstPlanning.Count; i++)
        //            {
        //                _planningWeek[lstPlanning[i].WeekBegin] = lstPlanning[i];
        //            }
        //        }
        //    }
        //    EmployeeWeekTimeRecordingService rec_service = _timeservice.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;

        //    List<EmployeeWeekTimeRecording> lstRecord =
        //        rec_service.GetEmployeesWeekStateByDateRange(new long[] { employeeid }, _beginMonthMonday, endDateSunday);

        //    _recordingWeek.Clear();
        //    if (lstRecord != null && lstRecord.Count > 0)
        //    {
        //        for (int i = 0; i < lstRecord.Count; i++)
        //        {
        //            _recordingWeek[lstRecord[i].WeekBegin] = lstRecord[i];
        //        }
        //    }



        //    _planningDay.Clear();
        //    if (IsPlanning)
        //    {
        //        EmployeeDayStatePlanningService plan_dayservice = _timeservice.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService;

        //        List<EmployeeDayStatePlanning> lstDayPlanning = plan_dayservice.GetEmployeeStates(employeeid, _beginMonth, endDateSunday);


        //        if (lstDayPlanning != null && lstDayPlanning.Count > 0)
        //        {
        //            for (int i = 0; i < lstDayPlanning.Count; i++)
        //            {
        //                _planningDay[lstDayPlanning[i].Date] = lstDayPlanning[i];
        //            }
        //        }
        //    }

        //    EmployeeDayStateRecordingService rec_dayservice = _timeservice.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService;

        //    List<EmployeeDayStateRecording> lstDayRecord = rec_dayservice.GetEmployeeStates(employeeid, _beginMonth, endDateSunday);

        //    _recordingDay.Clear();
        //    if (lstDayRecord != null && lstDayRecord.Count > 0)
        //    {
        //        for (int i = 0; i < lstDayRecord.Count; i++)
        //        {
        //            _recordingDay[lstDayRecord[i].Date] = lstDayRecord[i];
        //        }
        //    }

        //    #endregion

        //    DateTime day = _beginMonthMonday;
        //    int resultValue = 0;


        //    DateTime begin;
        //    while (day < CurrentMonday)
        //    {
        //        if (_recordingWeek.ContainsKey(day))
        //        {
        //            //EmployeeWeekTimeRecording week = _recordingWeek[day];
        //            for (int i = 0; i < 7; i++)
        //            {
        //                begin = day.AddDays(i);
        //                if (_recordingDay.ContainsKey(begin))
        //                {
        //                    EmployeeDayStateRecording daystate = _recordingDay[begin];
        //                    if (begin.Month == CurrentMonday.Month)
        //                    {
        //                        resultValue += daystate.AllreadyPlannedHours;
        //                        if (begin.DayOfWeek == DayOfWeek.Saturday)
        //                        {
        //                            if (daystate.WorkingHours > 0)
        //                                CountSaturday++;
        //                        }
        //                        if (begin.DayOfWeek == DayOfWeek.Sunday )
        //                        {
        //                            if (daystate.WorkingHours > 0)
        //                                CountSunday++;
        //                        }

        //                    }
        //                }
        //            }

        //        }
        //        else if (_planningWeek.ContainsKey(day))
        //        {
        //            //EmployeeWeekTimePlanning week = _planningWeek[day];
        //            for (int i = 0; i < 7; i++)
        //            {
        //                begin = day.AddDays(i);
        //                if (_planningDay.ContainsKey(begin))
        //                {
        //                    EmployeeDayStatePlanning daystate = _planningDay[begin];
        //                    if (begin.Month == CurrentMonday.Month)
        //                        resultValue += daystate.AllreadyPlannedHours;
        //                    if (begin.DayOfWeek == DayOfWeek.Saturday)
        //                    {
        //                        if (daystate.WorkingHours > 0)
        //                            CountSaturday++;
        //                    }
        //                    if (begin.DayOfWeek == DayOfWeek.Sunday)
        //                    {
        //                        if (daystate.WorkingHours > 0)
        //                            CountSunday++;
        //                    }
        //                }
        //            }
        //        }


        //        day = day.AddDays(7);
        //    }


        //    begin = CurrentMonday.AddDays(-7);
        //    if (_recordingWeek.ContainsKey(begin))
        //    {
        //        EmployeeDayStateRecording daystate = null;
        //        for (int i = 1; i >= 7; i++)
        //        {
        //            begin = CurrentMonday.AddDays(-i);
        //            if (_recordingDay.TryGetValue(begin, out daystate) && daystate.WorkingHours > 0)
        //            {
        //                WorkingDaysBefore++;
        //            }
        //            else
        //                break;
                    
        //        }
        //    }
        //    else if (_planningWeek.ContainsKey(begin))
        //    {
        //        EmployeeDayStatePlanning daystate = null;
        //        for (int i = 1; i >= 7; i++)
        //        {
        //            begin = CurrentMonday.AddDays(-i);

        //            if (_planningDay.TryGetValue(begin, out daystate) && daystate.WorkingHours > 0)
        //            {
        //                    WorkingDaysBefore++;
        //            }
        //            else
        //                break;
        //        }
        //    }
        //    return resultValue;
        //}


        public int GetMonthWorkingTime(long employeeid)
        {
            CountSaturday = 0;
            CountSunday = 0;
            WorkingDaysBefore = 0;
            WorkingDaysAfter = 0;

            _beginMonth = new DateTime(CurrentMonday.Year, CurrentMonday.Month, 1);
            _beginMonthMonday = DateTimeHelper.GetMonday(_beginMonth);
            DateTime endDateSunday = CurrentMonday.AddDays(13); // next week sunday = 7+6
            if (_beginMonthMonday > CurrentMonday.AddDays(-7))
                _beginMonthMonday = CurrentMonday.AddDays(-7);

            int resultValue = 0;
            #region Load data

            _days_diction.Clear();
            //if (IsPlanning)
            //{

            EmployeePlanningDayListEx lst_planning = new EmployeePlanningDayListEx(employeeid, _beginMonthMonday, endDateSunday);

            if (lst_planning != null && lst_planning.Count > 0)
            {
                for (int i = 0; i < lst_planning.Count; i++)
                {
                    _days_diction[lst_planning[i].Date] = (IEmployeeDay)lst_planning[i];
                }
            }
            //}

            EmployeeRecordingDayListEx lstDayRecord = new EmployeeRecordingDayListEx(employeeid, _beginMonthMonday, endDateSunday);


            if (lstDayRecord != null && lstDayRecord.Count > 0)
            {
                for (int i = 0; i < lstDayRecord.Count; i++)
                {
                    _days_diction[lstDayRecord[i].Date] = (IEmployeeDay)lstDayRecord[i];
                }
            }

            #endregion

            foreach (IEmployeeDay day in _days_diction.Values)
            {
                if (day.Date < CurrentMonday && day.Date.Month == CurrentMonday.Month)
                {
                    resultValue += day.AllreadyPlannedHours;

                    if (day.Date.DayOfWeek == DayOfWeek.Saturday && day.WorkingHours > 0)
                    {
                            CountSaturday++;
                    }
                    if (day.Date.DayOfWeek == DayOfWeek.Sunday && day.WorkingHours > 0)
                    {
                            CountSunday++;
                    }
                }
            }
            DateTime begin;
            IEmployeeDay day_item = null;
            for (int i = 1; i <= 7; i++)
            {
                begin = CurrentMonday.AddDays(-i);
                if (_days_diction.TryGetValue(begin, out day_item) && day_item.WorkingHours > 0)
                {
                    WorkingDaysBefore++;
                }
                else
                    break;

            }
            DateTime sunday = DateTimeHelper.GetSunday(CurrentMonday);
            for (int i = 1; i <= 7; i++)
            {
                begin = sunday.AddDays(i);
                if (_days_diction.TryGetValue(begin, out day_item) && day_item.WorkingHours > 0)
                {
                    WorkingDaysAfter++;
                }
                else
                    break;

            }
            return resultValue;
        }


        public void ProcessWeeks(List<EmployeeWeek> weeks, long[] ids)
        {
            // 1.need load dayinfo for previous and next weeks
            // 2. load dayinfo from begin of month(month of monday)
            DateTime beginMonth = new DateTime(CurrentMonday.Year, CurrentMonday.Month, 1);
            DateTime beginMonthMonday = DateTimeHelper.GetMonday(beginMonth);


            DateTime beginPrevWeek = CurrentMonday.AddDays(-7);
            DateTime endNextWeek = CurrentMonday.AddDays(13);

            DateTime beginDate = (beginMonthMonday < beginPrevWeek) ? beginMonthMonday : beginPrevWeek;

            SrvEmployeesPlanningDayList cache_planning_days = new SrvEmployeesPlanningDayList(ids, beginDate, endNextWeek );
            SrvEmployeesRecordingDayList cache_actual_days = new SrvEmployeesRecordingDayList(ids, beginDate, endNextWeek);

            foreach (EmployeeWeek w in weeks)
            {
                ProcessWeek(cache_planning_days.GetList(w.EmployeeId), cache_actual_days.GetList(w.EmployeeId), w);
            }

        }
        public void ProcessWeeks(List<EmployeePlanningWeek> weeks, long[] ids)
        {
            // 1.need load dayinfo for previous and next weeks
            // 2. load dayinfo from begin of month(month of monday)
            DateTime beginMonth = new DateTime(CurrentMonday.Year, CurrentMonday.Month, 1);
            DateTime beginMonthMonday = DateTimeHelper.GetMonday(beginMonth);


            DateTime beginPrevWeek = CurrentMonday.AddDays(-7);
            DateTime endNextWeek = CurrentMonday.AddDays(13);

            DateTime beginDate = (beginMonthMonday < beginPrevWeek) ? beginMonthMonday : beginPrevWeek;

            SrvEmployeesPlanningDayList cache_planning_days = new SrvEmployeesPlanningDayList(ids, beginDate, endNextWeek);
            SrvEmployeesRecordingDayList cache_actual_days = new SrvEmployeesRecordingDayList(ids, beginDate, endNextWeek);

            foreach (EmployeePlanningWeek w in weeks)
            {
                ProcessWeek(cache_planning_days.GetList(w.EmployeeId), cache_actual_days.GetList(w.EmployeeId), w);
            }

        }
        protected void ProcessWeek(EmployeePlanningDayList planning_days, SrvEmployeeRecordingDayList actual_days, IWorkingModelData week)
        {
            CountSaturday = 0;
            CountSunday = 0;
            WorkingDaysBefore = 0;
            WorkingDaysAfter = 0;

            _days_diction.Clear();

            DateTime endDateSunday = CurrentMonday.AddDays(13);

            if (planning_days != null && planning_days.List != null && planning_days.List.Count > 0)
            {
                for (int i = 0; i < planning_days.List.Count; i++)
                {
                    if (planning_days.List[i].Date <= endDateSunday)
                    {
                        _days_diction[planning_days.List[i].Date] = (IEmployeeDay)planning_days.List[i];
                    }
                }
            }


            if (actual_days!= null && actual_days.List != null && actual_days.List.Count > 0)
            {
                for (int i = 0; i < actual_days.List.Count; i++)
                {
                    if (actual_days.List[i].Date <= endDateSunday)
                        _days_diction[actual_days.List[i].Date] = (IEmployeeDay)actual_days.List[i];
                }
            }


            int SumOfPlannedHoursByMonth = 0;
            foreach (IEmployeeDay day in _days_diction.Values)
            {
                if (day.Date < CurrentMonday && day.Date.Month == CurrentMonday.Month)
                {
                    SumOfPlannedHoursByMonth += day.AllreadyPlannedHours;

                    if (day.Date.DayOfWeek == DayOfWeek.Saturday && day.WorkingHours > 0)
                    {
                            CountSaturday++;
                    }
                    if (day.Date.DayOfWeek == DayOfWeek.Sunday && day.WorkingHours > 0)
                    {
                            CountSunday++;
                    }
                }
            }
            DateTime begin;
            IEmployeeDay day_item = null;
            for (int i = 1; i <= 7; i++)
            {
                begin = CurrentMonday.AddDays(-i);
                if (_days_diction.TryGetValue(begin, out day_item) && day_item.WorkingHours > 0)
                {
                    WorkingDaysBefore++;
                }
                else
                    break;

            }
            DateTime sunday = DateTimeHelper.GetSunday(CurrentMonday);
            for (int i = 1; i <= 7; i++)
            {
                begin = sunday.AddDays(i);
                if (_days_diction.TryGetValue(begin, out day_item) && day_item.WorkingHours > 0)
                {
                    WorkingDaysAfter++;
                }
                else
                    break;

            }


            //Debug.Assert(week.WorkingTimeByMonth == SumOfPlannedHoursByMonth);
            //Debug.Assert(week.CountSaturday == (byte)CountSaturday);
            //Debug.Assert(week.CountSunday == (byte)CountSunday);
            //Debug.Assert(week.WorkingDaysBefore == (byte)WorkingDaysBefore);
            //Debug.Assert(week.WorkingDaysAfter == (byte)WorkingDaysAfter);


            week.WorkingTimeByMonth = SumOfPlannedHoursByMonth;
            week.CountSaturday = (byte)CountSaturday;
            week.CountSunday = (byte)CountSunday;

            week.WorkingDaysBefore = (byte)WorkingDaysBefore;
            week.WorkingDaysAfter = (byte)WorkingDaysAfter;
        }
    }
}
