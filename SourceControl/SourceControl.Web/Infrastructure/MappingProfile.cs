using SourceControl.Services.Dtos;

namespace SourceControl.Web.Infrastructure;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<HomeDto, HomeViewModel>();
	}
}
