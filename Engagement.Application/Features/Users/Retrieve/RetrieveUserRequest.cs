namespace Engagement.Application.Features.Users.Retrieve;

public record RetrieveUserRequest(Guid Id) : IRequest;