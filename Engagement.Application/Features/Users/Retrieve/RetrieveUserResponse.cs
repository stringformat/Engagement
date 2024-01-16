namespace Engagement.Application.Features.Users.Retrieve;

public record RetrieveUserResponse(Guid Id, string FirstName, string LastName, string Email);