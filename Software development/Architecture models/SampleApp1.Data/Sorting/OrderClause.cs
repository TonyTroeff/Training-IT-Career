using System.Linq.Expressions;

namespace SampleApp1.Data.Sorting
{
    public record OrderClause<TEntity> : IOrderClause<TEntity>
    {
        public required Expression<Func<TEntity, object>> Expression { get; init; }
        public bool IsAscending { get; init; } = true;
    }
}
