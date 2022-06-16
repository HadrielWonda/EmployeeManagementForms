using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOnSundayOrSaturday : ConditionBase
    {
        public ConditionWorkingOnSundayOrSaturday()
            : base(ConditionTypes.WorkingOnSaturdayOrSunday)
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
            int count = planningWeek.CountWorkingSundayAndSaturdayPerMonth ;

            if (Value <= count) return true;

            if (planningWeek.BeginDate.Month != planningWeek.EndDate.Month)
            {
                DateTime dtSaturday = planningWeek.EndDate.AddDays(-1);
                count = 0;
                if (planningWeek.BeginDate.Month != dtSaturday.Month)
                {
                    if (planningWeek.IsSaturdayWorking) count++;
                }
                if (planningWeek.IsSundayWorking) count++;

                if (Value <= count) return true;
            }
            return false;
        }
        public override bool Validate()
        {
            int count = Wrapper.EmployeeWeek.CountWorkingSundayAndSaturdayPerMonth;

            if (Value <= count) return true;

            if (Wrapper.EmployeeWeek.BeginDate.Month != Wrapper.EmployeeWeek.EndDate.Month)
            {
                DateTime dtSaturday = Wrapper.EmployeeWeek.EndDate.AddDays(-1);
                count = 0;
                if (Wrapper.EmployeeWeek.BeginDate.Month != dtSaturday.Month)
                {
                    if (Wrapper.EmployeeWeek.IsSaturdayWorking) count++;
                }
                if (Wrapper.EmployeeWeek.IsSundayWorking) count++;

                if (Value <= count) return true;
            }
            return false;

        }


        public override bool ValidateNew()
        {
            int count = Owner.EmployeeWeek.CountWorkingSundayAndSaturdayPerMonth;

            if (Value <= count) return true;

            if (Owner.EmployeeWeek.BeginDate.Month != Owner.EmployeeWeek.EndDate.Month)
            {
                DateTime dtSaturday = Owner.EmployeeWeek.EndDate.AddDays(-1);
                count = 0;
                if (Owner.EmployeeWeek.BeginDate.Month != dtSaturday.Month)
                {
                    if (Owner.EmployeeWeek.IsSaturdayWorking) count++;
                }
                if (Owner.EmployeeWeek.IsSundayWorking) count++;

                if (Value <= count) return true;
            }
            return false;

        }
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            int count = planningWeek.CountWorkingSundayAndSaturdayPerMonth;

            if (Value <= count) return true;

            if (planningWeek.BeginDate.Month != planningWeek.EndDate.Month)
            {
                DateTime dtSaturday = planningWeek.EndDate.AddDays(-1);
                count = 0;
                if (planningWeek.BeginDate.Month != dtSaturday.Month)
                {
                    if (planningWeek.IsSaturdayWorking) count++;
                }
                if (planningWeek.IsSundayWorking) count++;

                if (Value <= count) return true;
            }
            return false;
        }
    }
}
