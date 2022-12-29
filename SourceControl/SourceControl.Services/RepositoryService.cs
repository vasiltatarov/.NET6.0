using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SourceControl.Data;
using SourceControl.Data.Models;
using SourceControl.Data.Models.Enumerations;
using SourceControl.Models.Dtos;
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

	public async Task<RepositoryDto> GetById(int id)
	{
		var repo = await this.dbContext.Repositories.FindAsync(id);
		if (repo == null)
		{
			return null;
		}

		return this.mapper.Map<RepositoryDto>(repo);
	}

	public async Task<RepositoryDto> GetByUserId(int repoId, string userId)
	{
		var repo = await this.dbContext.Repositories.FindAsync(repoId);
		if (repo == null)
		{
			return null;
		}

		if (repo.UserId != userId)
		{
			return null;
		}

		return this.mapper.Map<RepositoryDto>(repo);
	}

	public async Task<IEnumerable<RepositoryDto>> GetAllByUser(string userId)
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

	public IEnumerable<RepositoryRow> GetAllRows()
	{
		var repos = this.dbContext
			.Repositories
			.Where(x => !x.IsDeleted)
			.Include(x => x.User)
			.ToList();

		return this.mapper.Map<IEnumerable<RepositoryRow>>(repos);
	}

	public async Task Edit(EditRepositoryDto editModel, string userId)
	{
		var repo = await this.dbContext.Repositories.FindAsync(editModel.Id);
		ArgumentNullException.ThrowIfNull(repo);

		if (repo.UserId != userId)
		{
			throw new InvalidOperationException("Can be edit only by Repository owner!");
		}

		repo.Name = editModel.Name;
		repo.Description = editModel.Description;
		repo.Type = editModel.Type;
		repo.License= editModel.License;

		this.dbContext.Repositories.Update(repo);
		await this.dbContext.SaveChangesAsync();
	}

	public async Task Edit(EditRepositoryDto editModel)
	{
		var repo = await this.dbContext.Repositories.FindAsync(editModel.Id);
		ArgumentNullException.ThrowIfNull(repo);

		repo.Name = editModel.Name;
		repo.Description = editModel.Description;
		repo.Type = editModel.Type;
		repo.License = editModel.License;

		this.dbContext.Repositories.Update(repo);
		await this.dbContext.SaveChangesAsync();
	}

	public async Task Delete(int id, string userId)
	{
		var repo = await this.dbContext.Repositories.FindAsync(id);
		ArgumentNullException.ThrowIfNull(repo);

		if (repo.UserId != userId)
		{
			throw new InvalidOperationException("Can be edit only by Repository owner!");
		}

		repo.IsDeleted = true;
		this.dbContext.Repositories.Update(repo);
		await this.dbContext.SaveChangesAsync();
	}

	public bool Delete(int id)
	{
		var repo = this.dbContext.Repositories.FirstOrDefault(x => x.Id == id);

		if (repo == null)
		{
			return false;
		}

		repo.IsDeleted = true;
		this.dbContext.Repositories.Update(repo);
		this.dbContext.SaveChanges();

		return true;
	}
}
