using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Core.Services.Abstractions;

public interface ICreateService<TEntity, TPrototype>
    where TEntity : class, IEntity
    where TPrototype : class
{
    Task<TEntity> CreateAsync(TPrototype prototype, CancellationToken cancellationToken);
}
