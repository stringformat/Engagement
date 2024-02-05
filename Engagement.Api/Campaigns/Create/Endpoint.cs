namespace Engagement.Api.Campaigns.Create;

public static class Endpoint
{
    public static WebApplication MapCampaignCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns", async (Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(new CreateCampaignCommand(request.Name, request.Description));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}