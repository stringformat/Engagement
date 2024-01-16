using Engagement.Application.Features.Users.Create;

namespace Engagement.Api.Users.Create;

public static class Endpoint
{
    public static WebApplication MapUserCreate(this WebApplication app)
    {
        app.MapPost("api/users", async (Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateUserCommand(request.FirstName, request.LastName, request.Email));
            
            return result.IsSuccess
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}