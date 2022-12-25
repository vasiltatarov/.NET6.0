namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryController : Controller
{
    private readonly IRepositoryService repositoryService;

    public RepositoryController(IRepositoryService repositoryService)
        => this.repositoryService = repositoryService;

    public IActionResult Index()
    {
        return View();
    }

    #region API Calls
    public IActionResult GetAll()
    {
        var repositories = this.repositoryService.GetAllRows();
        return Json(new { data = repositories });
    }
    #endregion
}
