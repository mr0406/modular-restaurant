using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using ModularRestaurant.Shared.Api;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.Processing.Commands;
using ModularRestaurant.Shared.Application.Processing.Requests;
using ModularRestaurant.Shared.Infrastructure.EF;

namespace ModularRestaurant.Ratings.Api.IoCModules
{
    internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = Assembly.GetExecutingAssembly().GetApplication();
            var infrastructureAssembly = Assembly.GetExecutingAssembly().GetInfrastructure();
            
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterMediatR(applicationAssembly, infrastructureAssembly);
            
            builder.RegisterGeneric(typeof(RequestLoggingBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));

            builder.RegisterGeneric(typeof(ValidatingBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(UnitOfWorkBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}