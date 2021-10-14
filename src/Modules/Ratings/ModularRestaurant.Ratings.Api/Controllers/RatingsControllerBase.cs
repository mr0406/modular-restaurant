using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [Route(RatingsModule.BasePath + "/[controller]")]
    public abstract class RatingsControllerBase : ModuleControllerBase
    {
    }
}
