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
        var user = await Set
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if(user is null)
            return Result<RetrieveUserResponse>.Failure();
        
        return new RetrieveUserResponse(user.Id, user.FirstName, user.LastName, user.Email);
    }
}