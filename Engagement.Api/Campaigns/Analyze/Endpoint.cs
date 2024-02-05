using Engagement.Application.Features.Campaigns.Analyze;

namespace Engagement.Api.Campaigns.Analyze;

public static class Endpoint
{
    public static WebApplication MapCampaignCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns/{id:guid}/analyze", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new AnalyzeCampaignQuery(id));
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}