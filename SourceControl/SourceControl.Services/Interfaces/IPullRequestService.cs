using SourceControl.Models.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IPullRequestService
{
	Task Create(string title, string description, int RepositoryId, string UserId);

	Task<IEnumerable<PullRequestDto>> GetAll(int repositoryId);
}
