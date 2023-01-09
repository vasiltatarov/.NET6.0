using System.ComponentModel.DataAnnotations;

namespace SourceControl.Models.Issue;

public class CreateIssueViewModel
{
	public int RepositoryId { get; set; }

	[Required]
	[MaxLength(100)]
	public string Title { get; set; }

	[Required]
	public string Comment { get; set; }
}
