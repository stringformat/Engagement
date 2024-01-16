using Engagement.Application.Features.Users.Retrieve;

namespace Engagement.Api.Users.Retrieve;

public record Response(Guid Id, string FirstName, string LastName, string Email)
{
    public static Response FromQuery(RetrieveUserResponse response) =>
        new(response.Id, response.FirstName, response.LastName, response.Email);
}