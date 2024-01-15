using Engagement.Application.Features.Survey.Close;
using MediatR;

namespace Engagement.Api.Survey.Close;

public static class Endpoint
{
    public static WebApplication MapSurveyClose(this WebApplication app)
    {
        app.MapPost("api/surveys/{id:guid}/close", async (Guid campaignId, Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new CloseSurveyCommand(id));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}