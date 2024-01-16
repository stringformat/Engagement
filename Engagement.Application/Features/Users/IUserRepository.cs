namespace Engagement.Application.Features.Users;

public interface IUserRepository
{
    Task AddAsync(User entity, CancellationToken cancellationToken);
    Task<Result<User>> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<List<User>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken);
}