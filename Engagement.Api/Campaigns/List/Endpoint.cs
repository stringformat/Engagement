using Engagement.Application.Features.Campaigns.List;

namespace Engagement.Api.Campaigns.List;

public static class Endpoint
{
    public static WebApplication MapCampaignList(this WebApplication app)
    {
        app.MapGet("api/campaigns", async (ListCampaignQuery query, CancellationToken cancellationToken) =>
        {
            var responses = await query.Handle(cancellationToken);

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}