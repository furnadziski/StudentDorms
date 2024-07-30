using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDorms.API.Controllers
{
    public class ConfigController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
