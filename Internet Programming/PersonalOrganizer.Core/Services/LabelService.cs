using PersonalOrganizer.Core.Authentication.Abstractions;
using PersonalOrganizer.Core.Authentication.Extensions;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.Data.Repositories.Abstractions;

namespace PersonalOrganizer.Core.Services;

public class LabelService(IRepository<Label> repository, IAuthenticationContext authContext) : BaseService<Label, LabelPrototype>(repository), ILabelService
{
    private readonly IAuthenticationContext _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));

    protected override Task ApplyAsync(Label entity, LabelPrototype prototype, CancellationToken cancellationToken)
    {
        entity.Name = prototype.Name;

        entity.User = this._authContext.GetCurrentUserRequired();

        return Task.CompletedTask;
    }
}
