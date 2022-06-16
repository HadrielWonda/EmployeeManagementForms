using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("1A4FEB0E-231D-4106-9AEB-E24C7ED4BE04")]
    public class StoreAdditionalHourService : BaseService<StoreAdditionalHour>, IStoreAdditionalHourService
    {
        private IStoreAdditionalHourDao StoreAdditionalHourDao
        {
            get { return (IStoreAdditionalHourDao) Dao; }
        }

        #region IStoreAdditionalHourService Members

        [AccessType(AccessType.Read)]
        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, DateTime Begin, DateTime End)
        {
            return StoreAdditionalHourDao.GetStoreAdditionalHourFiltered(storeID, Begin, End);
        }

        [AccessType(AccessType.Read)]
        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, int beginYear, byte dayOfWeek)
        {
            return StoreAdditionalHourDao.GetStoreAdditionalHourFiltered(storeID, beginYear, dayOfWeek);
        }

        #endregion
    }
}