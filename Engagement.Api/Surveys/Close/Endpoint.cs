using Engagement.Application.Features.Surveys.Close;

namespace Engagement.Api.Surveys.Close;

public static class Endpoint
{
    public static WebApplication MapSurveyClose(this WebApplication app)
    {
        app.MapPost("api/surveys/{id:guid}/close", async (Guid id, CloseSurveyCommand closeSurveyCommand, CancellationToken cancellationToken) =>
        {
            var result = await closeSurveyCommand.Handle(new CloseSurveyRequest(id), cancellationToken);
            
            return result.IsSuccess 
                ? Results.Ok()
                : result.Error.ToResponse();
        });

        return app;
    }
}