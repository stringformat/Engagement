using Engagement.Application.Features.Campaigns.Update;

namespace Engagement.Api.Questions.Update;

public static class Endpoint
{
    public static WebApplication MapCampaignUpdate(this WebApplication app)
    {
        app.MapPut("api/campaigns/{id:guid}", async (Guid id, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateCampaignCommand(id, request.Name, request.Description));
            
            return result.IsSuccess 
                ? Results.Ok((object?)Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}