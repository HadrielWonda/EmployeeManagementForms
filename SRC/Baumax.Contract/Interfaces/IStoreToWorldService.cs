using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.Interfaces
{
    public interface IStoreToWorldService : IBaseService<StoreToWorld>
    {
        List<StoreWorldDetail> GetStoreWorldDetail(short year);
        List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID);
        List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID, long store_worldID);

        List<StoreToWorld> FindAllForStore(long storeID);
        List<StoreToWorld> FindAllForRegion(long regionID);
        List<StoreToWorld> FindAllForCountry(long countryID);
        //AssignResult WGRToHWGRAssign(long storeID, long hwgr_id, long wgr_id, DateTime beginTime, DateTime endTime);
        //AssignResult HWGRToWorldAssign(long storeID, long world_id, long hwgr_id, DateTime beginTime, DateTime endTime);
        IList GetCashDeskPeopleEstimated(DateTime begin, DateTime end, long storeID);
        List<WorldPlanningInfo> GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, DateTime beginWeekDate);
        WorldPlanningInfo GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, long worldid, DateTime beginWeekDate);
        IList GetEstimatedWorldWorkingHours(DateTime begin, DateTime end, long storeID, long worldID);
        decimal GetEstimatedTargetedNetPerformance(short year, long storeID, long worldID);

        IList GetEstWorkingHours(DateTime begin, DateTime end, long storeID, long worldID);
        IList GetEstWorldDiffData(short year, long storeID, long worldID);
        IList GetEstWorldYearValues(short year, long storeID, long worldID);
        void ClearEstimation(long storeid, short year);

    }
}