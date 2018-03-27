namespace BlueSky.Commerce.WebUI.Controllers
{
    using Common.WebFramework.Controllers;
    using Common.WebFramework.Security;
    using System;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        [HttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        {
            return View();
        }
    }
}