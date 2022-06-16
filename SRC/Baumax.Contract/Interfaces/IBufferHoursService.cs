using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IBufferHoursService : IBaseService<BufferHours>
    {
        List<BufferHours> GetBufferHoursFiltered(long storeID, short? yearFrom, short? yearTo);
        BufferHours GetBufferHours(long storeworldID, short year);
        BufferHours ValidateAndUpdate(BufferHours entity);
    }
}