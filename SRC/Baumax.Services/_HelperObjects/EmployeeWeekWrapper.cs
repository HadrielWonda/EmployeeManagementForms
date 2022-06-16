using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.AppServer.Environment;
using System.Collections;

namespace Baumax.Services._HelperObjects
{
    //public class EmployeeWeekWrapper
    //{
    //    private EmployeeWeek _week;
    //    private EmployeeWeek _actualweek;
    //    private EmployeeWeekWrapper _prevWeek;
    //    private EmployeeWeekWrapper _nextWeek;
    //    IWorkingModelManager _wmmanager;
    //    EmployeeTimeService _timeservice;

    //    public EmployeeWeek EmployeeWeek
    //    {
    //        get { return _week; }
    //        set { _week = value; }
    //    }
    //    public EmployeeWeek ActualEmployeeWeek
    //    {
    //        get { return _actualweek; }
    //        set { _actualweek = value; }
    //    }
    //    public EmployeeWeekWrapper PrevWeek
    //    {
    //        get { return _prevWeek; }
    //        set { _prevWeek = value; }
    //    }

    //    public EmployeeWeekWrapper NextWeek
    //    {
    //        get { return _nextWeek; }
    //        set { _nextWeek = value; }
    //    }

    //    public DateTime WeekDate
    //    {
    //        get
    //        {
    //            if (_week != null)
    //                return _week.BeginDate;
    //            if (_actualweek != null)
    //                return _actualweek.BeginDate;

    //            throw new ArgumentException();
    //        }
    //    }

    //    public EmployeeWeekWrapper(EmployeeWeek week, EmployeeWeek actweek, EmployeeWeekWrapper prevweek, EmployeeWeekWrapper nextWeek,
    //        IWorkingModelManager wmmanager, EmployeeTimeService service)
    //    {
    //        if (service == null)
    //            throw new ArgumentNullException();
    //        if (wmmanager == null)
    //            throw new ArgumentNullException();

    //        _week = week;
    //        _actualweek = actweek;
    //        _prevWeek = prevweek;
    //        _nextWeek = nextWeek;
    //        _wmmanager = wmmanager;
    //        _timeservice = service;
    //    }


    //    public void AddWeek(EmployeeWeekWrapper week)
    //    {
    //        if (WeekDate < week.WeekDate)
    //        {
    //            if (NextWeek != null)
    //                NextWeek.AddWeek(week);
    //            else
    //            {
    //                week.PrevWeek = this;
    //                NextWeek = week;
    //            }
    //        }
    //        else if (WeekDate > week.WeekDate)
    //        {
    //            if (PrevWeek != null)
    //                PrevWeek.AddWeek(week);
    //            else
    //            {
    //                week.NextWeek = this;
    //                PrevWeek = week;
    //            }
    //        }
    //        else throw new ArgumentException();
    //    }


    //    public void AddPlanningWeek(EmployeeWeek week)
    //    {
    //        if (WeekDate < week.BeginDate)
    //        {
    //            if (NextWeek != null)
    //                NextWeek.AddPlanningWeek(week);
    //            else
    //            {
    //                EmployeeWeekWrapper wrap = new EmployeeWeekWrapper(week, null, this, null, _wmmanager, _timeservice);
    //                NextWeek = wrap;
    //            }
    //        }
    //        else if (WeekDate > week.BeginDate)
    //        {
    //            if (PrevWeek != null)
    //                PrevWeek.AddPlanningWeek(week);
    //            else
    //            {
    //                EmployeeWeekWrapper wrap = new EmployeeWeekWrapper(week, null, null,this, _wmmanager, _timeservice);
    //                PrevWeek = wrap;
    //            }
    //        }
    //        else
    //            _week = week;
    //            //throw new ArgumentException();
    //    }
    //    public void AddRecordingWeek(EmployeeWeek week)
    //    {
    //        if (WeekDate < week.BeginDate)
    //        {
    //            if (NextWeek != null)
    //                NextWeek.AddRecordingWeek(week);
    //            else
    //            {
    //                EmployeeWeekWrapper wrap = new EmployeeWeekWrapper(null, week, this, null, _wmmanager, _timeservice);
    //                NextWeek = wrap;
    //            }
    //        }
    //        else if (WeekDate > week.BeginDate)
    //        {
    //            if (PrevWeek != null)
    //                PrevWeek.AddRecordingWeek(week);
    //            else
    //            {
    //                EmployeeWeekWrapper wrap = new EmployeeWeekWrapper(null,week,  null, this, _wmmanager, _timeservice);
    //                PrevWeek = wrap;
    //            }
    //        }
    //        else
    //            _actualweek = week;
    //        //throw new ArgumentException();
    //    }


    //    public void Process(int saldo, int monthsum, int countsunday, int countsaturday)
    //    {

    //        if (_week != null)
    //        {
    //            _week.LastSaldo = saldo;
    //            _week.CountSunday = (byte)countsunday;
    //            _week.CountSaturday = (byte)countsaturday;
    //            _week.WorkingTimeByMonth = monthsum;

    //            _wmmanager.CalculateNew(_week, true);
    //        }

    //        if (_actualweek != null)
    //        {
    //            _actualweek.LastSaldo = saldo;
    //            _actualweek.CountSunday = (byte)countsunday;
    //            _actualweek.CountSaturday = (byte)countsaturday;
    //            _actualweek.WorkingTimeByMonth = monthsum;

    //            _wmmanager.CalculateNew(_actualweek, false);
    //        }

    //        int currentsaldo = 0;
    //        int sundays = GetSundayCount();
    //        int saturdays = GetSaturdayCount();
    //        int currentmonthsum = GetMonthSum();


    //        if (_nextWeek != null)
    //            _nextWeek.Process(currentsaldo, currentmonthsum, sundays, saturdays);
    //    }


    //    private int GetSundayCount()
    //    {
    //        if (_actualweek != null)
    //            return EmployeeWeekProcessor.BuildCountSundayForNextWeek (_actualweek );
    //        else
    //            return EmployeeWeekProcessor.BuildCountSundayForNextWeek(_week);
    //    }
    //    private int GetSaturdayCount()
    //    {
    //        if (_actualweek != null)
    //            return EmployeeWeekProcessor.BuildCountSaturdayForNextWeek(_actualweek);
    //        else
    //            return EmployeeWeekProcessor.BuildCountSaturdayForNextWeek(_week);
    //    }
    //    private int GetMonthSum()
    //    {
    //        if (_actualweek != null)
    //            return EmployeeWeekProcessor.BuildMonthSumForNextWeek(_actualweek);
    //        else
    //            return EmployeeWeekProcessor.BuildMonthSumForNextWeek(_week);
    //    }
    //}


    //public class _EmployeeWorkload
    //{
    //    private AbsenceManager _absencemanager;

    //    public AbsenceManager AbsenceManager
    //    {
    //        get { return _absencemanager; }
    //        set { _absencemanager = value; }
    //    }
    //    private WorkingModelManagerNew _wmmanager;

    //    public WorkingModelManagerNew WMManager
    //    {
    //        get { return _wmmanager; }
    //        set { _wmmanager = value; }
    //    }
    //    private CountryStoreDaysManager  _storedays;

    //    public CountryStoreDaysManager  StoreDays
    //    {
    //        get { return _storedays; }
    //        set { _storedays = value; }
    //    }
    //    private CacheEmployeesAllIn _all_in_manager;

    //    public CacheEmployeesAllIn AllInManager
    //    {
    //        get { return _all_in_manager; }
    //        set { _all_in_manager = value; }
    //    }


    //    private DictionListEmployeesContract _contracts_manager;

    //    public DictionListEmployeesContract ContractsManager
    //    {
    //        get { return _contracts_manager; }
    //        set { _contracts_manager = value; }
    //    }
    //    private DictionListEmployeeRelations _relations_manager;

    //    public DictionListEmployeeRelations RelationsManager
    //    {
    //        get { return _relations_manager; }
    //        set { _relations_manager = value; }
    //    }

    //    CountryStoreWorldManager _swCountryManager = null;

    //    public CountryStoreWorldManager CountrySWmanager
    //    {
    //        get { return _swCountryManager; }
    //        set { _swCountryManager = value; }
    //    }
    //    private long _employeeid;

    //    public long EmployeeId
    //    {
    //        get { return _employeeid; }
    //        set { _employeeid = value; }
    //    }

    //}


    //public class EmployeeWorkload : _EmployeeWorkload
    //{
    //    Dictionary<DateTime, EmployeeWeekTimePlanning> _planningweek = new Dictionary<DateTime, EmployeeWeekTimePlanning>();
    //    Dictionary<DateTime, EmployeeWeekTimeRecording> _recordingweek = new Dictionary<DateTime, EmployeeWeekTimeRecording>();

    //    Dictionary<DateTime, EmployeeDayStateRecording> _recordingdays = new Dictionary<DateTime, EmployeeDayStateRecording>();
    //    Dictionary<DateTime, EmployeeDayStatePlanning> _planningdays = new Dictionary<DateTime, EmployeeDayStatePlanning>();

    //    Dictionary<DateTime, EmployeeWeek> _viewweek = new Dictionary<DateTime, EmployeeWeek>();

    //    List<AbsenceTimePlanning> _absenceplanningtimes = new List<AbsenceTimePlanning>();
    //    List<AbsenceTimeRecording> _absencerecordingtimes = new List<AbsenceTimeRecording>();

    //    List<WorkingTimePlanning> _workingplanningtimes = new List<WorkingTimePlanning>();
    //    List<WorkingTimeRecording> _workingrecordingtimes = new List<WorkingTimeRecording>();

    //    EmployeeWeek _currentWeek = null;

    //    DateTime _fromDate = DateTime.Today;
    //    DateTime _toDate = DateTimeSql.SmallDatetimeMin;

    //    public DateTime ToDate
    //    {
    //        get { return _toDate; }

    //        set
    //        {
    //            if (_toDate < value)
    //                _toDate = value;
    //        }
    //    }

    //    public DateTime FromDate
    //    {
    //        get { return _fromDate; }

    //        set
    //        {
    //            _fromDate = value;
    //        }
    //    }

    //    private void LoadWeeks()
    //    {
    //        DateTime date = new DateTime(FromDate.Year, FromDate.Month, 1);
    //        date = DateTimeHelper.GetMonday(date);
    //        EmployeeWeekTimePlanningService weektime_planning = ServerEnvironment.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService;

    //        IList lst = weektime_planning.GetEmployeeWeekStatesFrom(EmployeeId, date);

    //        if (lst != null)
    //        {
    //            foreach (EmployeeWeekTimePlanning entity in lst)
    //            {
    //                ToDate = entity.WeekEnd;
    //                _planningweek[entity.WeekBegin] = entity;
    //            }
    //        }


    //        EmployeeWeekTimeRecordingService weektime_recording = ServerEnvironment.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;

    //        lst = weektime_recording.GetEmployeesWeekStatesFrom(EmployeeId, date);
    //        if (lst != null)
    //        {
    //            foreach (EmployeeWeekTimeRecording entity in lst)
    //            {
    //                ToDate = entity.WeekEnd;
    //                _recordingweek[entity.WeekBegin] = entity;
    //            }
    //        }
    //    }


    //    private void LoadDays()
    //    {
    //        DateTime date = new DateTime(FromDate.Year, FromDate.Month, 1);
    //        EmployeeDayStateRecordingService day_service_record = ServerEnvironment.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService;

    //        IList lst = day_service_record.GetEmployeeStates(EmployeeId, date, DateTimeSql.SmallDatetimeMax);
    //        if (lst != null)
    //        {
    //            foreach (EmployeeDayStateRecording entity in lst)
    //            {
    //                _recordingdays[entity.Date] = entity;
    //            }
    //        }


    //        EmployeeDayStatePlanningService day_service_plan = ServerEnvironment.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService;

    //        lst = day_service_plan.GetEmployeeStates(EmployeeId, date, DateTimeSql.SmallDatetimeMax);
    //        if (lst != null)
    //        {
    //            foreach (EmployeeDayStatePlanning entity in lst)
    //            {
    //                _planningdays[entity.Date] = entity;
    //            }
    //        }
    //    }


    //    private void LoadTimes()
    //    {
    //        AbsenceTimePlanningService absence_plan_service = ServerEnvironment.AbsenceTimePlanningService as AbsenceTimePlanningService;
    //        AbsenceTimeRecordingService absence_record_service = ServerEnvironment.AbsenceTimeRecordingService as AbsenceTimeRecordingService;
    //        _absenceplanningtimes = absence_plan_service.GetAbsenceTimePlanningsByEmployeeId(EmployeeId, FromDate, ToDate);
    //        _absencerecordingtimes = absence_record_service.GetAbsenceTimeRecordingsByEmployeeId(EmployeeId, FromDate, ToDate);


    //        WorkingTimePlanningService work_plan_service = ServerEnvironment.WorkingTimePlanningService as WorkingTimePlanningService;
    //        WorkingTimeRecordingService work_record_service = ServerEnvironment.WorkingTimeRecordingService as WorkingTimeRecordingService;

    //        _workingplanningtimes = work_plan_service.GetWorkingTimeByEmployeeId(EmployeeId, FromDate, ToDate);
    //        _workingrecordingtimes = work_record_service.GetWorkingTimeByEmployeeId(EmployeeId, FromDate, ToDate);

    //    }

    //    private void LoadRelationAndContractAndAllIn()
    //    {
    //        ContractsManager = new DictionListEmployeesContract(ServerEnvironment.EmployeeContractService.GetEmployeeContracts(EmployeeId));

    //        RelationsManager = new DictionListEmployeeRelations(ServerEnvironment.EmployeeRelationService.GetEmployeeRelations(EmployeeId));

    //        AllInManager = new CacheEmployeesAllIn();
    //        AllInManager.LoadByEmployee(EmployeeId);
    //    }

    //    private void InitCountryData()
    //    {
    //        Employee empl = null;
    //        if (AbsenceManager == null || WMManager == null || StoreDays==null || CountrySWmanager == null)
    //        {
    //            empl = ServerEnvironment.EmployeeService.FindById(EmployeeId);
    //            long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(empl.MainStoreID);


    //            if (StoreDays == null)
    //                StoreDays = new CountryStoreDaysManager(ServerEnvironment.StoreService as StoreService, countryid, FromDate);
    //            StoreDays.LoadStoreInfo (empl.MainStoreID );

    //            if (AbsenceManager == null)
    //            {
    //                AbsenceManager = new AbsenceManager(ServerEnvironment.AbsenceService);
    //                AbsenceManager.CountryId = countryid;
    //            }
    //            if (WMManager == null)
    //            {
    //                WMManager = new WorkingModelManagerNew(ServerEnvironment.WorkingModelService);
    //                WMManager.CountryId = countryid;
    //            }
    //            if (CountrySWmanager == null)
    //            {
    //                CountrySWmanager = new CountryStoreWorldManager(ServerEnvironment.StoreToWorldService);
    //            }
    //        }
    //    }


    //    private void BuildViewWeek()
    //    {
    //        DateTime date = FromDate ;
    //        EmployeeLongTimeAbsenceIndexer absenceIndexer = 
    //            new EmployeeLongTimeAbsenceIndexer(ServerEnvironment.EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence (new long[] {EmployeeId}, FromDate, ToDate));
    //        while (date < ToDate)
    //        {

    //            Employee empl = ServerEnvironment.EmployeeService.FindById(EmployeeId);
    //            long orderHWGR = 0;
    //            if(empl != null)
    //            {
    //                orderHWGR = empl.OrderHwgrID.HasValue ? empl.OrderHwgrID.Value : 0;
    //            }
    //            EmployeeWeek week = new EmployeeWeek(EmployeeId, null, date, date.AddDays(6), orderHWGR);
    //            EmployeeRelation relationWorld;
    //            foreach (EmployeeDay d in week.DaysList)
    //            {
    //                relationWorld = RelationsManager.GetRelationEntity(week.EmployeeId, d.Date);
    //                if (relationWorld != null)
    //                {
    //                    d.StoreWorldId = CountrySWmanager.GetStoreWorldIdByStoreAndWorldId(relationWorld.StoreID, relationWorld.WorldID.Value);
    //                    d.StoreId = relationWorld.StoreID;

    //                    d.StoreDay = StoreDays.GetDayInfo(d.StoreId, d.Date);
    //                }
    //            }
    //            ContractsManager.FillEmployeeWeek(week);
    //            week.AllIn = AllInManager.GetAllIn(week.EmployeeId, week.BeginDate, week.EndDate);
    //            absenceIndexer.FillEmployeeWeek(week);

    //            week.InitWeekState();


    //            _viewweek[week.BeginDate] = week;
    //            EmployeeWeekTimeRecording record_week;
    //            if (_recordingweek.TryGetValue(week.BeginDate, out record_week))
    //            {
    //                week.CustomEdit = record_week.CustomEdit;
    //            }

    //            date = date.AddDays(7);
    //        }
    //    }

    //    private void FillWeekByMonthHoursAndCountWeekEnds(EmployeeWeek week)
    //    {
    //        DateTime date = new DateTime(week.BeginDate.Year, week.BeginDate.Month, 1);
    //        date = DateTimeHelper.GetMonday(date);

    //        int monthSum = 0;

    //        if (!week.PlannedWeek)
    //        {
    //            date = new DateTime(week.BeginDate.Year, week.BeginDate.Month, 1);
    //            EmployeeDayStateRecording day =null;
    //            while (date < week.BeginDate)
    //            {
    //                if (_recordingdays.TryGetValue(date, out day))
    //                {
    //                    week.WorkingTimeByMonth += day.AllreadyPlannedHours;

    //                    if (day.Date.DayOfWeek == DayOfWeek.Saturday)
    //                        week.CountSaturday += (byte)1;
    //                    if (day.Date.DayOfWeek == DayOfWeek.Sunday)
    //                        week.CountSunday += (byte)1;

    //                }
    //                date = date.AddDays(1);
    //            }
    //            return;
    //        }

    //        while (date < week.BeginDate)
    //        {
    //            if (_recordingweek.ContainsKey(date))
    //            {
    //                EmployeeDayStateRecording day =null;
    //                DateTime d = date;
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    d = date.AddDays(i); 
    //                    if (d.Month == week.BeginDate.Month && _recordingdays.TryGetValue(date.AddDays(i), out day))
    //                    {
    //                        week.WorkingTimeByMonth += day.AllreadyPlannedHours;
    //                        if (day.Date.DayOfWeek == DayOfWeek.Saturday)
    //                            week.CountSaturday += (byte)1;
    //                        if (day.Date.DayOfWeek == DayOfWeek.Sunday)
    //                            week.CountSunday += (byte)1;
    //                    }
                        
    //                }
    //            }
    //            else
    //            {
    //                EmployeeDayStatePlanning day = null;
    //                DateTime d = date;
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    d = date.AddDays(i);
    //                    if (d.Month == week.BeginDate.Month && _planningdays.TryGetValue(date.AddDays(i), out day))
    //                    {
    //                        week.WorkingTimeByMonth += day.AllreadyPlannedHours;
    //                        if (day.Date.DayOfWeek == DayOfWeek.Saturday)
    //                            week.CountSaturday += (byte)1;
    //                        if (day.Date.DayOfWeek == DayOfWeek.Sunday)
    //                            week.CountSunday += (byte)1;
    //                    }

    //                }
    //            }
    //            date = date.AddDays(7);
    //        }

    //    }

    //    private void Calculate()
    //    {
    //        EmployeeWeek week = _viewweek[FromDate];
    //        DateTime date = FromDate ;
    //        while (date < ToDate)
    //        {
    //            if (_recordingweek.ContainsKey(date))
    //            {
    //                week.PlannedWeek = false;
    //                week.NewWeek = false;
    //                FillWeekByMonthHoursAndCountWeekEnds(week);

    //                if (_absencerecordingtimes != null)
    //                {
    //                    foreach (AbsenceTimeRecording absence_time in _absencerecordingtimes)
    //                    {
    //                        if (week.BeginDate <= absence_time.Date && absence_time.Date <= week.EndDate)
    //                        {
    //                            EmployeeDay day = week.GetDay (absence_time.Date);
    //                            if (day.TimeList == null)
    //                                day.TimeList = new List<EmployeeTimeRange> ();
    //                            day.TimeList.Add(new EmployeeTimeRange(absence_time));
    //                        }
    //                    }
    //                }
    //                if (_workingrecordingtimes != null)
    //                {
    //                    foreach (WorkingTimeRecording work_time in _workingrecordingtimes)
    //                    {
    //                        if (week.BeginDate <= work_time.Date && work_time.Date <= week.EndDate)
    //                        {
    //                            EmployeeDay day = week.GetDay(work_time.Date);
    //                            if (day.TimeList == null)
    //                                day.TimeList = new List<EmployeeTimeRange>();
    //                            day.TimeList.Add(new EmployeeTimeRange(work_time));
    //                        }
    //                    }
    //                }


    //                WMManager.CalculateNew(week, false);

    //                UpdateRecordingWeek(week);
    //            }
    //        }

    //    }

    //    private void UpdateRecordingWeek(EmployeeWeek week)
    //    {
    //        EmployeeWeekTimeRecording rec_week  = _recordingweek[week.BeginDate ];
            
    //        if (!EmployeeWeekProcessor.IsModified (rec_week, week))
    //        {
    //            EmployeeWeekProcessor.AssignTo(rec_week, week);
    //            ServerEnvironment.EmployeeWeekTimeRecordingService.SaveOrUpdate(rec_week);
    //        }
    //        EmployeeDayStateRecording rec_day;
    //        foreach (EmployeeDay day in week.DaysList)
    //        {
    //            if (_recordingdays.TryGetValue(day.Date, out rec_day))
    //            {
    //                if (EmployeeDayProcessor.IsNeedSave(day))
    //                {
    //                    if (!EmployeeDayProcessor.IsEqual(rec_day, day))
    //                    {
    //                        EmployeeDayProcessor.AssignToRecording(rec_day, day);
    //                        ServerEnvironment.EmployeeDayStateRecordingService.SaveOrUpdate(rec_day);
    //                    }
    //                }
    //                else
    //                {
    //                    ServerEnvironment.EmployeeDayStateRecordingService.DeleteByID(rec_day.ID);
    //                    _recordingdays.Remove(rec_day.Date);
    //                }
    //            }
    //            else
    //                if (EmployeeDayProcessor.IsNeedSave(day))
    //                {
    //                    rec_day = new EmployeeDayStateRecording();
    //                    EmployeeDayProcessor.AssignToRecording(rec_day, day);
    //                    ServerEnvironment.EmployeeDayStateRecordingService.SaveOrUpdate(rec_day);
    //                    _recordingdays[rec_day.Date] = rec_day;

    //                }
    //        }

    //        //(ServerEnvironment.WorkingTimeRecordingService as WorkingTimeRecordingService).
    //    }
    //    public void RebuildFrom(long emplid, DateTime monday)
    //    {
    //        EmployeeId = emplid;
    //        ToDate = monday;
    //        FromDate = monday;
    //        LoadWeeks();

    //        int iCount = (_planningweek != null) ? _planningweek.Count : 0;
    //        iCount += (_recordingweek != null) ? _recordingweek.Count : 0;

    //        if (iCount == 0) return;

    //        LoadDays();

    //        LoadTimes();


    //        LoadRelationAndContractAndAllIn();

    //        InitCountryData();

    //        BuildViewWeek();

    //        Calculate();
            
    //    }
    //}
}
