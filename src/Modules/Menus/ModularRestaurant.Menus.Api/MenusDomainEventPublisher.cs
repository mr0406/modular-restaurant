using System.Threading.Tasks;
using Autofac;
using MediatR;
using ModularRestaurant.Menus.Infrastructure;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Api
{
    public class MenusDomainEventPublisher : IMenusDomainEventPublisher
    {
        public async Task Publish(DomainEvent domainEvent)
        {
            await using (var scope = MenusCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                await mediator.Publish(domainEvent);
            }
        }
    }
}