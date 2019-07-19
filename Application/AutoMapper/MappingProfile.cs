using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Models;
using Application.ViewModels;
using Domain.Commands;

namespace Application.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<StudentViewModel, RegisterStudentCommand>()
                .IncludeMembers(c => c.Address)
                .ReverseMap();
        
        }
    }
}
