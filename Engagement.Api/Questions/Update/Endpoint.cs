using Engagement.Application.Features.Questions.Update;

namespace Engagement.Api.Questions.Update;

public static class Endpoint
{
    public static WebApplication MapQuestionUpdate(this WebApplication app)
    {
        app.MapPut("api/questions/{id:guid}", async (Guid id, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateQuestionCommand(id, request.Name, request.Description));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}