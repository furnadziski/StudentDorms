using Aspose.Words.Lists;
using Aspose.Words.Lists;
using StudentDorms.Data.Interfaces;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.Enums;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace StudentDorms.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class RestaurantController : Controller
    {
        IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost("TestMethod")]
        [AllowAnonymous]
        public JsonResult TestMethod()
        {
            //var result = _restaurantService.GetRestaurantsForGrid(restaurantSearchModel);
            return Json(true);
        }

        [HttpPost("GetRestaurantsForGrid")]
        [AllowAnonymous]
        public JsonResult GetRestaurantsForGrid([FromBody] RestaurantSearchModel restaurantSearchModel)
        {
            //var result = _restaurantService.GetRestaurantsForGrid(restaurantSearchModel);
            return Json(true);
        }

        [HttpPost("CreateRestaurant")]
        public JsonResult CreateRestaurant([FromBody] RestaurantCreateUpdateModel restaurantCreateUpdateModel)
        {
            _restaurantService.CreateRestaurant(restaurantCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateRestaurant")]
        public JsonResult UpdateRestaurant([FromBody] RestaurantCreateUpdateModel restaurantCreateUpdateModel)
        {
            _restaurantService.UpdateRestaurant(restaurantCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("DeleteRestaurantById")]
        public JsonResult DeleteRestaurantById([FromBody] IntSearchModel intSearchModel)
        {
            _restaurantService.DeleteRestaurantById(intSearchModel.Id);
            return Json(true);

        }

        [HttpPost("GetRestaurantById")]
        public JsonResult GetRestaurantById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _restaurantService.GetRestaurantById(intSearchModel.Id);
            return Json(result);
        }

        [HttpPost("GetRestaurantsForDropdown")]
        public JsonResult GetRestaurantsForDropdown()
        {
            var result = _restaurantService.GetRestaurantsForDropdown();
            return Json(result);
        }
    }
}
