using SourceControl.Data.Models;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);
}
