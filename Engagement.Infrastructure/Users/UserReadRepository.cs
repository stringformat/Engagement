using Engagement.Application.Features.Users;
using Engagement.Application.Features.Users.List;
using Engagement.Application.Features.Users.Retrieve;

namespace Engagement.Infrastructure.Users;

public class UserReadRepository(EngagementContext context) : ReadRepositoryBase<User>(context), IUserReadRepository
{
    public Task<List<ListUserResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListUserResponse(x.Id, x.FirstName, x.LastName, x.Email))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveUserResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
            .Select(x => new RetrieveUserResponse(x.Id, x.FirstName, x.LastName, x.Email))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveUserResponse>.Failure();
    }
}