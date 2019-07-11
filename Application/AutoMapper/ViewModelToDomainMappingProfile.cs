using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Application.ViewModels;
using AutoMapper;

namespace Application.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>();
        }
    }
}
