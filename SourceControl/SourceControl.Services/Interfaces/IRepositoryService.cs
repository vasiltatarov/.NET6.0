using SourceControl.Data.Models;
using SourceControl.Models.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);

	Task Edit(EditRepositoryDto editModel, string userId);

	Task Edit(EditRepositoryDto editModel);

	Task Delete(int id, string userId);

	bool Delete(int id);

	Task<RepositoryDto> GetById(int id);

	Task<RepositoryDto> GetByUserId(int repoId, string userId);

	Task<IEnumerable<RepositoryDto>> GetAllByUser(string userId);

	Task<IEnumerable<RepositoryDto>> GetAllPublic();

    IEnumerable<RepositoryRow> GetAllRows();
}
