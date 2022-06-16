using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.Contract
{
    public class StoreWorldManager
    {
        private IStoreToWorldService _service = null;
        private long _storeid;
        private Dictionary<long, StoreToWorld> _dictionworld = new Dictionary<long, StoreToWorld>();
        private Dictionary<long, StoreToWorld> _dictionentity = new Dictionary<long, StoreToWorld>();

        public StoreWorldManager(IStoreToWorldService service)
        {
            _service = service;
        }

        public long StoreId
        {
            get { return _storeid; }
            set 
            { 
                _storeid = value;
                LoadWorlds();
            }
        }

        private void LoadWorlds()
        {
            _dictionworld.Clear();
            _dictionentity.Clear();
            if (StoreId > 0)
            {
                List<StoreToWorld> lst = _service.FindAllForStore(StoreId);

                if (lst != null)
                {
                    foreach (StoreToWorld sw in lst)
                    {
                        _dictionworld[sw.WorldID] = sw;
                        _dictionentity[sw.ID] = sw;
                    }
                }
            }
        }

        public long GetStoreWorldIdByWorldId(long id)
        {
            StoreToWorld sw = null;
            if (_dictionworld.TryGetValue(id, out sw))
                return sw.ID;

            return 0;
        }

        public StoreToWorld GetById(long id)
        {
            StoreToWorld sw = null;
            if (_dictionentity.TryGetValue(id, out sw))
                return sw;

            return null;
        }


    }

    public class CountryStoreWorldManager
    {
        private IStoreToWorldService _service = null;
        private long _countryid;
        private Dictionary<long, StoreToWorld> _dictionentity = new Dictionary<long, StoreToWorld>();

        private Dictionary<long, Dictionary<long, StoreToWorld>> _dictionbyStore = new Dictionary<long, Dictionary<long, StoreToWorld>>();

        public CountryStoreWorldManager(IStoreToWorldService service)
        {
            _service = service;
        }

        public long CountryId
        {
            get { return _countryid; }
            set
            {
                _countryid = value;
                LoadWorlds();
            }
        }

        private void LoadWorlds()
        {
            _dictionbyStore.Clear();
            _dictionentity.Clear();
            if (CountryId > 0)
            {
                List<StoreToWorld> lst = _service.FindAllForCountry(CountryId);

                if (lst != null)
                {
                    foreach (StoreToWorld sw in lst)
                    {
                        
                        _dictionentity[sw.ID] = sw;

                        if (_dictionbyStore.ContainsKey(sw.StoreID))
                        {
                            _dictionbyStore[sw.StoreID].Add(sw.WorldID, sw);
                        }
                        else
                        {
                            Dictionary<long, StoreToWorld> newitem = new Dictionary<long, StoreToWorld>();
                            newitem.Add(sw.WorldID, sw);
                            _dictionbyStore[sw.StoreID] = newitem;
                        }
                    }
                }
            }
        }

        public long GetStoreWorldIdByStoreAndWorldId(long storeid, long worldid)
        {
            Dictionary<long, StoreToWorld> dict = null;
            StoreToWorld entity = null;
            if (_dictionbyStore.TryGetValue(storeid, out dict))
            {
                dict.TryGetValue (worldid, out entity);

                return (entity != null) ? entity.ID : 0;
            }
            else
            {
                return LoadByStore(storeid,worldid);
            }
        }

        private long LoadByStore(long storeid, long worldid)
        {
            List<StoreToWorld> lst = _service.FindAllForStore(storeid);
            StoreToWorld entity = null;
            Dictionary<long, StoreToWorld> newitem = new Dictionary<long, StoreToWorld>();
            if (lst != null)
            {
                foreach (StoreToWorld sw in lst)
                {
                    newitem[sw.WorldID] = sw;
                    _dictionentity[sw.ID] = sw;
                    if (sw.WorldID == worldid)
                        entity = sw;
                }
            }
            _dictionbyStore[storeid] = newitem;


            return (entity != null) ? 0 : entity.ID;

        }

        public StoreToWorld GetById(long id)
        {
            StoreToWorld sw = null;
            _dictionentity.TryGetValue(id, out sw);

            return sw;
        }


    }
}
