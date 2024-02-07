using Engagement.Application.Features.Questions.List;

namespace Engagement.Api.Questions.List;

public static class Endpoint
{
    public static WebApplication MapQuestionList(this WebApplication app)
    {
        app.MapGet("api/questions", async (ListQuestionQuery listQuestionQuery, CancellationToken cancellationToken) =>
        {
            var responses = await listQuestionQuery.Handle(cancellationToken);

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}