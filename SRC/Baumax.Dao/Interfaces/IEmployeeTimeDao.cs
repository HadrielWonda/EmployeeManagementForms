using System.Collections.Generic;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using System;
using Baumax.Contract;
using System;

namespace Baumax.Dao
{
    public interface IEmployeeTimeDao
    {
        SaveDataResult ImportTime(List<ImportTimeData> list, ImportTimeType importTimeType);

        int? GetEmployeeLastVerifiedSaldo(long employeeid, DateTime currentMonday);
        long[][] EmployeeTimeSaldoGet(long[] employeeIDList, EmployeeTimeSaldoType employeeTimeSaldoType, DateTime date);

        List<long> GetStoresWhereWorkedEmployee(long employeeid, DateTime begin, DateTime end);
        long[] EmployeeListContractEndOutsideChangedGet();

        DateTime GetMaxDateOfPlanningOrRecording(long emplid);
    }
}
