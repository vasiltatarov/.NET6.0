namespace SourceControl.Web.Infrastructure;

using SourceControl.Models.Dtos;
using SourceControl.Models.Repository;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRepositoryViewModel, Repository>();

        CreateMap<Repository, RepositoryDto>();

        CreateMap<RepositoryDto, EditRepositoryViewModel>();

        CreateMap<EditRepositoryViewModel, EditRepositoryDto>();

        CreateMap<Repository, RepositoryRow>()
            .ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn.ToShortDateString()));
    }
}
