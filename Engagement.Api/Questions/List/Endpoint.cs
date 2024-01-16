using Engagement.Application.Features.Campaigns.List;

namespace Engagement.Api.Questions.List;

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