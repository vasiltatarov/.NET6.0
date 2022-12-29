namespace SourceControl.Models.Home;

using SourceControl.Models.Dtos;

public class HomeViewModel
{
    public IEnumerable<RepositoryDto> Repositories { get; set; }
}
