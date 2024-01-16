using Engagement.Application.Features.Campaigns.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public static class Endpoint
{
    public static WebApplication MapCampaignRetrieve(this WebApplication app)
    {
        app.MapGet("api/campaigns/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveCampaignQuery(id));
            
            return response.IsSuccess 
                ? Results.Ok((object?)Response.FromQuery(response)) 
                : Results.BadRequest();
        });

        return app;
    }
}