using System;
using System.Collections.Generic;
using uangsaku.Domain.Core.Events;

namespace uangsaku.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}