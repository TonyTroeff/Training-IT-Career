namespace PersonalOrganizer.Core.Services.Abstractions;

public interface IDeleteService
{
    Task SoftDeleteAsync(Guid entityId, CancellationToken cancellationToken);
    Task HardDeleteAsync(Guid entityId, CancellationToken cancellationToken);
}
