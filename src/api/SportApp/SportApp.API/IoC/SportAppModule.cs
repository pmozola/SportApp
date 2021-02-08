using Autofac;
using System.Reflection;

using MediatR;
using SportApp.Application.Bahaviors;
using SportApp.Application.CommandHandlers;

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
        }
    }
}
