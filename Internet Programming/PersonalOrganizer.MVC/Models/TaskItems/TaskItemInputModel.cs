using System.ComponentModel;

namespace PersonalOrganizer.MVC.Models.TaskItems;

public class TaskItemInputModel
{
    public required string Title { get; init; }
    public required string Description { get; init; }

    [DisplayName("Due date")]
    public DateOnly? DueDate { get; init; }

    [DisplayName("Group")]
    public Guid? GroupId { get; init; }

    [DisplayName("Labels")]
    public Guid[] LabelIds { get; init; } = [];
}
