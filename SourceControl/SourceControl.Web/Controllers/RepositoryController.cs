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

	public async Task<IActionResult> Index()
	{
		var repos = await this.repositoryService.GetAllByUser(User.UserId());

		return View(repos);
	}

	public async Task<IActionResult> DetailsPage(int id)
	{
		var repo = await this.repositoryService.GetById(id);
		if (repo == null)
		{
			return NotFound();
		}

		return View(repo);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateRepositoryViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		var repo = this.mapper.Map<Repository>(model);
		repo.UserId = User.UserId();
		await this.repositoryService.Create(repo);

		TempData["success"] = "Successfully created repository";

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Edit(int id)
	{
		var repo = await this.repositoryService.GetByUserId(id, User.UserId());
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
		await this.repositoryService.Edit(repo, User.UserId());

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Delete(int id)
	{
		await this.repositoryService.Delete(id, User.UserId());

		return RedirectToAction("Index");
	}
}
