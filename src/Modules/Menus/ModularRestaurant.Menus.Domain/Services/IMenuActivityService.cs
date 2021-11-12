using System.Threading.Tasks;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Services
{
    public interface IMenuActivityService
    {
        Task ChangeActive(RestaurantId restaurantId, MenuId menuToActivateId);
        Task Deactivate(MenuId menuToDeactivateId);
    }
}