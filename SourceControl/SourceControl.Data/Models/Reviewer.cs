using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models;

public class Reviewer
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Required]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }
}
