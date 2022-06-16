using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Services
{
    //public class ServerTimeContext : IRecordingContext
    //{
    //    private IStoreService _StoreService = null;
    //    private IEmployeeService _EmployeeService = null;
    //    private IWorkingTimePlanningService _WorkingTimePlanningService = null;
    //    private IAbsenceTimePlanningService _AbsenceTimePlanningService = null;

    //    private IWorkingTimeRecordingService _WorkingTimeRecordingService = null;
    //    private IAbsenceTimeRecordingService _AbsenceTimeRecordingService = null;

    //    private StoreDaysList m_storedays = null;
    //    private AbsenceManager m_countryabsences = null;
    //    private WorkingModelManagerNew m_workingmodelmanager = null;
    //    private LongTimeAbsenceManager m_longabsences = null;
    //    private CountryColorManager m_colormanager = null;

    //    private long _CountryId = 0;
    //    private long _StoreId = 0;
    //    private long _StoreWorldId = 0;
    //    private long _WorldId = 0;
    //    private bool _Modified = false;
    //    private DateTime _BeginWeekDate;
    //    private DateTime _EndWeekDate;
    //    private DateTime _ViewDate;

    //    private List<StoreToWorld> m_storeworlds = null;

    //    private StoreWorldWeekState _PlanningWorldState = null;
    //    private StoreWorldWeekState _ActualWorldState = null;

    //    public ServerTimeContext(ILongTimeAbsenceService longabsenceService,
    //        IAbsenceService absenceService,
    //        IWorkingModelService wmManager,
    //        IColouringService colorManager,
    //        IEmployeeService emplService,
    //        IStoreService storeService,
    //        IWorkingTimePlanningService workingTimePlanningService,
    //        IAbsenceTimePlanningService absenceTimePlanningService,
    //        IWorkingTimeRecordingService workingTimeRecordingService,
    //        IAbsenceTimeRecordingService absenceTimeRecordingService
    //        )
    //    {
            
    //        _EmployeeService = emplService;
    //        _StoreService = storeService;
    //        _WorkingTimePlanningService = workingTimePlanningService;
    //        _AbsenceTimePlanningService = absenceTimePlanningService;

    //        _WorkingTimeRecordingService = workingTimeRecordingService;
    //        _AbsenceTimeRecordingService = absenceTimeRecordingService;

    //        m_countryabsences = new AbsenceManager(absenceService);
    //        m_longabsences = new LongTimeAbsenceManager(longabsenceService);
    //        m_workingmodelmanager = new WorkingModelManagerNew(wmManager);
    //        m_colormanager = new CountryColorManager(colorManager);

    //        _ViewDate = DateTime.Today;
    //        _BeginWeekDate = DateTimeHelper.GetMonday(DateTime.Today);
    //        _EndWeekDate = DateTimeHelper.GetSunday(DateTime.Today);
    //        _ViewDate = DateTime.Today;

    //    }

    //    public bool Modified
    //    {
    //        get { return _Modified; }
    //        set { _Modified = value; }
    //    }
    //    public event ChangedContext ChangedContext
    //    {
    //        add
    //        {
                
    //        }
    //        remove
    //        {
                
    //        }
    //    }
    //    public ILongTimeAbsenceManager LongAbsences
    //    {
    //        get
    //        {
    //            return m_longabsences;
    //        }
    //    }

    //    public IAbsenceManager Absences
    //    {
    //        get
    //        {
    //            return m_countryabsences;
    //        }
    //    }
    //    public IWorkingModelManager WorkingModels
    //    {
    //        get
    //        {
    //            return m_workingmodelmanager;
    //        }
    //    }
    //    public ICountryColorManager CountryColors
    //    {
    //        get
    //        {
    //            return m_colormanager;
    //        }
    //    }
    //    public IStoreDaysList StoreDays
    //    {
    //        get { return m_storedays; }
    //    }
    //    public long CountryId
    //    {
    //        get { return _CountryId; }
    //    }
    //    public long StoreId
    //    {
    //        get { return _StoreId; }
    //    }
    //    public long WorldId
    //    {
    //        get { return _WorldId; }
    //    }
    //    public long StoreWorldId
    //    {
    //        get { return _StoreWorldId; }
    //    }
    //    public DateTime BeginWeekDate
    //    {
    //        get { return _BeginWeekDate; }
    //    }
    //    public DateTime EndWeekDate
    //    {
    //        get { return _EndWeekDate; }
    //    }
    //    public DateTime ViewDate
    //    {
    //        get { return _ViewDate; }
    //    }

    //    public StoreWorldWeekState WorldPlanningState
    //    {
    //        get
    //        {
    //            return _PlanningWorldState;
    //        }
    //    }

    //    public StoreWorldWeekState WorldActualState
    //    {
    //        get
    //        {
    //            return _ActualWorldState;
    //        }
    //    }
    //    public List<StoreToWorld> WorldList
    //    {
    //        get { return m_storeworlds; }
    //    }

    //    public void SetCountryAndStore(long countryid, long storeid)
    //    {
    //        if (CountryId != countryid)
    //        {
    //            _CountryId = countryid;
    //            Absences.CountryId = CountryId;
    //            WorkingModels.CountryId = CountryId;
    //            CountryColors.CountryId = CountryId;
    //            LongAbsences.CountryId = CountryId;
    //        }

    //        if (StoreId != storeid)
    //        {
    //            _StoreId = storeid;
    //            m_storeworlds = _StoreService.StoreToWorldService.FindAllForStore(StoreId);
    //            _WorldId = _StoreWorldId = 0;
    //            _PlanningWorldState = null;
    //            _ActualWorldState = null;
    //            LoadStoreDayInfo();
    //        }
    //    }
    //    public void SetStoreWorld(long storeworldid, long worldid)
    //    {
    //        if (StoreWorldId != storeworldid)
    //        {
    //            _StoreWorldId = storeworldid;
    //            _WorldId = worldid;
    //            LoadEmployeePlanningAndRecording(true);
    //        }
    //    }

    //    private void LoadStoreDayInfo()
    //    {

    //        if (m_storedays != null && m_storedays.StoreId == StoreId &&
    //            m_storedays.BeginTime == BeginWeekDate) return;

    //        m_storedays = _StoreService.GetStoreDays(StoreId, BeginWeekDate, EndWeekDate);

    //    }
        
    //    private void LoadEmployeePlanningAndRecording(bool bLoadStoreDays)
    //    {
    //        if (bLoadStoreDays)
    //            LoadStoreDayInfo();

    //        if (WorldId > 0)
    //        {
    //            List<EmployeeWeek> planningweeks = _EmployeeService.GetTimePlannignEmployeeByWorld2(StoreId, WorldId, BeginWeekDate, EndWeekDate);
    //            Absences.FillEmployeeWeek(planningweeks);
    //            _PlanningWorldState = new StoreWorldWeekState(StoreWorldId, BeginWeekDate, EndWeekDate);

    //            if (planningweeks != null)
    //                _PlanningWorldState.List.AddRange(planningweeks);

    //            _PlanningWorldState.Context = this;
    //            _PlanningWorldState.Calculate();


    //            planningweeks = _EmployeeService.GetTimeRecordingEmployeeByWorld(StoreId, WorldId, BeginWeekDate, EndWeekDate);
    //            Absences.FillEmployeeWeek(planningweeks);
    //            _ActualWorldState = new StoreWorldWeekState(StoreWorldId, BeginWeekDate, EndWeekDate);

    //            if (planningweeks != null)
    //                _ActualWorldState.List.AddRange(planningweeks);

    //            _ActualWorldState.Context = this;
    //            _ActualWorldState.Calculate();

    //            Modified = false;
    //        }
    //    }

    //    public void SetViewDay(DateTime vday)
    //    {
    //        DateTime day = DateTimeHelper.GetMonday(vday);
    //        if (day != BeginWeekDate)
    //        {
    //            _BeginWeekDate = day;
    //            _EndWeekDate = DateTimeHelper.GetSunday(day);
    //            _ViewDate = vday;
    //            LoadEmployeePlanningAndRecording(true);
    //        }
    //        else
    //        {
    //            _ViewDate = vday;
    //        }
    //    }

    //}
}
