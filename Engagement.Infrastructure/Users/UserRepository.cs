using Engagement.Application.Features.Users;
using Engagement.Domain.UserAggregate;

namespace Engagement.Infrastructure.Users;

public class UserRepository(DbContext context) : RepositoryBase<User>(context), IUserRepository;