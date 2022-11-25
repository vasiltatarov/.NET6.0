namespace SourceControl.Web.Controllers;

[Authorize]
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
    {
        // Get all Repositories for current logged in user - public and private
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRepositoryViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var repo = this.mapper.Map<Repository>(vm);
        repo.UserId = User.UserId();
        await this.repositoryService.Create(repo);

        TempData["success"] = "Successfully created repository";

        return RedirectToAction("Index");
    }
}
