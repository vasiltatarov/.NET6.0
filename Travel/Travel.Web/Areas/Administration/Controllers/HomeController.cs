namespace Travel.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Travel.Web.Constants.WebConstants;

    [Authorize(Roles = AdminRoleName)]
    [Area(AreaName)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
