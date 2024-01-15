using Engagement.Application.Features.Campaign.List;
using MediatR;

namespace Engagement.Api.Survey.List;

public static class Endpoint
{
    public static WebApplication MapSurveyList(this WebApplication app)
    {
        app.MapGet("api/campaigns/{id:guid}/surveys", async (Guid id, IMediator mediator) =>
        {
            var responses = await mediator.Send(new ListCampaignQuery());

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}