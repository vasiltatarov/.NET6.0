using System.ComponentModel.DataAnnotations;

namespace SourceControl.Models.PullRequest;

public class CreatePullRequestViewModel
{
	public int RepositoryId { get; set; }

	[Required]
	[MaxLength(100)]
	public string Title { get; set; }

	[Required]
	public string Description { get; set; }
}
