namespace Travel.Services.Dtos
{
    public class CreateTravelRequestModel
    {
        public string Destination { get; set; }

        public int Participants { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Accommodation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
