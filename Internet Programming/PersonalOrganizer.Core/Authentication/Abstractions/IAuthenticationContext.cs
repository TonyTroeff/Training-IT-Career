using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace PersonalOrganizer.Core.Authentication.Abstractions;

public interface IAuthenticationContext
{
    [MemberNotNullWhen(true, nameof(CurrentUser))]
    bool IsAuthenticated { get; }
    
    IdentityUser? CurrentUser { get; }

    void Authenticate(IdentityUser user);
}
