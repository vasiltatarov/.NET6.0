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
}
