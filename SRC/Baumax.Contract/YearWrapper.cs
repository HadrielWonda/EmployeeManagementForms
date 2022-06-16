using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Baumax.Contract
{
    public class YearWrapper
    {
        private int[] _weektomonth = null;
        private DateTime[] _weekranges = null;
        private int _year;
        private int _countofweek;
        private DateTime _beginyeardate;
        private DateTime _endyeardate;

        public int Year
        {
            get { return _year; }
        }

        
        public int CountOfWeek
        {
            get { return _countofweek; }
        }
        
        public DateTime BeginYearDate
        {
            get { return _beginyeardate; }
        }
        
        public DateTime EndYearDate
        {
            get { return _endyeardate; }
        }
        public int CountDayInYear
        {
            get
            {
                TimeSpan ts = EndYearDate - BeginYearDate;
                return ts.Days;
            }
        }

        public int[] GetWeekNumbersByMonths(int month)
        {
            Debug.Assert(_weektomonth != null && _weektomonth.Length > 51);
            List<int> res = new List<int>(5);
            for (int i = 0; i < _weektomonth.Length; i++)
            {
                if (_weektomonth[i] == month)
                    res.Add(i + 1);
            }
            return res.ToArray();
        }

        public int[] GetMonthMap()
        {
            Debug.Assert(_weektomonth != null && _weektomonth.Length > 51);
            int[] res = new int[CountOfWeek];
            _weektomonth.CopyTo(res, 0);
            return res;
        }

        public DateTime GetMondayByWeek(int weeknumber)
        {
            Debug.Assert((1 <= weeknumber) && (weeknumber <= CountOfWeek));
            Debug.Assert((_weekranges != null) && _weekranges.Length == (CountOfWeek * 2));

            return _weekranges[2 * (weeknumber - 1)];
        }

        public void GetWeekDateRange(int weeknumber, out DateTime monday, out DateTime sunday)
        {
            Debug.Assert((1 <= weeknumber) && (weeknumber <= CountOfWeek));
            Debug.Assert((_weekranges != null) && _weekranges.Length == (CountOfWeek * 2));

            monday = _weekranges[2 * (weeknumber - 1)];
            sunday = _weekranges[2 * (weeknumber - 1) + 1];
        }

        private void Init()
        {
            _beginyeardate = DateTimeHelper.GetBeginYearDate(Year);
            _endyeardate = DateTimeHelper.GetEndYearDate(Year);
            _countofweek = DateTimeHelper.GetCountWeekInYear(Year);

            _weektomonth = new int[CountOfWeek];
            _weekranges = new DateTime[CountOfWeek * 2];
            DateTime monday, sunday;

            for (int i = 1, j = 0; i <= CountOfWeek; i++, j += 2)
            {
                DateTimeHelper.GetDateRangeByWeekNumber(i, Year, out monday, out sunday);
                _weekranges[j] = monday; _weekranges[j + 1] = sunday;
                _weektomonth[i - 1] = DateTimeHelper.GetMonthNumberByWeekDateRange(monday, sunday);
            }
        }
        public YearWrapper(int year)
        {
            _year = year;
            Init();
        }
        public YearWrapper(DateTime date)
        {
            _year = DateTimeHelper.GetYearByDate (date);
            Init();
        }

    }
}
