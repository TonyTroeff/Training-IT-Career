using Microsoft.AspNetCore.Identity;
using PersonalOrganizer.Core.Authentication.Abstractions;
using PersonalOrganizer.Core.Authentication.Extensions;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.Data.Repositories.Abstractions;
using System.Linq.Expressions;

namespace PersonalOrganizer.Core.Services;

public class TaskGroupService(IRepository<TaskGroup> repository, IAuthenticationContext authContext) : BaseService<TaskGroup, TaskGroupPrototype>(repository), ITaskGroupService
{
    private readonly IAuthenticationContext _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));

    protected override Task ApplyAsync(TaskGroup entity, TaskGroupPrototype prototype, CancellationToken cancellationToken)
    {
        entity.Name = prototype.Name;
        entity.Description = prototype.Description;

        entity.User = this._authContext.GetCurrentUserRequired();

        return Task.CompletedTask;
    }

    protected override IEnumerable<Expression<Func<TaskGroup, bool>>> BuildAdditionalFilters()
    {
        IdentityUser currentUser = this._authContext.GetCurrentUserRequired();
        return [tg => tg.User == currentUser];
    }
}
