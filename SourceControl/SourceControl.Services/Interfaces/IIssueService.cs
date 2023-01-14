using SourceControl.Models.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IIssueService
{
	Task Create(string title, string comment, int RepositoryId, string UserId);

	Task<IEnumerable<IssueDto>> GetAll(int repositoryId);
}
