using System;
using System.Collections.Generic;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using System.Diagnostics;
using Common.Logging;

namespace Baumax.Services._HelperObjects.ExEntity
{
    public class ExEmployeeHolidays
    {
        private long _EmployeeId;
        private int _Year;

        protected EmployeeHolidaysInfoService Service
        {
            get
            {
                return ServerEnvironment.EmployeeTimeService.EmployeeHolidaysInfoService as EmployeeHolidaysInfoService;
            }
        }

        public long EmployeeId
        {
            get { return _EmployeeId; }
            protected set { _EmployeeId = value; }
        }
        
        public int Year
        {
            get { return _Year; }
            protected set { _Year = value; }
        }

        public ExEmployeeHolidays(long emplid, int year)
        {
            EmployeeId = emplid;
            Year = year;

        }

        public EmployeeHolidaysInfo CalculateAndUpdate()
        {
            EmployeeHolidaysInfo entity = GetEntity(EmployeeId, Year);

            if (entity == null)
            {
                entity = new EmployeeHolidaysInfo();
                entity.Year = (short)Year;
                entity.EmployeeID = EmployeeId;
                entity.NewHolidays = entity.OldHolidays = 0;
                entity.PlannedHolidays = entity.TakenHolidays = 0;
                entity.SpareHolidaysExc = entity.SpareHolidaysInc = 0;
                entity.UsedHolidays = 0;
            }

            ExEmployeeHolidays.CalculateAndUpdate(entity);

            Debug.Assert(!entity.IsNew);

            return entity;
            //int TodayYear = DateTimeHelper.GetYearByDate(DateTime.Today);

            //DateTime begin_year_date = DateTimeHelper.GetBeginYearDate(Year);
            //DateTime end_year_date = DateTimeHelper.GetEndYearDate(Year);

            //StoreService storeservice = ServerEnvironment.StoreService as StoreService;
            //EmlpoyeeHolidaysSumDays sums_by_year =
            //    storeservice.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(EmployeeId, begin_year_date, end_year_date, DateTime.Today);

            //EmployeeHolidaysInfo entity = Service.GetEntity(EmployeeId, Year);

            //if (entity == null)
            //{
            //    entity = new EmployeeHolidaysInfo();
            //    entity.Year = (short)Year;
            //    entity.EmployeeID = EmployeeId;
            //    entity.NewHolidays = entity.OldHolidays = 0;
            //    entity.PlannedHolidays = entity.TakenHolidays = 0;
            //    entity.SpareHolidaysExc = entity.SpareHolidaysInc = 0;
            //}

            //if (sums_by_year != null)
            //{
            //    entity.TakenHolidays = Math.Round(sums_by_year.TimeRecording / 1440, 2);
            //    entity.PlannedHolidays = Math.Round(sums_by_year.TimePlanning / 1440, 2);
            //}

            //Service.SaveOrUpdate(entity);

            //return entity;

        }

        public EmployeeHolidaysInfo UpdateFromEmployee(Employee employee)
        {
            if (employee == null) return null;
            if (employee.IsNew) return null;
            if (EmployeeId != employee.ID) return null;

            EmployeeHolidaysInfo entity = GetEntity(EmployeeId, Year);

            if (entity == null)
            {
                entity = new EmployeeHolidaysInfo();
            }
            entity.EmployeeID = employee.ID;
            entity.NewHolidays = employee.NewHolidays;
            entity.OldHolidays = employee.OldHolidays;
            entity.UsedHolidays = employee.UsedHolidays;
            entity.Year = (short)Year;
            entity.CalculateSpareHolidays();
            Srv.SaveOrUpdate(entity);

            return entity;
        }

        public static void DebugCheckMethods()
        {
            Srv.GetEntities(100);

            Srv.GetEntity(100, 2007);

            Srv.GetEntities(new long[] { 100, 1001 }, 2007);

            Srv.GetEntitiesByStore(1003, 2007);
            Srv.GetEntitiesByCountry(999, 2007);
        }

        #region static methods

        protected static EmployeeHolidaysInfoService Srv
        {
            get
            {
                return ServerEnvironment.EmployeeTimeService.EmployeeHolidaysInfoService as EmployeeHolidaysInfoService;
            }
        }

        #region Taken/Planned holidays update methods

        public static EmployeeHolidaysInfo CalculateAndUpdate(long emplid, int Year)
        {
            return (new ExEmployeeHolidays(emplid, Year).CalculateAndUpdate());
        }
        public static EmployeeHolidaysInfo CalculateAndUpdate(EmployeeHolidaysInfo entity)
        {
            return CalculateAndUpdate(entity, false);
        }
        public static EmployeeHolidaysInfo CalculateAndUpdate(EmployeeHolidaysInfo entity, bool bAustria)
        {

            Debug.Assert(entity != null);

            if (entity == null) return null;

            Debug.WriteLine("Begin calculate: " + entity.ToString());
            int TodayYear = DateTimeHelper.GetYearByDate(DateTime.Today);

            DateTime begin_year_date = DateTimeHelper.GetBeginYearDate(entity.Year);
            DateTime end_year_date = DateTimeHelper.GetEndYearDate(entity.Year);

            StoreService storeservice = ServerEnvironment.StoreService as StoreService;
            EmlpoyeeHolidaysSumDays sums_by_year =
                storeservice.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(entity.EmployeeID, begin_year_date, end_year_date, DateTime.Today);

            bool bModified = entity.IsNew;

            if (sums_by_year != null)
            {
                //decimal taken = Math.Round(sums_by_year.TimeRecording / 1440, 2);
                //decimal used = Math.Round(sums_by_year.TimePlanning / 1440, 2);

                decimal taken = Math.Round(sums_by_year.TimeRecording, 2);
                decimal used = Math.Round(sums_by_year.TimePlanning, 2);

                bModified |= (taken != entity.TakenHolidays) || 
                    (used != entity.PlannedHolidays);

                entity.TakenHolidays = taken;
                entity.PlannedHolidays = used;
            }
            if (bAustria )
                bModified |= entity.CalculateSpareHolidays_Austria();
            else
                bModified |= entity.CalculateSpareHolidays();

            //Debug.Assert(entity.IsNew == bModified);

            if (bModified)
            {
                Debug.WriteLine("Entity was changed : " + entity.ToString());
                Srv.SaveOrUpdate(entity);
            }
            
            Debug.WriteLine("End calculate: " + entity.ToString());
            return entity;
        }
        public static void CalculateAndUpdate(long[] emplids, int Year)
        {
            if (emplids != null)
            {
                ExEmployeeHolidays ex_holidays = null;
                foreach (long id in emplids)
                {
                    if (ex_holidays == null)
                    {
                        ex_holidays = new ExEmployeeHolidays(id, Year);
                        ex_holidays.CalculateAndUpdate();
                    }
                    else
                    {
                        ex_holidays.EmployeeId = id;
                        ex_holidays.Year = Year;
                        ex_holidays.CalculateAndUpdate();
                    }
                }
            }
        }

        #endregion

        #region read methods

        public static EmployeeHolidaysInfo GetEntity(long emplid, int year)
        {
            return Srv.GetEntity(emplid, year);
        }
        public static List<EmployeeHolidaysInfo> GetAllByEmployee(long emplid)
        {
            return Srv.GetEntities(emplid);
        }
        public static List<EmployeeHolidaysInfo> GetAllByEmployees(long[] emplids, int Year)
        {
            return Srv.GetEntities(emplids, Year);
        }
        public static List<EmployeeHolidaysInfo> GetAllByStore(long storeid, int Year)
        {
            return Srv.GetEntitiesByStore(storeid, Year);
        }
        public static List<EmployeeHolidaysInfo> GetAllByCountry(long countryid, int Year)
        {
            return Srv.GetEntitiesByCountry(countryid, Year);
        }

        #endregion

        #region New/Old holidays changed calculation

        public static EmployeeHolidaysInfo UpdateNewOldHolidays(long emplid, int year, double old_holidays, double new_holidays)
        {
            EmployeeHolidaysInfo entity = GetEntity(emplid, year);

            if (entity == null)
            {
                entity = new EmployeeHolidaysInfo((short)year, 0m,0m,0m,emplid);
            }

            return UpdateNewOldHolidays(entity, old_holidays, new_holidays);
        }

        public static EmployeeHolidaysInfo UpdateNewOldHolidays(EmployeeHolidaysInfo entity, double old_holidays, double new_holidays)
        {
            if (entity == null)
                throw new ArgumentNullException();

            bool bModified = entity.IsNew ||entity.OldHolidays != Convert.ToDecimal(old_holidays) ||
                entity.NewHolidays != Convert.ToDecimal(new_holidays);

            entity.OldHolidays = Convert.ToDecimal(old_holidays);
            entity.NewHolidays = Convert.ToDecimal(new_holidays);

            if (entity.CalculateSpareHolidays())
                Srv.SaveOrUpdate(entity);

            return entity;
        }


        #endregion

        #region converting methods

        public static Dictionary<long, EmployeeHolidaysInfo> ConvertToDictionary(List<EmployeeHolidaysInfo> list)
        {
            Dictionary<long, EmployeeHolidaysInfo> dictionary = new Dictionary<long, EmployeeHolidaysInfo>();

            if (list != null && list.Count > 0)
            {
                foreach (EmployeeHolidaysInfo entity in list)
                {
#if DEBUG
                    if (dictionary.ContainsKey(entity.EmployeeID))
                        throw new ArgumentException("two equal EmployeeHolidaysInfo entities in dictionary");
#endif
                    dictionary[entity.EmployeeID] = entity;
                }
            }

            return dictionary;
        }

        public static long[] ExtractEmployeesId(EmployeeHolidaysInfo[] list)
        {
            if (list == null)
                return null;

            return ExtractEmployeesId(new List<EmployeeHolidaysInfo>(list));
        }
        public static long[] ExtractEmployeesId(IList<EmployeeHolidaysInfo> list)
        {
            if (list == null) return null;

            long[] ids = new long [list.Count];
            
            for (int i = 0; i < list.Count; i++)
            {
                ids[i] = list[i].EmployeeID;
            }

            return ids;

        }

        #endregion

        public static EmployeeHolidaysInfo UpdateSpareHolidaysExc_Austria(long emplid, int year, double spare_holidays)
        {
            EmployeeHolidaysInfo entity = GetEntity(emplid, year);

            if (entity == null)
            {
                entity = new EmployeeHolidaysInfo((short)year, 0m, 0m, 0m, emplid);
            }
            return UpdateSpareHolidaysExc_Austria(entity, spare_holidays);
        }

        public static EmployeeHolidaysInfo UpdateSpareHolidaysExc_Austria(EmployeeHolidaysInfo entity, double spare_holidays)
        {
            if (entity == null)
                throw new ArgumentNullException();
            decimal new_spare_exc = Convert.ToDecimal(spare_holidays);
            decimal old_spare_exc = entity.SpareHolidaysExc;

            bool bModified = entity.IsNew || (old_spare_exc != new_spare_exc);

            entity.SpareHolidaysExc = new_spare_exc;
            bModified |= entity.CalculateSpareHolidays_Austria();

            if (bModified)
                Srv.SaveOrUpdate(entity);

            return entity;
        }
        // After dayly import austrian employees - recalculate holidays
        // Attention: list_employees - must contain only employees which have valid contract(per year)
        public static void UpdateSpareHolidaysExc_Austria(List<Employee> list_employees, long[] ids, int year)
        {

            ILog log = LogManager.GetLogger(typeof(ExEmployeeHolidays));

            if (ids == null || ids.Length == 0) return;
            if (list_employees == null || list_employees.Count == 0) return;

            List<EmployeeHolidaysInfo> list_entities = GetAllByEmployees(ids, year);
            Dictionary<long, EmployeeHolidaysInfo> diction_entities = ConvertToDictionary(list_entities);
            EmployeeHolidaysInfo entity = null;
            foreach (Employee employee in list_employees)
            {
                if (log.IsDebugEnabled)
                    log.Debug(employee.ID.ToString () + " " + employee.FullName + " AvailableHolidays=" + employee.AvailableHolidays.ToString ());

                entity = null;
                if (!diction_entities.TryGetValue(employee.ID, out entity))
                {

                    if (log.IsDebugEnabled)
                        log.Debug(String.Format ("Create new holidays entity: EmployeeID={0}, Name={1}, Year={2}",
                            employee.ID,employee.FullName, year));

                    entity = new EmployeeHolidaysInfo((short)year, 0m, 0m, 0m, employee.ID);
                }

                bool bModified = entity.IsNew || (entity.SpareHolidaysExc != employee.AvailableHolidays);

                entity.SpareHolidaysExc = employee.AvailableHolidays;

                Srv.SaveOrUpdate(entity);

                CalculateAndUpdate(entity, true);

                if (log.IsDebugEnabled)
                    log.Debug(String.Format("holidays entity: EmployeeID={0}, Name={1}, Year={2}, TakenHoliday={3}, PlannedHolidays={4}, SpareExc={5}",
                        new object[] { employee.ID, employee.FullName, year,entity.TakenHolidays,entity.PlannedHolidays,entity.SpareHolidaysExc}));
            }
        }


        public static List<EmployeeHolidaysInfo> BuildOldHolidaysFromPreviousYear(long storeid, int year)
        {
            ILog log = LogManager.GetLogger("ExEmployeeHolidays"); 

            if (year - 1 < DateTimeSql.SmallDatetimeMin.Year) return null;
            DateTime begin_year_date = DateTimeHelper.GetBeginYearDate(year);
            DateTime end_year_date = DateTimeHelper.GetEndYearDate(year);

            if (log.IsDebugEnabled)
                log.Debug(string.Format("Begin move spare(exc) holidays from {0} to {1} years for store {2}", year-1, year, storeid));

            EmployeeService service = ServerEnvironment.EmployeeService as EmployeeService;
            List<Employee> employeesList = service.EmployeeDao.GetStoreEmployeesHaveContracts(storeid, begin_year_date, end_year_date);

            if (log.IsDebugEnabled)
            {
                int iCount = (employeesList != null)? employeesList.Count: 0; 
                
                log.Debug(string.Format("Loaded {0} employees for year {1}", iCount, year));

            }


            if (employeesList == null || employeesList.Count == 0) return null;


            List<EmployeeHolidaysInfo> listOldHolidaysInfo = GetAllByStore(storeid, year - 1);
            if (listOldHolidaysInfo == null || listOldHolidaysInfo.Count == 0) return null;

            List<EmployeeHolidaysInfo> listCurrentHolidaysInfo = GetAllByStore(storeid, year);

            Dictionary<long, EmployeeHolidaysInfo> diction_old_holidays = ConvertToDictionary(listOldHolidaysInfo);
            Dictionary<long, EmployeeHolidaysInfo> diction_current_holidays = ConvertToDictionary(listCurrentHolidaysInfo);

            if (log.IsDebugEnabled)
            {
                int iCount = (listCurrentHolidaysInfo != null) ? listCurrentHolidaysInfo.Count : 0;
                int iCount2 = (listOldHolidaysInfo != null) ? listOldHolidaysInfo.Count : 0;

                log.Debug(string.Format("Loaded previous entities {0} and current entities {1} ", iCount2, iCount));

            }

            EmployeeHolidaysInfo old_holiday_info = null;
            EmployeeHolidaysInfo current_holiday_info = null;

            foreach (Employee employee in employeesList)
            {
                old_holiday_info = current_holiday_info = null;

                diction_old_holidays.TryGetValue(employee.ID, out old_holiday_info);
                diction_current_holidays.TryGetValue(employee.ID, out current_holiday_info);

                if (old_holiday_info != null)
                {
                    if (current_holiday_info != null)
                    {
                        bool modified = current_holiday_info.OldHolidays != old_holiday_info.SpareHolidaysExc;

                        current_holiday_info.OldHolidays = old_holiday_info.SpareHolidaysExc;
                        modified |= current_holiday_info.CalculateSpareHolidays();

                        if (modified)
                        {
                            Srv.SaveOrUpdate(current_holiday_info);
                        }
                    }
                    else
                    {
                        current_holiday_info = new EmployeeHolidaysInfo(employee.ID, (short)year);

                        current_holiday_info.OldHolidays = old_holiday_info.SpareHolidaysExc;

                        EmlpoyeeHolidaysSumDays sums_by_year = GetHolidaysSumDays(employee.ID, begin_year_date, end_year_date);

                        if (sums_by_year != null)
                        {
                            current_holiday_info.TakenHolidays = sums_by_year.TimeRecording;
                            current_holiday_info.PlannedHolidays = sums_by_year.TimePlanning;
                            
                            
                        }
                        current_holiday_info.CalculateSpareHolidays();
                        Srv.SaveOrUpdate(current_holiday_info);

                        if (log.IsDebugEnabled)
                        {
                            log.Debug(string.Format("Create entity from employee ID={0} and Name = {1}; Year={2} ", employee.ID, employee.FullName, year));
                        }

                    }
                }
            }

            listCurrentHolidaysInfo = GetAllByStore(storeid, year);

            return listCurrentHolidaysInfo;
        }

        public static EmlpoyeeHolidaysSumDays GetHolidaysSumDays(long emplid, int year)
        {
            DateTime begin_year_date = DateTimeHelper.GetBeginYearDate(year);
            DateTime end_year_date = DateTimeHelper.GetEndYearDate(year);

            return GetHolidaysSumDays(emplid, begin_year_date, end_year_date);
        }
        public static EmlpoyeeHolidaysSumDays GetHolidaysSumDays(long emplid, DateTime begin_year_date, DateTime end_year_date)
        {
            StoreService storeservice = ServerEnvironment.StoreService as StoreService;
            
            EmlpoyeeHolidaysSumDays sums_by_year =
                storeservice.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(emplid, begin_year_date, end_year_date, DateTime.Today);

            return sums_by_year;
        }

        #endregion
    }
}
