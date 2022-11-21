using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SourceControl.Data.Models;

namespace SourceControl.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Repository> Repositories { get; set; }

    public DbSet<Commit> Commits { get; set; }

    public DbSet<Issue> Issues { get; set; }

    public DbSet<PullRequest> PullRequests { get; set; }
}