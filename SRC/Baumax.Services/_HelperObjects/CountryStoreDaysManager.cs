using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using System.Collections;
using Baumax.Domain;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    public class CountryStoreDaysManager
    {
        private Dictionary<long, List<StoreWorkingTime>> _diction = new Dictionary<long, List<StoreWorkingTime>>();

        private CountryFeastListEx _feast_manager = null;
        private CountryCloseDaysListEx _closeday_manager = null;

        private Dictionary<long, Dictionary<DateTime, StoreDay>> _cellDiction = new Dictionary<long, Dictionary<DateTime, StoreDay>>();
        private long _CountryId;
        private DateTime _beginDate = DateTimeSql.SmallDatetimeMin;
        private DateTime _endDate = DateTimeSql.SmallDatetimeMax;


        protected StoreService Service
        {
            get { return ServerEnvironment.StoreService as StoreService; }
        }

        public long CountryId
        {
            get { return _CountryId; }
            protected set { _CountryId = value; }
        }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            protected set { _beginDate = value; }
        }

        public DateTime  EndDate
        {
            get { return _endDate; }
            protected set { _endDate = value; }
        }

        public CountryStoreDaysManager(long countryid, DateTime begin)
        {
            _CountryId = countryid;
            BeginDate = begin;
            Init();
        }
        public void Init()
        {
            _feast_manager = new CountryFeastListEx(CountryId, BeginDate, EndDate);
            _closeday_manager = new CountryCloseDaysListEx(CountryId, BeginDate, EndDate);

        }

        public void LoadStoreInfo(long storeid)
        {
            if (!_diction.ContainsKey(storeid))
            {
                List<StoreWorkingTime> lst = Service.StoreWorkingTimeService.GetWorkingTimeFiltered(storeid, BeginDate, EndDate);
                _diction[storeid] = lst;
            }
        }

        public StoreDay GetDayInfo(long storeid, DateTime date)
        {
            if (!_diction.ContainsKey(storeid))
                LoadStoreInfo(storeid);

            Dictionary <DateTime , StoreDay > dict = null;
            StoreDay day = null;
            if (!_cellDiction.TryGetValue(storeid, out dict))
            {
                dict = new Dictionary<DateTime, StoreDay>();
                _cellDiction[storeid] = dict;
            }

            if (!dict.TryGetValue(date, out day))
            {
                day = BuildStoreDay(storeid, date);
                
                if (day == null)
                    throw new ArgumentNullException();

                dict[date] = day;
            }

            return day;


        }

        private StoreDay BuildStoreDay(long storeid, DateTime date)
        {

            bool feast = false;
            bool closed = false;
            StoreDay day = null;

            feast = _feast_manager.IsFeast(date);

            closed = _closeday_manager.IsClosedDay (date);
                

            List<StoreWorkingTime > lst = null;
            if (_diction.TryGetValue(storeid, out lst))
            {
                if (lst != null)
                {
                    foreach (StoreWorkingTime swt in lst)
                    {
                        if (swt.BeginTime <= date && date <= swt.EndTime)
                        {
                            day = new StoreDay(date);
                            day.Feast = feast;
                            day.ClosedDay = closed;
                            if (swt.StoreWTWeekdays != null)
                            {
                                foreach (StoreWTWeekday weekday in swt.StoreWTWeekdays)
                                {
                                    if (weekday.Weekday == (byte)date.DayOfWeek)
                                    {
                                        day.OpenTime = weekday.Opentime;
                                        day.CloseTime = weekday.Closetime;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return day;
            
        }


    }

    public class BaumaxStoreDaysManager
    {
        private Dictionary<long, CountryStoreDaysManager> _diction = new Dictionary<long, CountryStoreDaysManager>();

        private DateTime _FromDate = DateTimeSql.SmallDatetimeMin;
        private DateTime _ToDate = DateTimeSql.SmallDatetimeMax;

        public DateTime FromDate
        {
            get { return _FromDate; }
            protected set { _FromDate = value; }
        }

        public DateTime ToDate
        {
            get { return _ToDate; }
            protected set { _ToDate = value; }
        }
        #region ctor

        public BaumaxStoreDaysManager()
        {
        }
        public BaumaxStoreDaysManager(DateTime fromDate)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(fromDate);
        }
        public BaumaxStoreDaysManager(DateTime fromDate, DateTime toDate)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(fromDate);
            ToDate = DateTimeSql.CheckSmallMinMax(toDate);
        }
        public BaumaxStoreDaysManager(long countryid, DateTime fromDate, DateTime toDate)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(fromDate);
            ToDate = DateTimeSql.CheckSmallMinMax(toDate);

            LoadCountry(countryid);
        }

        public BaumaxStoreDaysManager(long countryid, DateTime fromDate)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(fromDate);
            LoadCountry(countryid);
        }
        public BaumaxStoreDaysManager(long countryid)
        {
            LoadCountry(countryid);
        }

        #endregion

        public CountryStoreDaysManager this[long countryid]
        {
            get
            {
                CountryStoreDaysManager manager = null;
                if (!_diction.TryGetValue(countryid, out manager))
                {
                    manager = LoadCountry(countryid);

                }
                return manager;
            }
        }
        protected CountryStoreDaysManager LoadCountry(long countryid)
        {
            CountryStoreDaysManager manager = DoLoad(countryid, FromDate, ToDate);
            _diction[countryid] = manager;
            return manager;
        }
        protected CountryStoreDaysManager DoLoad(long countryid, DateTime fromdate, DateTime todate)
        {
            CountryStoreDaysManager manager = new CountryStoreDaysManager(countryid, fromdate);
            return manager;
        }
    }
}
