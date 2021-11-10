using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Events
{
    public class MenuDeactivatedByRestaurantEvent : DomainEvent
    {
        public readonly RestaurantId RestaurantId;
        public readonly MenuId DeactivatedMenuId;

        public MenuDeactivatedByRestaurantEvent(RestaurantId restaurantId, MenuId deactivatedMenuId)
        {
            RestaurantId = restaurantId;
            DeactivatedMenuId = deactivatedMenuId;
        }
    }
}