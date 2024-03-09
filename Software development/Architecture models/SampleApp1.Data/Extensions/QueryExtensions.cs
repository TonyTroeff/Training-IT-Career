using SampleApp1.Data.Sorting;

namespace SampleApp1.Data.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, IEnumerable<IOrderClause<TEntity>> orderClauses)
        {
            IOrderedQueryable<TEntity>? orderedQuery = null;
            foreach (var clause in orderClauses)
            {
                if (clause.IsAscending)
                {
                    if (orderedQuery is null) 
                        orderedQuery = query.OrderBy(clause.Expression);
                    else
                        orderedQuery = orderedQuery.ThenBy(clause.Expression);
                }
                else
                {
                    if (orderedQuery is null)
                        orderedQuery = query.OrderByDescending(clause.Expression);
                    else
                        orderedQuery = orderedQuery.ThenByDescending(clause.Expression);
                }
            }

            return orderedQuery ?? query;
        }
    }
}
