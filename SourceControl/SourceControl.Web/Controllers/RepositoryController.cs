using SourceControl.Models.Issue;

namespace SourceControl.Web.Controllers;

[Authorize]
public class RepositoryController : Controller
{
	private readonly IRepositoryService repositoryService;
	private readonly IMapper mapper;
	private readonly IIssueService issueService;

	public RepositoryController(IRepositoryService repositoryService, IMapper mapper, IIssueService issueService)
	{
		this.repositoryService = repositoryService;
		this.mapper = mapper;
		this.issueService = issueService;
	}

	public async Task<IActionResult> Index()
	{
		var repos = await this.repositoryService.GetAllByUser(User.UserId());

		return View(repos);
	}

	public async Task<IActionResult> DetailsPage(int id, string tab = "code")
	{
		var repo = await this.repositoryService.GetById(id);
		if (repo == null)
		{
			return NotFound();
		}

		var issues = await this.issueService.GetAll(id);

		var vm = new RepositoryDetailsPageViewModel
		{
			Repository = repo,
			Issues = issues,
			Tab = tab
		};

		return View(vm);
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

		await this.repositoryService.Edit(model, User.UserId());

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Delete(int id)
	{
		await this.repositoryService.Delete(id, User.UserId());

		return RedirectToAction("Index");
	}

	#region Issues
	public IActionResult CreateIssue(int repoId)
	{
		return View(new CreateIssueViewModel { RepositoryId = repoId });
	}

	[HttpPost]
	public async Task<IActionResult> CreateIssue(CreateIssueViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		var userId = User.UserId();
		await this.issueService.Create(model.Title, model.Comment, model.RepositoryId, userId);

		return RedirectToAction("DetailsPage", new { id = model.RepositoryId, tab = "issues" });
	}
	#endregion
}
