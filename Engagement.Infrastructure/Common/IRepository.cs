namespace Engagement.Infrastructure.Common;

public interface IRepository<T>
    where T : Entity, IAggregateRoot
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    Task<Result<T>> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> Exist(Guid id, CancellationToken cancellationToken);
    Task<List<T>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken);
}