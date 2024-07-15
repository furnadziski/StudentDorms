using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace StudentDorms.API.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

    }
}
