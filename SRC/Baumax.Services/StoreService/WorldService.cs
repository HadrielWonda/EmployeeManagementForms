using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Contract.QueryResult;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("DBC4BD8F-036E-408f-91B2-83B8FD3E29BC")]
    public class WorldService : BaseService<World>, IWorldService
    {
        #region IWorldService Members

        [AccessType(AccessType.Read)]
        public List<World> GetStoreWorlds(long storeID)
        {
            try
            {
                return GetTypedListFromIList(((IWorldDao) Dao).GetStoreWorlds(storeID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public World GetByStoreToWorldID(long storeToWorldID)
        {
            try
            {
                return ((IWorldDao) Dao).GetByStoreToWorldID(storeToWorldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public Dictionary<long, World> GetDictionaryByStoreToWorldIDList(IEnumerable<long> idList)
        {
            try
            {
                return ((IWorldDao)Dao).GetDictionaryByStoreToWorldIDList(idList);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}