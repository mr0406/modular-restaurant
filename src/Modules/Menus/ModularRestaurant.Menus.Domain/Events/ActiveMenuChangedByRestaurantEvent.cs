using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Domain.Events
{
    public class ActiveMenuChangedByRestaurantEvent : DomainEvent
    {
        public readonly RestaurantId RestaurantId;
        public readonly MenuId ActivatedMenuId;

        public ActiveMenuChangedByRestaurantEvent(RestaurantId restaurantId, MenuId activatedMenuId)
        {
            RestaurantId = restaurantId;
            ActivatedMenuId = activatedMenuId;
        }
    }
}