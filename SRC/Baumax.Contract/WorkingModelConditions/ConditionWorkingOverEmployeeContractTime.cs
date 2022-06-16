using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using System.Globalization;


namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOverEmployeeContractTime:ConditionBase 
    {
        private int _value = 0;
        public ConditionWorkingOverEmployeeContractTime()
            :base(ConditionTypes.WorkingOverEmployeeContractTime )
        {

        }


        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool Validate(EmployeePlanningWeek employeeweek)
        {
            int count = 0;
            DateTime currentDate = employeeweek.BeginDate;
            EmployeePlanningDay currentDay = null;
            EmployeePlanningDay lastWorkingDay = null;
            
            Value = employeeweek.ContractHoursPerWeek;

            for (int i = 0; i < 7; i++)
            {
                currentDay = employeeweek.Days[currentDate];

                if (currentDay.CountDailyWorkingHours > 0)
                {
                    count += currentDay.CountDailyWorkingHours;
                    lastWorkingDay = currentDay;
                }

                currentDate = currentDate.AddDays(1);
            }

            if (count > Value)
            {
                int t = count - Value;
                if (Wrapper.Hours == -1 || Wrapper.Hours > t)
                    Wrapper.Hours = t;
                return true;
            }

            return false;
        }
        
        public override bool Validate()
        {
            return Validate(Wrapper.EmployeeWeek);
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return Validate(planningWeek);
        }

        public override void ParseValue(string value)
        {
            Value = (int)(Convert.ToDouble(value, NumberFormatInfo.InvariantInfo) * 60);
        }


        public bool ValidateNew(IBaumaxEmployeeWeek employeeweek)
        {
            int count = 0;
            DateTime currentDate = employeeweek.BeginDate;
            EmployeeDay currentDay = null;
            EmployeeDay lastWorkingDay = null;

            Value = employeeweek.ContractHoursPerWeek;

            for (int i = 0; i < 7; i++)
            {
                currentDay = employeeweek.GetDay(currentDate);

                //if (currentDay.CountDailyPlannedWorkingHours > 0)
                {
                    count += currentDay.CountDailyPlannedWorkingHours;
                    lastWorkingDay = currentDay;
                }

                currentDate = currentDate.AddDays(1);
            }

            if (count > Value)
            {
                int t = count - Value;
                //if (Wrapper.Hours == -1 || Wrapper.Hours > t)
                    Owner.Hours = t;
                return true;
            }

            return false;
        }

        public override bool ValidateNew()
        {
            return ValidateNew(Owner.EmployeeWeek);
        }
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return ValidateNew(planningWeek);
        }
    }
}
