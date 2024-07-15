using StudentDorms.Common.Exceptions;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentDorms.API.Controllers
{
    /// <summary>
    /// Container holding public information. 
    /// Methods in this Controller will be access with anonymous access
    /// </summary>
    [AllowAnonymous]
    public class OpenApiController : Controller
    {
        private readonly ISharedService _sharedService;

        public OpenApiController(ISharedService sharedService)
        {

        }
        /// <summary>
        /// Method for Verifying Connection to the API
        /// </summary>
        /// <returns></returns>
        public IActionResult VerifyConnection()
        {
            return View();
        }


    }
}
