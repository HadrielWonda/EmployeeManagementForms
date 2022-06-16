using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IWorldService : IBaseService<World>
    {
        List<World> GetStoreWorlds(long storeID);
        World GetByStoreToWorldID(long storeToWorldID);
        Dictionary<long, World> GetDictionaryByStoreToWorldIDList(IEnumerable<long> idList);
    }
}