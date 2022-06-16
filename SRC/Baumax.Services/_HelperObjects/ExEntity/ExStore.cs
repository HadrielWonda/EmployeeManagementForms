using System;
using System.Collections.Generic;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.Domain;
using System.Collections;

namespace Baumax.Services._HelperObjects.ExEntity
{
    public class ExStore
    {
        Dictionary<long, Store> _dictionStores = new Dictionary<long, Store>();
        protected static StoreService Service
        {
            get
            {
                return ServerEnvironment.StoreService as StoreService;
            }
        }

        public Store this[long id]
        {
            get
            {
                Store store = null;
                _dictionStores.TryGetValue(id, out store);
#if DEBUG
                if (store == null)
                    throw new ArgumentException("Store not found - " + id.ToString());
#endif
                return store;
            }
        }
        public bool IsAustria(long storeid)
        {
            Store store = this[storeid];

            if (store != null)
                return ServerEnvironment.CountryService.AustriaCountryID == store.CountryID;
            return false;
        }
        public long CountryId(long storeid)
        {
            Store store = this[storeid];
            if (store != null) 
                return store.CountryID;
            return 0;
        }

        protected void BuildDiction(ICollection stores)
        {
            _dictionStores.Clear();

            if (stores != null)
            {
                foreach (Store store in stores)
                    _dictionStores[store.ID] = store;
            }
        }
        public void LoadAll()
        {
            BuildDiction(Service.LoadAll());
        }
        public void LoadByCountry(long countryid)
        {
            BuildDiction(Service.GetStoresByCountryId (countryid ));
        }
        public void LoadCountryStoresByStore(long storeid)
        {
            long countryid = Service.GetCountryByStoreId(storeid);
            BuildDiction(Service.GetStoresByCountryId(countryid));
        }

        public bool UpdateLastPlanning(long storeid, DateTime monday)
        {
            return Service.LastEmployeeWeekTimePlanningUpdate(storeid, monday);
        }
        public bool UpdateLastRecording(long storeid, DateTime monday)
        {
            return Service.LastEmployeeWeekTimeRecordingUpdate(storeid, monday);
        }


    }
}
