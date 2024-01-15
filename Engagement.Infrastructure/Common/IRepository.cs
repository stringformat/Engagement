using Engagement.Common.ResultPattern;
using Engagement.Domain.Common;

namespace Engagement.Infrastructure.Common;

public interface IRepository<T>
    where T : Entity, IAggregateRoot
{
    public Task AddAsync(T entity, CancellationToken cancellationToken);
    public void Update(T entity);
    public Task<Result<T>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> Exist(Guid id, CancellationToken cancellationToken);
}