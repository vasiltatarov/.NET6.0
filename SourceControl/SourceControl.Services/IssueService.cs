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
			throw new InvalidOperationException(ex.Message);
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
