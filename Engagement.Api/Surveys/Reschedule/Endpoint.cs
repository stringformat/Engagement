using Engagement.Application.Features.Surveys.Reschedule;

namespace Engagement.Api.Surveys.Reschedule;

public static class Endpoint
{
    public static WebApplication MapSurveyReschedule(this WebApplication app)
    {
        app.MapPost("api/campaigns/{campaignId:guid}/surveys/{id:guid}/reschedule", async (Guid campaignId, Guid id, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new RescheduleSurveyCommand(campaignId, id, request.SendingDate));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}