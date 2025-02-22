namespace PersonalOrganizer.Core.Prototypes;

public class TaskItemPrototype
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public DateOnly? DueDate { get; init; }

    public Guid? GroupId { get; init; }
    public Guid[] LabelIds { get; init; } = [];
}
