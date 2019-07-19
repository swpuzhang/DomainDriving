using Domain.Core.Events;
using Domain.Events;
using Infrastruct.Data.Repository.EventSourcing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Data.EventSourcing
{
    public class SqlEventStoreService : IEventStoreService
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStoreService(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);
            var storedEvent = new StoreEvent(
                theEvent,
                serializedData,
                "zhangyang");
            _eventStoreRepository.Store(storedEvent);

        }
    }
}
