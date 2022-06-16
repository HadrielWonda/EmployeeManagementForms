using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.ComponentModel;
using System.Reflection;
namespace Baumax.Contract.Absences
{
    public class AbsencePrintArgs
    {
        private AbsencePlanningView m_View;
        private string m_WorldName;
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private int m_MonthOrWeek;
        private bool m_A3 = true;
        private int m_Year;
        private long m_WordID;
        private Dictionary<long, BindingList<BzEmployeeHoliday>> m_DataSource;
        private long m_StoreID;
        private string m_StoreName;
        private Dictionary<PropertyInfo, bool> m_SortInfo;
        private List<StoreToWorld> m_WorldList;
        private bool m_OnlyHolidays = false;
        private bool m_ShowSummary = false;
        private bool m_IsAustria;

        public bool IsAustria
        {
            get { return m_IsAustria; }
            set { m_IsAustria = value; }
        }
        public bool ShowSummary
        {
            get { return m_ShowSummary; }
            set { m_ShowSummary = value; }
        }
        public bool OnlyHolidays
        {
            get { return m_OnlyHolidays; }
            set { m_OnlyHolidays = value; }
        }
        public List<StoreToWorld> WorldList
        {
            get { return m_WorldList; }
            set { m_WorldList = value; }
        }

        public Dictionary<PropertyInfo, bool> SortInfo
        {
            get { return m_SortInfo; }
            set { m_SortInfo = value; }
        }
        public bool A3
        {
            get { return m_A3; }
            set { m_A3 = value; }
        }
        public int MonthOrWeek
        {
            get { return m_MonthOrWeek; }
            set { m_MonthOrWeek = value; }
        }
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        public string WorldName
        {
            get { return m_WorldName; }
            set { m_WorldName = value; }
        }
        public AbsencePlanningView View
        {
            get { return m_View; }
            set
            {
                if (m_View != value)
                {
                    m_View = value;
                    BuildDateRange();
                }
            }
        }

        private void BuildDateRange()
        {
            switch (m_View)
            {
                case AbsencePlanningView.YearlyView:
                    WeekManager.SetBeginEndDate(Year, out m_StartDate, out m_EndDate);
                    break;
                case AbsencePlanningView.MonthlyView:
                    WeekManager.SetBeginEndDate(Year, out m_StartDate, out m_EndDate);
                    break;
                case AbsencePlanningView.WeeklyView:
                    DateTimeHelper.GetDateRangeByWeekNumber(m_MonthOrWeek, m_Year, out m_StartDate, out m_EndDate);
                    break;
            }
        }

        public int Year
        {
            get { return m_Year; }
            set { m_Year = value; }
        }
        public long WordID
        {
            get { return m_WordID; }
            set { m_WordID = value; }
        }
        public Dictionary<long, BindingList<BzEmployeeHoliday>> DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }
        public long StoreID
        {
            get { return m_StoreID; }
            set { m_StoreID = value; }
        }
        public string StoreName
        {
            get { return m_StoreName; }
            set { m_StoreName = value; }
        }

        public AbsencePrintArgs(AbsencePlanningView view, int year,
            long worldID, List<StoreToWorld> worldList, Dictionary<long, BindingList<BzEmployeeHoliday>> dataSource,
            long storeID, string storeName, string worldName, int monthOrWeek, Dictionary<PropertyInfo, bool> sortInfo, bool isaustria)
        {
            m_View = view;
            m_Year = year;
            m_WordID = worldID;
            m_StoreID = storeID;
            m_DataSource = dataSource;
            m_StoreName = storeName;
            m_WorldName = worldName;
            m_MonthOrWeek = monthOrWeek;
            m_SortInfo = sortInfo;
            m_WorldList = worldList;
            m_IsAustria = isaustria;
            BuildDateRange();
        }
    }
}
