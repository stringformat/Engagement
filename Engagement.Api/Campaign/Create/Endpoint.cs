using Engagement.Application.Features.Campaign.Create;
using MediatR;

namespace Engagement.Api.Campaign.Create;

public static class Endpoint
{
    public static WebApplication MapCampaignCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns", async (Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateCampaignCommand(request.Name, request.Description));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}