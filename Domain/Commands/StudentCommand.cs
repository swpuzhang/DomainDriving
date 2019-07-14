using Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public abstract class StudentCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public string Phone { get; protected set; }
    }
}
