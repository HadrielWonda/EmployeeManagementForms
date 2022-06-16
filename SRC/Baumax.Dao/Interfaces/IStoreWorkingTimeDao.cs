using System;
using System.Collections;
using Baumax.Domain;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IStoreWorkingTimeDao : IDao<StoreWorkingTime>
    {
        IList GetWorkingTimeFiltered(long storeID, DateTime? dateOn);
        IList GetWorkingTimeFiltered(long storeID, DateTime aBegin, DateTime aEnd);
        List<StoreWorkingTime> GetWorkingTimeFiltered_Srv(long storeID, DateTime aBegin, DateTime aEnd);
    }
}