using SourceControl.Data.Models;
using SourceControl.Services.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);

	Task Edit(EditRepositoryDto editModel, string userId);

	Task Delete(int id, string userId);

	Task<RepositoryDto> GetById(int id);

	Task<RepositoryDto> GetByUserId(int repoId, string userId);

	Task<IEnumerable<RepositoryDto>> GetAllByUser(string userId);

	Task<IEnumerable<RepositoryDto>> GetAllPublic();
}
