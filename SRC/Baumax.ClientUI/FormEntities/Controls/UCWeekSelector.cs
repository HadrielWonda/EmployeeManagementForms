using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.Controls
{
    public partial class UCWeekSelector : UCBaseEntity
    {
        #region fields
        private int m_currentWeek;
        private int m_currentYear;
        private List<string> m_months = new List<string>();
        private bool m_isupdate = false;
        
        #endregion

        #region properties
        public DateTime Date
        {
            set 
            { 
                RebuildByDate(value);
                SelectCurrentWeek();
            }
        }
        public int CurrentYear
        {
            get { return m_currentYear; }
            set 
            {
                if (m_currentYear != value)
                {
                    m_currentYear = value;
                    OnDateChanged();
                }
                SelectCurrentWeek();
            }
        }
        public DateTime MondayDate
        {
            get 
            {
                WeekSource source = WeekManager.GetWeekSource(m_currentYear, m_currentWeek);
                return (source != null) ? source.Monday : new DateTime();
            }
        }
        public DateTime SundayDate
        {
            get
            {
                WeekSource source = WeekManager.GetWeekSource(m_currentYear, m_currentWeek);
                return (source != null) ? source.Sunday : new DateTime();                
            }
        }
        public int CurrentWeek
        {
            get { return m_currentWeek; }
            set
            {
                if (m_currentWeek != value)
                {
                    m_currentWeek = value;
                    OnDateChanged();
                }
                SelectCurrentWeek();
            }
        }

        private void SelectCurrentWeek()
        {
            WeekSource week = gridView.GetRow(gridView.FocusedRowHandle) as WeekSource;
            if (week == null || week.Number == m_currentWeek)
                return;
            if (gridControl.DataSource != null)
                gridView.FocusedRowHandle = gridView.GetRowHandle((gridControl.DataSource as List<WeekSource>).FindIndex(new Predicate<WeekSource>(
                    delegate(WeekSource s)
                    {
                        return s.Number == m_currentWeek;
                    })));
            gridView.SetFocusedRowModified();
            
        }
        #endregion

        public event EventHandler DateChanged;

        public UCWeekSelector()
        {
                InitializeComponent();
                gridControl.Focus();
                AssignLanguage();
                this.edYear.EditValueChanged += new System.EventHandler(this.edYear_EditValueChanged);
                edYear.EditValue = DateTime.Today.Year;

        }

        public void MakeRowVisible()
        {
            gridView.MakeRowVisible(gridView.FocusedRowHandle, true);
        }

        private void edYear_EditValueChanged(object sender, EventArgs e)
        {
            CurrentYear = (int)edYear.Value;
            RebouldByYearWeek((int)edYear.Value, m_currentWeek);
            
        }

        private void RebouldByYearWeek(int current_year, int current_week)
        {
            gridView.BeginUpdate();
            List<WeekSource> source = WeekManager.GetYearMap(current_year);
            if (source.Count < current_week)
                current_week = source.Count;

            foreach (WeekSource week in source)
                week.Month = m_months[week.MonthNumber];
            gridControl.DataSource = source;
            CurrentWeek = current_week;
            gridView.EndUpdate();
        }

        private void RebuildByDate(DateTime date)
        {
            gridView.BeginUpdate();
            List<WeekSource> source = WeekManager.GetYearMap(date.Year);
            foreach (WeekSource week in source)
                week.Month = m_months[week.MonthNumber];
            gridControl.DataSource = source;
            CurrentYear = date.Year;
            CurrentWeek = WeekManager.GetWeekNumber(date);
            gridView.EndUpdate();
            
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            WeekSource week = gridView.GetRow(e.FocusedRowHandle) as WeekSource;
            if (week != null && !m_isupdate)
                CurrentWeek = week.Number;
        }

        private void gridView_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            e.Handled = true;
            e.Result = Comparer<int>.Default.Compare(m_months.IndexOf((string)e.Value1), 
                                                     m_months.IndexOf((string)e.Value2));
        }
        protected void OnDateChanged()
        {
            if (DateChanged != null)
                DateChanged(this, null);
        }

        public override void AssignLanguage()
        {
            m_months.Clear();
            m_months.Add("");
            m_months.Add(GetLocalized("January"));
            m_months.Add(GetLocalized("February"));
            m_months.Add(GetLocalized("March"));
            m_months.Add(GetLocalized("April"));
            m_months.Add(GetLocalized("May"));
            m_months.Add(GetLocalized("June"));
            m_months.Add(GetLocalized("July"));
            m_months.Add(GetLocalized("August"));
            m_months.Add(GetLocalized("September"));
            m_months.Add(GetLocalized("October"));
            m_months.Add(GetLocalized("November"));
            m_months.Add(GetLocalized("December"));
                base.AssignLanguage();
        }

        private void btn_Current_Click(object sender, EventArgs e)
        {
            CurrentWeek = WeekManager.GetWeekNumber(DateTime.Today);
        }
    }
}
