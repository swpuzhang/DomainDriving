using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Events;
using FluentValidation.Results;

namespace Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get;set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
        public abstract bool IsValid();
    }
}
