using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Dao;
using System.Collections.Generic;
using System;

namespace Baumax.Services
{
    [ServiceID("42BBA523-3E77-42d4-B9BC-89087BF4B514")]
    public class EmployeeRecordingWorkingModelService : BaseService<EmployeeRecordingWorkingModel>, IEmployeeRecordingWorkingModelService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        public IEmployeeRecordingWorkingModelDao ServiceDao
        {
            get { return (IEmployeeRecordingWorkingModelDao)Dao; }
        }

        public List<EmployeeRecordingWorkingModel> LoadByEmployeesAndDateRange(long[] emplids, DateTime begin, DateTime end)
        {
            return ServiceDao.GetWorkingModelByEmployeeIds(emplids, begin, end);
        }

        public List<EmployeeRecordingWorkingModel> LoadByEmployeeAndDateRange(long emplid, DateTime begin, DateTime end)
        {
            return ServiceDao.GetWorkingModelByEmployeeId(emplid, begin, end);
        }

        public void SetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels)
        {
            ServiceDao.SetWorkingModelByEmployeeId(employeeId, beginDate, endDate, lstModels);
        }


        public void SetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels)
        {
            ServiceDao.SetWorkingModelByEmployeeIds(employeeIds, beginDate, endDate, lstModels);
        }

        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeRecordingWorkingModel> models = ServiceDao.GetWorkingModelByEmployeeId(id, aBegin, aEnd);
            if (models != null && models.Count > 0)
            {
                DeleteList(models);
                //foreach (EmployeePlanningWorkingModel entity in models)
                //    DeleteByID(entity.ID);
            }
        }
    }
}