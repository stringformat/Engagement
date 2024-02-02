using Engagement.Application.Features.Questions.Reply;

namespace Engagement.Api.Questions.Reply;

public static class Endpoint
{
    public static WebApplication MapQuestionReply(this WebApplication app)
    {
        app.MapPost("api/questions/{id:guid}/reply", async (Guid id, Request request, IMediator mediator) =>
        {
            var command = new ReplyQuestionCommand(id, request.ToCommand());
            var response = await mediator.Send(command);
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response.Value)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}