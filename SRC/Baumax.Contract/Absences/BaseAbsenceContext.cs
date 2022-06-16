using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.Absences;
using Baumax.Contract.HolydayClasses;

namespace Baumax.Contract.Absences
{
//    public class BaseAbsenceContext
//    {
//        protected long m_StoreWorldID = 0;
//        protected int m_CurrentMonth;
//        protected AbsenceController m_AbsenceManager;
//        protected EmployeeManager m_EmployeeManager;
//        protected TimeViewStyle m_ViewStyle = TimeViewStyle.Year;
//        protected List<DateTime> m_DayOfWeek = new List<DateTime>();
//        protected YearAppearance m_Props;
//        protected EmployeeCoefficientManager m_CoefficentManager;
//        protected AbsencePlanningServices m_Services;
//        protected AbsencePlanningQuery m_Query;

//        #region enable commands
//        protected bool m_EnableSave = false;
//        protected bool m_EnableModifyAbsence = false;

//        public bool EnableModifyAbsence
//        {
//            get { return m_EnableModifyAbsence; }
//            set
//            {
//                if (m_EnableModifyAbsence != value)
//                {
//                    m_EnableModifyAbsence = value;
//                    OnEnableCommandChanged();
//                }
//            }
//        }
//        public bool EnableSave
//        {
//            get { return m_EnableSave; }
//            set
//            {
//                if (m_EnableSave != value)
//                {
//                    m_EnableSave = value;
//                    OnEnableCommandChanged();
//                }
//            }
//        }
//        #endregion

//        public event EventHandler ViewStyleChanged = null;
//        public event EventHandler StoreChanged = null;
//        public event EventHandler WorldChanged = null;
//        public event EventHandler WeekChanged = null;
//        public event EventHandler YearChanged = null;
//        public event EventHandler EnableCommandChanged = null;

//        public BaseAbsenceContext(AbsencePlanningServices services)
//        {
//            m_Services = services;
//            m_Props = new YearAppearance();
//            Year = DateTime.Today.Year;
//            List<WeekSource> yearMap = WeekManager.GetYearMap(Year);
//            WeekSource source = yearMap[WeekManager.GetWeekNumber(DateTime.Today) - 1];

//            CurrentWeek = source.Number;
//            FillDaysOfWeek();
//            CurrentMonth = source.MonthNumber;
//        }

//        public StoreDaysList StoreDay
//        {
//            get { return m_Query.StoreDays; }
//            set { m_Query.StoreDays = value; }
//        }
//        public List<DateTime> DayOfWeek
//        {
//            get { return m_DayOfWeek; }
//            set { m_DayOfWeek = value; }
//        }
//        public long StoreID
//        {
//            get { return m_Props.StoreID; }
//            set
//            {
//                if (m_Props.StoreID != value)
//                {
//                    m_Props.StoreID = value;
//                    OnStoreChanged();
//                }
//            }
//        }

//        public bool IsAustria
//        {
//            get
//            {
//                return m_Props.CountryID == m_Services.CountryService.AustriaCountryID;
//            }
//        }
//        public YearAppearance Props
//        {
//            get { return m_Props; }
//            set { m_Props = value; }
//        }
//        public long CountryID
//        {
//            get { return m_Props.CountryID; }
//            set { m_Props.CountryID = value; }
//        }

//        public int CurrentWeek
//        {
//            get
//            {
//                return m_Props.WeekNumber;
//            }
//            set
//            {
//                //if (m_Props.WeekNumber != value)
//                {
//                    m_Props.WeekNumber = value;
//                    OnWeekChanged();
//                }
//            }
//        }

//        protected virtual void FillDaysOfWeek()
//        {
//            WeekSource source = WeekManager.GetWeekSource(m_Props.Year, m_Props.WeekNumber);
//            m_DayOfWeek.Clear();
//            for (DateTime day = source.Monday; day <= source.Sunday; day = day.AddDays(1d))
//                m_DayOfWeek.Add(day);
//        }
//        public int CurrentMonth
//        {
//            get { return m_CurrentMonth; }
//            set { m_CurrentMonth = value; }
//        }
//        public int Year
//        {
//            get { return m_Props.Year; }
//            set
//            {
//                if (m_Props.Year != value)
//                {
//                    m_Props.Year = value;
//                    OnYearChanged();
//                }
//            }
//        }
//        public long StoreWorldID
//        {
//            get { return m_StoreWorldID; }
//            set
//            {
//                if (m_StoreWorldID != value && m_EmployeeManager != null && m_AbsenceManager != null)
//                {
//                    m_StoreWorldID = value;
//                    m_EmployeeManager.StoreWorldID = value;
//                    m_AbsenceManager.StoreWorldID = value;
//                    m_AbsenceManager.SetFilteredEmployeeList(m_EmployeeManager.Employees, m_EmployeeManager.EmployeesInAnorherWorlds);
//                    OnWorldChanged();
//                }
//            }
//        }

//        public TimeViewStyle ViewStyle
//        {
//            get { return m_ViewStyle; }
//            set
//            {
//                if (m_ViewStyle != value)
//                {
//                    m_ViewStyle = value;
//                    OnStyleChanged();
//                }
//            }
//        }

//        public virtual AbsenceController AbsenceManager
//        {
//            get { return m_AbsenceManager; }
//        }

//        public virtual EmployeeManager EmployeeManager
//        {
//            get { return m_EmployeeManager; }
//        }

        
//        protected virtual void ModifyPrimaryParametres()
//        {
//            List<WeekSource> weeks = WeekManager.GetYearMap(Year);
//            m_Query = m_Services.EmployeeTime.GetAllAbsencePlanning(m_Props.StoreID, m_Props.CountryID, m_Props.Year, DateTime.Today);
            
//            m_Props.AvgWorkingDayByWeek = m_Query.AvgDaysPerWeek;

//            if (m_Query.AvgDaysPerWeek == 0)
//            {
//                m_Query.Contracts = null;
//                m_Query.Employees = null;
//                m_Query.Relations = null;
//                m_Query.Longabsences = null;
//                m_Query.Recordings = null;
//                m_Query.Plannings = null;

////                return;
//            }
//            LoadManagers();

//            m_EmployeeManager.StoreWorldID = m_StoreWorldID;
            
            
//            m_AbsenceManager.Load(m_EmployeeManager.IdArray);
//            m_AbsenceManager.SetNoContractRanges(m_EmployeeManager.EmployeesInAnorherWorlds);
//            List<AvgWorkingDaysInWeek> workingDays = m_Services.AvgDays.GetAvgWorkingDaysInWeekFiltered(m_Props.CountryID, (short)Year, (short)Year);

//            if (CurrentWeek == 0 && m_CurrentMonth == 0)
//            {
//                CurrentMonth = WeekManager.GetWeekSource(Year, WeekManager.GetWeekNumber(DateTime.Today)).MonthNumber;
//                CurrentWeek = WeekManager.GetWeekNumber(DateTime.Today);
//            }
//            FillDaysOfWeek();
//        }

//        protected virtual void LoadManagers()
//        {
//            m_EmployeeManager = new EmployeeManager(m_Props, m_Services, m_Query);
//            m_AbsenceManager = new AbsenceController(m_Props, m_Services, m_Query);
//        }

//        protected void OnStoreChanged()
//        {
//            StoreWorldID = 0;
//            ModifyPrimaryParametres();
//            if (StoreChanged != null)
//                StoreChanged(this, null);
//        }
//        protected void OnWorldChanged()
//        {
//            if (WorldChanged != null)
//                WorldChanged(this, null);
//        }
//        protected void OnWeekChanged()
//        {
//            WeekSource source = WeekManager.GetWeekSource(Year, CurrentWeek);
//            if (source != null)
//                CurrentMonth = source.MonthNumber;
//            FillDaysOfWeek();
//            ViewStyle = TimeViewStyle.Week;

//            if (WeekChanged != null)
//                WeekChanged(this, null);
//        }

//        protected void OnYearChanged()
//        {
//            List<WeekSource> yearMap = WeekManager.GetYearMap(Year);
//            int weeks = yearMap.Count;

//            m_Props.WeekNumber = weeks;
//            m_Props.Begin = yearMap[0].Monday;
//            m_Props.End = yearMap[weeks - 1].Sunday;

//            if (CurrentWeek > weeks)
//                CurrentWeek = weeks;
//            if (StoreID != 0)
//                ModifyPrimaryParametres();
//            if (YearChanged != null)
//                YearChanged(this, null);
//        }

//        protected void OnStyleChanged()
//        {
//            if (ViewStyleChanged != null)
//                ViewStyleChanged(this, null);
//        }

//        protected void OnEnableCommandChanged()
//        {
//            if (EnableCommandChanged != null)
//                EnableCommandChanged(this, null);
//        }

//        public virtual string GetDayCaption(string dayName, int plusMonday)
//        {
//            DateTime day = m_Props.GetDay(m_Props.GetWithWeek(plusMonday));
//            string timerange = String.Empty;

//            if (AbsenceManager != null)
//                timerange = AbsenceManager.GetStoreRangeString(day);
//            return string.Format("{0}\n{1}\n{2}", 
//                dayName, day.ToShortDateString(),
//                timerange);
//        }
//    }
}
