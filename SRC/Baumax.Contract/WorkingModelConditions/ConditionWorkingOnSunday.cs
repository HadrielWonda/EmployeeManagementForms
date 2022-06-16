using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOnSunday:ConditionBase 
    {
        public ConditionWorkingOnSunday()
            :base(ConditionTypes.WorkingOnSunday)
        {

        }
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override void ParseValue(string value)
        {
            Value = Convert.ToInt32(value);
        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            int count = planningWeek.CountWorkingSundayPerMonth;

            if (Value <= count) return true;

            if (planningWeek.BeginDate.Month != planningWeek.EndDate.Month)
            {
                if (planningWeek.IsSundayWorking && (Value <= 1)) return true;
            }
            return false;
        }
        public override bool Validate()
        {
            int count = Wrapper.EmployeeWeek.CountWorkingSundayPerMonth;

            if (Value <= count) return true;
            if (Wrapper.EmployeeWeek.BeginDate.Month != Wrapper.EmployeeWeek.EndDate.Month)
            {
                if (Wrapper.EmployeeWeek.IsSundayWorking && (Value <= 1)) return true;
            }
            return false;
        }


        public override bool ValidateNew()
        {
            int count = Owner.EmployeeWeek.CountWorkingSundayPerMonth;

            if (Value <= count) return true;
            if (Owner.EmployeeWeek.BeginDate.Month != Owner.EmployeeWeek.EndDate.Month)
            {
                if (Owner.EmployeeWeek.IsSundayWorking && (Value <= 1)) return true;
            }
            return false;
        }
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            int count = planningWeek.CountWorkingSundayPerMonth;
            if (Value <= count) return true;
            if (planningWeek.BeginDate.Month != planningWeek.EndDate.Month)
            {
                if (planningWeek.IsSundayWorking && (Value <= 1)) return true;
            }
            return false;
        }
    }
}
