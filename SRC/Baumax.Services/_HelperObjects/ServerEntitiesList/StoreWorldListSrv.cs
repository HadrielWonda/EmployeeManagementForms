using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    public class StoreWorldListSrv:List<StoreToWorld>
    {
        private Store _store;
        private long _storeid = 0;

        public Store Store
        {
            get { return GetStoreEntity(); }
        }

        protected Store GetStoreEntity()
        {
            if (_store == null)
            {
                _store = ServerEnvironment.StoreService.FindById(_storeid);
            }
            return _store; 
        }

        public StoreWorldListSrv(long storeid)
        {
            if (storeid <= 0)
                throw new ArgumentNullException();

            _storeid = storeid;
            Load();
        }

        public StoreWorldListSrv(Store store)
        {
            if (store == null)
                throw new ArgumentNullException ();

            _store = store;
            _storeid = store.ID;

            Load();
        }

        private void Load()
        {
            List<StoreToWorld> lst = ServerEnvironment.StoreToWorldService.FindAllForStore(_storeid);
            if (lst != null)
            {
                this.AddRange(lst);
            }
        }

        public StoreToWorld GetById(long id)
        {
            foreach (StoreToWorld entity in this)
                if (entity.ID == id) return entity;

            return null;
        }
        public StoreToWorld GetByWorldId(long id)
        {
            foreach (StoreToWorld entity in this)
                if (entity.WorldID == id) return entity;

            return null;
        }

    }
}
