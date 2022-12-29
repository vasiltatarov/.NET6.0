namespace SourceControl.Web.Areas.Admin.Controllers;

using SourceControl.Models.Dtos;
using SourceControl.Models.Repository;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryController : Controller
{
    private readonly IRepositoryService repositoryService;
    private readonly IMapper mapper;

    public RepositoryController(IRepositoryService repositoryService, IMapper mapper)
    {
        this.repositoryService = repositoryService;
        this.mapper = mapper;
    }

    public IActionResult Index()
        => View();

    public async Task<IActionResult> Edit(int id)
    {
        var repo = await this.repositoryService.GetById(id);
        var vm = this.mapper.Map<EditRepositoryViewModel>(repo);

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditRepositoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var repo = this.mapper.Map<EditRepositoryDto>(model);
        await this.repositoryService.Edit(repo);
        
        return RedirectToAction("Index");
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
        var isDeleted = this.repositoryService.Delete(id);
        return Json(new { success = isDeleted, message = isDeleted ? "Deleted successfuly" : "Failed" });
    }
    #endregion
}
