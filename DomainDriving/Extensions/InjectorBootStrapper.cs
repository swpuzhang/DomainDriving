using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastruct.Data.Context;
using Infrastruct.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Domain.Core.Bus;
using Infrastruct.Bus;

namespace DomainDriving.Extensions
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();//上下文
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, InMemoryBus>();
        }
    }
}
