using System;
using Baumax.Domain;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using System.Collections;
namespace Baumax.Contract.Interfaces
{
    public interface IWorldToHwgrService : IBaseService<WorldToHwgr>
    {
        List<WorldToHwgr> GetWorldToHwgrFiltered(DateTime dateon);
        List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID);
        List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID, long worldID, long hwgrID);
        List<World_HWGR_SysValues> Get_World_HWGR_SysValues();
        List<WorldToHwgr> InsertRelation(WorldToHwgr entity);
    }
}