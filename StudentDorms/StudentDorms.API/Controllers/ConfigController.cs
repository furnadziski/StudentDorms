 using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentDorms.Data.Interfaces;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
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
        IStudentDormService _studentDormService;
        IUserService _userService;
        ISharedService _sharedService;
        IBlockService _blockService;
        IRoomService _roomService;
        IMealService _mealService;
        IRoleService _roleService;
        IGenderService _genderService;
          public ConfigController(
            IStudentDormService studentDormService,
            IUserService userService,
            ISharedService sharedService,
            IBlockService blockService,
            IRoomService roomService,
            IMealService mealService,
            IRoleService roleService,
            IGenderService genderService
         )
        {
            _studentDormService = studentDormService;
            _userService = userService;
            _sharedService = sharedService;
            _blockService = blockService;
            _roomService = roomService;
            _mealService = mealService;
            _roleService = roleService;
            _genderService = genderService;
        } 
        
       [HttpPost("GetUsersForGrid")]
       [AllowAnonymous]
       public JsonResult GetUsersForGrid([FromBody] UserSearchModel userSearchModel)
       {
           var result = _userService.GetUsersForGrid(userSearchModel);
           return Json(result);
       }

        [HttpPost("GetUserForMyProfile")]
        [AllowAnonymous]
        public JsonResult GetUserForMyProfile([FromBody] MyProfileSearchModel myProfileSearchModel)
        {
            var result = _userService.GetUserForMyProfile(myProfileSearchModel);
            return Json(result);
        }
        [HttpPost("GetUserById")]
        [AllowAnonymous]
        public JsonResult GetUserById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _userService.GetUserById(intSearchModel.Id);
            return Json(result);
        }


        [HttpPost("GetStudentDormsForGrid")]
        [AllowAnonymous]
        public JsonResult GetStudentDormsForGrid([FromBody] StudentDormSearchModel studentDormSearchModel)
        {
            var result = _studentDormService.GetStudentDormsForGrid(studentDormSearchModel);
            return Json(result);
        }

        [HttpPost("GetStudentDormById")]
        [AllowAnonymous]
        public JsonResult GetRestaurantById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _studentDormService.GetStudentDormById(intSearchModel.Id);
            return Json(result);
        }
        [HttpPost("GetStudentDormsForDropdown")]
        [AllowAnonymous]
        public JsonResult GetStudentDormsForDropdown()
        {
            var result = _studentDormService.GetStudentDormsForDropdown();
            return Json(result);
        }

        [HttpPost("GetBlocksForDropdownByStudentDormId")]
        [AllowAnonymous]
        public JsonResult GetBlocksForDropdownByStudentDormId([FromBody] IntSearchModel intSearchModel)
        {
            var result = _blockService.GetBlocksForDropdownByStudentDormId(intSearchModel.Id);
            return Json(result);
        }
        [HttpPost("GetRoomsForDropdownByBlockId")]
        [AllowAnonymous]
        public JsonResult GetRoomsForDropdownByBlockId([FromBody] IntSearchModel intSearchModel)
        {
            var result = _roomService.GetRoomsForDropdownByBlockId(intSearchModel.Id);
            return Json(result);
        }



        [HttpPost("GetUserWithRoleAndBlock")]
        [AllowAnonymous]
        public JsonResult GetUserWithRoleAndBlock([FromBody] UserWithRoleAndBlockSearchModel userWithRoleAndBlockSearchModel)
        {
            var result = _userService.GetUserWithRoleAndBlock(userWithRoleAndBlockSearchModel.BlockId, userWithRoleAndBlockSearchModel.Year);
            return Json(result);
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

        [HttpPost("GetMealsForDropdown")]
        [AllowAnonymous]
        public JsonResult FilterMeals([FromBody] IntSearchModel intSearchModel)
        {
            var result = _mealService.GetMealsForDropdown(intSearchModel.Id);
            return Json(result);
        }

        [HttpPost("GetBlocksForDropdown")]
        [AllowAnonymous]
        public JsonResult GetBlocksForDropdown()
        {
            var result = _blockService.GetBlocksForDropdown();
            return Json(result);
        }

        [HttpPost("GetBlockById")]
        [AllowAnonymous]
        public JsonResult GetBlockById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _blockService.GetBlockById(intSearchModel.Id);
            return Json(result);
        }

        [HttpPost("GetRoomById")]
        [AllowAnonymous]
        public JsonResult GetRoomById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _roomService.GetRoomById(intSearchModel.Id);
            return Json(result);
        }

        [HttpPost("GetMealById")]
        [AllowAnonymous]
        public JsonResult GetMealById([FromBody] IntSearchModel intSearchModel)
        {
            var result = _mealService.GetMealById(intSearchModel.Id);
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

        [HttpPost("GetMealCategoriesForGrid")]
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

        [HttpPost("SaveMealVote")]
        public JsonResult SaveMealVote([FromBody] List<MealVoteGridModel> mealVoteGridModels)
        {
            _mealService.SaveMealVote(mealVoteGridModels);
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

        [HttpPost("UpdateBlock")]
        public JsonResult UpdateBlock([FromBody] BlockCreateUpdateModel blockCreateUpdateModel)
        {
            _blockService.UpdateBlock(blockCreateUpdateModel);
            return Json(true);
        }

        [HttpPost("UpdateStudentDorm")]
       public JsonResult UpdateStudentDorm([FromBody] StudentDormCreateUpdateModel studentDormCreateUpdateModel)
       {
           _studentDormService.UpdateStudentDorm(studentDormCreateUpdateModel);
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
        [HttpPost("GetRoomsForDropdown")]
        public JsonResult GetRoomsForDropdown()
        {
            var result = _roomService.GetRoomsForDropdown();
            return Json(result);
        }

        [HttpPost("GetMealCategoriesForDropdown")]
        public JsonResult GetMealCategoriesForDropdown()
        {
            var result = _mealService.GetMealCategoriesForDropdown();
            return Json(result);
        }

        [HttpPost("GetGendersForDropdown")]
        public JsonResult GetGendersForDropdown()
        {
            var result = _genderService.GetGendersForDropdown();
            return Json(result);
        }

        [HttpPost("GetStudentsForDropDown")]
        public JsonResult GetStudentsForDropdown()
        {
            var result = _userService.GetStudentsForDropDown();
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

        [HttpPost("DeleteRoomById")]
        public JsonResult DeleteRoomById([FromBody] IntSearchModel intSearchModel)
        {
            _roomService.DeleteRoomById(intSearchModel.Id);
            return Json(true);
        }

        [HttpPost("DeleteMealById")]
        public JsonResult DeleteMealById([FromBody] IntSearchModel intSearchModel)
        {
            _mealService.DeleteMealById(intSearchModel.Id);
            return Json(true);
        }
    }
}

