using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Menus.Api.Controllers
{
    [Route("menus-module")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Menus API!";
    }
}
