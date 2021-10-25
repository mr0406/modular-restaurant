using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using ModularRestaurant.Menus.Application.Commands.CreateGroup;
using ModularRestaurant.Menus.Application.Processing;
using ModularRestaurant.Menus.Infrastructure.EF;
using ModularRestaurant.Shared.Application.Processing.Commands;
using ModularRestaurant.Shared.Application.Processing.Requests;

namespace ModularRestaurant.Menus.Api.IoCModules
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //fix that: need Application and Infrastructure Assemblies

            builder.RegisterMediatR(typeof(CreateGroupCommand).Assembly, typeof(MenusDbContext).Assembly);
            
            /*builder.RegisterGeneric(typeof(RequestLoggingBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));

            builder.RegisterGeneric(typeof(ValidatingBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(MenusUnitOfWorkBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));*/
        }
    }
}