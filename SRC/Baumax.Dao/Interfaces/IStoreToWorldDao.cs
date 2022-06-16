using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IStoreToWorldDao : IDao<StoreToWorld>
    {
        List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID, long store_worldID);

        IList FindAllForStore(long storeID);
        IList FindAllForRegion(long regionID);
        IList FindAllForCountry(long countryID);
        StoreToWorld FindByStoreAndWorld(long storeid, long worldid);
        AssignResult WGRToHWGRAssign(long storeID, long hwgr_id, long wgr_id, DateTime beginTime, DateTime endTime);
        AssignResult HWGRToWorldAssign(long storeID, long world_id, long hwgr_id, DateTime beginTime, DateTime endTime);
        IList GetCashDeskPeopleEstimated(DateTime begin, DateTime end, long storeID);
        IList GetEstimatedWorldWorkingHours(DateTime begin, DateTime end, long storeID, long worldID);
        decimal GetEstimatedTargetedNetPerformance(short year, long storeID, long worldID);

        IList GetEstWorkingHours(DateTime begin, DateTime end, long storeID, long worldID);
        IList GetEstWorldDiffData(short year, long storeID, long worldID);
        IList GetEstWorldYearValues(short year, long storeID, long worldID);
        void ClearEstimation(long storeid, short year);

        IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID, long worldID);
        IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID);
        IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID, long worldID);
        IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID);
        IList GetBusinessVolumeCRRSum(DateTime begin, DateTime end, long storeID);
        IList GetBusinessVolumeCRR(DateTime begin, DateTime end, long storeID);

        bool BusinessVolumeActualDataExists(DateTime date, long storeID);
        bool BusinessVolumeActualDataExists(DateTime date, long storeID, long worldID);
        int?[,] EmployeeDayStatePlanningGetHoursSum(DateTime begin, DateTime end, long storeID);
        int?[,] EmployeeDayStateRecordingGetHoursSum(DateTime begin, DateTime end, long storeID);

        Dictionary<long, int?> GetWorkingHoursByWorlds(long storeid, DateTime monday, bool bPlanned);
        int[] GetWorldWorkingHoursForYearAsWeeksSum(long storeworldid, int year, bool bPlanned);
    }
}