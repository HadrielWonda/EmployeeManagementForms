using System.Collections.Generic;

namespace Baumax.Contract.Interfaces
{
    public delegate void InvalidateWholeCacheDelegate();

    public interface IInvalidateWholeCacheReceiver
    {
        void ReceiveInvalidateWholeCache();

        // for client-side use
        event InvalidateWholeCacheDelegate InvalidateWholeCache;
        bool IsInvalid { get; }
        void Reset();
    }
}