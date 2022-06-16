using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IStoreAdditionalHourService : IBaseService<StoreAdditionalHour>
    {
        List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, DateTime Begin, DateTime End);
        List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, int beginYear, byte dayOfWeek);
    }
}