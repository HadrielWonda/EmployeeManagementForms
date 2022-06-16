using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.LocalServices
{
    public class LocalWorldToHwgrService : LocalBaseCachingService<WorldToHwgr>, IWorldToHwgrService
    {
        public override WorldToHwgr AfterEntityLoaded(WorldToHwgr entity)
        {
            return base.AfterEntityLoaded(FillHwgrName(entity));
        }
        
        private WorldToHwgr FillHwgrName(WorldToHwgr entity)
        {
            if (entity != null)
            {
                HWGR related = ClientEnvironment.HWGRService.FindById(entity.HWGR_ID);
                if (related != null)
                {
                    entity.HwgrName = related.Name;
                }
            }
            return entity;
        }

        private List<WorldToHwgr> FillHwgrName(List<WorldToHwgr> entities)
        {
            if ((entities != null) && (entities.Count > 0))
            {
                foreach (WorldToHwgr entity in entities)
                {
                    FillHwgrName(entity);
                }
            }
            return entities;
        }

        #region IWorldToHwgrService Members

        public List<WorldToHwgr> InsertRelation(WorldToHwgr entity)
        {
            List<WorldToHwgr> lst = RemoteService.InsertRelation(entity);
            return FillHwgrName(lst);
        }

        public List<WorldToHwgr> GetWorldToHwgrFiltered(DateTime dateon)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(WorldToHwgr entity)
                                          {
                                              return
                                                  ((entity.BeginTime <= dateon) &&
                                                   (entity.EndTime >= dateon));
                                          }
                    );
            }
            return FillHwgrName(RemoteService.GetWorldToHwgrFiltered(dateon));
        }

        public List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return _cache.GetFiltered(delegate(WorldToHwgr entity)
                                          {
                                              return (entity.StoreID == storeID);
                                          }
                    );
            }
            return FillHwgrName(RemoteService.GetWorldToHwgrFiltered(storeID));
        }

        public List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID, long worldID, long hwgrID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(WorldToHwgr entity)
                                          {
                                              return (entity.StoreID == storeID && entity.WorldID == worldID && entity.HWGR_ID == hwgrID);
                                          }
                    );
            }
            return FillHwgrName(RemoteService.GetWorldToHwgrFiltered(storeID, worldID, hwgrID));
        }

        public List<World_HWGR_SysValues> Get_World_HWGR_SysValues()
        {
            return RemoteService.Get_World_HWGR_SysValues();
        }

        #endregion

        private IWorldToHwgrService RemoteService
        {
            get { return (IWorldToHwgrService) _remoteService; }
        }
    }
}