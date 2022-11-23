using Microsoft.AspNetCore.Identity;
using SourceControl.Data.Models.Enumerations;
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

    public PullRequestStatus Status { get; set; } = PullRequestStatus.Open;

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Required]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }
}
