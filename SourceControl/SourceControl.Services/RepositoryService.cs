using SourceControl.Data;
using SourceControl.Data.Models;
using SourceControl.Services.Interfaces;

namespace SourceControl.Services;

public class RepositoryService : IRepositoryService
{
	private readonly ApplicationDbContext dbContext;

	public RepositoryService(ApplicationDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task Create(Repository repo)
	{
		await this.dbContext.AddAsync(repo);
		await this.dbContext.SaveChangesAsync();
	}
}
