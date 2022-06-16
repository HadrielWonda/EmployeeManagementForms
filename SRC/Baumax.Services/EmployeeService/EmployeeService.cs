using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Dao;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using System.Collections;
using Baumax.Contract.TimePlanning;
using Baumax.Services._HelperObjects;
using Spring.Transaction.Interceptor;
using Baumax.Contract.Exceptions;
using Baumax.AppServer.Environment;
using Baumax.Contract.PlanningAndRecording;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using System.Diagnostics;
using Baumax.Services._HelperObjects.ExEntity;

namespace Baumax.Services
{
    [ServiceID("EC1DD1C0-EECC-4944-A669-2BB63C8E5463")]
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private static bool _IsRunningEmployeeImport = false;
        private static Object _SyncIsRunningEmployeeImport = new Object();

        private static bool IsRunningEmployeeImport
        {
            get { return _IsRunningEmployeeImport; }
            set 
            { 
                lock (_SyncIsRunningEmployeeImport)
                {
                    if (_IsRunningEmployeeImport != value)
                        _IsRunningEmployeeImport = value;
                }
            }
        }

        private IAbsenceService _absenceService;
        private IEmployeeRelationService _employeeRelationService;
        private IEmployeeContractService _employeeContractService;
        private ILongTimeAbsenceService _longTimeAbsenceService;
        private IEmployeeLongTimeAbsenceService _employeeLongTimeAbsenceService;
        private IEmployeeTimeService _employeeTimeService;
        private IStoreToWorldService _storeworldService;
        private IStoreService _storeService;
        private IEmployeeAllInService _employeeAllInService;
        private IEmployeeHolidaysInfoService _employeeHolidaysInfoService;


        public IEmployeeHolidaysInfoService EmployeeHolidaysInfoService
        {
            get { return _employeeHolidaysInfoService; }
        }
        public IEmployeeDao EmployeeDao
        {
            get { return (IEmployeeDao) Dao; }
        }
        public IStoreToWorldService StoreWorldService
        {
            get { return _storeworldService; }
        }

        public IStoreService StoreService
        {
            get { return _storeService; }
        }

        public IAbsenceService AbsenceService
        {
            get { return _absenceService; }
        }

        public IEmployeeRelationService EmployeeRelationService
        {
            get { return _employeeRelationService; }
        }

        public IEmployeeContractService EmployeeContractService
        {
            get { return _employeeContractService; }
        }

        public ILongTimeAbsenceService LongTimeAbsenceService
        {
            get { return _longTimeAbsenceService; }
        }

        public IEmployeeLongTimeAbsenceService EmployeeLongTimeAbsenceService
        {
            get { return _employeeLongTimeAbsenceService; }
        }

        public IEmployeeTimeService EmployeeTimeService
        {
            get { return _employeeTimeService; }
        }

        public IEmployeeAllInService EmployeeAllInService
        {
            get { return _employeeAllInService; }
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeLongTimeAbsence> GetLongAbsenceEmployees(long storeID, DateTime begin, DateTime end)
        {
            List<EmployeeLongTimeAbsence> list = new List<EmployeeLongTimeAbsence>();
            list.AddRange(GetEmployeeLongTimeBody(storeID, begin, end));
            return list;
        }

        #region 3.08.2007 Igor Yakubov

        [AccessType(AccessType.Read)]
        public EmployeeLongTimeAbsence[] GetLongAbsenceEmployees(long storeid, DateTime? date)
        {
            return GetEmployeeLongTimeBody(storeid, date, null);
        }

        private EmployeeLongTimeAbsence[] GetEmployeeLongTimeBody(long storeid, DateTime? date, DateTime? date2)
        {
            try
            {
                // select all employee by store
                EmployeeShortView[] empls = GetEmployeesNames(storeid);
                Dictionary<long, string> emplNames = new Dictionary<long, string>();
                if (empls != null)
                {
                    // full hash employee names
                    foreach (EmployeeShortView empl in empls)
                    {
                        emplNames[empl.EmployeeID] = empl.FullName;
                    }
                }
                // select all long absence TO-DO : need select by store
                List<EmployeeLongTimeAbsence> employeeAbsences = null;
                if (date == null)
                {
                    employeeAbsences = EmployeeLongTimeAbsenceService.FindAll();
                }
                else if (date.HasValue && date2.HasValue)
                {
                    employeeAbsences = EmployeeLongTimeAbsenceService.FindByNamedParam(
                        "entity.BeginTime <= :end and :start <=entity.EndTime",
                        new string[] {"start", "end"}, new object[] {date.Value, date2.Value});
                }
                else
                {
                    employeeAbsences = EmployeeLongTimeAbsenceService.FindByNamedParam(
                        null,
                        " entity.BeginTime <= :d and :d <=entity.EndTime",
                        null, "d", date.Value);
                }
                //select entity from EmployeeLongTimeAbsence entity where 

                List<LongTimeAbsence> defaultLongTime = LongTimeAbsenceService.FindAll();
                Dictionary<long, string> _dictionLongTimeAbsence = new Dictionary<long, string>();
                if (defaultLongTime != null)
                {
                    foreach (LongTimeAbsence absen in defaultLongTime)
                    {
                        _dictionLongTimeAbsence[absen.ID] = absen.CodeName;
                    }
                }

                List<EmployeeLongTimeAbsence> resultAbsences = new List<EmployeeLongTimeAbsence>();
                if (employeeAbsences != null)
                {
                    // fill amployee name on long time absences
                    EmployeeLongTimeAbsence longAbsence;
                    string sEmployeeName = String.Empty;
                    string absencename = string.Empty;

                    for (int i = 0; i < employeeAbsences.Count; i++)
                    {
                        longAbsence = (EmployeeLongTimeAbsence) employeeAbsences[i];
                        if (emplNames.TryGetValue(longAbsence.EmployeeID, out sEmployeeName))
                        {
                            longAbsence.EmployeeFullName = sEmployeeName;

                            if (_dictionLongTimeAbsence.TryGetValue(longAbsence.LongTimeAbsenceID, out absencename))
                            {
                                longAbsence.LongTimeAbsenceName = absencename;
                            }
                            resultAbsences.Add(longAbsence);
                        }
                    }
                }
                // TO-DO: 
                EmployeeLongTimeAbsence[] res = resultAbsences.ToArray();
                return res;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public EmployeeShortView[] GetEmployeesNames(long storeid)
        {
            try
            {
                return ((IEmployeeDao) Dao).GetEmployeesNames(storeid);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        #endregion

        [AccessType(AccessType.Import)]
        public ImportEmployeeResult ImportEmployee(List<ImportEmployeeData> list)
        {
            ImportEmployeeResult returnObject = null;
            if (IsRunningEmployeeImport)
                throw new AnotherImportRunning();
            IsRunningEmployeeImport = true;
            try
            {
                returnObject = ((IEmployeeDao)Dao).ImportEmployee(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningEmployeeImport = false;
            }
            //===============================================
            EmployeeChanged[] modifiedEmployees = (EmployeeChanged[])returnObject.DataChanged;
            
            if (modifiedEmployees != null && modifiedEmployees.Length > 0)
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug("Mofified employee - " + modifiedEmployees.Length);
                    Log.Debug("Begin calculation : " + DateTime.Now.ToLongTimeString());
                }
                long[] ids = new long[modifiedEmployees.Length];
                for (int i = 0; i < modifiedEmployees.Length; i++)
                {
                    ids[i] = modifiedEmployees[i].EmployeeID;
                }

                EmployeeBusinessObject.Recalculate(ids);
                if (Log.IsDebugEnabled )
                    Log.Debug("End calculation : " + DateTime.Now.ToLongTimeString());
            }


            //===============================================

            return returnObject ;


        }

        [AccessType(AccessType.Read)]
        public List<Employee> GetEmployeeTypedList(long storeID, DateTime? date, bool isAustria)
        {
            if (date.HasValue)
            {
                return GetTypedListFromIList(GetEmployeeList(storeID, date.Value, isAustria));
            }
            else
            {
                return FindByNamedParam(" entity.MainStoreID=:storeID ",
                                        new string[] {"storeID"}, new object[] {storeID});
            }
        }

        [AccessType(AccessType.Read)]
        public IList GetEmployeeList(long storeID, DateTime date, bool isAustria)
        {
            try
            {
                IList resultList = ((IEmployeeDao) Dao).GetEmployeeList (storeID, date);


                int Year = DateTimeHelper.GetYearByDate(date);
                int TodayYear = DateTimeHelper.GetYearByDate(DateTime.Today);
                DateTime beginYearDate = DateTimeHelper.GetBeginYearDate(Year);
                DateTime endYearDate = DateTimeHelper.GetEndYearDate(Year);
                
                

                if (isAustria && resultList != null)
                {
                    List<EmlpoyeeHolidaysSumDays> lst = (_storeService as StoreService).EmlpoyeeHolidaysSumInfoGet(storeID, beginYearDate, endYearDate, DateTime.Today);

                    Dictionary<long, EmlpoyeeHolidaysSumDays> dictionHolidaysSum =
                        EmlpoyeeHolidaysSumDays.BuildDiction(lst);

                    EmlpoyeeHolidaysSumDays sum = null;
                    foreach (Employee employee in resultList)
                    {
                        employee.IsAustria = true;
                        sum = null;
                        if (!dictionHolidaysSum.TryGetValue (employee.ID, out sum))
                        {
                            sum = (_storeService as StoreService).EmlpoyeeHolidaysSumInfoByEmployeeIDGet(employee.ID, beginYearDate, endYearDate, date);
                        }

                        if (sum != null)
                        {
                            if (Year == TodayYear)
                            {
                                //employee.SpareHolidaysExc = employee.AvailableHolidays;

                                employee.SpareHolidaysInc = employee.SpareHolidaysExc - sum.TimePlanning;
                            }
                            employee.UsedHolidays = sum.TimeRecording + sum.TimePlanning;
                        }
                    }
                }
                else if (!isAustria && resultList != null)
                {
//                    EmployeeHolidaysInfoService holidays_service = _employeeHolidaysInfoService as EmployeeHolidaysInfoService;
                    
                    List<EmployeeHolidaysInfo> info = ExEmployeeHolidays.GetAllByStore (storeID, Year);// _employeeHolidaysInfoService.GetByStoreYear(storeID, Year);
                    Dictionary<long, EmployeeHolidaysInfo> dict = EmployeeHolidaysInfo.BuildDiction(info);
                    List<EmlpoyeeHolidaysSumDays> lst = (_storeService as StoreService) .EmlpoyeeHolidaysSumInfoGet(storeID, beginYearDate, endYearDate, DateTime.Today);
                    Dictionary<long, EmlpoyeeHolidaysSumDays> holydInfo = EmlpoyeeHolidaysSumDays.BuildDiction(lst);

                    EmployeeWeekTimeRecording week_recording = null;
                    EmployeeWeekTimeRecordingService week_service = ServerEnvironment.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;
                    foreach(Employee employee in resultList)
                    {
                        EmployeeHolidaysInfo holInf = info != null && dict.ContainsKey(employee.ID)
                            ? dict[employee.ID]
                            : _employeeHolidaysInfoService.CreateEntity();
                        
                        employee.OldHolidays = holInf.OldHolidays;
                        employee.NewHolidays = holInf.NewHolidays;
                        employee.AvailableHolidays = employee.OldHolidays + employee.NewHolidays;

                        if (lst != null && holydInfo.ContainsKey(employee.ID))
                        {
                            decimal planning = holydInfo[employee.ID].TimePlanning, recording = holydInfo[employee.ID].TimeRecording;
                            employee.UsedHolidays = planning + recording;
                            employee.SpareHolidaysExc = employee.AvailableHolidays - recording;
                            employee.SpareHolidaysInc = employee.AvailableHolidays - recording - planning;
                        }

                        week_recording = week_service.GetLastWeek(employee.ID);
                        if (week_recording != null)
                            employee.BalanceHours = Convert.ToDecimal(week_recording.Saldo);
                    }
                }

                return resultList;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }


        public List<Employee> GetEmployeeList(long storeid)
        {
            return GetTypedListFromIList(((IEmployeeDao)Dao).GetEmployeeList(storeid, DateTime.Today));
        }
        [AccessType(AccessType.Write)]
        public Employee Assign(Employee employee, long storeID, DateTime beginTime, DateTime endDate)
        {
            return Assign(employee, storeID, null, null, beginTime, endDate);
        }

        [AccessType(AccessType.Write)]
        public Employee Assign(Employee employee, long storeID, long? worldID, DateTime beginTime, DateTime endDate)
        {
            return Assign(employee, storeID, worldID, null, beginTime, endDate);
        }

        [AccessType(AccessType.Write)]
        public Employee Assign(Employee employee, long storeID, long? worldID, long? hwgrID, DateTime beginTime,
                               DateTime endDate)
        {
            try
            {
                return ((IEmployeeDao) Dao).Assign(employee, storeID, worldID, hwgrID, beginTime, endDate);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        public void AssignHwgr(long employeeId, long? hwgrID)
        {
            try
            {
                ((IEmployeeDao)Dao).AssignHwgr(employeeId, hwgrID);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        public void Merge(long employeeIDInternal, long employeeIDExternal)
        {
            try
            {
                ((IEmployeeDao) Dao).Merge(employeeIDInternal, employeeIDExternal);
            }
            catch (EmployeeMergeException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EmployeeMergeException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public Employee GetEmployeeByID(long employeeID, DateTime date)
        {
            try
            {
                return ((IEmployeeDao) Dao).GetEmployeeByID(employeeID, date);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        


        [AccessType(AccessType.Read)]
        public List<EmployeePlanningWeek> GetTimePlannignEmployee3(long storeid, DateTime aBegin, DateTime aEnd)
        {
            // list of all employee for storeid
            IList employees = EmployeeDao.GetPlanningEmployees(storeid, aBegin, aEnd);

            if (employees == null || employees.Count == 0)
            {
                return null;
            }

            List<EmployeeRelation> emplRelations =
                EmployeeRelationService.GetEmployeeRelationsByStore(storeid, aBegin, aEnd);

            StoreWorldManager swmanager = new StoreWorldManager(_storeworldService);
            swmanager.StoreId = storeid;


            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);


            List<Employee> resultList = new List<Employee>(employees.Count);

            Dictionary<long, EmployeeLongTimeAbsence> diction =
                EmployeeLongTimeAbsenceProcessor.GetEmployeeHasAbsences(emplLongTimeAbsences, aBegin, aEnd);

            foreach (Employee empl in employees)
            {
                resultList.Add(empl);
            }

            List<EmployeePlanningWeek> employeesWeek = new List<EmployeePlanningWeek>();
            EmployeePlanningWeek emplWeek = null;
            // applly relations
            foreach (Employee empl in resultList)
            {
                emplWeek = new EmployeePlanningWeek(empl.ID, empl.FullName, aBegin, aEnd, empl.OrderHwgrID ?? 0);
                emplWeek.LastSaldo = (int) Math.Round(empl.BalanceHours);
                foreach (EmployeeRelation rel in emplRelations)
                {
                    if (rel.EmployeeID == empl.ID)
                    {
                        foreach (EmployeePlanningDay d in emplWeek.Days.Values)
                        {
                            if (rel.IsContainDate(d.Date))
                            {
                                d.HasRelation = true;
                                d.WorldId = swmanager.GetStoreWorldIdByWorldId(rel.WorldID.Value);
                                d.StoreId = rel.StoreID;
                            }
                        }
                    }
                }
                employeesWeek.Add(emplWeek);
            }

            // applly contracts
            List<long> idsList = GetIDsFromEntityList(resultList);

            if (idsList != null && idsList.Count > 0)
            {
                long[] ids = idsList.ToArray();

                List<EmployeeContract> contracts = EmployeeContractService.GetEmployeeContracts(ids, aBegin, aEnd);
                if (contracts != null && contracts.Count > 0)
                {
                    foreach (EmployeePlanningWeek emplweek in employeesWeek)
                    {
                        foreach (EmployeeContract contract in contracts)
                        {
                            if (contract.EmployeeID == emplweek.EmployeeId)
                            {
                                foreach (EmployeePlanningDay d in emplweek.Days.Values)
                                {
                                    if (contract.IsContainDate(d.Date))
                                    {
                                        d.HasContract = true;
                                        d.ContractHoursPerWeek = contract.ContractWorkingHours;
                                        if (emplweek.ContractHoursPerWeek == 0)
                                        {
                                            emplweek.ContractHoursPerWeek =
                                                Convert.ToInt32(contract.ContractWorkingHours*60);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // applly longtimeabsence

            if (emplLongTimeAbsences != null && emplLongTimeAbsences.Count > 0)
            {
                foreach (EmployeePlanningWeek emplweek in employeesWeek)
                {
                    foreach (EmployeeLongTimeAbsence absence in emplLongTimeAbsences)
                    {
                        if (absence.EmployeeID == emplweek.EmployeeId)
                        {
                            foreach (EmployeePlanningDay d in emplweek.Days.Values)
                            {
                                if (absence.IsContainDate(d.Date))
                                {
                                    d.HasLongAbsence = true;
                                    d.LongAbsenceId = absence.LongTimeAbsenceID;
                                }
                            }
                        }
                    }
                }
            }


            List<EmployeePlanningWeek> tempList = new List<EmployeePlanningWeek>();
            foreach (EmployeePlanningWeek emplweek in employeesWeek)
            {
                bool relation = false;
                bool absence = true;
                bool contract = false;
                foreach (EmployeePlanningDay d in emplweek.Days.Values)
                {
                    relation |= d.HasRelation;
                    absence &= d.HasLongAbsence;
                    contract |= d.HasContract;
                }

                if (!relation || absence || !contract)
                {
                    continue;
                }

                tempList.Add(emplweek);
            }

            employeesWeek = tempList;

            EmployeeTimeService.EmployeeWeekTimePlanningService.FillEmployeePlanningWeeks(employeesWeek);
            (EmployeeTimeService.EmployeeDayStatePlanningService as IInternalEmployeeDayStatePlanning).
                FillEmployeePlanningWeeks(employeesWeek, aBegin, aEnd);

            /*EmployeeTimeService timeservice = (EmployeeTimeService as EmployeeTimeService);
            foreach (EmployeePlanningWeek emplweek1 in employyesWeek)
            {
                int? value = timeservice.GetEmployeeLastVerifiedSaldo(emplweek1.EmployeeId, emplweek1.BeginDate);

                if (value.HasValue)
                    emplweek1.LastSaldo = value.Value;

            }*/
            Dictionary<long, EmployeePlanningWeek> _dict = new Dictionary<long, EmployeePlanningWeek>();
            long[] ids2 = new long[employeesWeek.Count];
            for (int i = 0; i < employeesWeek.Count; i++)
            {
                _dict[employeesWeek[i].EmployeeId] = employeesWeek[i];
                ids2[i] = employeesWeek[i].EmployeeId;
            }
            LastSaldoBuilder saldoBuilder = new LastSaldoBuilder();

            saldoBuilder.FillPlanningLastSaldo(_dict, ids2, aBegin);
            
            EmployeeMonthWorkingTime monthtimes =
                new EmployeeMonthWorkingTime(EmployeeTimeService as EmployeeTimeService);
            monthtimes.CurrentMonday = aBegin;

            CacheEmployeesAllIn managers = new CacheEmployeesAllIn();
            managers.LoadByStoreRelation(storeid);

            foreach (EmployeePlanningWeek week in employeesWeek)
            {
                week.WorkingTimeByMonth = monthtimes.GetMonthWorkingTime(week.EmployeeId);
                week.CountSunday = (byte) monthtimes.CountSunday;
                week.CountSaturday = (byte) monthtimes.CountSaturday;
                week.AllIn = managers.GetAllIn(week.EmployeeId, aBegin, aEnd);
                week.WorkingDaysBefore = (byte)monthtimes.WorkingDaysBefore;
                week.WorkingDaysAfter = (byte)monthtimes.WorkingDaysAfter;
            }



            return employeesWeek;
        }
        // GetTimePlannignEmployee2 with optimization
        [AccessType(AccessType.Read)]
        public List<EmployeePlanningWeek> GetTimePlannignEmployee2(long storeid, DateTime aBegin, DateTime aEnd)
        {
            //EmployeeBusinessObject.RecalculateAfterModifiedContractEndDate(new long[] { 76096 });
            Store store = ServerEnvironment.StoreService.FindById(storeid);

            if (store == null)
                return null;

            bool IsAustria = store.CountryID == ServerEnvironment.CountryService.AustriaCountryID;

            // list of all employee for storeid
            IList employees = EmployeeDao.GetPlanningEmployees(storeid, aBegin, aEnd);

            if (employees == null || employees.Count == 0)
            {
                return null;
            }

            //List<EmployeeRelation> emplRelations = EmployeeRelationService.GetEmployeeRelationsByStore(storeid, aBegin, aEnd);

            StoreWorldManager swmanager = new StoreWorldManager(_storeworldService);
            swmanager.StoreId = storeid;


            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);


            List<Employee> resultList = new List<Employee>(employees.Count);
            foreach (Employee empl in employees)
                resultList.Add(empl);


            //Dictionary<long, EmployeeLongTimeAbsence> diction =
            //    EmployeeLongTimeAbsenceProcessor.GetEmployeeHasAbsences(emplLongTimeAbsences, aBegin, aEnd);


            List<EmployeePlanningWeek> employeesWeek = new List<EmployeePlanningWeek>();
            EmployeePlanningWeek emplWeek = null;

            CacheListEmployeeRelations cache_relations = new CacheListEmployeeRelations();
            cache_relations.LoadByStore(storeid, aBegin, aEnd);
            CacheListEmployeeContracts cache_contracts = new CacheListEmployeeContracts();
            cache_contracts.LoadByStore(storeid, aBegin, aEnd);

            EmployeeLongTimeAbsenceIndexer cache_longabsences = new EmployeeLongTimeAbsenceIndexer(emplLongTimeAbsences);

            // applly relations
            EmployeeRelation relation = null;
            EmployeeContract contract = null;
            EmployeeLongTimeAbsence longabsence = null;
            bool bWholeWeekAbsence = true;
            foreach (Employee empl in resultList)
            {
                emplWeek = new EmployeePlanningWeek(empl.ID, empl.FullName, aBegin, aEnd, empl.OrderHwgrID ?? 0);
                emplWeek.LastSaldo = (int)Math.Round (empl.BalanceHours);
                bWholeWeekAbsence = true;
                foreach (EmployeePlanningDay d in emplWeek.Days.Values)
                {
                    relation = cache_relations.GetRelationEntity(empl.ID, d.Date);
                    if (relation != null)
                    {
                        d.HasRelation = true;
                        d.WorldId = swmanager.GetStoreWorldIdByWorldId(relation.WorldID.Value);
                        d.StoreId = relation.StoreID;
                    }
                    contract = cache_contracts.IsContain (empl.ID, d.Date);
                    if (contract != null)
                    {
                        d.HasContract = true;
                        d.ContractHoursPerWeek = contract.ContractWorkingHours;
                        if (emplWeek.ContractHoursPerWeek == 0)
                        {
                            emplWeek.ContractHoursPerWeek =
                                Convert.ToInt32(contract.ContractWorkingHours * 60);
                        }
                    }
                    longabsence = cache_longabsences.IsContain(empl.ID, d.Date);

                    if (longabsence != null)
                    {
                        d.HasLongAbsence = true;
                        d.LongAbsenceId = longabsence.LongTimeAbsenceID;
                    }
                    bWholeWeekAbsence &= d.HasLongAbsence;
                }
                if (!bWholeWeekAbsence) 
                    employeesWeek.Add(emplWeek);
            }

            EmployeeTimeService.EmployeeWeekTimePlanningService.FillEmployeePlanningWeeks(employeesWeek);
            (EmployeeTimeService.EmployeeDayStatePlanningService as IInternalEmployeeDayStatePlanning).
                FillEmployeePlanningWeeks(employeesWeek, aBegin, aEnd);

            
            Dictionary<long, EmployeePlanningWeek> _dict = new Dictionary<long, EmployeePlanningWeek>();
            long[] ids2 = new long[employeesWeek.Count];
            for (int i = 0; i < employeesWeek.Count; i++)
            {
                _dict[employeesWeek[i].EmployeeId] = employeesWeek[i];
                ids2[i] = employeesWeek[i].EmployeeId;
            }
            //LastSaldoBuilder saldoBuilder = new LastSaldoBuilder();
            LastSaldoBuilder saldoBuilder = (IsAustria) ? new LastSaldoBuilderAustria() : new LastSaldoBuilder();
            saldoBuilder.FillPlanningLastSaldo(_dict, ids2, aBegin);

            EmployeeMonthWorkingTime monthtimes =
                new EmployeeMonthWorkingTime(EmployeeTimeService as EmployeeTimeService);
            monthtimes.CurrentMonday = aBegin;

            CacheEmployeesAllIn managers = new CacheEmployeesAllIn();
            managers.LoadByStoreRelation(storeid);

            foreach (EmployeePlanningWeek week in employeesWeek)
            {
                //week.WorkingTimeByMonth = monthtimes.GetMonthWorkingTime(week.EmployeeId);
                //week.CountSunday = (byte)monthtimes.CountSunday;
                //week.CountSaturday = (byte)monthtimes.CountSaturday;
                week.AllIn = managers.GetAllIn(week.EmployeeId, aBegin, aEnd);
                //week.WorkingDaysBefore = (byte)monthtimes.WorkingDaysBefore;
                //week.WorkingDaysAfter = (byte)monthtimes.WorkingDaysAfter;
            }
            monthtimes.ProcessWeeks(employeesWeek, ids2);


            return employeesWeek;
        }
        [AccessType(AccessType.Read)]
        public List<EmployeePlanningWeek> GetTimePlannignEmployeeByWorld(long storeid, long worldid, DateTime aBegin,
                                                                         DateTime aEnd)
        {
            // list of all employee for storeid and world
            IList employees = EmployeeDao.GetPlanningEmployeesByWorld(storeid, worldid, aBegin, aEnd);

            if (employees == null && employees.Count == 0)
            {
                return null;
            }

            List<EmployeeRelation> emplRelations =
                EmployeeRelationService.GetEmployeeRelationsByStoreAndWorld(storeid, worldid, aBegin, aEnd);

            StoreWorldManager swmanager = new StoreWorldManager(_storeworldService);
            swmanager.StoreId = storeid;

            List<long> idsList = GetIDsFromEntityList(employees);

            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                EmployeeLongTimeAbsenceService.GetEmployeesHasLongTimeAbsence(idsList.ToArray(), aBegin, aEnd);


            List<Employee> resultList = new List<Employee>(employees.Count);

            Dictionary<long, EmployeeLongTimeAbsence> diction =
                EmployeeLongTimeAbsenceProcessor.GetEmployeeHasAbsences(emplLongTimeAbsences, aBegin, aEnd);
            // remove employee who have long absence for whole week
            foreach (Employee empl in employees)
            {
                if (diction.ContainsKey(empl.ID))
                {
                    for (int i = emplRelations.Count - 1; i >= 0; i--)
                    {
                        if (emplRelations[i].EmployeeID == empl.ID)
                        {
                            emplRelations.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    resultList.Add(empl);
                }
            }

            List<EmployeePlanningWeek> employyesWeek = new List<EmployeePlanningWeek>();
            EmployeePlanningWeek emplWeek = null;
            // applly relations
            foreach (Employee empl in resultList)
            {
                emplWeek = new EmployeePlanningWeek(empl.ID, empl.FullName, aBegin, aEnd, empl.OrderHwgrID ?? 0);
                emplWeek.LastSaldo = (int) Math.Round(empl.BalanceHours);

                foreach (EmployeeRelation rel in emplRelations)
                {
                    if (rel.EmployeeID == empl.ID)
                    {
                        foreach (EmployeePlanningDay d in emplWeek.Days.Values)
                        {
                            if (rel.IsContainDate(d.Date))
                            {
                                d.HasRelation = true;
                                //d.WorldId = rel.WorldID.Value;
                                d.WorldId = swmanager.GetStoreWorldIdByWorldId(rel.WorldID.Value);
                            }
                        }
                    }
                }
                employyesWeek.Add(emplWeek);
            }

            // applly contracts
            idsList = GetIDsFromEntityList(resultList);

            if (idsList != null && idsList.Count > 0)
            {
                long[] ids = idsList.ToArray();

                List<EmployeeContract> contracts = EmployeeContractService.GetEmployeeContracts(ids, aBegin, aEnd);
                if (contracts != null && contracts.Count > 0)
                {
                    foreach (EmployeePlanningWeek emplweek in employyesWeek)
                    {
                        foreach (EmployeeContract contract in contracts)
                        {
                            if (contract.EmployeeID == emplweek.EmployeeId)
                            {
                                foreach (EmployeePlanningDay d in emplweek.Days.Values)
                                {
                                    if (contract.IsContainDate(d.Date))
                                    {
                                        d.HasContract = true;
                                        d.ContractHoursPerWeek = contract.ContractWorkingHours;
                                        emplweek.ContractHoursPerWeek =
                                            Convert.ToInt32(contract.ContractWorkingHours*60);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // applly longtimeabsence

            if (emplLongTimeAbsences != null && emplLongTimeAbsences.Count > 0)
            {
                foreach (EmployeePlanningWeek emplweek in employyesWeek)
                {
                    foreach (EmployeeLongTimeAbsence absence in emplLongTimeAbsences)
                    {
                        if (absence.EmployeeID == emplweek.EmployeeId)
                        {
                            foreach (EmployeePlanningDay d in emplweek.Days.Values)
                            {
                                if (absence.IsContainDate(d.Date))
                                {
                                    d.HasLongAbsence = true;
                                    d.LongAbsenceId = absence.ID;
                                }
                            }
                        }
                    }
                }
            }


            List<EmployeePlanningWeek> tempList = new List<EmployeePlanningWeek>();
            foreach (EmployeePlanningWeek emplweek in employyesWeek)
            {
                bool relation = false;
                bool absence = true;
                bool contract = false;
                foreach (EmployeePlanningDay d in emplweek.Days.Values)
                {
                    relation |= d.HasRelation;
                    absence &= d.HasLongAbsence;
                    contract |= d.HasContract;
                }

                if (!relation || absence || !contract)
                {
                    continue;
                }

                tempList.Add(emplweek);
            }

            employyesWeek = tempList;

            EmployeeTimeService.EmployeeWeekTimePlanningService.FillEmployeePlanningWeeks(employyesWeek);
            (EmployeeTimeService.EmployeeDayStatePlanningService as IInternalEmployeeDayStatePlanning).
                FillEmployeePlanningWeeks(employyesWeek, aBegin, aEnd);

            return employyesWeek;
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeWeek> GetTimePlannignEmployeeByWorld2(long storeid, long worldid, DateTime aBegin,
                                                                  DateTime aEnd)
        {
            //EmployeeWeekBuilder builder = new EmployeeWeekBuilder(this);
            EmployeeWeekBuilder builder = new EmployeeWeekBuilder();
            return builder.BuildAndFillPlanningWeek(storeid, worldid, aBegin, aEnd);
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeWeek> GetTimeRecordingEmployeeByWorld(long storeid, long worldid, DateTime aBegin,
                                                                  DateTime aEnd)
        {

            //EmployeeWeekBuilder builder = new EmployeeWeekBuilder(this);
            EmployeeWeekBuilder builder = new EmployeeWeekBuilder();
            builder.LoadWeeks = true;
            return builder.BuildAndFillActualWeek(storeid, worldid, aBegin, aEnd);

        }

        [AccessType(AccessType.Read)]
        public bool HasWorkingOrAbsenceTime(long employeeID, DateTime beginTime, DateTime endTime)
        {
            try
            {
                return ((IEmployeeDao) Dao).HasWorkingOrAbsenceTime(employeeID, beginTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AccessType(AccessType.Read)]
        public bool HasWorkingOrAbsenceTimeEx(long employeeID, DateTime beginTime, DateTime endTime)
        {
            try
            {
                return ((IEmployeeDao)Dao).HasWorkingOrAbsenceTimeEx(employeeID, beginTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AccessType(AccessType.Read)]
        public long[][] GetEmployeeToMergeList()
        {
            try
            {
                return ((IEmployeeDao) Dao).GetEmployeeToMergeList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AccessType(AccessType.Write)]
        [Transaction]
        public Employee SaveExternalEmployee(Employee employee, DateTime filterDate)
        {
            if (employee == null) return null;

            if (employee.Import) return null;

            if (employee.IsNew)
                return InsertExternalEmployee(employee, filterDate);

            ((IEmployeeDao)Dao).Update(employee);

            DateTime maxDate = EmployeeTimeService.GetMaxDateOfPlanningOrRecording(employee.ID);

            //ListEmployeeContracts contracts = new ListEmployeeContracts(EmployeeContractService, employee.ID);

            //ListEmployeeRelations relations = new ListEmployeeRelations(EmployeeRelationService, employee.ID);


            EmployeeContract contract = EmployeeContractService.FindById(employee.EmployeeContractID);

            // not valid contract
            if (contract == null) return null;

            if (contract.ContractBegin != employee.ContractBegin ||
                contract.ContractEnd != employee.ContractEnd ||
                contract.ContractWorkingHours != employee.ContractWorkingHours )
            {

                if (contract.ContractBegin < employee.ContractBegin)
                {
                    if (HasWorkingOrAbsenceTimeEx(employee.ID, contract.ContractBegin, employee.ContractBegin.AddDays(-1)))
                    {
                        throw new ValidationException("ErrorNewContractTimeInvalid", null);
                    }
                }
                if (contract.ContractEnd > employee.ContractEnd)
                {
                    if (HasWorkingOrAbsenceTimeEx(employee.ID, employee.ContractEnd.AddDays(1), contract.ContractEnd))
                    {
                        throw new ValidationException("ErrorNewContractTimeInvalid", null);
                    }
                }

                contract.ContractBegin = employee.ContractBegin;
                contract.ContractEnd = employee.ContractEnd;
                contract.ContractWorkingHours = employee.ContractWorkingHours;



                EmployeeContractService.Update(contract);


                ListEmployeeContracts contracts = new ListEmployeeContracts(EmployeeContractService, employee.ID);
                ListEmployeeRelations relations = new ListEmployeeRelations(EmployeeRelationService, employee.ID);

                contracts.GetUnbreakContracts().CheckAndModifyRelations(relations, EmployeeRelationService);

            }





            return GetEmployeeByID(employee.ID, filterDate); 

        }
        public Employee InsertExternalEmployee(Employee employee, DateTime filterDate)
        {
            if (employee == null) return null;
            if (!employee.IsNew) return null;

            ((IEmployeeDao)Dao).Save(employee);

            
            


            EmployeeContract contract = new EmployeeContract(employee.ContractBegin, employee.ContractEnd, employee.ContractWorkingHours, employee.ID);

            EmployeeContractService.Save(contract);

            int today_year = DateTimeHelper.GetYearByDate(DateTime.Today);
            int begin_year = DateTimeHelper.GetYearByDate(employee.ContractBegin);
            int end_year = DateTimeHelper.GetYearByDate(employee.ContractEnd);
            int year = today_year ;
            if (begin_year <= today_year && today_year <= end_year)
                year = today_year;
            else if (today_year < begin_year)
                year = begin_year;
            else year = end_year;


            //employee.EmployeeContractID = contract.ID;

            EmployeeRelation relation = new EmployeeRelation(employee.ContractBegin, employee.ContractEnd, 0, employee.MainStoreID, employee.ID, employee.WorldID.Value);
            relation.HWGR_ID = null;

            EmployeeRelationService.Save(relation);

            //employee.EmployeeRelationsID = relation.ID;

            ExEmployeeHolidays holidays = new ExEmployeeHolidays(employee.ID, year);

            holidays.UpdateFromEmployee(employee);

            return GetEmployeeByID (employee.ID, filterDate);
        }

        protected override bool Validate(Employee entity)
        {
            if (entity != null && !entity.IsNew)
            {
                EmployeeContract contract = _employeeContractService.FindById(entity.EmployeeContractID);
                if (contract.ContractBegin < entity.ContractBegin &&
                    HasWorkingOrAbsenceTime(entity.ID, contract.ContractBegin, entity.ContractBegin.AddDays(-1)))
                {
                    throw new ValidationException("ErrorNewContractTimeInvalid", null);
                }
                if (contract.ContractEnd > entity.ContractEnd &&
                    HasWorkingOrAbsenceTime(entity.ID, entity.ContractEnd.AddDays(1), contract.ContractEnd))
                {
                    throw new ValidationException("ErrorNewContractTimeInvalid", null);
                }
            }
            return base.Validate(entity);
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        [Obsolete("Use SaveEmployeeHolidays(EmployeeHolidaysInfo info)")]
        public void SaveEmployeeHolidays(long emplid, decimal oldHolidays, decimal newHolidays, decimal? usedHolidays,
                                         decimal? holidaysInc, decimal? holidaysExc)
        {
            try
            {
                Employee employee = FindById(emplid);

                Debug.Assert(employee != null);

                if (employee == null)
                    return ;

                long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(employee.MainStoreID);
                if (countryid == ServerEnvironment.CountryService.AustriaCountryID)
                    return ;

                EmployeeHolidaysInfo holiday_info = ExEmployeeHolidays.UpdateNewOldHolidays(emplid, DateTimeHelper.GetYearByDate(DateTime.Today), Convert.ToDouble(oldHolidays), Convert.ToDouble(newHolidays));

                Debug.Assert(holiday_info != null);

                //holiday_info.FillEmployee(employee);

                //return employee;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }
        [AccessType(AccessType.Write)]
        [Transaction]
        public EmployeeHolidaysInfo SaveEmployeeHolidays(EmployeeHolidaysInfo info)
        {
            if (info == null)
                throw new ArgumentNullException();

            try
            {
                Employee employee = FindById(info.EmployeeID);

                Debug.Assert(employee != null);

                if (employee == null)
                    return null;

                long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(employee.MainStoreID);
                if (countryid == ServerEnvironment.CountryService.AustriaCountryID)
                    return null;

                EmployeeHolidaysInfo holiday_info = ExEmployeeHolidays.UpdateNewOldHolidays(info.EmployeeID, DateTimeHelper.GetYearByDate(DateTime.Today), Convert.ToDouble(info.OldHolidays), Convert.ToDouble(info.NewHolidays));

                Debug.Assert(holiday_info != null);

                return holiday_info;

            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void SaveEmployeeSaldo(long emplid, decimal saldo)
        {

            Employee employee = FindById(emplid);
            Store store = this.StoreService.FindById(employee.MainStoreID);

            bool isAustria = store.CountryID == ServerEnvironment.CountryService.AustriaCountryID;

            // can't modify Austria saldo
            if (isAustria) return;

            EmployeeBusinessObject bzEmployee = new EmployeeBusinessObject(employee, DateTimeHelper.GetMonday (DateTime.Today));
            bzEmployee.AustriaEmployee = isAustria;
            bzEmployee.UpdateCustomSaldo(Convert.ToInt32(saldo));
        }
       
       

        [Transaction]
        [AccessType(AccessType.Read)]

        public EmployeeDebugInfo GetEmployeeDebugInfo(long emplid)
        {
            EmployeeDebugInfo result = new EmployeeDebugInfo();
            result.employee = GetEmployeeByID(emplid, DateTime.Today);
            result._relations = EmployeeRelationService.GetEmployeeRelations(emplid);
            result._contracts = EmployeeContractService.GetEmployeeContracts(emplid);
            result._allins = EmployeeAllInService.GetEntitiesByEmployee(emplid, null, null);
            result._absences = (EmployeeLongTimeAbsenceService as EmployeeLongTimeAbsenceService).GetEntitiesByEmployee(emplid);

            result._planningweeks = (ServerEnvironment.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService).GetEmployeeWeekStatesFrom(emplid, DateTimeSql.FirstMinMonday);
            result._recordingweeks = (ServerEnvironment.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService).GetEmployeesWeekStatesFrom(emplid, DateTimeSql.FirstMinMonday);

            return result;
        }

        [Transaction]
        [AccessType(AccessType.Write)]
        public void DebugRecalculation()
        {
            List<Employee> lst = GetEmployeeList(1162);////FindAll();

            List<long> l = new List<long>(lst.Count);
            foreach (Employee e in lst)
                l.Add(e.ID);

            EmployeeBusinessObject.Recalculate(l.ToArray());

            
        }

        #region HungaryExport

        [AccessType(AccessType.Import)]
        public void ExportHungaryGetWTimes(DateTime? from, DateTime? to)
        {
            try
            {
                EmployeeDao.ExportHungaryGetWTimes(from, to);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveOrUpdateException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public void ExportHungaryGetAvailableAbsences()
        {
            try
            {
                EmployeeDao.ExportHungaryGetAvailableAbsences();
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveOrUpdateException(ex);
            }
        }

        #endregion
    }
}