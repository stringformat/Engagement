using MediatR;

namespace Engagement.Application.Features.Users.Retrieve;

public record RetrieveUserQuery(Guid Id) : IRequest<Result<RetrieveUserResponse>>;