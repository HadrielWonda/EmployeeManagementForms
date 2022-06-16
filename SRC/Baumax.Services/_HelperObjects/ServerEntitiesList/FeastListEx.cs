using System;
using System.Collections.Generic;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using System.Collections;
using Baumax.Domain;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    public class CountryFeastListEx : Dictionary<DateTime, Feast>
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

        public FeastService Service
        {
            get { return ServerEnvironment.FeastService as FeastService; }
        }

        public CountryFeastListEx()
        {

        }
        public CountryFeastListEx(long countryid)
        {
            CountryId = countryid;
            DoLoad(CountryId, FromDate, ToDate);
        }

        public CountryFeastListEx(long countryid, DateTime from, DateTime to)
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

            BuildDiction(Service.GetFeastsFiltered(countryid, from1, to1));
        }
        protected void BuildDiction(ICollection collection)
        {
            
            this.Clear();
            if (collection != null)
            {
                foreach (Feast f in collection)
                    this[f.FeastDate] = f;
            }
        }

        public bool IsFeast(DateTime date)
        {
            return ContainsKey(date);
        }
    }



    public class BaumaxFeasts
    {
        private Dictionary<long, CountryFeastListEx> _diction = new Dictionary<long, CountryFeastListEx>();
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
        public BaumaxFeasts()
        {

        }

        public BaumaxFeasts(DateTime from, DateTime to)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(from);
            ToDate = DateTimeSql.CheckSmallMinMax(to); 
        }

        public BaumaxFeasts(DateTime from)
        {
            FromDate = DateTimeSql.CheckSmallMinMax(from);
        }


        public CountryFeastListEx this[long id]
        {
            get
            {
                CountryFeastListEx item = null;
                if (!_diction.TryGetValue(id, out item))
                {
                    item = DoLoad(id, FromDate, ToDate);
                }
                return item;

            }
        }



        public Feast FeastExists(long countryid, DateTime date)
        {
            CountryFeastListEx item = this[countryid];
            Feast feast = null;
            if (item != null)
                item.TryGetValue(date, out feast);

            return feast;
        }

        public bool IsFeast(long countryid, DateTime date)
        {
            return FeastExists(countryid, date) != null;
        }

        protected virtual CountryFeastListEx DoLoad(long countryid, DateTime from, DateTime to)
        {
            CountryFeastListEx item = new CountryFeastListEx(countryid, from, to);
            _diction[countryid] = item;
            return item;
        }
    }
}
