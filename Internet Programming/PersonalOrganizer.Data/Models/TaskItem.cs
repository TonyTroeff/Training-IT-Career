using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Data.Models;

public class TaskItem : BaseEntity, IUserResource
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateOnly? DueDate { get; set; }

    public string UserId { get; set; } = string.Empty;
    public IdentityUser? User { get; set; }

    public Guid? GroupId { get; set; }
    public TaskGroup? Group { get; set; }

    public List<Label> Labels { get; } = [];
}
