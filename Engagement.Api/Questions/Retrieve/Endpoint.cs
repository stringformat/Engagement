using Engagement.Application.Features.Questions.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public static class Endpoint
{
    public static WebApplication MapQuestionRetrieve(this WebApplication app)
    {
        app.MapGet("api/questions/{id:guid}", async (Guid id, RetrieveQuestionQuery retrieveQuestionQuery, CancellationToken cancellationToken) =>
        {
            var response = await retrieveQuestionQuery.Handle(new RetrieveQuestionRequest(id), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromQuery(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}