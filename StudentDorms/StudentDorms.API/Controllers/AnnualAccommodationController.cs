using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentDorms.Models.CreateUpdateModels;
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
    public class AnnualAccommodationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        IAnnualAccommodationService _accommodationService;

        public AnnualAccommodationController(IAnnualAccommodationService accommodationService)
        {
         
            _accommodationService = accommodationService;
        }

        [HttpPost("GetAccommodationsForGrid")]
        [AllowAnonymous]
        public JsonResult GetAccommodationsForGrid([FromBody] AnnualAccommodationSearchModel accommodationSearchModel)
        {
            var result = _accommodationService.GetAnnualAccommodationsForGrid(accommodationSearchModel);
            return Json(result);
        }

        [HttpPost("UpdateAccommodation")]
        public JsonResult UpdateAccommodation([FromBody] AccommodationCreateUpdateModel accommodationCreateUpdateModel)
        {
            _accommodationService.UpdateAnnualAccommodation(accommodationCreateUpdateModel);
            return Json(true);
        }
        [HttpPost("GetAccommodationById")]
        public JsonResult GetAccommodationById([FromBody] IntSearchModel intSearchModel)
        {
           var  result= _accommodationService.GetAccommodationById(intSearchModel.Id);
            return Json(result);
        }

       
    }
}
