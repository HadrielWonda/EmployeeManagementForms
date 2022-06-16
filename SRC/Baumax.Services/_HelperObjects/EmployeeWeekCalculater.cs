using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.AppServer.Environment;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using Baumax.Contract.QueryResult;

namespace Baumax.Services._HelperObjects
{
    public class StoreWeekCalculater
    {
        protected EmployeeTimeService _timeservice = null;
        protected EmployeeService _employeeservice = null;
        protected EmployeeWeekTimePlanningService _weekplanningservice = null;
        protected EmployeeDayStatePlanningService _dayplanningservice = null;
        protected WorkingTimePlanningService _worktimeservice = null;
        protected AbsenceTimePlanningService _absencetimeservice = null;
        protected StoreService _storeservice = null;


        protected AbsenceManager _absencemanager = null;

        protected WorkingModelManagerNew _wmodelmanager = null;

        protected List<EmployeeWeek> _employeeweeks = null;

        private long _storeid;

        public long StoreId
        {
            get { return _storeid; }
            set { _storeid = value; }
        }
        private long _countryId;

        public long CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }
        private DateTime _begindate;

        public DateTime BeginDate
        {
            get { return _begindate; }
            set { _begindate = value; }
        }
        private DateTime _enddate;

        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        public StoreWeekCalculater(long storeid, DateTime abegin, DateTime aend, EmployeeTimeService timeservice)
        {
            _storeid = storeid;
            _begindate = abegin;
            _enddate = aend;

            _timeservice = timeservice;
            _employeeservice = _timeservice.EmployeeService as EmployeeService;
            _storeservice = _employeeservice.StoreService as StoreService;

            

            CountryId = _storeservice.GetCountryByStoreId(_storeid);

            _absencemanager = new AbsenceManager(_storeservice.CountryService.AbsenceService);
            _absencemanager.CountryId = CountryId;

            _wmodelmanager = new WorkingModelManagerNew(_storeservice.CountryService.WorkingModelService);
            _wmodelmanager.CountryId = CountryId;

            Init();


        }

        protected virtual void Init()
        {
            _weekplanningservice = _timeservice.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService;
            _dayplanningservice = _timeservice.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService;
            _worktimeservice = _timeservice.WorkingTimePlanningService as WorkingTimePlanningService;
            _absencetimeservice = _timeservice.AbsenceTimePlanningService as AbsenceTimePlanningService;
        }

        public virtual void Calculate()
        {
           // EmployeeWeekBuilder builder = new EmployeeWeekBuilder(_employeeservice);
            EmployeeWeekBuilder builder = new EmployeeWeekBuilder();
            builder.LoadWeeks = true;
            _employeeweeks = builder.BuildAndFillPlanningWeek(StoreId, -1, BeginDate, EndDate);
            _absencemanager.FillEmployeeWeek(_employeeweeks);

            
            if (_employeeweeks != null && _employeeweeks.Count > 0)
            {
                
                foreach (EmployeeWeek ew in _employeeweeks)
                {
                    ew.InitWeekState();
                    _wmodelmanager.CalculateNew(ew, true);
                }
            }

        }

        public virtual void Save()
        {
            if (_employeeweeks != null && _employeeweeks.Count > 0)
            {
                 long[] ids = EmployeeWeekProcessor.GetEmployeeIds(_employeeweeks);
                // load from BeginDate to 2079 year
                 SrvEmployeeWeekPlanningList plan_list = new SrvEmployeeWeekPlanningList(ids, BeginDate);
                 SrvEmployeesPlanningDayList day_list = new SrvEmployeesPlanningDayList(ids, BeginDate);
                 foreach (EmployeeWeek w in _employeeweeks)
                 {
                     plan_list.UpdateSaldoAfterPlanning(w);
                     foreach (EmployeeDay ed in w.DaysList)
                     {
                         day_list.CompareAndSave (ed);
                     }
                 }

                 
                 EmployeePlanningWorkingModelHelper wmhelper = new EmployeePlanningWorkingModelHelper(_timeservice.EmployeePlanningWorkingModelService);

                 wmhelper.SaveEmployeeWorkingModel(_employeeweeks);
            }
        }


        void FillDiction(Dictionary<long, int> dict)
        {
            foreach (EmployeeWeek week in _employeeweeks)
            {
                foreach (EmployeeDay day in week.DaysList)
                {
                    if (dict.ContainsKey(day.StoreWorldId))
                    {
                        dict[day.StoreWorldId] += day.CountDailyWorkingHours;
                    }
                }
            }
        }

        protected virtual void CalculateByWorld()
        {

            StoreBufferHoursAvailableManager.UpdateBufferHours(StoreId, BeginDate, true);
            
        }
        public void Process()
        {
            Calculate();
            Save();
            CalculateByWorld();
        }

    }

    public class SrvRecordingStoreWeekCalculator : StoreWeekCalculater
    {
        EmployeeWeekTimeRecordingService _weekservice = null;
        EmployeeDayStateRecordingService _dayservice = null;
        WorkingTimeRecordingService _worktimeservice = null;
        AbsenceTimeRecordingService _absencetimeservice = null;

        public SrvRecordingStoreWeekCalculator(long storeid, DateTime abegin, DateTime aend, EmployeeTimeService timeservice)
            :base(storeid, abegin, aend, timeservice )
        {
        }
        protected override void Init()
        {
            _weekservice = _timeservice.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;
            _dayservice = _timeservice.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService;
            _worktimeservice = _timeservice.WorkingTimeRecordingService as WorkingTimeRecordingService;
            _absencetimeservice = _timeservice.AbsenceTimeRecordingService as AbsenceTimeRecordingService;
        }
        public override void Calculate()
        {
            //EmployeeWeekBuilder builder = new EmployeeWeekBuilder(_employeeservice);
            EmployeeWeekBuilder builder = new EmployeeWeekBuilder();
            builder.LoadWeeks = true;
            _employeeweeks = builder.BuildAndFillActualWeek (StoreId, -1, BeginDate, EndDate);
            _absencemanager.FillEmployeeWeek(_employeeweeks);
            if (_employeeweeks != null && _employeeweeks.Count > 0)
            {
                
                foreach (EmployeeWeek ew in _employeeweeks)
                {
                    ew.InitWeekState();
                    ew.PlannedWeek = false;
                    _wmodelmanager.CalculateNew(ew, true);
                }
            }
        }
        protected override void CalculateByWorld()
        {
            StoreBufferHoursAvailableManager.UpdateBufferHours(StoreId, BeginDate, false);
        }
        public override void Save()
        {
            if (_employeeweeks != null && _employeeweeks.Count > 0)
            {
                //_weekservice.SaveEmployeeWeeks(_employeeweeks);
                //_dayservice.SaveEmployeeWeeks(_employeeweeks);
                


                long[] ids = EmployeeWeekProcessor.GetEmployeeIds(_employeeweeks);
                SrvEmployeeWeekRecordingList srv_updater_weeks = new SrvEmployeeWeekRecordingList();
                DateTime nextWeekMonday = DateTimeHelper.GetNextMonday (BeginDate );
                srv_updater_weeks.InitList(ids, BeginDate);
                SrvEmployeesRecordingDayList day_list = new SrvEmployeesRecordingDayList(ids, BeginDate);

                foreach (EmployeeWeek e_w in _employeeweeks)
                {
                    //srv_updater_weeks.UpdateSaldoAfterRecording(e_w.EmployeeId, nextWeekMonday, e_w.Saldo);
                    srv_updater_weeks.UpdateEntityAfterRecording(e_w);
                    foreach (EmployeeDay ed in e_w.DaysList)
                        day_list.CompareAndSave(ed);
                }


                EmployeeRecordingWorkingModelHelper wmhelper = new EmployeeRecordingWorkingModelHelper(_timeservice.EmployeeRecordingWorkingModelService);

                wmhelper.SaveEmployeeWorkingModel(_employeeweeks);
            }
        }
    }



    public class HolidayCalculator
    {
        public void Calculate(long storeid, DateTime aBegin, List<EmployeePlanningWeek> weeks)
        {
            
            if (weeks != null && weeks.Count > 0)
            {
                // build list of absences
                List<AbsenceTimePlanning> lst_Absences = new List<AbsenceTimePlanning>();
                foreach (EmployeePlanningWeek week in weeks)
                {
                    foreach (EmployeePlanningDay day in week.Days.Values)
                    {
                        if (day.AbsenceTimeList != null && day.AbsenceTimeList.Count > 0)
                        {
                            foreach (AbsenceTimePlanning absence_time in day.AbsenceTimeList)
                            {
                                lst_Absences.Add(absence_time);
                            }
                        }
                    }
                }
                // if exists absence times 
                if (lst_Absences.Count > 0)
                {
                    AbsenceManager absencemanager = new AbsenceManager(ServerEnvironment.AbsenceService);
                    int year = DateTimeHelper.GetYearByDate(aBegin);
                    long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(storeid);
                    absencemanager.CountryId = countryid;
                    // fill times by absence entity
                    absencemanager.FillAbsencePlanningTimes(lst_Absences);
                    double avg_day_a_week = ServerEnvironment.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeekByStore(storeid, year);

                    long[] ids = new long[weeks.Count];
                    for (int i = 0; i < weeks.Count; i++)
                    {
                        ids[i] = weeks[i].EmployeeId;
                    }
                    List<EmployeeContract> lst =
                        ServerEnvironment.EmployeeContractService.GetEmployeeContracts(ids, aBegin, aBegin.AddDays(7));

                    DictionListEmployeesContract indexer = new DictionListEmployeesContract(lst);
                    
                    Calculate(avg_day_a_week, indexer, lst_Absences);
                }

            }
        }
        public void Calculate(double avg_day_a_week, DictionListEmployeesContract contracts, List<AbsenceTimePlanning> absence_times)
        {
            foreach (AbsenceTimePlanning absence_time in absence_times)
            {
                if (absence_time.Absence == null)
                    throw new ArgumentNullException();

                if (absence_time.Absence.AbsenceTypeID == AbsenceType.Holiday)
                {
                    absence_time.ApplyTime(contracts.GetContractHours(absence_time.EmployeeID, absence_time.Date), avg_day_a_week); 
                }
            }
        }

        //public void Calculate(long storeid, long[] emplids, DateTime date)
        //{
        //    int Year = DateTimeHelper.GetYearByDate(date);

        //    List<EmployeeDayTimeResult> result = 
        //        ServerEnvironment.EmployeeTimeService.EmployeeHolidaysInfoService.GetEmployeeCoefficints(storeid, Year);


        //}
    }
}
