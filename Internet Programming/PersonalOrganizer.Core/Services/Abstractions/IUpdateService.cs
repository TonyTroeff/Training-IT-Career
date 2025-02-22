using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Core.Services.Abstractions;

public interface IUpdateService<TEntity, TPrototype>
    where TEntity : class, IEntity
    where TPrototype : class
{
    Task<TEntity> UpdateAsync(Guid entityId, TPrototype prototype, CancellationToken cancellationToken);
}
