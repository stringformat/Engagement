using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.User;

public interface IUserRepository
{
    Task AddAsync(Domain.UserAggregate.User entity, CancellationToken cancellationToken);
    void Update(Domain.UserAggregate.User entity);
    Task<Result<Domain.UserAggregate.User>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result> Exist(Guid id, CancellationToken cancellationToken);
}