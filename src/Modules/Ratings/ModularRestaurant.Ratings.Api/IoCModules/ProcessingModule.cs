using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using ModularRestaurant.Shared.Api;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.Processing.Commands;
using ModularRestaurant.Shared.Infrastructure.MsSql;
using Module = Autofac.Module;

namespace ModularRestaurant.Ratings.Api.IoCModules
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = Assembly.GetExecutingAssembly().GetApplication();
            var infrastructureAssembly = Assembly.GetExecutingAssembly().GetInfrastructure();
            
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterMediatR(applicationAssembly, infrastructureAssembly);

            builder.RegisterGeneric(typeof(UnitOfWorkBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}