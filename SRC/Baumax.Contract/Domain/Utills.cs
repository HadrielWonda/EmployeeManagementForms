using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Domain
{
    public class Utills
    {
        #region time / absence planning

        public const decimal DayMinutes = 24 * 60;
        public const int MinutesInDay = 24 * 60;

        public static decimal ToDays(int minutes)
        {
            return (decimal)minutes / DayMinutes;
        }

        //public static short GetEntityTime(short begin, short end, decimal contractHours, decimal weekDays)
        //{
        //    return (short)((end - begin) /
        //           ((decimal)contractHours / (decimal)weekDays / DayMinutes));
        //}

        //public static short GetEntityTime(short begin, short end, decimal coeficient)
        //{
        //    return (short)((decimal)(end - begin) / coeficient);
        //}

        public static short GetEntityTime(Absence absence, short begin, short end, double contractHours, double weekDays)
        {

            if (absence != null && absence.CountAsOneDay)
                return (short)MinutesInDay;

            return GetEntityTime(absence, (end - begin), contractHours, weekDays);

            //return (short)((end - begin) /
            //       ((double)contractHours / (double)weekDays / (double)DayMinutes));
        }
        public static short GetEntityTime(Absence absence, int time, double contractHours, double weekDays)
        {
            
            //if (absence != null && absence.CountAsOneDay)
            //    return (short)MinutesInDay;

            return (short)Math.Round ((time /
                   (contractHours / weekDays / (double)DayMinutes)));
        }

        public static int AvgWorkingHoursPerDay(double contracthours, double avg_working_days)
        {
            return (int)Math.Round (contracthours / avg_working_days, 0);
        }

#endregion
    }
}
