using Engagement.Application.Features.Survey.Retrieve;
using MediatR;

namespace Engagement.Api.Survey.Retrieve;

public static class Endpoint
{
    public static WebApplication MapSurveyRetrieve(this WebApplication app)
    {
        app.MapGet("api/campaigns/{campaignId:guid}/surveys/{id:guid}", async (Guid campaignId, Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveSurveyQuery(campaignId, id));
            
            return response.IsSuccess
                ? Results.Ok((object?)Response.FromQuery(response)) 
                : Results.BadRequest();
        });

        return app;
    }
}