namespace SourceControl.Models.Repository;

using SourceControl.Models.Dtos;

public class RepositoryDetailsPageViewModel
{
    public RepositoryDto Repository { get; set; }

    public IEnumerable<IssueDto> Issues { get; set; }

    public string Tab { get; set; }
}
