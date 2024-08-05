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
        IStudentDormService _studentDormService;
        public IActionResult Index()
        {
            return View();
        }

        public ConfigController(IUserService userService,IStudentDormService studentDormService,ISharedService sharedService)
        {
            _studentDormService = studentDormService;
            _userService = userService;
            _sharedService = sharedService;
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
    }
}

