using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Data.Models;

public class Label : BaseEntity, IUserResource
{
    public string Name { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public IdentityUser? User { get; set; }

    public List<TaskItem> Tasks { get; } = [];
}
