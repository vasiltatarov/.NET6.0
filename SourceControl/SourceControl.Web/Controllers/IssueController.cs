namespace SourceControl.Web.Controllers;

[Authorize]
public class IssueController : Controller
{
	private readonly IIssueService issueService;

	public IssueController(IIssueService issueService)
	{
		this.issueService = issueService;
	}

	public IActionResult GetAll(int repositoryId)
	{
		var issues = this.issueService.GetAll(repositoryId).GetAwaiter().GetResult();
		return Json(new { data = issues });
	}

	public async Task<IActionResult> Close(int id, int repoId)
	{
		var result = await this.issueService.Close(id, repoId, this.User.UserId());

		if (!result)
		{
			return BadRequest();
		}

		return RedirectToAction("DetailsPage", "Repository", new { id = repoId, tab = "issues" });
	}
}
