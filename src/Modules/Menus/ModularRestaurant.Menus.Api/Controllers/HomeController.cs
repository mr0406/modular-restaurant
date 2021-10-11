﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModularRestaurant.Menus.Api.Controllers
{
    [ApiController]
    public class HomeController : MenusControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Menu API!";
    }
}