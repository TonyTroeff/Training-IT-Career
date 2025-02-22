using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Core.Services.Abstractions;

public interface IReadService<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity[]> GetAllWithNavigationsAsync(IEnumerable<string> navigations, CancellationToken cancellationToken);

    Task<TEntity[]> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdCompleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdWithNavigationsAsync(Guid id, IEnumerable<string> navigations, CancellationToken cancellationToken);

    Task<TEntity> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken);
}
