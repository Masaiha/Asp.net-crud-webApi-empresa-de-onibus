﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ubus.Application.Controllers
{
    public class AdditionalController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
