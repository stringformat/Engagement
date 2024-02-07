using Engagement.Application.Features.Surveys.Open;

namespace Engagement.Api.Surveys.Open;

public static class Endpoint
{
    public static WebApplication MapSurveyOpen(this WebApplication app)
    {
        app.MapPost("api/surveys/{id:guid}/open", async (Guid id, OpenSurveyCommand openSurveyCommand, CancellationToken cancellationToken) =>
        {
            var response = await openSurveyCommand.Handle(new OpenSurveyRequest(id), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}