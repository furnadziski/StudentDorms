﻿using Microsoft.AspNetCore.Authorization;
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
    public class MealController : Controller
    {
        IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("FilterMealSchedule")]
        [AllowAnonymous]
        public JsonResult FilterMealSchedule([FromBody] FilterMealSearchModel filterMealSearchModel)
        {
            var result = _mealService.FilterMealSchedule(filterMealSearchModel);
            return Json(result);
        }

        [HttpPost("FilterMealVoting")]
        [AllowAnonymous]
        public JsonResult FilterMealVoting([FromBody] FilterMealVotingSearchModel filterMealVotingSearchModel)
        {
            var result = _mealService.FilterMealVoting(filterMealVotingSearchModel);
            return Json(result);
        }

    }
}