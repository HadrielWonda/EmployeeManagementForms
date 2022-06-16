using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract
{
	public static class DateTimeSql
	{
        const int _Seconds = 60 * 24 * 60 - 1;
        readonly public static string SmallDatetimeMinStr;
		readonly public static string SmallDatetimeMaxStr;
		readonly public static string DatetimeMinStr;
		readonly public static string DatetimeMaxStr;

		readonly public static DateTime SmallDatetimeMin;
		readonly public static DateTime SmallDatetimeMax;
		readonly public static DateTime DatetimeMin;
		readonly public static DateTime DatetimeMax;

        readonly public static DateTime LastMaxSunday;
        readonly public static DateTime FirstMinMonday;

        public static DateTime GetBegin(DateTime date)
        {
            return date.Date; 
        }

        public static DateTime GetEnd(DateTime date)
        {
            if (date != DatetimeMax && date != SmallDatetimeMax)
                date.Date.AddSeconds(_Seconds);
            return date;
        }
        public static DateTime CheckSmallMinMax(DateTime date)
        {
            if (date < SmallDatetimeMin) return SmallDatetimeMin;
            if (date > SmallDatetimeMax) return SmallDatetimeMax;
            return date;
        }
        public static DateTime CheckSmallMin(DateTime date)
        {
            if (date < SmallDatetimeMin) return SmallDatetimeMin;
            return date;
        }

        public static DateTime CheckSmallMax(DateTime date)
        {
            if (date > SmallDatetimeMax) return SmallDatetimeMax;
            return date;
        }

        public static string DateToSqlString(DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

		static DateTimeSql()
		{
			//January 1, 1900, through June 6, 2079
			SmallDatetimeMinStr = "19000101";
			SmallDatetimeMaxStr = "20790606";
			//January 1, 1753, through December 31, 9999
			DatetimeMinStr = "17530101";
			DatetimeMaxStr = "99991231";
			SmallDatetimeMin = DateTime.ParseExact(SmallDatetimeMinStr, "yyyyMMdd", null);
			SmallDatetimeMax = DateTime.ParseExact(SmallDatetimeMaxStr, "yyyyMMdd", null);
			DatetimeMin = DateTime.ParseExact(DatetimeMinStr, "yyyyMMdd", null);
			DatetimeMax = DateTime.ParseExact(DatetimeMaxStr, "yyyyMMdd", null);
            LastMaxSunday = new DateTime(2079,6, 4);
            FirstMinMonday = new DateTime(1900, 1, 1);
		}
	}
}
