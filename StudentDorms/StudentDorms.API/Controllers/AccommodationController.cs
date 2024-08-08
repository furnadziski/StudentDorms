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
    public class AccommodationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        IAccommodationService _accommodationService;

        public AccommodationController(IAccommodationService accommodationService)
        {
         
            _accommodationService = accommodationService;
        }

        [HttpPost("GetAccommodationsForGrid")]
        [AllowAnonymous]
        public JsonResult GetAccommodationsForGrid([FromBody] AccommodationSearchModel accommodationSearchModel)
        {
            var result = _accommodationService.GetAccommodationsForGrid(accommodationSearchModel);
            return Json(result);
        }
    }
}
