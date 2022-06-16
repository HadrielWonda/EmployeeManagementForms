using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Interfaces
{
    public delegate void EntitiesChangedDelegate(IEnumerable<long> ids);

    public interface IChangeReceiver
    {
        void ReceiveEntitiesChanged(IEnumerable<long> ids);

        // for client-side use
        event EntitiesChangedDelegate EntitiesChanged;
        List<long> GetIds();
        bool HasChanges { get; }
        bool IsInList(long id);
        bool RemoveFromList(long id);
        void RemoveFromList(IEnumerable<long> idList);
    }
}