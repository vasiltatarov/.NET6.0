using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models;

public class Issue
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public string Comment { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsOpen { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }

    [Required]
    [MaxLength(50)]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }
}
