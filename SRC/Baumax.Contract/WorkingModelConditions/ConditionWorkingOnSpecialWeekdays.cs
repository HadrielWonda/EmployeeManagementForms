using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;


namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOnSpecialWeekdays:ConditionBase 
    {
        private WeeksDayMask _weekdays = WeeksDayMask.Empty ;

        public ConditionWorkingOnSpecialWeekdays()
            :base(ConditionTypes.WorkingOnSpecialWeekdays )
        {

        }

        public WeeksDayMask WeekDayMasks
        {
            get { return _weekdays; }
            set { _weekdays = value; }
        }
        public int CountMinutes = 0;
        public bool Validate(EmployeePlanningDay employeeday)
        {
            CountMinutes = 0;
            if (WeekDayMasks == WeeksDayMask.Empty) return false;
            if (employeeday.CountDailyWorkingHours == 0 || 
                employeeday.WorkingTimeList == null ||
                employeeday.WorkingTimeList.Count == 0)
                return false;
            DayOfWeek dayofweek = employeeday.Date.DayOfWeek;
            WeeksDayMask currentDayMask = WeeksDayMask.Empty;
            switch (dayofweek)
            {
                case DayOfWeek.Monday: currentDayMask = WeeksDayMask.Monday; break;
                case DayOfWeek.Tuesday : currentDayMask = WeeksDayMask.Tuesday ; break;
                case DayOfWeek.Wednesday : currentDayMask = WeeksDayMask.Wednesday ; break;
                case DayOfWeek.Thursday : currentDayMask = WeeksDayMask.Thursday ; break;
                case DayOfWeek.Friday : currentDayMask = WeeksDayMask.Friday ; break;
                case DayOfWeek.Saturday : currentDayMask = WeeksDayMask.Saturday ; break;
                case DayOfWeek.Sunday: currentDayMask = WeeksDayMask.Sunday; break;
            }

            if ((WeekDayMasks & currentDayMask) != WeeksDayMask.Empty)
            {
                CountMinutes = employeeday.CountDailyWorkingHours;

                if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                    Wrapper.Hours = CountMinutes;
                return true;
            }
            else return false;
        }
        public override bool Validate()
        {
            EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            return Validate(day);
        }
        public override void ParseValue(string value)
        {
            WeekDayMasks = (WeeksDayMask)Convert.ToInt32(value);
        }


        public bool ValidateNew(EmployeeDay employeeday)
        {
            CountMinutes = 0;
            if (WeekDayMasks == WeeksDayMask.Empty) 
                return false;
            if (employeeday.CountDailyWorkingHours == 0) 
                return false;
            DayOfWeek dayofweek = employeeday.Date.DayOfWeek;
            WeeksDayMask currentDayMask = WeeksDayMask.Empty;
            switch (dayofweek)
            {
                case DayOfWeek.Monday: currentDayMask = WeeksDayMask.Monday; break;
                case DayOfWeek.Tuesday: currentDayMask = WeeksDayMask.Tuesday; break;
                case DayOfWeek.Wednesday: currentDayMask = WeeksDayMask.Wednesday; break;
                case DayOfWeek.Thursday: currentDayMask = WeeksDayMask.Thursday; break;
                case DayOfWeek.Friday: currentDayMask = WeeksDayMask.Friday; break;
                case DayOfWeek.Saturday: currentDayMask = WeeksDayMask.Saturday; break;
                case DayOfWeek.Sunday: currentDayMask = WeeksDayMask.Sunday; break;
            }

            if ((WeekDayMasks & currentDayMask) != WeeksDayMask.Empty)
            {
                CountMinutes = employeeday.CountDailyWorkingHours;

                //if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                Owner.Hours = CountMinutes;
                return true;
            }
            else return false;
        }
        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            return ValidateNew(day);
        }
    }
}
