namespace SourceControl.Web.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRepositoryViewModel, Repository>();

        CreateMap<Repository, RepositoryDto>();

        CreateMap<RepositoryDto, EditRepositoryViewModel>();

        CreateMap<Repository, RepositoryRow>()
            .ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn.ToShortDateString()));

        CreateMap<Issue, IssueDto>();

        CreateMap<PullRequest, PullRequestDto>();
    }
}
