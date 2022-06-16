using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.PlanningAndRecording;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        IEmployeeRelationService EmployeeRelationService { get; }
        IEmployeeAllInService EmployeeAllInService { get; }
        IEmployeeContractService EmployeeContractService { get; }
        ILongTimeAbsenceService LongTimeAbsenceService { get; }
        IEmployeeLongTimeAbsenceService EmployeeLongTimeAbsenceService { get; }
        IEmployeeTimeService EmployeeTimeService { get; }

        #region // 3.08.2007 IgorYakubov
        EmployeeLongTimeAbsence[] GetLongAbsenceEmployees(long storeid, DateTime? date);
        EmployeeShortView[] GetEmployeesNames(long storeid);
        #endregion

        ImportEmployeeResult ImportEmployee(List<ImportEmployeeData> list);
        IList GetEmployeeList(long storeID, DateTime date, bool isAustria);
        List<Employee> GetEmployeeTypedList(long storeID, DateTime? date, bool isAustria);
        Employee Assign(Employee employee, long storeID, DateTime beginTime, DateTime endDate);
        Employee Assign(Employee employee, long storeID, long? worldID, DateTime beginTime, DateTime endDate);
        Employee Assign(Employee employee, long storeID, long? worldID, long? hwgrID, DateTime beginTime, DateTime endDate);
        void AssignHwgr(long employeeId, long? hwgrID);
        void Merge(long employeeIDInternal, long employeeIDExternal);
        Employee GetEmployeeByID(long employeeID, DateTime date);

        Employee SaveExternalEmployee(Employee employee, DateTime filterDate);

        //TimePlanningResult GetTimePlannignEmployee(long storeid, DateTime aBegin, DateTime aEnd);
        List<EmployeePlanningWeek> GetTimePlannignEmployee2(long storeid, DateTime aBegin, DateTime aEnd);
        List<EmployeePlanningWeek> GetTimePlannignEmployeeByWorld(long storeid, long worldid, DateTime aBegin, DateTime aEnd);
        List<EmployeeWeek> GetTimePlannignEmployeeByWorld2(long storeid, long worldid, DateTime aBegin, DateTime aEnd);
        List<EmployeeWeek> GetTimeRecordingEmployeeByWorld(long storeid, long worldid, DateTime aBegin, DateTime aEnd);
        bool HasWorkingOrAbsenceTime(long employeeID, DateTime beginTime, DateTime endTime);
        bool HasWorkingOrAbsenceTimeEx(long employeeID, DateTime beginTime, DateTime endTime);
        /// <summary>
        /// Get Employee list, that can be merge.
        ///     long[n][0] - EmployeeID, long[n][1] - MainStoreID
        /// </summary>
        /// <returns></returns>
        long[][] GetEmployeeToMergeList();

        List<EmployeeLongTimeAbsence> GetLongAbsenceEmployees(long storeid, DateTime start, DateTime end);
        [Obsolete("Use SaveEmployeeHolidays(EmployeeHolidaysInfo info)")]
        void SaveEmployeeHolidays(long emplid, decimal oldHolidays, decimal newHolidays, decimal? usedHolidays, decimal? holidaysInc, decimal? holidaysExc);
        // Add 31.01.2008 Igor Yakubov
        EmployeeHolidaysInfo SaveEmployeeHolidays(EmployeeHolidaysInfo info);
        void SaveEmployeeSaldo(long emplid, decimal saldo);

        //List<EmployeeContract> GetEmployeeContracts(long storeID, DateTime dateBegin, DateTime dateEnd);

        void ExportHungaryGetWTimes(DateTime? from, DateTime? to);
        void ExportHungaryGetAvailableAbsences();

        EmployeeDebugInfo GetEmployeeDebugInfo(long emplid);

        void DebugRecalculation();
    }
}