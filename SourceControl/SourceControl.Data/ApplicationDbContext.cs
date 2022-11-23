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

    public DbSet<Reviewer> Reviewers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Commit>()
            .HasOne(x => x.Repository)
            .WithMany(x => x.Commits)
            .HasForeignKey(x => x.RepositoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.Entity<Issue>()
            .HasOne(x => x.Repository)
            .WithMany(x => x.Issues)
          .HasForeignKey(x => x.RepositoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PullRequest>()
            .HasOne(x => x.Repository)
            .WithMany(x => x.PullRequests)
            .HasForeignKey(x => x.RepositoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reviewer>()
            .HasOne(x => x.Repository)
            .WithMany(x => x.Reviewers)
            .HasForeignKey(x => x.RepositoryId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(builder);
    }
}