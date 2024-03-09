using System.Linq.Expressions;

namespace SampleApp1.Data.Sorting
{
    public interface IOrderClause<TEntity>
    {
        Expression<Func<TEntity, object>> Expression { get; }
        bool IsAscending { get; }
    }
}
