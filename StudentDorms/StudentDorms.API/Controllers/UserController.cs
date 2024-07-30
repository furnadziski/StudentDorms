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
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetUsersForGrid")]
        [AllowAnonymous]
        public JsonResult GetUsersForGrid([FromBody] UserSearchModel userSearchModel)
        {
            var result = _userService.GetUsersForGrid(userSearchModel);
            return Json(true);
        }

    }
}
