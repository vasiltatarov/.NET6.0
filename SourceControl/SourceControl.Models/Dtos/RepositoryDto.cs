using SourceControl.Data.Models.Enumerations;

namespace SourceControl.Models.Dtos;

public class RepositoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Source { get; set; }

    public RepositoryType Type { get; set; }

    public LicenseType License { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UserEmail { get; set; }

    public string UserId { get; set; }
}
