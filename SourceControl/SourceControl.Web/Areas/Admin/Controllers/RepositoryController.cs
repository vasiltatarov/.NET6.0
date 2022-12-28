namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryController : Controller
{
    private readonly IRepositoryService repositoryService;

    public RepositoryController(IRepositoryService repositoryService)
        => this.repositoryService = repositoryService;

    public IActionResult Index()
        => View();

    public IActionResult Edit(int id)
    {
        return Ok();
    }

    #region API Calls
    public IActionResult GetAll()
    {
        var repositories = this.repositoryService.GetAllRows();
        return Json(new { data = repositories });
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var isDeleted = this.repositoryService.DeleteByAdmin(id);
        return Json(new { success = isDeleted, message = isDeleted ? "Deleted successfuly" : "Failed" });
    }
    #endregion
}
