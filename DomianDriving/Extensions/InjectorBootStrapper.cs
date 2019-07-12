using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastruct.Data.Context;
using Infrastruct.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomianDriving.Extensions
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();//上下文
        }
    }
}
