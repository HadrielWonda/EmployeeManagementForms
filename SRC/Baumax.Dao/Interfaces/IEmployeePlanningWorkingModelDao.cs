using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using System;

namespace Baumax.Dao
{
    public interface IEmployeePlanningWorkingModelDao : IDao<EmployeePlanningWorkingModel>
    {
        IList LoadByEmployeesAndDateRange(long[] emplids, DateTime begin, DateTime end);

        List<EmployeePlanningWorkingModel> GetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);


        List<EmployeePlanningWorkingModel> GetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate);


        void SetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate, List<EmployeePlanningWorkingModel> lstModels);


        void SetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate, List<EmployeePlanningWorkingModel> lstModels);

    }
}