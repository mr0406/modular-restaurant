using System.Threading.Tasks;
using Autofac;
using MediatR;
using ModularRestaurant.Ratings.Infrastructure;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Api
{
    public class RatingsDomainEventPublisher : IRatingsDomainEventPublisher
    {
        public async Task Publish(DomainEvent domainEvent)
        {
            await using (var scope = RatingsCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                await mediator.Publish(domainEvent);
            }
        }
    }
}