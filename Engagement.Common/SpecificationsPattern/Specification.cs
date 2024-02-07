using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Engagement.Common.SpecificationsPattern;

public abstract record Specification<TEntity>
    where TEntity : Entity
{
    public Expression<Func<TEntity, bool>> Criteria { get; protected set; }

    public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> Includes { get; } = [];

    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

    protected void AddIncludes(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
}