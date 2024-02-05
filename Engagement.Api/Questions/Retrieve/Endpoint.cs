using Engagement.Application.Features.Questions.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public static class Endpoint
{
    public static WebApplication MapQuestionRetrieve(this WebApplication app)
    {
        app.MapGet("api/questions/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new RetrieveQuestionQuery(id));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromQuery(response))
                : response.Error.ToResponse();
        });

        return app;
    }
}