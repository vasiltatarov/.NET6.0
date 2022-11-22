using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models;

public class Commit
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Message { get; set; }

    [Required]
    public string Changes { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(50)]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }
}
