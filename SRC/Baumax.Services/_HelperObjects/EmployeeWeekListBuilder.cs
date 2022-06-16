using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Contract;

namespace Baumax.Services._HelperObjects
{
    //public class EmployeeWeekListBuilder
    //{
    //    private EmployeeTimeService _service = null;
    //    private EmployeeService _employeeservice = null;
    //    private StoreService _storeservice = null;
    //    private CountryService _countryservice = null;

    //    private EmployeesRelationIndexer _relationindexer = null;
    //    private DictionListEmployeesContract _contractindexer = null;
    //    private EmployeeLongTimeAbsenceIndexer _longabsenceindexer = null;

    //    private List<EmployeeWeek> _planningweeks = null;
    //    private List<EmployeeWeek> _recordingweeks = null;
    //    private Employee _employee = null;
    //    private DateTime _mondayDate = DateTime.Today;
    //    CountryStoreWorldManager swCountryManager = null;
    //    CountryStoreDaysManager storedayManager = null;

    //    AbsenceManager _absencemanager;

    //    EmployeeWeekWrapper _head = null;
    //    WorkingModelManagerNew _wmmanager = null;
    //    public EmployeeWeekListBuilder(EmployeeTimeService service)
    //    {
    //        _service = service;

    //        _employeeservice = _service.EmployeeService as EmployeeService;

    //        _storeservice = _employeeservice.StoreService as StoreService;

    //        _countryservice = _storeservice.CountryService as CountryService;
            
    //    }

    //    private void AddPlanningWeek(EmployeeWeek week)
    //    {
    //        if (_head == null)
    //        {
    //            _head = new EmployeeWeekWrapper(week, null, null, null, _wmmanager, _service);
    //            return;
    //        }

    //        _head.AddPlanningWeek(week);

    //        if (_head.PrevWeek != null)
    //            _head = _head.PrevWeek;
    //    }

    //    private void AddRecordingWeek(EmployeeWeek week)
    //    {
    //        if (_head == null)
    //        {
    //            _head = new EmployeeWeekWrapper(null,week,  null, null, _wmmanager, _service);
    //            return;
    //        }

    //        _head.AddRecordingWeek(week);

    //        if (_head.PrevWeek != null)
    //            _head = _head.PrevWeek;
    //    }


    //    public void Process(long emplid, DateTime date)
    //    {
    //        _planningweeks = new List<EmployeeWeek> ();
    //        _recordingweeks = new List<EmployeeWeek>();

    //        _mondayDate = DateTimeHelper.GetMonday(date);

    //        _employee = _service.EmployeeService.FindById(emplid);

    //        if (_employee == null)
            
    //            throw new ArgumentException();


    //        EmployeeWeek newentity;

    //        List<EmployeeWeekTimePlanning> lstPlanning =
    //            (_service.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService).GetEmployeesWeekStateByDateRange(new long[] { emplid }, _mondayDate, DateTimeSql.LastMaxSunday);

    //        if (lstPlanning != null && lstPlanning.Count > 0)
    //        {
    //            foreach (EmployeeWeekTimePlanning entity in lstPlanning)
    //            {
    //                newentity = new EmployeeWeek(entity);
    //                _planningweeks.Add(newentity);
    //                AddPlanningWeek(newentity);
    //            }


    //        }

    //        List<EmployeeWeekTimeRecording> lstRecording =
    //            (_service.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService).GetEmployeesWeekStateByDateRange(new long[] { emplid }, _mondayDate, DateTimeSql.LastMaxSunday);


    //        if (lstRecording != null && lstRecording.Count > 0)
    //        {
    //            foreach (EmployeeWeekTimeRecording entity in lstRecording)
    //            {
    //                newentity = new EmployeeWeek(entity);
    //                newentity.PlannedWeek = false;
    //                _recordingweeks.Add(newentity);
    //                AddRecordingWeek(newentity);
    //            }

    //        }



    //        if (_relationindexer == null)
    //            _relationindexer = new EmployeesRelationIndexer(_employeeservice.EmployeeRelationService, _mondayDate);

    //        List<EmployeeContract> contracts = _service.EmployeeService.EmployeeContractService.GetEmployeeContracts(new long[] { emplid }, _mondayDate, DateTimeSql.LastMaxSunday);
    //        _contractindexer = new DictionListEmployeesContract(contracts);


    //        List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
    //            _service.EmployeeService.EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(new long[] { emplid }, _mondayDate, DateTimeSql.LastMaxSunday);
    //        _longabsenceindexer = new EmployeeLongTimeAbsenceIndexer(emplLongTimeAbsences);




    //        if (swCountryManager == null )
    //        {
    //            long countryid = _storeservice.GetCountryByStoreId(_employee.MainStoreID);
    //            swCountryManager = new CountryStoreWorldManager(_employeeservice.StoreWorldService );
    //            swCountryManager.CountryId = countryid;
                 
    //            storedayManager = new CountryStoreDaysManager(_storeservice, countryid, _mondayDate);

    //            StoreService storeservice = (_service.EmployeeService as EmployeeService ).StoreService as StoreService ;

    //            _absencemanager = new AbsenceManager(_countryservice.AbsenceService);
    //            _absencemanager.CountryId = countryid;

    //            _wmmanager = new WorkingModelManagerNew(_countryservice.WorkingModelService);
    //            _wmmanager.CountryId = countryid;
    //        }

            

    //        if (lstPlanning != null && lstPlanning.Count > 0)
    //        {
    //            DateTime maxPlanningDate = lstPlanning[lstPlanning.Count - 1].WeekEnd;

    //            List<WorkingTimePlanning> lstWorkTime = _service.WorkingTimePlanningService.GetWorkingTimePlanningsByEmployeeIds(new long[] { emplid }, _mondayDate, maxPlanningDate);
    //            List<AbsenceTimePlanning> lstAbsenceTime = _service.AbsenceTimePlanningService.GetAbsenceTimePlanningsByEmployeeIds(new long[] { emplid }, _mondayDate, maxPlanningDate);
    //            _absencemanager.FillAbsencePlanningTimes(lstAbsenceTime);
    //            EmployeeTimeRangeHelper.FillEmployeeWeeks(_planningweeks, lstWorkTime, lstAbsenceTime);
    //        }

    //        if (lstRecording != null && lstRecording.Count > 0)
    //        {
    //            DateTime maxPlanningDate = lstRecording[lstRecording.Count - 1].WeekEnd;

    //            List<WorkingTimeRecording> lstWorkTime = _service.WorkingTimeRecordingService.GetWorkingTimeRecordingsByEmployeeIds (new long[] { emplid }, _mondayDate, maxPlanningDate);
    //            List<AbsenceTimeRecording> lstAbsenceTime = _service.AbsenceTimeRecordingService.GetAbsenceTimeRecordingsByEmployeeIds(new long[] { emplid }, _mondayDate, maxPlanningDate);
    //            _absencemanager.FillAbsenceRecordingTimes(lstAbsenceTime);
    //            EmployeeTimeRangeHelper.FillEmployeeWeeks(_recordingweeks, lstWorkTime, lstAbsenceTime);
    //        }

    //        foreach (EmployeeWeek week in _planningweeks)
    //        {
    //            foreach (EmployeeDay day in week.DaysList)
    //            {
    //                EmployeeRelation relation = _relationindexer.GetRelationEntity(day.EmployeeId, day.Date);
    //                if (relation != null)
    //                {
    //                    day.StoreWorldId = swCountryManager.GetStoreWorldIdByStoreAndWorldId(relation.StoreID, relation.WorldID.Value);
    //                    day.StoreId = relation.StoreID;

    //                    day.StoreDay = storedayManager.GetDayInfo(day.StoreId, day.Date);

    //                    EmployeeLongTimeAbsence absence = _longabsenceindexer.IsContain (day.EmployeeId, day.Date);
    //                    if (absence != null)
    //                        day.LongAbsenceId = absence.LongTimeAbsenceID;

    //                    EmployeeContract contract = _contractindexer.IsContain(day.EmployeeId, day.Date);

    //                    if (contract != null)
    //                    {
    //                        day.HasContract = true;

    //                        if (week.ContractHoursPerWeek == 0)
    //                            week.ContractHoursPerWeek = (int)(contract.ContractWorkingHours * 60);
    //                    }
    //                }
    //            }
    //        }
    //        foreach (EmployeeWeek week in _recordingweeks)
    //        {
    //            foreach (EmployeeDay day in week.DaysList)
    //            {
    //                EmployeeRelation relation = _relationindexer.GetRelationEntity(day.EmployeeId, day.Date);
    //                if (relation != null)
    //                {
    //                    day.StoreWorldId = swCountryManager.GetStoreWorldIdByStoreAndWorldId(relation.StoreID, relation.WorldID.Value);
    //                    day.StoreId = relation.StoreID;

    //                    day.StoreDay = storedayManager.GetDayInfo(day.StoreId, day.Date);

    //                    EmployeeLongTimeAbsence absence = _longabsenceindexer.IsContain(day.EmployeeId, day.Date);
    //                    if (absence != null)
    //                        day.LongAbsenceId = absence.LongTimeAbsenceID;

    //                    EmployeeContract contract = _contractindexer.IsContain(day.EmployeeId, day.Date);

    //                    if (contract != null)
    //                    {
    //                        day.HasContract = true;

    //                        if (week.ContractHoursPerWeek == 0)
    //                            week.ContractHoursPerWeek = (int)(contract.ContractWorkingHours * 60);
    //                    }
    //                }
    //            }
    //        }

    //        int? saldo = _service.GetEmployeeLastVerifiedSaldo(emplid, _mondayDate);

    //        if (!saldo.HasValue)
    //            saldo = (int)(_employee.BalanceHours);

    //        EmployeeMonthWorkingTime monthData = new EmployeeMonthWorkingTime(_service);
    //        monthData.CurrentMonday = _mondayDate;
    //        monthData.IsPlanning = true;

    //        int monthsum = monthData.GetMonthWorkingTime(emplid);

    //        int sundaycount = monthData.CountSunday;
    //        int saturdaycount = monthData.CountSaturday;

    //        if (_head != null)
    //            _head.Process(saldo.Value , monthsum, sundaycount, saturdaycount);

    //    }

    //}
}
