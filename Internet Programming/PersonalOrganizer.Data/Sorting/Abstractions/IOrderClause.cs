using System.Linq.Expressions;

namespace PersonalOrganizer.Data.Sorting.Abstractions;

public interface IOrderClause<TEntity>
{
    Expression<Func<TEntity, object>> Expression { get; }
    bool IsAscending { get; }
}
