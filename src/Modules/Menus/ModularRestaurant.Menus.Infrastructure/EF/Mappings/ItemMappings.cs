using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF.Mappings
{
    public static class ItemMappings
    {
        public static ItemDTO ToDTO(this Item item)
        {
            return new ItemDTO()
            {
                Name = item.Name
            };
        }

        public static IEnumerable<ItemDTO> ToDTOs(this IEnumerable<Item> items)
            => items.Select(ToDTO);
    }
}
