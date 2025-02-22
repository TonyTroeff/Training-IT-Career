using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonalOrganizer.Data.Models.Abstractions;
using PersonalOrganizer.Data.Repositories.Abstractions;
using PersonalOrganizer.Data.Repositories.Extensions;
using PersonalOrganizer.Data.Sorting.Abstractions;
using System.Linq.Expressions;

namespace PersonalOrganizer.Data.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        this._dbContext.Set<TEntity>().Add(entity);
        await this._dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        this._dbContext.Set<TEntity>().Update(entity);
        await this._dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        this._dbContext.Set<TEntity>().Remove(entity);
        await this._dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<TEntity?> GetAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).FirstOrDefaultAsync(cancellationToken);

    public Task<TProjection?> GetAsync<TProjection>(IEnumerable<Expression<Func<TEntity, bool>>> filters, Expression<Func<TEntity, TProjection>> projection, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).Select(projection).FirstOrDefaultAsync(cancellationToken);

    public Task<TEntity?> GetCompleteAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters, CancellationToken cancellationToken)
    {
        IEntityType? entityType = this._dbContext.Model.FindEntityType(typeof(TEntity));
        if (entityType is null) throw new InvalidOperationException("Invalid entity type.");

        IEnumerable<string> navigations = entityType.GetNavigations().Select(x => x.Name)
            .Concat(entityType.GetSkipNavigations().Select(x => x.Name));

        return this.GetWithNavigationsAsync(filters, navigations, cancellationToken);
    }

    public Task<TEntity?> GetWithNavigationsAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters, IEnumerable<string> navigations, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).Include(navigations).FirstOrDefaultAsync(cancellationToken);

    public Task<TEntity[]> GetManyAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).ToArrayAsync(cancellationToken);

    public Task<TProjection[]> GetManyAsync<TProjection>(IEnumerable<Expression<Func<TEntity, bool>>> filters, Expression<Func<TEntity, TProjection>> projection, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).Select(projection).ToArrayAsync(cancellationToken);

    public Task<TProjection[]> GetManyAsync<TProjection>(IEnumerable<Expression<Func<TEntity, bool>>> filters, Expression<Func<TEntity, TProjection>> projection, IEnumerable<IOrderClause<TEntity>> orderClauses, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).OrderBy(orderClauses).Select(projection).ToArrayAsync(cancellationToken);

    public Task<TEntity[]> GetManyWithNavigationsAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters, IEnumerable<string> navigations, CancellationToken cancellationToken)
        => this._dbContext.Set<TEntity>().Where(filters).Include(navigations).ToArrayAsync(cancellationToken);
}
