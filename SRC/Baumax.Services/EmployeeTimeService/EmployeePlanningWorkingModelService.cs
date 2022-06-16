using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System;
using System.Collections;
using Baumax.Dao;
using System.Collections.Generic;

namespace Baumax.Services
{
    [ServiceID("CEF42569-7F43-4389-B0AA-A59B460B9E21")]
    public class EmployeePlanningWorkingModelService : BaseService<EmployeePlanningWorkingModel>, IEmployeePlanningWorkingModelService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }
        public IEmployeePlanningWorkingModelDao ServiceDao
        {
            get { return (IEmployeePlanningWorkingModelDao)Dao; }
        }

        private void DeleteByEmployeeDay(long employeeid, DateTime date)
        {
            IList lst = LoadByEmployeeDay(employeeid, date);
            if (lst != null && lst.Count > 0)
            {
                foreach (EmployeePlanningWorkingModel model in lst)
                    DeleteByID(model.ID);
            }
        }
        private IList LoadByEmployeeDay(long employeeid, DateTime date)
        {
            return Dao.FindByNamedParam("EmployeeID=:emplid AND Date=:pldate",
                new string[] { "emplid", "pldate" },
                new object[] { employeeid, date });
        }

        public List<EmployeePlanningWorkingModel> LoadByEmployeesAndDateRange(long[] emplids, DateTime begin, DateTime end)
        {
            return ServiceDao.GetWorkingModelByEmployeeIds(emplids, begin, end);
        }

        public List<EmployeePlanningWorkingModel> LoadByEmployeeAndDateRange(long emplid, DateTime begin, DateTime end)
        {
            return ServiceDao.GetWorkingModelByEmployeeId(emplid, begin, end);
        }

        public void SaveEmployeeDay(EmployeePlanningDay planningday)
        {

            if (planningday != null )
            {
                DeleteByEmployeeDay(planningday.EmployeeId, planningday.Date);

                if (planningday.WorkingModels != null && planningday.WorkingModels.Count > 0)
                {
                    foreach (EmployeePlanningWorkingModel model in planningday.WorkingModels)
                    {
                        model.ID = 0;
                        ServiceDao.SaveOrUpdate(model);
                    }
                }
            }
        }
        public void SaveEmployeeWeek(EmployeePlanningWeek planningweek)
        {

            if (planningweek != null)
            {
                List<EmployeePlanningWorkingModel> models = new List<EmployeePlanningWorkingModel>();

                ClearEmployeeByDateRange(planningweek.EmployeeId, planningweek.BeginDate, planningweek.EndDate);

                foreach (EmployeePlanningDay day in planningweek.Days.Values)
                {
                    if (day.WorkingModels != null)
                        models.AddRange(day.WorkingModels);
                }

                foreach (EmployeePlanningWorkingModel entity in models)
                {
                    entity.ID = 0;
                    ServiceDao.SaveOrUpdate(entity);
                }
            }
        }

        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List < EmployeePlanningWorkingModel> models = ServiceDao.GetWorkingModelByEmployeeId(id, aBegin, aEnd);
            if (models != null && models.Count > 0)
            {
                DeleteList(models);
                //foreach (EmployeePlanningWorkingModel entity in models)
                //    DeleteByID(entity.ID);
            }
        }
    }
}