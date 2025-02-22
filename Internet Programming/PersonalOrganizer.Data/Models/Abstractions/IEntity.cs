namespace PersonalOrganizer.Data.Models.Abstractions;

public interface IEntity
{
    Guid Id { get; set; }

    DateTime CreatedAt { get; set; }
    DateTime LastModifiedAt { get; set; }

    bool IsDeleted { get; set; }
}
