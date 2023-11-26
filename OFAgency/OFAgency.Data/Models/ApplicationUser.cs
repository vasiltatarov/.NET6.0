using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace OFAgency.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Url]
		public string ImageUrl { get; set; }

		public int CountryId { get; set; }

		public string Country { get; set; }

		public string Role { get; set; } // Client, Model

		public string Status { get; set; } // None, Approved, Declined
	}
}
