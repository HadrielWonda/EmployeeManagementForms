using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionDurationOfWorkingDaysInRow:ConditionBase 
    {
        private int _value = 0;
        public ConditionDurationOfWorkingDaysInRow()
            :base(ConditionTypes.DurationOfWorkingDay)
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
            DateTime beginWeek = employeeweek.BeginDate;
            DateTime currentDate;
            count = employeeweek.WorkingDaysBefore;
            for (int i = 0; i < 7; i++)
            {
                currentDate = beginWeek.AddDays(i);

                if (employeeweek.Days[currentDate].CountDailyWorkingHours > 0) count++;
                else count = 0;

                if (count >= Value) return true;
            }
            if ((count > 0) && (count + employeeweek.WorkingDaysAfter >= Value))
                return true;

            return false;
        }


        public bool Validate(EmployeePlanningDay employeeday)
        {
            throw new Exception();
            //int count = 0;
            //EmployeePlanningWeek week = employeeday.PlanningWeek;
            //DateTime currentDate = week.BeginDate;

            //if (employeeday.Date.AddDays(-Value) < week.BeginDate) return false;
            //count = week.CountWorkDaysBefore;
            //while (currentDate <= employeeday.Date)
            //{
            //    if (week.Days[currentDate].CountDailyWorkingHours > 0) count++;
            //    else count = 0;

            //    if (count >= Value) return true;

            //    currentDate = currentDate.AddDays(1);
            //}
            //return false;

        }
        public override bool Validate()
        {
            return Validate(Wrapper.EmployeeWeek);//.Days[Wrapper.CurrentDate]);
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return Validate(planningWeek);
        }

        public override void ParseValue(string value)
        {
            Value = Convert.ToInt32(value);
        }



        /// <summary>
        /// ////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public override bool ValidateNew()
        {
            return ValidateWeek(Owner.EmployeeWeek);//.GetDay(Owner.CurrentDate));
        }
        public bool ValidateNew(EmployeeDay employeeday)
        {
            throw new Exception();
            //int count = 0;
            //IBaumaxEmployeeWeek week = Owner.EmployeeWeek;

            //DateTime currentDate = week.BeginDate;
            //count = week.CountWorkDaysBefore;
            ////if (employeeday.Date.AddDays(-Value) < week.BeginDate) return false;

            //while (currentDate <= employeeday.Date)
            //{
            //    if (week.GetDay(currentDate).CountDailyWorkingHours > 0) count++;
            //    else count = 0;

            //    if (count > Value) return true;

            //    currentDate = currentDate.AddDays(1);
            //}

            //return false;

        }

        public bool ValidateWeek(IBaumaxEmployeeWeek week)
        {
            int count = 0;
            //IBaumaxEmployeeWeek week = Owner.EmployeeWeek;

            DateTime currentDate = week.BeginDate;

            //if (employeeday.Date.AddDays(-Value) < week.BeginDate) return false;
            count = week.WorkingDaysBefore;
            while (currentDate <= week.EndDate)
            {
                if (week.GetDay(currentDate).CountDailyWorkingHours > 0) count++;
                else count = 0;

                if (count >= Value) return true;

                currentDate = currentDate.AddDays(1);
            }
            if ((count > 0) && (count + week.WorkingDaysAfter >= Value))
                return true;
            return false;

        }
    }
}
