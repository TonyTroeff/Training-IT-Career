using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Data.Models;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
    
    public bool IsDeleted { get; set; }
}
