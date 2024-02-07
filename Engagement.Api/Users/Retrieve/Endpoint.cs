using Engagement.Application.Features.Users.Retrieve;

namespace Engagement.Api.Users.Retrieve;

public static class Endpoint
{
    public static WebApplication MapUserRetrieve(this WebApplication app)
    {
        app.MapGet("api/users/{id:guid}", async (Guid id, RetrieveUserQuery retrieveUserQuery, CancellationToken cancellationToken) =>
        {
            var response = await retrieveUserQuery.Handle(new RetrieveUserRequest(id), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromQuery(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}