using SourceControl.Data.Models.Enumerations;

namespace SourceControl.Services.Dtos;

public class RepositoryDto
{
	public string Name { get; set; }

	public string Description { get; set; }

	public RepositoryType Type { get; set; }

	public LicenseType License { get; set; }

	public DateTime CreatedOn { get; set; }

	public string UserEmail { get; set; }
}
