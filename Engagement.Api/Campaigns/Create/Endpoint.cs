namespace Engagement.Api.Campaigns.Create;

public static class Endpoint
{
    public static WebApplication MapCampaignCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns", async (Request request, CreateCampaignCommand command, CancellationToken cancellationToken) =>
        {
            var result = await command.Handle(new CreateCampaignRequest(request.Name, request.Description), cancellationToken);
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}