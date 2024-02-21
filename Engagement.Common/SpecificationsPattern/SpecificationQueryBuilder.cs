using Microsoft.EntityFrameworkCore;

namespace Engagement.Common.SpecificationsPattern;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> query, Specification<TEntity> specification) where TEntity : Entity
    {
        query = specification.Includes.Aggregate(query, (current, include) => current.Include(null));

        if (specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);
        
        return query.Where(specification.Criteria);
    }
}