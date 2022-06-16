using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Baumax.Contract;

namespace Baumax.ClientUI
{
    class DateTimeHelper
    {
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
        public static DateTime GetSunday(DateTime end)
        {
            DayOfWeek sunday = end.DayOfWeek;
            if (sunday != DayOfWeek.Sunday)
                end += new TimeSpan(7 - (int)sunday, 0, 0, 0);
            if (end > DateTimeSql.SmallDatetimeMax) end = DateTimeSql.SmallDatetimeMax;
            return end;
        }
        public static DateTime GetMonday(DateTime begin)
        {
            DayOfWeek monday = begin.DayOfWeek;
            if (monday != DayOfWeek.Monday)
                begin -= new TimeSpan((int)monday - 1, 0, 0, 0);
            if (begin > DateTimeSql.SmallDatetimeMax) begin = DateTimeSql.SmallDatetimeMax;
            return begin;
        }

        public static DateTime GetNextMonday(DateTime begin)
        {
            DateTime dt = GetMonday(begin);
            if (dt < begin) dt = dt.AddDays(7);
            return dt;
        }

        public static DateTime GetNextSunday(DateTime end)
        {
            DateTime dt = GetSunday(end);
            if (dt < end) dt = dt.AddDays(7);
            return dt;
        }

        public static bool IsHitInInterval (DateTime hitter, DateTime date1, DateTime date2) 
        {
            return (date1 <= date2)
                ? hitter.Date <= date2.Date && hitter.Date >= date1.Date
                : hitter.Date >= date2.Date && hitter.Date <= date1.Date;
        }

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
    }
}
