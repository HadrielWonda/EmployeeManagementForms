using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Services._HelperObjects.ExEntity;
using Baumax.Services._HelperObjects;
using Spring.Transaction.Interceptor;

namespace Baumax.Services
{
    [ServiceID("F97F427C-0355-43ca-AD07-911F516217A3")]
    public class BufferHoursService : BaseService<BufferHours>, IBufferHoursService
    {

        public IBufferHoursDao ServiceDao { get { return (IBufferHoursDao)Dao;} }
        #region IBufferHoursService Members

        [AccessType(AccessType.Read)]
        public List<BufferHours> GetBufferHoursFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            try
            {
                return
                    GetTypedListFromIList(ServiceDao.GetBufferHoursFiltered(storeID, yearFrom, yearTo));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public BufferHours GetBufferHours(long storeworldID, short year)
        {
            try
            {
                return ServiceDao.GetBufferHours(storeworldID, year);
                    
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        #endregion


        [AccessType(AccessType.Read)]
        public List<BufferHours> GetBufferHours(long storeworldID)
        {
            try
            {
                return ServiceDao.GetBufferHours(storeworldID);

            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public BufferHours ValidateAndUpdate(BufferHours entity)
        {

            ExStoreToWorld ex = new ExStoreToWorld(entity.StoreWorldID);
            if (ex.Entity != null)
            {
                bool bModified = false;
                BufferHours buffer = ex.BufferHours(entity.Year);

                if (buffer == null)
                {
                    entity.ID = 0;
                    entity.ValueWeek = BufferHours.GetWeekStepValue(entity);
                        //Math.Round(entity.Value*60 / DateTimeHelper.GetCountWeekInYear(entity.Year));
                    bModified = true;
                }
                else
                {
                    if (buffer.Value != entity.Value)
                    {
                        buffer.Value = entity.Value;
                        buffer.ValueWeek = BufferHours.GetWeekStepValue(buffer);
                            //Math.Round(buffer.Value * 60 / DateTimeHelper.GetCountWeekInYear(buffer.Year));
                        entity = buffer;
                        bModified = true;
                    }
                }

                //if (entity.IsNew)
                //{
                //    if (buffer == null)
                //    {
                //        bModified = true;
                //    }
                //    else
                //    {
                //        if (buffer.Value != entity.Value)
                //        {
                //            buffer.Value = entity.Value;
                //            buffer.ValueWeek = Math.Round(buffer.ValueWeek / DateTimeHelper.GetCountWeekInYear(buffer.Year));
                //            entity = buffer;
                //            bModified = true;
                //        }
                //    }
                //}
                //else
                //{
                //    if (buffer == null)
                //    {
                //        bModified = true;
                //    }
                //    else
                //    {
                //        if (buffer.Value != entity.Value)
                //        {
                //            buffer.Value = entity.Value;
                //            buffer.ValueWeek = Math.Round(buffer.ValueWeek / DateTimeHelper.GetCountWeekInYear(buffer.Year));
                //            entity = buffer;
                //            bModified = true;
                //        }
                //    }
                //}
                if (bModified)
                {
                    SaveOrUpdate(entity);
                    WorldAvailableBufferHoursManager world_availble_buffer_manager = new WorldAvailableBufferHoursManager(ex.Entity, entity.Year);
                    world_availble_buffer_manager.Load();
                    world_availble_buffer_manager.CheckAndBuildAllYearEntity();
                    world_availble_buffer_manager.RecalculateAfterChangedBufferValue();
                }

                return entity;
            }
            return null;

        }
    }
}