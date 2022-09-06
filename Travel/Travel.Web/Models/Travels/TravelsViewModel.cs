namespace Travel.Web.Models.Travels
{
    using Travel.Services.Dtos;

    public class TravelsViewModel
    {
        public IEnumerable<TravelDto> Travels { get; set; }
    }
}
