namespace SourceControl.Web.Infrastructure;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<CreateRepositoryViewModel, Repository>();

		CreateMap<Repository, RepositoryDto>();

		CreateMap<RepositoryDto, EditRepositoryViewModel>();

		CreateMap<EditRepositoryViewModel, EditRepositoryDto>();
	}
}
