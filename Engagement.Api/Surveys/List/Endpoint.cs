using Engagement.Application.Features.Surveys.List;

namespace Engagement.Api.Surveys.List;

public static class Endpoint
{
    public static WebApplication MapSurveyList(this WebApplication app)
    {
        app.MapGet("api/surveys", async (ListSurveyQuery listSurveyQuery, CancellationToken cancellationToken) =>
        {
            var responses = await listSurveyQuery.Handle(cancellationToken);

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}