using PersonalOrganizer.Core.Services.Abstractions;
using PersonalOrganizer.Data.Models.Abstractions;
using PersonalOrganizer.Data.Repositories.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace PersonalOrganizer.Core.Services;

public abstract class BaseService<TEntity, TPrototype>(IRepository<TEntity> repository) : IService<TEntity, TPrototype>
    where TEntity : class, IEntity, new ()
    where TPrototype : class
{
    private readonly IRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken)
        => this._repository.GetManyAsync(this.BuildAdditionalFilters(), cancellationToken);

    public Task<TEntity[]> GetAllWithNavigationsAsync(IEnumerable<string> navigations, CancellationToken cancellationToken)
        => this._repository.GetManyWithNavigationsAsync(this.BuildAdditionalFilters(), navigations, cancellationToken);

    public Task<TEntity[]> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        => this._repository.GetManyAsync([e => ids.Contains(e.Id), ..this.BuildAdditionalFilters()], cancellationToken);

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => this._repository.GetAsync([e => e.Id == id, ..this.BuildAdditionalFilters()], cancellationToken);

    public Task<TEntity?> GetByIdCompleteAsync(Guid id, CancellationToken cancellationToken)
        => this._repository.GetCompleteAsync([e => e.Id == id, ..this.BuildAdditionalFilters()], cancellationToken);

    public Task<TEntity?> GetByIdWithNavigationsAsync(Guid id, IEnumerable<string> navigations, CancellationToken cancellationToken)
        => this._repository.GetWithNavigationsAsync([e => e.Id == id, ..this.BuildAdditionalFilters()], navigations, cancellationToken);

    public async Task<TEntity> GetByIdRequiredAsync(Guid id, CancellationToken cancellationToken)
    {
        TEntity? entity = await this._repository.GetAsync([e => e.Id == id, ..this.BuildAdditionalFilters()], cancellationToken);
        EnsureEntityNotNull(entity);

        return entity;
    }

    public async Task<TEntity> CreateAsync(TPrototype prototype, CancellationToken cancellationToken)
    {
        TEntity entity = await this.InitializeAsync(prototype, cancellationToken);
        await this.ApplyAsync(entity, prototype, cancellationToken);

        DateTime currentTime = DateTime.Now;
        entity.CreatedAt = currentTime;
        entity.LastModifiedAt = currentTime;

        await this._repository.CreateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(Guid entityId, TPrototype prototype, CancellationToken cancellationToken)
    {
        TEntity? entity = await this.GetByIdCompleteAsync(entityId, cancellationToken);
        EnsureEntityNotNull(entity);

        await this.ApplyAsync(entity, prototype, cancellationToken);
        entity.LastModifiedAt = DateTime.Now;

        await this._repository.UpdateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task SoftDeleteAsync(Guid entityId, CancellationToken cancellationToken)
    {
        TEntity entity = await this.GetByIdRequiredAsync(entityId, cancellationToken);

        entity.IsDeleted = true;
        entity.LastModifiedAt = DateTime.Now;
        await this._repository.UpdateAsync(entity, cancellationToken);
    }

    public async Task HardDeleteAsync(Guid entityId, CancellationToken cancellationToken)
    {
        TEntity entity = await this.GetByIdRequiredAsync(entityId, cancellationToken);

        await this._repository.DeleteAsync(entity, cancellationToken);
    }

    protected abstract Task ApplyAsync(TEntity entity, TPrototype prototype, CancellationToken cancellationToken);

    protected virtual Task<TEntity> InitializeAsync(TPrototype prototype, CancellationToken cancellationToken) => Task.FromResult(new TEntity());
    protected virtual IEnumerable<Expression<Func<TEntity, bool>>> BuildAdditionalFilters() => [];

    private static void EnsureEntityNotNull([NotNull] TEntity? entity)
    {
        if (entity is null) throw new InvalidOperationException("Entity was not found.");
    }
}
