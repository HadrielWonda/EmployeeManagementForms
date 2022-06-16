using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionWorkingTimeOutOfOpeningStore:ConditionBase 
    {

        private int _CountMinutes = 0;

        public ConditionWorkingTimeOutOfOpeningStore()
            :base(ConditionTypes.WorkingTimeOutOfOpeningTimeOfStore)
        {

        }

        public int CountMinutes
        {
            get { return _CountMinutes; }
            protected set { _CountMinutes = value; }
        }

        public bool Validate(EmployeePlanningDay employeeday)
        {
            CountMinutes = 0;
            if (employeeday.HasRelation && employeeday.HasContract)
            {
                if (employeeday.WorkingTimeList == null || 
                    employeeday.WorkingTimeList.Count == 0) return false;

                short openTime = employeeday.StoreDay.OpenTime;  //storeday.OpenTime;
                short closeTime = employeeday.StoreDay.CloseTime;

                foreach (WorkingTimePlanning wtp in employeeday.WorkingTimeList)
                {

                    for (short start = wtp.Begin; start <= wtp.End; start += 15)
                    {
                        if (openTime <= start && start <= closeTime) continue;

                        CountMinutes += 15;
                    }
                }

                if (CountMinutes > 0)
                {
                    if (Wrapper.Hours > CountMinutes || Wrapper.Hours == -1)
                        Wrapper.Hours = CountMinutes;

                    return true;
                }
            }

            return false;
        }
        public override bool Validate()
        {
            EmployeePlanningDay day = Wrapper.EmployeeWeek.Days[Wrapper.CurrentDate];
            return Validate(day);
        }




        public bool ValidateNew(EmployeeDay employeeday)
        {
            if (employeeday.HasRelation && employeeday.HasContract)
            {
                CountMinutes = 0;

                if (employeeday.CountDailyWorkingHours == 0) return false;

                short openTime = employeeday.StoreDay.OpenTime;
                short closeTime = employeeday.StoreDay.CloseTime;

                

                foreach (EmployeeTimeRange wtp in employeeday.TimeList)
                {
                    if (wtp.AbsenceID <= 0)
                    {
                        for (short start = wtp.Begin; start <= wtp.End; start += 15)
                        {
                            if (openTime <= start && start <= closeTime) continue;

                            CountMinutes += 15;
                        }
                    }
                }

                if (CountMinutes > 0)
                {
                    Owner.Hours = CountMinutes;

                    return true;
                }
            }
            
            return false;
        }
        public override bool ValidateNew()
        {
            EmployeeDay day = Owner.EmployeeWeek.GetDay(Owner.CurrentDate);
            return ValidateNew(day);
        }
    }
}
