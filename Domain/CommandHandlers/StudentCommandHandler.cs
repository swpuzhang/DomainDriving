using Domain.Commands;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Events;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>
    {
        // 注入仓储接口
        private readonly IStudentRepository _studentRepository;
        

        public StudentCommandHandler(IStudentRepository studentRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      IMemoryCache cache) : base(uow, bus, cache)
        {
            _studentRepository = studentRepository;
           
        }

        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (_studentRepository.GetEmail(request.Email) != null)
            {
                //List<string> errorInfo = new List<string>() { "The customer e-mail has already been taken." };
                //_cache.Set("ErrorData", errorInfo);
                _bus.RaiseEvent<DomainNotification>(new DomainNotification("", "already used"));
                return Task.FromResult(new Unit());
            }
           
            var student = new Student(Guid.NewGuid(), request.Name,
                request.Email, request.Phone, request.BirthDate, 
                new Address(request.Province, request.City, request.County, request.Street));
            _studentRepository.Add(student);
            if (Commit())
            {
                _bus.RaiseEvent<StudentRegisteredEvent>(new StudentRegisteredEvent(
                    student.Id, student.Name, student.Email, student.BirthDate, student.Phone
                    ));
            }
            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
