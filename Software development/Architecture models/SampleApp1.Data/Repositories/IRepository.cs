using System.Linq.Expressions;

namespace SampleApp1.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        TEntity? Get(Expression<Func<TEntity, bool>> filter);
        TProjection? Get<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection);

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection);
    }
}
