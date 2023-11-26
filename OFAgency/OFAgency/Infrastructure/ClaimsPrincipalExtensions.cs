using System.Security.Claims;

namespace OFAgency.Infrastructure
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetUserId(this ClaimsPrincipal user)
			=> user.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
