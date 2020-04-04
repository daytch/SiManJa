using uangsaku.Application.Interfaces;
using uangsaku.Application.Services;
using uangsaku.Domain.CommandHandlers;
using uangsaku.Domain.Commands;
using uangsaku.Domain.Core.Bus;
using uangsaku.Domain.Core.Events;
using uangsaku.Domain.Core.Notifications;
using uangsaku.Domain.EventHandlers;
using uangsaku.Domain.Events;
using uangsaku.Domain.Interfaces;
using uangsaku.Infra.CrossCutting.Bus;
using uangsaku.Infra.CrossCutting.Identity.Authorization;
using uangsaku.Infra.CrossCutting.Identity.Models;
using uangsaku.Infra.Data.Context;
using uangsaku.Infra.Data.EventSourcing;
using uangsaku.Infra.Data.Repository;
using uangsaku.Infra.Data.Repository.EventSourcing;
using uangsaku.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace uangsaku.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<uangsakuContext>();
            services.AddDbContext<UangsakuContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();
            services.AddDbContext<EventStoreSqlContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}