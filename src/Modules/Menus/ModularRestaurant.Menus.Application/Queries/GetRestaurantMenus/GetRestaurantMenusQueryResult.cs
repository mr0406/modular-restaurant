using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.Queries.GetRestaurantMenus
{
    public class GetRestaurantMenusQueryResult
    {
        public IEnumerable<Menu> Menus { get; init; }
        
        public record Menu(string InternalName, bool IsActive);
    }
}