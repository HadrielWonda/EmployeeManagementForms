using System;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using System.Data;

namespace Baumax.Dao.NHibernate
{
    public class HibernateWorldToHwgrDao : HibernateDao<WorldToHwgr>, IWorldToHwgrDao
    {
        public IList GetWorldToHwgrFiltered(DateTime dateon)
        {
            return
                FindByNamedParam(null,
                                 "( (entity.BeginTime IS NULL) OR (entity.BeginTime <= :dateon) ) AND ( (entity.EndTime IS NULL) OR (entity.EndTime >= :dateon) )",
                                 null, "dateon", dateon);
        }

        public IList GetWorldToHwgrFiltered(long storeID)
        {
            return
                FindByNamedParam(null, "entity.StoreID = :store_id", "ORDER BY entity.BeginTime DESC", "store_id",
                                 storeID);
        }

        public IList GetWorldToHwgrFiltered(long storeID, long worldID, long hwgrID)
        {
            return
                FindByNamedParam(null,
                                 @"entity.StoreID = :store_id
                                   AND entity.WorldID = :world_id
                                   AND entity.HWGR_ID = :hwgr_id",
                                 "ORDER BY entity.BeginTime DESC",
                                 new string[] {"store_id", "world_id", "hwgr_id"},
                                 new object[] {storeID, worldID, hwgrID});
        }

        public List<World_HWGR_SysValues> Get_World_HWGR_SysValues()
        {
            List<World_HWGR_SysValues> hwgr_wgr_SysValuesList = new List<World_HWGR_SysValues>();
            string query = "select * from vwWorld_HWGR";
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        World_HWGR_SysValues hwgr_wgr_SysValues = new World_HWGR_SysValues();
                        hwgr_wgr_SysValues.World_HWGR_ID = reader.GetInt64(0);
                        hwgr_wgr_SysValues.Store_WorldID = reader.GetInt64(1);
                        hwgr_wgr_SysValues.HWGR_ID = reader.GetInt64(2);
                        hwgr_wgr_SysValues.HWGR_SystemID = reader.GetInt64(3);
                        hwgr_wgr_SysValues.World_SystemID = reader.GetInt32(4);
                        hwgr_wgr_SysValuesList.Add(hwgr_wgr_SysValues);
                    }
                }
            }
            return hwgr_wgr_SysValuesList;
        }
    }
}