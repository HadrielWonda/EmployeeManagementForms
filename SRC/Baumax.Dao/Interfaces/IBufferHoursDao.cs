using System.Collections;
using Baumax.Domain;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IBufferHoursDao : IDao<BufferHours>
    {
        IList GetBufferHoursFiltered(long storeID, short? yearFrom, short? yearTo);
        BufferHours GetBufferHours(long storeworldID, short year);
        List<BufferHours> GetBufferHours(long storeworldID);
    }
}