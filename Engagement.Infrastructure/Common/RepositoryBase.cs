namespace Engagement.Infrastructure.Common;

public abstract class RepositoryBase<T>(DbContext dbContext) : IRepository<T>
    where T : Entity, IAggregateRoot
{
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }
    
    public async Task<Result<T>> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await dbContext.Set<T>().FindAsync([id], cancellationToken: cancellationToken);

        return result ?? Result<T>.Failure();
    }
    
    public async Task<List<T>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken)
    {
        return await dbContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<bool> Exist(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<T>().AnyAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
}