namespace SourceControl.Web.Models.Repository;

public class EditRepositoryViewModel
{
	public int Id { get; set; }

	[Required]
	[MaxLength(70)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string Description { get; set; }

	public RepositoryType Type { get; set; }

	public LicenseType License { get; set; }
}
