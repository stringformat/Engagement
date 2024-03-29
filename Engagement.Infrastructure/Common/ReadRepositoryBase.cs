using Engagement.Common;

namespace Engagement.Infrastructure.Common;

public abstract class ReadRepositoryBase<T>(DbContext context) where T : Entity
{
    protected readonly IQueryable<T> Set = context.Set<T>().AsNoTracking();
}