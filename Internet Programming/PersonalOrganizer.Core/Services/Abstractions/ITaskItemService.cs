using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Data.Models;

namespace PersonalOrganizer.Core.Services.Abstractions;

public interface ITaskItemService : IService<TaskItem, TaskItemPrototype>
{
}
