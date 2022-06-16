using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract;
using System.Threading;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Belikov.GenuineChannels;
using Belikov.GenuineChannels.BroadcastEngine;
using Spring.Transaction.Interceptor;
using Baumax.Contract.PlanningAndRecording;
using Baumax.Services._HelperObjects;
using Baumax.Contract.Absences;
//using Baumax.Contract.HolydayClasses;
using Baumax.Contract.Exceptions;
using Baumax.AppServer.Environment;
using System.Diagnostics;
using Baumax.Services._HelperObjects.ExEntity;
using Common.Logging;

namespace Baumax.Services
{
    [ServiceID("292D9942-DA73-408a-B01C-50D342AC3810")]
    public class EmployeeTimeService : RemoteService, IEmployeeTimeService
    {
        private static bool _IsRunningEmployeeTimeImport = false;
        private static Object _SyncIsRunningEmployeeTimeImport = new Object();

        private static bool IsRunningEmployeeTimeImport
        {
            get { return _IsRunningEmployeeTimeImport; }
            set
            {
                lock (_SyncIsRunningEmployeeTimeImport)
                {
                    if (_IsRunningEmployeeTimeImport != value)
                        _IsRunningEmployeeTimeImport = value;
                }
            }
        }

        private readonly Dispatcher _OperationCompleteDispatcher = new Dispatcher(typeof(IOperationCompleteReceiver));
        private readonly IOperationCompleteReceiver _OperationCompleteCaller;

        private IEmployeeService _employeeService;
        private IAbsenceService _absenceService;

        private IAbsenceTimePlanningService _absenceTimePlanningService;
        private IAbsenceTimeRecordingService _absenceTimeRecordingService;
        private IWorkingTimePlanningService _workingTimePlanningService;
        private IWorkingTimeRecordingService _workingTimeRecordingService;
        private IEmployeeTimeDao _EmployeeTimeDao;
        private IStoreService _storeService;
        private ICountryService _countryService;
        private IEmployeeDayStatePlanningService _employeeDayStatePlanningService;
        private IEmployeeDayStateRecordingService _employeeDayStateRecordingService;
        private IEmployeeWeekTimePlanningService _employeeWeekTimePlanningService;
        private IEmployeeWeekTimeRecordingService _employeeWeekTimeRecordingService;
        private IEmployeePlanningWorkingModelService _employeePlanningWorkingModelService;
        private IEmployeeRecordingWorkingModelService _employeeRecordingWorkingModelService;
        private IEmployeeHolidaysInfoService _employeeHolidaysInfoService;
        private IEmployeeLongTimeAbsenceService _employeeLongTimeAbsenceService;


        private event OperationCompleteDelegate _OperationComplete;

        public event OperationCompleteDelegate OperationComplete
        {
            add { _OperationComplete += value; }
            remove { _OperationComplete -= value; }
        }

        #region Services

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        public IAbsenceService AbsenceService
        {
            get { return _absenceService; }
        }

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

        public IEmployeeLongTimeAbsenceService EmployeeLongTimeAbsenceService
        {
            get { return _employeeLongTimeAbsenceService; }
        }

        #endregion

        public EmployeeTimeService()
        {
            _OperationCompleteDispatcher.BroadcastCallFinishedHandler += OperationCompleteBroadcastCallFinishedHandler;
            _OperationCompleteDispatcher.CallIsAsync = true;
            _OperationCompleteCaller = (IOperationCompleteReceiver)_OperationCompleteDispatcher.TransparentProxy;
        }

        [AccessType(AccessType.Import)]
        public void ImportTime(List<ImportTimeData> list, ImportTimeType importTimeType)
        {
            if (IsRunningEmployeeTimeImport)
                throw new AnotherImportRunning();
            IsRunningEmployeeTimeImport = true;
            InheritedContextAsyncStarter.Run(importTimePlanning, new ImportParam(list, importTimeType));
            //Thread thread = new Thread(new ParameterizedThreadStart(importTimePlanning));
            //thread.Start(new ImportParam(list, importTimeType));
        }

        private void OnOperationComplete(object sender, OperationCompleteEventArgs e)
        {
            try
            {
                if (_OperationComplete != null)
                {
                    _OperationComplete(sender, e);
                }
                _OperationCompleteCaller.ReceiveOperationComplete(sender, e);
            }
            finally
            {
                IsRunningEmployeeTimeImport = false;
            }
        }

        private void importTimePlanning(object param)
        {
            OperationCompleteEventArgs operationCompleteEventArgs = new OperationCompleteEventArgs(false);
            ImportParam importParam = (ImportParam)param;
            try
            {
                SaveDataResult saveDataResult =
                    _EmployeeTimeDao.ImportTime(importParam.List, importParam.ImportTimeType);
                operationCompleteEventArgs.Success = saveDataResult.Success;
                //[0,0]- min date
                //[0,1]- max date
                DateTime?[,] minmaxDate = (DateTime?[,])saveDataResult.Data;


                // calculate holidays absence - need change Time field

                if (minmaxDate != null && minmaxDate[0, 0] != null && minmaxDate[0, 1] != null)
                {
                    DateTime minDate = minmaxDate[0, 0].Value;
                    DateTime maxDate = minmaxDate[0, 1].Value;  

                    if (Log.IsDebugEnabled)
                        Log.Debug(minDate.ToShortDateString() + "  " +
                            maxDate.ToShortDateString() + " - start recalculation");

                    EmployeeBusinessObject.RecalculateHolidaysTimeRanges(minDate, maxDate);
                    if (Log.IsDebugEnabled)
                        Log.Debug(minDate.ToShortDateString() + "  " +
                            maxDate.ToShortDateString() + " - finished recalculation");
                }
                //operationCompleteEventArgs.Param = saveDataResult.Data;
            }
            catch (Exception ex)
            {
                operationCompleteEventArgs.Param = ex;
            }
            OnOperationComplete(null, operationCompleteEventArgs);
        }

        private struct ImportParam
        {
            public List<ImportTimeData> List;
            public ImportTimeType ImportTimeType;

            public ImportParam(List<ImportTimeData> list, ImportTimeType importTimeType)
            {
                List = list;
                ImportTimeType = importTimeType;
            }
        }



        [AccessType(AccessType.Write)]
        [Transaction]
        public void SavePlanning(DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks)
        {
            throw new NotSupportedException();
            //try
            //{
            //    WorkingTimePlanningService.SetWeekTimePlanning(lstWeeks);
            //    AbsenceTimePlanningService.SetWeekTimePlanning(lstWeeks);
            //    (EmployeeDayStatePlanningService as IInternalEmployeeDayStatePlanning).SaveEmployeePlanningWeeks(
            //        lstWeeks);
            //    EmployeeWeekTimePlanningService.SaveEmployeePlanningWeeks(lstWeeks);
            //}
            //catch (EntityException)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    CheckForDBValidationException(null, ex);
            //    throw new SaveException(ex);
            //}
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void SavePlanning2(long storeid, DateTime aBegin, DateTime aEnd, List<EmployeePlanningWeek> lstWeeks)
        {
            #region validate date
            Debug.Assert(aBegin < aEnd);
            Debug.Assert(aBegin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(aEnd.DayOfWeek == DayOfWeek.Sunday);

            if (aEnd < DateTime.Today)
            {
                if (Log.IsWarnEnabled)
                {
                    User user = ServerEnvironment.AuthorizationService.GetCurrentUser();
                    string username = String.Empty;
                    if (user != null)
                    {
                        username = user.LoginName;
                    }

                    Log.Warn(string.Format("User - '{0}', try save planning date in date({1}) with input data {2}-{3} storeid={4}",
                        new object[] { username, DateTime.Today, aBegin, aEnd, storeid }));
                }
                return;
            }
            #endregion

            try
            {
                HolidayCalculator calculatorHolidays = new HolidayCalculator();
                calculatorHolidays.Calculate(storeid, aBegin, lstWeeks);


                WorkingTimePlanningService.SetWeekTimePlanning(lstWeeks);
                AbsenceTimePlanningService.SetWeekTimePlanning(lstWeeks);


                StoreWeekCalculater calculator = new StoreWeekCalculater(storeid, aBegin, aEnd, this);

                calculator.Process();


                if (lstWeeks != null)
                {
                    long[] ids = PlanningWeekProcessor.ListToEmployeeIds(lstWeeks);

                    ExEmployeeHolidays.CalculateAndUpdate(ids, DateTimeHelper.GetYearByDate(aBegin));
                }

                _storeService.LastEmployeeWeekTimePlanningUpdate(storeid, aBegin);

            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                CheckForDBValidationException(null, ex);
                throw new SaveException(ex);
            }
        }



        [AccessType(AccessType.Write)]
        [Transaction]
        public void SaveActualEmployeeWeek(List<EmployeeWeek> lstWeeks)
        {
            throw new NotSupportedException();
            //try
            //{
            //    WorkingTimeRecordingService.SaveEmployeesWeek(lstWeeks);
            //    AbsenceTimeRecordingService.SaveEmployeesWeek(lstWeeks);

            //    IServerEmployeeDayService dayService = (EmployeeDayStateRecordingService as IServerEmployeeDayService);

            //    if (dayService != null)
            //    {
            //        dayService.SaveEmployeeWeeks(lstWeeks);
            //    }

            //    IServerEmployeeWeekService weekService =
            //        (EmployeeWeekTimeRecordingService as IServerEmployeeWeekService);
            //    if (weekService != null)
            //    {
            //        weekService.SaveEmployeeWeeks(lstWeeks);
            //    }
            //}
            //catch (EntityException)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    CheckForDBValidationException(null, ex);
            //    throw new SaveException(ex);
            //}
        }

        //[AccessType(AccessType.Write)]
        //[Transaction]
        //public void SaveActualEmployeeTimeRange(long countryid, long storeid, long storeworldid, DateTime aBegin,
        //                                        DateTime aEnd, List<EmployeeTimeRange> lst)
        //{
        //    throw new NotSupportedException();
        //    //try
        //    //{
        //    //    if (lst != null)
        //    //    {
        //    //        lst.Sort();
        //    //    }
        //    //}
        //    //catch (EntityException)
        //    //{
        //    //    throw;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    CheckForDBValidationException(null, ex);
        //    //    throw new SaveException(ex);
        //    //}
        //}
        [AccessType(AccessType.Write)]
        [Transaction]
        public void SaveActualEmployeeTimeRange(long storeid, DateTime aBegin,
                                                DateTime aEnd, long[] employeeids, List<EmployeeTimeRange> lst)
        {
            #region validate date
            Debug.Assert(aBegin < aEnd);
            Debug.Assert(aBegin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(aEnd.DayOfWeek == DayOfWeek.Sunday);

            if (aBegin >= DateTime.Today)
            {
                if (Log.IsWarnEnabled)
                {
                    User user = ServerEnvironment.AuthorizationService.GetCurrentUser();
                    string username = String.Empty;
                    if (user != null)
                    {
                        username = user.LoginName;
                    }

                    Log.Warn(string.Format("User - '{0}', try save recording date in date({1}) with input data {2}-{3} storeid={4}",
                        new object[] { username, DateTime.Today, aBegin, aEnd, storeid }));
                }
                return;
            }
            #endregion

            try
            {
                if (employeeids == null || employeeids.Length == 0) return;

                if (lst != null)
                {
                    lst.Sort();
                }
                List<EmployeeTimeRange> lstWorks = new List<EmployeeTimeRange>();
                List<EmployeeTimeRange> lstAbsences = new List<EmployeeTimeRange>();

                EmployeeTimeRangeHelper.GetWorkingAndAbsenceTimeRange(lst, lstWorks, lstAbsences);



                (WorkingTimeRecordingService as IServerEmployeeTimeRangeService).SaveEmployeeTimeRanges(employeeids, lstWorks, aBegin, aEnd);

                (AbsenceTimeRecordingService as IServerEmployeeTimeRangeService).SaveEmployeeTimeRanges(employeeids, lstAbsences, aBegin, aEnd);

                SrvRecordingStoreWeekCalculator calculator = new SrvRecordingStoreWeekCalculator(storeid, aBegin, aEnd, this);
                calculator.Process();

                _storeService.LastEmployeeWeekTimeRecordingUpdate(storeid, aBegin);

                ExEmployeeHolidays.CalculateAndUpdate(employeeids, DateTimeHelper.GetYearByDate(aBegin));

            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                CheckForDBValidationException(null, ex);
                throw new SaveException(ex);
            }
        }


        public int? GetEmployeeLastVerifiedSaldo(long employeeid, DateTime currentMonday)
        {
            return _EmployeeTimeDao.GetEmployeeLastVerifiedSaldo(employeeid, currentMonday);
        }

        [AccessType(AccessType.Write | AccessType.Read)]
        [Transaction]
        public void SetAbsenceTimePlanning(List<AbsenceTimePlanning> absences)
        {
            throw new NotSupportedException();
            //if (absences != null && absences.Count > 0)
            //{
            //    DateTime startdate = absences[0].Date, enddate = absences[absences.Count - 1].Date;
            //    ClearEmployeeTimeRange(absences[0].EmployeeID, startdate, enddate);
            //    AbsenceTimePlanningService.SaveOrUpdateList(absences);
            //}
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public EmployeeLongTimeAbsence SaveLongTimeAbsence(EmployeeLongTimeAbsence entity)
        {
            if (entity != null)
            {
                ClearEmployeeTimeRange(entity.EmployeeID, entity.BeginTime, entity.EndTime);
                EmployeeLongTimeAbsence ent = _employeeLongTimeAbsenceService.SaveOrUpdate(entity);
                return ent;
            }
            else
                return null;
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void DeleteAllAbsences(DateTime beginDate, DateTime endDate, long employeeID)
        {
            throw new NotSupportedException();

            //if (beginDate > endDate)
            //{
            //    DateTime dateRevers = endDate;
            //    endDate = beginDate;
            //    beginDate = endDate;
            //}
            //string[] aliases = new string[] {"empl", "start", "stop"};
            //object[] plases = new object[] {employeeID, beginDate, endDate};

            //List<EmployeeLongTimeAbsence> intersected = EmployeeLongTimeAbsenceService.FindByNamedParam(
            //    " entity.EmployeeID = :empl AND ((entity.BeginTime >= :start AND entity.BeginTime <= :stop) OR (entity.EndTime >= :start AND entity.EndTime <= :stop)) ",
            //    aliases, plases);
            //if (intersected != null)
            //{
            //    List<EmployeeLongTimeAbsence> inserted = new List<EmployeeLongTimeAbsence>(),
            //                                  deleted = new List<EmployeeLongTimeAbsence>(),
            //                                  updated = new List<EmployeeLongTimeAbsence>();
            //    Baumax.Contract.Absences.AbsenceProcessor
            //        .DeleteLongTimeAbsences(intersected, beginDate, endDate, deleted, inserted, updated);

            //    EmployeeLongTimeAbsenceService.DeleteList(deleted);
            //    EmployeeLongTimeAbsenceService.UpdateList(updated);
            //    EmployeeLongTimeAbsenceService.SaveList(inserted);
            //}

            //List<AbsenceTimePlanning> absences = AbsenceTimePlanningService.FindByNamedParam(
            //    " entity.EmployeeID=:empl AND entity.Date>=:start AND entity.Date<=:stop", aliases, plases);
            //if (absences != null)
            //{
            //    AbsenceTimePlanningService.DeleteList(absences);
            //}
        }

        private void OperationCompleteBroadcastCallFinishedHandler(Dispatcher dispatcher, IMessage message,
                                                                   ResultCollector resultCollector)
        {
            lock (resultCollector)
            {
                foreach (DictionaryEntry entry in resultCollector.Failed)
                {
                    string mbrUri = (string)entry.Key;
                    Exception ex = null;
                    if (entry.Value is Exception)
                    {
                        ex = (Exception)entry.Value;
                    }
                    else
                    {
                        ex = ((IMethodReturnMessage)entry.Value).Exception;
                    }
                    MarshalByRefObject failedObject =
                        dispatcher.FindObjectByUri(mbrUri);

                    Console.WriteLine(
                        "OperationCompleteBroadcastCallFinishedHandler: Receiver {0} has failed. Error: {1}",
                        mbrUri, ex.Message);
                    // here you have failed MBR object (failedObject)
                    // and Exception (ex)
                }
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeOperationComplete(IOperationCompleteReceiver receiver)
        {
            _OperationCompleteDispatcher.Add((MarshalByRefObject)receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeOperationComplete(IOperationCompleteReceiver receiver)
        {
            _OperationCompleteDispatcher.Remove((MarshalByRefObject)receiver);
        }

        [AccessType(AccessType.Read)]
        public long[][] EmployeeTimeSaldoGet(long[] employeeIDList, EmployeeTimeSaldoType employeeTimeSaldoType,
                                             DateTime date)
        {
            try
            {
                return _EmployeeTimeDao.EmployeeTimeSaldoGet(employeeIDList, employeeTimeSaldoType, date);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        // after insert or modify long-time absence need delete all planning data
        [Transaction]
        [AccessType(AccessType.Write)]
        public void ClearEmployeeTimeRange(long employeeId, DateTime aBegin, DateTime aEnd)
        {
            try
            {
                // week
                // day
                // working time
                // absence time
                // workingmodel

                EmployeePlanningWorkingModelService models =
                    (EmployeePlanningWorkingModelService as EmployeePlanningWorkingModelService);
                models.ClearEmployeeByDateRange(employeeId, aBegin, aEnd);

                AbsenceTimePlanningService absences = (AbsenceTimePlanningService as AbsenceTimePlanningService);
                absences.ClearEmployeeByDateRange(employeeId, aBegin, aEnd);
                WorkingTimePlanningService times = (WorkingTimePlanningService as WorkingTimePlanningService);
                times.ClearEmployeeByDateRange(employeeId, aBegin, aEnd);

                EmployeeDayStatePlanningService daystate =
                    (EmployeeDayStatePlanningService as EmployeeDayStatePlanningService);
                daystate.ClearEmployeeByDateRange(employeeId, aBegin, aEnd);

                EmployeeWeekTimePlanningService weekstate =
                    (EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService);
                weekstate.ClearEmployeeByDateRange(employeeId, aBegin, aEnd);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                CheckForDBValidationException(null, ex);
                throw new SaveException(ex);
            }
        }


        public void ClearEmployeePlanningTime(long employeeId, DateTime aBegin, DateTime aEnd)
        {
            (ServerEnvironment.AbsenceTimePlanningService as AbsenceTimePlanningService).ClearEmployeeByDateRange(employeeId, aBegin, aEnd);
            (ServerEnvironment.WorkingTimePlanningService as WorkingTimePlanningService).ClearEmployeeByDateRange(employeeId, aBegin, aEnd);

            (ServerEnvironment.EmployeePlanningWorkingModelService as EmployeePlanningWorkingModelService).ClearEmployeeByDateRange(employeeId, aBegin, aEnd);
        }

        [AccessType(AccessType.Read)]
        public long[] EmployeeListContractEndOutsideChangedGet()
        {
            try
            {
                return _EmployeeTimeDao.EmployeeListContractEndOutsideChangedGet();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void RecalculateInactiveEmployees()
        {
            try
            {
                

                long[] iids = EmployeeListContractEndOutsideChangedGet();
                if (iids != null)
                {
                    InheritedContextAsyncStarter.Run(__RunCalculateEnactiveEmployee, iids);
                    //EmployeeBusinessObject.RecalculateAfterModifiedContractEndDate(iids);
                }
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        private void __RunCalculateEnactiveEmployee(object param)
        {
            long[] ids = (long[])param;
            EmployeeBusinessObject.RecalculateAfterModifiedContractEndDate(ids);

        }

        #region experemental code

        [AccessType(AccessType.Read)]
        public AbsencePlanningQuery GetAllAbsencePlanning(long storeID, long countryID, int year, DateTime today)
        {

            int TodayYear = DateTimeHelper.GetYearByDate(DateTime.Today);

            bool isAustria = countryID == _countryService.AustriaCountryID;

            DateTime begin, end;
            begin = DateTimeHelper.GetBeginYearDate(year);
            end = DateTimeHelper.GetEndYearDate(year);


            DateTime dateToday = DateTime.Today;

            AbsencePlanningQuery result = new AbsencePlanningQuery();
            List<long> employee_ids = new List<long>();

            result.Year = year;
            result.StoreID = storeID;

            // need remove - once per country need load
            result.Absences = _absenceService.GetCountryAbsences(countryID);

            result.AvgDaysPerWeek = _countryService.AvgWorkingDaysInWeekService
                .GetAvgWorkingDaysInWeek(countryID, year);
            result.StoreDays = _storeService.GetStoreDays(storeID, begin, end);

            result.LongabsencesEntities = _employeeService.LongTimeAbsenceService.FindAllByCountry(countryID);


            EmployeeService service = _employeeService as EmployeeService;
            List<Employee> employees = service.EmployeeDao.GetStoreEmployeesHaveContracts(storeID, begin, end);
            long[] ids_employee = null;
            if (employees != null && employees.Count > 0)
            {
                foreach (Employee empl in employees)
                    employee_ids.Add(empl.ID);
                ids_employee = employee_ids.ToArray();


                EmployeeContractService contract_service = ServerEnvironment.EmployeeContractService as EmployeeContractService;
                result.Contracts = contract_service.GetEmployeeContractsByStore(storeID, begin, end);


                EmployeeRelationService relation_service = _employeeService.EmployeeRelationService as EmployeeRelationService;
                result.Relations = relation_service.GetEmployeeRelationByMainStore(storeID, begin, end);

                result.Longabsences = _employeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(storeID, begin, end);


                //Debug.Assert(result.Contracts != null && result.Contracts.Count >= employees.Count);
                //Debug.Assert(result.Relations != null && result.Relations.Count >= employees.Count);

                if (dateToday < begin)
                {
                    result.Plannings = _absenceTimePlanningService
                        .GetAbsenceTimePlanningsByEmployeeIds(ids_employee, begin, end);
                }
                else if (dateToday > end)
                {
                    result.Recordings = _absenceTimeRecordingService
                        .GetAbsenceTimeRecordingsByEmployeeIds(ids_employee, begin, end);
                }
                else
                {
                    result.Plannings = _absenceTimePlanningService
                        .GetAbsenceTimePlanningsByEmployeeIds(ids_employee, dateToday, end);
                    result.Recordings = _absenceTimeRecordingService
                        .GetAbsenceTimeRecordingsByEmployeeIds(ids_employee, begin, dateToday.AddDays(-1));
                }


                List<EmployeeHolidaysInfo> holidays = ExEmployeeHolidays.GetAllByStore(storeID, year);

                Dictionary<long, EmployeeHolidaysInfo> hash = new Dictionary<long, EmployeeHolidaysInfo>();

                hash = EmployeeHolidaysInfo.BuildDiction(holidays);

                BzEmployeeHoliday bz_entity = null;
                EmployeeHolidaysInfo entity = null;
                foreach (Employee empl in employees)
                {
                    if (result._holidays == null)
                        result._holidays = new List<BzEmployeeHoliday>();
                    if (!hash.TryGetValue(empl.ID, out entity))
                    {
                        entity = new EmployeeHolidaysInfo((short)year, 0, 0, 0, empl.ID);
                    }
                    bz_entity = new BzEmployeeHoliday(entity, empl.FullName, empl.MainStoreID, empl.OrderHwgrID);
                    bz_entity.IsAustria = isAustria;
                    if (isAustria && year == TodayYear)
                        bz_entity.AvailableHolidays = Convert.ToDouble(empl.AvailableHolidays);

                    result._holidays.Add(bz_entity);
                }


            }


            return result;
        }



        [Transaction]
        [AccessType(AccessType.Write)]
        public void RecalculateHolidaysInfo(int year, long storeID, DateTime today)
        {
            throw new NotSupportedException();

            //List<WeekSource> weeks = WeekManager.GetYearMap(year);
            //DateTime begin = weeks[0].Monday, end = weeks[weeks.Count-1].Sunday;

            //List<EmployeeContract> contracts = _employeeService.GetEmployeeContracts(storeID, begin, end);
            //List<long> ids = new List<long>();

            //if(contracts != null)
            //foreach (EmployeeContract cntr in contracts)
            //    if (!ids.Contains(cntr.EmployeeID))
            //        ids.Add(cntr.EmployeeID);

            //List<EmployeeHolidaysInfo> lasts = _employeeHolidaysInfoService.GetByEmployeesYear(ids, year);
            //List<EmployeeHolidaysInfo> nexts = _employeeHolidaysInfoService.GetByEmployeesYear(ids, year+1);
            //List<EmployeeHolidaysInfo> tosave = new List<EmployeeHolidaysInfo>();

            //if (nexts != null)
            //    _employeeHolidaysInfoService.DeleteList(nexts);

            //if (lasts != null)
            //{
            //    Dictionary<long, EmlpoyeeHolidaysSumDays> holydSum = EmlpoyeeHolidaysSumDays.BuildDiction (
            //        (_storeService as StoreService).EmlpoyeeHolidaysSumInfoGet(storeID, begin, end, today.Year == year ? today : begin.AddDays(1)));

            //        //GetHolidaysSum(storeID, begin, end, today.Year == year ? today : begin.AddDays(1));

            //    if (holydSum != null)
            //    foreach (EmployeeHolidaysInfo hol in lasts)
            //    {
            //        decimal usedDays = holydSum[hol.EmployeeID].TimePlanning + holydSum[hol.EmployeeID].TimeRecording;
            //        decimal spare = hol.NewHolidays + hol.OldHolidays - usedDays;
            //        if (holydSum[hol.EmployeeID].TimePlanning!=0)
            //        {
            //            EmlpoyeeHolidaysSumDays s = holydSum[hol.EmployeeID];
            //            s.ToString();
            //        }

            //        tosave.Add(new EmployeeHolidaysInfo((short)(year + 1), spare, 0, 0/*usedDays*/, hol.EmployeeID));
            //    }

            //    _employeeHolidaysInfoService.SaveList(tosave);
            //}
        }


        [AccessType(AccessType.Write)]
        [Transaction]
        public AbsencePlanningResponse SaveAbsencePlanning(AbsencePlanningResponse response)
        {
            // diction id of empluyees which absences or holidays number changed
            Dictionary<long, object> d_ids = new Dictionary<long, object>();

            if (response.DeletedIds != null)
            {

                List<long> ids = new List<long>(response.DeletedIds);

                List<AbsenceTimePlanning> listAbsences = AbsenceTimePlanningService.FindByIDList(ids);
                if (listAbsences != null)
                {
                    foreach (AbsenceTimePlanning a in listAbsences)
                        d_ids[a.EmployeeID] = a;
                }

                AbsenceTimePlanningService.DeleteList(listAbsences);// DeleteListByID(ids);

            }

            if (response.ModifiedEntity != null)
            {
                List<EmployeeHolidaysInfo> lst = new List<EmployeeHolidaysInfo>(response.ModifiedEntity);
                EmployeeHolidaysInfoService.SaveOrUpdateList(lst);

                foreach (EmployeeHolidaysInfo o in lst)
                    d_ids[o.EmployeeID] = o;
            }

            if (response.NewAbsences != null)
            {
                foreach (AbsenceTimeRange a in response.NewAbsences)
                {

                    Debug.Assert(a.EmployeeID > 0);
                    Debug.Assert(a.AbsenceID > 0);
                    Debug.Assert(a.ID <= 0);

                    d_ids[a.EmployeeID] = a;

                    ClearEmployeePlanningTime(a.EmployeeID, a.Date, a.Date);
                    AbsenceTimePlanning entity = new AbsenceTimePlanning(a.Begin, a.End, a.Time, a.AbsenceID, a.EmployeeID);
                    entity.ID = 0;
                    entity.Date = a.Date;
                    AbsenceTimePlanningService.SaveOrUpdate(entity);
                    a.ID = entity.ID;

                }
            }


            if (d_ids.Count > 0)
            {
                long[] ids = new long[d_ids.Count];
                d_ids.Keys.CopyTo(ids, 0);
                ExEmployeeHolidays.CalculateAndUpdate(ids, response.Year);
            }
            return response;
        }
        [AccessType (AccessType.Read )]
        public DateTime GetMaxDateOfPlanningOrRecording(long emplid)
        {
            return _EmployeeTimeDao.GetMaxDateOfPlanningOrRecording(emplid);
        }
        #endregion
    }
}
