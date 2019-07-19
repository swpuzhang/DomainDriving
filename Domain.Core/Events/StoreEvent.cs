using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Events
{
    public class StoreEvent : Event
    {
        public Guid Id { get; private set; }
        public string Data { get; private set; }
        public string User { get; private set; }
        public StoreEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            
            this.AggregateId = theEvent.AggregateId;
            this.MessageType = theEvent.MessageType;
            Data = data;
            User = user;

        }
        protected StoreEvent() { }
    }
}
