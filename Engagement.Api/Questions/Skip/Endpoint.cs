using Engagement.Application.Features.Questions.Skip;

namespace Engagement.Api.Questions.Skip;

public static class Endpoint
{
    public static WebApplication MapQuestionSkip(this WebApplication app)
    {
        app.MapPost("api/questions/{id:guid}/skip", async (Guid id, Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(new SkipQuestionCommand(id, request.UserId));
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}