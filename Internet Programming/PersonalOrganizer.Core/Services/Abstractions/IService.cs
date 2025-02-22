using PersonalOrganizer.Data.Models.Abstractions;

namespace PersonalOrganizer.Core.Services.Abstractions;

public interface IService<TEntity, TPrototype> : ICreateService<TEntity, TPrototype>, IReadService<TEntity>, IUpdateService<TEntity, TPrototype>, IDeleteService
    where TEntity : class, IEntity
    where TPrototype : class
{
}
