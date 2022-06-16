using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalBufferHourAvailableService : LocalBaseCachingService<BufferHourAvailable>,
                                                   IBufferHourAvailableService
    {
        private IBufferHourAvailableService RemoteService
        {
            get { return (IBufferHourAvailableService) _remoteService; }
        }

        #region IBufferHourAvailableService Members
        #endregion
    }
}