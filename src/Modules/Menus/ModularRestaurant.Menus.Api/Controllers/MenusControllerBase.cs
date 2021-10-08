using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Controllers
{
    [Route(MenusModule.BasePath + "/[controller]")]
    public abstract class MenusControllerBase : ModuleControllerBase
    {
    }
}
