using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.DTOs
{
    public class MenuDTO
    {
        public IEnumerable<GroupDTO> Groups { get; set; }
    }
}
