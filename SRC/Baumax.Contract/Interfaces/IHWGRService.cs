using System;
using System.Collections.Generic;

using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.Interfaces
{
    public interface IHWGRService : IBaseService<HWGR>
    {
        List<HWGR> GetHwgrFiltered(long worldID, DateTime? from, DateTime? to);
		SaveDataResult ImportHWGR(List<ImportHWGRData> list);
    }
}