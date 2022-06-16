using System;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IWorldToHwgrDao : IDao<WorldToHwgr>
    {
        IList GetWorldToHwgrFiltered(DateTime dateon);
        IList GetWorldToHwgrFiltered(long storeID);
        IList GetWorldToHwgrFiltered(long storeID, long worldID, long hwgrID);
        List<World_HWGR_SysValues> Get_World_HWGR_SysValues();
    }
}