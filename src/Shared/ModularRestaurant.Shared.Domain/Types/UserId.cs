using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class UserId : TypeId
    {
        public UserId(Guid value)
            : base(value)
        {
        }
    }
}
