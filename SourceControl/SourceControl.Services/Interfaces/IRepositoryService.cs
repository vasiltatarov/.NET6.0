using SourceControl.Data.Models;
using SourceControl.Services.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);

	Task<IEnumerable<RepositoryDto>> GetAll(string userId);

	Task<IEnumerable<RepositoryDto>> GetAllPublic();
}
