using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalEmployeeWeekTimePlanningService : LocalBaseCachingService<EmployeeWeekTimePlanning>, IEmployeeWeekTimePlanningService
    {
        private IEmployeeWeekTimePlanningService RemoteService
        {
            get { return (IEmployeeWeekTimePlanningService)_remoteService; }
        }

        public void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            throw new NotSupportedException();
            /*if (planningweeks != null)
            {
                RemoteService.SaveEmployeePlanningWeeks(planningweeks);
            }*/
        }


        public List<EmployeeWeekTimePlanning> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            throw new NotSupportedException();
            /*
            if (emplids != null && emplids.Length > 0)
            {
                return RemoteService.GetEmployeesWeekState(emplids, beginDate, endDate);
            }
            return null;*/
        }
        public void FillEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            throw new NotSupportedException();
        }
    }
}