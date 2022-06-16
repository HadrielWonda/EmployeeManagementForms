using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;

namespace Baumax.Contract.HolydayClasses
{
    //public class YearAppearance
    //{
    //    private int _year;
    //    private double _AvgWorkingDayByWeek = 5;
    //    private DateTime _begin;
    //    private DateTime _end;
    //    private int _weeknumber;
    //    private long _storeid;
    //    private long _countryID;


    //    public long CountryID
    //    {
    //        get { return _countryID; }
    //        set { _countryID = value; }
    //    }
    //    public int Year
    //    {
    //        get { return _year; }
    //        set
    //        {
    //            _year = value;
    //            BuildDateRange();
    //        }
    //    }
    //    public DateTime Begin
    //    {
    //        get { return _begin; }
    //        set { _begin = value; }
    //    }
    //    public DateTime End
    //    {
    //        get { return _end; }
    //        set { _end = value; }
    //    }
    //    public int WeekNumber
    //    {
    //        get { return _weeknumber; }
    //        set { _weeknumber = value; }
    //    }
    //    public long StoreID
    //    {
    //        get { return _storeid; }
    //        set { _storeid = value; }
    //    }

    //    public DateTime GetWeekBeginDate(int weeknumber)
    //    {
    //        return Begin.AddDays(weeknumber * 7);
    //    }

    //    public double AvgWorkingDayByWeek
    //    {
    //        get { return _AvgWorkingDayByWeek; }
    //        set { _AvgWorkingDayByWeek = value; }
    //    }

    //    private void BuildDateRange()
    //    {
    //        _begin = DateTimeHelper.GetBeginYearDate(Year);
    //        _end =   DateTimeHelper.GetEndYearDate(Year);
    //    }

    //    public DateTime GetDay(int mondayPlus)
    //    {
    //        return _begin.AddDays(mondayPlus);
    //    }

    //    public DateTime GetDay(int week, int mondayPlus)
    //    {
    //        return _begin.AddDays((week - 1) * 7 + mondayPlus);
    //    }

    //    public int GetWithWeek(int tag)
    //    {
    //        return (_weeknumber - 1)*7 + tag;
    //    }

    //    public bool IsValidDate(DateTime date)
    //    {
    //        return date >= _begin && date <= _end;
    //    }

    //    public bool IsValidIndex(int index)
    //    {
    //        return index >= 0 && _begin.AddDays(index) <= _end;
    //    }
    //}
}
