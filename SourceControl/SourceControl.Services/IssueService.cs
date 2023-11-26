using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SourceControl.Data.Models;
using SourceControl.Data;
using SourceControl.Models.Dtos;
using SourceControl.Services.Interfaces;

namespace SourceControl.Services;

public class IssueService : IIssueService
{
	private readonly ApplicationDbContext dbContext;
	private readonly IMapper mapper;

	public IssueService(ApplicationDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
	}

	public async Task<bool> Close(int id, int repoId, string userId)
	{
		var repo = await this.dbContext.Repositories.FirstOrDefaultAsync(x => x.Id == repoId);
		if (repo == null || repo.UserId != userId)
		{
			return false;
		}

		var issue = await this.dbContext.Issues.FirstOrDefaultAsync(x => x.Id == id);
		if (issue == null || issue.RepositoryId != repoId)
		{
			return false;
		}

		if (issue.IsOpen == false)
		{
			throw new InvalidOperationException("This issue is already closed!");
		}

		issue.IsOpen = false;
		this.dbContext.Issues.Update(issue);
		await this.dbContext.SaveChangesAsync();

		return true;
	}

	public async Task Create(string title, string comment, int RepositoryId, string UserId)
	{
		try
		{
			var issue = new Issue
			{
				Title = title,
				Comment = comment,
				RepositoryId = RepositoryId,
				UserId = UserId
			};

			await this.dbContext.Issues.AddAsync(issue);
			await this.dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Canot create issue!", ex);
		}
	}

	public async Task<IEnumerable<IssueDto>> GetAll(int repositoryId)
	{
		var issues = await this.dbContext.Issues
			.Include(x => x.User)
			.Where(x => x.RepositoryId == repositoryId && !x.IsDeleted)
			.OrderByDescending(x => x.CreatedOn)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<IssueDto>>(issues);
	}
}
