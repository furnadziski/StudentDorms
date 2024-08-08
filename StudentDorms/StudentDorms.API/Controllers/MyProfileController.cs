using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentDorms.Models.SearchModels;
using StudentDorms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDorms.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        IMealService _mealService;

        public MyProfileController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpPost("FilterMealSchedule")]
        [AllowAnonymous]
        public JsonResult FilterMealSchedule([FromBody] FilterMealSearchModel filterMealSearchModel)
        {
            var result = _mealService.FilterMealSchedule(filterMealSearchModel);
            return Json(result);
        }

    }


}
