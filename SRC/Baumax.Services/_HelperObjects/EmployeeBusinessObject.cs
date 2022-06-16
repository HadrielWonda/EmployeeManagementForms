using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using System.Diagnostics;
using Baumax.Contract.TimePlanning;
using System.Collections;
using Common.Logging;

namespace Baumax.Services._HelperObjects
{
    public class EmployeeBusinessObject
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        private CacheEmployeesAllIn _AllInManagers;

        public CacheEmployeesAllIn AllInManagers
        {
            get { return _AllInManagers; }
            set { _AllInManagers = value; }
        }


        #region Recording data

        private SrvEmployeeWeekRecordingList _recordingWeeks;

        public SrvEmployeeWeekRecordingList RecordingWeeks
        {
            get { return _recordingWeeks; }
            set { _recordingWeeks = value; }
        }


        private SrvEmployeeRecordingDayList _recordingDay = null;

        public SrvEmployeeRecordingDayList RecordingDays
        {
            get { return _recordingDay; }
            set { _recordingDay = value; }
        }
        
        #endregion

        #region Planning data

        private SrvEmployeeWeekPlanningList _planningWeeks;

        public SrvEmployeeWeekPlanningList PlanningWeeks
        {
            get { return _planningWeeks; }
            set { _planningWeeks = value; }
        }


        SrvEmployeesPlanningDayList _PlanningDays = null;

        public SrvEmployeesPlanningDayList PlanningDays
        {
            get { return _PlanningDays; }
            set { _PlanningDays = value; }
        }

        #endregion


        #region relations

        DictionListEmployeeRelations _relations = null;

        public DictionListEmployeeRelations Relations
        {
            get { return _relations; }
            set { _relations = value; }
        }

        #endregion

        #region contracts

        DictionListEmployeesContract _contracts = null;

        public DictionListEmployeesContract Contracts
        {
            get { return _contracts; }
            set { _contracts = value; }
        }

        #endregion


        #region longabsences

        EmployeeLongTimeAbsenceIndexer _longabsences = null;

        public EmployeeLongTimeAbsenceIndexer LongAbsences
        {
            get { return _longabsences; }
            set { _longabsences = value; }
        }

        #endregion

        private DateTime _InitDate;

        public DateTime DateOfInit
        {
            get { return _InitDate; }
            set { _InitDate = value; }
        }
        private bool _AustriaEmployee;

        public bool AustriaEmployee
        {
            get { return _AustriaEmployee; }
            set { _AustriaEmployee = value; }
        }


        public EmployeeBusinessObject(Employee employee, DateTime date)
        {
            if (employee == null)
                throw new ArgumentNullException();

            _employee = employee;
            DateOfInit = date;
        }
        public EmployeeBusinessObject(long emplid)
        {
            _employee = ServerEnvironment.EmployeeService.FindById(emplid);
            AustriaEmployee = ServerEnvironment.CountryService.AustriaCountryID == ServerEnvironment.StoreService.GetCountryByStoreId(_employee.MainStoreID);
            DateOfInit = DateTime.Today;
        }
        private void CheckAndInit()
        {
            if (AllInManagers == null)
            {
                AllInManagers = new CacheEmployeesAllIn();

                AllInManagers.LoadByEmployee(Employee.ID);
            }

            if (RecordingWeeks == null)
            {
                RecordingWeeks = new SrvEmployeeWeekRecordingList();

                RecordingWeeks.InitList(Employee.ID, DateOfInit);

                RecordingWeeks.CacheAllIn = AllInManagers;
            }
        }

        // user can change saldo from Employee manager
        // here recalculate saldo for planning week
        public void UpdateCustomSaldo(int saldo)
        {
            CheckAndInit();

            if (!AustriaEmployee)
            {
                EmployeeWeekTimeRecording entity = RecordingWeeks.UpdateLastSaldoAsCustom(Employee.ID, saldo);

                int lastsaldo = saldo;

                DateTime date = DateTimeSql.FirstMinMonday;

                if (entity != null)
                {
                    date = entity.WeekBegin.AddDays(7);
                }
                else
                {
                    _employee.BalanceHours = Convert.ToDecimal(saldo);
                    (ServerEnvironment.EmployeeService as EmployeeService).EmployeeDao.UpdateSaldo(Employee.ID, Employee.BalanceHours);
                }
                PlanningWeeks = new SrvEmployeeWeekPlanningList();

                if (entity != null)
                {
                    PlanningWeeks.InitList(Employee.ID, entity.WeekBegin);
                    PlanningWeeks.SetCustomEditFlag(Employee.ID, entity.WeekBegin, saldo);
                }
                else
                    PlanningWeeks.InitList(Employee.ID, date);

                PlanningWeeks.AllInManager = AllInManagers;
                PlanningWeeks.UpdateSaldoFrom(Employee.ID, date, lastsaldo);
            }
        }

        public int GetLastSaldoForPlanning(DateTime date)
        {
            EmployeeTimeService service = ServerEnvironment.EmployeeTimeService as EmployeeTimeService;
            int? saldo=  service.GetEmployeeLastVerifiedSaldo(Employee.ID, date);

            if (!saldo.HasValue)
                return Convert.ToInt32(Employee.BalanceHours);
            else
                return saldo.Value;

        }

        public void UpdateAllInFlag(DateTime date)
        {
            DateTime fromDate = DateTimeHelper.GetMonday(date);


            AllInManagers = new CacheEmployeesAllIn();
            AllInManagers.LoadByEmployee(Employee.ID);

            

            PlanningWeeks = new SrvEmployeeWeekPlanningList(Employee.ID, fromDate);
            PlanningDays = new SrvEmployeesPlanningDayList(Employee.ID, fromDate);
            PlanningWeeks.AllInManager = AllInManagers;


            List<EmployeeWeekTimePlanning> list = 
                PlanningWeeks.GetEntitiesByEmployeeId(Employee.ID);

            if (list != null && list.Count > 0)
            {
                int lastSaldo = GetLastSaldoForPlanning(fromDate);

                bool bAllIn = false;
                foreach (EmployeeWeekTimePlanning week_entity in list)
                {
                    if (week_entity.WeekBegin < fromDate) continue;

                    bAllIn = AllInManagers.GetAllIn(week_entity.EmployeeID, week_entity.WeekBegin, week_entity.WeekEnd);

                    Debug.WriteLine(Employee.FullName + week_entity.Dump ());


                    if (week_entity.AllIn != bAllIn)
                    {
                        week_entity.AllIn = bAllIn;

                        if (!week_entity.AllIn)
                        {
                            week_entity.AdditionalCharge = PlanningDays.GetAdditionalChargesForWeekRange(week_entity.EmployeeID ,
                                week_entity.WeekBegin, week_entity.WeekEnd); ;

                            week_entity.CalculateSaldo(lastSaldo);
                        }
                        else
                        {
                            week_entity.AdditionalCharge = 0;
                        }
                        PlanningWeeks.UpdateEntity(week_entity);
                    }

                    Debug.WriteLine(Employee.FullName + week_entity.Dump());

                    lastSaldo = week_entity.Saldo;
                }
            }

        }
        
        public void RecalculateFrom()
        {
            RecalculateFrom(DateOfInit);
        }
        public void RecalculateFrom(DateTime date)
        {
            
            DateTime monday = DateTimeHelper.GetMonday(date);
            DateTime PrevMonday = monday.AddDays(-7);
            if (Relations == null)
            {
                Relations = new DictionListEmployeeRelations(ServerEnvironment.EmployeeRelationService.GetEmployeeRelations (Employee.ID));
            }
            if (Contracts == null)
            {
                Contracts = new DictionListEmployeesContract(ServerEnvironment.EmployeeContractService.GetEmployeeContracts (Employee.ID));
            }

            //LongAbsences = new EmployeeLongTimeAbsenceIndexer(ServerEnvironment.EmployeeLongTimeAbsenceService, Employee.ID);
            if (AllInManagers == null)
            {
                AllInManagers = new CacheEmployeesAllIn(Employee.ID);
            }
            if (RecordingWeeks == null)
            {
                RecordingWeeks = new SrvEmployeeWeekRecordingList();

                RecordingWeeks.InitList(Employee.ID, PrevMonday);
            }


            if (PlanningWeeks == null)
            {
                PlanningWeeks = new SrvEmployeeWeekPlanningList(Employee.ID, PrevMonday);
                
            }
            PlanningWeeks.BzEmployee = this;
            PlanningWeeks.AllInManager = AllInManagers;
            PlanningWeeks.Contracts = Contracts;
            PlanningWeeks.RecordingWeeks = RecordingWeeks;

            PlanningWeeks.RecalculateAfterImport(monday);
        }
        
        public static void Recalculate(long[] ids)
        {
            EmployeeService empl_service = ServerEnvironment.EmployeeService as EmployeeService;

            List<Employee> lst = empl_service.EmployeeDao.GetEmployeeByIds(ids);

            IList list = empl_service.EmployeeDao.GetDifferenceContractsAndRelations();

            if (lst == null) return;
            int i = 0;

            DictionListEmployeeRelations rels = new DictionListEmployeeRelations(ServerEnvironment.EmployeeRelationService.LoadAllSorted());



            CacheListEmployeeContracts contracts = (new CacheListEmployeeContracts()).LoadAll();

            CacheEmployeesAllIn all = (new CacheEmployeesAllIn()).LoadAll();

            DateTime beginDate = DateTime.Today.AddDays(-7);
            beginDate = DateTimeHelper.GetMonday(beginDate);


            SrvEmployeeWeekPlanningList PlanningWeeks = new SrvEmployeeWeekPlanningList();
            PlanningWeeks.InitList(null, beginDate);

            SrvEmployeeWeekRecordingList RecordingWeeks = new SrvEmployeeWeekRecordingList();
            RecordingWeeks.InitList(null, beginDate);

            List<Store> stores = ServerEnvironment.StoreService.FindAll();
            Dictionary<long, Store> diction_stores = new Dictionary<long, Store>();
            foreach (Store s in stores)
                diction_stores[s.ID] = s;

            long austriaid = ServerEnvironment.CountryService.AustriaCountryID;
            //rels.LoadRelations(ServerEnvironment.EmployeeRelationService);
            EmployeeBusinessObject bz = null;

            foreach (Employee e in lst)
            {
                i++;

                if (bz == null)
                    bz = new EmployeeBusinessObject(e, DateTime.Today);
                else
                    bz.Employee = e;

                bz.AustriaEmployee = diction_stores[e.MainStoreID].CountryID == austriaid;

                bz.Relations = rels;
                bz.Contracts = contracts;
                bz.AllInManagers = all;

                bz.PlanningWeeks = PlanningWeeks;
                bz.RecordingWeeks = RecordingWeeks;
                bz.RecalculateFrom();

            }
        }
        /// <summary>
        /// Calculate absences as day.
        /// This method calls after import employees working time(Austria)
        /// date1,date2 - return sql server after import and contain min/max date of imported times
        /// </summary>
        /// <param name="date1">begin date for load absences</param>
        /// <param name="date2">end date for load absences</param>
        public static void RecalculateHolidaysTimeRanges(DateTime date1, DateTime date2)
        {
            if (date1 > date2) return;
            
            long countryid = ServerEnvironment.CountryService.AustriaCountryID;
            RecalculateHolidaysTimeRanges(countryid, date1, date2);
        }
        /// <summary>
        /// RecalculateHolidaysTimeRanges(long countryid, DateTime date1, DateTime date2)
        /// Calculate absence with type=Holidays as day
        /// </summary>
        /// <param name="countryid">country's ID for which need calculate</param>
        /// <param name="date1">begin date for load absences</param>
        /// <param name="date2">end date for load absences</param>
        public static void RecalculateHolidaysTimeRanges(long countryid, DateTime date1, DateTime date2)
        {
            AbsenceTimeRecordingService ser = (ServerEnvironment.AbsenceTimeRecordingService as AbsenceTimeRecordingService);
            if (ser == null)
                throw new ArgumentNullException();

            List<AbsenceTimeRecording> absences = ser.absenceTimeRecordingDao.GetCountryHolidayTimeRecordingsBetweenDate(countryid, date1, date2);
            RecalculateHolidaysTimeRanges(countryid, absences);
        }

        public static void RecalculateHolidaysTimeRanges(long countryid, List<AbsenceTimeRecording> absences)
        {
            if (absences == null || absences.Count == 0) return;

            Dictionary<long, object> dict = new Dictionary<long, object>(5000);
            foreach (AbsenceTimeRecording absence in absences)
            {
                dict[absence.EmployeeID] = null;
            }
            long[] ids = new long[dict.Count];
            dict.Keys.CopyTo(ids, 0);

            CacheListEmployeeContracts contracts = new CacheListEmployeeContracts();
            contracts.LoadByEmployees(ids);

            RecalculateHolidaysTimeRanges(countryid, contracts, absences);

        }
        public static void RecalculateHolidaysTimeRanges(long countryid, CacheListEmployeeContracts contracts, List<AbsenceTimeRecording> absences)
        {

            if (absences == null || absences.Count == 0) return;


            int Year = -1;

            AbsenceManager absenceManager = new AbsenceManager(ServerEnvironment.AbsenceService, countryid);

            double avgWorkingDays = 0;// ServerEnvironment.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeek(ServerEnvironment.CountryService.AustriaCountryID, Year);

            foreach (AbsenceTimeRecording absence in absences)
            {
                if (absenceManager.IsHoliday(absence.AbsenceID))
                {
                    absence.Absence = absenceManager.GetById(absence.AbsenceID);
                    short time = absence.Time;


                    int contractHours = contracts.GetContractHours(absence.EmployeeID, DateTimeHelper.GetMonday(absence.Date), DateTimeHelper.GetSunday(absence.Date));

                    if (contractHours > 0)
                    {
                        if (Year != DateTimeHelper.GetYearByDate(absence.Date))
                        {
                            Year = DateTimeHelper.GetYearByDate(absence.Date);
                            avgWorkingDays = ServerEnvironment.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeek(countryid, Year);
                        }
                        absence.ApplyTime(contractHours, avgWorkingDays);

                        if (absence.Time != time)
                        {
                            ServerEnvironment.AbsenceTimeRecordingService.SaveOrUpdate(absence);
                        }
                    }
                }
            }


        }




        public static void ClearEmployeeTimes(long emplid, DateTime begin, DateTime end)
        {
            // clear planning
            (ServerEnvironment.AbsenceTimePlanningService as AbsenceTimePlanningService).ClearEmployeeByDateRange(emplid, begin, end);
            (ServerEnvironment.WorkingTimePlanningService as WorkingTimePlanningService).ClearEmployeeByDateRange(emplid, begin, end);
            (ServerEnvironment.EmployeePlanningWorkingModelService as EmployeePlanningWorkingModelService).ClearEmployeeByDateRange(emplid, begin, end);


            // clear recording

            (ServerEnvironment.AbsenceTimeRecordingService as AbsenceTimeRecordingService).ClearEmployeeByDateRange(emplid, begin, end);
            (ServerEnvironment.WorkingTimeRecordingService as WorkingTimeRecordingService).ClearEmployeeByDateRange(emplid, begin, end);
            (ServerEnvironment.EmployeeRecordingWorkingModelService as EmployeeRecordingWorkingModelService).ClearEmployeeByDateRange(emplid, begin, end);


        }

        public static void RecalculateAfterModifiedContractEndDate(long[] emplids)
        {
            ILog Log = LogManager.GetLogger("EmployeeBusinessObject");


            if (emplids == null || emplids.Length == 0)
            {
                Log.Debug("RecalculateAfterModifiedContractEndDate - Count of employees = 0");
                return;
            }

            CacheListEmployeeContracts contracts = new CacheListEmployeeContracts();
            contracts.LoadByEmployees(emplids);

            if (Log.IsDebugEnabled)
                Log.Debug("Load contracts by long[] ids of employees");

            CacheListEmployeeRelations relations = new CacheListEmployeeRelations();
            relations.LoadByEmployees(emplids);

            if (Log.IsDebugEnabled)
                Log.Debug("Load relations by long[] ids of employees");

            #region  debug checking

#if DEBUG
            {
                //for (int i = 0; i < emplids.Length; i++)
                //{
                //    ListEmployeeContracts contract_list1 = contracts[emplids[i]];
                //    ListEmployeeRelations relation_list1 = relations[emplids[i]];


                //    if (contract_list1 == null && relation_list1 == null)
                //    {
                //        Log.Debug("Employee (" + emplids[i].ToString() + ") don't have contract and relation");
                //    }

                //    if (contract_list1 == null)
                //    {
                //        Log.Debug("Employee (" + emplids[i].ToString() + ") don't have contract");
                //    }
                //    if (relation_list1 == null)
                //    {
                //        Log.Debug("Employee (" + emplids[i].ToString() + ") don't have relation");
                //    }

                //    DateTime lastContractDate = contract_list1.GetLastContractDate();

                //    DateTime lastRelationDate = relation_list1.GetLastRelationDate();

                //    if (lastContractDate != lastRelationDate)
                //    {
                //        Log.Debug(String.Format("Employee({0}) has not equal contract and relation end date: {1} and {2}", emplids[i], lastContractDate.ToShortDateString(), lastRelationDate.ToShortDateString()));
                //    }

                //}
            }
#endif
            #endregion


            Dictionary<long, DateTime> setStoreWorlds = new Dictionary<long, DateTime>();
            Dictionary<long, DateTime> setStores = new Dictionary<long, DateTime>();
            ListEmployeeContracts contract_list = null;
            DateTime last_contract_date;

            SrvEmployeeWeekRecordingList recording_weeks = new SrvEmployeeWeekRecordingList();
            recording_weeks.InitList(emplids, DateTimeSql.FirstMinMonday);

            SrvEmployeeWeekPlanningList planning_weeks = new SrvEmployeeWeekPlanningList(emplids, DateTimeSql.FirstMinMonday);


            foreach (long employeeid in emplids)
            {
                Employee employee = ServerEnvironment.EmployeeService.FindById(employeeid);

                if (employee == null)
                {
                    Log.Warn(String.Format("Employee({0}) not found !!!", employeeid));
                    continue;
                }
                setStores[employee.MainStoreID] = DateTime.Today;

                if (Log.IsDebugEnabled)
                {
                    String debugMessage = String.Format(" Process {0}({1}) ( {2} )", employee.FullName, employee.PersID, employee.PersNumber);
                    Log.Debug(debugMessage);
                }

                contract_list = contracts[employeeid];
                if (contract_list == null || contract_list.Count == 0)
                {
                    continue;
                }

                last_contract_date = contract_list.GetLastContractDate();

                last_contract_date = last_contract_date.AddDays(1);

                last_contract_date = last_contract_date.Date;


                EmployeePlanningDayListEx planning_days = new EmployeePlanningDayListEx(employeeid, last_contract_date);
                foreach (EmployeeDayStatePlanning day in planning_days)
                {
                    if (last_contract_date <= day.Date)
                    {
                        if (setStoreWorlds.ContainsKey(day.StoreWorldId))
                        {
                            DateTime date = setStoreWorlds[day.StoreWorldId];

                            if (last_contract_date < date)
                                setStoreWorlds[day.StoreWorldId] = last_contract_date;
                        }
                        else
                            setStoreWorlds[day.StoreWorldId] = last_contract_date;
                    }
                }
                EmployeeRecordingDayListEx recording_days = new EmployeeRecordingDayListEx(employeeid, last_contract_date, DateTimeSql.SmallDatetimeMax);
                foreach (EmployeeDayStateRecording day in recording_days)
                {
                    if (last_contract_date <= day.Date)
                    {
                        if (setStoreWorlds.ContainsKey(day.StoreWorldId))
                        {
                            DateTime date = setStoreWorlds[day.StoreWorldId];

                            if (last_contract_date < date)
                                setStoreWorlds[day.StoreWorldId] = last_contract_date;
                        }
                        else
                            setStoreWorlds[day.StoreWorldId] = last_contract_date;
                    }
                }
                recording_weeks.ValidateWeekWithContractEnd(employeeid, last_contract_date);
                planning_weeks.ValidateWeekWithContractEnd(employeeid, last_contract_date);
                
                if (recording_days.Count > 0)
                {
                    recording_days.RemoveFromDatabase(last_contract_date, DateTimeSql.SmallDatetimeMax);
                }
                if (planning_days.Count > 0)
                {
                    planning_days.RemoveFromDatabase(last_contract_date, DateTimeSql.SmallDatetimeMax);
                }

                ClearEmployeeTimes(employeeid, last_contract_date, DateTimeSql.SmallDatetimeMax);

                if (last_contract_date.DayOfWeek != DayOfWeek.Monday)
                {
                    DateTime monday = DateTimeHelper.GetMonday (last_contract_date);
                    DateTime sunday = DateTimeHelper.GetSunday(monday);
                    planning_days = new EmployeePlanningDayListEx(employeeid, monday, sunday);

                    EmployeeWeekTimePlanning week_planning = 
                        planning_weeks.GetByDate(employeeid, monday);

                    if (week_planning != null)
                    {
                        week_planning.PlannedHours = 0;
                        week_planning.WorkingHours = 0;
                        week_planning.AdditionalCharge = 0;
                        int prevSaldo = week_planning.GetPrevSaldo();
                        foreach (EmployeeDayStatePlanning e in planning_days)
                        {
                            week_planning.PlannedHours += e.AllreadyPlannedHours;
                            week_planning.WorkingHours += e.WorkingHours;
                            week_planning.AdditionalCharge += e.SumOfAddHours;

                        }
                        week_planning.CalculateSaldo(prevSaldo);
                        ServerEnvironment.EmployeeWeekTimePlanningService.Update(week_planning);
                    }
                    recording_days = new EmployeeRecordingDayListEx(employeeid, monday, sunday);

                    EmployeeWeekTimeRecording week_recording =
                        recording_weeks.GetByDate(employeeid, monday);

                    if (week_recording != null)
                    {
                        week_recording.PlannedHours = 0;
                        week_recording.WorkingHours = 0;
                        week_recording.AdditionalCharge = 0;
                        int prevSaldo = week_recording.GetPrevSaldo();
                        foreach (EmployeeDayStateRecording e in recording_days)
                        {
                            week_recording.PlannedHours += e.AllreadyPlannedHours;
                            week_recording.WorkingHours += e.WorkingHours;
                            week_recording.AdditionalCharge += e.SumOfAddHours;

                        }
                        week_recording.CalculateSaldo(prevSaldo);
                        ServerEnvironment.EmployeeWeekTimeRecordingService.Update(week_recording);
                    }
                }
            }
            List<StoreToWorld> lst = ServerEnvironment.StoreToWorldService.FindAll();
            Dictionary<long, StoreToWorld> dc = new Dictionary<long, StoreToWorld>();
            if (lst != null)
            {
                foreach (StoreToWorld sw in lst)
                {
                    dc[sw.ID] = sw;
                }
            }
            //setStores.Clear();
            StoreToWorld sw1 = null;
            foreach (long swid in setStoreWorlds.Keys)
            {
                
                if (dc.TryGetValue (swid, out sw1))
                {
                    setStores[sw1.StoreID] = DateTime.Today;
                }
            }

            foreach (long storeid in setStores.Keys)
            {
                StoreBufferHoursAvailableManager.UpdateWholeYear(storeid, 2008);
            }

        }
        
    }
}
