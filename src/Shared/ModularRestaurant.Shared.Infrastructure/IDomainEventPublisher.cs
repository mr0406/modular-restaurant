using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Infrastructure
{
    public interface IDomainEventPublisher
    {
        Task Publish(DomainEvent domainEvent);
    }
}