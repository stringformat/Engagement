using Engagement.Application.Features.Surveys.Open;

namespace Engagement.Api.Surveys.Open;

public static class Endpoint
{
    public static WebApplication MapSurveyOpen(this WebApplication app)
    {
        app.MapPost("api/campaigns/{campaignId:guid}/surveys/{id:guid}/open", async (Guid campaignId, Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new OpenSurveyCommand(campaignId, id));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}