using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract
{
    public class LunchBrakeModelManager
    {
        private IWorkingModelService _modelService = null;
        private long _countryId = 0;
        private bool _DurationATime = false;
        List<LunchBrakeModel> _innerList = new List<LunchBrakeModel>();

        public bool DurationATime
        {
            get { return _DurationATime; }
            set { _DurationATime = value; }
        }

        public long CountryId
        {
            get { return _countryId; }
            set 
            {
                if (_countryId != value)
                {
                    _countryId = value;
                    OnLoadModels();
                }
            }
        }

        public LunchBrakeModelManager(IWorkingModelService service)
        {
            _modelService = service;
        }

        protected virtual void OnLoadModels()
        {
            if (_innerList != null)
                _innerList.Clear();

            List<WorkingModel> modelList = _modelService.GetCountryLunchModel(CountryId, null, null);

            if (modelList != null && modelList.Count > 0)
            {
                foreach (WorkingModel wm in modelList)
                {
                    DurationATime = wm.AddCharges;
                    if (_innerList == null)
                        _innerList = new List<LunchBrakeModel>();

                    if (DurationATime)
                        _innerList.Add(new DurationATimeLunchBrake(wm));
                    else
                        _innerList.Add(new DurationADayLunchBrake(wm));
                }

                _innerList.Sort();
            }
        }


        public void Process(EmployeePlanningWeek week)
        {
            
            foreach (EmployeePlanningDay epd in week.Days.Values)
            {
                _ApplyLunchBrakeModels(epd, true);

                epd.CountDailyWorkingHours = 0;

                epd.UnitPerDay = 0;
                if (epd.WorkingTimeList != null && epd.WorkingTimeList.Count > 0)
                {
                    int beginTime = 0, endTime = 0;
                    foreach (WorkingTimePlanning wtp in epd.WorkingTimeList)
                    {
                        epd.CountDailyWorkingHours += wtp.Time;
                        beginTime = wtp.Begin;
                        endTime = wtp.End;

                        beginTime = beginTime / 60; // we need hour
                        if (endTime % 60 != 0)
                        {
                            endTime = (endTime / 60) + 1;
                        }
                        else
                            endTime = (endTime / 60);
                        epd.UnitPerDay += (endTime - beginTime);
                    }
                }

                _ApplyLunchBrakeModels(epd, false);

                epd.CountDailyPlannedWorkingHours = epd.CountDailyWorkingHours;

                if (epd.AbsenceTimeList != null && epd.AbsenceTimeList.Count > 0)
                {
                    foreach (AbsenceTimePlanning atp in epd.AbsenceTimeList)
                        if (atp.Absence.UseInCalck) epd.CountDailyPlannedWorkingHours += (atp.End - atp.Begin);
                }
            }
        }


        protected void _ApplyLunchBrakeModels(EmployeePlanningDay day, bool beforeCalc)
        {
            if (_innerList == null || _innerList.Count == 0) return;

            if ((beforeCalc && DurationATime) || (!beforeCalc && !DurationATime ))
            {
                foreach (LunchBrakeModel m in _innerList)
                {
                    if (m.IsValidModelByData(day.Date))
                    {
                        m.Process(day);
                    }
                }
            }
        }

        public void Process(EmployeeWeek week)
        {

            foreach (EmployeeDay day in week.DaysList)
            {

                

                day.CountDailyWorkingHours = 0;
                day.CountDailyPlannedWorkingHours = 0;
                day.CountDailyAdditionalCharges = 0;
                //day.CountUnitsPerDay = 0;

                


                if (day.TimeList != null && day.TimeList.Count > 0)
                {
                    _ApplyLunchBrakeModels(day, true);

                    EmployeeTimeRange timerange;
                    for (int i = 0; i < day.TimeList.Count; i++)
                    {
                        timerange = day.TimeList[i];
                        if (timerange.IsWorkingRange)
                        {
                            day.CountDailyWorkingHours += timerange.Time;
                            //day.CountUnitsPerDay += timerange.GetUnits();
                        }
                    }

                    _ApplyLunchBrakeModels(day, false);

                    day.CountDailyPlannedWorkingHours = day.CountDailyWorkingHours;

                    for (int i = 0; i < day.TimeList.Count; i++)
                    {
                        timerange = day.TimeList[i];
                        if (!timerange.IsWorkingRange)
                        {
                            if (timerange.Absence != null && timerange.Absence.UseInCalck)
                                day.CountDailyPlannedWorkingHours += timerange.End - timerange.Begin;

                        }
                    }
                }


                
            }
        }


        protected void _ApplyLunchBrakeModels(EmployeeDay day, bool beforeCalc)
        {
            if (_innerList == null || _innerList.Count == 0) return;

            if ((beforeCalc && DurationATime) || (!beforeCalc && !DurationATime))
            {
                foreach (LunchBrakeModel m in _innerList)
                {
                    if (m.IsValidModelByData(day.Date))
                    {
                        m.Process(day);
                    }
                }
            }
        }

    }

    internal class LunchBrakeModel : IComparable<LunchBrakeModel>
    {
        private int _ConditionTime;
        private int _ApplyValue;
        private DateTime _BeginDate;
        private DateTime _EndDate;

        public int ConditionTime
        {
            get { return _ConditionTime; }
            set { _ConditionTime = value; }
        }

        public int ApplyValue
        {
            get { return _ApplyValue; }
            set { _ApplyValue = value; }
        }

        public DateTime BeginDate
        {
            get { return _BeginDate; }
            set { _BeginDate = value; }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        public bool IsValidModelByData(DateTime date)
        {
            return (BeginDate <= date && date <= EndDate);
        }

        public LunchBrakeModel(WorkingModel wm)
        {
            if (wm == null)
                throw new ArgumentNullException("WorkingModel");
            if (wm.WorkingModelType != WorkingModelType.LunchModel )
                throw new ArgumentException ("LunchModel");

            BeginDate = wm.BeginTime;
            EndDate = wm.EndTime;
            ConditionTime = (int)(wm.AddValue * 60);
            ApplyValue = (int)(wm.MultiplyValue * 60);
        }

        public virtual void Process(IEmployeeTimeRange range)
        {
            return;
        }
        public virtual void Process(EmployeePlanningDay day)
        {
            return;
        }
        public virtual void Process(EmployeeDay day)
        {
            return;
        }


        #region comparer

        public virtual int CompareTo(LunchBrakeModel obj)
        {
            return ConditionTime - obj.ConditionTime;
        }

        #endregion
    }

    internal class DurationATimeLunchBrake : LunchBrakeModel
    {
         
        
        public DurationATimeLunchBrake(WorkingModel wm):base(wm)
        {
            if (!wm.AddCharges)
                throw new InvalidCastException("Duration a time");
        }

        public override void Process(IEmployeeTimeRange range)
        {
            if (range == null)
                throw new ArgumentNullException("process range=null");

            if (range.Absence != null || range.AbsenceID > 0)
                throw new ArgumentException("absence range into lunch brake model");

            if (IsValidModelByData(range.Date))
            {
                int time = range.End - range.Begin;

                if (time >= ConditionTime)
                    range.Time = (short)(time + ApplyValue);
            }
        }
        public override void Process(EmployeePlanningDay day)
        {
            if (day.WorkingTimeList != null && day.WorkingTimeList.Count > 0)
            {
                for (int i = 0; i < day.WorkingTimeList.Count; i++)
                {
                    Process(day.WorkingTimeList[i]);
                }
            }
        }
        public override void Process(EmployeeDay day)
        {
            if (day.TimeList != null && day.TimeList.Count > 0)
            {
                for (int i = 0; i < day.TimeList.Count; i++)
                {
                    if (day.TimeList[i].AbsenceID <= 0)
                    {
                        Process(day.TimeList[i]);
                    }
                }
            }
        }
        
    }

    internal class DurationADayLunchBrake : LunchBrakeModel
    {


        public DurationADayLunchBrake(WorkingModel wm)
            : base(wm)
        {
            if (wm.AddCharges)
                throw new InvalidCastException("Duration a day");
        }

        public override void Process(EmployeePlanningDay day)
        {
            int time = 0;

            if (day.WorkingTimeList != null && day.WorkingTimeList.Count > 0)
            {
                for (int i = 0; i < day.WorkingTimeList.Count; i++)
                {
                    time += day.WorkingTimeList[i].End - day.WorkingTimeList[i].Begin;
                }

                if (time >= ConditionTime)
                    day.CountDailyWorkingHours = time + ApplyValue;
            }
        }
        public override void Process(EmployeeDay day)
        {
            int time = 0;

            if (day.TimeList != null && day.TimeList.Count > 0)
            {
                for (int i = 0; i < day.TimeList.Count; i++)
                {
                    if (day.TimeList[i].AbsenceID <= 0)
                    {
                        time += day.TimeList[i].End - day.TimeList[i].Begin;
                    }
                }

                if (time >= ConditionTime)
                    day.CountDailyWorkingHours = time + ApplyValue;
            }
        }

        #region comparer

        public virtual int CompareTo(DurationATimeLunchBrake obj)
        {
            return ConditionTime - obj.ConditionTime;
        }

        #endregion
    }
}
