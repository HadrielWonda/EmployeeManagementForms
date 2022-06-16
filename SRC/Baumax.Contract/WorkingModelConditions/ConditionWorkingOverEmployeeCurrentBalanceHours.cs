using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;


namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOverEmployeeCurrentBalanceHours:ConditionBase 
    {
        public ConditionWorkingOverEmployeeCurrentBalanceHours()
            : base(ConditionTypes.WorkingOverEmployeeCurrentBalanceHours)
        {
        }
        public override bool Validate()
        {
            EmployeePlanningWeek week = Wrapper.EmployeeWeek;

            if (week.LastSaldo < week.Saldo) 
                return true;

            return false;
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return base.ValidateWeek(planningWeek, date);
        }



        public override bool ValidateNew()
        {
            IBaumaxEmployeeWeek week = Owner.EmployeeWeek;

            if (week.LastSaldo < week.Saldo)
                return true;

            return false;
        }

        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return base.ValidateWeekNew(planningWeek, date);
        }
    }
}
