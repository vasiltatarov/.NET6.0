namespace Travel.Services.Dtos
{
    public class TravelDto
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public int Participants { get; set; }

        public string Description { get; set; }

        public string Accommodation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string UserId { get; set; }
    }
}
