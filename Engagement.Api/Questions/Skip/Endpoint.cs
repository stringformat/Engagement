using Engagement.Application.Features.Questions.Skip;

namespace Engagement.Api.Questions.Skip;

public static class Endpoint
{
    public static WebApplication MapQuestionSkip(this WebApplication app)
    {
        app.MapPost("api/questions/{id:guid}/skip", async (Guid id, Request request, SkipQuestionCommand skipQuestionCommand, CancellationToken cancellationToken) =>
        {
            var response =
                await skipQuestionCommand.Handle(new SkipQuestionRequest(id, request.UserId), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}