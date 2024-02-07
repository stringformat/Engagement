using Engagement.Application.Features.Questions.Reply;

namespace Engagement.Api.Questions.Reply;

public static class Endpoint
{
    public static WebApplication MapQuestionReply(this WebApplication app)
    {
        app.MapPost("api/questions/{id:guid}/reply", async (Guid id, Request request, ReplyQuestionCommand replyQuestionCommand, CancellationToken cancellationToken) =>
        {
            var response = await replyQuestionCommand.Handle(request.ToCommandRequest(id), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}