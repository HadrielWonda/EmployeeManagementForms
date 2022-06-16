using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System.Globalization;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionTimeBetweenPreviousDayWorkingTime:ConditionBase 
    {
        public ConditionTimeBetweenPreviousDayWorkingTime()
            : base(ConditionTypes.TimeBetweenPreviousDayWorkingTime)
        {
        }
        private double _value = 0;
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public override void ParseValue(string value)
        {
            Value = Convert.ToDouble(value, NumberFormatInfo.InvariantInfo);
        }

        public bool Validate(StoreDay storeday1, EmployeePlanningDay employeeday)
        {
            if (employeeday.Date.DayOfWeek == DayOfWeek.Monday) return false;

            if (employeeday.WorkingTimeList == null ||
                    employeeday.WorkingTimeList.Count == 0)
                return false;

            DateTime prevDate = employeeday.Date.AddDays(-1);

            EmployeePlanningDay prevDay = employeeday.PlanningWeek.Days[prevDate];

            if (prevDay.WorkingTimeList == null ||
                    prevDay.WorkingTimeList.Count == 0) 
                return false;

            short maxvalue = 0;
            short minvalue = 24 * 60;
            foreach (WorkingTimePlanning wtp in prevDay.WorkingTimeList)
                if (wtp.End > maxvalue) maxvalue = wtp.End;

            foreach (WorkingTimePlanning wtp in employeeday.WorkingTimeList)
                if (wtp.Begin < minvalue) minvalue = wtp.Begin;


            int diff = (Utills.MinutesInDay - maxvalue) + minvalue;

            int countHour = (int)(Value * 60);

            if (countHour > diff) return true;
            

            return false;
        }
        public override bool Validate()
        {
            EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            //StoreDay storeday = Wrapper.StoreDays[Wrapper.CurrentDate];

            return Validate(null, day);
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return base.ValidateWeek(planningWeek, date);
        }







        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            //StoreDay storeday = Owner.StoreDays[Owner.CurrentDate];

            return ValidateNew(null, day);
        }

        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return base.ValidateWeekNew(planningWeek, date);
        }

        public bool ValidateNew(StoreDay storeday1, EmployeeDay employeeday)
        {
            if (employeeday.Date.DayOfWeek == DayOfWeek.Monday) return false;

            if (employeeday.TimeList  == null ||
                    employeeday.TimeList.Count == 0)
                return false;

            DateTime prevDate = employeeday.Date.AddDays(-1);

            EmployeeDay prevDay = Owner.EmployeeWeek.GetDay(prevDate);

            if (prevDay.TimeList == null ||
                    prevDay.TimeList.Count == 0)
                return false;

            short maxvalue = 0;
            short minvalue = Utills.MinutesInDay;
            foreach (EmployeeTimeRange wtp in prevDay.TimeList)
            {
                if ((wtp.AbsenceID <= 0) && (wtp.End > maxvalue)) maxvalue = wtp.End;
            }
            foreach (EmployeeTimeRange wtp in employeeday.TimeList)
            {
                if ((wtp.AbsenceID <= 0) && (wtp.Begin < minvalue )) minvalue = wtp.Begin;
            }

            int diff = (Utills.MinutesInDay - maxvalue) + minvalue;

            int countHour = (int)(Value * 60);

            if (countHour > diff) return true;


            return false;
        }
    }
}
