using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using System.Collections;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    public class EmployeeWeekBuilder
    {
        private EmployeeService _employeeservice = null;
        private List<EmployeeWeek> _listweeks = null;
        private long[] _employeeids = null;
        private Dictionary<long, EmployeeWeek> _dictionWeek = null;
        private DictionListEmployeesContract _contractIndexer = null;
        private bool _LoadWeeks = false;

        public DictionListEmployeesContract ContractIndexer
        {
            get { return _contractIndexer; }
            set { _contractIndexer = value; }
        }

        public bool LoadWeeks
        {
            get { return _LoadWeeks; }
            set { _LoadWeeks = value; }
        }

        public EmployeeService EmployeeService
        {
            get { return _employeeservice; }
        }

        public List<EmployeeWeek> Weeks
        {
            get { return _listweeks; }
        }
        public EmployeeWeekBuilder()
        {
            _employeeservice = ServerEnvironment.EmployeeService as EmployeeService;

            if (_employeeservice == null)
                throw new ArgumentNullException();
        }

        public List<EmployeeWeek> BuildEmployeeWeeks(long storeid, long worldid, DateTime aBegin, DateTime aEnd, bool bPlanning)
        {
            Store store = ServerEnvironment.StoreService.FindById(storeid);

            if (store == null)
                return null;
            long countryid = store.CountryID;
            bool IsAustria = store.CountryID == ServerEnvironment.CountryService.AustriaCountryID;


            // list of all employee for storeid and world
            IList employees = EmployeeService.EmployeeDao.GetPlanningEmployeesByWorld(storeid, worldid, aBegin, aEnd);

            if (employees == null && employees.Count == 0) return null;

            long[] ids = new long[employees.Count];
            for (int i = 0; i < employees.Count; i++)
            {
                ids[i] = (employees[i] as Employee).ID;
            }

            EmployeeRelationService relationService = EmployeeService.EmployeeRelationService as EmployeeRelationService;

            List<EmployeeRelation> emplRelations = relationService.GetEmployeeRelationsByEmployeeIds(ids, aBegin, aEnd);

            //CountryStoreWorldManager swmanager = new CountryStoreWorldManager(EmployeeService.StoreWorldService);
            //swmanager.StoreId = storeid;
            if (swCountryManager == null)
            {
                //long countryid = EmployeeService.StoreService.GetCountryByStoreId(storeid);
                swCountryManager = new CountryStoreWorldManager(EmployeeService.StoreWorldService);
                swCountryManager.CountryId = countryid;
            }

            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                EmployeeService.EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(ids, aBegin, aEnd);

            EmployeeLongTimeAbsenceIndexer absenceIndexer = new EmployeeLongTimeAbsenceIndexer(emplLongTimeAbsences);

            DictionListEmployeeRelations relationIndexer = new DictionListEmployeeRelations(emplRelations);

            List<EmployeeContract> contracts = EmployeeService.EmployeeContractService.GetEmployeeContracts(ids, aBegin, aEnd);
            ContractIndexer = new DictionListEmployeesContract(contracts);


            // applly relations
            EmployeeRelation relationWorld = null;
            bool bExistsRelation = false;
            bool bExistsContract = false;
            bool bNotExistsAbsence = true;

            _listweeks = new List<EmployeeWeek>();
            EmployeeWeek emplWeek = null;


            foreach (Employee empl in employees)
            {
                emplWeek = new EmployeeWeek(empl.ID, empl.FullName, aBegin, aEnd, empl.OrderHwgrID.HasValue ? empl.OrderHwgrID.Value : 0);
                emplWeek.LastSaldo = (int)Math.Round(empl.BalanceHours);
                bExistsRelation = false;

                foreach (EmployeeDay d in emplWeek.DaysList)
                {
                    relationWorld = relationIndexer.GetRelationEntity(empl.ID, d.Date);
                    if (relationWorld != null)
                    {
                        d.StoreWorldId = swCountryManager.GetStoreWorldIdByStoreAndWorldId (relationWorld.StoreID, relationWorld.WorldID.Value);
                        d.StoreId = relationWorld.StoreID;
                    }

                    bExistsRelation |= d.HasRelation;
                }
                if (bExistsRelation)
                {
                    bExistsContract = ContractIndexer.FillEmployeeWeek(emplWeek);
                    if (bExistsContract)
                    {
                        bNotExistsAbsence = absenceIndexer.FillEmployeeWeek(emplWeek);

                        if (bNotExistsAbsence)
                        {
                            _listweeks.Add(emplWeek);
                        }
                    }
                }
            }

            FillEmployeeDayByStoreDay(storeid, aBegin, aEnd);

            _dictionWeek = EmployeeWeekProcessor.GetDictionary(_listweeks);
            _employeeids = EmployeeWeekProcessor.GetEmployeeIds(_listweeks);

            
            if (bPlanning)
                FillPlanningEmployeeWeeks(storeid, worldid, aBegin, aEnd);
            else
                FillActualEmployeeWeeks(storeid, worldid, aBegin, aEnd);

            //LastSaldoBuilder saldoBuilder = new LastSaldoBuilder();
            LastSaldoBuilder saldoBuilder = (IsAustria) ? new LastSaldoBuilderAustria() : new LastSaldoBuilder();


            
            saldoBuilder.FillLastSaldo(_dictionWeek, _employeeids, aBegin, bPlanning);

            EmployeeMonthWorkingTime monthData = new EmployeeMonthWorkingTime(EmployeeService.EmployeeTimeService as EmployeeTimeService);
            monthData.IsPlanning = bPlanning;
            monthData.CurrentMonday = aBegin;
            CacheEmployeesAllIn managerAllIn = new CacheEmployeesAllIn();
            managerAllIn.LoadByStoreRelation(storeid);

            foreach (EmployeeWeek ew in _listweeks)
            {
               ew.WorkingTimeByMonth = monthData.GetMonthWorkingTime(ew.EmployeeId);
               ew.CountSaturday = (byte)monthData.CountSaturday;
               ew.CountSunday = (byte)monthData.CountSunday;
                  
               ew.WorkingDaysBefore = (byte)monthData.WorkingDaysBefore;
               ew.WorkingDaysAfter = (byte)monthData.WorkingDaysAfter;
               ew.AllIn = managerAllIn.GetAllIn(ew.EmployeeId, aBegin, aEnd);

            }

            return _listweeks;
        }

        public List<EmployeeWeek> BuildAndFillPlanningWeek(long storeid, long worldid, DateTime aBegin, DateTime aEnd)
        {
            BuildEmployeeWeeks(storeid, worldid, aBegin, aEnd, true);
            return _listweeks;
            //return FillPlanningEmployeeWeeks(storeid, worldid, aBegin, aEnd);
        }

        public List<EmployeeWeek> FillPlanningEmployeeWeeks(long storeid, long worldid, DateTime aBegin, DateTime aEnd)
        {
            if (_listweeks != null && _listweeks.Count > 0)
            {

                FillEmployeeWeeks(aBegin, aEnd, true);
//                EmployeeTimeService timeService = EmployeeService.EmployeeTimeService as EmployeeTimeService;

//                timeService.FillEmployeeWeeks(_listweeks, _employeeids, _dictionWeek, aBegin, aEnd, true);

                if (LoadWeeks)
                {
                    EmployeeTimeService timeService = EmployeeService.EmployeeTimeService as EmployeeTimeService;

                    EmployeeWeekTimePlanningService weekService = timeService.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService;

                    List<EmployeeWeekTimePlanning> planningweeks = weekService.GetEmployeesWeekState(_employeeids, aBegin, aEnd);

                    if (planningweeks != null && planningweeks.Count > 0)
                    {
                        EmployeeWeek emplweek = null;
                        foreach (EmployeeWeekTimePlanning week in planningweeks)
                        {
                            if (_dictionWeek.TryGetValue(week.EmployeeID , out emplweek))
                            {
                                emplweek.NewWeek = false;

                                EmployeeWeekProcessor.Assign(week, emplweek);
                            }
                        }
                    }


                }
            }
            return _listweeks;
        }

        public List<EmployeeWeek> BuildAndFillActualWeek(long storeid, long worldid, DateTime aBegin, DateTime aEnd)
        {
            BuildEmployeeWeeks(storeid, worldid, aBegin, aEnd, false);
            return _listweeks;
            //return FillActualEmployeeWeeks(storeid, worldid, aBegin, aEnd);
        }

        public List<EmployeeWeek> FillActualEmployeeWeeks(long storeid, long worldid, DateTime aBegin, DateTime aEnd)
        {
            if (_listweeks != null && _listweeks.Count > 0)
            {
               
                //EmployeeTimeService timeService = EmployeeService.EmployeeTimeService as EmployeeTimeService;
                //timeService.FillEmployeeWeeks(_listweeks, aBegin, aEnd, false);

                FillEmployeeWeeks(aBegin, aEnd, false);

                if (LoadWeeks)
                {
                    EmployeeTimeService timeService = EmployeeService.EmployeeTimeService as EmployeeTimeService;

                    EmployeeWeekTimeRecordingService weekService = timeService.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;

                    List<EmployeeWeekTimeRecording> weeks = weekService.GetEmployeesWeekState(_employeeids, aBegin, aEnd);

                    if (weeks != null && weeks.Count > 0)
                    {
                        EmployeeWeek emplweek = null;
                        foreach (EmployeeWeekTimeRecording week in weeks)
                        {
                            if (_dictionWeek.TryGetValue(week.EmployeeID, out emplweek))
                            {
                                emplweek.NewWeek = false;
                                //emplweek.CustomEdit = week.CustomEdit;
                                //if (week.CustomEdit)
                                //    emplweek.Saldo = week.Saldo;

                                EmployeeWeekProcessor.Assign(week, emplweek);
                            }
                        }
                    }


                }
            }
            return _listweeks;
        }

        private void FillEmployeeDayByStoreDay(long storeid, DateTime aBegin, DateTime aEnd)
        {
            long countryid = EmployeeService.StoreService.GetCountryByStoreId(storeid);
            List<StoreToWorld> lst = EmployeeService.StoreWorldService.FindAllForCountry(countryid);
            Dictionary<long, StoreToWorld> _diction = new Dictionary<long, StoreToWorld>();
            if (lst != null)
            {
                foreach (StoreToWorld sw in lst)
                {
                    _diction[sw.ID] = sw;
                }
            }
            StoreDaysList dayslist = EmployeeService.StoreService.GetStoreDays(storeid, aBegin, aEnd);
            Dictionary<long, StoreDaysList> _dictionDays = new Dictionary<long, StoreDaysList>();
            _dictionDays[storeid] = dayslist;
            if (_listweeks != null)
            {
                foreach (EmployeeWeek ew in _listweeks)
                {
                    foreach (EmployeeDay ed in ew.DaysList)
                    {
                        if (ed.StoreWorldId > 0)
                        {
                            StoreToWorld sw = _diction[ed.StoreWorldId];
                            if (!_dictionDays.TryGetValue(sw.StoreID, out dayslist))
                            {
                                dayslist = EmployeeService.StoreService.GetStoreDays(sw.StoreID, aBegin, aEnd);
                                _dictionDays[sw.StoreID] = dayslist;
                            }

                            if (_dictionDays.TryGetValue(sw.StoreID, out dayslist))
                            {
                                ed.StoreDay = dayslist[ed.Date];
                            }
                        }
                    }
                }
            }

        }


        public void FillEmployeeWeeks(DateTime begin, DateTime end,  bool bPlanning)
        {
            if (_listweeks == null || _listweeks.Count == 0)
            {
                return;
            }

            List<EmployeeTimeRange> lstRanges = new List<EmployeeTimeRange>();
            EmployeeTimeRange range = null;

            #region Load entities

            if (bPlanning)
            {
                List<WorkingTimePlanning> lstWorks =
                    EmployeeService.EmployeeTimeService.WorkingTimePlanningService.GetWorkingTimePlanningsByEmployeeIds(_employeeids, begin, end);
                List<AbsenceTimePlanning> lstAbsences =
                    EmployeeService.EmployeeTimeService.AbsenceTimePlanningService.GetAbsenceTimePlanningsByEmployeeIds(_employeeids, begin, end);

                if (lstWorks != null)
                {
                    foreach (WorkingTimePlanning entity in lstWorks)
                    {
                        lstRanges.Add(new EmployeeTimeRange(entity));
                    }
                }
                if (lstAbsences != null)
                {
                    foreach (AbsenceTimePlanning entity in lstAbsences)
                    {
                        lstRanges.Add(new EmployeeTimeRange(entity));
                    }
                }
            }
            else
            {
                List<WorkingTimeRecording> lstWorks =
                    EmployeeService.EmployeeTimeService.WorkingTimeRecordingService.GetWorkingTimeRecordingsByEmployeeIds(_employeeids, begin, end);
                List<AbsenceTimeRecording> lstAbsences =
                    EmployeeService.EmployeeTimeService.AbsenceTimeRecordingService.GetAbsenceTimeRecordingsByEmployeeIds(_employeeids, begin, end);
                if (lstWorks != null)
                {
                    foreach (WorkingTimeRecording entity in lstWorks)
                    {
                        lstRanges.Add(new EmployeeTimeRange(entity));
                    }
                }
                if (lstAbsences != null)
                {
                    foreach (AbsenceTimeRecording entity in lstAbsences)
                    {
                        lstRanges.Add(new EmployeeTimeRange(entity));
                    }
                }
            }

            #endregion

            lstRanges.Sort();

            if (lstRanges.Count > 0)
            {
                EmployeeWeek week = null;
                EmployeeDay emplday = null;
                for (int i = 0; i < lstRanges.Count; i++)
                {
                    range = lstRanges[i];
                    if (week == null || (week.EmployeeId != range.EmployeeID))
                    {
                        week = null;
                        _dictionWeek.TryGetValue(range.EmployeeID, out week);
                    }

                    if (week != null)
                    {
                        emplday = week.GetDay(range.Date);
                        if (emplday != null)
                        {
                            if (emplday.TimeList == null)
                            {
                                emplday.TimeList = new List<EmployeeTimeRange>();
                            }
                            emplday.TimeList.Add(range);
                        }
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////

        public EmployeeWeek BuildEmployeeWeek(long emplid, DateTime aBeginWeek)
        {
            if (aBeginWeek.DayOfWeek != DayOfWeek.Monday)
                throw new ArgumentException();

            if (emplid <= 0)
                throw new ArgumentException();


            Employee empl = EmployeeService.FindById(emplid);

            if (empl == null)
                throw new ArgumentNullException();

            long[] ids = new long[] { emplid };
            DateTime aEndWeek = DateTimeHelper.GetSunday(aBeginWeek);
            EmployeeRelationService relationService = EmployeeService.EmployeeRelationService as EmployeeRelationService;
            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                EmployeeService.EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(ids, aBeginWeek, aEndWeek);
            EmployeeLongTimeAbsenceIndexer absenceIndexer = new EmployeeLongTimeAbsenceIndexer(emplLongTimeAbsences);

            List<EmployeeRelation> emplRelations = relationService.GetEmployeeRelationsByEmployeeIds(ids, aBeginWeek, aEndWeek);
            DictionListEmployeeRelations relationIndexer = new DictionListEmployeeRelations(emplRelations);

            List<EmployeeContract> contracts = EmployeeService.EmployeeContractService.GetEmployeeContracts(ids, aBeginWeek, aEndWeek);
            DictionListEmployeesContract contractIndexer = new DictionListEmployeesContract(contracts);

            EmployeeWeek emplWeek = new EmployeeWeek(emplid, "", aBeginWeek,aEndWeek, empl.OrderHwgrID.HasValue ? empl.OrderHwgrID.Value : 0);

            
            EmployeeRelation relationWorld = null;
            bool bExistsRelation = false;
            bool bExistsContract = false;
            bool bNotExistsAbsence = true;

            if (swCountryManager == null)
            {
                long countryid = EmployeeService.StoreService.GetCountryByStoreId(empl.MainStoreID);
                swCountryManager = new CountryStoreWorldManager(EmployeeService.StoreWorldService);
                swCountryManager.CountryId = countryid;
            }

            bExistsContract = contractIndexer.FillEmployeeWeek(emplWeek);
            if (bExistsContract)
            {
                bNotExistsAbsence = absenceIndexer.FillEmployeeWeek(emplWeek);
                if (bNotExistsAbsence)
                {
                    foreach (EmployeeDay d in emplWeek.DaysList)
                    {
                        relationWorld = relationIndexer.GetRelationEntity(emplid, d.Date);
                        if (relationWorld != null)
                        {
                            d.StoreWorldId = swCountryManager.GetStoreWorldIdByStoreAndWorldId(relationWorld.StoreID, relationWorld.WorldID.Value);
                            d.StoreId = relationWorld.StoreID;
                        }

                        bExistsRelation |= d.HasRelation;
                    }
                }
            }
            if (!bExistsContract || !bExistsRelation || !bNotExistsAbsence)
                emplWeek = null;

            return emplWeek;
        }
        Dictionary<long, StoreDaysList> m_dictionDays = new Dictionary<long, StoreDaysList>();
        CountryStoreWorldManager swCountryManager = null;
        private void FillEmployeeDayByStoreDay(EmployeeWeek emplweek)
        {
            if (emplweek != null)
            {
                StoreDaysList dayslist = null;
                foreach (EmployeeDay day in emplweek.DaysList)
                {
                    if (day.HasRelation)
                    {
                        if (!m_dictionDays.TryGetValue(day.StoreId, out dayslist))
                        {
                            dayslist = EmployeeService.StoreService.GetStoreDays(day.StoreId, emplweek.BeginDate, emplweek.EndDate.AddDays(356));
                            m_dictionDays[day.StoreId] = dayslist;
                        }
                        if (m_dictionDays.TryGetValue(day.StoreId, out dayslist))
                        {
                            day.StoreDay = dayslist[day.Date];
                        }
                    }
                }
            }
        }
    }
}
