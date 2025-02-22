using Microsoft.AspNetCore.Identity;

namespace PersonalOrganizer.Data.Models.Abstractions;

public interface IUserResource
{
    string UserId { get; set; }
    IdentityUser? User { get; set; }
}
