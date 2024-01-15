using Engagement.Application.Features.Campaign.List;
using MediatR;

namespace Engagement.Api.Question.List;

public static class Endpoint
{
    public static WebApplication MapCampaignList(this WebApplication app)
    {
        app.MapGet("api/campaigns", async (IMediator mediator) =>
        {
            var responses = await mediator.Send(new ListCampaignQuery());

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}