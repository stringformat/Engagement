using MediatR;

namespace Engagement.Application.Features.Users.Create;

public record CreateUserCommand(string FirstName, string LastName, string Email) : IRequest<Result<Guid>>;