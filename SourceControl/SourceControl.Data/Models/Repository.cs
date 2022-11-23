using Microsoft.AspNetCore.Identity;
using SourceControl.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models;

public class Repository
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(70)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    public RepositoryType Type { get; set; }

    public LicenseType License { get; set; }

    public string Source { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Required]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    public virtual IEnumerable<Commit> Commits { get; set; }

    public virtual IEnumerable<Issue> Issues { get; set; }

    public virtual IEnumerable<PullRequest> PullRequests { get; set; }

    public virtual IEnumerable<Reviewer> Reviewers { get; set; }
}
