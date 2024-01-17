using Engagement.Application.Features.Questions.List;

namespace Engagement.Api.Questions.List;

public static class Endpoint
{
    public static WebApplication MapQuestionList(this WebApplication app)
    {
        app.MapGet("api/questions", async (IMediator mediator) =>
        {
            var responses = await mediator.Send(new ListQuestionQuery());

            return responses.Select(Response.FromQuery);
        });

        return app;
    }
}