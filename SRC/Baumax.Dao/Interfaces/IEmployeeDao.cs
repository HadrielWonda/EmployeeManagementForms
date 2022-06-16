using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IEmployeeDao : IDao<Employee>
    {
        ImportEmployeeResult ImportEmployee(List<ImportEmployeeData> list);
		IList GetEmployeeList(long storeID, DateTime date);
        Employee Assign(Employee employee, long storeID, long? worldID, long? hwgrID, DateTime beginTime, DateTime endDate);
        EmployeeShortView[] GetEmployeesNames(long storeid);
        void Merge(long employeeIDInternal, long employeeIDExternal);
        Employee GetEmployeeByID(long employeeID, DateTime date);

        IList GetPlanningEmployees(long storeid, DateTime aBegin, DateTime aEnd);
        IList GetPlanningEmployeesByWorld(long storeid, long worldid, DateTime aBegin, DateTime aEnd);
        bool HasWorkingOrAbsenceTime(long employeeID, DateTime beginTime, DateTime endTime);
        bool HasWorkingOrAbsenceTimeEx(long employeeID, DateTime beginTime, DateTime endTime);
        long[][] GetEmployeeToMergeList();

        Employee UpdateHolidays(long employeeID, decimal OldHolidays, decimal NewHolidays);
        Employee UpdateSaldo(long employeeID, decimal saldo);
        //Dictionary<long, bool> GetEmployeeImportAllIn(long storeid);
        // Export for Hungary
        void ExportHungaryGetWTimes(DateTime? from, DateTime? to);
        void ExportHungaryGetAvailableAbsences();

        void AssignHwgr(long employeeId, long? hwgrID);


        List<Employee> GetEmployeeByIds(long[] ids);
        List<DiffContractRelation> GetDifferenceContractsAndRelations();
        List<Employee> GetStoreEmployeesHaveContracts(long storeid, DateTime begin, DateTime end);
        List<Employee> GetCountryEmployeesHaveContracts(long countryid, DateTime begin, DateTime end);
        List<Employee> GetCountryEmployees(long countryid);
    }
}
