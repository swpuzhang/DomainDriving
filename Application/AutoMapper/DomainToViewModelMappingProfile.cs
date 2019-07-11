using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Models;
using Application.ViewModels;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile :Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
