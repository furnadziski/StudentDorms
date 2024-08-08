using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentDorms.Data.Interfaces;
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
    public class ConfigController : Controller
    {
        IRoleService _roleService;
        IGenderService _genderService;
        ISharedService _sharedService;
        IUserService _userService;
        IBlockService _blockService;
        IStudentDormService _studentDormService;
        IRoomService _roomService;
        IMealService _mealService;
      
        public IActionResult Index()
        {
            return View();
        }

        public ConfigController(IUserService userService, IStudentDormService studentDormService, ISharedService sharedService, 
            IBlockService blockService, IRoomService roomService, IMealService mealService)
        {
            _studentDormService = studentDormService;
            _userService = userService;
            _sharedService = sharedService;
            _blockService = blockService;
            _roomService = roomService;
            _mealService = mealService;
        }

        [HttpPost("GetUsersForGrid")]
        [AllowAnonymous]
        public JsonResult GetUsersForGrid([FromBody] UserSearchModel userSearchModel)
        {
            var result = _userService.GetUsersForGrid(userSearchModel);
            return Json(result);
        }
        public JsonResult GetStudentDormsForGrid([FromBody] StudentDormSearchModel studentDormSearchModel)
        {
            var result = _studentDormService.GetStudentDormsForGrid(studentDormSearchModel);
            return Json(result);
        }

        [HttpPost("GetBlocksForGrid")]
        [AllowAnonymous]
        public JsonResult GetBlocksForGrid([FromBody] BlockSearchModel blockSearchModel)
        {
            var result = _blockService.GetBlocksForGrid(blockSearchModel);
            return Json(result);
        }

        [HttpPost("GetRoomsForGrid")]
        [AllowAnonymous]
        public JsonResult GetRoomsForGrid([FromBody] RoomSearchModel roomSearchModel)
        {
            var result = _roomService.GetRoomsForGrid(roomSearchModel);
            return Json(result);
        }

        [HttpPost("GeMealCategoriesForGrid")]
        [AllowAnonymous]
        public JsonResult GetMealCategoriesForGrid([FromBody] MealCategorySearchModel mealCategorySearchModel)
        {
            var result = _mealService.GeMealCategoriesForGrid(mealCategorySearchModel);
            return Json(result);
        }

        [HttpPost("GetMealsForGrid")]
        [AllowAnonymous]
        public JsonResult GetMealsForGrid([FromBody] MealSearchModel mealSearchModel)
        {
            var result = _mealService.GetMealsForGrid(mealSearchModel);
            return Json(result);
        }

        [HttpPost("CreateUser")]
        public JsonResult CreateUser([FromBody] UserCreateUpdateModel userCreateUpdateModel)
        {
            _userService.CreateUser(userCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("CreateStudentDorm")]
        public JsonResult CreateStudentDorm([FromBody] StudentDormCreateUpdateModel studentDormCreateUpdateModel)
        {
            _studentDormService.CreateStudentDorm(studentDormCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("CreateBlock")]
        public JsonResult CreateBlock([FromBody] BlockCreateUpdateModel blockCreateUpdateModel)
        {
            _blockService.CreateBlock(blockCreateUpdateModel);
            return Json(true);
        }
        [HttpPost("CreateRoom")]
        public JsonResult CreateRoom([FromBody] RoomCreateUpdateModel roomCreateUpdateModel)
        {
            _roomService.CreateRoom(roomCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("CreateMeal")]
        public JsonResult CreateMeal([FromBody] MealCreateUpdateModel mealCreateUpdateModel)
        {
            _mealService.CreateMeal(mealCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateUser")]
        public JsonResult UpdateUser([FromBody] UserCreateUpdateModel userCreateUpdateModel)
        {
            _userService.UpdateUser(userCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateStudentDorm")]
        public JsonResult UpdateStudentDorm([FromBody] StudentDormCreateUpdateModel studentDormCreateUpdateModel)
        {
            _studentDormService.UpdateStudentDorm(studentDormCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateBlock")]
        public JsonResult UpdateBlock([FromBody] BlockCreateUpdateModel blockCreateUpdateModel)
        {
            _blockService.UpdateBlock(blockCreateUpdateModel);
            return Json(true);
        }
        [HttpPost("UpdateRoom")]
        public JsonResult UpdateRoom([FromBody] RoomCreateUpdateModel roomCreateUpdateModel)
        {
            _roomService.UpdateRoom(roomCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateMeal")]
        public JsonResult UpdateMeal([FromBody] MealCreateUpdateModel mealCreateUpdateModel)
        {
            _mealService.UpdateMeal(mealCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("GetRolesForDropdown")]
        public JsonResult GetRolesForDropdown()
        {
            var result = _roleService.GetRolesForDropdown();
            return Json(result);
        }

        [HttpPost("GetGendersForDropdown")]
        public JsonResult GetGendersForDropdown()
        {
            var result = _genderService.GetGendersForDropdown();
            return Json(result);
        }
        [HttpPost("GetBooleanOptionsForDropdown")]
        public JsonResult GetBooleanOptionsForDropdown()
        {
            var result = _sharedService.GetBooleanOptionsForDropdown();
            return Json(result);
        }

        [HttpPost("DeleteStudentDormById")]
        public JsonResult DeleteStudentDormById([FromBody] IntSearchModel intSearchModel)
        {
            _studentDormService.DeleteStudentDormById(intSearchModel.Id);
            return Json(true);

        }

        [HttpPost("DeleteBlockById")]
        public JsonResult DeleteBlockById([FromBody] IntSearchModel intSearchModel)
        {
            _blockService.DeleteBlockById(intSearchModel.Id);
            return Json(true);
        }

        [HttpPost("DeletRoomById")]
        public JsonResult DeleteRoomById([FromBody] IntSearchModel intSearchModel)
        {
            _roomService.DeleteRoomById(intSearchModel.Id);
            return Json(true);
        }

        [HttpPost("DeletMealById")]
        public JsonResult DeleteMealById([FromBody] IntSearchModel intSearchModel)
        {
            _mealService.DeleteMealById(intSearchModel.Id);
            return Json(true);
        }

    }
}

