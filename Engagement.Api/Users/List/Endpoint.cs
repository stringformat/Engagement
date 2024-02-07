using Engagement.Application.Features.Users.List;

namespace Engagement.Api.Users.List;

public static class Endpoint
{
    public static WebApplication MapUserList(this WebApplication app)
    {
        app.MapGet("api/users", async (ListUserQuery listUserQuery, CancellationToken cancellationToken) =>
        {
            var responses = await listUserQuery.Handle(cancellationToken);
            
            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}