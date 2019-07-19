using Domain.Core.Bus;
using Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR.Internal;
using Domain.Core.Events;
using Domain.Events;

namespace Infrastruct.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStoreService _eventStore;
        public InMemoryBus(IMediator mediator, IEventStoreService eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
