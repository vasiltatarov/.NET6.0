using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models;

public class PullRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(50)]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }

    // Branch From
    // Branch To
}
