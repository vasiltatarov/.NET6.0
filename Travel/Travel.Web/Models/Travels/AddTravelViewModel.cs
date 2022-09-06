namespace Travel.Web.Models.Travels
{
    using System.ComponentModel.DataAnnotations;

    public class AddTravelViewModel
    {
        [Required]
        public string Destination { get; set; }

        [Range(1, 100)]
        public int Participants { get; set; }
    }
}
