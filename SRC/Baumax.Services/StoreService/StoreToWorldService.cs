using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using Baumax.Services._HelperObjects;
using Spring.Transaction.Interceptor;
using Baumax.Services._HelperObjects.ExEntity;

namespace Baumax.Services
{
    [ServiceID("6A0AD725-9A41-4ff4-9C6F-AA233531EFCD")]
    public class StoreToWorldService : BaseService<StoreToWorld>, IStoreToWorldService
    {
        IWorldService _worldService = null;
        IPersonMinMaxService _minmaxService = null;
        IBufferHoursService _bufferHoursService = null;
        IAvgAmountService _avgAmountService = null;
        IStoreService _storeService = null;
        IBenchmarkService _benchmarkService = null;

        public IWorldService WorldService
        {
            get { return _worldService; }
        }
        public IPersonMinMaxService PersonMinMaxService
        {
            get { return _minmaxService; }
        }
        public IBufferHoursService BufferHoursService
        {
            get { return _bufferHoursService; }
        }

        public IAvgAmountService AvgAmountService
        {
            get { return _avgAmountService; }
        }

        public IStoreService StoreService
        {
            get { return _storeService; }
        }
        public IBenchmarkService BenchmarkService
        {
            get { return _benchmarkService; }
        }
        #region IStoreToWorldService Members



        [AccessType(AccessType.Read)]
        public List<StoreWorldDetail> GetStoreWorldDetail(short year)
        {
            return GetStoreWorldDetail(year, -1, -1);
        }

        [AccessType(AccessType.Read)]
        public List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID)
        {
            return GetStoreWorldDetail(year, storeID, -1);
        }

        [AccessType(AccessType.Read)]
        public List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID, long store_worldID)
        {
            try
            {
				return ((IStoreToWorldDao)Dao).GetStoreWorldDetail(year, storeID, store_worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<StoreToWorld> FindAllForStore(long storeID)
        {
            try
            {
                return FillStoreToWorld(
                    GetTypedListFromIList(((IStoreToWorldDao) Dao).FindAllForStore(storeID)));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<StoreToWorld> FindAllForRegion(long regionID)
        {
            try
            {
                return
                    GetTypedListFromIList(((IStoreToWorldDao) Dao).FindAllForRegion(regionID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public List<StoreToWorld> FindAllForCountry(long countryID)
        {
            try
            {
                return
                    GetTypedListFromIList(((IStoreToWorldDao)Dao).FindAllForCountry(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Write)]
        public AssignResult WGRToHWGRAssign(long storeID, long hwgr_id, long wgr_id, DateTime beginTime, DateTime endTime)
        {
            try
            {
                return (((IStoreToWorldDao)Dao).WGRToHWGRAssign(storeID,hwgr_id,wgr_id,beginTime,endTime));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
     
        }

        [AccessType(AccessType.Write)]
        public AssignResult HWGRToWorldAssign(long storeID, long world_id, long hwgr_id, DateTime beginTime, DateTime endTime)
        {
            try
            {
                return (((IStoreToWorldDao)Dao).HWGRToWorldAssign(storeID,world_id,hwgr_id,beginTime,endTime));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        private List<StoreToWorld> FillStoreToWorld(List<StoreToWorld> lst)
        {
            try
            {
                if (lst != null)
                {
                    List<World> lstWorld = WorldService.FindAll();
                    if (lstWorld != null)
                    {
                        foreach (StoreToWorld stw in lst)
                        {
                            foreach (World w in lstWorld)
                            {
                                if (w.ID == stw.WorldID)
                                {
                                    stw.WorldName = w.Name;
                                    stw.WorldTypeID = w.WorldTypeID;
                                }
                            }
                        }
                    }
                }
                return lst;
                    
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList GetCashDeskPeopleEstimated(DateTime begin, DateTime end, long storeID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetCashDeskPeopleEstimated(begin, end, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }



       
        [AccessType(AccessType.Read)]
        public IList GetEstimatedWorldWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetEstimatedWorldWorkingHours(begin, end, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public decimal GetEstimatedTargetedNetPerformance(short year, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetEstimatedTargetedNetPerformance(year,storeID,worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }


        [AccessType(AccessType.Read)]
        public List<WorldPlanningInfo> GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, DateTime beginWeekDate)
        {
            StoreWorldEstimateInfoBuilder builderWorldInfo = new StoreWorldEstimateInfoBuilder(StoreService, this);
            builderWorldInfo.IsPlanning = IsPlanning;

            return builderWorldInfo.GetAllWorldInfo(storeid, beginWeekDate);
            
        }



        [AccessType(AccessType.Read)]
        public WorldPlanningInfo GetStoreWorldPlanningInfo(bool IsPlanning, long storeid, long worldid, DateTime beginWeekDate)
        {

            StoreWorldEstimateInfoBuilder builderWorldInfo = new StoreWorldEstimateInfoBuilder(StoreService, this);
            builderWorldInfo.IsPlanning = IsPlanning;
            return builderWorldInfo.GetWorldInfo(ExStoreToWorld.Get(storeid, worldid), beginWeekDate);

            
        }
        [AccessType(AccessType.Read)]
        public IList GetEstWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetEstWorkingHours(begin, end, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public IList GetEstWorldDiffData(short year, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetEstWorldDiffData(year, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public IList GetEstWorldYearValues(short year, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetEstWorldYearValues(year, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public void ClearEstimation(long storeid, short year)
        {
            try
            {
                ((IStoreToWorldDao)Dao).ClearEstimation(storeid, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }


        public IList GetBusinessVolumes(bool bTargeted, DateTime begin, DateTime end, long storeID, long worldID)
        {
            IList resultList = null;
            if (bTargeted)
            {
                if (worldID <= 0)
                    resultList = GetBusinessVolumeSumTarg(begin, end, storeID);
                else
                    resultList = GetBusinessVolumeSumTarg(begin, end, storeID, worldID);
            }
            else
            {
                if (worldID <= 0)
                    resultList = GetBusinessVolumeSumAct(begin, end, storeID);
                else
                    resultList = GetBusinessVolumeSumAct(begin, end, storeID, worldID);

            }
            return resultList;
        }

        public IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeSumAct(begin, end, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        public IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeSumAct(begin, end, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        
        }
        /*
        * Return Targeted net-performance per hour: Sum of targeted business volume of all 
        * ware-groupss wothin this world this week
        */
        public IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID, long worldID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeSumTarg(begin, end, storeID, worldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        /*
        * Return Targeted net-performance per hour: Sum of targeted business volume of all 
        * ware-groupss wothin this world this week
         * Return for all world of store
        */
        public IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeSumTarg(begin, end, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }

        }

        public IList GetBusinessVolumeCRRSum(DateTime begin, DateTime end, long storeID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeCRRSum(begin, end, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        private IList GetBusinessVolumeCRR(DateTime begin, DateTime end, long storeID)
        {
            try
            {
                return ((IStoreToWorldDao)Dao).GetBusinessVolumeCRR(begin, end, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        public Dictionary<long, int?> GetWorkingHoursByWorlds(long storeid, DateTime monday, bool planned)
        {
            return ((IStoreToWorldDao)Dao).GetWorkingHoursByWorlds(storeid, monday, planned);
        }
        public int[] GetWorldWorkingHoursForYearAsWeeksSum(long storeworldid, int year, bool planned)
        {
            return ((IStoreToWorldDao)Dao).GetWorldWorkingHoursForYearAsWeeksSum(storeworldid, year, planned);
        }
        //[AccessType(AccessType.FreeAccess)]
        //public void Test()
        //{
        //    //bool result = ((IStoreToWorldDao)Dao).BusinessVolumeActualDataExists(new DateTime(2007,1,1),1173);
        //    //result = ((IStoreToWorldDao)Dao).BusinessVolumeActualDataExists(new DateTime(2007, 1, 1), 1173, 3139);
        //    //result = ((IStoreToWorldDao)Dao).BusinessVolumeActualDataExists(new DateTime(2007, 1, 1), 1173, 0);
        //    //result = ((IStoreToWorldDao)Dao).BusinessVolumeActualDataExists(new DateTime(2007, 1, 1),0);
        //    int?[,] result = ((IStoreToWorldDao)Dao).EmployeeDayStatePlanningGetHoursSum(new DateTime(2004, 1, 1), new DateTime(2008, 1, 1), 1173);
        //    result = ((IStoreToWorldDao)Dao).EmployeeDayStateRecordingGetHoursSum(new DateTime(2004, 1, 1), new DateTime(2008, 1, 1), 1173);
        //    result = ((IStoreToWorldDao)Dao).EmployeeDayStateRecordingGetHoursSum(new DateTime(2008, 1, 1), new DateTime(2008, 1, 1), 1173);
        //}

        #endregion
    }
}
