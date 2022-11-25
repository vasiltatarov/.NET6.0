namespace SourceControl.Web.Infrastructure;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<HomeDto, HomeViewModel>();
		CreateMap<CreateRepositoryViewModel, Repository>();
	}
}
