using StudentDorms.Common.Exceptions;
using StudentDorms.Domain;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.Shared;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDorms.API.Controllers
{
    [Route("[controller]")]
    public class SharedController : Controller
    {
        ISharedService _sharedService;

        public SharedController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }


        #region Global
        [HttpGet("GetAppSettings")]
        public JsonResult GetAppSettings()
        {
            var appSettings = _sharedService.GetAppSettings();
            return Json(appSettings);
        }

        #endregion

        [HttpPost("GetBooleanOptionsForDropdown")]
        public JsonResult GetBooleanOptionsForDropdown()
        {
            var result = _sharedService.GetBooleanOptionsForDropdown();
            return Json(result);
        }

        [HttpPost("GetGroupingOptions")]
        public JsonResult GetGroupingOptions()
        {
            var result = _sharedService.GetGroupingOptions();
            return Json(result);
        }

    }
}
