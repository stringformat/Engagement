using Engagement.Application.Features.Questions.Update;

namespace Engagement.Api.Questions.Update;

public static class Endpoint
{
    public static WebApplication MapQuestionUpdate(this WebApplication app)
    {
        app.MapPut("api/questions/{id:guid}", async (Guid id, Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(new UpdateQuestionCommand(id, request.Name, request.Description));
            
            return response.IsSuccess 
                ? Results.Ok(Response.FromCommand(response)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}