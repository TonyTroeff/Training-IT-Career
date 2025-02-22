namespace PersonalOrganizer.MVC.Models.TaskGroups;

public class TaskGroupViewModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
