namespace Engagement.Api.Campaigns.Create;

public static class Endpoint
{
    public static WebApplication MapCampaignCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns", async (Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateCampaignCommand(request.Name, request.Description, request.Population));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}