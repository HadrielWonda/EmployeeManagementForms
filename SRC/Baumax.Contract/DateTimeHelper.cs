using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
namespace Baumax.Contract
{
    public class DateTimeHelper
    {

        public static int SubstractDateRange(DateTime begin1, DateTime end1, DateTime begin2, DateTime end2)
        {

            if (IsIntersectExc(begin1, end1, begin2, end2))
            {
                DateTime begin, end;
                if (begin1 <= begin2)
                {
                    begin = begin2;
                }
                else
                {
                    begin = begin1;
                }

                if (end1 >= end2)
                    end = end2;
                else
                    end = end1;

                return end.Subtract(begin).Days+1;
            }
            return 0;
        }

        public static bool IsLastDayOfMonth(DateTime date)
        {
            int monthdays = DateTime.DaysInMonth(date.Year, date.Month);

            return (date.Day == monthdays);
        }
        public static void GetDateRangeByWeekNumber(int weeknumber, int year, out DateTime monday, out DateTime sunday)
        {
            DateTime beginYearDate = GetBeginYearDate(year);

            monday = beginYearDate.AddDays((weeknumber-1) * 7);
            sunday = monday.AddDays(6);
        }
        public static void GetDateRangeByMonthNumber(int year, int month, out DateTime begin, out DateTime end)
        {
            if (month == 1)
            {
                begin = DateTimeHelper.GetBeginYearDate(year);
            }
            else
            {
                begin = new DateTime(year, month, 1);
            }
            if (month == 12)
            {
                end = DateTimeHelper.GetEndYearDate(year);
            }
            else
            {
                end = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
        }
        public static int GetMonthNumberByWeekDateRange(DateTime monday, DateTime sunday)
        {
            if (monday.Month == sunday.Month) return monday.Month;
            int month = 1;
            if (monday.Year == sunday.Year)
            {
                int monthdaycount = DateTime.DaysInMonth(monday.Year, monday.Month);

                if (monthdaycount - monday.Day >= 3)
                {
                    month = monday.Month;
                }
                else
                {
                    month = sunday.Month;
                }
            }
            else
            {
                int year = GetYearByDate(monday);

                if (monday.Year == year)
                {
                    month = 12;
                }
                else
                {
                    month = 1;
                }
            }

            return month;

        }
        public static int GetMonthNumberByDate(DateTime date)
        {
            DateTime monday = GetMonday(date);
            DateTime sunday = GetSunday(date);

            return GetMonthNumberByWeekDateRange(monday, sunday);

        }
        public static int GetCountWeekInYear(int year)
        {
            DateTime date = new DateTime(year, 12, 31);
            date = GetMonday(date);
            CultureInfo info = CultureInfo.InvariantCulture;

            int lastweek = GetWeekNumber(date, date);
                //info.Calendar.GetWeekOfYear(new DateTime(year, 12, 31), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (lastweek == 1)
            {
                date = date.AddDays(-7);
                lastweek = GetWeekNumber(date, date);
                    //info.Calendar.GetWeekOfYear(new DateTime(year, 12, 24), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }

            return lastweek;


        }

        public static byte GetWeekNumber(DateTime begin,DateTime end)
        {
            
            CultureInfo info = CultureInfo.InvariantCulture;
            DateTime sunday = GetSunday(begin);
            return (byte)info.Calendar.GetWeekOfYear(sunday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        public static byte GetWeekNumber(DateTime date)
        {
            CultureInfo info = CultureInfo.InvariantCulture;
            DateTime sunday = GetSunday(date);
            return (byte)info.Calendar.GetWeekOfYear(sunday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        public static int GetYearByDate(DateTime date)
        {
            DateTime monday = GetMonday(date);
            DateTime sunday = GetSunday(date);

            if (monday.Year == sunday.Year) return monday.Year;

            byte week = GetWeekNumber(monday, sunday);

            if (week == 1) 
                return sunday.Year;
            else 
                return monday.Year;

            
        }

        public static DateTime GetBeginYearDate(int year)
        {
            DateTime dt = GetMonday(new DateTime(year, 1, 1));

            int w = GetWeekNumber(dt, dt);

            if (w != 1)
                dt = GetNextMonday(dt);

            return dt;
        }

        public static DateTime GetEndYearDate(int year)
        {
            DateTime dt = GetSunday(new DateTime(year, 12, 31));

            int w = GetWeekNumber(dt, dt);

            if (w == 1)
                dt = dt.AddDays(-7); 

            return dt;
        }



        public static DateTime ResetTime(DateTime dt)
        {
            //return new DateTime(dt.Year, dt.Month, dt.Day);
            return dt.Date;
        }

        public static bool IsIntersectExc(DateTime aBeginDate, DateTime aEndDate, DateTime bBeginDate, DateTime bEndDate)
        {
            Debug.Assert(aBeginDate <= aEndDate);
            Debug.Assert(bBeginDate <= bEndDate);
            //begin_a <= end_b || end_a >= begin_b;
            return !((aBeginDate > bEndDate) || (aEndDate < bBeginDate));
        }
        public static bool IsIntersectInc(DateTime aBeginDate, DateTime aEndDate, DateTime bBeginDate, DateTime bEndDate)
        {
            Debug.Assert(aBeginDate <= aEndDate);
            Debug.Assert(bBeginDate <= bEndDate);
            //begin_a <= end_b || end_a >= begin_b;
            return !((aBeginDate >= bEndDate) || (aEndDate <= bBeginDate));
        }
        
        public static bool IsDayInCurrentWeek(DateTime d)
        {
            DateTime now = DateTime.Now;
            DateTime begin = GetMonday(now);
            DateTime end = GetSunday(now);
            if (d >= begin && d <= end)
                return true;
            else 
                return false;
        }
        
        public static DateTime GetSunday(DateTime end)
        {
            DayOfWeek sunday = end.DayOfWeek;
            if (sunday != DayOfWeek.Sunday)
                end += new TimeSpan(7 - (int)sunday, 0, 0, 0);
            Debug.Assert(end.DayOfWeek == DayOfWeek.Sunday);
            if (end > DateTimeSql.SmallDatetimeMax) end = DateTimeSql.SmallDatetimeMax;
            return end;
        }
        public static DateTime GetMonday(DateTime begin)
        {
            DayOfWeek monday = begin.DayOfWeek;
            if (monday != DayOfWeek.Monday)
            {
                int shift = (int)monday;
                if (monday == DayOfWeek.Sunday) shift = 7;
                begin -= new TimeSpan(shift - 1, 0, 0, 0);
            }
            Debug.Assert(begin.DayOfWeek == DayOfWeek.Monday);

            if (begin > DateTimeSql.SmallDatetimeMax) begin = DateTimeSql.SmallDatetimeMax;
            
            return begin;
        }

        public static DateTime GetNextMonday(DateTime begin)
        {
            DateTime dt = GetMonday(begin);
            if (dt <= begin) dt = dt.AddDays(7);
            Debug.Assert(dt.DayOfWeek == DayOfWeek.Monday);

            return dt;
        }

        public static DateTime GetNextSunday(DateTime end)
        {
            DateTime dt = GetSunday(end);
            if (dt <= end) dt = dt.AddDays(7);
            Debug.Assert(dt.DayOfWeek == DayOfWeek.Sunday);
            return dt;
        }

        //public static bool IsIntervalInInterval(DateTime newDate1, DateTime newDate2, DateTime oldDate1, DateTime oldDate2)
        //{
        //    return (oldDate1 <= newDate1) && (newDate2 <= oldDate2 );
        //}
        /// <summary>
        /// Include new interval full include into old interval
        /// </summary>
        /// <param name="newDate1">new interval begin</param>
        /// <param name="newDate2">new interval end</param>
        /// <param name="oldDate1">old interval begin</param>
        /// <param name="oldDate2">old interval end</param>
        /// <returns></returns>
        public static bool Include(DateTime newDate1, DateTime newDate2, DateTime oldDate1, DateTime oldDate2)
        {
            return (oldDate1 <= newDate1) && (newDate2 <= oldDate2);
        }
         
        //public static bool IsHitInInterval (DateTime hitter, DateTime date1, DateTime date2) 
        //{
        //    return (date1 <= date2)
        //        ? hitter.Date <= date2.Date && hitter.Date >= date1.Date
        //        : hitter.Date >= date2.Date && hitter.Date <= date1.Date;
        //}

        public static bool IsEntryExc(DateTime incomingBegin, DateTime incomingEnd, DateTime inBegin, DateTime inEnd)
        {
            return incomingBegin >= inBegin && incomingEnd <= inEnd;
        }

        public static bool Between(DateTime date, DateTime a, DateTime b)
        {
            return (a <= date && date <= b);
        }

        public static string IntTimeToStr(int time)
        {
            int ihour = time / 60;
            int minute = Math.Abs (time % 60);
            return String.Format("{0}:{1}", ihour.ToString("00"), minute.ToString("00"));
        }
        public static string ShortTimeRangeToStr(short begin, short end)
        {
            return String.Format("{0}-{1}", IntTimeToStr(begin), IntTimeToStr(end));
        }
        public static string DecimalTimeToStr(decimal time)
        {
            int value = (int)(time * 60);
            int ihour = value / 60;
            int minute = Math.Abs (value % 60);
            return String.Format("{0}:{1}", ihour.ToString("00"), minute.ToString("00"));
        }
        public static bool IsIntersectInc(short aBeginTime, short aEndTime, short bBeginTime, short bEndTime)
        {
            Debug.Assert(aBeginTime <= aEndTime);
            Debug.Assert(bBeginTime <= bEndTime);
            
            return !((aBeginTime >= bEndTime) || (aEndTime <= bBeginTime));
        }
        
        public static DateTime ShortToDateTime(short time)
        {
            short t = RoundToQuoter (time);
            return new DateTime(2007, 1, 1, (int)(t / 60), (int)(t % 60), 0);
        }

        public static short DateTimeToShort(DateTime time)
        {
            return RoundToQuoter ((short)(time.Hour *60 + time.Minute));
        }
        public static short DateTimeToShortWithoutRound(DateTime time)
        {
            return ((short)(time.Hour * 60 + time.Minute));
        }
        public static short RoundToQuoter(short time)
        {
            short newtime = Math.Abs(time);
            short s = (short)(newtime % 15);

            if (s != 0)
            {
                if (s < 8) newtime -= s;
                else newtime += (short)(15 - s);
            }
            return (time >= 0)?(short)newtime:(short)-newtime;

        }
        public static int RoundToQuoter(int time)
        {
            int newtime = Math.Abs(time);
            int s = (newtime % 15);

            if (s != 0)
            {
                if (s < 8) newtime -= s;
                else newtime += (15 - s);
            }
            return (time >= 0) ? newtime : -newtime;

        }
        public static DayOfWeek ConvertBaumaxToWindowsDayOfWeek(BaumaxDayOfWeek dayOfWeek)
        {
            switch(dayOfWeek)
            {
                case BaumaxDayOfWeek.Monday:
                    return DayOfWeek.Monday;
                case BaumaxDayOfWeek.Tuesday:
                    return DayOfWeek.Tuesday;
                case BaumaxDayOfWeek.Wednesday:
                    return DayOfWeek.Wednesday;
                case BaumaxDayOfWeek.Thursday:
                    return DayOfWeek.Thursday;
                case BaumaxDayOfWeek.Friday:
                    return DayOfWeek.Friday;
                case BaumaxDayOfWeek.Saturday:
                    return DayOfWeek.Saturday;
                case BaumaxDayOfWeek.Sunday:
                    return DayOfWeek.Sunday;
                case BaumaxDayOfWeek.Empty:
                    break;
            }
            return DayOfWeek.Monday;
        }

        public static BaumaxDayOfWeek ConvertWindowsToBaumaxDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return BaumaxDayOfWeek.Monday;
                case DayOfWeek.Tuesday:
                    return BaumaxDayOfWeek.Tuesday;
                case DayOfWeek.Wednesday:
                    return BaumaxDayOfWeek.Wednesday;
                case DayOfWeek.Thursday:
                    return BaumaxDayOfWeek.Thursday;
                case DayOfWeek.Friday:
                    return BaumaxDayOfWeek.Friday;
                case DayOfWeek.Saturday:
                    return BaumaxDayOfWeek.Saturday;
                case DayOfWeek.Sunday:
                    return BaumaxDayOfWeek.Sunday;
            }
            return BaumaxDayOfWeek.Monday;
        }

        public static List<WeekSource> GetYearMap(int year)
        {
            List<WeekSource> list = new List<WeekSource>();
            DateTime start = new DateTime(year, 1, 1),
                     end = new DateTime(year, 12, 31), sunday;
            int endTime = (int)end.DayOfWeek;
            if (endTime != 0)
                end = end.AddDays(endTime < 4 ? -endTime : 7 - endTime);

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
            for (int i = 1; sunday <= end; i++)
            {
                list.Add(new WeekSource(start.Month, i, start, sunday));
                start = start.AddDays(7);
                sunday = start.AddDays(6);
            }
            return list;
        }

        public static WeekSource GetWeekSource(int year, int week)
        {
            return GetYearMap(year)[week - 1];
        }
    }
}
