using System;
using System.Collections;
using System.Collections.Generic;

using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IHWGRDao : IDao<HWGR>
    {
        IList GetHwgrFiltered(long worldID, DateTime? from, DateTime? to);
		SaveDataResult ImportHWGR(List<ImportHWGRData> list);
    }
}