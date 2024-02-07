using Engagement.Application.Features.Surveys.Retrieve;

namespace Engagement.Api.Surveys.Retrieve;

public static class Endpoint
{
    public static WebApplication MapSurveyRetrieve(this WebApplication app)
    {
        app.MapGet("api/surveys/{id:guid}", async (Guid id, RetrieveSurveyQuery retrieveSurveyQuery, CancellationToken cancellationToken) =>
        {
            var response = await retrieveSurveyQuery.Handle(new RetrieveSurveyRequest(id), cancellationToken);
            
            return response.IsSuccess
                ? Results.Ok((object?)Response.FromQuery(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}