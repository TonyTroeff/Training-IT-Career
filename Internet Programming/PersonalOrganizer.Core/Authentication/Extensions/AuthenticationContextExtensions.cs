using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Core.Authentication.Abstractions;

namespace PersonalOrganizer.Core.Authentication.Extensions;

public static class AuthenticationContextExtensions
{
    public static IdentityUser GetCurrentUserRequired(this IAuthenticationContext authContext)
    {
        if (!authContext.IsAuthenticated) throw new InvalidOperationException("This action requires an authenticated user.");

        return authContext.CurrentUser;
    }
}
