using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SourceControl.Data;
using SourceControl.Data.Models;
using SourceControl.Models.Dtos;
using SourceControl.Services.Interfaces;

namespace SourceControl.Services;

public class PullRequestService : IPullRequestService
{
	private readonly ApplicationDbContext dbContext;
	private readonly IMapper mapper;

	public PullRequestService(ApplicationDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
	}

	public async Task Create(string title, string description, int RepositoryId, string UserId)
	{
		try
		{
			var pr = new PullRequest
			{
				Title = title,
				Description = description,
				RepositoryId = RepositoryId,
				UserId = UserId
			};

			await this.dbContext.PullRequests.AddAsync(pr);
			await this.dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Canot create pull request!", ex);
		}
	}

	public async Task<IEnumerable<PullRequestDto>> GetAll(int repositoryId)
	{
		var prs = await this.dbContext.PullRequests
			.Include(x => x.User)
			.Where(x => x.RepositoryId== repositoryId && !x.IsDeleted)
			.OrderByDescending(x => x.CreatedOn)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<PullRequestDto>>(prs);
	}
}
