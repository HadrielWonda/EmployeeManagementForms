using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("0A3593D6-8618-45ad-9574-36FD8EA2F54A")]
    public class StoreWorkingTimeService : BaseService<StoreWorkingTime>, IStoreWorkingTimeService
    {
        #region IStoreWorkingTimeService Members

        [AccessType(AccessType.Read)]
        public List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime? dateOn)
        {
            try
            {
                return
                    GetTypedListFromIList(((IStoreWorkingTimeDao) Dao).GetWorkingTimeFiltered(storeID, dateOn));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<StoreWorkingTime> GetWorkingTimeFiltered(long storeID, DateTime aBegin, DateTime aEnd)
        {
            try
            {
                return
                    GetTypedListFromIList(((IStoreWorkingTimeDao)Dao).GetWorkingTimeFiltered(storeID, aBegin, aEnd ));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        public List<StoreWorkingTime> GetWorkingTimeFiltered_Srv(long storeID, DateTime aBegin, DateTime aEnd)
        {
            try
            {
                return ((IStoreWorkingTimeDao)Dao).GetWorkingTimeFiltered_Srv(storeID, aBegin, aEnd);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        public override StoreWorkingTime CreateEntity()
        {
            StoreWorkingTime result = base.CreateEntity();
            Array list = Enum.GetValues(typeof(DayOfWeek));
            result.StoreWTWeekdays.Clear();
            for (byte i = 0; i < list.Length; i++)
            {
                result.StoreWTWeekdays.Add(new StoreWTWeekday(Convert.ToByte((int)list.GetValue(i)), 0, 0, result));
            }
            return result;
        }

        protected override bool Validate(StoreWorkingTime entity)
        {
            if (entity.StoreWTWeekdays.Count != 7)
            {
                return false;
            }
            string s = @"entity.StoreID = :storeid and entity.ID<>:entityid and 
                        ( (:from_date BETWEEN entity.BeginTime AND entity.EndTime) OR
                        (:to_date BETWEEN entity.BeginTime AND entity.EndTime) OR 
                        (entity.BeginTime BETWEEN :from_date AND :to_date) OR
                        (entity.EndTime BETWEEN :from_date AND :to_date))";

            IList lst = FindByNamedParam(s,
                new string[] { "storeid", "entityid","from_date", "to_date" },
                new object[] { entity.StoreID, entity.ID, entity.BeginTime, entity.EndTime});

            if (lst != null && lst.Count > 0)
            {
                return false;
            }
            return base.Validate(entity);
        }


    }
}