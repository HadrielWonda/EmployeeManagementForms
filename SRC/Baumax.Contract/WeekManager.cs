using System;
using System.Collections.Generic;

namespace Baumax.Contract
{
    public static class WeekManager
    {
        static Dictionary<int, List<WeekSource>> m_diction = new Dictionary<int, List<WeekSource>>();
        static int[] m_iso = { 6, 7, 8, 9, 10, 4, 5 };

        
    

        static WeekManager() {}
        
        public static int GetWeekNumber(DateTime date)
        {
            DateTime start = date.AddDays(-date.Day + 1).AddMonths(-date.Month + 1),
                     end = start.AddYears(1).AddDays(-1);
            int week = (date.Subtract(start).Days + m_iso[(int)start.DayOfWeek]) / 7;

            switch (week)
            {
                case 0:
                    return GetWeekNumber(start.AddDays(-1));
                case 53:
                    if (end.DayOfWeek < DayOfWeek.Thursday)
                         return 1;
                    else
                         return week;
                default: return week;
            }
        }

        public static int GetYear(DateTime date)
        {
            for (int i = -1; i < 2; i++)
            {
                List<WeekSource> me = GetYearMap(date.Year+i);
                if (me[0].Monday <= date && me[me.Count - 1].Sunday >= date)
                    return date.Year + i;
            }
            return date.Year;
        }

        public static void SetBeginEndDate(int year, out DateTime begin, out DateTime end)
        {
            List<WeekSource> map = WeekManager.GetYearMap(year);
            begin = map[0].Monday;
            end = map[map.Count - 1].Sunday;
        }

        public static List<WeekSource> GetYearMap(int year)
        {
            if (m_diction.ContainsKey(year))
                return m_diction[year];

            List<WeekSource> list = new List<WeekSource>();
            DateTime start = new DateTime(year, 1, 1),
                     end = new DateTime(year , 12, 31), sunday;
            int endTime = (int)end.DayOfWeek;
            if (endTime != 0)
                end = end.AddDays( endTime < 4 ? -endTime: 7 - endTime);


            switch (start.DayOfWeek)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                    start = start.AddDays(8 - (int)start.DayOfWeek);
                    break;
                case DayOfWeek.Sunday:
                    start = start.AddDays(1);
                    break;
                default:
                    start = start.AddDays(1 - (int)start.DayOfWeek);
                    break;
            }
            sunday = start.AddDays(6);

            for (int i = 1 ; sunday <= end; i++)
            {
                list.Add(new WeekSource( i < 3 ? 1 : (i > 50 ? 12 : start.Month), i, start, sunday));
                start  = start.AddDays(7);
                sunday = sunday.AddDays(7);
            }

            list[0].MonthNumber = 1;
            list[list.Count - 1].MonthNumber = 12;

            m_diction.Add(year, list);

            return list;
        }

        public static WeekSource GetWeekSource(int year, int week)
        {
            List<WeekSource> weeks = GetYearMap(year);
            if (weeks.Count >= week)
                return weeks[week - 1];
            else
                return null;
        }
    }


    public class WeekSource
    {
        private DateTime m_Monday;
        private DateTime m_sunday;
        private int m_number;
        private string m_month;
        private int m_monthNumber;

        public WeekSource(int month_num, int number, DateTime monday, DateTime sunday)
        {
            m_Monday = monday;
            m_sunday = sunday;
            m_number = number;
            m_monthNumber = month_num;
        }
        public WeekSource(string month, int number, DateTime monday, DateTime sunday)
        {
            m_Monday = monday;
            m_sunday = sunday;
            m_number = number;
            m_month = month;
        }

        public string Month
        {
            get { return m_month; }
            set { m_month = value; }
        }
        public int MonthNumber
        {
            get { return m_monthNumber; }
            set { m_monthNumber = value; }
        }
        public int Number
        {
            get { return m_number; }
            set { m_number = value; }
        }
        public DateTime Sunday
        {
            get { return m_sunday; }
            set { m_sunday = value; }
        }
        public DateTime Monday
        {
            get { return m_Monday; }
            set { m_Monday = value; }
        }
    }
}
