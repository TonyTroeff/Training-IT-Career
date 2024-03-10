using SampleApp1.Data.Sorting;
using System.Linq.Expressions;

namespace SampleApp1.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity? Get(Expression<Func<TEntity, bool>> filter);
        TProjection? Get<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection);

        TEntity? GetComplete(Expression<Func<TEntity, bool>> filter);
        TEntity? GetWithNavigations(Expression<Func<TEntity, bool>> filter, IEnumerable<string> navigations);

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection);
        IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection, IEnumerable<IOrderClause<TEntity>> orderClauses);
    }
}
