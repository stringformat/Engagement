using Engagement.Application.Features.Users.List;

namespace Engagement.Api.Users.List;

public static class Endpoint
{
    public static WebApplication MapUserList(this WebApplication app)
    {
        app.MapGet("api/users", async (IMediator mediator) =>
        {
            var responses = await mediator.Send(new ListUserQuery());
            
            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}