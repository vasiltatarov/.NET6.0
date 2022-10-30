namespace Travel.Web.Mappings
{
    using AutoMapper;
    using Travel.Services.Dtos;
    using Travel.Data.Models;
    using Travel.Web.Models.Travels;

    public class TravelProfile : Profile
    {
        public TravelProfile()
        {
            CreateMap<CreateTravelViewModel, CreateTravelRequestModel>();

            CreateMap<CreateTravelRequestModel, TravelEntity>();
        }
    }
}
