using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Core.Authentication.Abstractions;

namespace PersonalOrganizer.MVC.Middlewares;

public class AuthenticationContextSetupMiddleware(RequestDelegate next)
{
    private RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task InvokeAsync(HttpContext httpContext)
    {
        UserManager<IdentityUser> userManager = httpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
        IdentityUser? user = await userManager.GetUserAsync(httpContext.User);

        if (user is not null)
        {
            IAuthenticationContext authContext = httpContext.RequestServices.GetRequiredService<IAuthenticationContext>();
            authContext.Authenticate(user);
        }

        await this._next(httpContext);
    }
}
