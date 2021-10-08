using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.DTOs
{
    public class GroupDTO
    {
        public string Name { get; set; }
        
        public IEnumerable<ItemDTO> Items { get; set; }
    }
}
