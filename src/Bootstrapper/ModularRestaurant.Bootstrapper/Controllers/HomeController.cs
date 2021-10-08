using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModularRestaurant.Bootstrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController
    {
        [HttpGet]
        public ActionResult<string> Index() => "Modular Restaurant API!";
    }
}
