using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingTimeBetweenSeveralHours:ConditionBase 
    {
        private int _CountMinutes = 0;
        private short _BeginTime = 0;
        private short _EndTime = 0;
        public ConditionWorkingTimeBetweenSeveralHours()
            :base(ConditionTypes.WorkingTimeBetweenSeveralHours)
        {

        }

        public int CountMinutes
        {
            get { return _CountMinutes; }
            protected set { _CountMinutes = value; }
        }

        public short BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }
        public short EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }


        public bool Validate(EmployeePlanningDay employeeday)
        {
            CountMinutes = 0;

            if (employeeday.WorkingTimeList == null) return false;
            if (employeeday.WorkingTimeList.Count == 0) return false;

            foreach (WorkingTimePlanning wtp in employeeday.WorkingTimeList)
            {

                for (short start = wtp.Begin; start < wtp.End; start += 15)
                {
                    if (BeginTime <= start && start < EndTime) //continue;
                        CountMinutes += 15;
                }
            }
            if (CountMinutes > 0)
            {
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
            if (String.IsNullOrEmpty(value))
            {
                BeginTime = 0;
                EndTime = 0;
                return;
            }
            string[] times = value.Split('-');
            if (times.Length != 2) return;

            string[] h_m = times[0].Split(':');
            if (h_m.Length != 2) return;

            BeginTime = Convert.ToInt16(Convert.ToInt32(h_m[0]) * 60 + Convert.ToInt32(h_m[1]));

            h_m = times[1].Split(':');
            if (h_m.Length != 2) return;
            EndTime = Convert.ToInt16(Convert.ToInt32(h_m[0]) * 60 + Convert.ToInt32(h_m[1]));
        }



        public bool ValidateNew(EmployeeDay employeeday)
        {
            CountMinutes = 0;

            if (employeeday.CountDailyWorkingHours == 0) return false;

            if (employeeday.TimeList != null)
            {
                foreach (EmployeeTimeRange wtp in employeeday.TimeList)
                {
                    if (wtp.AbsenceID <= 0)
                    {
                        for (short start = wtp.Begin; start < wtp.End; start += 15)
                        {
                            if (BeginTime <= start && start < EndTime) //continue;
                                CountMinutes += 15;
                        }
                    }
                }

                if (CountMinutes > 0)
                {
                    //if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                    Owner.Hours = CountMinutes;

                    return true;
                }
            }
            return false;
        }

        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            return ValidateNew(day);
        }
    }
}
