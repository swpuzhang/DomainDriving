using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
           
            return new MapperConfiguration(cfg =>
            {
                
                cfg.AddProfile(new MappingProfile());
                
                
            });
        }
    }
}
