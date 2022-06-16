using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System.Globalization;


namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionBalanceHoursReachesCertainAmount:ConditionBase 
    {
        private double _value = 0;

        public ConditionBalanceHoursReachesCertainAmount()
            : base(ConditionTypes.BalanceHoursReachesCertainAmount)
        {
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override void ParseValue(string value)
        {
            Value = Convert.ToDouble(value, NumberFormatInfo.InvariantInfo);
        }
        public override bool Validate()
        {
            EmployeePlanningWeek week = Wrapper.EmployeeWeek;

            return ValidateWeek(week, week.EndDate );
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            if (planningWeek.Saldo > (int)(Value * 60))
                return true;

            return false;

        }


        public override bool ValidateNew()
        {
            IBaumaxEmployeeWeek week = Owner.EmployeeWeek;

            return ValidateWeekNew(week, week.EndDate);
        }

        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            if (planningWeek.Saldo > (int)(Value * 60))
                return true;

            return false;

        }
    }
}
