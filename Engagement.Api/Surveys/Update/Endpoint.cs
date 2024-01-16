using Engagement.Application.Features.Surveys.Update;

namespace Engagement.Api.Surveys.Update;

public static class Endpoint
{
    public static WebApplication MapSurveyUpdate(this WebApplication app)
    {
        app.MapPut("api/campaigns/{campaignId:guid}/surveys/{id:guid}", async (Guid campaignId, Guid id, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateSurveyCommand(campaignId, id, request.Name, request.Description));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}