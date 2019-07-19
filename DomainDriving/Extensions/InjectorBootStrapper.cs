using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastruct.Data.Context;
using Infrastruct.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Domain.Core.Bus;
using Infrastruct.Bus;
using Infrastruct.Data.Uow;
using Domain.Commands;
using Domain.CommandHandlers;
using Microsoft.Extensions.Caching.Memory;
using Domain.Events;
using Domain.EventHandlers;
using Domain.Core.Notifications;
using Infrastruct.Data.EventSourcing;
using Infrastruct.Data.Repository.EventSourcing;
using Domain.Core.Events;

namespace DomainDriving.Extensions
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();
            services.AddScoped<EventStoreSqlContext>();
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStoreService, SqlEventStoreService>();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            

        }
    }
}
