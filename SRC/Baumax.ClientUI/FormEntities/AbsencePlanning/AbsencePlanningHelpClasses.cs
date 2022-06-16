using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.AbsencePlanning
{
    public enum BandInfoType
    {
        Month,
        Week,
        Day
    }
    public class BandInfo
    {
        public BandInfoType BandType = BandInfoType.Month;
    }
    public class MonthBandInfo: BandInfo 
    {
        public int Month = 1;
        public MonthBandInfo()
        {
            BandType = BandInfoType.Month;
        }
        public MonthBandInfo(int month):this()
        {
            Month = month;
        }
    }

    public class WeekBandInfo : BandInfo
    {
        public int Week = 1;
        public WeekBandInfo()
        {
            BandType = BandInfoType.Week;
        }
        public WeekBandInfo(int week):this()
        {
            Week = week;
        }
    }

    public class DayBandInfo : BandInfo
    {
        public DateTime Date;
        public int WeekNumber = 1;
        public DayBandInfo()
        {
            BandType = BandInfoType.Day;
        }
        public DayBandInfo(DateTime date):this()
        {
            Date = date;

            WeekNumber = DateTimeHelper.GetWeekNumber(Date);
        }
    }
}
