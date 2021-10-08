using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Menu.Api.Controllers
{
    [ApiController]
    public class HomeController : MenuControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Menu API!";
    }
}
