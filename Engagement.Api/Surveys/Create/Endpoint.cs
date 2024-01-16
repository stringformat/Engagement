using Engagement.Application.Features.Surveys.Create;

namespace Engagement.Api.Surveys.Create;

public static class Endpoint
{
    public static WebApplication MapSurveyCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns/{id:guid}/surveys", async (Guid id, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateSurveyCommand(id, request.Name, request.Description, request.SendingDate));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}