using System;
using Baumax.Domain;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.Interfaces
{
    public interface IHwgrToWgrService : IBaseService<HwgrToWgr>
    {
        List<HwgrToWgr> GetHwgrToWgrFiltered(DateTime dateon);
        List<HwgrToWgr> GetHwgrToWgrFiltered(long storeID);
        List<HWGR_WGR_SysValues> Get_HWGR_WGR_SysValues();
		SaveDataResult Save_HWGR_WGR_Values(List<HWGR_WGR_SysValuesShort> list);
        List<HwgrToWgr> InsertRelation(HwgrToWgr entity);
    }
}