using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    using Baumax.Domain;
   

    /*public class WeekDayOpenCloseTime
    {
        Domain.StoreWTWeekday _day = null;
        public bool Modified = false;
        public WeekDayOpenCloseTime()
        {

        }
        public WeekDayOpenCloseTime(Domain.StoreWTWeekday day)
        {
            _day = day;
        }
        public Domain.StoreWTWeekday DayMask
        {
            get
            {
                return _day;
            }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    Modified = false;
                }

            }
        }


        public short OpenTime
        {
            get
            {
                return _day.Opentime;
            }
            set
            {
                if (value != _day.Opentime)
                {
                    Modified = true;
                    _day.Opentime = value;
                }
            }
        }
        public short CloseTime
        {
            get
            {
                return _day.Closetime;
            }
            set
            {
                if (value != _day.Closetime)
                {
                    Modified = true;
                    _day.Closetime = value;
                }
            }
        }

        public string DisplayString
        {
            get
            {
                if (DayMask == null) return String.Empty;
                else if (DayMask.Closetime == 0) return String.Empty;
                else return BaumaxTimeHelper.GetTimeAsString(DayMask.Opentime, DayMask.Closetime);
            }
            set
            {
                if (DayMask != null)
                {
                    string sValue = value.Trim();
                    if (String.IsNullOrEmpty(sValue))
                    {
                        if (DayMask != null)
                        {
                            DayMask.Opentime = DayMask.Closetime = 0;
                        }
                    }
                    else
                    {
                        short[] times = BaumaxTimeHelper.GetTimeRangeFromString(sValue);
                        if (times != null && times.Length == 2)
                        {
                            DayMask.Opentime = times[0];
                            DayMask.Closetime = times[1];
                        }
                    }
                }

            }
        }

    }*/
    public class BaumaxTimeHelper
    {
        public static DateTime GetTime(short time)
        {
            int hour =(int) (time / 60);
            int minutes = time % 60;
            DateTime now = DateTime.Now;
            DateTime result = new DateTime (now.Year, now.Month, now.Day, hour, minutes, 0);
            return result;
        }

        public static string GetTimeAsString(short time)
        {
            int hour = (int)(time / 60);
            int minutes = time % 60;
            return String.Format ("{0}:{1:D2}", hour,minutes);
        }
        public static string GetTimeAsString(short starttime, short endtime)
        {
            System.Diagnostics.Debug.Assert(starttime >= 0 && starttime < 60*24);
            System.Diagnostics.Debug.Assert(endtime >= 0 && endtime < 60 * 24);
            System.Diagnostics.Debug.Assert(starttime < endtime);
            if (endtime == 0) return String.Empty;
            else 
                return String.Format("{0}-{1}", GetTimeAsString (starttime), GetTimeAsString (endtime));
        }

        public static short[] GetTimeRangeFromString(string times)
        {
            short[] result = new short[2];
            result[0] = 0;
            result[1] = 0;
            string[] str = times.Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
            if (str.Length == 2)
            {

                string[] hm = str[0].Split (':');
                result[0] = GetTimeFromString(str[0]);
                result[1] = GetTimeFromString(str[1]);
            }
            return result;
        }
        public static short GetTimeFromString(string time)
        {
            string[] arr = time.Split(':');
            int h = Convert.ToInt16(arr[0]);
            int m = Convert.ToInt16(arr[1]);

            return (short)(h * 60 + m);
        }

           
    }
}
