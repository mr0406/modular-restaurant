using System;
using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.Queries.GetRestaurantMenus
{
    public class GetRestaurantMenusQueryResult
    {
        public IEnumerable<Menu> Menus { get; init; }
        
        public Guid? ActiveMenuId { get; init; }
        
        public record Menu(Guid Id, string InternalName, bool IsActive);
    }
}