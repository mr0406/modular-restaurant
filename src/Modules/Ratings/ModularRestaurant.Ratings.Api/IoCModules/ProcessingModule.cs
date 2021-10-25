using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using ModularRestaurant.Ratings.Application.Commands.AddRating;
using ModularRestaurant.Ratings.Application.Processing;
using ModularRestaurant.Ratings.Infrastructure.EF;

namespace ModularRestaurant.Ratings.Api.IoCModules
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RatingsUnitOfWork>().As<IRatingsUnitOfWork>().InstancePerLifetimeScope();
            
            builder.RegisterMediatR(typeof(AddRatingCommand).Assembly, typeof(RatingsDbContext).Assembly);
            
            builder.RegisterGeneric(typeof(RatingsUnitOfWorkBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}