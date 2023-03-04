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

        CreateMap<Issue, IssueDto>()
			.ForMember(x => x.Status, x => x.MapFrom(y => y.IsOpen ? "Open" : "Closed"))
			.ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn.ToShortDateString()));

		CreateMap<PullRequest, PullRequestDto>();

		CreateMap<RepositoryDto, RepositoryExportModel>()
			.ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn.ToString("MM-dd-yyyy")));
    }
}
