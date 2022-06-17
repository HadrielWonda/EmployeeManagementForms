using System;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using NHibernate;
using System.Data;
using System.Data.SqlClient;

namespace Baumax.Dao.NHibernate
{
    public class HibernateHwgrToWgrDao : HibernateDao<HwgrToWgr>, IHwgrWgrDao
    {
        public IList GetHwgrToWgrFiltered(DateTime dateon)
        {
            return
                FindByNamedParam(null,
                                 "( (entity.BeginTime IS NULL) OR (entity.BeginTime <= :dateon) ) AND ( (entity.EndTime IS NULL) OR (entity.EndTime >= :dateon) )",
                                 null, "dateon", dateon);
        }

        public IList GetHwgrToWgrFiltered(long storeID)
        {
            return
                FindByNamedParam(null, "entity.StoreID = :store_id", "ORDER BY entity.BeginTime DESC", "store_id",
                                 storeID);
        }

        public List<HWGR_WGR_SysValues> Get_HWGR_WGR_SysValues()
        {
            List<HWGR_WGR_SysValues> hwgr_wgr_SysValuesList = new List<HWGR_WGR_SysValues>();
            string query = "select * from vwHWGR_WGR";
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        HWGR_WGR_SysValues hwgr_wgr_SysValues = new HWGR_WGR_SysValues();
                        hwgr_wgr_SysValues.World_HWGR_ID = reader.GetInt64(0);
                        hwgr_wgr_SysValues.WGR_ID = reader.GetInt64(1);
                        hwgr_wgr_SysValues.HWGR_SystemID = reader.GetInt32(2);
                        hwgr_wgr_SysValues.World_SystemID = reader.GetInt32(3);
                        hwgr_wgr_SysValues.WGR_SystemID = reader.GetInt32(4);
                        hwgr_wgr_SysValuesList.Add(hwgr_wgr_SysValues);
                    }
                }
            }
            return hwgr_wgr_SysValuesList;
        }

        public SaveDataResult Save_HWGR_WGR_Values(List<HWGR_WGR_SysValuesShort> list)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" create table #wgr4insert
(
	HWGR_SystemID int,
	World_SystemID int,
	WGR_SystemID int
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 60*3;
                    command.ExecuteNonQuery();
                    foreach (HWGR_WGR_SysValuesShort value in list)
                    {
                        query =
                            "insert into #wgr4insert (HWGR_SystemID, World_SystemID, WGR_SystemID) values({0},{1},{2})";
                        command.CommandText =
                            string.Format(query, value.HWGR_SystemID, value.World_SystemID, value.WGR_SystemID);
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spHWGR_WGR_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        list.Clear();
                        while (reader.Read())
                        {
                            HWGR_WGR_SysValuesShort value = new HWGR_WGR_SysValuesShort();
                            value.HWGR_SystemID = reader.GetInt32(0);
                            value.World_SystemID = reader.GetInt32(1);
                            value.WGR_SystemID = reader.GetInt32(2);
                            list.Add(value);
                        }
                        reader.NextResult();
                        result.Success = ((int) importResult.Value > 0);
                    }
                    result.Data = list;
                }
            }
            OnDaoInvalidateWholeCache();
            return result;
        }
    }
}