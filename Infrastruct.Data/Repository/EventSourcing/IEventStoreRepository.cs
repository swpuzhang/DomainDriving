using Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoreEvent theEvent);
        IList<StoreEvent> All(Guid aggregateId);
    }


}
