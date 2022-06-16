using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionDurationOfWorkingTimeOnMonth : ConditionDurationOfWorkingTimeOnSingleDay
    {
        /*private double _value = 0;
        private bool _LessThan = false;
        */
        public ConditionDurationOfWorkingTimeOnMonth()
            : base(ConditionTypes.DurationOfWorkingTimeByMonth)
        {

        }

        public override bool Validate()
        {
            int iValue = (int)(Value * 60);
            int iCount = Wrapper.EmployeeWeek.WorkingTimeByMonth;

            DateTime beginWeek = Wrapper.EmployeeWeek.BeginDate;
            DateTime endWeek = Wrapper.EmployeeWeek.EndDate;
            int prevWeek = Wrapper.EmployeeWeek.WorkingTimeByMonth;

            if (beginWeek.Month == endWeek.Month)
            {
                prevWeek += Wrapper.EmployeeWeek.CountWeeklyPlanningWorkingHours;

                if (prevWeek > iValue)
                {
                    CountMinutes = prevWeek - iValue;
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;
                    return true;
                }
            }
            else
            {
                int prevMonth = 0;
                int nextMonth = 0;
                foreach (EmployeePlanningDay day in Wrapper.EmployeeWeek.Days.Values)
                {
                    if (day.Date.Month == beginWeek.Month)
                        prevMonth += day.CountDailyPlannedWorkingHours;
                    else
                        nextMonth += day.CountDailyPlannedWorkingHours;
                }

                prevMonth += Wrapper.EmployeeWeek.WorkingTimeByMonth;
                bool result = false;
                if (prevMonth > iValue)
                {
                    CountMinutes = prevMonth - iValue;
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;
                    result = true;
                }
                if (nextMonth > iValue)
                {
                    CountMinutes = nextMonth - iValue;
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;
                    result = true;
                }
                return result;
            }

            return false;
        }
        public bool ValidateMonthTime(int daytime)
        {
            CountMinutes = 0;
            if (daytime == 0) return false;
            int minutes = (int)(Value * 60);


            if (daytime > minutes)
            {
                CountMinutes = daytime - minutes;
                Owner.Hours = CountMinutes;
                return true;
            }

            return false;
        }

        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            
            return false;
        }
        public override bool ValidateNew()
        {
            DateTime date = Owner.EmployeeWeek.BeginDate.Date;
            int month = date.Month;
            EmployeeDay day = null;
            int minutes = 0;
            while (date <= Owner.EmployeeWeek.EndDate.Date)
            {
                day = Owner.EmployeeWeek.GetDay(date);
                if (day.Date.Month == month)
                {
                    minutes += day.CountDailyPlannedWorkingHours;
                }
                date = date.AddDays(1);
            }

            return ValidateMonthTime(Owner.EmployeeWeek.WorkingTimeByMonth + minutes);
        }
    }
}
