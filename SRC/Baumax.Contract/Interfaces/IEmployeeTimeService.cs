using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using System;
using Baumax.Contract.Absences;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeTimeService : IService
    {
        IAbsenceTimePlanningService AbsenceTimePlanningService { get; }
        IAbsenceTimeRecordingService AbsenceTimeRecordingService { get; }
        IWorkingTimePlanningService WorkingTimePlanningService { get; }
        IWorkingTimeRecordingService WorkingTimeRecordingService { get; }
        IEmployeeDayStatePlanningService EmployeeDayStatePlanningService { get; }
        IEmployeeDayStateRecordingService EmployeeDayStateRecordingService { get; }
        IEmployeeWeekTimePlanningService EmployeeWeekTimePlanningService { get; }
        IEmployeeWeekTimeRecordingService EmployeeWeekTimeRecordingService { get; }
        IEmployeePlanningWorkingModelService EmployeePlanningWorkingModelService { get; }
        IEmployeeRecordingWorkingModelService EmployeeRecordingWorkingModelService { get; }
        IEmployeeHolidaysInfoService EmployeeHolidaysInfoService { get; }

        event OperationCompleteDelegate OperationComplete;

        void SubscribeOperationComplete(IOperationCompleteReceiver receiver);
        void UnsubscribeOperationComplete(IOperationCompleteReceiver receiver);

        void ImportTime(List<ImportTimeData> list, ImportTimeType importTimeType);


        void SavePlanning(DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks);
        void SavePlanning2(long storeid, DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks);
        
        
        void SaveActualEmployeeWeek(List<EmployeeWeek> lstWeeks);
        void SaveActualEmployeeTimeRange(long storeid, DateTime aBegin,
                                                DateTime aEnd, long[] employeeids, List<EmployeeTimeRange> lst);

        void SetAbsenceTimePlanning(List<AbsenceTimePlanning> list);
        long[][] EmployeeTimeSaldoGet(long[] employeeIDList, EmployeeTimeSaldoType employeeTimeSaldoType, DateTime date);

        void DeleteAllAbsences(DateTime beginDate, DateTime endDate, long employeeID);
        EmployeeLongTimeAbsence SaveLongTimeAbsence(EmployeeLongTimeAbsence entity);
        AbsencePlanningQuery GetAllAbsencePlanning(long storeID, long countryID, int year, DateTime today);
        void RecalculateHolidaysInfo(int year, long storeID, DateTime today);
        AbsencePlanningResponse SaveAbsencePlanning(AbsencePlanningResponse response);
        long[] EmployeeListContractEndOutsideChangedGet();
        void RecalculateInactiveEmployees();
        DateTime GetMaxDateOfPlanningOrRecording(long emplid);
    }
}