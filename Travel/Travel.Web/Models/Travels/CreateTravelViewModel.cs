namespace Travel.Web.Models.Travels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTravelViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Destination must be minimum 5 characters length!")]
        [MaxLength(100)]
        public string Destination { get; set; }

        [Range(1, 100)]
        public int Participants { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Accommodation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
