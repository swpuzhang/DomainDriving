using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Events;
using MediatR;

namespace Domain.EventHandlers
{
    public class StudentEventHandler : INotificationHandler<StudentRegisteredEvent>
    {
        
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
