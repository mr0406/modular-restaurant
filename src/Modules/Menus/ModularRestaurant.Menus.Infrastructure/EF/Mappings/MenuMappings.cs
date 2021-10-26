using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Menus.Infrastructure.EF.Mappings
{
    public static class MenuMappings
    {
        public static MenuDTO ToDTO(this Menu Menu)
        {
            return new MenuDTO()
            {
                Groups = Menu.Groups?.ToDTOs()
            };
        }

        public static IEnumerable<MenuDTO> ToDTOs(this IEnumerable<Menu> menus)
        {
            return menus.Select(ToDTO);
        }
    }
}