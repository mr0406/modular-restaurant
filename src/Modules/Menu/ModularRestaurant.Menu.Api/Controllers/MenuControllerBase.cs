using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menu.Api.Controllers
{
    [Route(MenuModule.BasePath + "/[controller]")]
    public abstract class MenuControllerBase : ModuleControllerBase
    {
    }
}
