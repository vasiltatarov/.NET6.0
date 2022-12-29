using SourceControl.Data.Models;
using SourceControl.Models.Dtos;
using SourceControl.Models.Repository;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);

	Task Edit(EditRepositoryViewModel editModel, string userId);

	Task Edit(EditRepositoryViewModel editModel);

	Task Delete(int id, string userId);

	bool Delete(int id);

	Task<RepositoryDto> GetById(int id);

	Task<RepositoryDto> GetByUserId(int repoId, string userId);

	Task<IEnumerable<RepositoryDto>> GetAllByUser(string userId);

	Task<IEnumerable<RepositoryDto>> GetAllPublic();

    IEnumerable<RepositoryRow> GetAllRows();
}
