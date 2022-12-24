namespace SourceControl.Web.Areas.Admin.Controllers;

using Newtonsoft.Json;

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

    public async Task<IActionResult> GetAll()
    {
        var repositories = await this.repositoryService.GetAllPublic();
        return Json(JsonConvert.SerializeObject(repositories));
    }
}
