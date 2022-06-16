using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IStoreWorkingTimeService : IBaseService<StoreWorkingTime>
    {
        List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime? dateOn);
        List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime aBegin, DateTime aEnd);
    }
}