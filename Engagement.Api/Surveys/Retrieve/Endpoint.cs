using Engagement.Application.Features.Surveys.Retrieve;

namespace Engagement.Api.Surveys.Retrieve;

public static class Endpoint
{
    public static WebApplication MapSurveyRetrieve(this WebApplication app)
    {
        app.MapGet("api/campaigns/{campaignId:guid}/surveys/{id:guid}", async (Guid campaignId, Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveSurveyQuery(campaignId, id));
            
            return response.IsSuccess
                ? Results.Ok((object?)Response.FromQuery(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}