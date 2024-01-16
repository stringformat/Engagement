namespace Engagement.Application.Features.Users;

public interface IUserReadRepository
{
    Task<List<ListUserResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveUserResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}