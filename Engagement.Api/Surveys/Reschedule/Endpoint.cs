using Engagement.Application.Features.Surveys.Reschedule;

namespace Engagement.Api.Surveys.Reschedule;

public static class Endpoint
{
    public static WebApplication MapSurveyReschedule(this WebApplication app)
    {
        app.MapPost("api/campaigns/{campaignId:guid}/surveys/{id:guid}/reschedule", async (Guid campaignId, Guid id, Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(new RescheduleSurveyCommand(campaignId, id, request.SendingDate));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}