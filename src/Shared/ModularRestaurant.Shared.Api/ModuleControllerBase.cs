using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Api
{
    [ApiController]
    public abstract class ModuleControllerBase : ControllerBase
    {
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if(model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
