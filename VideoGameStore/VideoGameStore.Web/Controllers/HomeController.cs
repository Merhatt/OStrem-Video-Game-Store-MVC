﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace VideoGameStore.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}