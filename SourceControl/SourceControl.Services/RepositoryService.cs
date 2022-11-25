using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SourceControl.Data;
using SourceControl.Data.Models;
using SourceControl.Data.Models.Enumerations;
using SourceControl.Services.Dtos;
using SourceControl.Services.Interfaces;

namespace SourceControl.Services;

public class RepositoryService : IRepositoryService
{
	private readonly ApplicationDbContext dbContext;
	private readonly IMapper mapper;

	public RepositoryService(ApplicationDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
	}

	public async Task Create(Repository repo)
	{
		await this.dbContext.AddAsync(repo);
		await this.dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<RepositoryDto>> GetAll(string userId)
	{
		var repos = await this.dbContext.Repositories
			.Where(x => x.UserId == userId && !x.IsDeleted)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<RepositoryDto>>(repos);
	}

	public async Task<IEnumerable<RepositoryDto>> GetAllPublic()
	{
		var repos = await this.dbContext.Repositories
			.Include(x => x.User)
			.Where(x => x.Type == RepositoryType.Public && !x.IsDeleted)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<RepositoryDto>>(repos);
	}
}
