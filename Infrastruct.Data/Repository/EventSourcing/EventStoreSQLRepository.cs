using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Events;
using Infrastruct.Data.Context;
using System.Linq;

namespace Infrastruct.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        public EventStoreSQLRepository(EventStoreSqlContext context)
        {
            _context = context;
        }
        private readonly EventStoreSqlContext _context;
        public IList<StoreEvent> All(Guid aggregateId)
        {
            return _context.StoredEvent.Where(c => c.AggregateId == aggregateId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Store(StoreEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }
    }
}
