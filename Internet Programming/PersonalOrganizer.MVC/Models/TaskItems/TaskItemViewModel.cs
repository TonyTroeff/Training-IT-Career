using PersonalOrganizer.MVC.Models.Labels;
using PersonalOrganizer.MVC.Models.TaskGroups;
using System.ComponentModel;

namespace PersonalOrganizer.MVC.Models.TaskItems;

public class TaskItemViewModel
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }

    [DisplayName("Due date")]
    public DateOnly? DueDate { get; init; }

    public TaskGroupViewModel? Group { get; init; }
    public LabelViewModel[] Labels { get; init; } = [];
}
