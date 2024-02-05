using Engagement.Application.Features.Surveys.Open;

namespace Engagement.Api.Surveys.Open;

public static class Endpoint
{
    public static WebApplication MapSurveyOpen(this WebApplication app)
    {
        app.MapPost("api/campaigns/{campaignId:guid}/surveys/{id:guid}/open", async (Guid campaignId, Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new OpenSurveyCommand(campaignId, id));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}