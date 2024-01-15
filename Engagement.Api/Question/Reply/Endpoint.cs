using Engagement.Application.Features.Question.Reply;
using MediatR;

namespace Engagement.Api.Question.Reply;

public static class Endpoint
{
    public static WebApplication MapQuestionCreate(this WebApplication app)
    {
        app.MapPost("api/questions/{id:guid}/reply", async (Guid id, Request request, IMediator mediator) =>
        {
            var command = new ReplyQuestionCommand(id, new ReplyQuestionCommand.AnswerCommand(request.Value, request.Commentary, request.UserId));
            var response = await mediator.Send(command);
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : Results.BadRequest();
        });

        return app;
    }
}