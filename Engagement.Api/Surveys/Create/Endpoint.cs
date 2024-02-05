using Engagement.Application.Features.Surveys.Create;

namespace Engagement.Api.Surveys.Create;

public static class Endpoint
{
    public static WebApplication MapSurveyCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns/{id:guid}/surveys", async (Guid id, Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(new CreateSurveyCommand(id, request.Name, request.Description, request.SendingDate));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}