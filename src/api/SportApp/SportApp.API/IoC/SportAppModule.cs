using Autofac;
using System.Reflection;

using MediatR;
using SportApp.Application.Bahaviors;
using SportApp.Application.CommandHandlers;
using SportApp.Infrastructure.Repositories;
using SportApp.API.Infrastructure;
using SportApp.Application;
using Microsoft.EntityFrameworkCore;
using SportApp.Infrastructure;
using System;
using SportApp.Domain;

namespace SportApp.API.IoC
{
    public class SportAppModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(AddWeightCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }


            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ExceptionBehevior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { return componentContext.TryResolve(t, out object o) ? o : null; };
            });

            builder.RegisterAssemblyTypes(typeof(WeightRepository).GetTypeInfo().Assembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserContext>().As<IUserContext>();

            builder
               .Register(c =>
               {
                   var dbContextOptionsBuilder = new DbContextOptionsBuilder<SportAppDbContext>();

                   dbContextOptionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SportApp;Integrated Security=True");
                   dbContextOptionsBuilder.LogTo(Console.WriteLine)
                       .EnableSensitiveDataLogging();


                   return new SportAppDbContext(dbContextOptionsBuilder.Options);
               })
               .AsSelf()
               .As<DbContext>()
               .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<DomainEventDispacher>().As<IDomainEventDispacher>().InstancePerLifetimeScope();
        }
    }
}
