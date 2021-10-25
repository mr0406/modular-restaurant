using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Api.Controllers
{
    [Route("ratings-module/[controller]")]
    public abstract class RatingsControllerBase : ControllerBase
    {
        protected readonly IRatingsExecutor Executor;
        
        public RatingsControllerBase(IRatingsExecutor executor)
        {
            Executor = executor;
        }
    }
}
