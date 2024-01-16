using Engagement.Application.Features.Users.Retrieve;

namespace Engagement.Api.Users.Retrieve;

public static class Endpoint
{
    public static WebApplication MapUserRetrieve(this WebApplication app)
    {
        app.MapGet("api/users/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveUserQuery(id));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromQuery(response)) 
                : Results.BadRequest();
        });

        return app;
    }
}