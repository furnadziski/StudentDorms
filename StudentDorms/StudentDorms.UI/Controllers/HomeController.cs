using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace StudentDorms.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return File("~/ClientApp/index.html", "text/html");
        }

      
       
        /// <summary>
        /// Get settings paramametars from appsettings.json in SettingModel object. 
        /// This parameters will be returned to client and used in client side code
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAppSettings()
        {

            //var accessToken = AuthenticationProvider.GetAccessTokenModel(_httpContextAccessor);
            //var model = new AppSettingsSharedModel();

            //if (!string.IsNullOrEmpty(accessToken.refreshTokenUrl))
            //{
            //    model.appSettings = null;
            //    model.refreshTokenUrl = accessToken.refreshTokenUrl;
            //}
            //else
            //{
            //    var appSettings = Utils.AjaxToApiController(accessToken.token, "Shared", "GetAppSettings", string.Empty, "GET");
            //    if (string.IsNullOrEmpty(appSettings))
            //        throw new COMSException("EMPTY_RESULT");

            //    model.appSettings = JsonConvert.DeserializeObject<AppSettingsModel>(appSettings);
            //    model.refreshTokenUrl = string.Empty;
            //}

            //return Json(model);
            return Json(true);
        }

    }
}
