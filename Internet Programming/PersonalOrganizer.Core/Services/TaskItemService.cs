using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Core.Authentication.Abstractions;
using PersonalOrganizer.Core.Authentication.Extensions;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.Data.Repositories.Abstractions;
using System.Linq.Expressions;

namespace PersonalOrganizer.Core.Services;

public class TaskItemService(IRepository<TaskItem> repository, ITaskGroupService taskGroupService, ILabelService labelService, IAuthenticationContext authContext) : BaseService<TaskItem, TaskItemPrototype>(repository), ITaskItemService
{
    private readonly ITaskGroupService _taskGroupService = taskGroupService ?? throw new ArgumentNullException(nameof(taskGroupService));
    private readonly ILabelService _labelService = labelService ?? throw new ArgumentNullException(nameof(labelService));
    private readonly IAuthenticationContext _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));

    protected override async Task ApplyAsync(TaskItem entity, TaskItemPrototype prototype, CancellationToken cancellationToken)
    {
        entity.Title = prototype.Title;
        entity.Description = prototype.Description;
        entity.DueDate = prototype.DueDate;

        entity.User = this._authContext.GetCurrentUserRequired();

        if (prototype.GroupId.HasValue)
        {
            TaskGroup group = await this._taskGroupService.GetByIdRequiredAsync(prototype.GroupId.Value, cancellationToken);

            entity.GroupId = group.Id;
            entity.Group = group;
        }
        else
        {
            entity.GroupId = null;
            entity.Group = null;
        }

        Label[] labels = await this._labelService.GetByIdsAsync(prototype.LabelIds, cancellationToken);
        
        entity.Labels.Clear();
        entity.Labels.AddRange(labels);
    }

    protected override IEnumerable<Expression<Func<TaskItem, bool>>> BuildAdditionalFilters()
    {
        IdentityUser currentUser = this._authContext.GetCurrentUserRequired();
        return [ti => ti.User == currentUser];
    }
}
