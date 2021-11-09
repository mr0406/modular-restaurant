using System;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Menus.Domain.Exceptions
{
    public class MenuInRestaurantNotFoundException : NotFoundException
    {
        public readonly Guid RestaurantId;
        public readonly Guid MenuId;
        
        //TODO: Consider use RestaurantId instead of Guid, same to MenuId
        //It will private passing arguments in incorrect order
        public MenuInRestaurantNotFoundException(Guid restaurantId, Guid menuId)
            : base($"Menu of Id: {menuId} not found in {restaurantId}")
        {
            RestaurantId = restaurantId;
            MenuId = menuId;
        }
    }
}