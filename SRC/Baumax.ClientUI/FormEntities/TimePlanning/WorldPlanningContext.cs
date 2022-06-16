using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Contract.QueryResult;
using Baumax.Contract.WorkingModelConditions;
using Baumax.Environment;
using Baumax.Contract.TimePlanning;
using DevExpress.XtraEditors;
using Baumax.Localization;
using System.Diagnostics;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{


    public delegate void FireChangedStoreOrWorld(bool containEmployees);
    public delegate void FireChangedContext();
    public delegate void FireChangedModified();
    public delegate void FireSaveEvent();

    [Flags]
    public enum ErrorCodes
    {
        Empty = 0,
        NotExistsOpenTime = 1,
        NotExistsAvgDaysPerWeek = 2
    }
    // list of employee
    // list of employee relations
    // list of contract
    // list of long time-absence
    public class WorldPlanningContext : IPlanningContext
    {
        private long m_countryid = 0;
        private StoreDaysList m_storedays = null;
        private Store m_store = null;
        private StoreToWorld m_storeworld = null;
        private DateTime m_begintime;
        private DateTime m_endtime;
        private DateTime _ViewDate;

        private AbsenceManager m_countryabsences = null;
        private WorkingModelManager m_workingmodelmanager = null;
        private LongTimeAbsenceManager m_longabsences = null;
        private CountryColorManager m_colormanager = null;
        private List<EmployeePlanningWeek> _ListPlanningEmployees = null;

        private List<StoreToWorld> _ListStoreToWorld = null;
        private Dictionary<long, StoreWorldWeekPlanningState> _dictionStoreWorldStates = new Dictionary<long, StoreWorldWeekPlanningState>();

        public event FireChangedStoreOrWorld OnChangedStoreOrWorld = null;

        private bool _Modified = false;
        private bool _ReadOnly = false;

        private ErrorCodes ErrorCode = ErrorCodes.Empty;


        public WorldPlanningContext()
        {
            m_begintime = DateTime.Today;

            m_begintime = DateTimeHelper.GetMonday(m_begintime);

            m_endtime = DateTimeHelper.GetSunday(m_begintime);
            ViewDate = DateTime.Today;

            m_countryabsences = new AbsenceManager(ClientEnvironment.AbsenceService);
            m_longabsences = new LongTimeAbsenceManager(ClientEnvironment.LongTimeAbsenceService);
            m_workingmodelmanager = new WorkingModelManager(ClientEnvironment.WorkingModelService);
            m_colormanager = new CountryColorManager(ClientEnvironment.ColouringService);
        }


        #region IPlanningContext

        public bool Modified
        {
            get { return _Modified; }
            set
            {
                if (value != _Modified)
                {
                    _Modified = value;
                    if (OnChangedModified != null) OnChangedModified();
                }
            }
        }

        public event FireChangedModified OnChangedModified = null;
        public event FireSaveEvent OnSaveEvent = null;

        public void FireSave()
        {
            if (OnSaveEvent != null) OnSaveEvent();
        }

        public string GetLongTimeAbbreviation(long id)
        {
            return LongAbsences.GetAbbreviation (id); ;
        }
        public int? GetLongTimeAbsenceColor(long id)
        {
            return LongAbsences.GetColor(id);
        }
        public ILongTimeAbsenceManager LongAbsences
        {
            get
            {
                return m_longabsences;
            }
        }

        public IAbsenceManager Absences
        {
            get
            {
                return m_countryabsences;
            }
        }
        public IWorkingModelManager WorkingModels
        {
            get
            {
                return m_workingmodelmanager;
            }
        }
        public ICountryColorManager CountryColors
        {
            get
            {
                return m_colormanager;
            }
        }
        public long StoreWorldId
        {
            get { return CurrentStoreWorldId; }
        }
        #endregion

        #region Properties 

        public List<EmployeePlanningWeek> PlanningEmployees
        {
            get
            {
                return _ListPlanningEmployees;
            }
        }

        public StoreWorldWeekPlanningState WeeklyWorldState
        {
            get
            {
                StoreWorldWeekPlanningState result = null;
                _dictionStoreWorldStates.TryGetValue(CurrentWorldId, out result);
                return result;
            }
        }

        public List<EmployeePlanningWeek> DailyWorldPlanningEmployees
        {
            get
            {
                StoreWorldWeekPlanningState result = WeeklyWorldState;

                if (result != null)
                {
                    return PlanningWeekProcessor.GetEmployeesByWorldAndDate(result.StoreWorldId, ViewDate, result.List);
                }
                return null;
            }
        }

        public List<StoreToWorld> ListStoreWorlds
        {
            get
            {
                return _ListStoreToWorld;
            }
        }
        

        public Store CurrentStore
        {
            get { return m_store; }
            protected set
            {
                if (m_store != value)
                {
                    m_store = value;
                    OnChangedStore();
                }
            }
        }

        public long CurrentStoreId
        {
            get
            {
                if (m_store != null) return m_store.ID;

                return 0;
            }
        }

        public long CountryId
        {
            get { return m_countryid; }
            protected set 
            {
                if (m_countryid != value)
                {
                    m_countryid = value;

                    if (m_countryid <= 0)
                    {

                    }
                    else
                    {
                        Absences.CountryId = CountryId;
                        LongAbsences.CountryId = CountryId;
                        WorkingModels.CountryId = CountryId;
                        CountryColors.CountryId = CountryId;
                    }
                }
            }
        }

        public StoreToWorld CurrentStoreWorld
        {
            get
            {
                return m_storeworld; 
            }
            set
            {
                if (m_storeworld != value)
                {
                    m_storeworld = value;
                    OnChangedStoreWorld();
                }

            }
        }

        public long CurrentStoreWorldId
        {
            get
            {
                if (m_storeworld != null) return m_storeworld.ID;

                return 0;
            }
        }
        public long CurrentWorldId
        {
            get
            {
                if (m_storeworld != null) return m_storeworld.WorldID;
                return 0;
            }
        }

        public IStoreDaysList StoreDays
        {
            get { return m_storedays; }
        }



        public DateTime BeginTime
        {
            get { return m_begintime; }
            set
            {
                m_begintime = value;
            }
        }
        public DateTime EndTime
        {
            get { return m_endtime; }
            set
            {
                m_endtime = value;
            }
        }

        public DateTime ViewDate
        {
            get { return _ViewDate; }
            set { _ViewDate = value; }
        }


        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }
        #endregion

        protected virtual void OnChangedStore()
        {
            if (CurrentStore != null)
            {
                _ListStoreToWorld = ClientEnvironment.StoreToWorldService.FindAllForStore(CurrentStore.ID);
                if (_ListStoreToWorld != null)
                    _ListStoreToWorld.Sort(new StoreToWorldSorter());

                LoadContext();
            }
            Modified = false;
            OnChangedStoreWorld();
        }

        protected virtual void OnChangedContext()
        {
            //if (ChangedContext != null) ChangedContext();
        }

        protected virtual void OnChangedStoreWorld()
        {
            if (OnChangedStoreOrWorld != null)
                OnChangedStoreOrWorld (WeeklyWorldState != null
                                    && WeeklyWorldState.List != null 
                                    && WeeklyWorldState.List.Count > 0);
        }

        public void SetStore(long countryid, Store store)
        {
            
            if (countryid != CountryId ||CurrentStore != store)
            {
                // AskToSave
                if (Modified)
                {
                    QuestionToSaveAndSave();
                }
            }
            CountryId = countryid;
                
            CurrentStore = store;
        }

        private void ClearContext()
        {
            if (_dictionStoreWorldStates.Count > 0)
            {
                foreach (StoreWorldWeekPlanningState info in _dictionStoreWorldStates.Values)
                    info.Free();
            }
            _dictionStoreWorldStates.Clear();

            _ListPlanningEmployees = new List<EmployeePlanningWeek>();
            Modified = false;
        }

        public void ProcessError()
        {
            if (ErrorCode != ErrorCodes.Empty)
            {
                StringBuilder sb = new StringBuilder();

                if ((ErrorCode & ErrorCodes.NotExistsAvgDaysPerWeek) == ErrorCodes.NotExistsAvgDaysPerWeek)
                {
                    sb.AppendLine(Localizer.GetLocalized("NotExistsAvgDaysPerWeek"));
                }
                if ((ErrorCode & ErrorCodes.NotExistsOpenTime) == ErrorCodes.NotExistsOpenTime)
                {
                    sb.AppendLine(Localizer.GetLocalized("NotExistsOpenTime"));
                }

                string message = sb.ToString();
                XtraMessageBox.Show(message, Localizer.GetLocalized("Attention"), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }
        // must call after change store or date
        protected void LoadContext()
        {
            if (CurrentStoreId != 0)
            {
                ErrorCode = ErrorCodes.Empty;
                ClearContext();

                m_storedays = ClientEnvironment.StoreService.GetStoreDays(CurrentStoreId, BeginTime, EndTime);


                if (m_storedays.IsUndefined())
                {
                    ErrorCode |= ErrorCodes.NotExistsOpenTime ;
                    
                }
                if (m_storedays.AvgDayInWeek == 0)
                {
                    ErrorCode |= ErrorCodes.NotExistsAvgDaysPerWeek ;
                }

                if (ErrorCodes.Empty != ErrorCode)
                {
                    ProcessError();
                    return;
                }
                
                

                _ListPlanningEmployees = ClientEnvironment.EmployeeService.GetTimePlannignEmployee2(CurrentStoreId, BeginTime, EndTime);

                if (_ListPlanningEmployees != null)
                {
                    foreach (EmployeePlanningWeek week in _ListPlanningEmployees)
                    {
                        week.AvgDaysWeek = StoreDays.AvgDayInWeek;
                        week.InitWeekState();
                    }
                }
                ApplyStoreDays(); 

                BuildNewWeekWorldPlanningList();

                LoadWorkingAndAbsenceTimes();
            }
        }

        private void ApplyStoreDays()
        {
            Dictionary<long, StoreDaysList> dict = new Dictionary<long, StoreDaysList>();
            dict[CurrentStoreId] = m_storedays;
            if (_ListPlanningEmployees != null && _ListPlanningEmployees.Count > 0)
            {
                foreach (EmployeePlanningWeek week in _ListPlanningEmployees)
                {
                    foreach (EmployeePlanningDay day in week.Days.Values)
                    {
                        if (day.HasRelation)
                        {
                            if (day.StoreId == CurrentStoreId)
                            {
                                day.StoreDay = StoreDays[day.Date];
                            }
                            else
                            {
                                if (!dict.ContainsKey(day.StoreId))
                                {
                                    dict[day.StoreId] = ClientEnvironment.StoreService.GetStoreDays(day.StoreId, BeginTime, EndTime);
                                }

                            }
                        }
                    }
                }
            }

        }
        protected void ReloadWeek()
        {
            _ListPlanningEmployees = ClientEnvironment.EmployeeService.GetTimePlannignEmployee2(CurrentStoreId, BeginTime, EndTime);

            BuildNewWeekWorldPlanningList();

            LoadWorkingAndAbsenceTimes();

            Modified = false;
            OnChangedStore();
        }


        private void LoadWorkingAndAbsenceTimes()
        {
            long[] ids = PlanningWeekProcessor.ListToEmployeeIds(PlanningEmployees);

            List<WorkingTimePlanning> _workingTimes = ClientEnvironment.WorkingTimePlanningService.GetWorkingTimePlanningsByEmployeeIds(ids, BeginTime, EndTime);
            //List<WorkingTimePlanning> _workingTimes1 = ClientEnvironment.WorkingTimePlanningService.GetEntitiesByStoreRelations(CurrentStoreId, BeginTime, EndTime);
            
            List<AbsenceTimePlanning> _absenceTimes = ClientEnvironment.AbsenceTimePlanningService.GetAbsenceTimePlanningsByEmployeeIds(ids, BeginTime, EndTime);
            //List<AbsenceTimePlanning> _absenceTimes = ClientEnvironment.AbsenceTimePlanningService.GetEntitiesByStoreRelations(CurrentStoreId, BeginTime, EndTime);

            if (Absences != null) Absences.FillAbsencePlanningTimes(_absenceTimes);

            PlanningWeekProcessor.AssignTimes(PlanningEmployees, _workingTimes, _absenceTimes);


           

        }

        public void LoadByWeek(DateTime dateMonday, DateTime dateSunday)
        {
            if (dateMonday != BeginTime)
            {
                QuestionToSaveAndSave();
                BeginTime = dateMonday;
                EndTime = dateSunday;

                if (BeginTime <= DateTime.Today && DateTime.Today <= EndTime)
                    ViewDate = DateTime.Today;
                else
                    ViewDate = dateMonday;

                LoadContext();
                OnChangedStoreWorld();
            }
        }
        public void LoadByDate(DateTime date)
        {
            if (!DateTimeHelper.Between(date, BeginTime, EndTime))
            {
                QuestionToSaveAndSave();
                BeginTime = DateTimeHelper.GetMonday(date);
                EndTime = DateTimeHelper.GetSunday(date);
                ViewDate = date;

                LoadContext();
                OnChangedStoreWorld();
            }
            else
            {
                ViewDate = date;
            }
        }

        public EmployeeDayViewList GetDailyEmployeeList()
        {
            if (WeeklyWorldState != null)
            {
                return WeeklyWorldState.GetDailyListView (ViewDate); 
            }
            else return null;
        }


        public void BuildNewWeekWorldPlanningList()
        {
            _dictionStoreWorldStates.Clear();

            if (ListStoreWorlds != null)
            {
                List<EmployeePlanningWeek> lst = null;
                StoreWorldWeekPlanningState state = null;

                foreach (StoreToWorld stw in ListStoreWorlds)
                {
                    lst = PlanningWeekProcessor.GetEmployeesByWorld(stw.ID, PlanningEmployees);

                    state = new StoreWorldWeekPlanningState(stw.ID, BeginTime, EndTime);
                    state.IContext = this;
                    if (lst != null)
                        state.List.AddRange(lst);
                    _dictionStoreWorldStates[stw.WorldID]= state;

                    WorldPlanningInfo infoworld =
                        ClientEnvironment.StoreService.StoreToWorldService.GetStoreWorldPlanningInfo(true, CurrentStoreId, stw.WorldID, BeginTime);

                    state.StoreWorldInfo = infoworld;
 
                }
            }
        }

        public void SaveContext2(bool bReload)
        {
            Dictionary<long, EmployeePlanningWeek> _emplIds = new Dictionary<long, EmployeePlanningWeek>();
            //List<WorkingTimePlanning> lstWork = new List<WorkingTimePlanning>();
            //List<AbsenceTimePlanning> lstAbs = new List<AbsenceTimePlanning>();
            if (PlanningEmployees != null)
            {
                foreach (EmployeePlanningWeek epw in PlanningEmployees)
                {
                    foreach (EmployeePlanningDay epd in epw.Days.Values)
                    {
                        if (epd.Modified)
                        {
                            _emplIds[epw.EmployeeId] = epw;
                            break;
                        }
                    }
                }

                List<EmployeePlanningWeek> weeks = new List<EmployeePlanningWeek>();
                if (_emplIds.Count > 0)
                {
                    weeks.AddRange(_emplIds.Values);

                    ClientEnvironment.EmployeeService.EmployeeTimeService.SavePlanning2(CurrentStoreId, BeginTime, EndTime, weeks);
                    Modified = false;
                    //if (bReload )
                    //    ReloadWeek();
                }

            }
        }

        public bool CanEditEmployeeDay(EmployeePlanningDay planningday)
        {
            if (ReadOnly) return false;
            if (planningday.Date < DateTime.Today) return false;
            if (planningday.WorldId != CurrentStoreWorldId) return false;
            if (planningday.HasLongAbsence) return false;
            if (!planningday.HasContract) return false;

            return true;
        }

        public bool QuestionToSaveAndSave()
        {
            if (!Modified) return true;

            if (XtraMessageBox.Show(Localizer.GetLocalized ("QuestionSavePlannigData"),Localizer.GetLocalized ("Attention"), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveContext2(false);
            }
            Modified = false;

            return true;
        }
    }
}
