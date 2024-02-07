using Engagement.Application.Features.Campaigns.Update;

namespace Engagement.Api.Campaigns.Update;

public static class Endpoint
{
    public static WebApplication MapCampaignUpdate(this WebApplication app)
    {
        app.MapPut("api/campaigns/{id:guid}", async (Guid id, Request request, UpdateCampaignCommand command, CancellationToken cancellationToken) =>
        {
            var result = await command.Handle(new UpdateCampaignRequest(id, request.Name, request.Description),
                cancellationToken);
            
            return result.IsSuccess 
                ? Results.Ok()
                : Results.BadRequest();
        });

        return app;
    }
}