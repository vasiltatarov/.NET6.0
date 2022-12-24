namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
