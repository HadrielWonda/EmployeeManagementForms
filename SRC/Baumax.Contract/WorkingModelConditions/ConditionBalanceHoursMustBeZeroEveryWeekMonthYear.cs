using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;


namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionBalanceHoursMustBeZeroEveryWeekMonthYear:ConditionBase 
    {
        public ConditionBalanceHoursMustBeZeroEveryWeekMonthYear()
            : base(ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear)
        {
        }
        private EveryItemEnum m_enumItems = EveryItemEnum.Empty;
        private int m_CountWeek = 0;
        private int m_CountMonth = 0;


        public int CountWeek
        {
            get { return m_CountWeek; }
            set { m_CountWeek = value; }
        }

        public int CountMonth
        {
            get { return m_CountMonth; }
            set { m_CountMonth = value; }
        }

        public EveryItemEnum EveryItems
        {
            get { return m_enumItems; }
            set { m_enumItems = value; }
        }

        public override void ParseValue(string value)
        {
            string[] vals = value.Split(',');

            if (vals.Length == 3)
            {
                EveryItems = (EveryItemEnum)Convert.ToInt32(vals[0]);
                CountWeek = Convert.ToInt32(vals[1]);
                CountMonth = Convert.ToInt32(vals[2]);
            }
        }

        public override bool Validate()
        {
            EmployeePlanningWeek week = Wrapper.EmployeeWeek;

            return ValidateWeek(week, week.EndDate);
        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return false;

        }



        public bool IsNeededYear()
        {
            if (Owner.EmployeeWeek.EndDate.DayOfWeek == DayOfWeek.Sunday) return true;
            if (Owner.EmployeeWeek.BeginDate.Year < Owner.EmployeeWeek.EndDate.Year)
            {
                if (Owner.EmployeeWeek.EndDate.DayOfYear < 4)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return false;

        }

        public override bool ValidateNew()
        {
            IBaumaxEmployeeWeek week = Owner.EmployeeWeek;

            return ValidateWeekNew(week, week.EndDate);
        }

    }
}
