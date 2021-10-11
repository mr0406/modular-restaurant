using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class MenuId : TypeId
    {
        public MenuId(Guid value)
            : base(value)
        {
        }
    }
}
