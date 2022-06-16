using System;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IHwgrWgrDao : IDao<HwgrToWgr>
    {
        IList GetHwgrToWgrFiltered(DateTime dateon);
        IList GetHwgrToWgrFiltered(long storeID);
        List<HWGR_WGR_SysValues> Get_HWGR_WGR_SysValues();
		SaveDataResult Save_HWGR_WGR_Values(List<HWGR_WGR_SysValuesShort> list);
    }
}