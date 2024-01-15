using Engagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Common;

public abstract class ReadRepositoryBase<T>(DbContext context) where T : Entity
{
    protected readonly IQueryable<T> Set = context.Set<T>().AsNoTracking();
}