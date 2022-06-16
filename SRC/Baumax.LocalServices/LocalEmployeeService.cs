using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using System.Collections;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.PlanningAndRecording;

namespace Baumax.LocalServices
{
    public class LocalEmployeeService : LocalBaseCachingService<Employee>, IEmployeeService
    {
        private IEmployeeRelationService _employeeRelationService;
        private IEmployeeContractService _employeeContractService;
        private ILongTimeAbsenceService _longTimeAbsenceService;
        private IEmployeeLongTimeAbsenceService _employeeLongTimeAbsenceService;
        private IEmployeeTimeService _employeeTimeService;
        private IEmployeeAllInService _employeeAllInService;

        private IEmployeeService RemoteService
        {
            get { return (IEmployeeService) _remoteService; }
        }

        #region IEmployeeService Members

        public IEmployeeRelationService EmployeeRelationService
        {
            get { return _employeeRelationService; }
        }

        public IEmployeeContractService EmployeeContractService
        {
            get { return _employeeContractService; }
        }

        public ILongTimeAbsenceService LongTimeAbsenceService
        {
            get { return _longTimeAbsenceService; }
        }

        public IEmployeeLongTimeAbsenceService EmployeeLongTimeAbsenceService
        {
            get { return _employeeLongTimeAbsenceService; }
        }

        public IEmployeeTimeService EmployeeTimeService
        {
            get { return _employeeTimeService; }
        }

        public IEmployeeAllInService EmployeeAllInService
        {
            get { return _employeeAllInService; }
        }

        public EmployeeShortView[] GetEmployeesNames(long storeid)
        {
            return ((IEmployeeService) _remoteService).GetEmployeesNames(storeid);
        }

        public EmployeeLongTimeAbsence[] GetLongAbsenceEmployees(long storeid, DateTime? date)
        {
            return ((IEmployeeService) _remoteService).GetLongAbsenceEmployees(storeid, date);
        }

        public List<EmployeeLongTimeAbsence> GetLongAbsenceEmployees(long storeid, DateTime start, DateTime end)
        {
            return ((IEmployeeService) _remoteService).GetLongAbsenceEmployees(storeid, start, end);
        }

        public ImportEmployeeResult ImportEmployee(List<ImportEmployeeData> list)
        {
            return ((IEmployeeService) _remoteService).ImportEmployee(list);
        }

        public IList GetEmployeeList(long storeID, DateTime date, bool isAustria)
        {
            return ((IEmployeeService) _remoteService).GetEmployeeList(storeID, date, isAustria);
        }

        public Employee Assign(Employee employee, long storeID, DateTime beginTime, DateTime endDate)
        {
            return ((IEmployeeService) _remoteService).Assign(employee, storeID, beginTime, endDate);
        }

        public Employee Assign(Employee employee, long storeID, long? worldID, DateTime beginTime, DateTime endDate)
        {
            return ((IEmployeeService) _remoteService).Assign(employee, storeID, worldID, beginTime, endDate);
        }

        public Employee Assign(Employee employee, long storeID, long? worldID, long? hwgrID, DateTime beginTime,
                               DateTime endDate)
        {
            return ((IEmployeeService) _remoteService).Assign(employee, storeID, worldID, hwgrID, beginTime, endDate);
        }

        public void Merge(long employeeIDInternal, long employeeIDExternal)
        {
            ((IEmployeeService) _remoteService).Merge(employeeIDInternal, employeeIDExternal);
        }

        public Employee GetEmployeeByID(long employeeID, DateTime date)
        {
            return ((IEmployeeService) _remoteService).GetEmployeeByID(employeeID, date);
        }


        //public TimePlanningResult GetTimePlannignEmployee(long storeid, DateTime aBegin, DateTime aEnd)
        //{
        //    return ((IEmployeeService) _remoteService).GetTimePlannignEmployee(storeid, aBegin, aEnd);
        //}

        public List<EmployeePlanningWeek> GetTimePlannignEmployee2(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return ((IEmployeeService) _remoteService).GetTimePlannignEmployee2(storeid, aBegin, aEnd);
        }

        public List<EmployeePlanningWeek> GetTimePlannignEmployeeByWorld(long storeid, long worldid, DateTime aBegin,
                                                                         DateTime aEnd)
        {
            return ((IEmployeeService) _remoteService).GetTimePlannignEmployeeByWorld(storeid, worldid, aBegin, aEnd);
        }

        public List<EmployeeWeek> GetTimePlannignEmployeeByWorld2(long storeid, long worldid, DateTime aBegin,
                                                                  DateTime aEnd)
        {
            return ((IEmployeeService) _remoteService).GetTimePlannignEmployeeByWorld2(storeid, worldid, aBegin, aEnd);
        }

        public List<EmployeeWeek> GetTimeRecordingEmployeeByWorld(long storeid, long worldid, DateTime aBegin,
                                                                  DateTime aEnd)
        {
            return ((IEmployeeService) _remoteService).GetTimeRecordingEmployeeByWorld(storeid, worldid, aBegin, aEnd);
        }

        public bool HasWorkingOrAbsenceTime(long employeeID, DateTime beginTime, DateTime endTime)
        {
            return ((IEmployeeService) _remoteService).HasWorkingOrAbsenceTime(employeeID, beginTime, endTime);
        }
        public bool HasWorkingOrAbsenceTimeEx(long employeeID, DateTime beginTime, DateTime endTime)
        {
            return ((IEmployeeService)_remoteService).HasWorkingOrAbsenceTimeEx(employeeID, beginTime, endTime);
        }
        public long[][] GetEmployeeToMergeList()
        {
            return ((IEmployeeService) _remoteService).GetEmployeeToMergeList();
        }

        public List<Employee> GetEmployeeTypedList(long storeID, DateTime? date, bool isAustria)
        {
            return ((IEmployeeService) _remoteService).GetEmployeeTypedList(storeID, date, isAustria);
        }

        public void SaveEmployeeHolidays(long emplid, decimal oldHolidays, decimal newHolidays, decimal? usedHolidays,
                                         decimal? holidaysInc, decimal? holidaysExc)
        {
            RemoteService.SaveEmployeeHolidays(emplid, oldHolidays, newHolidays, usedHolidays, holidaysInc, holidaysExc);
        }
        public EmployeeHolidaysInfo SaveEmployeeHolidays(EmployeeHolidaysInfo info)
        {
            return RemoteService.SaveEmployeeHolidays(info);
        }
        public void SaveEmployeeSaldo(long emplid, decimal saldo)
        {
            RemoteService.SaveEmployeeSaldo(emplid, saldo);
        }
        public Employee SaveExternalEmployee(Employee employee, DateTime filterDate)
        {
            return RemoteService.SaveExternalEmployee(employee, filterDate);
        }
        //public List<EmployeeContract> GetEmployeeContracts(long storeID, DateTime dateBegin, DateTime dateEnd)
        //{
        //    return RemoteService.GetEmployeeContracts(storeID, dateBegin, dateEnd);
        //}

        public EmployeeDebugInfo GetEmployeeDebugInfo(long emplid)
        {
            return RemoteService.GetEmployeeDebugInfo(emplid);
        }
        #endregion

        #region HungaryExport

        public void ExportHungaryGetWTimes(DateTime? from, DateTime? to)
        {
            RemoteService.ExportHungaryGetWTimes(from, to);
        }

        public void ExportHungaryGetAvailableAbsences()
        {
            RemoteService.ExportHungaryGetAvailableAbsences();
        }

        #endregion

        #region IEmployeeService Members


        public void AssignHwgr(long employeeId, long? hwgrID)
        {
            ((IEmployeeService) _remoteService).AssignHwgr(employeeId, hwgrID);
        }

        public void DebugRecalculation()
        {
            ((IEmployeeService)_remoteService).DebugRecalculation();
        }
        #endregion
    }
}