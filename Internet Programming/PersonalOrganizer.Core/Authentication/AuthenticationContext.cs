using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Core.Authentication.Abstractions;

namespace PersonalOrganizer.Core.Authentication;

public class AuthenticationContext : IAuthenticationContext
{
    public bool IsAuthenticated => this.CurrentUser != null;
    public IdentityUser? CurrentUser { get; private set; }

    public void Authenticate(IdentityUser user)
    {
        ArgumentNullException.ThrowIfNull(user);
        this.CurrentUser = user;
    }
}
