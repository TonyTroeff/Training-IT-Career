using PersonalOrganizer.Data.Sorting.Abstractions;
using System.Linq.Expressions;

namespace PersonalOrganizer.Data.Sorting;

public class OrderClause<TEntity> : IOrderClause<TEntity>
{
    public required Expression<Func<TEntity, object>> Expression { get; init; }
    public bool IsAscending { get; init; } = true;
}
