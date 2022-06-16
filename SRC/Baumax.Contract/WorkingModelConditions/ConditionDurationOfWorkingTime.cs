using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using System.Globalization;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionDurationOfWorkingTime : ConditionBase
    {
        private double _value = 0;
        private bool _lessthan;
        private int _CountMinutes = 0;
        public ConditionDurationOfWorkingTime()
            : base(ConditionTypes.DurationOfWorkingTime)
        {
        }

        public double Value
        {
            get { return _value; }
            set {  _value = value; }
        }

        public bool LessThan
        {
            get { return _lessthan; }
            set { _lessthan = value; }
        }
        public int CountMinutes
        {
            get { return _CountMinutes; }
            protected set { _CountMinutes = value; }
        }

        public bool Validate(EmployeePlanningDay employeeday)
        {
            CountMinutes = 0;
            if (employeeday.WorkingTimeList == null ) return false;

            short minutes = (short)(Value * 60);
            foreach (WorkingTimePlanning wtp in employeeday.WorkingTimeList)
            {
                if (LessThan)
                {
                    if (wtp.Time < minutes)
                    {
                        CountMinutes = wtp.Time;
                        if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                            Wrapper.Hours = CountMinutes;
                        return true;
                    }
                }
                else
                {
                    if (wtp.Time > minutes)
                    {
                        CountMinutes = wtp.Time-minutes;
                        if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                            Wrapper.Hours = CountMinutes;
                        return true;
                    }
                }
            }

            return false;

        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return Validate(planningWeek.Days [date]);
        }

        public override bool Validate()
        {
            return Validate(Wrapper.EmployeeWeek.Days [Wrapper.CurrentDate ]);
        }

        public override void ParseValue(string value)
        {
            string[] arr = value.Split(';');

            Value = Convert.ToDouble(arr[0], NumberFormatInfo.InvariantInfo);
            LessThan = (Convert.ToInt32(arr[1]) == 0) ? true : false;
        }

        public override bool ValidateNew()
        {
            return ValidateNew(Owner.EmployeeWeek.GetDay(Owner.CurrentDate));
        }
        public bool ValidateNew(EmployeeDay employeeday)
        {
            CountMinutes = 0;
            if (employeeday.TimeList == null || employeeday.TimeList.Count == 0) return false;

            short minutes = (short)(Value * 60);

            foreach (EmployeeTimeRange wtp in employeeday.TimeList)
            {
                if (wtp.AbsenceID <= 0)// not absence range
                {
                    if (LessThan)
                    {
                        if (wtp.Time < minutes)
                        {
                            CountMinutes = wtp.Time;
                            if (Owner.Hours > CountMinutes || Owner.Hours == -1)
                                Owner.Hours = CountMinutes;
                            return true;
                        }
                    }
                    else
                    {
                        if (wtp.Time > minutes)
                        {
                            CountMinutes = wtp.Time - minutes;
                            if (Owner.Hours > CountMinutes || Owner.Hours == -1)
                                Owner.Hours = CountMinutes;
                            return true;
                        }
                    }
                }
            }

            return false;

        }
    }
}
