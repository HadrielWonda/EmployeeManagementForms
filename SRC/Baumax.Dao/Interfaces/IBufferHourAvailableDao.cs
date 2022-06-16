using Baumax.Domain;
using System.Collections.Generic;
using System;

namespace Baumax.Dao
{
    public interface IBufferHourAvailableDao : IDao<BufferHourAvailable>
    {
        List<BufferHourAvailable> GetAvailableBufferHoursForYear(long storeworldid, int year);
        List<BufferHourAvailable> GetAvailableBufferHours(long storeworldid, DateTime aBegin, DateTime aEnd);
        List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, DateTime aBegin, DateTime aEnd);
        List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, int year);
        BufferHourAvailable GetBufferHoursAvailable(long storeworldid, DateTime date);
        // return from date to 2079
        List<BufferHourAvailable> GetBufferHoursAvailableFrom(long storeworldid, DateTime date);
        void SaveOrUpdate2(BufferHourAvailable entity);
    }
}