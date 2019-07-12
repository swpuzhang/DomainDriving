using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentAppService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return (_studentRepository.GetAll()).ProjectTo<StudentViewModel>();
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map< StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            _studentRepository.Add(_mapper.Map<Student>(StudentViewModel));
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
        }
    }
}
