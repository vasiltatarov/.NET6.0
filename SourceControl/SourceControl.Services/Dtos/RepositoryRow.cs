namespace SourceControl.Services.Dtos;

public class RepositoryRow
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string Type { get; set; }

	public string License { get; set; }

	public string CreatedOn { get; set; }

	public string UserEmail { get; set; }
}
