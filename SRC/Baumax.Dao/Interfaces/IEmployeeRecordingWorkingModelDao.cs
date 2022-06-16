using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IEmployeeRecordingWorkingModelDao : IDao<EmployeeRecordingWorkingModel>
    {
        List<EmployeeRecordingWorkingModel> GetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate);


        List<EmployeeRecordingWorkingModel> GetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate);


        void SetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels);


        void SetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels);
    }
}