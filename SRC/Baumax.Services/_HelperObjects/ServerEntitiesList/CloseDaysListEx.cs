using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using Baumax.Domain;


namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    
    public class CountryCloseDaysListEx : Dictionary<DateTime, YearlyWorkingDay>
    {
        private long _countryid;

        public long CountryId
        {
            get { return _countryid; }
            set { _countryid = value; }
        }

        private DateTime _from_date = DateTimeSql.SmallDatetimeMin ;

        public DateTime FromDate
        {
            get { return _from_date; }
            set { _from_date = value; }
        }
        private DateTime _to_date = DateTimeSql.SmallDatetimeMax;

        public DateTime ToDate
        {
            get { return _to_date; }
            set { _to_date = value; }
        }

        public YearlyWorkingDayService Service
        {
            get { return ServerEnvironment.YearlyWorkingDayService as YearlyWorkingDayService; }
        }

        public CountryCloseDaysListEx()
        {

        }
        public CountryCloseDaysListEx(long countryid)
        {
            CountryId = countryid;
            DoLoad(CountryId, FromDate, ToDate);
        }

        public CountryCloseDaysListEx(long countryid, DateTime from, DateTime to)
        {
            CountryId = countryid;
            FromDate = DateTimeSql.CheckSmallMinMax(from);
            ToDate = DateTimeSql.CheckSmallMinMax(to); 

            DoLoad(CountryId, FromDate, ToDate);
        }

        protected void DoLoad(long countryid, DateTime from, DateTime to)
        {
            if (CountryId <= 0) return;

            DateTime from1 = DateTimeSql.CheckSmallMinMax(from);
            DateTime to1 = DateTimeSql.CheckSmallMinMax(to);

            BuildDiction(Service.GetYearlyWorkingDaysFiltered (countryid, from1, to1));
        }
        protected void BuildDiction(ICollection collection)
        {
            
            this.Clear();
            if (collection != null)
            {
                foreach (YearlyWorkingDay f in collection)
                    this[f.WorkingDay] = f;
            }
        }

        public bool IsClosedDay(DateTime date)
        {
            return ContainsKey(date);
        }
    }



    public class BaumaxCloseDays
    {
        private Dictionary<long, CountryCloseDaysListEx> _diction = new Dictionary<long, CountryCloseDaysListEx>();
        private DateTime _from_date = DateTimeSql.SmallDatetimeMin;

        public DateTime FromDate
        {
            get { return _from_date; }
            private set { _from_date = value; }
        }
        private DateTime _to_date = DateTimeSql.SmallDatetimeMax;

        public DateTime ToDate
        {
            get { return _to_date; }
            private set { _to_date = value; }
        }
        public BaumaxCloseDays()
        {

        }

        public BaumaxCloseDays(DateTime from, DateTime to)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(from);
            ToDate = DateTimeSql.CheckSmallMinMax(to); 
        }

        public BaumaxCloseDays(DateTime from)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(from);
        }


        public CountryCloseDaysListEx this[long id]
        {
            get
            {
                CountryCloseDaysListEx item = null;
                if (!_diction.TryGetValue(id, out item))
                {
                    item = DoLoad(id, FromDate, ToDate);
                }
                return item;

            }
        }



        public YearlyWorkingDay CloseDayExists(long countryid, DateTime date)
        {
            CountryCloseDaysListEx item = this[countryid];
            YearlyWorkingDay feast = null;
            if (item != null)
                item.TryGetValue(date, out feast);

            return feast;
        }

        public bool IsCloseDay(long countryid, DateTime date)
        {
            return CloseDayExists(countryid, date) != null;
        }

        protected virtual CountryCloseDaysListEx DoLoad(long countryid, DateTime from, DateTime to)
        {
            CountryCloseDaysListEx item = new CountryCloseDaysListEx(countryid, from, to);
            _diction[countryid] = item;
            return item;
        }
    }
}
