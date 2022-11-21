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

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int RepositoryId { get; set; }

    public virtual Repository Repository { get; set; }

    // Status - Open/Closed
    // approvals
    // contributors
}
