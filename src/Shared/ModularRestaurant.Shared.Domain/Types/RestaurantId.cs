﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Types
{
    public class RestaurantId : TypeId
    {
        public RestaurantId(Guid value)
            : base(value)
        {
        }
    }
}
