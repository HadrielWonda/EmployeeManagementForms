using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using System.Globalization;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionDurationOfWorkingTimeOnSingleDay:ConditionBase 
    {
        private int _CountMinutes = 0;
        private double _value = 0;
        private bool _LessThan = false;

        public ConditionDurationOfWorkingTimeOnSingleDay()
            :base(ConditionTypes.DurationOfWorkingTimeSingleDay)
        {

        }
        public ConditionDurationOfWorkingTimeOnSingleDay(ConditionTypes type)
            : base(type)
        {

        }
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public bool LessThan
        {
            get { return _LessThan; }
            set { _LessThan = value; }
        }
        public int CountMinutes
        {
            get { return _CountMinutes; }
            protected set { _CountMinutes = value; }
        }
        public bool Validate(int daytime)
        {
            CountMinutes = 0;
            if (daytime == 0) return false;
            int minutes = (int)(Value * 60);

            if (LessThan)
            {
                if (daytime < minutes)
                {
                    CountMinutes = Math.Abs (daytime-minutes);
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;
                    return true;
                }
            }
            else
                if (daytime > minutes)
                {
                    CountMinutes = daytime - minutes;
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;
                    return true;
                }

            return false;
        }
        private int GetWorkingMinutes(EmployeePlanningDay day)
        {
            int result = 0;
            if (day.WorkingTimeList != null && day.WorkingTimeList.Count > 0)
            {
                foreach (WorkingTimePlanning r in day.WorkingTimeList)
                        result += r.Time;
            }
            return result;
        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            EmployeePlanningDay day = planningWeek.Days[date];
            return Validate(day.CountDailyWorkingHours );
        }
        public override bool Validate()
        {
            EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            return Validate(day.CountDailyWorkingHours);
        }
        public override void ParseValue(string value)
        {
            string[] arr = value.Split(';');

            Value = Convert.ToDouble(arr[0], NumberFormatInfo.InvariantInfo);
            LessThan = (Convert.ToInt32(arr[1]) == 0) ? true : false;
        }
        //////////////////////////////////////////////////


        public bool ValidateNew(int daytime)
        {
            CountMinutes = 0;
            if (daytime == 0) return false;
            int minutes = (int)(Value * 60);

            if (LessThan)
            {
                if (daytime < minutes)
                {
                    CountMinutes = Math.Abs(daytime - minutes);
                    Owner.Hours = CountMinutes;
                    return true;
                }
            }
            else
                if (daytime > minutes)
                {
                    CountMinutes = Math.Abs(daytime - minutes);
                    Owner.Hours = CountMinutes;
                    return true;
                }

            return false;
        }


        private int GetWorkingMinutes(EmployeeDay day)
        {
            int result = 0;
            if (day.TimeList != null && day.TimeList.Count > 0)
            {
                foreach (EmployeeTimeRange r in day.TimeList)
                    if (r.AbsenceID == 0)
                        result += r.Time;
            }
            return result;
        }
        
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            EmployeeDay day = planningWeek.GetDay(date);

            return ValidateNew(day.CountDailyWorkingHours );
        }
        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            return ValidateNew(day.CountDailyWorkingHours);
        }
    }
}
