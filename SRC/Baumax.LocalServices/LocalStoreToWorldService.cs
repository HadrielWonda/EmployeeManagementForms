using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Environment;
using Baumax.Contract.TimePlanning;

namespace Baumax.LocalServices
{
    public class LocalStoreToWorldService : LocalBaseCachingService<StoreToWorld>, IStoreToWorldService
    {
        public override StoreToWorld AfterEntityLoaded(StoreToWorld entity)
        {
            return base.AfterEntityLoaded(FillWorldName(entity));
        }

        private StoreToWorld FillWorldName(StoreToWorld entity)
        {
            if (entity != null)
            {
                World related = ClientEnvironment.WorldService.FindById(entity.WorldID);
                if (related != null)
                {
                    entity.WorldName = related.Name;
                    entity.WorldTypeID = related.WorldTypeID;
                }
            }
            return entity;
        }

        private List<StoreToWorld> FillWorldName(List<StoreToWorld> entities)
        {
            if ((entities != null) && (entities.Count > 0))
            {
                foreach (StoreToWorld entity in entities)
                {
                    FillWorldName(entity);
                }
            }
            return entities;
        }

        private StoreWorldDetail FillWorldName(StoreWorldDetail entity)
        {
            if (entity != null)
            {
                World related = ClientEnvironment.WorldService.GetByStoreToWorldID(entity.StoreWorldId);
                if (related != null)
                {
                    entity.WorldName = related.Name;
                    entity.WorldTypeID = related.WorldTypeID;
                }
            }
            return entity;
        }

        private List<StoreWorldDetail> FillWorldName(List<StoreWorldDetail> entities)
        {
            if ((entities != null) && (entities.Count > 0))
            {
                Dictionary<long, World> swDictionary = ClientEnvironment.WorldService.GetDictionaryByStoreToWorldIDList(entities.ConvertAll<long>(delegate(StoreWorldDetail swd) { return swd.StoreWorldId; }));
                if ((swDictionary != null) && (swDictionary.Count > 0))
                {
                    foreach (StoreWorldDetail entity in entities)
                    {
                        if (swDictionary.ContainsKey(entity.StoreWorldId))
                        {
                            World related = swDictionary[entity.StoreWorldId];
                            entity.WorldName = related.Name;
                            entity.WorldTypeID = related.WorldTypeID;
                        }
                    }
                }
            }
            return entities;
        }

        #region IStoreToWorldService Members

        public List<StoreWorldDetail> GetStoreWorldDetail(short year)
        {
            return FillWorldName(RemoteService.GetStoreWorldDetail(year));
        }

        public List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID)
        {
            return FillWorldName(RemoteService.GetStoreWorldDetail(year, storeID));
        }

        public List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID, long store_worldID)
        {
            return FillWorldName(RemoteService.GetStoreWorldDetail(year, storeID, store_worldID));
        }

        public List<StoreToWorld> FindAllForStore(long storeID)
        {
            return FillWorldName(RemoteService.FindAllForStore(storeID));
        }

        public List<StoreToWorld> FindAllForRegion(long regionID)
        {
            return FillWorldName(RemoteService.FindAllForRegion(regionID));
        }

        public List<StoreToWorld> FindAllForCountry(long countryID)
        {
            return FillWorldName(RemoteService.FindAllForCountry(countryID));
        }

        public IList GetCashDeskPeopleEstimated(DateTime begin, DateTime end, long storeID)
        {
            return RemoteService.GetCashDeskPeopleEstimated(begin, end, storeID);
        }

        public IList GetEstimatedWorldWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            return RemoteService.GetEstimatedWorldWorkingHours(begin, end, storeID, worldID);
        }

        public decimal GetEstimatedTargetedNetPerformance(short year, long storeID, long worldID)
        {
            return RemoteService.GetEstimatedTargetedNetPerformance(year, storeID, worldID);
        }


        public IList GetEstWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            return RemoteService.GetEstWorkingHours(begin, end, storeID, worldID);
        }

        public IList GetEstWorldDiffData(short year, long storeID, long worldID)
        {
            return RemoteService.GetEstWorldDiffData(year, storeID, worldID);
        }

        public IList GetEstWorldYearValues(short year, long storeID, long worldID)
        {
            return RemoteService.GetEstWorldYearValues(year, storeID, worldID);
        }

        public void ClearEstimation(long storeid, short year)
        {
            RemoteService.ClearEstimation(storeid, year);
        }

        #endregion

        private IStoreToWorldService RemoteService
        {
            get { return (IStoreToWorldService) _remoteService; }
        }

        /*public AssignResult WGRToHWGRAssign(long storeID, long hwgr_id, long wgr_id, DateTime beginTime,
                                            DateTime endTime)
        {
            return RemoteService.WGRToHWGRAssign(storeID, hwgr_id, wgr_id, beginTime, endTime);
        }

        public AssignResult HWGRToWorldAssign(long storeID, long world_id, long hwgr_id, DateTime beginTime,
                                              DateTime endTime)
        {
            return RemoteService.HWGRToWorldAssign(storeID, world_id, hwgr_id, beginTime, endTime);
        }*/

        public List<WorldPlanningInfo> GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, DateTime beginWeekDate)
        {
            return RemoteService.GetStoreWorldPlanningInfo(IsPlanning, storeid, beginWeekDate);
        }

        public WorldPlanningInfo GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, long worldid,
                                                           DateTime beginWeekDate)
        {
            return RemoteService.GetStoreWorldPlanningInfo(IsPlanning, storeid, worldid, beginWeekDate);
        }
    }
}