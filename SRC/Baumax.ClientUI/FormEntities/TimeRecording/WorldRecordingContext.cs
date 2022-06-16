using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.IO;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.Contract.PlanningAndRecording;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{

    //public delegate void ChangedContext();

    public class WorldRecordingContext : IRecordingContext
    {
        private StoreTimeEnvironment _storetimeinfo = null;
        private IStoreService _StoreService = null;
        private IEmployeeService _EmployeeService = null;
        private IWorkingTimePlanningService _WorkingTimePlanningService = null;
        private IAbsenceTimePlanningService _AbsenceTimePlanningService = null;

        private IWorkingTimeRecordingService _WorkingTimeRecordingService = null;
        private IAbsenceTimeRecordingService _AbsenceTimeRecordingService = null;

        private StoreDaysList m_storedays = null;
        private AbsenceManager m_countryabsences = null;
        private WorkingModelManagerNew m_workingmodelmanager = null;
        private LongTimeAbsenceManager m_longabsences = null;
        private CountryColorManager m_colormanager = null;

        private long _CountryId = 0;
        private long _StoreId = 0;
        private bool _Modified = false;
        private DateTime _BeginWeekDate;
        private DateTime _EndWeekDate;
        private DateTime _ViewDate;

        private List<StoreToWorld> m_storeworlds = null;
        private StoreToWorld _CurrentStoreWorld = null;

        private StoreWorldWeekState _PlanningWorldState = null;
        private StoreWorldWeekState _ActualWorldState = null;

        private ErrorCodes ErrorCode = ErrorCodes.Empty;

        public WorldRecordingContext(ILongTimeAbsenceService longabsenceService,
            IAbsenceService absenceService,
            IWorkingModelService wmManager,
            IColouringService colorManager,
            IEmployeeService emplService,
            IStoreService storeService,
            IWorkingTimePlanningService workingTimePlanningService,
            IAbsenceTimePlanningService absenceTimePlanningService,
            IWorkingTimeRecordingService workingTimeRecordingService,
            IAbsenceTimeRecordingService absenceTimeRecordingService
            )
        {
            
            _EmployeeService = emplService;
            _StoreService = storeService;
            _WorkingTimePlanningService = workingTimePlanningService;
            _AbsenceTimePlanningService = absenceTimePlanningService;

            _WorkingTimeRecordingService = workingTimeRecordingService;
            _AbsenceTimeRecordingService = absenceTimeRecordingService;

            m_countryabsences = new AbsenceManager(absenceService);
            m_longabsences = new LongTimeAbsenceManager(longabsenceService);
            m_workingmodelmanager = new WorkingModelManagerNew(wmManager);
            m_colormanager = new CountryColorManager(colorManager);

            _ViewDate = DateTime.Today;
            _BeginWeekDate = DateTimeHelper.GetMonday(DateTime.Today);
            _EndWeekDate = DateTimeHelper.GetSunday(DateTime.Today);
            _ViewDate = DateTime.Today;

        }
        public event FireChangedModified ChangedModified = null;

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
        public IStoreDaysList StoreDays
        {
            get { return m_storedays; }
        }

        public bool Modified
        {
            get { return _Modified; }
            set 
            {
                if (value != _Modified)
                {
                    _Modified = value;
                    if (ChangedModified != null) ChangedModified();
                }
            }
        }
        public long CountryId
        {
            get { return _CountryId; }
        }
        public long StoreId
        {
            get { return _StoreId; }
        }
        public long WorldId
        {
            get 
            {
                if (CurrentStoreWorld == null)
                    return 0;
                return CurrentStoreWorld.WorldID; 
            }
        }
        public long StoreWorldId
        {
            get
            {
                if (CurrentStoreWorld == null)
                    return 0;
                return CurrentStoreWorld.ID;
            }
        }
        public StoreToWorld CurrentStoreWorld
        {
            get { return _CurrentStoreWorld; }
        }

        public DateTime BeginWeekDate
        {
            get { return _BeginWeekDate; }
        }
        public DateTime EndWeekDate
        {
            get { return _EndWeekDate; }
        }
        public DateTime ViewDate
        {
            get { return _ViewDate; }
            set { _ViewDate = value; }
        }

        public StoreWorldWeekState WorldPlanningState
        {
            get
            {
                return _PlanningWorldState;
            }
        }

        public StoreWorldWeekState WorldActualState
        {
            get
            {
                return _ActualWorldState;
            }
        }

        public List<StoreToWorld> WorldList
        {
            get { return m_storeworlds; }
        }

        public void SetCountryAndStore(long countryid, long storeid)
        {
            if (CountryId != countryid)
            {
                _CountryId = countryid ;
                Absences.CountryId = CountryId;
                WorkingModels.CountryId = CountryId;
                CountryColors.CountryId = CountryId;
                LongAbsences.CountryId = CountryId;
            }

            if (StoreId != storeid)
            {
                QuestionToSaveAndSave();

                _StoreId = storeid;
                m_storeworlds = _StoreService.StoreToWorldService.FindAllForStore(StoreId);
                
                if (m_storeworlds != null)
                    m_storeworlds.Sort(new StoreToWorldSorter());

                //_WorldId = _StoreWorldId = 0;
                _CurrentStoreWorld = null;
                _PlanningWorldState = _ActualWorldState = null;
                LoadStoreDayInfo();

                _storetimeinfo = _StoreService.GetStoreTimeEnvironment(StoreId);


                DisplayWarningMessage();

                OnChangedContext();
            }
        }
        public void SetStoreWorld(StoreToWorld entity)
        {
            if (_CurrentStoreWorld != entity)
            {
                
                QuestionToSaveAndSave();
                _CurrentStoreWorld = entity;
                LoadEmployeePlanningAndRecording(true);
            }
        }

        //protected void SetStoreWorld(long storeworldid, long worldid)
        //{
        //    if (StoreWorldId != storeworldid)
        //    {
        //        QuestionToSaveAndSave();

        //        _StoreWorldId = storeworldid;
        //        _WorldId = worldid;
        //        LoadEmployeePlanningAndRecording(true);
        //    }
        //}

        public void SetViewDay(DateTime vday)
        {
            DateTime day = DateTimeHelper.GetMonday(vday);
            if (day != BeginWeekDate)
            {
                QuestionToSaveAndSave();


                _BeginWeekDate = day;
                _EndWeekDate = DateTimeHelper.GetSunday(day);
                _ViewDate = vday;

                if (StoreId > 0)
                    LoadEmployeePlanningAndRecording(true);
            }
            else
            {
                _ViewDate = vday;
            }
        }

        private void LoadStoreDayInfo()
        {

            if (m_storedays != null && m_storedays.StoreId == StoreId &&
                m_storedays.BeginTime == BeginWeekDate) return;

           m_storedays = _StoreService.GetStoreDays(StoreId, BeginWeekDate, EndWeekDate);

        }
        public void Refresh()
        {
            LoadEmployeePlanningAndRecording(false);
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
        private void ClearContext()
        {
            if (_PlanningWorldState != null)
            {
                _PlanningWorldState.Context = null;
                _PlanningWorldState = null;
            }
            if (_ActualWorldState != null)
            {
                _ActualWorldState.Context = null;
                _ActualWorldState = null;
            }
            //_storetimeinfo = null;

            Modified = false;
            OnChangedContext();
        }
        private void LoadEmployeePlanningAndRecording(bool bLoadStoreDays)
        {
            

            ClearContext();

            if (bLoadStoreDays)
                LoadStoreDayInfo();

            ErrorCode = ErrorCodes.Empty;
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

            if (CurrentStoreWorld != null)
            {
                List<EmployeeWeek> planningweeks = _EmployeeService.GetTimePlannignEmployeeByWorld2(StoreId, WorldId, BeginWeekDate, EndWeekDate);
                EmployeeWeekProcessor.MarkAsPlannedWeek(planningweeks);

                Absences.FillEmployeeWeek(planningweeks);

                _PlanningWorldState = new StoreWorldWeekState(CurrentStoreWorld , BeginWeekDate, EndWeekDate);

                if (planningweeks != null)
                {
                    _PlanningWorldState.List.AddRange(planningweeks);
                    foreach (EmployeeWeek ew in planningweeks)
                        ew.InitWeekState();

                }

                _PlanningWorldState.Context = this;
                _PlanningWorldState.Calculate();


                planningweeks = _EmployeeService.GetTimeRecordingEmployeeByWorld(StoreId, WorldId, BeginWeekDate, EndWeekDate);
                EmployeeWeekProcessor.MarkAsRecordingWeek(planningweeks);
                Absences.FillEmployeeWeek(planningweeks);

                _ActualWorldState = new StoreWorldWeekState(CurrentStoreWorld, BeginWeekDate, EndWeekDate);

                if (planningweeks != null)
                {
                    _ActualWorldState.List.AddRange(planningweeks);
                    foreach (EmployeeWeek ew in planningweeks)
                        ew.InitWeekState();
                }

                _ActualWorldState.PlannedWorld = false;
                _ActualWorldState.Context = this;
                _ActualWorldState.Calculate();


                WorldPlanningInfo infoworld =
                        _StoreService.StoreToWorldService.GetStoreWorldPlanningInfo(false, StoreId, WorldId, BeginWeekDate);

                

                _ActualWorldState.StoreWorldInfo = infoworld;
                _PlanningWorldState.StoreWorldInfo = infoworld;

                FillRecordingWorldInfoFromPlanningInfo();

                Modified = false;
                OnChangedContext();

                
            }
        }

        private void FillRecordingWorldInfoFromPlanningInfo()
        {
            if (_PlanningWorldState != null && _ActualWorldState != null && _ActualWorldState.StoreWorldInfo != null)
            {
                int[] dayssum = _PlanningWorldState.GetSums();

                if (!_ActualWorldState.IsCashDesk )//StoreWorldInfo.IsCashDesk)
                {
                    StoreWorldPlanningInfo commonworld = _ActualWorldState.StoreWorldInfo as StoreWorldPlanningInfo;

                    if (commonworld != null && dayssum != null)
                        commonworld.SetTargetedHours(dayssum);
                }
                else
                {
                    
                }
            }
        }


        //public event ChangedContext ChangedContext = null;
        private event ChangedContext _ChangedContext = null;
        protected virtual  void OnChangedContext()
        {
            if (_ChangedContext != null) _ChangedContext();
        }

        public event ChangedContext ChangedContext
        {
            add
            {
                _ChangedContext += value;
            }
            remove
            {
                _ChangedContext -= value;
            }
        }


        public void UpdateHolidaysTime()
        {
            foreach (EmployeeWeek week in _ActualWorldState.List)
            {
                foreach (EmployeeDay day in week.DaysList)
                {
                    if (day.TimeList != null && day.TimeList.Count > 0)
                    {
                        foreach (EmployeeTimeRange timerange in day.TimeList)
                        {
                            if (!timerange.IsWorkingRange)
                            {
                                if (timerange.Absence != null && timerange.Absence.AbsenceTypeID == AbsenceType.Holiday)
                                {
                                    timerange.Time = Utills.GetEntityTime(timerange.Absence, timerange.Begin, timerange.End, week.ContractHoursPerWeek, StoreDays.AvgDayInWeek);
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool QuestionToSaveAndSave()
        {
            if (!Modified) return true;
            QuestionToSaveAndSave(true);
            return true;
        }
        public bool QuestionToSaveAndSave(bool bQuestion)
        {
            if (!Modified) return true;

            if (bQuestion)
            {
                if (XtraMessageBox.Show(Localizer.GetLocalized("QuestionSaveRecordingData"), Localizer.GetLocalized("Attention"), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveContext();
                }
                else Modified = false;
            }
            else
                SaveContext();
            return true;
        }
        public void SaveContext()
        {

            if (Modified && WorldActualState != null)
            {
                
                UpdateHolidaysTime();
                long[] ids_modified_employees = null;
                List<EmployeeTimeRange> lst = EmployeeWeekProcessor.GetDelta(WorldActualState.List, out ids_modified_employees);
                _EmployeeService.EmployeeTimeService.SaveActualEmployeeTimeRange(StoreId, BeginWeekDate, EndWeekDate, ids_modified_employees, lst);

                Modified = false;

            }
        }

        public void DisplayWarningMessage()
        {
            if (IsNeedWarningMessage())
            {
                string s = Localizer.GetLocalized("WarningDaysCome");
                if (_storetimeinfo != null)
                    s = String.Format(s, _storetimeinfo.WarningDays);
                XtraMessageBox.Show(s, 
                                    Localizer.GetLocalized("Attention"), 
                                    System.Windows.Forms.MessageBoxButtons.OK , 
                                    System.Windows.Forms.MessageBoxIcon.Warning) ;
            }
        }
        public bool IsNeedWarningMessage()
        {
            bool result = false;
            if (_storetimeinfo != null)
            {
                if (_storetimeinfo.LastRecordingDate.HasValue)
                {
                    DateTime warningDate = DateTime.Today.AddDays(-_storetimeinfo.WarningDays);
                    DateTime lastTime = _storetimeinfo.LastRecordingDate.Value.AddDays (7);// since it monday of week
                    result = (lastTime <= warningDate);
                }
                else
                    result =  true;
            }
            return result;

        }
        public bool AllowEdit(DateTime date)
        {
            if (_storetimeinfo != null)
            {
                DateTime beginEditDate = AllowEditBeginDate;
                DateTime endEditDate = DateTime.Today;
                return DateTimeHelper.Between(date, beginEditDate, endEditDate); 


                //DateTime today = DateTime.Today;
                //DateTime readonlyDate = today.AddDays(-_storetimeinfo.CriticalDays);

                //return (date >= readonlyDate);
            }
            return false;
        }

        public DateTime AllowEditBeginDate
        {
            get 
            {
                if (_storetimeinfo == null) return DateTime.Today;

                return DateTime.Today.AddDays(-_storetimeinfo.CriticalDays);
            }
        }
    }
}
