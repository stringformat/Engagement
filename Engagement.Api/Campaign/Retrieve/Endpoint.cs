using Engagement.Application.Features.Campaign.Retrieve;
using MediatR;

namespace Engagement.Api.Campaign.Retrieve;

public static class Endpoint
{
    public static WebApplication MapCampaignRetrieve(this WebApplication app)
    {
        app.MapGet("api/campaigns/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveCampaignQuery(id));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromQuery(response)) 
                : Results.BadRequest();
        });

        return app;
    }
}