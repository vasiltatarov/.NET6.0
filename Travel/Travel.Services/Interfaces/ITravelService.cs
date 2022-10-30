namespace Travel.Services.Interfaces
{
    using Travel.Services.Dtos;

    public interface ITravelService
    {
        Task<IEnumerable<TravelDto>> GetTravelsAsync();

        Task Create(CreateTravelRequestModel travelDto);
    }
}
