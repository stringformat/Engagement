namespace Engagement.Application.Features.Users.List;

public record ListUserResponse(Guid Id, string FirstName, string LastName, string Email);