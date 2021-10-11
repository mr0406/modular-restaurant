using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Queries
{
    public record GetMenuQuery(Guid Id) : IQuery<MenuDTO>;
}
