using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Commands;
using Domain.Core.Bus;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        public StudentAppService(IStudentRepository studentRepository, IMapper mapper, IMediatorHandler bus)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.GetAll().Select(_mapper.Map<StudentViewModel>).ToList();
            
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            //_studentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanges();
            var RegisterCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            _bus.SendCommand(RegisterCommand);
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
            _studentRepository.SaveChanges();
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
            _studentRepository.SaveChanges();
        }
    }
}
