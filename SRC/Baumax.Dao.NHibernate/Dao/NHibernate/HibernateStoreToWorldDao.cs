using System;
using System.Text;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Baumax.Contract.QueryResult;
using System.Data.SqlClient;
using NHibernate;
using NHibernate.Type;
using Rsdn.Framework.Data.Mapping;
using Baumax.Contract;
using Baumax.Contract.Estimate;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateStoreToWorldDao : HibernateDao<StoreToWorld>, IStoreToWorldDao
    {
        #region Private Fields

        IHwgrWgrDao _HwgrWgrDao;
        IWorldToHwgrDao _WorldToHwgrDao;

        #endregion

        #region IStoreToWorldDao Members

        public List<StoreWorldDetail> GetStoreWorldDetail(short year, long storeID, long store_worldID)
        {
            List<StoreWorldDetail> storeStructureList = new List<StoreWorldDetail>();
            string query = "exec spStore_WorldDetailGet {0}, {1}, {2}";
            query = string.Format(query, year, storeID, store_worldID);
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        //Store_WorldID, StoreID, BufferHoursValue, BenchmarkValue, 
                        //AvailableWorkTimeHours, BusinessVolumeHours, TargetedBusinessVolume, NetBusinessVolume1, NetBusinessVolume2
                        StoreWorldDetail storeWorldDetail = new StoreWorldDetail();
                        storeWorldDetail.Year = year;
                        storeWorldDetail.StoreWorldId = reader.GetInt64(0);
                        storeWorldDetail.StoreId = reader.GetInt64(1);
                        if (reader.IsDBNull(2))
                            storeWorldDetail.AvailableBufferHours = null;
                        else
                            storeWorldDetail.AvailableBufferHours = reader.GetDouble(2);
                        if (reader.IsDBNull(3))
                            storeWorldDetail.BenchmarkPerfomance = null;
                        else
                            storeWorldDetail.BenchmarkPerfomance = reader.GetDouble(3);
                        if (reader.IsDBNull(4))
                            storeWorldDetail.AvailableWorkTimeHours = null;
                        else
                            storeWorldDetail.AvailableWorkTimeHours = reader.GetDecimal(4);
                        if (reader.IsDBNull(5))
                            storeWorldDetail.BusinessVolumeHours = null;
                        else
                            storeWorldDetail.BusinessVolumeHours = reader.GetDecimal(5);
                        if (reader.IsDBNull(6))
                            storeWorldDetail.TargetedBusinessVolume = null;
                        else
                            storeWorldDetail.TargetedBusinessVolume = reader.GetDecimal(6);
                        if (reader.IsDBNull(7))
                            storeWorldDetail.NetBusinessVolume1 = null;
                        else
                            storeWorldDetail.NetBusinessVolume1 = reader.GetDecimal(7);
                        if (reader.IsDBNull(8))
                            storeWorldDetail.NetBusinessVolume2 = null;
                        else
                            storeWorldDetail.NetBusinessVolume2 = reader.GetDecimal(8);

                        storeStructureList.Add(storeWorldDetail);
                    }
                }
            }
            return storeStructureList;
        }

        public IList FindAllForStore(long storeID)
        {
            IList list = FindByNamedParam(null, "entity.StoreID = :store_id", null, "store_id", storeID);
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        public IList FindAllForRegion(long regionID)
        {
            IList list =
                FindByNamedParam("Store s", "entity.StoreID = s.ID AND s.RegionID = :region_id", null, "region_id",
                                 regionID);
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        public IList FindAllForCountry(long countryID)
        {
            IList list =
                FindByNamedParam("Store s, Region r", "entity.StoreID = s.ID AND s.RegionID = r.ID AND r.CountryID=:country_id", null, "country_id",
                                 countryID);
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }


        public StoreToWorld FindByStoreAndWorld(long storeid, long worldid)
        {
            IList storeWorldList = FindAllForStore(storeid);

            if (storeWorldList != null)
            {
                foreach (StoreToWorld entity in storeWorldList)
                {
                    if (entity.StoreID == storeid && entity.WorldID == worldid)
                    {
                        return entity;
                    }
                }
            }

            return null;
        }

        public AssignResult WGRToHWGRAssign(long storeID, long hwgr_id, long wgr_id, DateTime beginTime,
                                            DateTime endTime)
        {
            AssignResult result = new AssignResult();
            result.Result = AResult.Error;
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = "spWGR_HWGR_Assign";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                p1.Value = storeID;
                command.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@HWGR_ID", SqlDbType.BigInt, 8);
                p2.Value = hwgr_id;
                command.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@WGR_ID", SqlDbType.BigInt, 8);
                p3.Value = wgr_id;
                command.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@BeginTime", SqlDbType.SmallDateTime, 4);
                p4.Value = beginTime;
                command.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@EndTime", SqlDbType.SmallDateTime, 4);
                p5.Value = endTime;
                command.Parameters.Add(p5);
                SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                importResult.Direction = ParameterDirection.Output;
                command.Parameters.Add(importResult);
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    List<HwgrToWgr> list = new List<HwgrToWgr>();
                    while (reader.Read())
                    {
                        HwgrToWgr value = new HwgrToWgr();
                        value.ID = reader.GetInt64(0);
                        value.StoreID = reader.GetInt64(1);
                        value.HWGR_ID = reader.GetInt64(2);
                        value.WGR_ID = reader.GetInt64(3);
                        value.BeginTime = reader.GetDateTime(4);
                        value.EndTime = reader.GetDateTime(5);
                        value.Import = reader.GetBoolean(6);
                        list.Add(value);
                    }
                    reader.NextResult();
                    int res = (int) importResult.Value;
                    if (res < 0)
                    {
                        result.Result = AResult.Error;
                    }
                    result.Data = list;
                }
            }
            _HwgrWgrDao.OnDaoInvalidateWholeCache();
            return result;
        }

        public AssignResult HWGRToWorldAssign(long storeID, long world_id, long hwgr_id, DateTime beginTime,
                                              DateTime endTime)
        {
            AssignResult result = new AssignResult();
            result.Result = AResult.Error;
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = "spHWGR_World_Assign";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                p1.Value = storeID;
                command.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@World_ID", SqlDbType.BigInt, 8);
                p2.Value = world_id;
                command.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@HWGR_ID", SqlDbType.BigInt, 8);
                p3.Value = hwgr_id;
                command.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@BeginTime", SqlDbType.SmallDateTime, 4);
                p4.Value = beginTime;
                command.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@EndTime", SqlDbType.SmallDateTime, 4);
                p5.Value = endTime;
                command.Parameters.Add(p5);
                SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                importResult.Direction = ParameterDirection.Output;
                command.Parameters.Add(importResult);
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    List<WorldToHwgr> list = new List<WorldToHwgr>();
                    while (reader.Read())
                    {
                        WorldToHwgr value = new WorldToHwgr();
                        value.ID = reader.GetInt64(0);
                        value.StoreID = reader.GetInt64(1);
                        value.WorldID = reader.GetInt64(2);
                        value.HWGR_ID = reader.GetInt64(3);
                        value.BeginTime = reader.GetDateTime(4);
                        value.EndTime = reader.GetDateTime(5);
                        value.Import = reader.GetBoolean(6);
                        list.Add(value);
                    }
                    reader.NextResult();
                    int res = (int) importResult.Value;
                    if (res < 0)
                    {
                        result.Result = AResult.Error;
                    }
                    result.Data = list;
                }
            }
            _WorldToHwgrDao.OnDaoInvalidateWholeCache();
            return result;
        }

        public IList GetCashDeskPeopleEstimated(DateTime begin, DateTime end, long storeID)
        {
            List<CashDeskPeoplePerHourEstimateShort> result;
            string query = string.Format("exec spBusinessVolume_EstimatedCashDeskPeopleGet {0}, '{1}', '{2}'", storeID, begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"));
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<CashDeskPeoplePerHourEstimateShort>(reader);
            }
            return result;
        }

        public IList GetEstimatedWorldWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            List<EstimatedWorldWorkingHours> result;
            string query = string.Format("exec spBusinessVolume_EstimatedWorkingHoursGet {0}, {1}, '{2}', '{3}'", storeID, worldID, begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"));
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<EstimatedWorldWorkingHours>(reader);
            }
            return result;
        }

        public decimal GetEstimatedTargetedNetPerformance(short year, long storeID, long worldID)
        {
            string query = string.Format("exec spBusinessVolume_TargetedNetPerformanceGet {0}, {1}, {2}", storeID, worldID, year);
            object result= getDataScalar(query);
            if (result == null)
                result= SharedConsts.NoData;
            return (decimal)result;
        }



        public IList GetEstWorkingHours(DateTime begin, DateTime end, long storeID, long worldID)
        {
            List<EstWorldWorkingHours> result;
            string query = string.Format("SELECT EstWorldWorkingHours.*, WorldName.Name as WorldName FROM EstWorldWorkingHours, WorldName WHERE EstWorldWorkingHours.WorldID=WorldName.WorldID AND StoreID={0} AND DATE >='{1}' AND DATE <= '{2}'", storeID, begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"));
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<EstWorldWorkingHours>(reader);
            }
            return result;
        }

        public IList GetEstWorldDiffData(short year, long storeID, long worldID)
        {
            List<EstWorldDiffData> result;
            string query = string.Format("SELECT EstWorldDifferentData.*,WorldName.Name as WorldName FROM EstWorldDifferentData , WorldName WHERE EstWorldDifferentData.WorldID=WorldName.WorldID AND  Year = {0} AND StoreID={1}", year, storeID);
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<EstWorldDiffData>(reader);
            }
            return result;
        }

        public IList GetEstWorldYearValues(short year, long storeID, long worldID)
        {
            List<EstWorldYearValues> result;
            string query = string.Format("SELECT EstWorldYearValues.* ,WorldName.Name as WorldName FROM EstWorldYearValues,WorldName WHERE EstWorldYearValues.WorldID=WorldName.WorldID AND Year = {0} AND StoreID={1}", year, storeID);
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<EstWorldYearValues>(reader);
            }
            return result;
        }

        public IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID, long worldID)
        {
            return GetBusinessVolumeTargActSum(BVType.Actual, begin, end, storeID, worldID);
        }

        public IList GetBusinessVolumeSumAct(DateTime begin, DateTime end, long storeID)
        {
            return GetBusinessVolumeTargActSum(BVType.Actual, begin, end, storeID);
        }

        public IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID, long worldID)
        {
            return GetBusinessVolumeTargActSum(BVType.Targeted, begin, end, storeID, worldID);
        }
        
        public IList GetBusinessVolumeSumTarg(DateTime begin, DateTime end, long storeID)
        {
            return GetBusinessVolumeTargActSum(BVType.Targeted, begin, end, storeID);
        }

        IList GetBusinessVolumeTargActSum(BVType businessVolumeType, DateTime begin, DateTime end, long storeID)
        {
            return GetBusinessVolumeTargActSum(businessVolumeType,begin,end,storeID,SharedConsts.CalculateAll);
        }

        IList GetBusinessVolumeTargActSum(BVType businessVolumeType, DateTime begin, DateTime end, long storeID, long worldID)
        {
            List<BusinessVolumeTargActSum> result;
            string procName;
            string query;
            switch (businessVolumeType)
            {
                case BVType.Targeted:
                    procName= "spBV_TargetedSumGet";
                    break;
                case BVType.Actual:
                    procName = "spBV_ActualSumGet";
                    break;
                default:
                    goto case BVType.Targeted;
            }
            
            if (worldID < 0)
                query = string.Format("exec {0} '{1}', '{2}', {3}", procName, begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"), storeID);
            else
                query = string.Format("exec {0} '{1}', '{2}', {3}, {4}", procName, begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"), storeID, worldID);
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<BusinessVolumeTargActSum>(reader);
            }
            return result;
        }

        public IList GetBusinessVolumeCRRSum(DateTime begin, DateTime end, long storeID)
        {
            string query = string.Format("exec spBV_CRRSumGet '{0}', '{1}', {2}", begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"), storeID);
            using (IDataReader reader = getDataReader(query))
            {
                return Map.ToList<BusinessVolumeCRRSum>(reader);
            }

        }

        public IList GetBusinessVolumeCRR(DateTime begin, DateTime end, long storeID)
        {
            string query = string.Format("exec spBV_CRRGet '{0}', '{1}', {2}", begin.ToString("yyyMMdd"), end.ToString("yyyMMdd"), storeID);
            using (IDataReader reader = getDataReader(query))
            {
                return Map.ToList<BusinessVolumeCRR>(reader);
            }

        }
        
        public bool BusinessVolumeActualDataExists(DateTime date, long storeID)
        {
            return BusinessVolumeActualDataExists(date, storeID, SharedConsts.CalculateAll);
        }

        public bool BusinessVolumeActualDataExists(DateTime date, long storeID, long worldID)
        {
            string query;

            if (worldID == SharedConsts.CalculateAll)
                query = string.Format("exec spBV_ActualDataExists '{0}', {1}"
                      , DateTimeSql.DateToSqlString(date),
                      storeID);
            else
            query = string.Format("exec spBV_ActualDataExists '{0}', {1}, {2}"
                  , DateTimeSql.DateToSqlString(date),
                  storeID, worldID);

            bool result = (bool)HibernateTemplate.Execute(delegate(ISession session)
                                                           {
                                                               return session.CreateSQLQuery(query)
                                                                   .AddScalar("result", NHibernateUtil.Boolean)
                                                                   .UniqueResult<bool>();
                                                           }
                                     );
            return result;
        }

        struct EmployeeDayStateHoursSum
        {
            public int? AllreadyPlannedHours;
            public int? WorkingHours; 
        }

        enum EmployeeDayStateTableType : byte { EmployeeDayStatePlanning = 0, EmployeeDayStateRecording = 1 }

        

        



        public void ClearEstimation(long storeid, short year)
        {
            using (IDbCommand command = CreateCommand())
            {
                    command.CommandText = "spBusinessVolume_DeleteEstimatedCashDeskPeople";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                    p1.Value = storeid;
                    command.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("@EstimateYear", SqlDbType.SmallInt, 2);
                    p2.Value = year;
                    command.Parameters.Add(p2);

                    command.ExecuteNonQuery();

                    command.CommandText = "spBusinessVolume_DeleteEstimatedWorkingHours";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
            }
        }
        #endregion

        enum BVType { Targeted, Actual };


        public int[] GetWorldWorkingHoursForYearAsWeeksSum(long storeworldid, int year, bool bPlanned)
        {

            DateTime begin = DateTimeHelper.GetBeginYearDate(year);
            DateTime end = DateTimeHelper.GetEndYearDate(year);
            int week_count = DateTimeHelper.GetCountWeekInYear(year);
            string query = @"select entity.Date  ,sum(entity.WorkingHours)
                            from {0} entity 
                            where 
                                entity.StoreWorldId = {1} and
                                entity.Date between '{2}' and '{3}' 
                            group by entity.Date";
            string sql = null;
            if (bPlanned)
            {
                sql = String.Format(query, new object[] { "EmployeeDayStatePlanning", storeworldid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end) });
            }
            else
            {
                sql = String.Format(query, new object[] { "EmployeeDayStateRecording", storeworldid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end) });
            }
            Dictionary<DateTime, int> resultDiction = new Dictionary<DateTime, int>(400);

            IList list = HibernateTemplate.FindByNamedParam(sql, new string[] { }, new object[] { });
            if (list != null)
            {
                DateTime date;
                int minutes;
                foreach (object[] objs in list)
                {
                    date = Convert.ToDateTime(objs[0]);
                    minutes = Convert.ToInt32(objs[1]);
                    resultDiction[date] = minutes;
                }
            }

            int[] sums = new int[week_count];
            for (int i = 0; i < week_count; i++)
            {
                sums[i] = 0;
            }

            int weeknumber = 0;
            foreach (KeyValuePair<DateTime, int> keypair in resultDiction)
            {
                weeknumber = DateTimeHelper.GetWeekNumber(keypair.Key);

                if (weeknumber > 0 && weeknumber <= week_count)
                    sums[weeknumber-1] += keypair.Value;
            }

            return sums;
        }

        public Dictionary<long, int?> GetWorkingHoursByWorlds(long storeid, DateTime monday, bool bPlanned)
        {
            Debug.Assert(monday.DayOfWeek == DayOfWeek.Monday);

            string query = @"select entity.StoreWorldId  ,sum(entity.WorkingHours)
                            from {0} entity, StoreToWorld sw
                            where 
                                entity.StoreWorldId = sw.id and
                                sw.StoreID = {1} and
                                entity.Date between '{2}' and '{3}' 
                            group by entity.StoreWorldId";



            string sql = null;
            DateTime sunday = DateTimeHelper.GetSunday(monday);
            if (bPlanned)
            {
                sql = String.Format(query, new object[] { "EmployeeDayStatePlanning", storeid, DateTimeSql.DateToSqlString(monday), DateTimeSql.DateToSqlString(sunday) });
            }
            else
            {
                sql = String.Format(query, new object[] { "EmployeeDayStateRecording", storeid, DateTimeSql.DateToSqlString(monday), DateTimeSql.DateToSqlString(sunday) });
            }
            Dictionary<long, int?> resultDiction = new Dictionary<long, int?>();

            
            HibernateTemplate.Execute(delegate(ISession session)
                {
                    IList list = session.CreateQuery(sql).List();

                    if (list != null)
                    {
                        foreach (object[] objs in list)
                        {
                            long id = Convert.ToInt64(objs[0]);
                            resultDiction[id] = null;
                            if (objs[1] != null)
                                resultDiction[id] = Convert.ToInt32(objs[1]);

                            //(reader.IsDBNull(1)) ? null : (int?)reader.GetInt32(1);
                        }
                    }
                    return null;
                }
            );
            return resultDiction;
        }
        // like GetWorkingHoursByWorlds but throuh store procedure 
        private int?[,] EmployeeDayStateGetHoursSum(DateTime begin, DateTime end, long storeID, EmployeeDayStateTableType employeeDayStateTableType)
        {
            string query = string.Format("exec spEmployeeDayStateGetHoursSum '{0}', '{1}', {2}, {3}"
                , DateTimeSql.DateToSqlString(begin)
                , DateTimeSql.DateToSqlString(end)
                , storeID
                , (byte)employeeDayStateTableType);
            using (IDataReader reader = GetDataReader(query))
            {
                const int valuesCount = 2;
                int?[,] result = new int?[1, valuesCount];
                if (reader.Read())
                {
                    for (int i = 0; i < valuesCount; i++)
                        if (reader.IsDBNull(i))
                            result[0, i] = null;
                        else
                            result[0, i] = reader.GetInt32(i);
                }
                return result;
            }
        }
        public int?[,] EmployeeDayStatePlanningGetHoursSum(DateTime begin, DateTime end, long storeID)
        {
            return EmployeeDayStateGetHoursSum(begin, end, storeID, EmployeeDayStateTableType.EmployeeDayStatePlanning);
        }
        public int?[,] EmployeeDayStateRecordingGetHoursSum(DateTime begin, DateTime end, long storeID)
        {
            return EmployeeDayStateGetHoursSum(begin, end, storeID, EmployeeDayStateTableType.EmployeeDayStateRecording);
        }

    }
}