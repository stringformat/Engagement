using Engagement.Application.Features.Users.List;

namespace Engagement.Api.Users.List;

public record Response(Guid Id, string FirstName, string LastName, string Email)
{
    public static Response FromQuery(ListUserResponse response) =>
        new(response.Id, response.FirstName, response.LastName, response.Email);
}