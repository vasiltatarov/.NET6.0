using AutoMapper;

namespace OFAgency.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//CreateMap<CreateRepositoryViewModel, Repository>();
			//CreateMap<RepositoryDto, RepositoryExportModel>()
			//.ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn.ToString("MM-dd-yyyy")));
		}
	}
}
