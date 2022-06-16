using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult ;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingOnFeast:ConditionBase 
    {
        public ConditionWorkingOnFeast()
            : base(ConditionTypes.WorkingOnFeast)
        {
        }

        public bool Validate(EmployeePlanningDay employeeday)
        {
            if (employeeday.HasRelation && employeeday.HasContract)
            {
                if (employeeday.WorkingTimeList != null &&
                    employeeday.WorkingTimeList.Count > 0 &&
                    employeeday.StoreDay.Feast
                    )
                {
                    if (Wrapper.Hours == -1 || Wrapper.Hours > employeeday.CountDailyWorkingHours)
                        Wrapper.Hours = employeeday.CountDailyWorkingHours;
                    return true;
                }
            }
            return false;
        }

        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            
            return base.ValidateWeek(planningWeek, date);
        }

        public override bool Validate()
        {
            EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            return Validate(day);
        }





        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            return ValidateNew(day);
        }
        public bool ValidateNew(EmployeeDay employeeday)
        {
            if (employeeday.HasRelation && employeeday.HasContract)
            {
                if (employeeday.StoreDay.Feast && employeeday.CountDailyWorkingHours > 0)
                {
                    Owner.Hours = employeeday.CountDailyWorkingHours;
                    return true;
                }
            }

            return false;
        }
    }
}
