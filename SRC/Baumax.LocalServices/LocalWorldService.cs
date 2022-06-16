using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.LocalServices
{
    public class LocalWorldService : LocalBaseCachingService<World>, IWorldService
    {
        private IWorldService RemoteService
        {
            get { return (IWorldService)_remoteService; }
        }
        
        #region IWorldService Members

        public List<World> GetStoreWorlds(long storeID)
        {
            return RemoteService.GetStoreWorlds(storeID);
        }

        public World GetByStoreToWorldID(long storeToWorldID)
        {
            //return RemoteService.GetByStoreToWorldID(storeToWorldID);
            StoreToWorld sw = ClientEnvironment.StoreToWorldService.FindById(storeToWorldID);
            if(sw == null)
            {
                return null;
            }
            return FindById(sw.WorldID);
        }

        public Dictionary<long, World> GetDictionaryByStoreToWorldIDList(IEnumerable<long> idList)
        {
            return RemoteService.GetDictionaryByStoreToWorldIDList(idList);
        }

        #endregion
    }
}
