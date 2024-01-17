using Engagement.Application.Features.Users;

namespace Engagement.Infrastructure.Users;

public class UserRepository(EngagementContext context) : RepositoryBase<User>(context), IUserRepository;