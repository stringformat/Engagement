using Engagement.Application.Features.Surveys.Create;

namespace Engagement.Api.Surveys.Create;

public static class Endpoint
{
    public static WebApplication MapSurveyCreate(this WebApplication app)
    {
        app.MapPost("api/campaigns/{id:guid}/surveys", async (Guid id, Request request, CreateSurveyCommand createSurveyCommand, CancellationToken cancellationToken) =>
        {
            var response = await createSurveyCommand.Handle(new CreateSurveyRequest(id, request.Name, request.Description, request.SendingDate), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}