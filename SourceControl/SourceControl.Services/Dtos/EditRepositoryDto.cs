using SourceControl.Data.Models.Enumerations;

namespace SourceControl.Services.Dtos;

public class EditRepositoryDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public RepositoryType Type { get; set; }

	public LicenseType License { get; set; }
}
