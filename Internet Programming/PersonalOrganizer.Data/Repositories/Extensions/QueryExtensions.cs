using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Data.Repositories.Extensions;
using PersonalOrganizer.Data.Sorting.Abstractions;
using System.Linq.Expressions;

namespace PersonalOrganizer.Data.Repositories.Extensions;

public static class QueryExtensions
{
    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query, IEnumerable<Expression<Func<TEntity, bool>>> filters)
    {
        foreach (Expression<Func<TEntity, bool>> clause in filters)
            query = query.Where(clause);

        return query;
    }

    public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> query, IEnumerable<string> navigations)
        where TEntity : class
    {
        foreach (string navigation in navigations)
            query = query.Include(navigation);

        return query;
    }

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
