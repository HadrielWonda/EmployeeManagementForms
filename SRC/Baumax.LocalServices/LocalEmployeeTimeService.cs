using System;
using Baumax.Contract.Interfaces;
using System.Collections.Generic;
using Baumax.Contract.Import;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Contract.Absences;

namespace Baumax.LocalServices
{
    public class LocalEmployeeTimeService : LocalService, IEmployeeTimeService
    {
        private IEmployeeTimeService RemoteService
        {
            get { return (IEmployeeTimeService) _remoteService; }
        }

        private IAbsenceTimePlanningService _absenceTimePlanningService;
        private IAbsenceTimeRecordingService _absenceTimeRecordingService;
        private IWorkingTimePlanningService _workingTimePlanningService;
        private IWorkingTimeRecordingService _workingTimeRecordingService;
        private IEmployeeDayStatePlanningService _employeeDayStatePlanningService;
        private IEmployeeDayStateRecordingService _employeeDayStateRecordingService;
        private IEmployeeWeekTimePlanningService _employeeWeekTimePlanningService;
        private IEmployeeWeekTimeRecordingService _employeeWeekTimeRecordingService;
        private IEmployeePlanningWorkingModelService _employeePlanningWorkingModelService;
        private IEmployeeRecordingWorkingModelService _employeeRecordingWorkingModelService;
        private IEmployeeHolidaysInfoService _employeeHolidaysInfoService;

        private readonly IOperationCompleteReceiver _operationCompleteRcv = new OperationCompleteReceiver();

        private event OperationCompleteDelegate _OperationComplete;

        public event OperationCompleteDelegate OperationComplete
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_OperationComplete);
                _OperationComplete += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeOperationComplete(_operationCompleteRcv);
                    _operationCompleteRcv.OperationComplete += new OperationCompleteDelegate(OnOperationComplete);
                }
            }
            remove
            {
                _OperationComplete -= value;
                if (!Utils.IsDelegateSubscribers(_OperationComplete))
                {
                    RemoteService.UnsubscribeOperationComplete(_operationCompleteRcv);
                    _operationCompleteRcv.OperationComplete -= new OperationCompleteDelegate(OnOperationComplete);
                }
            }
        }

        private void OnOperationComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_OperationComplete != null)
            {
                lock (_OperationComplete)
                {
                    if (_OperationComplete != null)
                    {
                        _OperationComplete(sender, e);
                    }
                }
            }
        }

        #region IEmployeeTimeService Members

        public IAbsenceTimePlanningService AbsenceTimePlanningService
        {
            get { return _absenceTimePlanningService; }
        }

        public IAbsenceTimeRecordingService AbsenceTimeRecordingService
        {
            get { return _absenceTimeRecordingService; }
        }

        public IWorkingTimePlanningService WorkingTimePlanningService
        {
            get { return _workingTimePlanningService; }
        }

        public IWorkingTimeRecordingService WorkingTimeRecordingService
        {
            get { return _workingTimeRecordingService; }
        }

        public IEmployeeDayStatePlanningService EmployeeDayStatePlanningService
        {
            get { return _employeeDayStatePlanningService; }
        }

        public IEmployeeDayStateRecordingService EmployeeDayStateRecordingService
        {
            get { return _employeeDayStateRecordingService; }
        }

        public IEmployeeWeekTimePlanningService EmployeeWeekTimePlanningService
        {
            get { return _employeeWeekTimePlanningService; }
        }

        public IEmployeeWeekTimeRecordingService EmployeeWeekTimeRecordingService
        {
            get { return _employeeWeekTimeRecordingService; }
        }

        public IEmployeePlanningWorkingModelService EmployeePlanningWorkingModelService
        {
            get { return _employeePlanningWorkingModelService; }
        }

        public IEmployeeRecordingWorkingModelService EmployeeRecordingWorkingModelService
        {
            get { return _employeeRecordingWorkingModelService; }
        }

        public IEmployeeHolidaysInfoService EmployeeHolidaysInfoService
        {
            get { return _employeeHolidaysInfoService; }
        }

        public void ImportTime(List<ImportTimeData> list, ImportTimeType importTimeType)
        {
            RemoteService.ImportTime(list, importTimeType);
        }

        public void SavePlanning(DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks)
        {
            RemoteService.SavePlanning(aBegin, aEnd, lstWeeks);
        }
        public void SavePlanning2(long storeid, DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks)
        {
            RemoteService.SavePlanning2(storeid, aBegin, aEnd, lstWeeks);
        }
        public void SaveActualEmployeeWeek(List<EmployeeWeek> lstWeeks)
        {
            RemoteService.SaveActualEmployeeWeek(lstWeeks);
        }
        public void SaveActualEmployeeTimeRange(long storeid, DateTime aBegin,
                                                DateTime aEnd, long[] employeeids, List<EmployeeTimeRange> lst)
        {
            RemoteService.SaveActualEmployeeTimeRange(storeid, aBegin, aEnd, employeeids, lst);
        }
        public void SetAbsenceTimePlanning(List<AbsenceTimePlanning> list)
        {
            RemoteService.SetAbsenceTimePlanning(list);
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeOperationComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeOperationComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        public long[][] EmployeeTimeSaldoGet(long[] employeeIDList, EmployeeTimeSaldoType employeeTimeSaldoType,
                                             DateTime date)
        {
            return
                ((IEmployeeTimeService) _remoteService).EmployeeTimeSaldoGet(employeeIDList, employeeTimeSaldoType, date);
        }

        public void DeleteAllAbsences(DateTime beginDate, DateTime endDate, long employeeID) 
        {
            RemoteService.DeleteAllAbsences(beginDate, endDate, employeeID);
        }

        public EmployeeLongTimeAbsence SaveLongTimeAbsence(EmployeeLongTimeAbsence entity)
        {
            return RemoteService.SaveLongTimeAbsence(entity);
        }

        public AbsencePlanningQuery GetAllAbsencePlanning(long storeID, long countryID, int year, DateTime today)
        {
            return RemoteService.GetAllAbsencePlanning(storeID, countryID, year, today);
        }

        public void RecalculateHolidaysInfo(int year, long storeID, DateTime today)
        {
            RemoteService.RecalculateHolidaysInfo(year, storeID, today);
        }

        public AbsencePlanningResponse SaveAbsencePlanning(AbsencePlanningResponse response)
        {
            return RemoteService.SaveAbsencePlanning(response);
        }

        public long[] EmployeeListContractEndOutsideChangedGet()
        {
            return RemoteService.EmployeeListContractEndOutsideChangedGet();
        }
        public void RecalculateInactiveEmployees()
        {
            RemoteService.RecalculateInactiveEmployees();
        }
        public DateTime GetMaxDateOfPlanningOrRecording(long emplid)
        {
            return RemoteService.GetMaxDateOfPlanningOrRecording(emplid);
        }

        #endregion
    }
}