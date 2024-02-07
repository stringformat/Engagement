using Engagement.Application.Features.Users.Create;

namespace Engagement.Api.Users.Create;

public static class Endpoint
{
    public static WebApplication MapUserCreate(this WebApplication app)
    {
        app.MapPost("api/users", async (Request request, CreateUserCommand createUserCommand, CancellationToken cancellationToken) =>
        {
            var response = await createUserCommand.Handle(new CreateUserRequest(request.FirstName, request.LastName, request.Email), cancellationToken);
            
            return response.IsSuccess
                ? Results.Ok(Response.FromCommand(response.Value))
                : response.Error.ToResponse();
        });

        return app;
    }
}