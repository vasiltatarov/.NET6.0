using SourceControl.Models.Dtos;
using SourceControl.Models.Repository;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task<bool> Create(CreateRepositoryViewModel repo, string userId);

	Task Edit(EditRepositoryViewModel editModel, string userId);

	Task Edit(EditRepositoryViewModel editModel);

	Task Delete(int id, string userId);

	bool Delete(int id);

	void ImportRepositories(Stream fileStream);

	Task<RepositoryDto> GetById(int id);

	Task<RepositoryDto> GetByUserId(int repoId, string userId);

	Task<IEnumerable<RepositoryDto>> GetAllByUser(string userId);

	Task<IEnumerable<RepositoryDto>> GetAll(bool publicOnly = true);

	IEnumerable<RepositoryRow> GetAllRows();
}
