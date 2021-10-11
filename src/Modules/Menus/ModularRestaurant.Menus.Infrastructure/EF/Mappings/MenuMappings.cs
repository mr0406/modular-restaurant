using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            => menus.Select(ToDTO);
    }
}
