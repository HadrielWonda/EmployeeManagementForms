using System;
using System.Collections.Generic;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.Contract.TimePlanning;
using System.Diagnostics;
using Baumax.Domain;

namespace Baumax.Services._HelperObjects.ExEntity
{
    class ExPlanningWorkingTime
    {
        private WorkingTimePlanningService _service;

        protected WorkingTimePlanningService Service
        {
            get { return _service; }
        }
        public ExPlanningWorkingTime()
        {
            _service = ServerEnvironment.WorkingTimePlanningService as WorkingTimePlanningService;

            Debug.Assert(Service != null);
        }

        public void SavePlanningWeek(EmployeePlanningWeek week)
        {
            Debug.Assert(week != null);
            Debug.Assert(week.EmployeeId > 0);

            List<WorkingTimePlanning> list_old = Service.GetWorkingTimeByEmployeeId(week.EmployeeId, week.BeginDate, week.EndDate);

            List<WorkingTimePlanning> list_new = new List<WorkingTimePlanning>(10);

            List<WorkingTimePlanning> temp_list = new List<WorkingTimePlanning>(10);

            foreach (EmployeePlanningDay day in week.Days.Values)
            {
                if (day.WorkingTimeList != null)
                {
                    list_new.AddRange(day.WorkingTimeList);
                }
            }

            if (list_new.Count > 0)
            {
                bool bFound = false;
                foreach (WorkingTimePlanning entity in list_new)
                {
                    bFound = false;
                    if (list_old != null && list_old.Count > 0)
                    {
                        for (int i = 0; i < list_old.Count; i++)
                        {
                            if (list_old[i] != null && list_old[i].Compare(entity))
                            {
                                entity.ID = list_old[i].ID;
                                bFound = true;
                                list_old[i] = null;
                                break;
                            }
                        }
                    }

                    if (!bFound)
                    {
                        Service.Save(entity);
                    }
                }
            }

            if (list_old != null)
            {
                foreach (WorkingTimePlanning entity in list_old)
                {
                    if (entity != null)
                        Service.Delete(entity);
                }
            }



        }

        public void SavePlanningWeek(List<EmployeePlanningWeek> weeks)
        {
            if (weeks == null || weeks.Count == 0) return;

            long[] ids = PlanningWeekProcessor.ListToEmployeeIds(weeks);
            List<WorkingTimePlanning> list_old = Service.GetWorkingTimePlanningsByEmployeeIds(ids, weeks[0].BeginDate, weeks[0].EndDate);

            List<WorkingTimePlanning> list_new = new List<WorkingTimePlanning>(100);
            foreach (EmployeePlanningWeek week in weeks)
            {
                foreach (EmployeePlanningDay day in week.Days.Values)
                {
                    if (day.WorkingTimeList != null)
                    {
                        list_new.AddRange(day.WorkingTimeList);
                    }
                }
            }

            if (list_new.Count > 0)
            {
                bool bFound = false;
                foreach (WorkingTimePlanning entity in list_new)
                {
                    bFound = false;
                    if (list_old != null && list_old.Count > 0)
                    {
                        for (int i = 0; i < list_old.Count; i++)
                        {
                            if (list_old[i] != null && list_old[i].Compare(entity))
                            {
                                entity.ID = list_old[i].ID;
                                bFound = true;
                                list_old[i] = null;
                                break;
                            }
                        }
                    }

                    if (!bFound)
                    {
                        Service.Save(entity);
                    }
                }
            }

            if (list_old != null)
            {
                foreach (WorkingTimePlanning entity in list_old)
                {
                    if (entity != null)
                        Service.Delete(entity);
                }
            }



        }
    }
}
