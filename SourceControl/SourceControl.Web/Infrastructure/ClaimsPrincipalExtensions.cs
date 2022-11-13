using System.Security.Claims;

namespace SourceControl.Web.Infrastructure;

public static class ClaimsPrincipalExtensions
{
    public static string UserId(this ClaimsPrincipal user)
        => user.FindFirstValue(ClaimTypes.NameIdentifier);
}
