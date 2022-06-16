using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionDurationOfWorkingTimeOnWeek : ConditionDurationOfWorkingTimeOnSingleDay
    {
        
        public ConditionDurationOfWorkingTimeOnWeek()
            :base(ConditionTypes.DurationOfWorkingTimeByWeek )
        {

        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            int count = 0;

            foreach (EmployeePlanningDay day in planningWeek.Days.Values)
                count += day.CountDailyWorkingHours;

            return Validate(count);
        }
        public override bool Validate()
        {
            //EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            int count = 0;

            foreach (EmployeePlanningDay day in Wrapper.EmployeeWeek.Days.Values)
                count += day.CountDailyWorkingHours;

            return Validate(count);
        }









        public override bool ValidateNew()
        {
            int count = 0;

            foreach (EmployeeDay day in Owner.EmployeeWeek.DaysList)
                count += day.CountDailyWorkingHours;

            return ValidateNew(count);
        }
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            int count = 0;

            foreach (EmployeeDay day in planningWeek.DaysList)
                count += day.CountDailyWorkingHours;

            return ValidateNew(count);
        }
    }
}
