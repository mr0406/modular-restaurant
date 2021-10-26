using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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
        {
            return items.Select(ToDTO);
        }
    }
}