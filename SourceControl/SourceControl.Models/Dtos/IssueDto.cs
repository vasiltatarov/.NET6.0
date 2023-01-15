namespace SourceControl.Models.Dtos;

public class IssueDto
{
    public string Title { get; set; }

    public string Comment { get; set; }

    public string Status { get; set; }

	public string CreatedOn { get; set; }

	public string UserEmail { get; set; }
}
