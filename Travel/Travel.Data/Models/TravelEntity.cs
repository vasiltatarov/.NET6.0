namespace Travel.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class TravelEntity
    {
        public TravelEntity()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Destination { get; set; }

        [Range(1, 100)]
        public int Participants { get; set; }

        public string Description { get; set; }

        public string Accommodation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
