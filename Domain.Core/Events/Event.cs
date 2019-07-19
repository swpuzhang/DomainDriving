using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        // 每一个事件都是有状态的
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
