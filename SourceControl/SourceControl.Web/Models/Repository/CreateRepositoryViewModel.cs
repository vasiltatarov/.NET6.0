using SourceControl.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Web.Models.Repository;

public class CreateRepositoryViewModel
{
    [Required]
    [MaxLength(70)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    public RepositoryType Type { get; set; }

    public LicenseType License { get; set; }
}
