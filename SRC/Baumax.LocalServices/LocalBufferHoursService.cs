using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalBufferHoursService : LocalBaseCachingService<BufferHours>, IBufferHoursService
    {
        #region IBufferHoursService Members

        public List<BufferHours> GetBufferHoursFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            return RemoteService.GetBufferHoursFiltered(storeID, yearFrom, yearTo);
        }
        public BufferHours GetBufferHours(long storeworldID, short year)
        {
            return RemoteService.GetBufferHours(storeworldID, year);
        }
        public BufferHours ValidateAndUpdate(BufferHours entity)
        {
            return RemoteService.ValidateAndUpdate(entity);
        }
        #endregion

        private IBufferHoursService RemoteService
        {
            get { return (IBufferHoursService)_remoteService; }
        }
    }
}
