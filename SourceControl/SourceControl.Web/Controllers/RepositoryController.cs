﻿using SourceControl.Models.Issue;
using SourceControl.Models.PullRequest;

namespace SourceControl.Web.Controllers;

[Authorize]
public class RepositoryController : Controller
{
	private readonly IRepositoryService repositoryService;
	private readonly IMapper mapper;
	private readonly IIssueService issueService;
	private readonly IPullRequestService pullRequestService;

	public RepositoryController(IRepositoryService repositoryService,
		IMapper mapper,
		IIssueService issueService,
		IPullRequestService pullRequestService)
	{
		this.repositoryService = repositoryService;
		this.mapper = mapper;
		this.issueService = issueService;
		this.pullRequestService = pullRequestService;
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
		var prs = await this.pullRequestService.GetAll(id);

		var vm = new RepositoryDetailsPageViewModel
		{
			Repository = repo,
			Issues = issues,
			PullRequests = prs,
			Tab = tab,
			IsUserOwner = repo.UserId == this.User.UserId()
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

		if (await this.repositoryService.Create(model, User.UserId()))
		{
			TempData["success"] = "Successfully created repository";
		}
		else
		{
			TempData["error"] = "Something went wrong!";
		}

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
		=> View(new CreateIssueViewModel { RepositoryId = repoId });

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

	#region Pull Requests
	public IActionResult CreatePullRequest(int repoId)
		=> View(new CreatePullRequestViewModel { RepositoryId = repoId });

	[HttpPost]
	public async Task<IActionResult> CreatePullRequest(CreatePullRequestViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		var userId = User.UserId();
		await this.pullRequestService.Create(model.Title, model.Description, model.RepositoryId, userId);

		return RedirectToAction("DetailsPage", new { id = model.RepositoryId, tab = "pr" });
	}
	#endregion
}
