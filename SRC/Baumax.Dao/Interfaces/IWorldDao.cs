using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IWorldDao : IDao<World>
    {
        IList GetStoreWorlds(long storeID);
        World GetByStoreToWorldID(long storeToWorldID);
        Dictionary<long, World> GetDictionaryByStoreToWorldIDList(IEnumerable<long> idList);
    }
}